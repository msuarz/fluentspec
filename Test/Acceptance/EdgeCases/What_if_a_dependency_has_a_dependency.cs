using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance.EdgeCases {

    /// <summary>
    /// This scenario points to a Demeter violation smell
    /// therefore, it did not require extra framework code
    /// </summary>
    [TestClass]
    public class What_if_a_dependency_has_a_dependency : BehaviorOf<Class> { 
        
        [TestMethod]
        public void the_dependency_would_not_be_set_automatically() {

            Assert.IsNull(Actual.Dependency.Dependency);
        }

        [TestMethod]
        public void the_dependency_would_work_if_it_is_explicitly_set() {
            var ExpectedDependency = TestObjectFor<Dependency>();

            Given.Dependency.Dependency.Is(ExpectedDependency);
            Assert.AreSame(ExpectedDependency, Actual.Dependency.Dependency);
        }
    }
}