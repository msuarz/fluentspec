using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec {

    public static class BehaviorAssertions {
    
        public static void ShouldBeTrue(this bool Condition) {
            
            Assert.IsTrue(Condition);
        }
        
        public static void ShouldBe(this object One, object Another) {
            
            Assert.AreEqual(Another, One, One + " is not " + Another);
        }
        
    }
}