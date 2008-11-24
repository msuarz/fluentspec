using fitlibrary;
using FluentSpec.Test.Acceptance.Classes;

namespace FluentSpec.Test.Acceptance.Natural {

    public class HowToSetUpReturnValuesWithinTheClass : DoFixture {

        Class Subject; 

        public void GivenGuardClauseIsNotSet() {
            Subject = Create.TestObjectFor<Class>();
        }

        public void GivenGuardPropertyIsSetTo(bool value) {
            Subject = Create.TestObjectFor<Class>();
            Given.That(Subject).GuardProperty = value;
        }

        public void GivenGuardPropertyWillReturn(bool value) {
            Subject = Create.TestObjectFor<Class>();
            Given.That(Subject).GuardProperty.WillReturn(true);
        }

        public void WhenExecutingAMethodThatMightCallAGuardedMethod() {
            Subject.Method();
        }

        public bool ThenTheGuardedMethodShouldNotBeCalled() {
            try {
                Then.ShouldNot(Subject).GuardedMethod();
                return true;
            } catch { return false; }
        }

        public bool ThenTheGuardedMethodShouldBeCalled() {
            try {
                Then.Should(Subject).GuardedMethod();
                return true;
            } catch { return false; }
        }
    }
}