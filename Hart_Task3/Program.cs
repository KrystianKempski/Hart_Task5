
using Hart_Task3;
using System.Reflection.Metadata;

internal class Program
{
    class SomeClass
    {
        protected decimal PropA { get; }
        public string Property1 { get; set; }
        public string Method1(int value) { return " ss"; }
        public void MethodB(int arg, string arg2) { }
        public int field1;
        private DateTime? fieldB;
    }
    private static void Main(string[] args)
    {

        SomeClass typ = new SomeClass();

        DocHelper.ShowInfo(typ);
    }
}