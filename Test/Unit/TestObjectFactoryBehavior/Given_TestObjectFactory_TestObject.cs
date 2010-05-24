using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestObjectFactoryBehavior {

    [TestClass]
    public class Given_TestObjectFactory_TestObject :
        BehaviorOf<TestObjectFactory> {
        
        private readonly object ExpectedTestObject = new object();

        [TestMethod]
        public void Should_CreateClassProxy_Given_IsClass() {
            
            Given.Type = typeof(object);
            Given.CreateClassProxy.WillReturn(ExpectedTestObject);

            Assert.AreSame(ExpectedTestObject, Actual.TestObject);
        }

        [TestMethod]
        public void Should_CreateInterfaceProxy_Given_IsInterface() {
            
            Given.Type = typeof(IInterface);
            Given.CreateInterfaceProxy.WillReturn(ExpectedTestObject);

            Assert.AreSame(ExpectedTestObject, Actual.TestObject);
        }
    }
}