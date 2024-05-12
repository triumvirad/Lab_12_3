using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12_3
{
    public class Point<T> where T: IComparable
    {
        public T? Data { get; set; }
        public Point<T>? Left { get; set; }
        public Point<T>? Right { get; set; }

        public Point() // конструктор без параметров
        {
            this.Data = default(T);
            this.Left = null;
            this.Right = null;
        }
        public Point(T data) // конструктор с параметрами
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        public override string? ToString()
        {
            if (Data == null) return "";
            else return Data.ToString();
        }

        public int CompareTo(Point<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}
