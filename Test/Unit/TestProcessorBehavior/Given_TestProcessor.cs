using System;
using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestProcessorBehavior {

    [TestClass]
    public class Given_TestProcessor : BehaviorOf<TestProcessorClass> {
        
        [TestMethod]
        public void When_IgnoreArgs_Should_IgnoreArgs() {
            
            Assert.IsFalse(Actual.ShouldIgnoreArgs);
            When.IgnoreArgs();
            Assert.IsTrue(Actual.ShouldIgnoreArgs);
        }
        
        [TestMethod]
        public void When_Connector_Should_Return_this() {

            Assert.AreSame(Expected, Actual);
            Assert.AreSame(Expected, Actual.Given);
            Assert.AreSame(Expected, Actual.When);
            Assert.AreSame(Expected, Actual.Should);
            Assert.AreSame(Expected, Actual.ShouldNot);
        }
        
        [TestMethod]
        public void When_Given_Should_Execute_Expect() {
        
            Assert.IsTrue(Helper.WillDoWhenExecute(Actual.Given, "Expect"));
        }
        
        [TestMethod]
        public void When_Actual_When_Should_Execute_Record() {
        
            Assert.IsTrue(Helper.WillDoWhenExecute(Actual.When, "Record"));
        }
        
        [TestMethod]
        public void When_Should_Should_Execute_VerifyCalled() {
            Assert.IsTrue(Helper.WillDoWhenExecute(Actual.Should, "VerifyCalled"))
        ;}
        
        [TestMethod]
        public void When_ShouldNot_Should_Execute_VerifyDidNotCall() {
        
            Assert.IsTrue(Helper.WillDoWhenExecute(Actual.ShouldNot, "VerifyDidNotCall"));
        }
        
        [TestMethod]
        public void When_ExpectSubjectAction() {

            Assert.IsTrue(Helper.WillExpectSubjectActionOn(Actual.When));

            Assert.IsFalse(Helper.WillExpectSubjectActionOn(Actual.Given));
            Assert.IsFalse(Helper.WillExpectSubjectActionOn(Actual.Should));
            Assert.IsFalse(Helper.WillExpectSubjectActionOn(Actual.ShouldNot));
        }

        string ExpectedError;
        
        [TestMethod]
        public void When_VerifyCalled_Should_fail_If_not_logged_Call() {
            
            ExpectedError = TestProcessorClass.DidNotCall;

            try {
                When.VerifyCalled();
                Assert.Fail(Helper.ShouldHaveThrownException);    
            } catch (Exception Exception) {
                Assert.IsTrue(Exception.Message.Contains(ExpectedError));
            }
        }

        [TestMethod]
        public void When_VerifyCalled_Should_work_If_logged_Call() {

            Given.Log.Recorded(Expected.Call).WillReturn(true);
            When.VerifyCalled();
        }

        [TestMethod]
        public void When_VerifyDidNotCall_Should_fail_If_logged_Call() {
            
            ExpectedError = TestProcessorClass.ShouldNotCall;

            Given.Log.Recorded(Expected.Call).WillReturn(true);
            
            try {
                When.VerifyDidNotCall();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception Exception) {
                Assert.IsTrue(Exception.Message.Contains(ExpectedError));
            }
        }

        [TestMethod]
        public void When_VerifyDidNotCall_Should_work_If_not_logged_Call() {
        
            When.VerifyDidNotCall();
        }

        readonly object ExpectedResult = new object();
        readonly Call ExpectedCall = TestObjectFor<Call>();

        [TestMethod]
        public void When_return_expected_Result() {

            ExpectedCall.Given().Result.WillReturn(ExpectedResult);
            Given.ExpectedCall.WillReturn(ExpectedCall);
            
            Assert.AreSame(ExpectedResult, Actual.Result);
        }

        [TestMethod]
        public void When_return_default() {

            Given.UnexpectedCall.WillReturn(true);
            Given.Call.Result.WillReturn(ExpectedResult);
            
            Assert.AreSame(ExpectedResult, Actual.Result);
        }

        [TestMethod]
        public void When_ExpectedCall_Returns_logged_ExpectedCall() {

            Assert.IsNull(Actual.ExpectedCall);

            Given.Log.Expected(Expected.Call).WillReturn(ExpectedCall);
            Assert.AreSame(ExpectedCall, Actual.ExpectedCall);
        }

        [TestMethod]
        public void When_UnexpectedCall() {
            
            Assert.IsTrue(When.UnexpectedCall);
        }
        
        [TestMethod]
        public void When_ExpectedCall() {

            Given.ExpectedCall.WillReturn(ExpectedCall);
            Assert.IsFalse(When.UnexpectedCall);
        }
    }
}