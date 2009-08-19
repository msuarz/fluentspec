using System;
using System.Linq;

namespace FluentSpec.Classes {

    public class Property : Method {
    
        public override void WillBeExpected() {
            if (IsSetter) SwitchToGetter();
        }

        public override void WillThrow(Exception Exception) {
            if (WasSetter) SwitchToSetter();
            base.WillThrow(Exception);
        }

        public override void WasRecordedBy(Log Log) { 
            if (!IsSetter || !IsOriginal) return;
            
            var Getter = ObjectFactory.CallFrom(this);
            Getter.WillBeExpected();
            Log.Expect(Getter);
            Log.Record(Getter);        
        }

        protected bool IsOriginal { get { return MethodInfo.Name == Name; } }

        public virtual void SwitchToSetter() {
            Name = "set_" + Name.Remove(0, 4);
            Args = Args.Concat(new [] {Result}).ToArray();
        }

        public virtual void SwitchToGetter() {
            Name = "get_" + Name.Remove(0, 4);
            Result = Args[Args.Length - 1];
            Args = Args.Take(Args.Length - 1).ToArray();
        }

        public virtual bool IsSetter { get { return 
            MethodInfo.IsSetter()
        ;}}

        protected virtual bool IsGetter { get { return 
            MethodInfo.IsGetter()
        ;}}

        public virtual bool WasSetter { get { return
            IsSetter && Name != MethodInfo.Name
        ;}}
    }
}