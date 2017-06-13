namespace DesignPattern
{
    //--- Allow an object to alter its behavior when its internal state changes.
    //--- The object will appear to change its class.

    internal static class UsageState    
    {
        internal static void UsageMethod()
        {
            var context = new ContextMe(new ConcreteStateA());
            context.Request();
            context.Request();
            context.Request();
            context.Request();
        }
    }

    public interface IState
    {
        void Handle(ContextMe context);
    }

    public class ConcreteStateA : IState
    {
        public virtual void Handle(ContextMe context)
        {
            context.State = new ConcreteStateB();
        }
    }

    public class ConcreteStateB : IState
    {
        public virtual void Handle(ContextMe context)
        {
            context.State = new ConcreteStateA();
        }
    }

    public class ContextMe
    {
        private IState state;

        //--- C'tor
        public ContextMe(IState state)  
        {
            State = state;
        }

        public IState State
        {
            get { return state; }
            set
            {
                state = value;
                System.Diagnostics.Debug.WriteLine("State: " + state.GetType().Name);
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }
}