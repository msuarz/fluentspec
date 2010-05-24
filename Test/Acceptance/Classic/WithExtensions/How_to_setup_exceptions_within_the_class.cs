using System;
using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentSpec.Test.Unit;

namespace FluentSpec.Test.Acceptance.Classic.WithExtensions {

    [TestClass]
    public class How_to_setup_exceptions_within_the_class {

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
        public void use_Given_VirtualFunction_WillThrow_exception() {

            Subject.Given().GuardFunction().WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_Given_VirtualMethod_WillThrow_exception() {

            Subject.Given().VirtualMethod(); Subject.WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_Given_Property_WillThrow_exception() {

            Subject.Given().GuardProperty.WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_Given_Property_is_set_to_value_WillThrow_exception() {

            Subject.Given().VirtualProperty = true;
            Subject.WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

    }
}