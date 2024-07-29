using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.SolidPrinciples
{
    /// <summary>
    /// High level modules should not depend upon low-level ones.
    /// </summary>
    public class DependencyInversionPrinciple
    {
        public DependencyInversionPrinciple() 
        {
            DefaultMethod();
        }

        public void DefaultMethod()
        {
            var parent = new Person("John");
            var child1 = new Person("Mary");
            var child2 = new Person("Chris");

            var relationShips = new RelationShips();
            relationShips.AddParentAndChild(parent, child1);
            relationShips.AddParentAndChild(parent, child2);
            var research = new Research(relationShips);
        }
    }

    public class Research
    {
        //public Research(RelationShips relationShips)
        //{
        //    var relations = relationShips.Relations;
        //    foreach (var r in relations.Where(
        //        x => x.Item1.Name == "John" && 
        //             x.Item2 == RelationShip.Parent))
        //    {
        //        Console.WriteLine($"John has a child called {r.Item3.Name}.");
        //    }
        //}

        public Research(IRelationShipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {p.Name}.");
            }
        }
    }

    

    public enum RelationShip
    {
        Parent, Child, Sibling
    }

    public class Person
    {
        public Person(string name) {
            Name = name;
        }
        public string Name;
    }

    public interface IRelationShipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    //low-level
    public class RelationShips : IRelationShipBrowser
    {
        private List<(Person, RelationShip, Person)> _relations 
            = new List<(Person, RelationShip, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, RelationShip.Parent, child));
            _relations.Add((child, RelationShip.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return _relations.Where(
                x => x.Item1.Name == name && 
                     x.Item2 == RelationShip.Parent
            ).Select(r => r.Item3);
        }

        //public List<(Person, RelationShip, Person)> Relations => _relations;
    }
}
