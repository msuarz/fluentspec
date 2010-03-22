using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec {

    public static class ShouldAssertions {
      
        public static void ShouldBeA<T>(this Object Obj) {
            
            (Obj is T).ShouldBeTrue(
                Obj.GetType().Name.Quoted() + " is not of type " + typeof(T).Name.Quoted());            
        }
        
        public static void ShouldNotBeA<T>(this Object Obj) {
            
            (Obj is T).ShouldBeFalse(
                "Unexpected type of " + typeof(T).Name.Quoted());
        }

        public static void ShouldBe(this object Actual, object Expected) {
            Assert.AreEqual(Expected, Actual);
        }
        
        public static void ShouldBe(this object Actual, object Expected, string Message) {
            Assert.AreEqual(Expected, Actual, Message);
        }
        
        public static void ShouldBe<T>(this List<T> Ones, List<T> Others) {
            
            Ones.Count.ShouldBe(Others.Count);
            
            for (var i = 0; i < Ones.Count; i++)
                Ones[i].ShouldBe(Others[i]);
        }

        public static void ShouldNotBe(this object Actual, object NotExpected) {
            Assert.AreNotEqual(NotExpected, Actual);
        }
        
        public static void ShouldNotBe(this object Actual, object NotExpected, string Message) {
            Assert.AreNotEqual(NotExpected, Actual, Message);
        }
        
        public static void ShouldNotBe<T>(this List<T> Ones, List<T> Others) {
                            
            if (Ones.Count != Others.Count) return;
            
            for (var i = 0; i < Ones.Count; i++)
                if (!Ones[i].Equals(Others[i])) return;
            
            Ones.ShouldHaveFailed("Unexpected lists with same elements");
        }

        public static void ShouldBeNull(this object Actual) {
            Actual.ShouldBe(null);
        }
        
        public static void ShouldNotBeNull(this object Actual) {
            Actual.ShouldNotBe(null);
        }
        
        public static void ShouldFail(this object Obj, Action Action) {
            var Failed = false;
            
            try { Action(); }
            catch { Failed = true; }
            
            if (!Failed) throw new Exception("Should have failed");
        }
        
        public static void ShouldFail<T>(this object Obj, Func<T> Func) {
            var Failed = false;
            
            try { Func(); }
            catch { Failed = true; }
            
            if (!Failed) throw new Exception("Should have failed");
        }
        
        public static void ShouldNotFail(this object Obj, Action Action) {
            try { Action(); }
            catch { throw new Exception("Should not have failed"); }
        }
        
        public static void ShouldNotFail<T>(this object Obj, Func<T> Func) {
            try { Func(); }
            catch { throw new Exception("Should not have failed"); }
        }
        
        public static void ShouldBeTrue(this bool Condition) {
            Assert.IsTrue(Condition);
        }
        
        public static void ShouldBeTrue(this bool Condition, string Message) {
            Assert.IsTrue(Condition, Message);
        }
        
        public static void ShouldBeTrue<T>(this T Condition) {
            Convert.ToBoolean(Condition).ShouldBeTrue();
        }
        
        public static void ShouldBeFalse(this bool Condition) {
            Assert.IsFalse(Condition);
        }
        
        public static void ShouldBeFalse(this bool Condition, string Message) {
            Assert.IsFalse(Condition, Message);
        }
        
        public static void ShouldBeFalse<T>(this T Condition) {
            Convert.ToBoolean(Condition).ShouldBeFalse();
        }
        
        public static void ShouldHaveFailed(this object Obj) {
            Assert.Fail("Should have failed");
        }
        
        public static void ShouldHaveFailed(this object Obj, string Message) {
            Assert.Fail(Message);
        }
        
        public static void ShouldBeEmpty<T>(this List<T> List) {
            List.Count.ShouldBe(0, "List contains " + List.Count + " item(s)");
        }

        public static void ShouldNotBeEmpty<T>(this List<T> List) {
            (List.Count > 0).ShouldBeTrue("Unexpected empty List");
        }

        public static void ShouldBeEmpty(this string String) {
            String.IsNullOrEmpty(String).ShouldBeTrue("'" + String + "' is not empty");
        }
        
        public static void ShouldNotBeEmpty(this string String) {
            String.IsNullOrEmpty(String).ShouldBeFalse("Unexpected empty string");
        }
        
        public static void ShouldContain(this string Whole, string Part) {
            
            Whole.Contains(Part).ShouldBeTrue(
                Whole.Quoted() + " does not contain " + Part.Quoted());
        }
        
        public static void ShouldNotContain(this string Whole, string Part) {
            
            Whole.Contains(Part).ShouldBeFalse(
                Whole.Quoted() + " should not contain " + Part.Quoted());
        }
        
        public static void ShouldContain<T>(this List<T> List, T Item) {

            List.Contains(Item).ShouldBeTrue("List does not contain " + Item);
        }
        
        public static void ShouldNotContain<T>(this List<T> List, T Item) {

            List.Contains(Item).ShouldBeFalse("List should not contain " + Item);
        }
        
        public static void ShouldContain<T>(this List<T> Items, List<T> SomeItems) {
            
            SomeItems.ForEach(Items.ShouldContain);
        }

        public static void ShouldNotContain<T>(this List<T> Items, List<T> SomeItems) {
            
            SomeItems.ForEach(Items.ShouldNotContain);
        }

        public static void ShouldStartWith(this string Whole, string Prefix) {
            Whole.StartsWith(Prefix).ShouldBeTrue(
               Whole.Quoted() + " does not start with " + Prefix.Quoted());
        }

        public static void ShouldEndWith(this string Whole, string Suffix) {
            Whole.EndsWith(Suffix).ShouldBeTrue(
               Whole.Quoted() + " does not end with " + Suffix.Quoted());
        }

        public static void ShouldBeGreaterThan(this int Bigger, int Smaller) {
            
            (Bigger.CompareTo(Smaller) > 0).ShouldBeTrue(
                Bigger + " is not greater than " + Smaller);            
        }

        public static void ShouldBeLessThan(this IComparable Smaller, IComparable Bigger) {
            
            (Smaller.CompareTo(Bigger) < 0).ShouldBeTrue(
                Smaller + " is not less than " + Bigger);            
        }
    }
}