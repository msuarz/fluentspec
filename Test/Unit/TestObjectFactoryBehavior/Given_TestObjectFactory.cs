using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestObjectFactoryBehavior {

    [TestClass]
    public class Given_TestObjectFactory : BehaviorOf<TestObjectFactory> {

        [TestMethod]
        public void When_ShouldTestProperty() {
        
            Given.Property = Helper.TesteableProperty;
            Assert.IsTrue(That.ShouldTestProperty);
        }

        [TestMethod]
        public void When_ShouldNotTestProperty() {
        
            Given.Property = Helper.NonTesteableProperty;
            Assert.IsFalse(That.ShouldTestProperty);
        }
    }
}