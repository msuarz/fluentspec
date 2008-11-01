using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestProcessorBehavior {

    [TestClass]
    public class Given_TestProcessor_When_Expect : BehaviorOf<TestProcessorClass>{

        [TestInitialize]        
        public void Setup() { When.Expect(); }
        
        [TestMethod]
        public void Should_Log_Expected_Call() {
            
            Should.Log.Expect(Expected.Call);
        }
        
        [TestMethod]
        public void Should_Setup_CallBuilder() {
            
            Assert.AreSame(Expected.Call, CallBuilder.ActiveCall);
        }
    }
}