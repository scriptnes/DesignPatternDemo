﻿using System.Collections.Generic;

namespace DesignPattern
{
    //--- Define a one-to-many dependency between objects so that when one object changes state, 
    //--- all its dependents are notified and updated automatically.

    public static class UsageObserver   
    {
        public static void UsageMethod()
        {
            ConcreteSubject s = new ConcreteSubject();
            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));
            s.SubjectState = "ABC";
            s.Notify();
        }
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public abstract class Subject : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();    

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update();
            }
        }
    }

    public class ConcreteSubject : Subject
    {
        public string SubjectState { get; set; }
    }

    public interface IObserver
    {
        void Update();
    }

    public class ConcreteObserver : IObserver
    {
        private readonly string _name;  
        private string _observerState;  
        private readonly ConcreteSubject _subject;      

        //--- C'tor
        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }

        public virtual void Update()
        {
            _observerState = _subject.SubjectState;
            System.Diagnostics.Debug.WriteLine("Observer {0}'s new state is {1}", _name, _observerState);
        }

        public ConcreteSubject Subject { get; set; }
    }
}