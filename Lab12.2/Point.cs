﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    internal class Point<T> /*where T : IComparable*/
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Pred { get; set; }

        public Point()
        {
            this.Data = default(T);
            this.Next = null;
            this.Pred = null;
        }
        public Point(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Pred = null;
        }
        public override string ToString()
        {
            return Data == null ? "" : Data.ToString();
        }

        public override int GetHashCode()
        {
            return Data == null ? 0 : Data.GetHashCode();
        }

        //public int CompareTo(Point<T> other)
        //{
        //    return Data.CompareTo(other.Data);
        //}

    }
}

