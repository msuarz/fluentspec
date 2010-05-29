using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Specs {

    public class when_declaring_the_SUT {

        [TestClass]
        public class with_constructor_args : BehaviorOf<SUTWithConstructorArgs> {
            
            [TestMethod]
            public void should_allow_to_inject_args() {

                Subject = TestObjectFor<SUTWithConstructorArgs>(new object());

                The.Arg.ShouldNotBeNull();
            }
        }

        [TestClass]
        public class as_a_ConcreteClass : BehaviorOf<ConcreteClass> {
            
            [TestMethod]
            public void should_not_fail_on_connectors() {
                
//                Subject = new ConcreteClass();

                Given.Property = 42;
                When.PropertyTimes(2);
                Then.Property.ShouldBe(42 * 2);
            }
        }
    }

    public class SUTWithConstructorArgs {

        public object Arg { get; set; }

        public SUTWithConstructorArgs(object Arg) {
            this.Arg = Arg;
        }
    }

    public class ConcreteClass {
        public int Property { get; set; }
        public void PropertyTimes(int X) { Property *= X; }
    }
}