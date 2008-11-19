using System;
using System.Reflection;

namespace FluentSpec.Classes {

    public class CallClass : Call {

        public Comparer Comparer { get; set; }

        readonly MethodInfo MethodInfo;
        public virtual Type ReturnType { get { return MethodInfo.ReturnType; } }

        string method = string.Empty;
        public string Method {
            get { return method; }
            set { method = value; }
        }

        object[] args = new object[0];
        public object[] Args {
            get { return args; }
            set { args = value; }
        }

        public CallClass(){}

        public CallClass(MethodInfo MethodInfo, params object[] Args) {
            this.MethodInfo = MethodInfo;
            Method =  MethodInfo.Name;
            this.Args = Args;
        }

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
        public void WillThrow(Exception Exception) {
            if (WasSetter) SwitchToSetter();
            ShouldThrowException = true;
            Result = Exception;
        }

        public void WillBeExpected() {
            if (IsSetter) SwitchToGetter();
        }

        public virtual void SwitchToSetter() {
            Method = "set_" + Method.Remove(0, 4);
            Array.Resize(ref args, Args.Length + 1);
            Args[Args.Length - 1] = Result;
        }

        public virtual void SwitchToGetter() {
            Method = "get_" + Method.Remove(0, 4);
            Result = Args[Args.Length - 1];
            Array.Resize(ref args, Args.Length - 1);
        }

        public virtual bool IsSetter { get { return 
            MethodInfo.IsSpecialName
            && MethodInfo.Name.StartsWith("set_")
        ;}}

        public virtual bool WasSetter { get { return
            IsSetter && Method != MethodInfo.Name
        ;}}

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