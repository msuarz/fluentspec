using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.LogBehavior {

    [TestClass]
    public class Given_Log_When_Expect_Call : BehaviorOf<LogClass> {

        readonly Call Call = TestObjectFor<Call>();

        [TestInitialize]
        public void SetUp() {
            Call.Given().Equals(Call).Is(true);
            When.Expect(Call);
        }

        [TestMethod]
        public void Should_Expect_Call() {
            var AnotherCall = TestObjectFor<Call>();

            Assert.AreSame(Call, Actual.Expected(Call));
            Assert.IsNull(That.Expected(AnotherCall));
        }

        [TestMethod]
        public void Should_overwrite_Call_Given_another_has_same_index() {
            var SameCall = TestObjectFor<Call>();

            Call.Given().Equals(SameCall).Is(true);
            When.Expect(SameCall);

            Assert.IsNull(That.Expected(Call));
        }
    }
}