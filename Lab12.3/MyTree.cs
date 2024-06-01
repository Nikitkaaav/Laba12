using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12._3
{
    public class MyTree<T> where T : IInit, IComparable, new()
    {
        Point<T>? root = null;

        int count = 0;

        public int Count => count;

        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }

        public void ShowTree()
        {
            Show(root);
        }

        // Идеально сбалансированное дерево
        Point<T>? MakeTree(int length, Point<T>? point)
        {
            //Инициализация объекта данных типа Т случайным образом
            T data = new T();
            data.RandomInit();
            //Создается новый узел с данными и текущими данными, и его возвращаемое значение устанавливается как newItem
            Point<T> newItem = new Point<T>(data);
            //Если кол-во узлов 0, возвращается null, что означает пустое поддерево
            if (length == 0)
            {
                return null;
            }
            //Вычисление количества узлов для левого и правого поддеревьев
            int nl = length / 2;
            int nr = length - nl - 1;
            //Вызов MakeTree для создания левого поддерева соответствующего размера
            newItem.Left = MakeTree(nl, newItem.Left);
            //Вызов MakeTree для создания правого поддерева соответствующего размера
            newItem.Right = MakeTree(nr, newItem.Right);
            //Возвращаем корневой узел созданного поддерева
            return newItem;
        }

        void Show(Point<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                //Рекурсивный вызов Show для отображения левого поддерева с отступами
                Show(point.Left, spaces + 5);
                //Выводим отступы перед данными текущего узла для наглядного отображения структуры дерева
                for (int i = 0; i < spaces; i++)
                    Console.Write(" ");
                //Выводим данные текущего узла на консоль
                Console.WriteLine(point.Data);
                //Рекурсивный вызов Show для отображения правого поддерева с отступами
                Show(point.Right, spaces + 5);
            }
        }

        // Метод для вычисления среднего арифметического значений всех элементов в дереве
        double CalculateAverage(Point<T>? point)
        {
            if (point == null)
            {
                return 0; //Возвращаем 0, если узел пустой
            }
            //Рекурсивно находим сумму всех значений в левом и правом поддеревьях
            double sum = Convert.ToDouble(point.Data) + CalculateAverage(point.Left) + CalculateAverage(point.Right);
            //Подсчитываем количество всех узлов в дереве
            int count = 1 + CountNodes(point.Left) + CountNodes(point.Right);
            //Вычисляем и возвращаем среднее арифметическое
            return sum / count;
        }

        // Метод для вычисления количества узлов в дереве
        int CountNodes(Point<T>? point)
        {
            if (point == null)
            {
                return 0; //Возвращаем 0, если узел пустой
            }
            //Рекурсивно считаем количество узлов в левом и правом поддеревьях
            return 1 + CountNodes(point.Left) + CountNodes(point.Right);
        }

        //Дерево поиска
        public void AddPoint(T data)
        {
            // Начинаем с корня дерева
            Point<T>? point = root;
            Point<T>? current = null; //Для хранения текущего узла
            bool isExist = false; //Флаг для проверки существования элемента в дереве
            //Проходим по дереву, пока не найдем место для вставки нового элемента или не обнаружим его существование
            while (point != null && !isExist)
            {
                current = point; //Обновляем текущий узел
                //Сравниваем значение текущего узла с новым значением
                if (point.Data.CompareTo(data) == 0)
                {
                    isExist = true; //Элемент уже существует в дереве
                }
                else
                {
                    //Переходим к левому или правому потомку в зависимости от значения
                    if (point.Data.CompareTo(data) < 0)
                    {
                        point = point.Left;
                    }
                    else
                    {
                        point = point.Right;
                    }
                }
            }
            //Если элемент уже существует, прекращаем выполнение метода
            if (isExist)
            {
                return;
            }
            //Создаем новый узел для вставки
            Point<T> newPoint = new Point<T>(data);
            //Вставляем новый узел в дерево
            if (current.Data.CompareTo(data) < 0)
            {
                current.Left = newPoint;
            }
            else
            {
                current.Right = newPoint;
            }
            count++; //Увеличиваем счетчик узлов в дереве
        }

        // Метод для сохранения элементов бинарного дерева в массиве
        void TransformToArray(Point<T>? point, T[] array, ref int current)
        {
            //Проверяем, не дошли ли мы до пустого узла
            if (point != null)
            {
                //Рекурсивно вызываем TransformToArray для левого поддерева
                TransformToArray(point.Left, array, ref current);
                //Сохраняем значение текущего узла в массиве
                array[current] = point.Data;
                //Увеличиваем текущий индекс в массиве
                current++;
                //Рекурсивно вызываем TransformToArray для правого поддерева
                TransformToArray(point.Right, array, ref current);
            }
        }

        // Метод для создания дерева из элементов, сохраненных в массиве
        public void TransformToFindTree()
        {
            //Создаем новый массив для хранения элементов дерева
            T[] array = new T[count];
            int current = 0;
            //Заполняем массив элементами дерева, используя метод TransformToArray
            TransformToArray(root, array, ref current);
            //Создаем новый корневой узел для дерева
            root = new Point<T>(array[0]);
            //Сбрасываем счетчик элементов в исходном дневе
            count = 0;
            //Добавляем оставшиеся элементы из массива в новое дерево
            for (int i = 1; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
        }
    }
}
