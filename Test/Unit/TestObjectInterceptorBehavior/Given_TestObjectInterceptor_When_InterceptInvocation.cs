using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Test.Unit.TestObjectInterceptorBehavior {

    [TestClass]
    public class Given_TestObjectInterceptor_When_InterceptInvocation :
        BehaviorOf<TestObjectInterceptor>{
        
        [TestMethod]
        public void Should_Process_Invocation_Method_With_Processor() {
            var Call = TestObjectFor<Call>();
            
            Given.Call.WillReturn(Call);
            When.InterceptInvocation();
            Should.Processor.Process(Actual.Log, Call);
        }
        
        [TestMethod]
        public void If_ShouldReturn_Should_Setup_InvocationReturnValue_With_Processor_Result() {
            var ExpectedProcessorResult = new object();
            
            Given.ShouldReturn.WillReturn(true);            
            Given.Processor.Result.WillReturn(ExpectedProcessorResult);
            
            When.InterceptInvocation();

            Should.Invocation.ReturnValue = ExpectedProcessorResult; 
        }
    }
}