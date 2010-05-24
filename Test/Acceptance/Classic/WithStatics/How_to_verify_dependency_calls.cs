using System;
using FluentSpec.Test.Acceptance.Classes;
using FluentSpec.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Classic.WithStatics {

    [TestClass]
    public class How_to_verify_dependency_calls {

        readonly Class Subject = Create.TestObjectFor<Class>();

        [TestInitialize]
        public void call_a_Method() { Subject.Method(); }

        [TestMethod]
        public void use_ThenShould_to_verify_a_Dependency_Method_was_called_from_the_Method() {

            Then.Should(Subject).Dependency.Method();
        }

        [TestMethod]
        public void ThenShould_throws_exception_if_a_Dependency_Method_was_not_called_from_the_Method() {
            try {
                Then.Should(Subject).Dependency.AnotherMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(Helper.DidNotCall));
            }
        }

        [TestMethod]
        public void use_ThenShouldNot_to_verify_a_Dependency_Method_was_not_called_from_the_Method() {

            Then.ShouldNot(Subject).Dependency.AnotherMethod();
        }

        [TestMethod]
        public void ThenShouldNot_throws_exception_if_a_Dependency_Method_was_called_from_the_Method() {
            try {
                Then.ShouldNot(Subject).Dependency.Method();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(Helper.ShouldNotCall));
            }
        }

    }
}