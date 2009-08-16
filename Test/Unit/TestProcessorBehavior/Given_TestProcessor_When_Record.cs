using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestProcessorBehavior {

    [TestClass]
    public class Given_TestProcessor_When_Record : BehaviorOf<TestProcessorClass>{
        
        [TestInitialize]
        public void SetUp() { When.Record(); }
        
        [TestMethod]
        public void Should_Should_Log_Call() {

            Should.Log.Record(Actual.Call);
        }
        
        [TestMethod]
        public void Should_ThrowExceptionIfExpected() {
            
            Should.ThrowExceptionIfExpected();
        }
    }
}