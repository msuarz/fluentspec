using System;
using FluentSpec;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specs {

    [TestClass]
    public class when_intercepting_SUT_calls : BehaviorOf<ProtectedMethodCalls>{

        [TestMethod]
        public void should_not_intercept_protected_methods() {

            this.ShouldFail(When.ThrowExceptionInProtectedMethod);
        }
    }
    
    public class ProtectedMethodCallsBase {
        
        protected virtual void BaseMethod() { throw new Exception(); }
    }
    
    public class ProtectedMethodCalls : ProtectedMethodCallsBase {

        public void ThrowExceptionInProtectedMethod() {
            Method();
            BaseMethod();
        }
        
        protected virtual void Method() { throw new Exception(); }
    }
    
}