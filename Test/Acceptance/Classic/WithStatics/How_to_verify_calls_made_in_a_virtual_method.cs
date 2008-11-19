using System;
using FluentSpec.Test.Acceptance.Classes;
using FluentSpec.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Classic.WithStatics {

    [TestClass]
    public class How_to_verify_calls_within_the_class_in_a_virtual_method {

        readonly Class Subject = Create.TestObjectFor<Class>();

        [TestInitialize]
        public void call_a_VirtualMethod() { Subject.VirtualMethod(); }

        [TestMethod]
        public void use_ThenShould_to_verify_AnotherVirtualMethod_was_called_from_the_VirtualMethod() {

            Then.Should(Subject).AnotherVirtualMethod();
        }

        [TestMethod]
        public void ThenShould_throws_exception_if_a_VirtualMethod_was_not_called_from_the_VirtualMethod() {
            try {
                Then.Should(Subject).VirtualMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(Helper.DidNotCall));
            }
        }

        [TestMethod]
        public void use_ThenShouldNot_to_verify_a_VirtualMethod_was_not_called_from_the_VirtualMethod() {

            Then.ShouldNot(Subject).VirtualMethod();
        }

        [TestMethod]
        public void ThenShouldNot_throws_exception_if_AnotherVirtualMethod_was_called_from_the_VirtualMethod() {
            try {
                Then.ShouldNot(Subject).AnotherVirtualMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(Helper.ShouldNotCall));
            }
        }
    }
}