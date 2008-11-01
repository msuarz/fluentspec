namespace FluentSpec.Test.Acceptance.Classes {

    public class ClassWithDependency : Class {

        public Dependency Dependency { get; set; }
        public Dependency DependencyField;

        public Dependency ReturnUnexpectedInterface { get { return GetDependency; } }

        public virtual Dependency GetDependency { get {
            throw new System.NotImplementedException()
        ;}}

        public void Delegate() {
            Dependency.Method();
            if (Dependency.ConditionalMethod())
                GuardedMethod();
        }
    }
}