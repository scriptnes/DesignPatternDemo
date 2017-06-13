using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPattern;
using System;
using NSubstitute;

namespace DesignPattern
{
    [TestClass]
    public class DesignPattern_HandlerTests
    {
        private IHandler _iHandler;
        private Handler _testTarget;

        [TestInitialize]
        public void Init()
        {
            _iHandler = Substitute.For<IHandler>();



        }

        [TestMethod]
        public void SetSuccessorTest()
        {
            var param1 = GetIHandler();

            _testTarget.SetSuccessor(_iHandler);

        }

        [TestMethod]
        public void HandleRequestTest()
        {

            _testTarget.HandleRequest(43186308);

        }

        private static Handler GetIHandler()
        {
            return null; //return new Handler() { };
        }

    }
}