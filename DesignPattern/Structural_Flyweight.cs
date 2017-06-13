using System;
using System.Collections.Generic;

namespace DesignPattern
{
    //--- Use sharing to support large numbers of fine-grained objects efficiently.

    internal static class UsageFlyWeight    
    {
        internal static void UsageMethod()
        {
            int extrinsicstate = 22;
            FlyweightFactory factory = new FlyweightFactory();
            IFlyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);
            IFlyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);
            IFlyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);
            UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();
            fu.Operation(--extrinsicstate);
        }
    }

    public class FlyweightFactory
    {
        private readonly Dictionary<string, IFlyweight> _flyweights = new Dictionary<string, IFlyweight>(); 

        //--- C'tor
        public FlyweightFactory()
        {
            _flyweights.Add("X", new ConcreteFlyweight());
            _flyweights.Add("Y", new ConcreteFlyweight());
            _flyweights.Add("Z", new ConcreteFlyweight());
        }

        public IFlyweight GetFlyweight(string key)
        {
            return _flyweights[key];
        }

    }

    public interface IFlyweight
    {
        void Operation(int extrinsicstate);
    }

    public class ConcreteFlyweight : IFlyweight
    {
        public virtual void Operation(int extrinsicstate)
        {
            System.Diagnostics.Debug.WriteLine("ConcreteFlyweight: " + extrinsicstate);
        }
    }

    public class UnsharedConcreteFlyweight : IFlyweight
    {
        public virtual void Operation(int extrinsicstate)
        {
            System.Diagnostics.Debug.WriteLine("UnsharedConcreteFlyweight: " + extrinsicstate);
        }
    }
}