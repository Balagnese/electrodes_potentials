using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Electtodes_Potentials
{
    class Gradient
    {
        struct GradientItem
        {
            public GradientItem(Color color, double val)
            {
                this.color = color;
                this.val = val;
            }
            public Color color;
            public double val;
        }
        
        List<GradientItem> points = new List<GradientItem>();

        public void addPoint(Color color, double val)
        {
            int i = points.FindIndex(r => r.val == val);
            if (i != -1)
            {
                points.RemoveAt(i);
            }
            points.Add(new GradientItem(color, val));
            points.Sort((el1, el2) => {
                if (el1.val < el2.val)
                    return -1;
                else if (el1.val == el2.val)
                    return 0;
                return 1;
            });
        }

        public Color GetColor(double val)
        {
            if (points.Count < 2)
            {
                throw new Exception("not enough colors");
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                if ((val >= points[i].val) && (val < points[i + 1].val))
                {
                    double k = (val - points[i].val) / (points[i + 1].val - points[i].val);
                    int r = (int)(points[i].color.R + (points[i + 1].color.R - points[i].color.R) * k);
                    int g = (int)(points[i].color.G + (points[i + 1].color.G - points[i].color.G) * k);
                    int b = (int)(points[i].color.B + (points[i + 1].color.B - points[i].color.B) * k);
                    int a = (int)(points[i].color.A + (points[i + 1].color.A - points[i].color.A) * k);
                    return Color.FromArgb(a, r, g, b);
                }
            }
            if (val < points[0].val)
            {
                return points[0].color;
            }
            else return points[points.Count - 1].color;
        }

        public void Clear()
        {
            points.Clear();
        }
    }

    class BrushGradient
    {
        struct GradientItem
        {
            public GradientItem(Color color, double val)
            {
                this.color = color;
                this.val = val;
            }
            public Color color;
            public double val;
        }
        List<GradientItem> points = new List<GradientItem>();

        public void addPoint(Color color, double val)
        {
            int i = points.FindIndex(r => r.val == val);
            if (i != -1)
            {
                points.RemoveAt(i);
            }
            points.Add(new GradientItem(color, val));
            points.Sort((el1, el2) => {
                if (el1.val < el2.val)
                    return -1;
                else if (el1.val == el2.val)
                    return 0;
                return 1;
            });
        }

        public Color GetColor(double val)
        {
            if (points.Count < 2)
            {
                throw new Exception("not enough colors");
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                if ((val >= points[i].val) && (val < points[i + 1].val))
                {
                    double k = (val - points[i].val) / (points[i + 1].val - points[i].val);
                    int r = (int)(points[i].color.R + (points[i + 1].color.R - points[i].color.R) * k);
                    int g = (int)(points[i].color.G + (points[i + 1].color.G - points[i].color.G) * k);
                    int b = (int)(points[i].color.B + (points[i + 1].color.B - points[i].color.B) * k);
                    int a = (int)(points[i].color.A + (points[i + 1].color.A - points[i].color.A) * k);
                    return Color.FromArgb(a, r, g, b);
                }
            }
            if (val < points[0].val)
            {
                return points[0].color;
            }
            else return points[points.Count - 1].color;
        }

        public void Clear()
        {
            points.Clear();
        }
    }
}
