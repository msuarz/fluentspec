using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestProcessorBehavior {

    [TestClass]
    public class Given_TestProcessor_When_Setup : BehaviorOf<TestProcessorClass> {
        
        readonly Log Log = TestObjectFor<Log>();
        readonly Call Call = TestObjectFor<Call>();
        
        [TestMethod]
        public void Should_Setup_Log() {
            
            When.Setup(Log, Call);
            Assert.AreSame(Log, Actual.Log);
        }
        
        [TestMethod]
        public void Should_Setup_Call() {

            When.Setup(Log, Call);
            Assert.AreSame(Call, Actual.Call);
        }
        
        [TestMethod]
        public void Should_IgnoreArgs() {
            
            Given.ShouldIgnoreArgs = true;
            When.Setup(Log, Call);
            Should.Call.IgnoreArgs();
        }
        
        [TestMethod]
        public void ShouldNot_IgnoreArgs() {

            When.Setup(Log, Call);
            ShouldNot.Call.IgnoreArgs();
        }
    }
}