using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec {

    public static class ShouldAssertions {
    
        public static void ShouldBeOfType(this object Obj, Type Type) {
            Assert.AreSame(Type, Obj.GetType());
        }
        
        public static void ShouldBe(this object Obj, object Another) {
            Assert.AreEqual(Obj, Another, Obj + " is not " + Another);
        }
        
        public static void ShouldNotBe(this object Obj, object Another) {
            Assert.AreNotEqual(Obj, Another, Obj + " is not " + Another);
        }
        
        public static void ShouldBeNull(this object Obj) {
            Assert.IsNull(Obj);
        }
        
        public static void ShouldNotBeNull(this object Obj) {
            Assert.IsNotNull(Obj);
        }
        
        public static void ShouldFail(this object Obj, Action Action) {
            var Failed = false;
            
            try { Action.Invoke(); }
            catch { Failed = true; }
            
            if (!Failed) throw new Exception("Should have failed");
        }
        
        public static void ShouldNotFail(this object Obj, Action Action) {
            try { Action.Invoke(); }
            catch { throw new Exception("Should not have failed"); }
        }
        
        public static void ShouldBeTrue(this bool Condition) {
            Assert.IsTrue(Condition);
        }
        
        public static void ShouldBeFalse(this bool Condition) {
            Assert.IsFalse(Condition);
        }
        
        public static void ShouldHaveFailed(this object Obj) {
            Assert.Fail("Should have failed");
        }
    }
}