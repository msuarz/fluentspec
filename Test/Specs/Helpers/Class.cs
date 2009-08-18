using System;

namespace Specs.Helpers {

    public class Class {
    
        public object UnimplementedProperty { get { throw new NotImplementedException(); } }

        public virtual object VirtualProperty {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}