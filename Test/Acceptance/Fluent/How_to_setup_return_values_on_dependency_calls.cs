using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Fluent {

    [TestClass]
    public class How_to_setup_return_values_on_dependency_calls : BehaviorOf<Class> {

        void a_guarded_method_should_not_be_called() {
            When.Method();
            ShouldNot.GuardedMethod();
        }

        void a_guarded_method_should_be_called() {
            When.Method();
            Should.GuardedMethod();
        }

        [TestMethod]
        public void if_nothing_is_set_will_return_default_value() {

            // Given guard is false by default
            a_guarded_method_should_not_be_called();
        }

        [TestMethod]
        public void use_Given_and_set_the_Dependency_Property_value() {

            Given.Dependency.GuardProperty = true;

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Dependency_Property_WillReturn_value() {

            Given.Dependency.GuardProperty.WillReturn(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Dependency_Property_Is_value() {

            Given.Dependency.GuardProperty.Is(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Dependency_Property_Are_value() {

            Given.Dependency.GuardProperty.Are(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Dependency_Function_WillReturn_value() {

            Given.Dependency.GuardFunction().WillReturn(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Dependency_Function_Is_value() {

            Given.Dependency.GuardFunction().Is(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Dependency_Function_Are_value() {

            Given.Dependency.GuardFunction().Are(true);

            a_guarded_method_should_be_called();
        }
    }
}