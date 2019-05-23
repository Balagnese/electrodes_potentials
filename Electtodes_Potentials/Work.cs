using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electtodes_Potentials
{
    class Work
    {
        private double distance;
        public double Distance
        {
            get
            {
                return distance;
            }
            set
            {
                if (value >= 0)
                    distance = value;
            }
        }
        private double head_radius;
        public double HeadRadius
        {
            get
            {
                return head_radius;
            }
            set
            {
                if (value >= 0)
                    head_radius = value;
            }
        }
        private double epsilon;
        public double Epsilon
        {
            get
            {
                return epsilon;
            }
            set
            {
                if (value >= 1)
                {
                    epsilon = value;
                }
            }
        }
        Graphics g;
        private Bitmap image;
        public Bitmap Image {
            get
            {
                return image;
            }
            set {
                if (value == null)
                {
                    g.Clear(Color.Empty);
                    return;
                }
                double base_ratio = width * 1.0 / height;
                double image_ratio = value.Width * 1 / value.Height;

                
                if (image_ratio > base_ratio)
                {
                    g.DrawImage(value, new Rectangle(0, 0, width, height), 
                        new Rectangle(0, 0, (int)(value.Height*base_ratio), value.Height), GraphicsUnit.Pixel);
                }
                else
                {
                    g.DrawImage(value, new Rectangle(0, 0, width, height),
                        new Rectangle(0, 0, value.Width, (int)(value.Width / base_ratio)), GraphicsUnit.Pixel);
                }
               
            }
        }

        //реальный размер
        double width_distance;
        double height_distance;

        List<Electrod> electrods;
        double[,] field;
        Draw d;
        
        int width;
        int height;
        int rad = 5;

        public Work(int width, int height, double width_distance, double height_distance)
        {
            this.width = width;
            this.height = height;
            this.width_distance = width_distance;
            this.height_distance = height_distance;
            field = new double[width, height];
            electrods = new List<Electrod>();
            d = new Draw(width, height, rad);
            image = new Bitmap(width, height);
            g = Graphics.FromImage(image);
            Image = null;
        }

        /*public Work (int width, int height, double width_distance, double height_distance,
            double distance, double head_radius, double epsilon)
        {
            this.width = width;
            this.height = height;
            this.width_distance = width_distance;
            this.height_distance = height_distance;
            this.distance = distance;
            this.epsilon = epsilon;
            field = new double[width, height];
        }*/

        public void AddElectrod(int posx, int posy, double voltage)
        {
            double x = posx * width_distance / width;
            double y = posy * height_distance / height;
            Electrod e = new Electrod(posx, posy, x, y, voltage);
            electrods.Add(e);
        }

        public int FindElectrod(int posx, int posy)
        {
            for (int i = 0; i < electrods.Count; i++)
            {
                double centerx = electrods[i].posx - rad;
                double centery = electrods[i].posy - rad;
                double temp = Math.Sqrt((posx - centerx) * (posx - centerx) +
                    (posy - centery) * (posy - centery));
                if (temp <= 2*rad)
                {
                    return i;
                }
            }
            return -1;
        }

        public void MoveElectrod(int i, int posx, int posy)
        {
            Electrod e = electrods[i];
            e.x = posx * width_distance / width;
            e.y = posy * height_distance / height;
            e.posx = posx;
            e.posy = posy;
        }

        public void ChangeVoltageAtElectrod(Electrod e, double vol)
        {
            e.voltage = vol;
        }

        public void ChangeVoltageAtElectrodByIndex(int i, double vol)
        {
            if (!(i >= 0 && i <= electrods.Count - 1))
            {
                throw new Exception("index is not correct");
            }
            ChangeVoltageAtElectrod(electrods[i], vol);
        }

        public void DeleteElectrod(int i)
        {
            if (!(i >= 0 && i < electrods.Count))
            {
                throw new Exception("index is not correct");
            }
            electrods.Remove(electrods[i]);
        }

        public double GetVoltageAt(int posx, int posy)
        {
            double x = posx * width_distance / width;
            double y = posy * height_distance / height;
            double sum = 0;
            double d2 = distance * distance;
            for (int i = 0; i < electrods.Count; i++)
            {
                Electrod e = electrods[i];
                sum += e.voltage / Math.Sqrt((e.x - x) * (e.x - x) + (e.y - y) * (e.y - y) + d2);
            }
            double res = 2 * head_radius / epsilon * sum;
            return res;
        }

        public double[,] GetField()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    field[x, y] = GetVoltageAt(x, y);       
                }
            }
            return field;
        }

        public Bitmap Draw()
        {
            return d.DrawField(Image, GetField(), electrods);
        }

        public Bitmap DrawSelectedElectrod(int index)
        {
            return d.DrawField(Image, GetField(), electrods, index);
        }

       

        /*void calculateValues()
        {
            b = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            g = Graphics.FromImage(b);
            g.Clear(Color.White);

            electrods = getElectrods(electrodes_input, radius);

            double minVal = electrods[0].voltage;
            double maxVal = electrods[0].voltage;
            for (int i = 0; i < electrods.Length; i++)
            {
                minVal = minVal < electrods[i].voltage ? minVal : electrods[i].voltage;
                maxVal = maxVal > electrods[i].voltage ? maxVal : electrods[i].voltage;
            }

            int w = pictureBox.Width;
            int h = pictureBox.Height;

            double min = minVal;
            double max = maxVal;

            max = getVoltageAt(electrods, 0, 0, head_radius, distance, epsilon);
            min = max;
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    double val = getVoltageAt(electrods, x * width_distance / w, y * height_distance/ h, head_radius, distance, epsilon);
                    max = max > val ? max : val;
                    min = min < val ? min : val;
                }
            }
            Gradient grad = new Gradient();
            grad.addPoint(Color.Blue, min < 0 ? min : -10);
            grad.addPoint(Color.White, 0);
            grad.addPoint(Color.Red, max > 0 ? max : 10);
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    double val = getVoltageAt(electrods, x * 6 * radius / w, y * 6 * radius / h, head_radius, distance, epsilon);
                    Color c = grad.GetColor(val);
                    //Brush c1 = new SolidBrush(Color.FromArgb(255, (int)(255*(val - min)/(max-min)), (int)(255*(val - min) / (max - min)), (int)(255*(val - min) / (max - min))));
                    Brush brush = new SolidBrush(c);
                    g.FillRectangle(brush, x, y, 1, 1);
                }
            }

        }

    */
    }
}
