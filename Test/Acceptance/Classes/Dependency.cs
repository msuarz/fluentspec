namespace FluentSpec.Test.Acceptance.Classes {

    public interface Dependency {
        void Method();
        bool Function();
        void MethodWithArgs(params object[] args);
        bool GuardProperty { get; set; }
        bool Property { get; set; }
        bool GuardFunction();
        void AnotherMethod();
        Dependency Dependency { get; set; }
    }
}