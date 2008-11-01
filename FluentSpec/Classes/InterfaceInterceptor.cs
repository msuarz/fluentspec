using Castle.Core.Interceptor;

namespace FluentSpec.Classes {

    public class InterfaceInterceptor : TestObjectInterceptor {

        public override void Intercept(IInvocation Invocation) { 
            base.Intercept(Invocation);

            if (ShouldInvokeTestClass) ProcessTestClassInvocation();
            else InterceptInvocation(); 
        }
 
    }
}