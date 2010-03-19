using System;
using FluentSpec;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specs {

    [TestClass]
    public class when_verifying_expectations {
        
        [TestMethod]
        public void it_should_be_possible_to_compare_types() {

            "string".ShouldBeOfType(typeof (string));
            "string".ShouldNotBeOfType(typeof (int));
        }

        [TestMethod]
        public void it_should_be_possible_to_compare_values() {

            42.ShouldBe(42);
            "hello".ShouldNotBe("good bye");
        }

        [TestMethod]
        public void it_should_be_possible_to_check_null_values() {

            NullObject.ShouldBeNull();
            new object().ShouldNotBeNull();
        }

        object NullObject { get { return null; } }
        
        [TestMethod]
        public void it_should_be_possible_to_expect_failures() {
            
            this.ShouldFail(() => { throw new Exception(); });
            this.ShouldNotFail(() => {});
        }

        [TestMethod]
        public void it_should_be_possible_to_check_bools() {
            
            true.ShouldBeTrue();
            false.ShouldBeFalse();
            "true".ShouldBeTrue();
            "false".ShouldBeFalse();
            1.ShouldBeTrue();
            0.ShouldBeFalse();
        }
        
        [TestMethod]
        public void it_should_be_possible_to_induce_failure() {
            
            this.ShouldFail(() => this.ShouldHaveFailed());
        }
    }
}