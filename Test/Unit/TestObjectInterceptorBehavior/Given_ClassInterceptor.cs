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
            
            Given.Processor.ExpectSubjectAction.WillReturn(true);
            Given.WasExternalCall.WillReturn(true);
            
            Assert.IsTrue(That.ShouldInvokeBase);
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
            
            Given.Invocation.InvocationTarget.WillReturn(InvocationTarget);
            Given.ExternalCallers.WillReturn(new[]{ DifferentType });
            
            Assert.IsTrue(That.WasExternalCall);
        }
        
        [TestMethod]
        public void When_WasInternalCall() {

            Given.Invocation.InvocationTarget.WillReturn(InvocationTarget);
            Given.ExternalCallers.WillReturn(new[]{ SameType });

            Assert.IsFalse(That.WasExternalCall);
        }
    }
}