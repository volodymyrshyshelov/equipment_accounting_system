using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipment_accounting_system.Classes
{
    internal class charts_Painter
    {
        public void pie_chart_painter(PaintEventArgs e, float[] values, Color[] colors)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(78, 34, 80));

            if (values.Length > 10) values = values.Take(10).ToArray();
            if (colors.Length > 10) colors = colors.Take(10).ToArray();

            float total = values.Sum();
            float startAngle = 0;

            int size = Math.Min(e.ClipRectangle.Width, e.ClipRectangle.Height) - 20;
            Rectangle rect = new Rectangle((e.ClipRectangle.Width - size) / 2, (e.ClipRectangle.Height - size) / 2, size, size);

            for (int i = 0; i < values.Length; i++)
            {
                float sweepAngle = values[i] / total * 360;
                g.FillPie(new SolidBrush(colors[i]), rect, startAngle, sweepAngle);
                startAngle += sweepAngle;
            }
        }

        public void donut_pie_chart_painter(PaintEventArgs e, float[] values, Color[] colors)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(78, 34, 80));

            if (values.Length > 10) values = values.Take(10).ToArray();
            if (colors.Length > 10) colors = colors.Take(10).ToArray();

            float total = values.Sum();
            float startAngle = 0;

            int size = Math.Min(e.ClipRectangle.Width, e.ClipRectangle.Height) - 20;
            Rectangle rect = new Rectangle((e.ClipRectangle.Width - size) / 2, (e.ClipRectangle.Height - size) / 2, size, size);

            foreach (int i in Enumerable.Range(0, values.Length))
            {
                float sweepAngle = values[i] / total * 360;
                g.FillPie(new SolidBrush(colors[i]), rect, startAngle, sweepAngle);
                startAngle += sweepAngle;
            }

            int diameter = size / 2;
            Rectangle innerRect = new Rectangle(rect.X + (rect.Width - diameter) / 2, rect.Y + (rect.Height - diameter) / 2, diameter, diameter);
            g.FillEllipse(Brushes.White, innerRect);
        }
    }
}
