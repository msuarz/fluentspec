using System;
using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentSpec.Test.Unit;

namespace FluentSpec.Test.Acceptance.Fluent {

    [TestClass]
    public class How_to_setup_exceptions_on_dependency_calls : BehaviorOf<Class> {

        readonly Exception ExpectedException = new Exception();

        void the_expected_exception_should_be_thrown_in_a_method() {
            try {
                When.Method();
                Assert.Fail(Helper.ShouldHaveThrownException);
            } catch (Exception ActualException) {
                Assert.AreSame(ActualException, ExpectedException);
            }
        }

        [TestMethod]
        public void use_Given_VirtualFunction_WillThrow_exception() {

            Given.Dependency.GuardFunction().WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_Given_VirtualMethod_WillThrow_exception() {

            Given.Dependency.Method(); WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_Given_Property_WillThrow_exception() {

            Given.Dependency.GuardProperty.WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_Given_Property_is_set_to_value_WillThrow_exception() {

            Given.Dependency.Property = true;
            WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

    }
}