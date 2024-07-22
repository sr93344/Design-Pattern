using System;

namespace Patterns.SolidPrinciples
{
    public class LiskovSubstitutionPrinciple
    {
        public LiskovSubstitutionPrinciple() 
        {
            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has Area {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has Area {Area(sq)}");
        }

        public int Area(Rectangle r) => r.Height * r.Width;
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set
            {
                base.Width = base.Height = value;
            }
        }

        public override int Height
        {
            set
            {
                base.Height = base.Width = value;
            }
        }
    }

    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }
}
