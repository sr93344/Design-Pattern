using System;
using System.Collections.Generic;

namespace Patterns.SolidPrinciples
{
    /// <summary>
    /// It states that part of the system should be open for extenstion but should be closed 
    /// for addition.
    /// </summary>
    public class OpenClosePrinciple
    {
        private static Product[] _products;
        public OpenClosePrinciple() 
        {
            DefaultMethod();
            BetterMethod();
        }

        public void DefaultMethod()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            _products = new Product[] {apple, tree, house};

            var pf = new ProductFilter();
            Console.WriteLine($"Green Products (old): ");
            foreach(var p in pf.FilterByColor(_products, Color.Green))
            {
                Console.WriteLine($"- {p.Name} is green."); 
            }
        }

        public void BetterMethod()
        {
            var bf = new BetterFilter();
            Console.WriteLine($"Green Products (new): ");
            foreach (var p in bf.Filter(_products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"- {p.Name} is green.");
            }
            Console.WriteLine("Large blue items.");
            var andCombinator = new AndSpecification<Product>(new AndSpecification<Product>(
                new ColorSpecification(Color.Blue),
                new SizeSpecification(Size.Large)), new SizeSpecification(Size.Large));

            foreach (var p in bf.Filter(_products, andCombinator))
            {
                Console.WriteLine($"- {p.Name} is large and blue.");
            }
        }
    }

    public class Product
    {
        public Product(string _name, Color _color, Size _size)
        {
            Name = _name;
            Color = _color;
            Size = _size;
        }

        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }

    }

    public interface ISpecification<T>
    {
        bool IsSatified(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }

        public bool IsSatified(Product t)
        {
            return t.Color == _color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }

        public bool IsSatified(Product t)
        {
            return t.Size == _size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _first, _second;
        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            _first = first;
            _second = second;
        }

        public bool IsSatified(T t)
        {
            return _first.IsSatified(t) && _second.IsSatified(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if(spec.IsSatified(item))
                    yield return item;
            }
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
            {
                if (product.Size == size)
                    yield return product;
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
            {
                if (product.Color == color)
                    yield return product;
            }
        }

        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Color color, Size size)
        {
            foreach (var product in products)
            {
                if (product.Color == color && product.Size == size)
                    yield return product;
            }
        }
    }

    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Huge
    }
}
