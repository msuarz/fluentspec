using System.Reflection;
using FluentSpec.Classes;

namespace FluentSpec {

    public class ObjectFactory {

        public static TestProcessor TestProcessor { get { return new TestProcessorClass(); } }

        public static Log Log { get { return new LogClass(); } }

        public static Call Call(MethodInfo Method, params object[] Args) { return 
            new CallClass(Method, Args) { Comparer = new ComparerClass() }
        ;}

        public static TestObjectInterceptor ClassInterceptor(TestProcessor Processor) { return new ClassInterceptor {
            Processor = Processor,
            Log = Log
        };} 

        public static TestObjectInterceptor InterfaceInterceptor(TestProcessor Processor) { return new InterfaceInterceptor {
            Processor = Processor,
            Log = Log
        };} 

    }
}