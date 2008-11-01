using System.Reflection;
using FluentSpec.Classes;

namespace FluentSpec.Test.Unit {

    public class Helper {
        
        public static string ShouldHaveThrownException =
            "Should have thrown exception ...";
        
        public object FunctionSample() { return null; }
        
        public static MethodInfo Function { get { return 
            typeof(Helper).GetMethod("FunctionSample")
        ;}}
        
        public void MethodSample() {}
        
        public static MethodInfo Method { get { return 
            typeof(Helper).GetMethod("MethodSample")
        ;}}
        
        public static MethodInfo TestProcessorMethod { get { return 
            typeof(TestProcessor).GetMethod("Process")
        ;}}
        
        public static MethodInfo TestProcessorConnectorMethod { get { return 
            typeof(TestProcessor).GetMethod("get_When")
        ;}}
        
        public IInterface AutoProperty { get; set; }
        
        public static PropertyInfo TesteableProperty { get { return
            typeof(Helper).GetProperty("AutoProperty")
        ;}}

        public IInterface ReadOnlyProperty { get { return null; } }
        
        public static PropertyInfo NonTesteableProperty { get { return
            typeof(Helper).GetProperty("ReadOnlyProperty")
        ;}}

        public static bool WillDoWhenExecute(object TestProcessor, string Method) { return
            ((TestProcessorClass) TestProcessor).Execute.Method.Name.Equals(Method)
        ;}

        public static bool WillExpectSubjectActionOn(object TestProcessor) { return
            ((TestProcessorClass)TestProcessor).ExpectSubjectAction
        ;}
    }
}