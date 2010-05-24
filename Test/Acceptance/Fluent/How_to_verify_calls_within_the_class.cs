using System;
using FluentSpec.Test.Acceptance.Classes;
using FluentSpec.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Fluent {

    [TestClass]
    public class How_to_verify_calls_within_the_class : BehaviorOf<Class> {
        
        [TestInitialize]
        public void call_a_Method() { When.Method(); }

        [TestMethod]
        public void use_Should_to_verify_a_VirtualMethod_was_called_from_the_Method() {

            Should.VirtualMethod();
        }

        [TestMethod]
        public void Should_throws_exception_if_a_VirtualMethod_was_not_called_from_the_Method() {
            try {
                Should.AnotherVirtualMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(Helper.DidNotCall));
            }
        }

        [TestMethod]
        public void use_Then_to_verify_a_VirtualMethod_was_called_from_the_Method() {

            Then.VirtualMethod();
        }

        [TestMethod]
        public void Then_throws_exception_if_a_VirtualMethod_was_not_called_from_the_Method() {
            try {
                Then.AnotherVirtualMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(Helper.DidNotCall));
            }
        }

        [TestMethod]
        public void use_ShouldNot_to_verify_a_VirtualMethod_was_not_called_from_the_Method() {

            ShouldNot.AnotherVirtualMethod();
        }

        [TestMethod]
        public void ShouldNot_throws_exception_if_a_VirtualMethod_was_called_from_the_Method() {
            try {
                ShouldNot.VirtualMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(Helper.ShouldNotCall));
            }
        }

    }
}