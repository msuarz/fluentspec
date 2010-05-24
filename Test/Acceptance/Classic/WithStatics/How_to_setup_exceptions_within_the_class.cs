using System;
using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentSpec.Test.Unit;

namespace FluentSpec.Test.Acceptance.Classic.WithStatics {

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
        public void use_GivenThat_VirtualFunction_WillThrow_exception() {

            Given.That(Subject).GuardFunction().WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_GivenThat_VirtualMethod_WillThrow_exception() {

            Given.That(Subject).VirtualMethod(); Subject.WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_GivenThat_Property_WillThrow_exception() {

            Given.That(Subject).GuardProperty.WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

        [TestMethod]
        public void use_GivenThat_Property_is_set_to_value_WillThrow_exception() {

            Given.That(Subject).VirtualProperty = true;
            Subject.WillThrow(ExpectedException);

            the_expected_exception_should_be_thrown_in_a_method();
        }

    }
}