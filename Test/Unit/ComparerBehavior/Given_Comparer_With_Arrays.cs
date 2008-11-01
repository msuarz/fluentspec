using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.ComparerBehavior {

    [TestClass]
    public class Given_Comparer_With_Arrays : BehaviorOf<ComparerClass> {
        
        [TestMethod]
        public void When_AreEqual() {
            var Array = new object[0];

            Assert.IsTrue(That.AreEqual(Array, Array));
            Assert.IsTrue(That.AreEqual(new object[] {1}, new object[] {1}));
        }
        
        [TestMethod]
        public void When_AreNotEqual() {

            Assert.IsFalse(That.AreEqual(null, new object[] {1}));
            Assert.IsFalse(That.AreEqual(new object[] {1}, null));
            Assert.IsFalse(That.AreEqual(new object[] {1}, new object[] {2}));
            Assert.IsFalse(That.AreEqual(new object[] {1}, new object[] {1,2}));
        }
    }
}