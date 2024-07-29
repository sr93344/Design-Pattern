namespace Patterns.SolidPrinciples
{
    /// <summary>
    /// If you have an interface which includes too much stuff then just break it apart into 
    /// smaller interfaces.
    /// </summary>
    public class InterfaceSegregationPrinciple
    {
    }

    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document document);
        void Scan(Document document);
        void Fax(Document document);
    }

    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScanner
    {
        void Scan(Document document);
    }

    public class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document document)
        {
            throw new System.NotImplementedException();
        }

        public void Scan(Document document)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IMultiFunctionDevice : IPrinter, IScanner //...
    {

    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;
        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Print(Document document)
        {
            printer.Print(document);
        }

        public void Scan(Document document)
        {
            scanner.Scan(document);
            //decorator
        }
    }

    public class ModernMachine : IMachine
    {
        public void Fax(Document document)
        {
            //
        }

        public void Print(Document document)
        {
            //
        }

        public void Scan(Document document)
        {
            //
        }

        public class OldFashionMachine : IMachine
        {
            public void Fax(Document document)
            {
                throw new System.NotImplementedException();
            }

            public void Print(Document document)
            {
                throw new System.NotImplementedException();
            }

            public void Scan(Document document)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
