using System.Reflection;

namespace Specs.Helpers {

    public class Actors {

        public static MethodInfo VirtualGetter { get { return
            typeof(Class).GetMethod("get_VirtualProperty")
        ;}}

        public static MethodInfo VirtualSetter { get { return
            typeof(Class).GetMethod("set_VirtualProperty")
        ;}}
    }
}