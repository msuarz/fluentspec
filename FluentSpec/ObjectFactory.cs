using System.Reflection;
using FluentSpec.Classes;

namespace FluentSpec {

    internal class ObjectFactory {

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

        public static Call Call(MethodInfo MethodInfo, params object[] Args) { return 
            MethodInfo.IsProperty() ? 
                Property(MethodInfo, Args) : 
                Method(MethodInfo, Args)
        ;}

        public static Call Method(MethodInfo MethodInfo, params object[] Args) { return new Method {
            MethodInfo = MethodInfo,
            Name = MethodInfo.Name,
            Args = Args,
            Comparer = new ComparerClass()
        };}

        public static Call Property(MethodInfo MethodInfo, params object[] Args) { return new Property {
            MethodInfo = MethodInfo,
            Name = MethodInfo.Name,
            Args = Args,
            Comparer = new ComparerClass()
        };}

        public static Call CallFrom(Call AnotherCall) { return 
            Call(AnotherCall.MethodInfo, AnotherCall.Args)
        ;}
    }
}