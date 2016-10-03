using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        private void FuseToolforStack(Stack<Point> needCheckedPixel, Bitmap img, int x, int y)
        {
            int r = img.GetPixel(x, y).R;
            int g = img.GetPixel(x, y).G;
            int b = img.GetPixel(x, y).B;
            double average = (r + g + b) / 3;
            if (average!= 255)
            {
                Point item = new Point(x, y);
                needCheckedPixel.Push(item);
            }
            return;
        }

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
                {
                    FuseToolforStack(needCheckedPixel, img, I - 1, J);
                }
            }
        }
    }
}
