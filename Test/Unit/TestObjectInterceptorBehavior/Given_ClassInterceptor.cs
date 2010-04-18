using System;
using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestObjectInterceptorBehavior {

    [TestClass]
    public class Given_ClassInterceptor : BehaviorOf<ClassInterceptor> {
        
        [TestInitialize]
        public override void Setup() { base.Setup(); }
        
        [TestMethod]
        public void When_ShouldInvokeBase() {
            
            Given.Processor.ExpectSubjectAction.Is(true);
            And.WasExternalCall.Is(true);
            
            When.ShouldInvokeBase.ShouldBeTrue();
        }
        
        [TestMethod]
        public void ShouldNotInvokeBase_If_UnexpectedSubjectAction() {

            Given.Processor.ExpectSubjectAction.WillReturn(false);
            Assert.IsFalse(That.ShouldInvokeBase);
        }
        
        [TestMethod]
        public void ShouldNotInvokeBase_If_WasInternalCall() {

            Given.Processor.ExpectSubjectAction.WillReturn(true);
            Given.WasExternalCall.WillReturn(false);
            
            Assert.IsFalse(That.ShouldInvokeBase);
        }

        [TestMethod]
        public void ShouldNotInvokeBase_If_protected() {

            Given.IsProtectedCall.Is(true);
            
            When.ShouldInvokeBase.ShouldBeTrue();
        }
        
        readonly object InvocationTarget = new object();
        readonly Type SameType = typeof(object);
        readonly Type DifferentType = typeof(void);
        
        [TestMethod]
        public void When_WasExternalCall() {
            
            Given.Invocation.InvocationTarget.Is(InvocationTarget);
            And.Callers.Are(new[]{ DifferentType });
            
            When.WasExternalCall.ShouldBeTrue();
        }
        
        [TestMethod]
        public void When_WasInternalCall() {

            Given.Invocation.InvocationTarget.Is(InvocationTarget);
            And.Callers.Are(new[]{ SameType, SameType });

            When.WasExternalCall.ShouldBeFalse();
        }
    }
}