using System;

namespace FluentSpec.Classes {

    public class Property : Method {
    
        public override void WillBeExpected() {
            if (IsSetter) SwitchToGetter();
        }

        public override void WillThrow(Exception Exception) {
            if (WasSetter) SwitchToSetter();
            base.WillThrow(Exception);
        }
    }
}