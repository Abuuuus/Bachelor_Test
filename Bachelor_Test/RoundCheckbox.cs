using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bachelor_Test
{
    //Class for creating the round "connected" checkbox with green background. Custom configured
    public class RoundCheckbox : CheckBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            int checkBoxSize = 16; 

            Rectangle rect = new Rectangle(0, 0, checkBoxSize, checkBoxSize);

            if (this.Checked)
            {
                using (Brush brush = new SolidBrush(Color.Green))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.FillEllipse(brush, rect);
                }
            }
            else
            {
                using (Pen pen = new Pen(Color.Gray, 2))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawEllipse(pen, rect);
                }
            }

            TextRenderer.DrawText(e.Graphics, this.Text, this.Font,
                new Point(checkBoxSize + 2, (this.Height - this.Font.Height) / 2),
                this.ForeColor);
        }
    }
}
