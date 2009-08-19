using System.Reflection;

namespace FluentSpec.Classes {

    public static class MethodInfoExtensions {
        
        public static bool IsProperty(this MethodInfo MethodInfo) { return 
            MethodInfo.IsSetter()
            || MethodInfo.IsGetter()
        ;}
        
        public static bool IsSetter(this MethodInfo MethodInfo) { return 
            MethodInfo.IsSpecialName
            && MethodInfo.Name.StartsWith("set_")
        ;}

        public static bool IsGetter(this MethodInfo MethodInfo) { return 
            MethodInfo.IsSpecialName
            && MethodInfo.Name.StartsWith("get_")
        ;}
    }
}