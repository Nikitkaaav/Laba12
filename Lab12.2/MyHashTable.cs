using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        Point<T>[] table;
        public int Capacity => table.Length;

        public MyHashTable(int length)
        {
            table = new Point<T>[length];
        }

        public void PrintTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                // Вывод индекса элемента
                Console.WriteLine($"{i}:");

                // Проверка наличия элемента в текущей ячейке хэш-таблицы
                if (table[i] != null)
                {
                    // Вывод данных из текущего элемента хэш-таблицы
                    Console.WriteLine(table[i].Data);

                    // Проверка наличия следующего элемента в цепочке 
                    if (table[i].Next != null)
                    {
                        // Установка текущего элемента на начало цепочки 
                        Point<T>? current = table[i].Next;

                        // Перебор и вывод данных всех элементов в цепочке
                        while (current != null)
                        {
                            Console.WriteLine(current.Data);
                            current = current.Next;
                        }
                    }
                }
            }
        }

        public void AddPoint(T data)
        {
            // Получение индекса для добавляемых данных
            int index = GetIndex(data);

            // Проверка, пуста ли данная ячейка хэш-таблицы
            if (table[index] == null)
            {
                // Создание нового элемента и помещение его в ячейку
                table[index] = new Point<T>(data);
            }
            else
            {
                // Если ячейка не пуста, начинаем цикл по элементам цепочки
                Point<T>? current = table[index];

                // Переход к концу цепочки 
                while (current.Next != null)
                {
                    // Проверка на существование элемента с такими данными
                    if (current.Equals(data))
                        return;

                    // Переход к следующему элементу в цепочке
                    current = current.Next;
                }

                // Добавление нового элемента в конец цепочки
                current.Next = new Point<T>(data);
                current.Next.Pred = current; // Установка ссылки на предыдущий элемент
            }
        }

        public bool Contains(T data)
        {
            // Получение индекса для искомых данных
            int index = GetIndex(data);

            // Проверка на пустоту хэш-таблицы
            if (table == null)
                throw new Exception("empty table");

            // Проверка, пуста ли данная ячейка хэш-таблицы
            if (table[index] == null)
                return false;

            // Проверка наличия искомых данных в первом элементе цепочки
            if (table[index].Data.Equals(data))
                return true;
            else
            {
                // Если искомые данные отсутствуют в первом элементе, ищем по цепочке
                Point<T>? current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true; // Найдено совпадение, возвращаем true
                    current = current.Next; // Переход к следующему элементу цепочки
                }
            }
            return false; // Искомые данные не найдены, возвращаем false
        }

        public bool RemoveData(T data)
        {
            Point<T>? current;
            int index = GetIndex(data);

            // Проверка, пуста ли данная ячейка хэш-таблицы
            if (table[index] == null)
                return false;

            // Проверка, содержит ли первый элемент ячейки искомые данные
            if (table[index].Data.Equals(data))
            {
                // Обработка случая, когда первый элемент содержит искомые данные
                if (table[index].Next == null)
                    table[index] = null;
                else
                {
                    table[index] = table[index].Next;
                    table[index].Pred = null;
                }
                return true;
            }
            else
            {
                // Поиск элемента в цепочке
                current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        // Удаление элемента из цепочки 
                        Point<T>? pred = current.Pred;
                        Point<T>? next = current.Next;
                        pred.Next = next;
                        current.Pred = null;
                        if (next != null)
                            next.Pred = pred;
                        return true;
                    }
                    current = current.Next;
                }
            }
            return false;
        }

        int GetIndex(T data)
        {
            // Рассчитывает хэш-код для данных и возвращает индекс в массиве хэш-таблицы
            return Math.Abs(data.GetHashCode()) % Capacity;
        }
    }
}
