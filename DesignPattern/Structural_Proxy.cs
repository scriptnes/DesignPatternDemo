namespace DesignPattern
{
    //--- Provide a surrogate or placeholder for another object to control access to it.

    internal static class UsageProxy    
    {
        internal static void UsageMethod()
        {
            Proxy proxy = new Proxy();
            proxy.Request();
        }
    }

    public interface ISubjectProxy
    {
        void Request();
    }

    public class RealSubject : ISubjectProxy
    {
        public virtual void Request()
        {
            System.Diagnostics.Debug.WriteLine("Called RealSubject.Request()");
        }
    }

    public class Proxy : ISubjectProxy
    {
        private RealSubject _realSubject;   

        public virtual void Request()
        {
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }
            _realSubject.Request();
        }
    }
}