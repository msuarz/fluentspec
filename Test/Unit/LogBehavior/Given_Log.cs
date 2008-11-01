using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.LogBehavior {

    [TestClass]
    public class Given_Log : BehaviorOf<LogClass> {
        
        readonly Call Call = TestObjectFor<Call>();
        readonly Call AnotherCall = TestObjectFor<Call>();
        
        [TestMethod]
        public void Should_Record() {
            
            When.Record(Call);

            Assert.IsTrue(That.Recorded(Call));
            Assert.IsFalse(That.Recorded(AnotherCall));
        }
        
        [TestMethod]
        public void Should_Expect() {

            When.Expect(Call);

            Assert.AreSame(Call, Actual.Expected(Call));
            Assert.IsNull(When.Expected(AnotherCall));
        }
    }
}