using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle:Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException();
                }

                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
                    
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return this.Height * 2 + this.Width * 2;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
