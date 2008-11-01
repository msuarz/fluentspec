using System;
using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestProcessorBehavior {

    [TestClass]
    public class Given_TestProcessor_When_ThrowExceptionIfExpected
        : BehaviorOf<TestProcessorClass> {
        
        readonly Call ExpectedCall = TestObjectFor<Call>();
        readonly Exception ExpectedException = new Exception();
        
        [TestMethod]
        public void ShouldNot_Throw_If_UnexpectedCall() {

            Given.UnexpectedCall.WillReturn(true);
            When.ThrowExceptionIfExpected();
        }

        private void GivenExpectedCall() {
            Given.UnexpectedCall.WillReturn(false);
            Given.ExpectedCall.WillReturn(ExpectedCall);
        }

        private void GivenExpectedException() {
            ExpectedCall.Given().ShouldThrowException.WillReturn(true);
            ExpectedCall.Given().Exception.WillReturn(ExpectedException);
        }
        
        [TestMethod]
        public void ShouldNot_Throw_ExpectedCall() {

            GivenExpectedCall();
            When.ThrowExceptionIfExpected();
        }

        [TestMethod]
        public void Should_Throw_ExpectedException() {

            GivenExpectedCall();
            GivenExpectedException();

            try {
                When.ThrowExceptionIfExpected();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception ActualException) {
                Assert.AreSame(ExpectedException, ActualException);
            }
        }

    }
}