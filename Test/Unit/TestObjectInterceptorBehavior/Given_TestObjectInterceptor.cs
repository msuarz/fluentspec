using Castle.Core.Interceptor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestObjectInterceptorBehavior {
    
    [TestClass]
    public class Given_TestObjectInterceptor : BehaviorOf<TestObjectInterceptorClass> {
        
        [TestMethod]
        public void When_Intercept_Should_Setup_Invocation() {
            var ExpectedInvocation = TestObjectFor<IInvocation>();        
            
            When.Intercept(ExpectedInvocation);
            Assert.AreSame(ExpectedInvocation, Actual.Invocation);
        }
        
        [TestMethod]
        public void When_ShouldReturn() {

            Given.Invocation.Method.WillReturn(Helper.Function);
            Assert.IsTrue(That.ShouldReturn);
        }
        
        [TestMethod]
        public void When_ShouldNotReturn() {

            Given.Invocation.Method.WillReturn(Helper.Method);
            Assert.IsFalse(That.ShouldReturn);
        }
        
        [TestMethod]
        public void When_ShouldInvokeTestClass() {
            
            Given.IsTestProcessorInvocation.WillReturn(true);
            Given.IsTestConnector.WillReturn(true);

            Assert.IsTrue(That.ShouldInvokeTestClass);
        }
        
        [TestMethod]
        public void When_ShouldNotInvokeTestClass() {
        
            Assert.IsFalse(That.ShouldInvokeTestClass);
        }
        
        [TestMethod]
        public void When_IsTestProcessorInvocation() {
            
            Given.Invocation.Method.WillReturn(Helper.TestProcessorMethod);
            Assert.IsTrue(That.IsTestProcessorInvocation);
        }
        
        [TestMethod]
        public void When_IsNotTestProcessorInvocation() {
        
            Given.Invocation.Method.WillReturn(Helper.Method);
            Assert.IsFalse(That.IsTestProcessorInvocation);
        }
        
        [TestMethod]
        public void When_IsTestConnector() {
            
            Given.Invocation.Method.WillReturn(Helper.TestProcessorConnectorMethod);
            Assert.IsTrue(That.IsTestConnector);
        }
        
        [TestMethod]
        public void When_IsNotTestConnector() {
        
            Given.Invocation.Method.WillReturn(Helper.Method);
            Assert.IsFalse(That.IsTestConnector);
        }

        readonly object ExpectedReturnValue = new object();
        
        [TestMethod]
        public void When_ProcessTestClassInvocation_Should_Setup_Invocation_ReturnValue() {
            
            Given.Invoke.WillReturn(ExpectedReturnValue);
            When.ProcessTestClassInvocation();
            Should.Invocation.ReturnValue = ExpectedReturnValue;
        }
        
        [TestMethod]
        public void When_ProcessTestClassInvocation_Should_Setup_Invocation_ReturnValue_With_Proxy() {

            Given.Invoke.Is(Expected.Processor);
            Given.Invocation.Proxy.WillReturn(ExpectedReturnValue);
            
            When.ProcessTestClassInvocation();
            Should.Invocation.ReturnValue = ExpectedReturnValue;
        }
    }
}