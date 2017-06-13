using System.Collections.Generic;

namespace DesignPattern
{
    //--- Provide a way to access the elements of an aggregate object  
    //--- sequentially without exposing its underlying representation.

    internal static class UsageIterator 
    {
        internal static void UsageMethod()
        {
            ConcreteAggregate a = new ConcreteAggregate
            {
                [0] = "Item A",
                [1] = "Item B",
                [2] = "Item C",
                [3] = "Item D"
            };
            ConcreteIterator i = new ConcreteIterator(a);
            System.Diagnostics.Debug.WriteLine("Iterating over collection:");
            string item = i.First();
            while (item != null)
            {
                System.Diagnostics.Debug.WriteLine(item);
                item = i.Next();
            }
        }
    }

    public interface IAggregate
    {
        IIterator CreateIterator();
    }

    public class ConcreteAggregate : IAggregate 
    {
        private readonly List<string> _items = new List<string>();  

        public virtual IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public string this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }

    public interface IIterator
    {
        string First();
        string Next();
        bool IsDone();
        string CurrentItem();
    }

    public class ConcreteIterator : IIterator
    {
        private readonly ConcreteAggregate _aggregate;  
        private int _current = 0;

        //--- C'tor
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        public virtual string First()
        {
            return _aggregate[0];
        }

        public virtual string Next()
        {
            string ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }
            return ret;
        }

        public virtual string CurrentItem()
        {
            return _aggregate[_current];
        }

        public virtual bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}