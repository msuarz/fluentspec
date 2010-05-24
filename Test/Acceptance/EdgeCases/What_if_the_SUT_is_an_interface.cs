using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.EdgeCases {

    /// <summary>
    /// the SUT must always be a concrete class
    /// but ... 
    /// </summary>
    [TestClass]
    public class What_if_the_SUT_is_an_interface : BehaviorOf<Dependency> {

        [TestMethod]
        public void a_call_could_be_verified() {

            When.Method();
            Should.Method();
        }

        [TestMethod]
        public void a_result_for_a_function_could_be_setup() {

            Given.Function().Is(true);
            Assert.IsTrue(That.Function());
        }

        [TestMethod]
        public void a_result_for_a_property_could_be_setup() {

            Given.Property = true;
            Assert.IsTrue(That.Property);
        }
    }
}