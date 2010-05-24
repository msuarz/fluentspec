using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Specs {

    [TestClass]
    public class when_declaring_the_SUT : BehaviorOf<SUTWithConstructorArgs> {
        
        [TestMethod]
        public void should_allow_to_use_constructor_args() {

            Subject = TestObjectFor<SUTWithConstructorArgs>(new object());

            The.Arg.ShouldNotBeNull();
        }
    }

    public class SUTWithConstructorArgs {

        public object Arg { get; set; }

        public SUTWithConstructorArgs(object Arg) {
            this.Arg = Arg;
        }
    }
}