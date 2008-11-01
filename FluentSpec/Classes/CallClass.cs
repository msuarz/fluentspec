using System;
using System.Reflection;

namespace FluentSpec.Classes {

    public class CallClass : Call {

        public Comparer Comparer { get; set; }

        readonly MethodInfo MethodInfo;
        public virtual string Method { get { return MethodInfo.Name; } }
        public virtual Type ReturnType { get { return MethodInfo.ReturnType; } }
        public virtual object[] Args { get; private set; }

        public CallClass(){}

        public CallClass(MethodInfo MethodInfo, params object[] Args) {
            this.MethodInfo = MethodInfo;
            this.Args = Args;
        }

        object result;
        public virtual object Result {
            get { return result ?? Default; } 
            set { result = value; }
        }

        public virtual object Default { get { 
            try { return Activator.CreateInstance(ReturnType); } 
            catch { return null; }
        }}

        public bool ShouldThrowException { get; private set; }
        public void WillThrow(Exception Exception) {
            ShouldThrowException = true;
            Result = Exception;
        }
        public Exception Exception { get { return Result as Exception; } }

        public bool ShouldIgnoreArgs;
        public void IgnoreArgs() { ShouldIgnoreArgs = true; }

        public override bool Equals(object obj) { 
            var Other = obj as CallClass;
            
            return Method.Equals(Other.Method)
                && HaveMatchingArgsWith(Other);
        }

        public virtual bool HaveMatchingArgsWith(CallClass Other) { return
            ShouldIgnoreArgs
            || Other.ShouldIgnoreArgs
            || Comparer.AreEqual(Args, Other.Args)
        ;}

        public override int GetHashCode() { unchecked { return 
            ((Method != null ? Method.GetHashCode() : 0)*397) ^ 
            (Args != null ? Args.GetHashCode() : 0)
        ;}}

        public override string ToString() { return
            MethodInfo.DeclaringType.Name + "." + Method
        ;}
    }
}