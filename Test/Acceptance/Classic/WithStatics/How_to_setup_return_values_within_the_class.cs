using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Classic.WithStatics {

    [TestClass]
    public class How_to_setup_return_values_within_the_class {

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
        public void use_GivenThat_and_set_the_Property_value() {

            Given.That(Subject).GuardProperty = true;

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_Property_WillReturn_value() {

            Given.That(Subject).GuardProperty.WillReturn(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_Property_Is_value() {

            Given.That(Subject).GuardProperty.Is(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_Property_Are_value() {

            Given.That(Subject).GuardProperty.Are(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_VirtualFunction_WillReturn_value() {

            Given.That(Subject).GuardFunction().WillReturn(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_VirtualFunction_Is_value() {

            Given.That(Subject).GuardFunction().Is(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_GivenThat_VirtualFunction_Are_value() {

            Given.That(Subject).GuardFunction().Are(true);

            a_guarded_method_should_be_called();
        }

    }
}