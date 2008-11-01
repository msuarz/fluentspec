using System;
using System.Diagnostics;
using Castle.Core.Interceptor;

namespace FluentSpec.Classes {

    public class ClassInterceptor : TestObjectInterceptor {

        public override void Intercept(IInvocation Invocation) { 
            base.Intercept(Invocation);

            if (ShouldInvokeTestClass) ProcessTestClassInvocation();
            else if (ShouldInvokeBase) Invocation.Proceed();
            else InterceptInvocation(); 
        }

        public virtual bool ShouldInvokeBase { get { return
            Processor.ExpectSubjectAction && WasExternalCall
        ;}}

        public virtual  bool WasExternalCall { get { return 
            !ExternalCaller.IsInstanceOfType(Invocation.InvocationTarget)
        ;}}

        public virtual Type ExternalCaller { get {
            var Stack = new StackTrace();
            var Frame = Stack.GetFrame(6);
            var Method = Frame.GetMethod();
            return Method.DeclaringType;
        }}

    }
}