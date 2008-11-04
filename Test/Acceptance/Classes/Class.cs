namespace FluentSpec.Test.Acceptance.Classes {
    using System;

    public class Class {

        public void Method() {
            VirtualMethod();

            if (BoolProperty)
                GuardedMethod();

            if (ExpectedException != null)
                GuardedMethodForException();
        }

        public virtual void VirtualMethod() {
            NestedVirtualMethod();
        }

        public virtual void NestedVirtualMethod() {
            throw new NotImplementedException();
        }

        public virtual object GetProperty() { return 
            VirtualProperty;
        }

        public virtual void SetProperty(object Value) { 
            VirtualProperty = Value;
        }

        public virtual void GuardedMethod() {
            throw new NotImplementedException();
        }

        public virtual void GuardedMethodForException() {
            throw new NotImplementedException();
        }

        public virtual bool BoolProperty {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual object VirtualProperty {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual object this[string name, int index] {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        
        public virtual Exception ExpectedException { get; set; }
    }
}