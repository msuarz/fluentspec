using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance {

    [TestClass]
    public class Given_Class_Using_Classic_Syntax_With_Statics {

        private readonly Class Subject = Create.TestObjectFor<Class>();

        [TestMethod]
        public void When_Method_Should_VirtualMethod() {

            Subject.Method();
            Then.Should(Subject).VirtualMethod();
        }

        [TestMethod]
        public void When_Method_ShouldNot_NestedVirtualMethod() {

            Subject.Method();
            Then.ShouldNot(Subject).NestedVirtualMethod();
        }

        [TestMethod]
        public void When_Method_Should_GuardedMethod_If_Given_ConditionalMethod() {

            Given.That(Subject).ConditionalMethod().WillReturn(true);
            Subject.Method();
            Then.Should(Subject).GuardedMethod();
        }
    }
}