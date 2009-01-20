using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Fluent {

    [TestClass]
    public class How_to_setup_return_values_within_the_class : BehaviorOf<Class> {

        void a_guarded_method_should_not_be_called() {
            When.Method();
            ShouldNot.DoGuardedMethod();
        }

        void a_guarded_method_should_be_called() {
            When.Method();
            Should.DoGuardedMethod();
        }

        [TestMethod]
        public void if_nothing_is_set_will_return_default_value() {

            // Given guard is false by default
            a_guarded_method_should_not_be_called();
        }

        [TestMethod]
        public void use_Given_and_set_the_Property_value() {

            Given.GuardProperty = true;

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Property_WillReturn_value() {

            Given.GuardProperty.WillReturn(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Property_Is_value() {

            Given.GuardProperty.Is(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Property_Are_value() {

            Given.GuardProperty.Are(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_VirtualFunction_WillReturn_value() {

            Given.GuardFunction().WillReturn(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_VirtualFunction_Is_value() {

            Given.GuardFunction().Is(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_VirtualFunction_Are_value() {

            Given.GuardFunction().Are(true);

            a_guarded_method_should_be_called();
        }
    }
}