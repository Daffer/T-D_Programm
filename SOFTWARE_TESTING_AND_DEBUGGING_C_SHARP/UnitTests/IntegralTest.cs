using System;
using System.Windows;
using System.Windows.Forms;
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
    public class IntegralTest
    {
        public delegate int Method(int indexmap, int value);

        [Test]
        public void TestContrastGUIResult()
        {
            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800,600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            FormBrightness testform = new FormBrightness(main.Images, main);
            testform.SubmitButton_Click(null, new EventArgs());
            Bitmap result = main.Images.GetLastBitmap();
            main.Images.Contrast(0, 127);
            Bitmap correct = main.Images.GetLastBitmap();
            bool equ = true;
            for (int I = 0; I < result.Width; I++)
            {
                for (int J = 0; J < result.Height; J++)
                {
                    Color temp1 = result.GetPixel(I, J);
                    Color temp2 = correct.GetPixel(I, J);
                    if (temp1 != temp2)
                    {
                        equ = false;
                        break;
                    }
                }
                if (!equ)
                    break;
            }
            Assert.AreEqual(equ, true);
        }

        [Test]
        public void TestCancelContrastNBrightnessGUIResult()
        {

            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800, 600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            int correctcountmap = main.Images.GetCountImages();
            FormBrightness testform = new FormBrightness(main.Images, main);
            testform.CancelButton_Click(null, new EventArgs());
            int result = main.Images.GetCountImages();
            Assert.AreEqual(result, correctcountmap);
        }

        [Test]
        public void TestBinarizationGUIResult()
        {
            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800, 600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            FormBinarization testform = new FormBinarization(main, main.Images);
            testform.AutoBinarizationButton_Click(null, new EventArgs());
            Bitmap result = main.Images.GetLastBitmap();
            main.Images.MethodOtsu(0);
            Bitmap correct = main.Images.GetLastBitmap();
            bool equ = true;
            for (int I = 0; I < result.Width; I++)
            {
                for (int J = 0; J < result.Height; J++)
                {
                    Color temp1 = result.GetPixel(I, J);
                    Color temp2 = correct.GetPixel(I, J);
                    if (temp1 != temp2)
                    {
                        equ = false;
                        break;
                    }
                }
                if (!equ)
                    break;
            }
            Assert.AreEqual(equ, true);
        }

        void GetMeasureInfoFromInterface(ref double[] result, int paramindex, FormAutoMeasureTable table)
        {
            result = new double[table.ParticlesInfoDataGridView.ColumnCount];
            for (int I = 0; I < table.ParticlesInfoDataGridView.RowCount; I++)
                result[I] = Convert.ToDouble(table.ParticlesInfoDataGridView[paramindex, I].Value);
            return;
        }

        void GetMeasureInfoFromCalc(ref Particle[] part, Calculater calc, int indexmap)
        {
            calc.AllCalculations(ref part,indexmap);
            return;
        }

        [Test]
        public void TestMeasureTableGUI_Square()
        {
            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800, 600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            FormAutoMeasureTable testform = new FormAutoMeasureTable(main, main.Images, main.Calc, 0);
            Particle[] part = null;
            double[] result = null;
            GetMeasureInfoFromInterface(ref result, 2, testform);
            GetMeasureInfoFromCalc(ref part, main.Calc, 0);
            bool equ = true;
            for (int I = 0; I < part.Length; I++)
                if (part[I].Square != result[I])
                {
                    equ = false;
                    break;
                }
            Assert.AreEqual(equ, true);
        }

        [Test]
        public void TestMeasureTableGUI_Perimetr()
        {
            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800, 600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            FormAutoMeasureTable testform = new FormAutoMeasureTable(main, main.Images, main.Calc, 0);
            Particle[] part = null;
            double[] result = null;
            GetMeasureInfoFromInterface(ref result, 1, testform);
            GetMeasureInfoFromCalc(ref part, main.Calc, 0);
            bool equ = true;
            for (int I = 0; I < part.Length; I++)
                if (part[I].Perimetr != result[I])
                {
                    equ = false;
                    break;
                }
            Assert.AreEqual(equ, true);
        }

        [Test]
        public void TestMeasureTableGUI_Length()
        {
            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800, 600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            FormAutoMeasureTable testform = new FormAutoMeasureTable(main, main.Images, main.Calc, 0);
            Particle[] part = null;
            double[] result = null;
            GetMeasureInfoFromInterface(ref result, 3, testform);
            GetMeasureInfoFromCalc(ref part, main.Calc, 0);
            bool equ = true;
            for (int I = 0; I < part.Length; I++)
                if (part[I].Length != result[I])
                {
                    equ = false;
                    break;
                }
            Assert.AreEqual(equ, true);
        }

        [Test]
        public void TestMeasureTableGUI_Width()
        {
            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800, 600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            FormAutoMeasureTable testform = new FormAutoMeasureTable(main, main.Images, main.Calc, 0);
            Particle[] part = null;
            double[] result = null;
            GetMeasureInfoFromInterface(ref result, 4, testform);
            GetMeasureInfoFromCalc(ref part, main.Calc, 0);
            bool equ = true;
            for (int I = 0; I < part.Length; I++)
                if (part[I].Width != result[I])
                {
                    equ = false;
                    break;
                }
            Assert.AreEqual(equ, true);
        }

        [Test]
        public void TestMeasureTableGUI_DiametrGOST()
        {
            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800, 600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            FormAutoMeasureTable testform = new FormAutoMeasureTable(main, main.Images, main.Calc, 0);
            Particle[] part = null;
            double[] result = null;
            GetMeasureInfoFromInterface(ref result, 5, testform);
            GetMeasureInfoFromCalc(ref part, main.Calc, 0);
            bool equ = true;
            for (int I = 0; I < part.Length; I++)
                if (part[I].DiameterGost != result[I])
                {
                    equ = false;
                    break;
                }
            Assert.AreEqual(equ, true);
        }

        [Test]
        public void TestMeasureTableGUI_Diametr()
        {
            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800, 600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            FormAutoMeasureTable testform = new FormAutoMeasureTable(main, main.Images, main.Calc, 0);
            Particle[] part = null;
            double[] result = null;
            GetMeasureInfoFromInterface(ref result, 6, testform);
            GetMeasureInfoFromCalc(ref part, main.Calc, 0);
            bool equ = true;
            for (int I = 0; I < part.Length; I++)
                if (part[I].Diameter != result[I])
                {
                    equ = false;
                    break;
                }
            Assert.AreEqual(equ, true);
        }

        [Test]
        public void TestMeasureTableGUI_Smoothness()
        {
            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800, 600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            FormAutoMeasureTable testform = new FormAutoMeasureTable(main, main.Images, main.Calc, 0);
            Particle[] part = null;
            double[] result = null;
            GetMeasureInfoFromInterface(ref result, 7, testform);
            GetMeasureInfoFromCalc(ref part, main.Calc, 0);
            bool equ = true;
            for (int I = 0; I < part.Length; I++)
                if (part[I].Smoothness != result[I])
                {
                    equ = false;
                    break;
                }
            Assert.AreEqual(equ, true);
        }

        [Test]
        public void TestMeasureTableGUI_FomrFactor()
        {
            MainForm main = new MainForm();
            Bitmap map = new Bitmap(800, 600);
            map.SetPixel(10, 10, Color.White);
            main.Images.AddNewImage(map);
            FormAutoMeasureTable testform = new FormAutoMeasureTable(main, main.Images, main.Calc, 0);
            Particle[] part = null;
            double[] result = null;
            GetMeasureInfoFromInterface(ref result, 7, testform);
            GetMeasureInfoFromCalc(ref part, main.Calc, 0);
            bool equ = true;
            for (int I = 0; I < part.Length; I++)
                if (part[I].FormFactor != result[I])
                {
                    equ = false;
                    break;
                }
            Assert.AreEqual(equ, true);
        }

        [Test]
        public void TestBinarizationNMeasureInfo()
        {
            ProgramImage image = new ProgramImage();
            Calculater calc = new Calculater(image);
            Bitmap map = new Bitmap(800, 600);
            for (int I = 0; I < 800; I++)
                for (int J = 0; J < 600; J++)
                    if(I<375 && I>425 && J < 275 && J > 325)
                        map.SetPixel(I, J, Color.White);
                    else
                        map.SetPixel(I, J, Color.Black);

            image.AddNewImage(map);
            image.MethodOtsu(0);
            Particle[] part = null;
            calc.AllCalculations(ref part, 2);
            bool equ = true;
            if (part != null && part.Length == 1)
                equ = true;
            else
                equ = false;
            Assert.AreEqual(equ, true);
        }

        [Test]
        public void TestContrastNNegative()
        {
            ProgramImage image = new ProgramImage();
            Bitmap map = new Bitmap(800, 600);
            for (int I = 0; I < 800; I++)
                for (int J = 0; J < 600; J++)
                    if (I < 375 && I > 425 && J < 275 && J > 325)
                        map.SetPixel(I, J, Color.White);
                    else
                        map.SetPixel(I, J, Color.Black);
            image.AddNewImage(map);
            image.Contrast(0, 100);
            Bitmap lastmap = image.GetLastBitmap();
            image.Negativ(lastmap);
            Particle[] part = null;
            calc.AllCalculations(ref part, 2);
            bool equ = true;
            if (part != null && part.Length == 1)
                equ = true;
            else
                equ = false;
            Assert.AreEqual(equ, true);
        }
    }
}
