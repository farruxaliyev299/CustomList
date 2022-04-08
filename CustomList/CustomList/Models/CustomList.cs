using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CustomList.Models
{
    internal class CustomList<T>:IEnumerable<T>,IComparable<CustomList<T>>
    {
        public T[] list;

        private int _count;
        public int Count { get => _count; }

        public bool IsReadOnly => throw new NotImplementedException();

        public int Capacity { get; set; } = 0;

        public int initialLength;


        public CustomList()
        {
            _count = 0;
            list = new T[0];
            initialLength = list.Length;
        }

        public CustomList(int capacity)
        {
            Capacity = capacity;
            _count = Capacity;
            list = new T[capacity];
            initialLength = list.Length;

        }

        public T this[int index] 
        {
            get
            {
                return list[index];
            }
            set
            {
                if (index >= 0)
                {
                    list[index] = value;
                }
            }
        }

        public void Resizable(bool check)
        {
            if (check)
            {
                if(initialLength == 0)
                {
                    if(list.Length < 2)
                    {
                        Array.Resize(ref list, list.Length+1);
                    }
                    else if(list.Length >= 2)
                    {
                        Array.Resize(ref list, list.Length*2);
                    }
                }
                else
                {
                    Array.Resize(ref list , initialLength + list.Length);
                }
            }
        }

        public void Add(T item)
        {
            Resizable(_count == list.Length);
            list[Count]= item;
            _count++;
        }


        public void Clear()
        {
            T[] elist = new T[0];
            _count = 0;
            list = elist;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if(((IComparable<T>)item).CompareTo(list[i]) == 0)
                {
                    return true;
                }
            }
            return false;
        }



        public T[] Remove(T item)
        {
            T[] result = new T[Capacity-1];
            for (int i = 0; i < list.Length; i++)
            {
                if(((IComparable<T>)item).CompareTo(list[i]) == 0)
                {
                    continue;
                }
                result[i] = list[i];
            }

            return result;
            
        }

        public void Remove(int index)
        {
            T[] result = new T[list.Length - 1];
            for (int i = 0;i< result.Length; i++)
            {
                if (index == i)
                {
                    continue ;
                }
                result[i]= list[i];
            }

            list = result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int CompareTo([AllowNull] CustomList<T> other)
        {
            throw new NotImplementedException();
        }

        
    }
}
