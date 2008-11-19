using System;
using FluentSpec.Test.Acceptance.Classes;
using FluentSpec.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Fluent {

    [TestClass]
    public class How_to_verify_calls_within_the_class_in_a_virtual_method : BehaviorOf<Class> {

        [TestInitialize]
        public void call_a_VirtualMethod() { When.VirtualMethod(); }

        [TestMethod]
        public void use_Should_to_verify_AnotherVirtualMethod_was_called_from_the_VirtualMethod() {

            Should.AnotherVirtualMethod();
        }

        [TestMethod]
        public void Should_throws_exception_if_a_VirtualMethod_was_not_called_from_the_VirtualMethod() {
            try {
                Should.VirtualMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(Helper.DidNotCall));
            }
        }

        [TestMethod]
        public void use_Then_to_verify_AnotherVirtualMethod_was_called_from_the_VirtualMethod() {

            Then.AnotherVirtualMethod();
        }

        [TestMethod]
        public void Then_throws_exception_if_a_VirtualMethod_was_not_called_from_the_VirtualMethod() {
            try {
                Then.VirtualMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(Helper.DidNotCall));
            }
        }

        [TestMethod]
        public void use_ShouldNot_to_verify_a_VirtualMethod_was_not_called_from_the_VirtualMethod() {

            ShouldNot.VirtualMethod();
        }

        [TestMethod]
        public void ShouldNot_throws_exception_if_AnotherVirtualMethod_was_called_from_the_VirtualMethod() {
            try {
                ShouldNot.AnotherVirtualMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(Helper.ShouldNotCall));
            }
        }
    }
}