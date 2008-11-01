using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance {

    [TestClass]
    public class Given_Interface : BehaviorOf<Dependency> {
        
        [TestMethod]
        public void When_Method_Should_Method() {
            When.Method();
            Should.Method();
        }

        [TestMethod]
        public void Given_ConditionalMethod_Actual_ConditionalMethod() {
            Given.ConditionalMethod().WillReturn(true);
            Assert.IsTrue(Actual.ConditionalMethod());
        }
    }
}