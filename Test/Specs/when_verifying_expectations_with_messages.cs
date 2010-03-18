using System;
using FluentSpec;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specs {

    [TestClass]
    public class when_verifying_expectations_with_messages {
    
        [TestMethod]
        public void it_should_be_possible_to_check_bools() {
        
            ShouldFailWithMessage(
                () => false.ShouldBeTrue("contradiction"), 
                "contradiction"
            );
        }
        
        [TestMethod]
        public void it_should_be_possible_to_induce_failure() {

            ShouldFailWithMessage(
                () => this.ShouldHaveFailed("with a message"),
                "with a message"
            );
        }

        void ShouldFailWithMessage(Action Action, string Message) {
            try { Action(); } 
            catch (Exception Exception) { Exception.Message.ShouldEndWith(Message); }
        }
    }
}