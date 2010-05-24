using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Specs {

    [TestClass]
    public class when_Dependencies_are_instantiated_by_the_constructor : BehaviorOf<SelfInjector> {
        
        [TestMethod]
        public void should_not_automock_the_property() {
            
            The.SelfInjectedDependency.ShouldBeA<SelfInjector.ConcreteDependency>();
        }

        [TestMethod]
        public void should_allow_to_inject_a_TestObject() {

            Given.SelfInjectedDependency = TestObjectFor<SelfInjector.Dependency>();
            The.SelfInjectedDependency.ShouldNotBeA<SelfInjector.ConcreteDependency>();
        }

        [TestMethod]
        public void should_allow_to_verify_call_on_injected_TestObject() {
            
            Given.SelfInjectedDependency = TestObjectFor<SelfInjector.Dependency>();
            When.DelegateMethod();
            Then.SelfInjectedDependency.Should().Method();
        }
    }

    public class SelfInjector {
        
        public interface Dependency {
            void Method();
        }

        public class ConcreteDependency : Dependency {
            public void Method() { throw new NotImplementedException(); }
        }

        public Dependency SelfInjectedDependency { get; set; }

        public SelfInjector() { SelfInjectedDependency = new ConcreteDependency(); }

        public void DelegateMethod() { SelfInjectedDependency.Method(); }
    }
}
