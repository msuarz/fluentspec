using FluentSpec;
using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acceptance.Silverlight.Fluent {

    [TestClass]
    public class How_to_use_args : BehaviorOf<Class> {

        [TestInitialize]
        public override void Setup() { base.Setup(); }
        
        [TestMethod]
        public void setup_result_for_call_with_args() {

            Given.ValidationForArgs(1, 2, 3).Is(true);
            Assert.IsTrue(That.AreValid(1, 2, 3));
        }

        [TestMethod]
        public void setup_result_with_wrong_args_should_fail() {

            Given.ValidationForArgs(1, 2, 3).Is(true);
            Assert.IsFalse(That.AreValid(4, 5, 6));
        }

        [TestMethod]
        public void setup_result_for_call_ignoring_args() {

            Given.ValidationForArgs().IgnoringArgs().Is(true);
            Assert.IsTrue(That.AreValid(1, 2, 3));
        }

        [TestMethod]
        public void verify_call_to_method_with_args() {

            When.MethodWithArgs(1, 2, 3);
            Should.ForwardToMethodWithArgs(1, 2, 3);
        }

        [TestMethod]
        public void verify_call_to_dependency_method_with_args() {
            var ObjectArg = new object();

            When.MethodWithArgs(ObjectArg);
            Should.Dependency.MethodWithArgs(ObjectArg);
        }

        [TestMethod]
        public void verify_call_ignoring_args() {

            When.MethodWithArgs(1, 2, 3);
            Should.IgnoringArgs().ForwardToMethodWithArgs();
        }

        [TestMethod]
        public void verify_did_not_call_with_wrong_args() {

            When.MethodWithArgs(1, 2, null);
            Should.ForwardToMethodWithArgs(1, 2, null);

            ShouldNot.ForwardToMethodWithArgs(4, 5, 6);
            ShouldNot.ForwardToMethodWithArgs(1, 2, 3);
            ShouldNot.ForwardToMethodWithArgs();
            ShouldNot.ForwardToMethodWithArgs(null);
            ShouldNot.ForwardToMethodWithArgs("1", 2, null);
            ShouldNot.ForwardToMethodWithArgs(1);
        }
    }
}