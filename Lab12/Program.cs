using ClassLibraryLab10;
namespace Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<BankCard> list = new MyList<BankCard>();

            int menu = 0;
            while (menu != 7)
            {
                Console.WriteLine("1) Сформировать двунаправленный список");
                Console.WriteLine("2) Распечатать список");
                Console.WriteLine("3) Удалить из списка все элементы с четными номерами ");
                Console.WriteLine("4) Добавить в список элемент после элемента с заданным информационным полем");
                Console.WriteLine("5) Выполнить глубокое клонирование списка");
                Console.WriteLine("6) Удалить список из памяти");
                Console.WriteLine("7) Выход");

                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Введите размер коллекции:");
                        int size = int.Parse(Console.ReadLine());
                        list = new MyList<BankCard>(size);
                        Console.WriteLine("Коллекция создана");
                        break;
                    case 2:
                        list.PrintList();
                        break;
                    case 3:
                        BankCard bc1 = new BankCard();
                        bc1.Init();
                        if (!list.RemoveItemsAtEvenPositions(bc1))
                            Console.WriteLine("Элемент не найден");
                        else
                            Console.WriteLine("Элемент удален");
                        break;
                    case 4:
                        BankCard bc2 = new BankCard();
                        BankCard bc3 = new BankCard();
                        bc2.RandomInit();
                        bc3.RandomInit();
                        list.AddAfter(bc2, bc3);
                        break;
                    case 5:
                        MyList<BankCard> clonedList = list.DeepClone();
                        clonedList.PrintList();
                        break;
                    case 6:
                        list.Clear();
                        break;
                    case 7:

                        break;
                }
            }

        }
    }
}