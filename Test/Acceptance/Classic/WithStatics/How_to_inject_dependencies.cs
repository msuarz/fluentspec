using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.Classic.WithStatics {

    [TestClass]
    public class How_to_inject_dependencies {

        readonly Class Subject = Create.TestObjectFor<Class>();

        [TestMethod]
        public void using_constructor() {

            var Dependency = Create.TestObjectFor<Dependency>();
            var AnotherSubject = Create.TestObjectFor<Class>(Dependency);

            AnotherSubject.TestDependency();
            Then.Should(Dependency).Method();
        }

        [TestMethod]
        public void abstract_dependencies_are_auto_injected() {

            Subject.TestDependency();
            Then.Should(Subject).AbstractDependency.Method();
        }

        [TestMethod]
        public void using_setter_only_with_abstract_dependency() {

            var Dependency = Create.TestObjectFor<Dependency>();

            Subject.SetAbstractDependency = Dependency;
            Subject.TestDependency();
            Then.Should(Dependency).Method();
        }

        [TestMethod]
        public void passing_the_dependency_on_the_call() {

            var Dependency = Create.TestObjectFor<Dependency>();

            Subject.TestDependency(Dependency);
            Then.Should(Dependency).Method();
        }

        [TestMethod]
        public void using_property_with_concrete_dependency() {

            Subject.ConcreteDependency = Create.TestObjectFor<Class>();
            Subject.TestDependency();
            Then.Should(Subject).ConcreteDependency.VirtualMethod();
        }

        [TestMethod]
        public void using_setter_only_with_concrete_dependency() {

            var ConcreteDependency = Create.TestObjectFor<Class>();

            Subject.SetConcreteDependency = ConcreteDependency;
            Subject.TestDependency();
            Then.Should(ConcreteDependency).VirtualMethod();
        }
    }
}