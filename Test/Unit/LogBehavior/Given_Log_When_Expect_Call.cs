using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.LogBehavior {

    [TestClass]
    public class Given_Log_When_Expect_Call : BehaviorOf<LogClass> {

        readonly Call Call = TestObjectFor<Call>();
        readonly Call AnotherCall = TestObjectFor<Call>();

        [TestInitialize]
        public void Setup() {

            Given.IndexOf(Call).Is(-1);
            When.Expect(Call);
        }

        [TestMethod]
        public void Should_Expect_Call() {

            Assert.AreSame(Call, Actual.Expected(Call));
            Assert.IsNull(That.Expected(AnotherCall));
        }

        [TestMethod]
        public void Should_overwrite_Call_Given_another_has_same_index() {

            Given.IndexOf(AnotherCall).Is(Actual.IndexOf(Call));
            When.Expect(AnotherCall);

            Assert.AreSame(AnotherCall, Actual.Expected(AnotherCall));
            Assert.IsNull(That.Expected(Call));
        }
    }
}