using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Classic.WithStatics {

    [TestClass]
    public class How_to_use_args {

        readonly Class Subject = Create.TestObjectFor<Class>();

        [TestMethod]
        public void setup_result_for_call_with_args() {

            Given.That(Subject).ValidationForArgs(1, 2, 3).Is(true);
            Assert.IsTrue(Subject.AreValid(1, 2, 3));
        }

        [TestMethod]
        public void setup_result_with_wrong_args_should_fail() {

            Given.That(Subject).ValidationForArgs(1, 2, 3).Is(true);
            Assert.IsFalse(Subject.AreValid(4, 5, 6));
        }

        [TestMethod]
        public void setup_result_for_call_ignoring_args() {

            Given.That(Subject).ValidationForArgs().IgnoringArgs().Is(true);
            Assert.IsTrue(Subject.AreValid(1, 2, 3));
        }

        [TestMethod]
        public void verify_call_to_method_with_args() {

            Subject.MethodWithArgs(1, 2, 3);
            Then.Should(Subject).ForwardToMethodWithArgs(1, 2, 3);
        }

        [TestMethod]
        public void verify_call_to_dependency_method_with_args() {
            var ObjectArg = new object();

            Subject.MethodWithArgs(ObjectArg);
            Then.Should(Subject).Dependency.MethodWithArgs(ObjectArg);
        }

        [TestMethod]
        public void verify_call_ignoring_args() {

            Subject.MethodWithArgs(1, 2, 3);
            Then.Should(Subject).IgnoringArgs().ForwardToMethodWithArgs();
        }

        [TestMethod]
        public void verify_did_not_call_with_wrong_args() {

            Subject.MethodWithArgs(1, 2, null);
            Then.Should(Subject).ForwardToMethodWithArgs(1, 2, null);

            Then.ShouldNot(Subject).ForwardToMethodWithArgs(4, 5, 6);
            Then.ShouldNot(Subject).ForwardToMethodWithArgs(1, 2, 3);
            Then.ShouldNot(Subject).ForwardToMethodWithArgs();
            Then.ShouldNot(Subject).ForwardToMethodWithArgs(null);
            Then.ShouldNot(Subject).ForwardToMethodWithArgs("1", 2, null);
            Then.ShouldNot(Subject).ForwardToMethodWithArgs(1);
        }
    }
}