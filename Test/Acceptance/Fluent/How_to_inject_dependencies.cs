using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Fluent {

    [TestClass]
    public class How_to_inject_dependencies : BehaviorOf<Class> {
        
        [TestMethod]
        public void abstract_dependencies_are_auto_injected() {

            When.TestDependency();
            Should.AbstractDependency.Method();
        }

        [TestMethod]
        public void using_setter_only_with_abstract_dependency() {

            var Dependency = TestObjectFor<Dependency>();

            Given.SetAbstractDependency = Dependency;
            When.TestDependency();
            Dependency.Should().Method();
        }

        [TestMethod]
        public void passing_the_dependency_on_the_call() {

            var Dependency = TestObjectFor<Dependency>();

            When.TestDependency(Dependency);
            Dependency.Should().Method();
        }

        [TestMethod]
        public void using_property_with_concrete_dependency() {
            
            Given.ConcreteDependency = TestObjectFor<Class>();
            When.TestDependency();
            Should.ConcreteDependency.VirtualMethod();
        }

        [TestMethod]
        public void using_setter_only_with_concrete_dependency() {

            var ConcreteDependency = TestObjectFor<Class>();

            Given.SetConcreteDependency = ConcreteDependency;
            When.TestDependency();
            ConcreteDependency.Should().VirtualMethod();
        }
    }
}