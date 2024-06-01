using ClassLibraryLab10;

namespace Lab12._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyTree<DebitCard> tree = new MyTree<DebitCard>(10);
            tree.ShowTree();
            tree.TransformToFindTree();
            tree.ShowTree();

        }


    }
}