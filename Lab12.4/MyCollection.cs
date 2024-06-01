using System;
using ClassLibraryLab10;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab12._4
{
    internal class MyCollection<T> : MyList<T>, IEnumerable<T> where T : IInit, ICloneable, new()
    {
        //Конструктор без параметров
        public MyCollection() : base() { }
        //Конструктор с параметром размера
        public MyCollection(int size) : base(size) { }
        //Конструктор, инициализирующий коллекцию существующим массивом
        public MyCollection(T[] collection) : base(collection) { }

        // Метод возвращает перечислитель элементов типа T
        public IEnumerator<T> GetEnumerator()
        {
            //Устанавливаем начальное значение текущего элемента на начало списка
            Point<T> current = beg;
            //Пока текущий элемент не равен null, проходим по всем элементам списка
            while (current != null)
            {
                //Возвращаем данные текущего элемента в текущей итерации перечислителя
                yield return current.Data;
                //Переходим к следующему элементу списка
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    //return new MyEnumerator<T>(this);

    //internal class MyEnumerator<T> : IEnumerator<T> where T : IInit, ICloneable, new()
    //{
    //    Point<T>? beg;
    //    Point<T>? current;

    //    public MyEnumerator(MyCollection<T> collection)
    //    {
    //        beg = collection.beg;
    //        current = beg;
    //    }

    //    public T Current => current.Data;
    //    object IEnumerator.Current => throw new NotImplementedException();

    //    public void Dispose()
    //    {

    //    }

    //    public bool MoveNext()
    //    {
    //        if (current.Next == null)
    //        {
    //            Reset();
    //            return false;
    //        }
    //        else
    //        {
    //            current = current.Next;
    //            return true;
    //        }
    //    }

    //    public void Reset()
    //    {
    //        current = beg;
    //    }
    //}
}
