﻿namespace DesignPattern
{
    //--- Convert the interface of a class into another interface clients expect.
    //--- Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.

    internal static class UsageAdapter  
    {
        internal static void UsageMethod()
        {
            Target target = new Adapter();
            target.TargetRequest();
        }
    }

    public class Target
    {
        public virtual void TargetRequest()
        {
            System.Diagnostics.Debug.WriteLine("Called Target TargetRequest()");
        }
    }

    public class Adapter : Target
    {
        private readonly Adaptee _adaptee = new Adaptee();  

        public override void TargetRequest()
        {
            //--- Call the AdapteeSpecificRequest to use the Adaptee's specific functionallity
            _adaptee.AdapteeSpecificRequest();
        }
    }

    public class Adaptee
    {
        public void AdapteeSpecificRequest()
        {
            System.Diagnostics.Debug.WriteLine("You called AdapteeSpecificRequest()");
        }
    }
}