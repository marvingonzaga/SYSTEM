using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ResizableMoveableTile
{
    public class Tile : Panel
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);


        #region events

        public event EventHandler TileClicked;
        public event EventHandler TileRightClicked;
        public event EventHandler TileMoved;

        private void TileClickedFunction()
        {
            if (TileClicked != null)
                TileClicked(this, new EventArgs());
        }

        private void TileRightClickedFunction()
        {
            if (TileRightClicked != null)
                TileRightClicked(this, new EventArgs());
        }

        private void TileMovedFunction()
        {
            if (TileMoved != null)
                TileMoved(this, new EventArgs());
        }

        #endregion

        #region windows messages

        protected override void WndProc(ref Message m)
        {
            const int WM_NCPAINT = 133;
            if (m.Msg == WM_NCPAINT)
            {
                IntPtr hdc = GetWindowDC(m.HWnd);
                Graphics g = Graphics.FromHdc(hdc);
                Rectangle rDraw = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                Pen pBottom = new Pen(Color.Gray, 3);
                Pen pTop = new Pen(Color.White, 3);
                g.DrawRectangle(pBottom, rDraw);
                Point[] pts = new Point[3];

                pts[0] = new Point(0, this.Height - 1);
                pts[1] = new Point(0, 0);
                pts[2] = new Point(this.Width - 1, 0);


                g.DrawLines(pTop, pts);
                ReleaseDC(this.Handle, hdc);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        #endregion

        #region init & load

        public Tile()
        {
            if (this.Tag == null) this.Tag = string.Empty;

            #region init variables

            //moving part
            bool Dragging = false;
            bool Dragged = false;
            Point DragStart = Point.Empty;

            bool Resizing = false;
            bool Resized = false;
            bool MouseIsInLeftEdge = false;
            bool MouseIsInRightEdge = false;
            bool MouseIsInTopEdge = false;
            bool MouseIsInBottomEdge = false;
            Point CursorStartPoint = new Point();
            Size CurrentStartSize = new Size();


            //make the shadow
            this.BorderStyle = BorderStyle.Fixed3D;
            Label label = new Label();
            label.Font = new Font("Arial", 10, FontStyle.Bold);
            label.Location = new Point(5, 5);
            label.AutoSize = true;
            this.Controls.Add(label);

            #endregion

            #region visible changed

            this.VisibleChanged += delegate (object sender, EventArgs e)
            {
                TileMovedFunction();
            };

            #endregion

            #region paint

            this.Paint += delegate (object sender, PaintEventArgs e)
            {
                Graphics g = this.Parent.CreateGraphics();
                Matrix mx = new Matrix(1F, 0, 0, 1F, 4, 4);
                Rectangle rdraw = new Rectangle(this.Left, this.Top, this.Width, this.Height);
                g.Transform = mx;
                g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Black)), rdraw);
                g.Dispose();

                label.Text = this.Tag.ToString();
            };

            #endregion

            #region mouse down 

            this.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                MouseIsInLeftEdge = Math.Abs(e.X) <= 5;
                MouseIsInRightEdge = Math.Abs(e.X - this.Width) <= 5;
                MouseIsInTopEdge = Math.Abs(e.Y) <= 5;
                MouseIsInBottomEdge = Math.Abs(e.Y - this.Height) <= 5;

                if (MouseIsInLeftEdge || MouseIsInRightEdge || MouseIsInTopEdge || MouseIsInBottomEdge)
                {
                    Resizing = true;
                    Resized = false;

                    CursorStartPoint = new Point(e.X, e.Y);
                    CurrentStartSize = this.Size;

                    if (MouseIsInLeftEdge)
                    {
                        if (MouseIsInTopEdge)
                        {
                            this.Cursor = Cursors.SizeNWSE;
                        }
                        else if (MouseIsInBottomEdge)
                        {
                            this.Cursor = Cursors.SizeNESW;
                        }
                        else
                        {
                            this.Cursor = Cursors.SizeWE;
                        }
                    }
                    else if (MouseIsInRightEdge)
                    {
                        if (MouseIsInTopEdge)
                        {
                            this.Cursor = Cursors.SizeNESW;
                        }
                        else if (MouseIsInBottomEdge)
                        {
                            this.Cursor = Cursors.SizeNWSE;
                        }
                        else
                        {
                            this.Cursor = Cursors.SizeWE;
                        }

                    }
                    else if (MouseIsInTopEdge || MouseIsInBottomEdge)
                    {
                        this.Cursor = Cursors.SizeNS;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }

                }
                else
                { 
                    Dragging = true;
                    Dragged = false;
                    DragStart = new Point(e.X, e.Y);
                }
                this.Capture = true;
            };

            #endregion

            #region mouse up

            this.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                Dragging = false;
                Resizing = false;

                this.Capture = false;
        
                if (Dragged || Resized)
                {
                    TileMovedFunction();
                }
                else
                {
                    if (e.Button == MouseButtons.Right)
                        TileRightClickedFunction();
                    else
                        TileClickedFunction();
                }
            };

            #endregion

            #region mouse move

            this.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (Resizing)
                {
                    Resized = false;

                    if (MouseIsInLeftEdge)
                    {
                        if (MouseIsInTopEdge)
                        {
                            this.Width -= (e.X - CursorStartPoint.X);
                            this.Left += (e.X - CursorStartPoint.X);
                            this.Height -= (e.Y - CursorStartPoint.Y);
                            this.Top += (e.Y - CursorStartPoint.Y);
                        }
                        else if (MouseIsInBottomEdge)
                        {
                            this.Width -= (e.X - CursorStartPoint.X);
                            this.Left += (e.X - CursorStartPoint.X);
                            this.Height = (e.Y - CursorStartPoint.Y)
                                     + CurrentStartSize.Height;
                        }
                        else
                        {
                            this.Width -= (e.X - CursorStartPoint.X);
                            this.Left += (e.X - CursorStartPoint.X);
                        }
                    }
                    else if (MouseIsInRightEdge)
                    {
                        if (MouseIsInTopEdge)
                        {
                            this.Width = (e.X - CursorStartPoint.X)
                                            + CurrentStartSize.Width;
                            this.Height -= (e.Y - CursorStartPoint.Y);
                            this.Top += (e.Y - CursorStartPoint.Y);

                        }
                        else if (MouseIsInBottomEdge)
                        {
                            this.Width = (e.X - CursorStartPoint.X)
                                            + CurrentStartSize.Width;
                            this.Height = (e.Y - CursorStartPoint.Y)
                                            + CurrentStartSize.Height;
                        }
                        else
                        {
                            this.Width = (e.X - CursorStartPoint.X)
                                           + CurrentStartSize.Width;
                        }
                    }
                    else if (MouseIsInTopEdge)
                    {
                        this.Height -= (e.Y - CursorStartPoint.Y);
                        this.Top += (e.Y - CursorStartPoint.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        this.Height = (e.Y - CursorStartPoint.Y)
                                   + CurrentStartSize.Height;
                    }
                    else
                    {
                        Resizing = false;
                    }
                }
                else if (Dragging)
                {
                    Dragged = true;
                    this.Left = Math.Max(0, e.X + this.Left - DragStart.X);
                    this.Top = Math.Max(0, e.Y + this.Top - DragStart.Y);
                }
            };

        }

        #endregion

        #endregion

    }
}
