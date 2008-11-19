namespace FluentSpec.Test.Acceptance.Classes {
    using System;

    public class Class {

        public Dependency Dependency { get; set; }

        public void Method() {

            VirtualMethod();
            Dependency.Method();

            if (GuardCondition) GuardedMethod();

            VirtualProperty = Dependency.Property = true;
        }

        bool GuardCondition { get { return 
            GuardProperty 
            || GuardFunction() 
            || Dependency.GuardProperty 
            || Dependency.GuardFunction()
        ;}}

        public virtual void VirtualMethod() {
            AnotherVirtualMethod();
        }

        public virtual void AnotherVirtualMethod() {
            throw new NotImplementedException();
        }

        public virtual void GuardedMethod() {
            throw new NotImplementedException();
        }

        public virtual bool GuardProperty {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual object VirtualProperty {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual bool GuardFunction() {
            throw new NotImplementedException();
        }

        #region dependency injection

        public Dependency AbstractDependency { get; set; }
        public Dependency SetAbstractDependency { set; private get; }
        public Class ConcreteDependency { get; set; }
        public Class SetConcreteDependency { set; private get; }

        public void TestDependency() {

            if (AbstractDependency != null) AbstractDependency.Method();
            if (SetAbstractDependency != null) SetAbstractDependency.Method();

            if (ConcreteDependency != null) ConcreteDependency.VirtualMethod();
            if (SetConcreteDependency != null) SetConcreteDependency.VirtualMethod();
        }

        public void TestDependency(Dependency Dependency) {
            Dependency.Method();
        }

        #endregion

    }
}