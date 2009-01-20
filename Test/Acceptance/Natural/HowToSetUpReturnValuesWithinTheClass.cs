using fitlibrary;
using FluentSpec.Test.Acceptance.Classes;

namespace FluentSpec.Test.Acceptance.Natural {

    public class HowToSetUpReturnValuesWithinTheClass : DoFixture {

        Class Class; 

        public void GivenAClass() {
            Class = Create.TestObjectFor<Class>();            
        }

        public void WithAnUnsetGuardClause() { }

        public void WithAGuardPropertySetTo(bool Value) {
            Given.That(Class).GuardProperty = Value;
        }

        public void WithAGuardPropertyThatWillReturn(bool Value) {
            Given.That(Class).GuardProperty.WillReturn(Value);
        }

        public void WhenExecutingAMethodThatMightCallAGuardedMethod() {
            Class.Method();
        }

        public bool ThenTheGuardedMethodShouldNotBeCalled() {
            return Verified.That(() => Class.ShouldNot().DoGuardedMethod());
        }

        public bool ThenTheGuardedMethodShouldBeCalled() {
            return Verified.That(() => Class.Should().DoGuardedMethod());
        }

    }
}