using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP
{
    class Image
    {
        private void FuseToolforStack(Stack<Point> needCheckedPixel, int [][] matrix, int newNum, int x, int y)
        {
            Point item = new Point(x, y);
            needCheckedPixel.Push(item);
            matrix[x][y] = newNum;
            return;
        }

        int Fuse(int x, int y, int num, int[][] matrix, int h, int w)
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
                        FuseToolforStack(needCheckedPixel, matrix, num, I + 1, J);
                        square++;
                    }
                if (I > 0)
                    if ( matrix[I -1][J] == oldNum)
                    {
                        FuseToolforStack(needCheckedPixel, matrix, num, I - 1, J);
                        square++;
                    }
                if (J < w-1)
                    if (matrix[I][J+1] == oldNum)
                    {
                        FuseToolforStack(needCheckedPixel, matrix, num, I, J + 1);
                        square++;
                    }
                if (J > 0)
                    if (matrix[I][J-1] == oldNum)
                    {
                        FuseToolforStack(needCheckedPixel, matrix, num, I, J - 1);
                        square++;
                    }
            }
            return square;
        }
    }
}
