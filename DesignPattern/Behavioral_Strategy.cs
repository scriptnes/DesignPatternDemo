namespace DesignPattern
{
    //--- Define a family of algorithms, encapsulate each one, and make them interchangeable. 
    //--- Strategy lets the algorithm vary independently from clients that use it.

    internal static class UsageStrategy 
    {
        internal static void UsageMethod()
        {
            var context = new ContextStrategy(new ConcreteStrategyA());
            context.ContextInterface();
            context = new ContextStrategy(new ConcreteStrategyB());
            context.ContextInterface();
            context = new ContextStrategy(new ConcreteStrategyC());
            context.ContextInterface();
        }
    }

    public interface IStrategy
    {
        void AlgorithmInterface();
    }

    public class ConcreteStrategyA : IStrategy
    {
        public virtual void AlgorithmInterface()
        {
            System.Diagnostics.Debug.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public virtual void AlgorithmInterface()
        {
            System.Diagnostics.Debug.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    public class ConcreteStrategyC : IStrategy
    {
        public virtual void AlgorithmInterface()
        {
            System.Diagnostics.Debug.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    public class ContextStrategy
    {
        private readonly IStrategy _strategy;   

        //--- C'tor
        public ContextStrategy(IStrategy strategy)  
        {
            this._strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}