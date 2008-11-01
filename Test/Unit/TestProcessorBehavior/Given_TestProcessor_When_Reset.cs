using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestProcessorBehavior {

    [TestClass]
    public class Given_TestProcessor_When_Reset : BehaviorOf<TestProcessorClass> {
        
        [TestInitialize]
        public void Setup() { When.Reset(); }
        
        [TestMethod]
        public void Should_Setup_Record() {

            Assert.IsTrue(Helper.WillDoWhenExecute(Actual.When, "Record"));
        }
        
        [TestMethod]
        public void Should_Setup_not_to_IgnoreArgs() {
            
            Assert.IsFalse(Actual.ShouldIgnoreArgs);
        }
    }
}