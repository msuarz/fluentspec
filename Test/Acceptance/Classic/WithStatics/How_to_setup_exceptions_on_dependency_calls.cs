using System;
using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentSpec.Test.Unit;

namespace FluentSpec.Test.Acceptance.Classic.WithStatics {

    [TestClass]
    public class How_to_setup_exceptions_on_dependency_calls {

        readonly Class Subject = Create.TestObjectFor<Class>();

        readonly Exception ExpectedException = new Exception();

        void the_expected_exception_should_be_thrown_in_a_method() {
            try {
                Subject.Method();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception ActualException) {
                Assert.AreSame(ActualException, ExpectedException);
            }
        }

        [TestMethod]
        public void use_GivenThat_Dependency_Function_WillThrow_exception() {

            Given.That(Subject).Dependency.GuardFunction().WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_GivenThat_Dependency_Method_WillThrow_exception() {

            Given.That(Subject).Dependency.Method(); Subject.WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_GivenThat_Dependency_Property_WillThrow_exception() {

            Given.That(Subject).Dependency.GuardProperty.WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_GivenThat_Dependency_Property_is_set_to_value_WillThrow_exception() {

            Given.That(Subject).Dependency.Property = true;
            Subject.WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

    }
}