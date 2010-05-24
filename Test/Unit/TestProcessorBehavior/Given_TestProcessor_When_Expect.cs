using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestProcessorBehavior {

    [TestClass]
    public class Given_TestProcessor_When_Expect : BehaviorOf<TestProcessorClass>{

        [TestInitialize]
        public void SetUp() { When.Expect(); }

        [TestMethod]
        public void Should_Call_WillBeExpected() {
            
            Should.Call.WillBeExpected();
        }

        [TestMethod]
        public void Should_Log_Expected_Call() {

            Should.Log.Expect(Expected.Call);
        }
        
        [TestMethod]
        public void Should_Setup_CallBuilder_With_ExpectedCall() {

            Assert.AreSame(Expected.Call, CallBuilder.ActiveCall);
        }
    }
}