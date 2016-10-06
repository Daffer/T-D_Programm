using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP
{
    class ProgramImage
    {
        //  Вспомогательная функция для подсчета площади зоны (заносит новые пиксели для подсчета)
        private void SquareToolforStack(Stack<Point> needCheckedPixel, int [][] matrix, int newNum, int x, int y)
        {
            Point item = new Point(x, y);
            needCheckedPixel.Push(item);
            matrix[x][y] = newNum;
            return;
        }

        //  Подсчет площади выделенной зоны
        int SquareCalculate(int x, int y, int num, int[][] matrix, int h, int w)
        {
            int square = 0;
            int oldNum = matrix[x][y];
            Stack<Point> needCheckedPixel = new Stack<Point>();
            Point item = new Point(x, y);
            int I, J;
            needCheckedPixel.Push(item);
            while (needCheckedPixel.Count != 0)
            {
                item = needCheckedPixel.Pop();
                I = item.X;
                J = item.Y;
                if (matrix[I][J] != num)
                {
                    matrix[I][J] = num;
                    square++;
                }
                if (I < h - 1)
                    if (matrix[I + 1][J] == oldNum)
                    {
                        SquareToolforStack(needCheckedPixel, matrix, num, I + 1, J);
                        square++;
                    }
                if (I > 0)
                    if ( matrix[I -1][J] == oldNum)
                    {
                        SquareToolforStack(needCheckedPixel, matrix, num, I - 1, J);
                        square++;
                    }
                if (J < w-1)
                    if (matrix[I][J+1] == oldNum)
                    {
                        SquareToolforStack(needCheckedPixel, matrix, num, I, J + 1);
                        square++;
                    }
                if (J > 0)
                    if (matrix[I][J-1] == oldNum)
                    {
                        SquareToolforStack(needCheckedPixel, matrix, num, I, J - 1);
                        square++;
                    }
            }
            return square;
        }
        //  вспомогательная функция, получающая RGB
        private void GetRGB(Bitmap img, int x, int y, int r, int g, int b)
        {
            r = img.GetPixel(x, y).R;
            g = img.GetPixel(x, y).G;
            b = img.GetPixel(x, y).B;
            return;
        }
        //  вспомогательная функция, получающая компоненту цвета
        private double ColourComponent(Bitmap img, int x, int y)
        {
            int r = 0, g = 0, b = 0;
            GetRGB(img, x, y, r, g, b);
            double average = (r + g + b) / 3;
            return average;
        }
        //  вспомогательная функция осуществляющая анализ пикселя на засвеченность
        private void FuseToolforStack(Stack<Point> needCheckedPixel, Bitmap img, int x, int y)
        {
            double colour = ColourComponent(img, x, y);
            if (colour != 255)
            {
                Point item = new Point(x, y);
                needCheckedPixel.Push(item);
            }
            return;
        }

        private void Fuse(int x, int y, Bitmap img, int h, int w)
        {
            int I, J;
            Point item = new Point(x, y);
            Stack<Point> needCheckedPixel = new Stack<Point>();
            needCheckedPixel.Push(item);
            while(needCheckedPixel.Count != 0)
            {
                item = needCheckedPixel.Pop();
                I = item.X;
                J = item.Y;
                img.SetPixel(I,J,Color.FromArgb(255,255,255));
                if ( I - 1 >= 0)
                    FuseToolforStack(needCheckedPixel, img, I - 1, J);
                if ( J - 1 >= 0)
                    FuseToolforStack(needCheckedPixel, img, I, J - 1);
                if (I + 1 < h)
                    FuseToolforStack(needCheckedPixel, img, I + 1, J);
                if (J + 1 < w)
                    FuseToolforStack(needCheckedPixel, img, I, J + 1);
                if ((J + 1 < w) && (I + 1 < h))
                    FuseToolforStack(needCheckedPixel, img, I + 1, J + 1);
                if ((J - 1 >= 0) && (I + 1 < h))
                    FuseToolforStack(needCheckedPixel, img, I + 1, J - 1);
                if ((J + 1 < w) && (I - 1 >= 0))
                    FuseToolforStack(needCheckedPixel, img, I - 1, J + 1);
                if ((J - 1 >= 0) && (I - 1 >= 0))
                    FuseToolforStack(needCheckedPixel, img, I - 1, J - 1);
            }
        }

        //  вспомогательная функция обработки краев
        private void BorderProcessingHelper(Bitmap img, int height, int width, int x, int y)
        {
            double colour = ColourComponent(img, x, y);
            if (colour != 255)
            {
                Fuse(x, y, img, width, height);
            }
            return;
        }
        //  обработка краев изображения
        private void BorderProcessing(Bitmap img)
        {
            int i, j;
            int h = img.Height;
            int w = img.Width;

            for (j = 0; j < h; j++)
            {
                BorderProcessingHelper(img, h, w, 0, j);
                BorderProcessingHelper(img, h, w, 1, j);
                BorderProcessingHelper(img, h, w, w - 2, j);
                BorderProcessingHelper(img, h, w, w - 1, j);
            }
            for (j = 0; j < w; j++)
            {
                BorderProcessingHelper(img, h, w, j, 0);
                BorderProcessingHelper(img, h, w, j, 1);
                BorderProcessingHelper(img, h, w, j, h - 2);
                BorderProcessingHelper(img, h, w, j, h - 1);
            }
            return;
        }

        //  получение негатива изображения
        private void Negativ(Bitmap img)
        {
            int i, j;
            for (i = 0; i < img.Width; i++)
            {
                for (j = 0; j < img.Height; j++)
                {
                    int r = 0, g = 0, b = 0;
                    GetRGB(img, i, j, r, g, b);

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;
                    
                    img.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            return;
        }

        //  вспомогательная функция корректировки компонента цвета
        private int ExtremateColor(int source, int changeval)
        {
            if (changeval > 0)
            {
                if (source > 127)
                {
                    int Check = source + changeval;
                    if (Check > 255) return 255;
                    else return Check;
                }
                else
                {
                    int Check = source - changeval;
                    if (Check < 0) return 0;
                    else return Check;
                }
            }
            else
            {
                if (source > 127)
                {
                    int Check = source + changeval;
                    if (Check < 127) return 127;
                    else return Check;
                }
                else
                {
                    int Check = source - changeval;
                    if (Check > 127) return 127;
                    else return Check;
                }
            }
        }

        //  вспомогательная функция контрастирования пикселя
        private int ContrastPixel(int val, int n)
        {
            double pixel;
            double contrast = (100.0 + n) / 100.0;

            contrast = contrast * contrast;

            pixel = val / 255.0;
            pixel = pixel - 0.5;
            pixel = pixel * contrast;
            pixel = pixel + 0.5;
            pixel = pixel * 255;
            if (pixel < 0) pixel = 0;
            if (pixel > 255) pixel = 255;
            return (int)pixel;

        }
        //  функция контрастирования изображения
        private void Contrast(Bitmap img, int n)
        {
            int i, j;

            for (i = 0; i < img.Width; i++)
            {
                for (j = 0; j < img.Height; j++)
                {
                    int r = 0, g = 0, b = 0;
                    GetRGB(img, i, j, r, g, b);
                    r = ContrastPixel(r, n);
                    g = ContrastPixel(r, n);
                    b = ContrastPixel(r, n);
                    img.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            return;
        }

        private double RedApproximation = 0.299;
        private double GreenApproximation = 0.587;
        private double BlueApproximation = 0.114;
        // конвертация изображения
        public void ConvertImage(Bitmap image, int[][] matrix)
        {
            int r = 0, g = 0, b = 0;
            int y;
            for (int I = 0; I < image.Width; I++)
            {
                for (int J = 0; J < image.Height; J++)
                {
                    GetRGB(image, I, J, r, g, b);
                    y = Convert.ToInt32(RedApproximation * r + GreenApproximation * g + BlueApproximation * b);
                    if ((r == 0) && (g == 0) && (b == 0))
                        matrix[I][J] = 1;
                    else
                        matrix[I][J] = 0;
                }

            }
            return;
        }

        public void BackConvertImage(Bitmap image,int [][] matrix)
        {
            for (int I = 0; I < image.Width; I++)
            {
                for (int J = 0; J < image.Height; J++)
                {
                    if (matrix[I][J] == 1)
                        image.SetPixel(I, J, Color.FromArgb(0, 0, 0));
                    else if (matrix[I][J] == 0)
                        image.SetPixel(I, J, Color.FromArgb(0, 0, 0));
                }
            }
            return;
        }
    }
}
