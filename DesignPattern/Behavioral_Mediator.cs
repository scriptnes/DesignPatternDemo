namespace DesignPattern
{
    //--- Define an object that encapsulates how a set of objects interact. 
    //--- Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.

    internal static class UsageMediator 
    {
        internal static void UsageMethod()
        {
            ConcreteMediator m = new ConcreteMediator();
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            m.Colleague1 = c1;
            m.Colleague2 = c2;
            c1.Send("How are you?");
            c2.Send("Fine, thanks");
        }
    }

    public interface IMediator
    {
        void Send(string message, Colleague colleague);
    }

    public class ConcreteMediator : IMediator
    {
        private ConcreteColleague1 _colleague1; 
        private ConcreteColleague2 _colleague2; 

        public ConcreteColleague1 Colleague1
        {
            set { _colleague1 = value; }
        }

        public ConcreteColleague2 Colleague2
        {
            set { _colleague2 = value; }
        }

        public virtual void Send(string message, Colleague colleague)
        {
            if (colleague == _colleague1)
            {
                _colleague2.Notify(message);
            }
            else
            {
                _colleague1.Notify(message);
            }
        }
    }

    public abstract class Colleague
    {
        protected readonly IMediator Mediator;  

        //--- C'tor
        protected Colleague(IMediator mediator)
        {
            this.Mediator = mediator;
        }
    }

    public class ConcreteColleague1 : Colleague
    {
        //--- C'tor
        public ConcreteColleague1(IMediator mediator)
          : base(mediator)
        {
        }

        public void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            System.Diagnostics.Debug.WriteLine("Colleague1 gets message: " + message);
        }
    }

    public class ConcreteColleague2 : Colleague
    {
        //--- C'tor
        public ConcreteColleague2(IMediator mediator)
          : base(mediator)
        {
        }

        public void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            System.Diagnostics.Debug.WriteLine("Colleague2 gets message: " + message);
        }
    }
}