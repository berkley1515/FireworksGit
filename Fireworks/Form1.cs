using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Fireworks
{
    public partial class Form1 : Form
    {
        //const int times = 2000;

        Random randomGen = new Random();

        int counter1 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            while (counter1 == 0)
            {
                Graphics formGraphics1 = this.CreateGraphics();
                Graphics formGraphics2 = this.CreateGraphics();
                Graphics formGraphics3 = this.CreateGraphics();

                SolidBrush drawBrush = new SolidBrush(Color.Black);
                SolidBrush drawBrush1 = new SolidBrush(Color.White);
                SolidBrush drawBrush2 = new SolidBrush(Color.White);
                SolidBrush drawBrush3 = new SolidBrush(Color.White);
                Pen drawPen = new Pen(Color.Red, 10);

                int r, g, b, r2, g2, b2, r3, g3, b3, xPos1, xPos2, xPos3, ySpeed1, ySpeed2, ySpeed3, times;

                int y1 = Height;
                int y2 = Height;
                int y3 = Height;

                int width = 6;
                int height = 9;

                times = 100;

                r = randomGen.Next(1, 256);
                g = randomGen.Next(1, 256);
                b = randomGen.Next(1, 256);

                r2 = randomGen.Next(1, 256);
                g2 = randomGen.Next(1, 256);
                b2 = randomGen.Next(1, 256);

                r3 = randomGen.Next(1, 256);
                g3 = randomGen.Next(1, 256);
                b3 = randomGen.Next(1, 256);

                xPos1 = randomGen.Next(30, Width - 30);
                xPos2 = randomGen.Next(30, Width - 30);
                xPos3 = randomGen.Next(30, Width - 30);

                ySpeed1 = 13;//randomGen.Next(2, 6);
                ySpeed2 = 5;//randomGen.Next(2, 6);
                ySpeed3 = 8;//randomGen.Next(2, 6);

                //   if (ySpeed3 == ySpeed2 || ySpeed3 == ySpeed1 || ySpeed2 == ySpeed1) //not working
                // {
                //     ySpeed2 = randomGen.Next(2, 6);
                //     ySpeed3 = randomGen.Next(2, 6);
                // }

                drawBrush1.Color = Color.FromArgb(r, g, b);
                drawBrush2.Color = Color.FromArgb(r2, g2, b2);
                drawBrush3.Color = Color.FromArgb(r3, g3, b3);

                int d1 = ySpeed1 / 4;
                int d2 = ySpeed2 / 4;
                int d3 = ySpeed3 / 4;

                int pixelGrow = 1;
                int pixelGrowTimes = 95;

                formGraphics1.Clear(Color.Black);
                formGraphics2.Clear(Color.Black);
                formGraphics3.Clear(Color.Black);

                counter1++;

                while (counter1 > 0 && counter1 < times)
                {
                    formGraphics1.FillRectangle(drawBrush, xPos1, y1 - ySpeed1, width, height + 6);
                    formGraphics2.FillRectangle(drawBrush, xPos2, y2 - ySpeed2, width, height + 6);
                    formGraphics3.FillRectangle(drawBrush, xPos3, y3 - ySpeed3, width, height + 6);
                    Thread.Sleep(2);
                    formGraphics1.FillRectangle(drawBrush1, xPos1, y1 - ySpeed1, width, height);
                    formGraphics2.FillRectangle(drawBrush2, xPos2, y2 - ySpeed2, width, height);
                    formGraphics3.FillRectangle(drawBrush3, xPos3, y3 - ySpeed3, width, height);
                    Thread.Sleep(18);

                    counter1++;
                    y1 -= d1;
                    y2 -= d2;
                    y3 -= d3;

                    while (counter1 == times && pixelGrow < pixelGrowTimes)
                    {
                        int x1 = xPos1 - 10;
                        int x2 = xPos2 - 10;
                        int x3 = xPos3 - 10;
                        int y1a = y1 - 10;
                        int y2a = y2 - 10;
                        int y3a = y3 - 10;

                        formGraphics1.FillEllipse(drawBrush1, x1 - pixelGrow / 2, y1a - pixelGrow / 2, 20 + pixelGrow, 20 + pixelGrow);
                        formGraphics2.FillEllipse(drawBrush2, x2 - pixelGrow / 2, y2a - pixelGrow / 2, 20 + pixelGrow, 20 + pixelGrow);
                        formGraphics3.FillEllipse(drawBrush3, x3 - pixelGrow / 2, y3a - pixelGrow / 2, 20 + pixelGrow, 20 + pixelGrow);
                        Thread.Sleep(0);

                        formGraphics1.FillEllipse(drawBrush3, xPos1 - pixelGrow / 2, y1 - pixelGrow / 2, pixelGrow, pixelGrow);
                        formGraphics2.FillEllipse(drawBrush1, xPos2 - pixelGrow / 2, y2 - pixelGrow / 2, pixelGrow, pixelGrow);
                        formGraphics3.FillEllipse(drawBrush2, xPos3 - pixelGrow / 2, y3 - pixelGrow / 2, pixelGrow, pixelGrow);
                        Thread.Sleep(0);

                        formGraphics1.FillEllipse(drawBrush2, xPos1 + 10 - pixelGrow / 2, y1 + 10 - pixelGrow / 2, pixelGrow - 20, pixelGrow - 20);
                        formGraphics2.FillEllipse(drawBrush3, xPos2 + 10 - pixelGrow / 2, y2 + 10 - pixelGrow / 2, pixelGrow - 20, pixelGrow - 20);
                        formGraphics3.FillEllipse(drawBrush1, xPos3 + 10 - pixelGrow / 2, y3 + 10 - pixelGrow / 2, pixelGrow - 20, pixelGrow - 20);
                        Thread.Sleep(15);

                        pixelGrow++;

                        while (pixelGrow == pixelGrowTimes)
                        {
                            counter1 = 0;
                            pixelGrow = 0;//to restart
                        }
                    }
                }
            }
        }
    }
}
