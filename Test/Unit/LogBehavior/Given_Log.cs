using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.LogBehavior {

    [TestClass]
    public class Given_Log : BehaviorOf<LogClass> {
        
        readonly Call Call = TestObjectFor<Call>();
        readonly Call AnotherCall = TestObjectFor<Call>();
        
        [TestMethod]
        public void Should_Record() {
            Call.Given().Equals(Call).Is(true);
            
            When.Record(Call);
            
            Then.Recorded(Call).ShouldBeTrue();
            Then.Recorded(AnotherCall).ShouldBeFalse();
        }
    }
}