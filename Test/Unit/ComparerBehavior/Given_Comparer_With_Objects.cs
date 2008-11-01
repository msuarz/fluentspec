using System.Collections.ObjectModel;
using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.ComparerBehavior {

    [TestClass]
    public class Given_Comparer_With_Objects : BehaviorOf<ComparerClass> {

        [TestMethod]
        public void When_AreEqual_SameObjects() {
            var Object = new object();

            Assert.IsTrue(That.AreEqual(Object, Object));
        }

        [TestMethod]
        public void When_AreEqual_Collections() {
            object Collection = new Collection<object>();
            object AnotherCollection = new Collection<object>();

            Assert.IsTrue(That.AreEqual(Collection, AnotherCollection));
        }
        
        [TestMethod]
        public void When_AreEqual_Objects() {
            var One = ObjectFactory.Call(Helper.Method, null);
            var Another = ObjectFactory.Call(Helper.Method, null);

            Assert.IsTrue(That.AreEqual(One, Another));
        }

        [TestMethod]
        public void When_AreNotEqual() {

            Assert.IsFalse(That.AreEqual(null, 1));
            Assert.IsFalse(That.AreEqual(1, null));
            Assert.IsFalse(That.AreEqual(1, true));
        }
    }
}