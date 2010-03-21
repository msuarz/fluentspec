using System;
using System.Collections.Generic;
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
        public void it_should_be_possible_to_check_facts() {
            
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

        [TestMethod]
        public void it_should_be_possible_to_detect_emptiness() {
            
            "".ShouldBeEmpty();
            "42".ShouldNotBeEmpty();

            new List<int>().ShouldBeEmpty();
            new List<int>{42}.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void it_should_be_possible_to_search() {
            
            "142".ShouldContain("42");
            "42".ShouldNotContain("0");

            var List = new List<int>{0, 42, 84};
            
            List.ShouldContain(42);
            List.ShouldContain(new List<int>{42, 0});
            List.ShouldNotContain(1);
            List.ShouldNotContain(new List<int>{1, 2});
        }
        
        [TestMethod]
        public void it_should_be_possible_to_check_prefix_and_suffix() {
            
            "Hello Goodbye".ShouldStartWith("Hello");
            "Hello Goodbye".ShouldEndWith("Goodbye");
        }

        [TestMethod]
        public void it_should_be_possible_to_compare() {
            
            2.ShouldBeGreaterThan(1);
            1.ShouldBeLessThan(2);
        }
    }
}