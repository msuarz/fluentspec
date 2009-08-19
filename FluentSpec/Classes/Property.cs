namespace FluentSpec.Classes {

    public class Property : Method {
    
        public override void WillBeExpected() {
            if (IsSetter) SwitchToGetter();
        }
    }
}