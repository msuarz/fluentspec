using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Classic.WithExtensions {

    [TestClass]
    public class How_to_setup_return_values_within_the_class {

        readonly Class Subject = Create.TestObjectFor<Class>();

        void a_guarded_method_should_not_be_called() {
            Subject.Method();
            Subject.ShouldNot().DoGuardedMethod();
        }

        void a_guarded_method_should_be_called() {
            Subject.Method();
            Subject.Should().DoGuardedMethod();
        }

        [TestMethod]
        public void if_nothing_is_set_will_return_default_value() {

            // Given guard is false by default
            a_guarded_method_should_not_be_called();
        }

        [TestMethod]
        public void use_Given_and_set_the_Property_value() {

            Subject.Given().GuardProperty = true;

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Property_WillReturn_value() {

            Subject.Given().GuardProperty.WillReturn(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Property_Is_value() {

            Subject.Given().GuardProperty.Is(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_Property_Are_value() {

            Subject.Given().GuardProperty.Are(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_VirtualFunction_WillReturn_value() {

            Subject.Given().GuardFunction().WillReturn(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_VirtualFunction_Is_value() {

            Subject.Given().GuardFunction().Is(true);

            a_guarded_method_should_be_called();
        }

        [TestMethod]
        public void use_Given_VirtualFunction_Are_value() {

            Subject.Given().GuardFunction().Are(true);

            a_guarded_method_should_be_called();
        }
    }
}