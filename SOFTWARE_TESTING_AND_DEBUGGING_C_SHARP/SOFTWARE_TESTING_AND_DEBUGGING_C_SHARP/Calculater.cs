using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP
{
    public class Calculater
    {
        public Calculater(ProgramImage reference)
        {
            ReferenceImage = reference;
        }
        private ProgramImage ReferenceImage;
        private double rate = 1;
        //  Вспомогательная функция для подсчета площади зоны (заносит новые пиксели для подсчета)
        private void SquareToolforStack(Stack<Point> needCheckedPixel, int[,] matrix, int newNum, int x, int y)
        {
            Point item = new Point(x, y);
            needCheckedPixel.Push(item);
            matrix[x, y] = newNum;
            return;
        }
        //  Подсчет площади выделенной зоны
        public int SquareCalculate(int x, int y, int num, int[,] matrix, int h, int w)
        {
            if (h < 0 || w < 0)
                return -1;              // Ошибка входных данных
            if (h * w > matrix.Length)
                return -2;              // Ошибка длины или высоты
            if (x > w || x < 0 || y > h || y < 0)
                return 0;
            int square = 0;
            int oldNum = matrix[x, y];
            Stack<Point> needCheckedPixel = new Stack<Point>();
            Point item = new Point(x, y);
            int I, J;
            needCheckedPixel.Push(item);
            while (needCheckedPixel.Count != 0)
            {
                item = needCheckedPixel.Pop();
                I = item.X;
                J = item.Y;
                if (matrix[I, J] != num)
                {
                    matrix[I, J] = num;
                    square++;
                }
                if (I < h - 1)
                    if (matrix[I + 1, J] == oldNum)
                    {
                        SquareToolforStack(needCheckedPixel, matrix, num, I + 1, J);
                        square++;
                    }
                if (I > 0)
                    if (matrix[I - 1, J] == oldNum)
                    {
                        SquareToolforStack(needCheckedPixel, matrix, num, I - 1, J);
                        square++;
                    }
                if (J < w - 1)
                    if (matrix[I, J + 1] == oldNum)
                    {
                        SquareToolforStack(needCheckedPixel, matrix, num, I, J + 1);
                        square++;
                    }
                if (J > 0)
                    if (matrix[I, J - 1] == oldNum)
                    {
                        SquareToolforStack(needCheckedPixel, matrix, num, I, J - 1);
                        square++;
                    }
            }
            return square;
        }
        //  Вспомогательная функция определяющая границу изображения
        private bool IsBorder(int[,] a, int I, int J, int h, int w)
        {
            if (I > w || I < 0 || J < 0 || J > h)
                return false;
            if (a == null)
                return false;
            if ((I > 0) && (a[I - 1, J] == 0))
                return true;
            if ((I < h - 1) && (a[I + 1, J] == 0))
                return true;
            if ((J < w - 1) && (a[I, J + 1] == 0))
                return true;
            if ((J > 0) && (a[I, J - 1] == 0))
                return true;
            return false;
        }
        //  Подсчет периметра
        public int Perimetr(int[,] matrix,int num, int h, int w)
        {
            int result = 0;
            int count = 0;
            int count_bor = 0;
            bool is_border;
            if (matrix == null)
                return -1;
            if (h * w >= 1920 * 1080)
                return -1;
            if (num < 0)
                return -1;
            for (int I = 0; I < h; I++)
            {
                for (int J = 0; J < w; J++)
                {
                    is_border = false;
                    if (matrix[I, J] == num)
                        is_border = IsBorder(matrix, I, J, h, w);
                    if (is_border)
                    {
                        count_bor++;
                        if ((I > 0) && (J > 0) && (!IsBorder(matrix, I - 1, J, h, w)) && (!IsBorder(matrix, I, J - 1, h, w)))
                            count++;
                        if ((I < h - 1) && (J > 0) && (!IsBorder(matrix, I + 1, J, h, w)) && (!IsBorder(matrix, I, J - 1, h, w)))
                            count++;
                        if ((I < h - 1) && (J < w - 1) && (!IsBorder(matrix, I + 1, J, h, w)) && (!IsBorder(matrix, I, J + 1, h, w)))
                            count++;
                        if ((I > 0) && (J < w - 1) && (!IsBorder(matrix, I - 1, J, h, w)) && (!IsBorder(matrix, I, J + 1, h, w)))
                            count++;
                    }
                }
            }
            result = Convert.ToInt32(count_bor + Convert.ToDouble(count * 0.2071));
            return result;
        }

        public int MakeCart(Bitmap map,ref int[,] matrix)
        {
            if (map == null || matrix == null)
                return - 1;
            int matrixheight = map.Height;
            int matrixwidth = map.Width;
            matrix = new int[matrixwidth,matrixheight];
            int nom = 1;
            for (int I = 0; I < map.Width; I++)
            {
                for (int J = 0; J < map.Height; J++)
                {
                    if (matrix[I,J] == 1)
                    {
                        nom += 1;
                        this.SquareCalculate(I, J, nom, matrix, matrixheight, matrixwidth);
                    }
                }
            }
            return nom;
        }

        public void CalculateWidth(int h, int w, int[,] matrix, int num, ref Particle[] particles)
        {
            for (int i = 2; i <= num; i++)
                particles[i - 2].Width = h * w;
            for (int n = 2; n <= num; n++)
            {
                int xlu = w;
                int ylu = h;
                int xrd = 0;
                int yrd = 0;
                int xn, yn;
                // находим две точки
                for (int i = 0; i < h; i++)
                    for (int j = 0; j < w; j++)
                        if (matrix[i, j] == n) 
                        {
                            if (i < ylu)
                                ylu = i;
                            if (i > yrd)
                                yrd = i;
                            if (j < xlu)
                                xlu = j;
                            if (j > xrd)
                                xrd = j;
                        }
                // находим центральную точку фигуры
                xn = (xlu + xrd) / 2;
                yn = (ylu + yrd) / 2;
                // находим Shortsize
                for (int i = ylu - 1; i <= yrd + 1; i++)
                    for (int j = xlu - 1; j <= xrd + 1; j++)
                        if (matrix[i, j] != n) 
                        {
                            double aa = Math.Sqrt((xn - j) * (xn - j) + (yn - i) * (yn - i));
                            if (aa < particles[n - 2].Width)
                                particles[n - 2].Width = aa;
                        }
            }
            for (int i = 2; i <= num; i++)
            {
                particles[i - 2].Width = particles[i - 2].Width * 2;
                if (particles[i - 2].Width == 0)
                    particles[i - 2].Width = 1;
            }
            return;
        }

        public int AllCalculations(ref Particle[] particles, int index)
        {
       
            int i, j;
            int nom = 1;
            Bitmap map = ReferenceImage.GetBitmap(index);
            if (map == null)
                return -1;
            int[,] matrix = new int[map.Width,map.Height];
            int countparticles = MakeCart(map, ref matrix);
            particles = new Particle[countparticles];
            for (int I = 0; I < particles.Length; I++)
            {
                particles[I] = new Particle();
            }
            for (i = 0; i < map.Width; i++)
            {
                for (j = 0; j < map.Height; j++)
                {
                    if (matrix[i,j] > 0)
                        matrix[i,j] = 1;
                }
            }
            for (i = 0; i < map.Width; i++)
            {
                for (j = 0; j < map.Height; j++)
                {
                    if (matrix[i,j] == 1)
                    {
                        nom += 1;
                        double sq = this.SquareCalculate(i, j, nom, matrix, map.Width, map.Height)*rate;
                        particles[nom - 2].Square = sq;
                    }
                }
            }
            /*calculation of the perimetrs*/
            for (i = 2; i <= countparticles; i++)
            {
                double pr = this.Perimetr(matrix, i, map.Width, map.Height)*rate;
                particles[i - 2].Perimetr = pr;
            }
            /*calculation of lengthes*/
            CalculateLength(map.Width, map.Height, matrix, countparticles, ref particles);
            /*calculation of widthes*/
            CalculateWidth(map.Width, map.Height, matrix, countparticles, ref particles);
            /*calculation of diameters*/
            for (i = 2; i <= countparticles; i++)
            {
                particles[i - 2].Diameter = 2 * Math.Sqrt(particles[i - 2].Square / 3.14 * rate);
                particles[i - 2].DiameterGost = Math.Sqrt(particles[i - 2].Square * rate);
                particles[i - 2].FormFactor = particles[i - 2].Width / particles[i - 2].Length;
                if (particles[i - 2].FormFactor > 1)
                    particles[i - 2].FormFactor = 1;
                particles[i - 2].Smoothness = (particles[i - 2].Perimetr * particles[i - 2].Perimetr) / (4 * 3.14 * particles[i - 2].Square);
            }
            return countparticles - 1;
        }

        public void CalculateLength(int h,int w, int[,] matrix, int num, ref Particle[] particle)
        {
            for (int I = 2; I <= num; I++)
                particle[I - 2].Length = 0;
            int xlu, ylu;
            int xrd, yrd;
            int xn, yn;
            for (int N = 2; N <= num; N++)
            {
                xlu = w;
                ylu = h;
                xrd = 0;
                yrd = 0;
                //  Находим две точки
                for (int I = 0; I < h; I++) 
                {
                    for (int J = 0; J < w; J++)
                    {
                        if (matrix[I,J] == N)
                        {
                            if (I < ylu)
                                ylu = I;
                            if (I > yrd)
                                yrd = I;
                            if (J < xlu)
                                xlu = J;
                            if (J > xrd)
                                xrd = J;
                        }
                    }
                }
                //  Находим центральную точку фигуры
                xn = (xlu + xrd) / 2;
                yn = (ylu + yrd) / 2;
                //  Находим Longsize - ?
                for (int I = ylu; I <= yrd; I++)
                {
                    for (int J = xlu; J <= xrd; J++)
                    {
                        if (matrix[I,J] == N)
                        {
                            double templength = Math.Sqrt(Math.Pow(xn - J, 2) + Math.Pow(yn - I, 2));
                            if (templength > particle[N - 2].Length)
                                particle[N - 2].Length = templength;
                        }
                    }
                }
            }
            for (int I = 2; I <= num; I++)
            {
                particle[I - 2].Length = particle[I - 2].Length * 2;
                if (particle[I - 2].Length == 0)
                    particle[I - 2].Length = 1;
            }
            return;
        }
        
    }
}
