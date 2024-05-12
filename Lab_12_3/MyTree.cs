using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using Lab_12_3;

namespace Lav_12_3
{
    public class MyTree<T> where T: IInit, IComparable, new()
    {
        Point<T>? root = null;

        int count = 0;

        public int Count => count;

        public MyTree(int length) 
        {
            count = length;
            root = MakeTree(length, root);
        }

        public void ShowTree() // вывод дерева
        {
            Show(root);
        }

        Point<T>? MakeTree(int length, Point<T>? point) // идеально сбалансированное дерево
        {
            T data = new T();
            data.RandomInit();
            Point<T> newItem = new Point<T>(data);
            if (length == 0) return null;
            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Right);
            return newItem;
        }

        void Show(Point<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Right, spaces + 5);
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(point.Data);
                Show(point.Left, spaces + 5);
            }
        }

        public void AddPoint(T data) // дерево поиска
        {
            Point<T> point = root;
            Point<T> current = null;
            bool isExist = false;
            while (point != null && !isExist)
            {
                current = point;
                if (point.Data.CompareTo(data) == 0) // элемент уже есть
                {
                    isExist = true;
                }
                else // ищем место
                {
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
            // нашли место
            if(isExist)
            {
                return; // ничего не добавили
            }
            Point<T> newPoint = new Point<T>(data);
            if (current.Data.CompareTo(data) < 0) // если элемент меньше
                current.Left = newPoint;
            else
                current.Right = newPoint;
            count++;
        }

        void TransFromToArray(Point<T>? point, T[]array, ref int current)
        {
            if(point != null)
            {
                TransFromToArray(point.Left, array, ref current);
                array[current] = point.Data;
                current++;
                TransFromToArray(point.Right, array, ref current);
            }
        }

        public void TransFromToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransFromToArray(root, array, ref current);
            root = new Point<T>(array[0]);
            count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
        }

        public void ClearTree()
        {
            root = null;
            count = 0;
        }

        public T FindMax()
        {
            Point<T>? current = root;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current.Data;
        }
    }
}


