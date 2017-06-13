namespace DesignPattern
{
    //--- Provide a unified interface to a set of interfaces in a subsystem.
    //--- Façade defines a higher-level interface that makes the subsystem easier to use.

    internal static class UsageFacade   
    {
        internal static void UsageMethod()
        {
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
        }
    }

    public class SubSystemOne
    {
        public void MethodOne()
        {
            System.Diagnostics.Debug.WriteLine(" SubSystemOne Method");
        }
    }

    public class SubSystemTwo
    {
        public void MethodTwo()
        {
            System.Diagnostics.Debug.WriteLine(" SubSystemTwo Method");
        }
    }

    public class SubSystemThree
    {
        public void MethodThree()
        {
            System.Diagnostics.Debug.WriteLine(" SubSystemThree Method");
        }
    }

    public class SubSystemFour
    {
        public void MethodFour()
        {
            System.Diagnostics.Debug.WriteLine(" SubSystemFour Method");
        }
    }

    public class Facade
    {
        private readonly SubSystemOne _one;
        private readonly SubSystemTwo _two;
        private readonly SubSystemThree _three;
        private readonly SubSystemFour _four;   

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void MethodA()
        {
            System.Diagnostics.Debug.WriteLine(" \nMethodA() ---- ");
            _one.MethodOne();
            _two.MethodTwo();
            _four.MethodFour();
        }

        public void MethodB()
        {
            System.Diagnostics.Debug.WriteLine(" \nMethodB() ---- ");
            _two.MethodTwo();
            _three.MethodThree();
        }
    }
}