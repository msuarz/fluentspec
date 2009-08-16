using System.Collections.Generic;
using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Fluent {

    [TestClass]
    public class How_to_use_Properties : BehaviorOf<Class> {
        
        [TestMethod]
        public void when_a_VirtualProperty_is_set_it_should_be_verifiable_with_an_assigment() {
            
            When.Method();
            Should.VirtualProperty = true;
        }
        
        [TestMethod]
        public void when_a_VirtualProperty_is_injected_it_should_be_verifiable_with_a_Should_expression() {
        
            Given.List = new List<string>();
            When.AddAnElement();
            Then.List.Count.ShouldBe(1);
        }

        [TestMethod]
        public void when_a_VirtualProperty_is_set_it_should_be_verifiable_with_a_Should_expression() {
            
            When.Method();
            Then.VirtualProperty.ShouldBe(true);
        }
    }
}