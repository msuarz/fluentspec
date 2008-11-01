namespace FluentSpec.Test.Acceptance.Classes {
    using System;

    public class Class {

        public void Method() {
            VirtualMethod();

            if (ConditionalMethod())
                GuardedMethod();

            if (ExpectedException != null)
                GuardedMethod();
        }

        public virtual void VirtualMethod() {
            NestedVirtualMethod();
        }

        public virtual void NestedVirtualMethod() {
            throw new NotImplementedException();
        }

        public virtual bool ConditionalMethod() { return 
            ConditionalProperty;
        }

        public virtual void GuardedMethod() {
            throw new NotImplementedException();
        }

        public bool ConditionalProperty { get; set; }

        public virtual Exception ExpectedException { get; set; }
    }
}