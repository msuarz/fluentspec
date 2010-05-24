using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Classic.WithStatics {

    [TestClass]
    public class How_to_setup_return_values_on_dependency_calls {

        readonly Class Subject = Create.TestObjectFor<Class>();

        void a_guarded_method_should_not_be_called() {
            Subject.Method();
            Then.ShouldNot(Subject).DoGuardedMethod();
        }

        void a_guarded_method_should_be_called() {
            Subject.Method();
            Then.Should(Subject).DoGuardedMethod();
        }

        [TestMethod]
        public void if_nothing_is_set_will_return_default_value() {

            // Given guard is false by default
            a_guarded_method_should_not_be_called();
        }

        [TestMethod]
        public void use_GivenThat_and_set_the_Dependency_Property_value() {

            Given.That(Subject).Dependency.GuardProperty = true;

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_Dependency_Property_WillReturn_value() {

            Given.That(Subject).Dependency.GuardProperty.WillReturn(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_Dependency_Property_Is_value() {

            Given.That(Subject).Dependency.GuardProperty.Is(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_Dependency_Property_Are_value() {

            Given.That(Subject).Dependency.GuardProperty.Are(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_Dependency_Function_WillReturn_value() {

            Given.That(Subject).Dependency.GuardFunction().WillReturn(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_Dependency_Function_Is_value() {

            Given.That(Subject).Dependency.GuardFunction().Is(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_Dependency_Function_Are_value() {

            Given.That(Subject).Dependency.GuardFunction().Are(true);

            a_guarded_method_should_be_called();
        }
    }
}