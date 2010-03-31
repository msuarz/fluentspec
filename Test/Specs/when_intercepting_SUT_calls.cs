using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Specs {

    [TestClass]
    public class when_intercepting_SUT_calls : BehaviorOf<InterceptingMethodCalls>{

        [TestMethod]
        public void should_not_intercept_protected_methods() {

            this.ShouldFail(When.ThrowExceptionInProtectedMethod);
        }
        
        [TestMethod]
        public void should_intercept_internal_methods() {

            this.ShouldNotFail(When.AttemptToThrowExceptionFromInternalMethod);
        }
        
        [TestMethod]
        public void should_intercept_calls_from_extension_methods() {
            
            When.UsesExtensions();
            Should.CallMethodFromExtension();
        }
    }

    #region context

    public class InterceptingMethodCallsBase {

        protected virtual void BaseMethod() { throw new Exception(); }
    }

    public class InterceptingMethodCalls : InterceptingMethodCallsBase {

        public void ThrowExceptionInProtectedMethod() {
            Method();
            BaseMethod();
        }

        protected virtual void Method() { throw new Exception(); }

        public void UsesExtensions() { this.ExtensionMethod(); }

        public virtual void CallMethodFromExtension() { throw new Exception(); }

        public void AttemptToThrowExceptionFromInternalMethod() {
            ThrowExceptionFromInternalMethod();
        }

        virtual internal protected void ThrowExceptionFromInternalMethod() { throw new Exception(); }
    }

    public static class InterceptingMethodCallsExtensions {

        public static void ExtensionMethod(this InterceptingMethodCalls Class) {
            Class.CallMethodFromExtension();
        }
    }

    #endregion
}