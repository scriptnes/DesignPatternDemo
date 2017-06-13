namespace DesignPattern
{
    //--- Attach additional responsibilities to an object dynamically.
    //--- Decorators provide a flexible alternative to subclassing for extending functionality.

    internal static class UsageDecorator    
    {
        internal static void UsageMethod()
        {
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();
            d1.SetComponent(c);
            d2.SetComponent(d1);
            d2.Operation();
        }
    }

    public interface IComponent
    {
        void Operation();
    }

    public class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            System.Diagnostics.Debug.WriteLine("ConcreteComponent.Operation()");
        }
    }

    public abstract class Decorator : IComponent
    {
        protected IComponent Component { get; private set; }    

        public void SetComponent(IComponent component)
        {
            this.Component = component;
        }

        public virtual void Operation()
        {
            Component?.Operation();
            #region Old var.
            //if (Component != null)
            //{
            //    Component.Operation();
            //}
            #endregion
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            System.Diagnostics.Debug.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            System.Diagnostics.Debug.WriteLine("ConcreteDecoratorB.Operation()");
        }

        private void AddedBehavior()
        {
        }
    }
}