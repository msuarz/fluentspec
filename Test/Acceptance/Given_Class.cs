using System;
using FluentSpec.Classes;
using FluentSpec.Test.Acceptance.Classes;
using FluentSpec.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance {

    [TestClass]
    public class Given_Class : BehaviorOf<Class> {

        [TestMethod]
        public void When_Method_Should_VirtualMethod() {
            When.Method();
            Should.VirtualMethod();
        }

        [TestMethod]
        public void When_Should_fails_throws_exception() {
            When.Method();
            try {
                Should.NestedVirtualMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(TestProcessorClass.DidNotCall));
            }
        }
        
        [TestMethod]
        public void When_Method_ShouldNot_NestedVirtualMethod() {
            When.Method();
            ShouldNot.NestedVirtualMethod();
        }

        [TestMethod]
        public void When_ShouldNot_fails_throws_exception() {
            When.Method();
            try {
                ShouldNot.VirtualMethod();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception e) {
                Assert.IsTrue(e.Message.Contains(TestProcessorClass.ShouldNotCall));
            }
        }
        
        [TestMethod]
        public void When_VirtualMethod_Should_NestedVirtualMethod() {
            When.VirtualMethod();
            Should.NestedVirtualMethod();
        }

        [TestMethod]
        public void When_Method_Should_GuardedMethod_If_Given_ConditionalMethod() {
            Given.ConditionalMethod().WillReturn(true);
            When.Method();
            Should.GuardedMethod();
        }

        [TestMethod]
        public void When_ConditionalMethod_If_Given_ConditionalProperty() {
            Given.ConditionalProperty = true;
            Assert.IsTrue(When.ConditionalMethod());
        }

        [TestMethod]
        public void When_UnexpectedResult_Should_return_default_value() {
            Assert.IsFalse(When.ConditionalMethod());
        }
    }
}