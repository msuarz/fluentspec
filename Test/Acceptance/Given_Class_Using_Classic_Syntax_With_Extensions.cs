using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance {

    [TestClass]
    public class Given_Class_Using_Classic_Syntax_With_Extensions {

        private readonly Class Subject = Create.TestObjectFor<Class>();

        [TestMethod]
        public void When_Method_Should_VirtualMethod() {
        
            Subject.Method();
            Subject.Should().VirtualMethod();
        }

        [TestMethod]
        public void When_Method_ShouldNot_NestedVirtualMethod() {

            Subject.Method();
            Subject.ShouldNot().NestedVirtualMethod();
        }

        [TestMethod]
        public void When_Method_Should_GuardedMethod_If_Given_ConditionalMethod() {

            Subject.Given().ConditionalMethod().WillReturn(true);
            Subject.Method();
            Subject.Should().GuardedMethod();
        }

    }
}