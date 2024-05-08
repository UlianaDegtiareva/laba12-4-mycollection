using ClassLibraryLaba10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12_4_mycollection
{
    public class MyCollection_HashTable<T> : MyHashTable<T>, IEnumerable<T> where T : IInit, IComparable, ICloneable, new()
    {
        public MyCollection_HashTable() : base() { }
        public MyCollection_HashTable(int size, double fillRatio) : base(size, fillRatio) { }
        public MyCollection_HashTable(params T[] collection) : base(collection) { }

        public new void AddItem(T item)
        {
            base.AddItem(item);
        }

        public new void Print()
        { 
            base.Print();
        }

        public new bool RemoveData(T data)
        {
            return base.RemoveData(data);
        }

        public new bool Contains(T data)
        { 
            return base.Contains(data);
        }

        public new MyCollection_HashTable<T> CopyTable()
        {
            MyCollection_HashTable<T> copiedTable = new MyCollection_HashTable<T>(Capacity, fillRatio);

            // Копируем элементы из текущей таблицы в новую таблицу
            for (int i = 0; i < Capacity; i++)
            {
                copiedTable.table[i] = table[i];
            }

            return copiedTable;
        }

        public new MyCollection_HashTable<T> DeepCopy()
        {
            MyCollection_HashTable<T> copiedTable = new MyCollection_HashTable<T>(Capacity, fillRatio);

            // Клонируем каждый элемент из текущей таблицы и добавляем его в новую таблицу
            for (int i = 0; i < Capacity; i++)
            {
                if (table[i] != null)
                {
                    copiedTable.table[i] = (T)table[i].Clone();
                }
            }

            return copiedTable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    internal class MyEnumerator<T> : IEnumerator<T> where T : IInit, IComparable, ICloneable, new()
    {
        MyCollection_HashTable<T> collection;
        int position = -1; // Текущая позиция перечислителя

        public MyEnumerator(MyCollection_HashTable<T> collection)
        {
            this.collection = collection;
            position = -1; // Устанавливаем начальную позицию на 0
        }
        public T Current => collection.table[position];

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            // Метод Dispose пустой, так как в данном случае нет необходимости освобождать ресурсы
        }

        // Перемещаемся к следующему элементу в коллекции
        public bool MoveNext()
        {
            position++;
            while (position < collection.Capacity && collection.table[position] == null)
            {
                position++;
            }
            if (position >= collection.Capacity)
            {
                Reset(); // Сбросить перечислитель к началу, если достигнут конец коллекции
                return false;
            }
            return true;
        }

        // Сбрасываем перечислитель к началу
        public void Reset()
        {
            position = -1;
        }
    }
}
