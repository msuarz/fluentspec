namespace FluentSpec.Test.Acceptance.Classes {

    public class ClassWithArgs {
    
        public Dependency Dependency { get; set; }
    
        public void MethodWithArgs(params object[] Args) {
            VirtualMethodWithArgs(Args);
        }
        
        public bool Condition(params object[] Args) {
            return AreValid(Args);
        }

        public virtual bool AreValid(params object[] args) {
            throw new System.NotImplementedException();
        }

        public virtual void VirtualMethodWithArgs(params object[] Args) {
            throw new System.NotImplementedException();
        }

        public void MethodWith(Dependency TestObjectArg) {
            Dependency.MethodWith(TestObjectArg);
        }

    }
    
}
