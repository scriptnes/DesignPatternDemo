using System.Diagnostics;

namespace DesignPattern
{
    //--- Ensure a class has only one instance and provide a global point of access to it.

    internal static class UsageSingleton    
    {
        internal static void UsageMethod()
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();
            Debug.Assert(s1 == s2);
        }
    }

    public class Singleton
    {
        private static Singleton _instance; 

        //--- C'tor is non public, so can't be instantiated
        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            //--- Note: Not thread safe!
            return _instance ?? (_instance = new Singleton());

            #region old variant
            //if (_instance == null)
            //{
            //    _instance = new Singleton();
            //}
            //return _instance;
            #endregion

        }
    }
}