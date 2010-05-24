using System;
using System.Reflection;

namespace FluentSpec.Classes {

    public class Method : Call {

        public Comparer Comparer { get; set; }

        public MethodInfo MethodInfo { get; set; }
        public virtual Type ReturnType { get { return MethodInfo.ReturnType; } }
        
        public Method() {
            Name = string.Empty;
            Args = new object[0];
        }

        public string Name { get; set; }
        public object[] Args { get; set; }

        object result;
        bool hasResult;
        public virtual object Result {
            get { return hasResult ? result : Default; }
            set { hasResult = true; result = value; }
        }

        public virtual object Default { get { 
            try { return Activator.CreateInstance(ReturnType); } 
            catch { return null; }
        }}

        public bool ShouldThrowException { get; private set; }
        public virtual void WillThrow(Exception Exception) {
            ShouldThrowException = true;
            Result = Exception;
        }

        public virtual void WillBeExpected() {}
        public virtual void WasRecordedBy(Log Log) {}

        public Exception Exception { get { return Result as Exception; } }

        public bool ShouldIgnoreArgs;
        public void IgnoreArgs() { ShouldIgnoreArgs = true; }

        public override bool Equals(object obj) { 
            var Other = obj as Method;
            
            return Name.Equals(Other.Name)
                && HaveMatchingArgsWith(Other);
        }

        public virtual bool HaveMatchingArgsWith(Method Other) { return
            ShouldIgnoreArgs
            || Other.ShouldIgnoreArgs
            || Comparer.AreEqual(Args, Other.Args)
        ;}

        public override int GetHashCode() { unchecked { return 
            ((Name != null ? Name.GetHashCode() : 0)*397) ^ 
            (Args != null ? Args.GetHashCode() : 0)
        ;}}

        public override string ToString() { return
            MethodInfo.DeclaringType.Name + "." + Name
        ;}
    }
}