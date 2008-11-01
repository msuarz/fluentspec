using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance {

    [TestClass]
    public class Given_Class_With_Dependency : BehaviorOf<ClassWithDependency> {

        [TestMethod]
        public void When_Delegate_Should_Dependency_Method() {
        
            When.Delegate();
            Should.Dependency.Method();
        }

        [TestMethod]
        public void When_Delegate_Should_GuardedMethod_If_Given_Dependency_ConditionalMethod() {
        
            Given.Dependency.ConditionalMethod().WillReturn(true);
            When.Delegate();
            Should.GuardedMethod();
        }

        [TestMethod]
        public void When_UnexpectedResult_Should_return_null_if_its_interface() {
        
            Assert.IsNull(When.ReturnUnexpectedInterface);
        }
    }
}