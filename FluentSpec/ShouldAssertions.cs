using System;
using System.Collections.Generic;
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
        
        public static void ShouldFail<T>(this object Obj, Func<T> Func) {
            var Failed = false;
            
            try { Func.Invoke(); }
            catch { Failed = true; }
            
            if (!Failed) throw new Exception("Should have failed");
        }
        
        public static void ShouldNotFail(this object Obj, Action Action) {
            try { Action.Invoke(); }
            catch { throw new Exception("Should not have failed"); }
        }
        
        public static void ShouldNotFail<T>(this object Obj, Func<T> Func) {
            try { Func.Invoke(); }
            catch { throw new Exception("Should not have failed"); }
        }
        
        public static void ShouldBeTrue(this bool Condition) {
            Assert.IsTrue(Condition);
        }
        
        public static void ShouldBeTrue<T>(this T Condition) {
            Assert.IsTrue(Convert.ToBoolean(Condition));
        }
        
        public static void ShouldBeFalse(this bool Condition) {
            Assert.IsFalse(Condition);
        }
        
        public static void ShouldHaveFailed(this object Obj) {
            Assert.Fail("Should have failed");
        }
        
        public static void ShouldBeEmpty<T>(this List<T> List) {
            Assert.IsTrue(List.Count == 0, "List have " + List.Count + " item(s)");
        }

        public static void ShouldContain<T>(this List<T> List, T Item) {
            Assert.IsTrue(List.Contains(Item), "List does not have " + Item);
        }
        
        public static void ShouldNotBeEmpty(this string String) {
            Assert.IsTrue(String.IsNullOrEmpty(String), "'" + String + "' is not empty");
        }
        
        public static void ShouldBeGreaterThan(this int Higher, int Lower) {
            Assert.IsTrue(Higher > Lower, Higher + " is < than " + Lower);
        }
    }
}