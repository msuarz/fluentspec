using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestObjectFactoryBehavior {

    [TestClass]
    public class Given_TestObjectFactory_When_TestObjectFor : BehaviorOf<TestObjectFactory> {

        private readonly TestObjectFactory ExpectedTestObject = TestObjectFor<TestObjectFactory>();
        private readonly TestProcessor ExpectedProcessor = TestObjectFor<TestProcessor>();

        private TestObjectFactory ActualTestObject;

        [TestInitialize]
        public void Setup() {
            
            Given.TestObject.WillReturn(ExpectedTestObject);
            Given.TestProcessor.WillReturn(ExpectedProcessor);

            ActualTestObject = When.TestObjectFor<TestObjectFactory>();
        }

        [TestMethod]
        public void Should_return_expected_TestObject() {
            Assert.AreSame(ExpectedTestObject, ActualTestObject);
        }

        [TestMethod]
        public void Should_setup_Type() {
            Assert.AreSame(typeof(TestObjectFactory), Actual.Type);
        }

        [TestMethod]
        public void Should_setup_Processor() {
            Assert.AreSame(ExpectedProcessor, Actual.Processor);
        }

        [TestMethod]
        public void Should_CreateDependencies() {
            Should.CreateDependencies();
        }
    }
}