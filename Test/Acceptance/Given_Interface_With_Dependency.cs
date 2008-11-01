using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance {

    /// <summary>
    /// This scenario points to a Demeter violation smell
    /// it is tested to prove it would work
    /// should not require extra framework code
    /// </summary>
    [TestClass]
    public class Given_Interface_With_Dependency : BehaviorOf<DependencyWithDependency> {
        
        [TestMethod]
        public void Actual_Dependency_is_null() {
            Assert.IsNull(Actual.Dependency);
        }

        [TestMethod]
        public void Given_Dependency_Actual_Dependency() {
            var ExpectedDependency = TestObjectFor<Dependency>();
            
            Given.Dependency.WillReturn(ExpectedDependency);
            Assert.AreSame(ExpectedDependency, Actual.Dependency);
        }
    }
}