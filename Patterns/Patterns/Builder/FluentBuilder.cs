﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Patterns.Builder
{
    public class Person
    {
        public string Name;
        public string Position;
        public override string ToString()
        {
            return $"{nameof(Name)} : {Name}, {nameof(Position)} : {Position}";
        }

        public class Builder: PersonJobBuilder<Builder>
        {
            
        }
        public static Builder New => new Builder();
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build() { return person; }
    }

    public class PersonInfoBuilder<SELF> 
        : PersonBuilder 
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF>
        : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    /// <summary>
    /// Recursive Generics.
    /// </summary>
    public class FluentBuilder
    {
        public FluentBuilder() 
        {
            DefaultMethod();
        }

        public void DefaultMethod()
        {
            var me = Person.New
                .Called("Sudhanshu Ranjan")
                .WorksAsA("SDE1")
                .Build();
            Console.WriteLine(me);
        }
    }
}
