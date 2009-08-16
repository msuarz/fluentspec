using System;

namespace Specs.Classes {

    public class Class {
    
        public object UnimplementedProperty { get { throw new NotImplementedException(); } }
    }
}