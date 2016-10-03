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
        int Fuse(int x, int y, int num, int[][] matrix, int h, int w)
        {
            int result = 0;
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
                if (I<h-1)
                {

                }
            }
            return result;
        }
    }
}
