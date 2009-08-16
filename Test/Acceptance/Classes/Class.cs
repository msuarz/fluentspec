using System;
using System.Collections.Generic;

namespace FluentSpec.Test.Acceptance.Classes {

    public class Class {

        public Dependency Dependency { get; set; }

        public void Method() {

            VirtualMethod();
            Dependency.Method();

            if (GuardCondition) DoGuardedMethod();

            VirtualProperty = Dependency.Property = true;
        }

        public void AddAnElement() { 
            List.Add("an element");
        }

        #region virtual methods

        public virtual void VirtualMethod() {
            AnotherVirtualMethod();
        }

        public virtual void AnotherVirtualMethod() {
            throw new NotImplementedException();
        }

        public virtual List<string> List {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual object VirtualProperty {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion
        #region guarded methods

        bool GuardCondition { get { return
            GuardProperty
            || GuardFunction()
            || Dependency.GuardProperty
            || Dependency.GuardFunction()
        ;}}

        public virtual void DoGuardedMethod() {
            throw new NotImplementedException();
        }

        public virtual bool GuardProperty {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual bool GuardFunction() {
            throw new NotImplementedException();
        }

        #endregion
        #region methods with args

        public void MethodWithArgs(params object[] Args) {
            ForwardToMethodWithArgs(Args);
            Dependency.MethodWithArgs(Args);
        }

        public virtual void ForwardToMethodWithArgs(params object[] Args) {
            throw new NotImplementedException();
        }

        public bool AreValid(params object[] Args) {
            return ValidationForArgs(Args);
        }

        public virtual bool ValidationForArgs(params object[] args) {
            throw new NotImplementedException();
        }

        #endregion
        #region dependency injection

        public Class() { }

        public Class(Dependency Dependency) {
            AbstractDependency = Dependency;
        }

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