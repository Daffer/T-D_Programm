﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP
{
    public class ProgramImage
    {
        public ProgramImage()
        {
            PixelMapList = new List<Bitmap>();
        }
        //  вспомогательная функция, получающая RGB
        public void GetRGB(Bitmap img, int x, int y, ref int r, ref int g, ref int b)
        {
            r = img.GetPixel(x, y).R;
            g = img.GetPixel(x, y).G;
            b = img.GetPixel(x, y).B;
            return;
        }
        //  вспомогательная функция, получающая компоненту цвета
        public double ColourComponent(Bitmap img, int x, int y)
        {
            if (x < 0 || y < 0 || x >= img.Width || y >= img.Height)
                return -1;
            int r = 0, g = 0, b = 0;
            GetRGB(img, x, y, ref r, ref g, ref b);
            double average = (r + g + b) / 3;
            return average;
        }
        //  вспомогательная функция осуществляющая анализ пикселя на засвеченность
        public void FuseToolforStack(Stack<Point> needCheckedPixel, Bitmap img, int x, int y)
        {
            double colour = ColourComponent(img, x, y);
            if (colour != 255)
            {
                Point item = new Point(x, y);
                needCheckedPixel.Push(item);
            }
            return;
        }
        //  Затравка
        public void Fuse(int x, int y, Bitmap img, int h, int w)
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
        public void BorderProcessingHelper(Bitmap img, int height, int width, int x, int y)
        {
            double colour = ColourComponent(img, x, y);
            if (colour != 255)
            {
                Fuse(x, y, img, width, height);
            }
            return;
        }
        //  обработка краев изображения
        public int BorderProcessing(int index)
        {
            int j;
            if (index < 0 || index > PixelMapList.Count || PixelMapList.Count == 0)
            {
                return -1;
            }
            int height = 0;
            int width = 0;
            Bitmap newmap = CreateNewMapForMap(index, ref height, ref width);
            if (newmap == null)
                return -1;
            for (j = 0; j < height; j++)
            {
                BorderProcessingHelper(newmap, height, width, 0, j);
                BorderProcessingHelper(newmap, height, width, 1, j);
                BorderProcessingHelper(newmap, height, width, width - 2, j);
                BorderProcessingHelper(newmap, height, width, width - 1, j);
            }
            for (j = 0; j < width; j++)
            {
                BorderProcessingHelper(newmap, height, width, j, 0);
                BorderProcessingHelper(newmap, height, width, j, 1);
                BorderProcessingHelper(newmap, height, width, j, height - 2);
                BorderProcessingHelper(newmap, height, width, j, height - 1);
            }
            PixelMapList.Add(newmap);
            return 0;
        }
        //  получение негатива изображения
        public int Negativ(int index)
        {
            int i, j;
            if (index < 0 || index > PixelMapList.Count || PixelMapList.Count == 0)
            {
                return -1;
            }
            int height = 0;
            int width = 0;
            Bitmap img = CreateNewMapForMap(index, ref height, ref width);
            for (i = 0; i < img.Width; i++)
            {
                for (j = 0; j < img.Height; j++)
                {
                    int r = 0, g = 0, b = 0;
                    GetRGB(img, i, j, ref r, ref g, ref b);
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;
                    img.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            PixelMapList.Add(img);
            return 0;
        }
        //  вспомогательная функция корректировки компонента цвета
        public int ExtremateColor(int source, int changeval)
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
        public int ContrastPixel(int val, int n)
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
        public int Contrast(int indexmap, int n)
        {
            int i, j;
            if (indexmap < 0 || indexmap > PixelMapList.Count || PixelMapList.Count == 0)
            {
                return -1;
            }
            int height = 0;
            int width = 0;
            Bitmap newmap = CreateNewMapForMap(indexmap, ref height, ref width);
            if (newmap == null)
                return -1;
            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    int r = 0, g = 0, b = 0;
                    GetRGB(newmap, i, j, ref r, ref g, ref b);
                    r = ContrastPixel(r, n);
                    g = ContrastPixel(g, n);
                    b = ContrastPixel(b, n);
                    newmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            PixelMapList.Add(newmap);
            return 0;
        }
        //  Константы аппроксимирующие цветовые характеристики
        private double RedApproximation = 0.299;
        private double GreenApproximation = 0.587;
        private double BlueApproximation = 0.114;
        // конвертация изображения
        public void ConvertImage(Bitmap image, int[,] InfoMatrix)
        {
            int r = 0, g = 0, b = 0;
            int y;
            for (int I = 0; I < image.Width; I++)
            {
                for (int J = 0; J < image.Height; J++)
                {
                    GetRGB(image, I, J, ref r, ref g, ref b);
                    y = Convert.ToInt32(RedApproximation * r + GreenApproximation * g + BlueApproximation * b);
                    if ((r == 0) && (g == 0) && (b == 0))
                        InfoMatrix[I, J] = 1;
                    else
                        InfoMatrix[I, J] = 0;
                }

            }
            return;
        }
        //  функция обратной конвертации
        public void BackConvertImage(Bitmap image, int[,] InfoMatrix)
        {
            for (int I = 0; I < image.Width; I++)
            {
                for (int J = 0; J < image.Height; J++)
                {
                    if (InfoMatrix[I, J] == 1)
                        image.SetPixel(I, J, Color.FromArgb(0, 0, 0));
                    else if (InfoMatrix[I, J] == 0)
                        image.SetPixel(I, J, Color.FromArgb(0, 0, 0));
                }
            }
            return;
        }
        // Функция эрозии изображения
        public void Erosion(Bitmap image, int[,] InfoMatrix)
        {
            int[,] matrix = new int[image.Width, image.Height];
            int count;
            int K, L;
            for (int I = 1; I < image.Width - 3; I++)
            {
                for(int J = 1; J < image.Height - 3; J++)
                {
                    count = 0;
                    K = -1;
                    L = -1;
                    while ((InfoMatrix[I + K, J + L] != 0) && (K < 2)) 
                    {
                        count++;
                        if (L<1)
                        {
                            L++;
                        }
                        else
                        {
                            L--;
                            K++;
                        }
                    }
                    if (count == 9)
                        matrix[I, J] = 1;
                    else
                        matrix[I, J] = 0;
                }
            }
            for (int I = 1; I < image.Width - 1; I++) 
            {
                for (int J = 1; J < image.Height - 1; J++) 
                {
                    InfoMatrix[I, J] = matrix[I, J];
                }
            }
            return;
        }
        //  Дилатация изображения
        public void Dilatation(Bitmap PixelMap, int[,] InfoMatrix)
        {
            int h = PixelMap.Height;
            int w = PixelMap.Width;
            int[,] matrix = new int[w, h];
            for (int I = 0; I < w; I++) 
            {
                for (int J = 0; J < h; J++) 
                {
                    matrix[I, J] = 0;
                }
            }
            int result;
            for (int I = 1; I<w; I++)
            {
                for (int J = 1; J<h; J++)
                {
                    result = 0;
                    for (int K = -1; K <= 1; K++) 
                    {
                        for (int L = -1; L <= 1; L++) 
                        {
                            result += InfoMatrix[I + K, J + L];
                        }
                    }
                    if (result > 0)
                        matrix[I, J] = 1;
                    else
                        matrix[I, J] = 0;
                }
            }
            for (int I = 0; I < w - 1; I++)
            {
                for (int J = 0; J < h - 1; J++)
                {
                    InfoMatrix[I, J] = matrix[I, J];
                }
            }
            return;
        }
        //  Функция проверки дилатации и эрозии изображения
        public void CheckErodeAndDilatation(Bitmap PixelMap, int[,] InfoMatrix)
        {
            for (int I = 0; I < PixelMap.Height; I++)
            {
                for (int J = 0; J < PixelMap.Width; J++) 
                {
                    if ((InfoMatrix[I, J] != 0) && (InfoMatrix[I, J] != 1))
                        InfoMatrix[I, J] = 0;
                }
            }
            return;
        }
        //  Метод Оцу
        public int MethodOtsu(int index)
        {
            if (index < 0 || index > PixelMapList.Count || PixelMapList.Count == 0)
            {
                return -1;
            }
            int height = 0;
            int width = 0;
            Bitmap newmap = CreateNewMapForMap(index, ref height, ref width);
            if (newmap == null)
                return -1;
            int[] p = new int[256];// ?
            double[] pp = new double[256];//?
            int total = 0;
            int r = 0, g = 0, b = 0, res = 0;
            for (int I = 0; I < p.Length; I++) 
                p[I] = 0;
            for (int I = 0; I< newmap.Width; I++)
            {
                for(int J = 0; J<newmap.Height; J++)
                {
                    GetRGB(newmap, I, J, ref r, ref g, ref b);
                    res = Convert.ToInt32(RedApproximation * r + GreenApproximation * g + BlueApproximation * b);
                    p[res]++;
                }
            }
            for (int I = 0; I < 256; I++)
                total += p[I];
            for (int I = 0; I < 256; I++)
                pp[I] = Convert.ToDouble(p[I]) / Convert.ToDouble(total);
            int t = 0;
            double q1, q2, m1, m2, s1, s2 ,sw = Double.MaxValue; //?
            for (int I = 0; I< 256; I++)
            {
                q1 = q2 = 0;
                m1 = m2 = 0;
                s1 = s2 = 0;
                for (int J = 0; J <= I; J++)
                    q1 += pp[J];
                for (int J = I + 1; J < 256; J++)
                    q2 += pp[J];
                for (int J = 0; J <= I; J++) 
                    m1 += J * pp[J] / q1;
                for (int J = I + 1; J < 256; J++)
                    m2 += J * pp[J] / q2;
                for (int J = 0; J <= I; J++)
                    s1 += Math.Pow((J - m1), 2) * pp[J] / q1;
                for (int J = I + 1; J < 256; J++)
                    s2 += Math.Pow((J - m2), 2) * pp[J] / q2;
                if ((q1 * s1 + q2 * s2) < sw)
                {
                    sw = q1 * s1 + q2 * s2;
                    t = I;
                }
            }
            for (int I = 0; I < newmap.Width; I++) 
            {
                for (int J = 0; J < newmap.Height; J++) 
                {
                    GetRGB(newmap, I, J, ref r, ref g, ref b);
                    res = Convert.ToInt32(RedApproximation * r + GreenApproximation * g + BlueApproximation * b);
                    if (res > t)
                        newmap.SetPixel(I, J, Color.FromArgb(0, 0, 0));
                    else
                        newmap.SetPixel(I, J, Color.FromArgb(255, 255, 255));
                }
            }
            PixelMapList.Add(newmap);
            return 0;
        }

        public int Brightness(int indexmap, int n)
        {
            int i, j;
            if (indexmap < 0 || indexmap > PixelMapList.Count || PixelMapList.Count == 0)
            {
                return -1;
            }
            int height = 0;
            int width = 0;
            Bitmap newmap = CreateNewMapForMap(indexmap, ref height, ref width);
            if (newmap == null)
                return -1;
            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    int r = 0, g = 0, b = 0;
                    GetRGB(newmap, i, j, ref r, ref g, ref b);
                    r = r + n;
                    g = g + n;
                    b = b + n;
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;

                    if (r < 0) r = 0;
                    if (g < 0) g = 0;
                    if (b < 0) b = 0;
                    newmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            PixelMapList.Add(newmap);
            return 0;
        }
        public List<Bitmap> GetBitmapList()
        {
            return this.PixelMapList;
        }
        public void SetBitmapList(List<Bitmap> a)
        {
            this.PixelMapList = a;
        }
        private List<Bitmap> PixelMapList;
        public Bitmap GetLastBitmap()
        {
            return GetBitmap(PixelMapList.Count - 1);
        }
        public int GetCountImages()
        {
            return PixelMapList.Count;
        }
        public Bitmap GetBitmap(int index)
        {
            if (index < 0 || index > PixelMapList.Count)
                return null;
            return PixelMapList[index];
        }
        public void AddNewImage(Bitmap newmap)
        {
            PixelMapList.Add(newmap);
            return;
        }
        private Bitmap CreateNewMapForMap(int index, ref int height, ref int width)
        {
            if (index < 0 || index > PixelMapList.Count || PixelMapList.Count == 0)
            {
                return null;
            }
            width = PixelMapList[index].Width;
            height = PixelMapList[index].Height;
            Bitmap newmap = new Bitmap(width, height);
            Rectangle rec = new Rectangle(0, 0, width, height);
            //newmap.Clone(rec, PixelMapList[index].PixelFormat);
            for (int I = 0; I < newmap.Width; I++)
            {
                for (int J = 0; J < newmap.Height; J++)
                {
                    int r = 0, g = 0, b = 0;
                    GetRGB(PixelMapList[index], I, J, ref r, ref g, ref b);
                    newmap.SetPixel(I, J, Color.FromArgb(r, g, b));
                }
            }
            return newmap;
        }
        // что осталось 
        // void handy_binarization(int t);
        // void brightness(int n);
        // void make_border();
        // int make_calculations();
        // int make_cart();
    }
}
