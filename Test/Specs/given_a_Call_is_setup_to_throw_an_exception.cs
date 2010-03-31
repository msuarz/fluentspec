using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentSpec.Classes;
using System;

namespace FluentSpec.Specs {

    public class given_a_Call_is_setup_to_throw_an_exception : BehaviorOf<Method> {

        readonly static Exception ExpectedException = new Exception();
        
        [TestClass]
        public class when_throwing_from_a_Method : BehaviorOf<Method> {
        
            [TestMethod]
            public void it_should_be_set_to_throw_an_exception() {

                When.WillThrow(ExpectedException);
                Then.ShouldThrowException.ShouldBeTrue();
            }

            [TestMethod]
            public void it_should_store_the_exception_on_the_Result() {

                When.WillThrow(ExpectedException);
                Then.Result.ShouldBe(ExpectedException);
            }
        }
        
        [TestClass]
        public class when_throwing_from_a_Property : BehaviorOf<Property> {
        
            [TestMethod]
            public void should_switch_to_setter_if_was_setter() {

                Given.WasSetter.WillReturn(true);
                When.WillThrow(ExpectedException);
                Then.Should().SwitchToSetter();           
            }
        }
    }
}