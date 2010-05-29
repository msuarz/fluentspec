using System.Collections.Generic;
using Castle.Core.Interceptor;

namespace FluentSpec {

    public abstract class TestObjectInterceptor : IInterceptor {

        public TestProcessor Processor { get; set; }
        public Log Log { get; set; }
        public IInvocation Invocation { get; set; }

        public virtual void Intercept(IInvocation Invocation) {
            this.Invocation = Invocation;
        }

        public void InterceptInvocation() {
            Processor.Process(Log, Call);
            if (ShouldReturn) Invocation.ReturnValue = Processor.Result;
        }
        
        public virtual Call Call { get { return 
            ObjectFactory.Call(Invocation.Method, Invocation.Arguments)
        ;}}

        public virtual bool ShouldReturn { get { return 
            Invocation.Method.ReturnType != typeof(void)
        ;}}

        public virtual bool ShouldInvokeTestClass { get { return
            IsTestProcessorInvocation && IsTestConnector
        ;}}
        
        public virtual bool IsTestProcessorInvocation { get { return
            Invocation.Method.DeclaringType.Equals(typeof(TestProcessor))    
        ;}}

        static readonly List<string> TestConnectors = new List<string> {
            "get_Given", "get_When", "get_Should", "get_ShouldNot", "IgnoreArgs"
        };

        public virtual bool IsTestConnector { get { return 
            TestConnectors.Contains(Invocation.Method.Name)
        ;}}

        public void ProcessTestClassInvocation() {
            Invocation.ReturnValue = Invoke;
            if (Invocation.ReturnValue == Processor)  
                Invocation.ReturnValue = Invocation.Proxy;
        }
        
        public virtual object Invoke { get { return
            Invocation.Method.Invoke(Processor, Invocation.Arguments)
        ;}}
    }
}