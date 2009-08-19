using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentSpec.Classes;
using System;

namespace FluentSpec.Test.Unit.CallBehavior {

    [TestClass]
    public class Given_Call_When_WillThrow : BehaviorOf<Method> {

        readonly Exception ExpectedException = new Exception();

        [TestMethod]
        public void Setup_ShouldThrowException() {

            When.WillThrow(ExpectedException);
            Assert.IsTrue(That.ShouldThrowException);
        }

        [TestMethod]
        public void Should_Setup_Result() {

            When.WillThrow(ExpectedException);
            Should.Result = ExpectedException;
        }
        
        [TestMethod]
        public void Should_SwitchToSetter_If_WasSetter() {

            Given.WasSetter.WillReturn(true);
            When.WillThrow(ExpectedException);
            Should.SwitchToSetter();           
        }
    }
}