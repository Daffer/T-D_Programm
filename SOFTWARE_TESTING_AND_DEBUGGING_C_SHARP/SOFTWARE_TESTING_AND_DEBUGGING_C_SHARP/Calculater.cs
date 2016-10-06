using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTWARE_TESTING_AND_DEBUGGING_C_SHARP
{
    class Calculater
    {
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
