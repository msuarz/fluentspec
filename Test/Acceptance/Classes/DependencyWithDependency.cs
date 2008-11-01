namespace FluentSpec.Test.Acceptance.Classes {

    public interface DependencyWithDependency : Dependency {
        Dependency Dependency { get; set; }
    }
}