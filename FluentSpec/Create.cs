using FluentSpec.Classes;

namespace FluentSpec {

    public static class Create {
        
        public static T TestObjectFor<T>(params object[] Args) { return new
            TestObjectFactory().TestObjectFor<T>(Args)
        ;}
    }
}