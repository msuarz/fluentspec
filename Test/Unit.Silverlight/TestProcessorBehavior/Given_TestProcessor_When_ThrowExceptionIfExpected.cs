using System;
using FluentSpec;
using FluentSpec.Classes;
using FluentSpec.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit.Silverlight.TestProcessorBehavior {
    [TestClass]
    public class Given_TestProcessor_When_ThrowExceptionIfExpected
        : BehaviorOf<TestProcessorClass> {
        
        Call ExpectedCall;
        readonly Exception ExpectedException = new Exception();

        [TestInitialize]
        public override void Setup() {
            base.Setup();
            ExpectedCall = TestObjectFor<Call>();
        }
        
        [TestMethod]
        public void ShouldNot_Throw_If_UnexpectedCall() {

            Given.UnexpectedCall.Is(true);
            When.ThrowExceptionIfExpected();
        }

        private void GivenExpectedCall() {
            Given.UnexpectedCall.Is(false);
            Given.ExpectedCall.Is(ExpectedCall);
        }

        private void GivenExpectedException() {
            ExpectedCall.Given().ShouldThrowException.Is(true);
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