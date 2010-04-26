using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Specs {

    [TestClass]
    public class when_Automocking_dependencies : BehaviorOf<Automocking>{
        
        [TestMethod]
        public void should_Automock_internal_dependencies() {

            The.InternalDependency.ShouldNotBeNull();
        }

        [TestMethod]
        public void should_not_Automock_protected_or_private_dependencies() {

            The.ProtectedDependency().ShouldBeNull();
            The.PrivateDependency().ShouldBeNull();
        }
    }

    public class Automocking {

        public interface Dependency {}

        internal Dependency InternalDependency { get; set; }

        protected Dependency protectedDependency { get; set; }
        private Dependency privateDependency { get; set; }

        public Dependency ProtectedDependency() { return protectedDependency; }
        public Dependency PrivateDependency() { return privateDependency; }
    }
}