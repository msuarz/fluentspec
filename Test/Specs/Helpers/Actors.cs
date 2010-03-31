using System.Reflection;

namespace FluentSpec.Specs.Helpers {

    public class Actors {

        public static MethodInfo VirtualGetter { get { return
            typeof(Class).GetMethod("get_VirtualProperty")
        ;}}

        public static MethodInfo VirtualSetter { get { return
            typeof(Class).GetMethod("set_VirtualProperty")
        ;}}

        public static MethodInfo Method { get { return
            typeof(Class).GetMethod("Method")
        ;}}

        public static PropertyInfo Property { get { return
            typeof(Class).GetProperty("VirtualProperty")
        ;}}
    }
}