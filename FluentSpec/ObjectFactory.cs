using System.Reflection;
using FluentSpec.Classes;

namespace FluentSpec {

    public class ObjectFactory {

        public static TestProcessor TestProcessor { get { return new TestProcessorClass(); } }

        public static Log Log { get { return new LogClass(); } }

        public static TestObjectInterceptor ClassInterceptor(TestProcessor Processor) { return new ClassInterceptor {
            Processor = Processor,
            Log = Log
        };} 

        public static TestObjectInterceptor InterfaceInterceptor(TestProcessor Processor) { return new InterfaceInterceptor {
            Processor = Processor,
            Log = Log
        };}

        public static Call Call(MethodInfo MethodInfo, params object[] Args) { return new CallClass {
            MethodInfo = MethodInfo,
            Method = MethodInfo.Name,
            Args = Args,
            Comparer = new ComparerClass()
        };}

        public static Call CallFrom(Call AnotherCall) { return 
            Call(AnotherCall.MethodInfo, AnotherCall.Args)
        ;}
    }
}