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
    }
}