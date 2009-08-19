using System;
using System.Reflection;

namespace FluentSpec.Classes {

    public class Method : Call {

        public Comparer Comparer { get; set; }

        public MethodInfo MethodInfo { get; set; }
        public virtual Type ReturnType { get { return MethodInfo.ReturnType; } }
        protected bool IsOriginal { get { return MethodInfo.Name == Name; } }

        string name = string.Empty;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        object[] args = new object[0];
        public object[] Args {
            get { return args; }
            set { args = value; }
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
            Name = "set_" + Name.Remove(0, 4);
            Array.Resize(ref args, Args.Length + 1);
            Args[Args.Length - 1] = Result;
        }

        public virtual void SwitchToGetter() {
            Name = "get_" + Name.Remove(0, 4);
            Result = Args[Args.Length - 1];
            Array.Resize(ref args, Args.Length - 1);
        }

        public virtual bool IsSetter { get { return 
            MethodInfo.IsSpecialName
            && MethodInfo.Name.StartsWith("set_")
        ;}}

        protected virtual bool IsGetter { get { return 
            MethodInfo.IsSpecialName
            && MethodInfo.Name.StartsWith("get_")
        ;}}

        public virtual bool WasSetter { get { return
            IsSetter && Name != MethodInfo.Name
        ;}}

        public Exception Exception { get { return Result as Exception; } }

        public bool ShouldIgnoreArgs;
        public void IgnoreArgs() { ShouldIgnoreArgs = true; }

        public override bool Equals(object obj) { 
            var Other = obj as Method;
            
            return Name.Equals(Other.Name)
                && HaveMatchingArgsWith(Other);
        }

        public void WasRecordedBy(Log Log) { 
            if (!IsSetter || !IsOriginal) return;
            
            var Getter = ObjectFactory.CallFrom(this);
            Getter.WillBeExpected();
            Log.Expect(Getter);
            Log.Record(Getter);        
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