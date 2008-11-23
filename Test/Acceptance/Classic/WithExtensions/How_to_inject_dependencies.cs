using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Classic.WithExtensions {

    [TestClass]
    public class How_to_inject_dependencies {

        readonly Class Subject = Create.TestObjectFor<Class>();

        [TestMethod]
        public void using_constructor() {
            
            var Dependency = Create.TestObjectFor<Dependency>();
            var AnotherSubject = Create.TestObjectFor<Class>(Dependency);

            AnotherSubject.TestDependency();
            Dependency.Should().Method();
        }

        [TestMethod]
        public void abstract_dependencies_are_auto_injected() {

            Subject.TestDependency();
            Subject.Should().AbstractDependency.Method();
        }

        [TestMethod]
        public void using_setter_only_with_abstract_dependency() {

            var Dependency = Create.TestObjectFor<Dependency>();

            Subject.SetAbstractDependency = Dependency;
            Subject.TestDependency();
            Dependency.Should().Method();
        }

        [TestMethod]
        public void passing_the_dependency_on_the_call() {

            var Dependency = Create.TestObjectFor<Dependency>();

            Subject.TestDependency(Dependency);
            Dependency.Should().Method();
        }

        [TestMethod]
        public void using_property_with_concrete_dependency() {

            Subject.ConcreteDependency = Create.TestObjectFor<Class>();
            Subject.TestDependency();
            Subject.Should().ConcreteDependency.VirtualMethod();
        }

        [TestMethod]
        public void using_setter_only_with_concrete_dependency() {

            var ConcreteDependency = Create.TestObjectFor<Class>();

            Subject.SetConcreteDependency = ConcreteDependency;
            Subject.TestDependency();
            ConcreteDependency.Should().VirtualMethod();
        }
    }
}