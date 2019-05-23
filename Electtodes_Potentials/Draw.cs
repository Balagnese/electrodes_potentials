using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electtodes_Potentials
{
    class Draw
    {
        Bitmap b;
        Graphics g;
        Gradient grad;
        int rad;
        static Object obj = new Object();
        static Color c = Color.FromArgb(128, 0, 0, 255);
        static Brush br = new SolidBrush(c);
        static Pen pen = new Pen(br);

        ColorMatrix cm = new ColorMatrix();
        ImageAttributes ia = new ImageAttributes();

        private double min = -100;
        public double Min
        {
            get { return min; }
            set
            {
                if (value > 0)
                    min = -100;
                else min = value;
                UpdatePoints();
            }
        }
        private double max = 100;
        public double Max
        {
            get
            {
                return max;
            }
            set
            {
                if (value < 0)
                    max = 100;
                else max = value;
                UpdatePoints();
            }
        }


        public Draw(int width, int height, int rad)
        {
            b = new Bitmap(width, height);
            g = Graphics.FromImage(b);
            grad = new Gradient();
            this.rad = rad;
            cm.Matrix03 = 0.55f;
            ia.SetColorMatrix(cm);
            
            UpdatePoints();
        }

        public void UpdatePoints()
        {
            grad.Clear();
            grad.addPoint(Color.FromArgb(200, 0, 0, 255), Min);
            grad.addPoint(Color.FromArgb(200, 255, 255, 255), 0);
            grad.addPoint(Color.FromArgb(200, 255, 0, 0), Max);
        }

        public Bitmap DrawField(Bitmap ground, double[,] field, List<Electrod> els, int index = -1) {

            lock (obj)
            {
                g.DrawImage(ground, 0, 0);
                g.DrawImage(ground, new Rectangle(0, 0, ground.Width, ground.Height), 0, 0, ground.Width, ground.Height, GraphicsUnit.Pixel, ia);
                for (int x = 0; x < field.GetLength(0); x++)
                {
                    for (int y = 0; y < field.GetLength(1); y++)
                    {
                        c = grad.GetColor(field[x, y]);
                        br = new SolidBrush(c); 

                        g.FillRectangle(br, x, y, 1, 1);
                    }
                }

                //draw electrods
                Pen p = Pens.Black;
                Pen p1 = Pens.YellowGreen;
                for (int i = 0; i < els.Count; i++)
                {
                    g.DrawEllipse(p, els[i].posx - rad, els[i].posy - rad, 2 * rad, 2 * rad);
                    if (index == i)
                        g.DrawEllipse(p1, els[i].posx - rad, els[i].posy - rad, 2 * rad, 2 * rad);
                }
                
                return b;
            }
            
        }

        

    }
}
