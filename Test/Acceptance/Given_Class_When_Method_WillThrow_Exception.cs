using System;
using FluentSpec.Test.Unit;
using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance {

    [TestClass]
    public class Given_Class_When_Method_WillThrow_Exception : BehaviorOf<Class> {

        private readonly Exception ExpectedException = new Exception();

        private void AssertWhenMethodThrowsExpectedException() {
            try {
                When.Method();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception ActualException) {
                Assert.AreSame(ActualException, ExpectedException);
            }
        }

        [TestMethod]
        public void Given_ConditionalMethod_WillThrow_Exception() {

            Given.BoolProperty.WillThrow(ExpectedException);

            AssertWhenMethodThrowsExpectedException();
        }

        [TestMethod]
        public void Given_VirtualMethod_WillThrow_Exception(){

            Given.VirtualMethod(); WillThrow(ExpectedException);

            AssertWhenMethodThrowsExpectedException();
        }

        [TestMethod]
        public void Given_ExpectedException_Should_GuardedMethod() {

            Given.ExpectedException.WillReturn(ExpectedException);
            When.Method();
            Should.GuardedMethodForException();
        }
        
        [TestMethod]
        public void Without_ExpectedException_ShouldNot_GuardedMethod() {
            const Exception NullException = null;

            Given.ExpectedException.WillReturn(NullException);
            When.Method();
            ShouldNot.GuardedMethodForException();
        }
    }
}