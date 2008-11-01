namespace FluentSpec.Test.Acceptance.Classes {

    public interface Dependency {
        void Method();
        bool ConditionalMethod();
        void MethodWith(Dependency TestObjectArg);
    }
}