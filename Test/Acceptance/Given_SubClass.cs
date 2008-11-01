using FluentSpec.Test.Acceptance.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Acceptance {

    [TestClass]
    public class Given_SubClass : BehaviorOf<SubClass> {
        
        [TestMethod]
        public void When_Method_Should_VirtualMethod() {
            When.Method();
            Should.VirtualMethod();
        }
    }
}