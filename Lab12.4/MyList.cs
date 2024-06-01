﻿using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12._4
{
    internal class MyList<T> where T : IInit, ICloneable, new()
    {
        public Point<T>? beg = null;
        public Point<T>? end = null;

        int count = 0;

        public int Count => count;

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone(); //глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone(); //глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = beg;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddAfter(T newData, T afterData)
        {
            // Начинаем с начала списка
            Point<T> current = beg;

            // Перебираем элементы списка
            while (current != null)
            {
                // Если найден элемент с соответствующим информационным полем
                if (current.Data.Equals(afterData))
                {
                    // Создаем новый элемент
                    Point<T> newNode = new Point<T>(newData);

                    // Вставляем новый элемент после найденного элемента
                    newNode.Next = current.Next;
                    current.Next = newNode;

                    // Если найденный элемент был последним, обновляем указатель конца списка
                    if (current == end)
                    {
                        end = newNode;
                    }

                    // Прерываем цикл после вставки нового элемента
                    break;
                }

                // Переходим к следующему элементу
                current = current.Next;
            }
        }

        public MyList() { }

        public MyList(int size)
        {
            // Проверяем, чтобы размер списка был больше нуля
            if (size <= 0)
            {
                // Если размер меньше или равен нулю, выбрасываем исключение
                throw new Exception("size less zero");
            }
            // Начальная инициализация указателей списка
            beg = MakeRandomData();
            end = beg;
            // Заполняем список случайными элементами
            for (int i = 0; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
        }

        public MyList(T[] collection)
        {
            // Проверяем, что коллекция не равна null
            if (collection == null)
            {
                // Если коллекция равна null, выбрасываем исключение
                throw new Exception("empty collection: null");
            }
            // Проверяем, что коллекция не пустая
            if (collection.Length == 0)
            {
                // Если коллекция пустая, выбрасываем исключение
                throw new Exception("empty collection");
            }
            // Создаем новый объект данных на основе клонирования первого элемента из коллекции
            T newData = (T)collection[0].Clone();
            beg = new Point<T>(newData);
            end = beg;
            // Добавляем оставшиеся элементы из коллекции в список
            for (int i = 1; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public void PrintList()
        {
            if (count == 0)
                Console.WriteLine("the list is empty");
            Point<T>? current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public Point<T>? FindItem(T item)
        {
            Point<T>? current = beg;

            // Проходим по списку элементов
            while (current != null)
            {
                // Проверяем, если data текущего элемента равен null, бросаем исключение
                if (current.Data == null)
                {
                    throw new Exception("Data is null");
                }
                // Сравниваем data текущего элемента с заданным элементом item
                if (current.Data.Equals(item))
                {
                    return current; // Возвращаем указатель на текущий элемент, если элемент найден
                }
                current = current.Next; // Переходим к следующему элементу
            }
            return null; // Если элемент не найден, возвращаем null
        }

        public bool RemoveItemsAtEvenPositions(T item)
        {
            // Проверка на пустой список
            if (beg == null)
            {
                throw new Exception("the empty list");
            }

            bool removed = false; // Флаг для отслеживания удаления элементов
            Point<T> current = beg; // Указатель на текущий элемент
            Point<T> prev = null; // Указатель на предыдущий элемент

            while (current != null)
            {
                Point<T> next = current.Next; // Указатель на следующий элемент

                // Проверяем, является ли позиция элемента четной
                if (prev != null && prev.Next == current)
                {
                    // Удаляем элемент на четной позиции
                    prev.Next = next;
                    if (next != null)
                    {
                        next.Pred = prev;
                    }

                    // Переприсваиваем конец списка, если текущий элемент - последний
                    if (current == end)
                    {
                        end = prev;
                    }

                    count--; // Уменьшаем счетчик элементов
                    removed = true; // Устанавливаем флаг удаления в true
                }
                prev = current; // Переходим к следующему элементу
                current = next;
            }
            return removed; // Возвращаем флаг удаления
        }

        // Глубокое клинрование
        public MyList<T> DeepClone()
        {
            // Создаем новый экземпляр списка для хранения клонированных данных
            MyList<T> newList = new MyList<T>();
            // Начинаем с начала текущего списка
            Point<T> current = beg;
            while (current != null)
            {
                // Клонируем данные текущего элемента
                T clonedData = (T)current.Data.Clone();
                newList.AddToEnd(clonedData);
                current = current.Next;
            }
            // Возвращаем новый клонированный список
            return newList;
        }

        // Поверхностное копирование
        public MyList<T> ShallowCopy()
        {
            // Создаем новый экземпляр списка для хранения скопированных данных
            MyList<T> newCopy = new MyList<T>();
            // Начинаем с начала текущего списка
            Point<T> current = beg;
            // Пока текущий элемент не равен null, выполняем копирование
            while (current != null)
            {
                // Получаем ссылку на данные текущего элемента
                T data = current.Data;
                // Добавляем данные в новый список без клонирования
                newCopy.AddToEnd(data);
                // Переходим к следующему элементу для копирования
                current = current.Next;
            }
            // Возвращаем новое поверхностное копирование списка
            return newCopy;
        }

        public void Clear()
        {
            beg = null;
            end = null;
        }


    }
}
