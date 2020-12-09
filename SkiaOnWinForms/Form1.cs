using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkiaOnWinForms
{
    public partial class Form1 : Form
    {
        private float _xSpeed = 5.0f;
        private float _ySpeed = 10.0f;
        private const float BallSize = 20.0f;
        private (float x, float y) _position = (BallSize / 2, BallSize / 2);
        public Form1()
        {
            InitializeComponent();
        }

        private void skControl1_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            e.Surface.Canvas.Clear();
            e.Surface.Canvas.DrawCircle(_position.x, _position.y, BallSize,
                new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = Color.Red.ToSKColor(),
                });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var nextXPos = getNextXPos();
            var nextYPos = getNextYPos();
            if (nextXPos + BallSize / 2 >= skControl1.Width || nextXPos - BallSize / 2 < 0)
            {
                _xSpeed = -_xSpeed;
                nextXPos = getNextXPos();
            }
            if (nextYPos + BallSize / 2 >= skControl1.Height || nextYPos - BallSize / 2 < 0)
            {
                _ySpeed = -_ySpeed;
                nextYPos = getNextYPos();
            }

            _position = (nextXPos, nextYPos);
            skControl1.Invalidate();

            float getNextXPos() => _position.x + _xSpeed;
            float getNextYPos() => _position.y + _ySpeed;
        }
    }
}
