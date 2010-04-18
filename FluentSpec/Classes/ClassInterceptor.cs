using System;
using System.Linq;
using System.Collections.Generic;
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
            IsProtectedCall ||
            (Processor.ExpectSubjectAction && WasExternalCall)
        ;}}

        public virtual bool IsProtectedCall { get { return Invocation.Method.IsFamily; }}

        public virtual bool WasExternalCall { get { return 
            ExternalCallers.Where(Caller => 
                Caller.IsInstanceOfType(Invocation.InvocationTarget))
                .Take(2).Count() != 2
        ;}}

        public virtual IEnumerable<Type> ExternalCallers { get {
            const int InternalCallsCount = 7;
            var Stack = new StackTrace();

            for (var i = InternalCallsCount; i < Stack.FrameCount; i++) 
                yield return Stack
                    .GetFrame(i)
                    .GetMethod()
                    .DeclaringType;
        }}
    }
}