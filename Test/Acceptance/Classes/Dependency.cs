namespace FluentSpec.Test.Acceptance.Classes {

    public interface Dependency {
        void Method();
        bool ConditionalMethod();
        void MethodWith(Dependency TestObjectArg);
        bool GuardProperty { get; set; }
        bool Property { get; set; }
        bool GuardFunction();
        void AnotherMethod();
    }
}