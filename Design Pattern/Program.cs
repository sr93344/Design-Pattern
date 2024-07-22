using Patterns;
using Patterns.SolidPrinciples;
using System;

namespace DesignPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LSP();
        }

        /// <summary>
        /// A typical class has one responsibility and has one reason to change.
        /// </summary>
        public static void SRP()
        {
            var srp = new SingleResponsibilityPrinciple();
            Console.ReadLine();
        }

        /// <summary>
        /// It states that part of the system should be open for extenstion but should be closed 
        /// for addition.
        /// </summary>
        public static void OCP()
        {
            var ocp = new OpenClosePrinciple();
            Console.ReadLine();
        }

        /// <summary>
        /// If you have an interface which includes too much stuff then just break it apart into 
        /// smaller interfaces.
        /// </summary>
        public static void ISP()
        {
            var isp = new InterfaceSegregationPrinciple();
            Console.ReadLine();
        }

        /// <summary>
        /// High level modules should not depend upon low-level ones.
        /// </summary>
        public static void DIP()
        {
            var dip = new DependencyInversionPrinciple();
            Console.ReadLine();
        }


        /// <summary>
        /// You should be able to upcast to base type for a subtype.
        /// </summary>
        public static void LSP()
        {
            var lsp = new LiskovSubstitutionPrinciple();
            Console.ReadLine();
        }
    }
}
