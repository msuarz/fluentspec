using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestProcessorBehavior {

    [TestClass]
    public class Given_TestProcessor_When_Proccess : BehaviorOf<TestProcessorClass>{
    
        readonly Log Log = TestObjectFor<Log>();
        readonly Call Call = TestObjectFor<Call>();
        
        bool Executed;
        private void TestExecute() { Executed = true; }
        
        [TestInitialize]
        public void SetUp() {
            Given.Execute = TestExecute;
            When.Process(Log, Call);
        }

        [TestMethod]
        public void Should_Setup() {
            Should.Setup(Log, Call);
        }
        
        [TestMethod]
        public void Should_Execute() {
            Assert.IsTrue(Executed);
        }
        
        [TestMethod]
        public void Should_Reset() {
            Should.Reset();
        }

    }
}