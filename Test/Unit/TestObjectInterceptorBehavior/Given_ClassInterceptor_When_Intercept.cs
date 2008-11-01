using Castle.Core.Interceptor;
using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestObjectInterceptorBehavior {
    
    [TestClass]
    public class Given_ClassInterceptor_When_Intercept :
        BehaviorOf<ClassInterceptor> {

        readonly IInvocation ExpectedInvocation = TestObjectFor<IInvocation>();

        [TestMethod]
        public void Should_Setup_Invocation() {

            When.Intercept(ExpectedInvocation);
            Assert.AreSame(ExpectedInvocation, Actual.Invocation);
        }

        [TestMethod]
        public void Should_InterceptInvocation() {

            When.Intercept(ExpectedInvocation);
            Should.InterceptInvocation();
        }

        [TestMethod]
        public void Should_ProcessTestClassInvocation_If_ShouldInvokeTestClass() {

            Given.ShouldInvokeTestClass.WillReturn(true);
            When.Intercept(ExpectedInvocation);
            Should.ProcessTestClassInvocation();
        }
        
        [TestMethod]
        public void Should_Proceed_If_ShouldInvokeBase() {

            Given.ShouldInvokeBase.WillReturn(true);
            When.Intercept(ExpectedInvocation);
            ExpectedInvocation.Should().Proceed();
        }
    }
}