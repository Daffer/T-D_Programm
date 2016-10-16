using System;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;
using System.Drawing;
using System.IO;
using SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP;
using System.Drawing;

namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP.UnitTests
{
    [TestFixture]
    public class ProgrammImage_NUnitTests
    {
        [Test]
        public void SquareCalculate_CorrectCalculate()
        {
            int correctanswer = 99;
            ProgramImage item = new ProgramImage();
            int x = 2;
            int y = 2;
            int num = 1;
            int h = 10;
            int w = 10;
            int[,] matrix = new int[w, h];
            for (int I = 0; I < w; I++)
                for (int J = 0; J < h; J++)
                    if (I == 5 && J == 5)
                        matrix[I, J] = 1;
                    else
                        matrix[I, J] = 0;
            Assert.AreEqual(item.SquareCalculate(x, y, num, matrix, h, w), correctanswer);
        }

        [Test]
        public void SquareCalculate_InvalidWidthToCalculate_Less()
        {
            int correctanswer = -1;
            int x = 2;
            int y = 5;
            int h = 10;
            int w = 10;
            int invalid_w1 = -1;
            int num = 1;
            int[,] matrix = new int[w, h];
            for (int I = 0; I < w; I++)
                for (int J = 0; J < h; J++)
                    if (I == 5 && J == 5)
                        matrix[I, J] = 1;
                    else
                        matrix[I, J] = 0;
            ProgramImage item = new ProgramImage();
            Assert.AreEqual(item.SquareCalculate(x, y, num, matrix, h, invalid_w1), correctanswer);
        }

        [Test]
        public void SquareCalculate_InvalidWidthToCalculate_Above()
        {
            int correctanswer = -2;
            int x = 2;
            int y = 5;
            int h = 10;
            int w = 10;
            int invalid_w1 = w+2;
            int num = 1;
            int[,] matrix = new int[w, h];
            for (int I = 0; I < w; I++)
                for (int J = 0; J < h; J++)
                    if (I == 5 && J == 5)
                        matrix[I, J] = 1;
                    else
                        matrix[I, J] = 0;
            ProgramImage item = new ProgramImage();
            Assert.AreEqual(item.SquareCalculate(x, y, num, matrix, h, invalid_w1), correctanswer);
        }

        [Test]
        public void SquareCalculate_InvalidHeightToCalculate_Less()
        {
            int correctanswer = -1;
            int x = 2;
            int y = 5;
            int h = 10;
            int w = 10;
            int invalid_h = -1;
            int num = 1;
            int[,] matrix = new int[w, h];
            for (int I = 0; I < w; I++)
                for (int J = 0; J < h; J++)
                    if (I == 5 && J == 5)
                        matrix[I, J] = 1;
                    else
                        matrix[I, J] = 0;
            ProgramImage item = new ProgramImage();
            Assert.AreEqual(item.SquareCalculate(x, y, num, matrix, invalid_h, w), correctanswer);
        }

        [Test]
        public void SquareCalculate_InvalidHeightToCalculate_Above()
        {
            int correctanswer = -2;
            int x = 2;
            int y = 5;
            int h = 10;
            int w = 10;
            int invalid_h = 12;
            int num = 1;
            int[,] matrix = new int[w, h];
            for (int I = 0; I < w; I++)
                for (int J = 0; J < h; J++)
                    if (I == 5 && J == 5)
                        matrix[I, J] = 1;
                    else
                        matrix[I, J] = 0;
            ProgramImage item = new ProgramImage();
            Assert.AreEqual(item.SquareCalculate(x, y, num, matrix, invalid_h, w), correctanswer);
        }

        [Test]
        public void SquareCalculate_InvalidStartPointToCalculate_Less()
        {
            int correctanswer = 0;
            int x1 = -1;
            int y1 = 0;
            int x2 = -1;
            int y2 = -1;
            int x3 = 0;
            int y3 = -1;
            int x4 = -1;
            int y4 = -1;
            int x5 = 11;
            int y5 = 0;
            int x6 = 11;
            int y6 = 11;
            int x7 = 0;
            int y7 = 11;
            int x8 = 11;
            int y8 = 11;
            int h = 10;
            int w = 10;
            int num = 1;
            int[,] matrix = new int[w, h];
            for (int I = 0; I < w; I++)
                for (int J = 0; J < h; J++)
                    if (I == 5 && J == 5)
                        matrix[I, J] = 1;
                    else
                        matrix[I, J] = 0;
            ProgramImage item = new ProgramImage();
            Assert.AreEqual(item.SquareCalculate(x1, y1, num, matrix, h, w), correctanswer);
            Assert.AreEqual(item.SquareCalculate(x2, y2, num, matrix, h, w), correctanswer);
            Assert.AreEqual(item.SquareCalculate(x3, y3, num, matrix, h, w), correctanswer);
            Assert.AreEqual(item.SquareCalculate(x4, y4, num, matrix, h, w), correctanswer);
            Assert.AreEqual(item.SquareCalculate(x5, y5, num, matrix, h, w), correctanswer);
            Assert.AreEqual(item.SquareCalculate(x6, y6, num, matrix, h, w), correctanswer);
            Assert.AreEqual(item.SquareCalculate(x7, y7, num, matrix, h, w), correctanswer);
            Assert.AreEqual(item.SquareCalculate(x8, y8, num, matrix, h, w), correctanswer);
        }

        [Test]
        public void ColourComponent_CorrectWork()
        {
            int correctanswer = 255;
            ProgramImage item = new ProgramImage();
            Bitmap map = new Bitmap(1,1);
            map.SetPixel(0, 0, Color.FromArgb(255, 255, 255));
            int x = 0;
            int y = 0;
            Assert.AreEqual(item.ColourComponent(map, x, y), correctanswer);
        }

        [Test]
        public void ColourComponent_InvalidPoint()
        {
            int correctanswer = -1;
            ProgramImage item = new ProgramImage();
            Bitmap map = new Bitmap(1, 1);
            map.SetPixel(0, 0, Color.FromArgb(255, 255, 255));
            int x1 = -1;
            int y1 = 0;
            int x2 = -1;
            int y2 = -1;
            int x3 = 0;
            int y3 = -1;
            int x4 = -1;
            int y4 = -1;
            int x5 = 1;
            int y5 = 0;
            int x6 = 1;
            int y6 = 1;
            int x7 = 0;
            int y7 = 1;
            int x8 = 1;
            int y8 = 1;
            Assert.AreEqual(item.ColourComponent(map, x1, y1), correctanswer);
            Assert.AreEqual(item.ColourComponent(map, x2, y2), correctanswer);
            Assert.AreEqual(item.ColourComponent(map, x3, y3), correctanswer);
            Assert.AreEqual(item.ColourComponent(map, x4, y4), correctanswer);
            Assert.AreEqual(item.ColourComponent(map, x5, y5), correctanswer);
            Assert.AreEqual(item.ColourComponent(map, x6, y6), correctanswer);
            Assert.AreEqual(item.ColourComponent(map, x7, y7), correctanswer);
            Assert.AreEqual(item.ColourComponent(map, x8, y8), correctanswer);
        }

        [Test]
        public void IsBorder_CorrectBorder()
        {
            bool correctanswer = true;
            int h = 3;
            int w = 3;
            int x = 1;
            int y = 1;
            ProgramImage item = new ProgramImage();
            int[,] matrix = new int[w, h];
            for (int I = 0; I < w; I++)
                for (int J = 0; J < h; J++)
                    matrix[1, 1] = 1;
            Assert.AreEqual(item.IsBorder(matrix, x, y, h, w), correctanswer);
        }

        [Test]
        public void IsBorder_InvalidStartPoint()
        {
            bool correctanswer = false;
            int h = 3;
            int w = 3;
            int x1 = -1;
            int y1 = 0;
            int x2 = -1;
            int y2 = -1;
            int x3 = 0;
            int y3 = -1;
            int x4 = -1;
            int y4 = -1;
            int x5 = w + 1;
            int y5 = 0;
            int x6 = w + 1;
            int y6 = h + 1;
            int x7 = 0;
            int y7 = h + 1;
            int x8 = w + 1;
            int y8 = h + 1;
            ProgramImage item = new ProgramImage();
            int[,] matrix = new int[w, h];
            for (int I = 0; I < w; I++)
                for (int J = 0; J < h; J++)
                    matrix[1, 1] = 1;
            Assert.AreEqual(item.IsBorder(matrix, x1, y1, h, w), correctanswer);
            Assert.AreEqual(item.IsBorder(matrix, x2, y2, h, w), correctanswer);
            Assert.AreEqual(item.IsBorder(matrix, x3, y3, h, w), correctanswer);
            Assert.AreEqual(item.IsBorder(matrix, x4, y4, h, w), correctanswer);
            Assert.AreEqual(item.IsBorder(matrix, x5, y5, h, w), correctanswer);
            Assert.AreEqual(item.IsBorder(matrix, x6, y6, h, w), correctanswer);
            Assert.AreEqual(item.IsBorder(matrix, x7, y7, h, w), correctanswer);
            Assert.AreEqual(item.IsBorder(matrix, x8, y8, h, w), correctanswer);
        }

        [Test]
        public void IsBorder_NullMatrix()
        {
            bool correctanswer = false;
            int h = 3;
            int w = 3;
            int x = 1;
            int y = 1;
            ProgramImage item = new ProgramImage();
            Assert.AreEqual(item.IsBorder(null, x, y, h, w), correctanswer);
        }
        [Test]
        public void InitMatrixNoMatrix()
        {
            int w = 800;
            int h = 600;
            ProgramImage item = new ProgramImage();
            int err = 0;
            int[,] matr = new int[w, h];
            err = item.InitMatrix(null, w, h);
            Assert.AreEqual(err, -1);
        }
        [Test]
        public void InitMatrixCorrect()
        {
            int w = 800;
            int h = 600;
            ProgramImage item = new ProgramImage();
            int err = 0;
            int[,] matr = new int[w, h];
            err = item.InitMatrix(matr, w, h);
            Assert.AreEqual(err, 0);
        }
        [Test]
        public void InitMatrixGreatSize()
        {
            int w = 2000;
            int h = 2000;
            ProgramImage item = new ProgramImage();
            int err = 0;
            int[,] matr = new int[w, h];
            err = item.InitMatrix(matr, w, h);
            Assert.AreEqual(err, -2);
        }
        [Test]
        public void ContrastPixelNoChange()
        {
            ProgramImage item = new ProgramImage();
            int r = 127;
            int res = 0;
            int n = 0;
            res = item.ContrastPixel(r, n);
            Assert.AreEqual(r, res);
        }
        [Test]
        public void ContrastPixelOver255()
        {
            // changes for over 255
            ProgramImage item = new ProgramImage();
            int r = 255;
            int res = 0;
            int n = 255;
            res = item.ContrastPixel(r, n);
            Assert.AreEqual(r, res);
        }
        [Test]
        public void ContrastPixelBelowZero()
        {
            // changes for over 255
            ProgramImage item = new ProgramImage();
            int r = 0;
            int res = 255;
            int n = -255;
            res = item.ContrastPixel(r, n);
            Assert.AreEqual(r, res);
        }
        [Test]
        public void ContrastPixelCorrect()
        {
            // changes for over 255
            ProgramImage item = new ProgramImage();
            int r = 0;
            int res = 2;
            int n = -1;
            r = item.ContrastPixel(r, n);
            Assert.AreEqual(r, res);
        }

        [Test]
        public void ContrastNoImage()
        {
            ProgramImage item = new ProgramImage();
            int err = 0;
            Bitmap map = new Bitmap(1, 1);
            map.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            err = item.Contrast(null, 10);
            Assert.AreEqual(err, -1);
        }
        [Test]
        public void ContrastCorrect()
        {
            // changes for over 255
            ProgramImage item = new ProgramImage();
            int err = 0;
            Bitmap map = new Bitmap(1, 1);
            map.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            err = item.Contrast(map, 10);
            Assert.AreEqual(err, 0);
        }
        [Test]
        public void PerimetrNoMatrix()
        {
            ProgramImage item = new ProgramImage();
            int count = 0;
            count = item.Perimetr(null, 2, 800, 600);
            Assert.AreEqual(count, -1);
        }
        [Test]
        public void PerimetrCorrect()
        {
            ProgramImage item = new ProgramImage();
            int count = 0;
            int[,] matr = new int[5, 5];
            matr[0, 0] = 2;
 
            count = item.Perimetr(matr, 2, 1, 1);
            Assert.AreEqual(count, 0);
        }
        [Test]
        public void PerimetrGreatSize()
        {
            ProgramImage item = new ProgramImage();
            int count = 0;
            int[,] matr = new int[1, 1];
            matr[0, 0] = 2;
            count = item.Perimetr(matr, 2, 2000, 2000);
            Assert.AreEqual(count, -1);
        }
        [Test]
        public void PerimetrNegativeNum()
        {
            ProgramImage item = new ProgramImage();
            int count = 0;
            int[,] matr = new int[1, 1];
            matr[0, 0] = 2;
            count = item.Perimetr(matr, -1, 2000, 2000);
            Assert.AreEqual(count, -1);
        }
    }
}
