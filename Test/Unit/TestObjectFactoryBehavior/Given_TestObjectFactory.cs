using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestObjectFactoryBehavior {

    [TestClass]
    public class Given_TestObjectFactory : BehaviorOf<TestObjectFactory> {

        [TestMethod]
        public void When_ShouldTestProperty() {

            Given.Object = new Helper();
            And.Property = Helper.TestableProperty;

            When.ShouldTestProperty.ShouldBeTrue();
        }

        [TestMethod]
        public void When_ShouldNotTestProperty() {
        
            Given.Property = Helper.NonTestableProperty;

            When.ShouldTestProperty.ShouldBeFalse();
        }
    }
}