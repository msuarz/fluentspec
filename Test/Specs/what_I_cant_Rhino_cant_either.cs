using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace FluentSpec.Specs {

    [TestClass]
    public class what_I_cant_Rhino_cant_either : BehaviorOf<NoCantDo>{
        
        [TestMethod]
        public void cant_Automock_internal_dependencies() {

            The.InternalDependency.ShouldBeNull();
        }

        [TestMethod]
        public void cant_mock_internal_dependencies() {

            this.ShouldFail(() => TestObjectFor<InternalInterface>());
        }

        [TestMethod]
        public void Rhino_cant_mock_internal_dependencies() {

            this.ShouldFail(() => MockRepository.GenerateMock<InternalInterface>());
        }
    }

    public class NoCantDo {

        internal InternalInterface InternalDependency { get; set; }
    }

    internal interface InternalInterface {}
}