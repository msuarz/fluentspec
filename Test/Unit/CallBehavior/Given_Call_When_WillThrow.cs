using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentSpec.Classes;
using System;

namespace FluentSpec.Test.Unit.CallBehavior {

    [TestClass]
    public class Given_Call_When_WillThrow : BehaviorOf<CallClass> {

        readonly Exception ExpectedException = new Exception();

        [TestInitialize]
        public void Setup() {
            When.WillThrow(ExpectedException);
        }

        [TestMethod]
        public void Setup_ShouldThrowException() {

            Assert.IsTrue(That.ShouldThrowException);
        }

        [TestMethod]
        public void Should_Setup_Result() {
            
            Should.Result = ExpectedException;
        }
    }
}