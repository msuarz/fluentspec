using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance {

    [TestClass]
    public class Given_ClassWithArgs : BehaviorOf<ClassWithArgs> {
        
        [TestMethod]
        public void When_MethodWithArgs_Should_VirtualMethodWithArgs() {
            When.MethodWithArgs();
            Should.VirtualMethodWithArgs();
        }
        
        [TestMethod]
        public void When_MethodWithArgs_Should_match_Args() {
            
            When.MethodWithArgs(1,2,3);
            Should.VirtualMethodWithArgs(1,2,3);
        }

        [TestMethod]
        public void When_Method_Should_match_Dependency_MethodWithArg() {
            var TestObjectArg = TestObjectFor<Dependency>();
            
            When.MethodWith(TestObjectArg);
            Should.Dependency.MethodWith(TestObjectArg);
        }

        [TestMethod]
        public void When_MethodWithArgs_ShouldNot_match_Args() {
        
            When.MethodWithArgs(1, 2, null);
            
            ShouldNot.VirtualMethodWithArgs(4, 5, 6);
            ShouldNot.VirtualMethodWithArgs(1, 2, 3);
            ShouldNot.VirtualMethodWithArgs();
            ShouldNot.VirtualMethodWithArgs(null);
            ShouldNot.VirtualMethodWithArgs("1", 2, null);
            ShouldNot.VirtualMethodWithArgs(1);
        }
        
        [TestMethod]
        public void When_MethodWithArgs_Should_IgnoreArgs() {

            When.MethodWithArgs(1, 2, 3);
            Should.IgnoringArgs().VirtualMethodWithArgs();
        }
        
        [TestMethod]
        public void When_Condition_Should_IgnoreArgs() {

            Given.AreValid().IgnoringArgs().WillReturn(true);
            Assert.IsTrue(When.Condition(1, 2, 3));
        }

    }
}