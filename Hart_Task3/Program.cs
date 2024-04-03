
using Hart_Task5;
using System.Reflection.Metadata;

internal class Program
{
    class ExaminedClass
    {
        protected decimal PropA { get; }
        private int PrivateProp { get; set; }

        public string PublicProperty1 { get; set; }
        public int field1;
        protected int protectedField;
        private DateTime? fielDateTime;
        public string Method1(int value) { return "test"; }
        public void MethodB(int arg, string arg2) { }
    }
    private static void Main(string[] args)
    {

        ExaminedClass typ = new ExaminedClass();

        DocHelper.ShowInfo(typ);
    }
}