using ClassLibraryLab10;

namespace Lab12._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection<BankCard> bc1 = new MyCollection<BankCard>(10);
            foreach (BankCard bc in bc1) 
            {
                Console.WriteLine(bc);
            }
            Console.WriteLine();
        }
    }
}