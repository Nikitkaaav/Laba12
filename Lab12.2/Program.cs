using ClassLibraryLab10;
namespace Lab12._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashTable<BankCard> table = new MyHashTable<BankCard>(10);

            int menu = 0;
            while (menu != 6)
            {
                Console.WriteLine("1) Заполнить таблицу элеменатми");
                Console.WriteLine("2) Выполнить поиск элемента в таблице");
                Console.WriteLine("3) Удалить найденный элемент из таблицы");
                Console.WriteLine("4) Распечатать таблицу");
                Console.WriteLine("5) Показать добавление в таблицу");
                Console.WriteLine("6) Выход");

                try
                {
                    menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            {
                                Console.WriteLine("Введите количество элементов:");
                                int number = int.Parse(Console.ReadLine());
                                for (int i = 0; i < number; i++)
                                {
                                    BankCard card = new BankCard();
                                    card.RandomInit();
                                    table.AddPoint(card);
                                }
                            }
                            break;
                        case 2:
                            {
                                BankCard card = new BankCard();
                                card.Init();
                                if (table.Contains(card))
                                {
                                    Console.WriteLine("Элемент найден");
                                }
                                else
                                {
                                    Console.WriteLine("Элемент не найден");
                                }
                            }
                            break;
                        case 3:
                            {
                                BankCard card = new BankCard();
                                card.Init();
                                if (table.RemoveData(card))
                                {
                                    Console.WriteLine("Элемент удален");
                                }
                                else
                                {
                                    Console.WriteLine("Элемента нет в таблице");
                                }
                            }
                            break;
                        case 4:
                            {
                                table.PrintTable();
                            }
                            break;
                        case 5:
                            {
                                BankCard card = new BankCard();
                                card.Init();
                                table.AddPoint(card);
                            }
                            break;
                        case 6:

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}