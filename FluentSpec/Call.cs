using System;

namespace FluentSpec {

    public interface Call {
    
        string Method { get; }
        Type ReturnType { get; }
        object[] Args { get; }

        object Result { get; set; }
        bool ShouldThrowException { get; }
        Exception Exception { get; }

        void IgnoreArgs();
        void WillThrow(Exception Exception);
        void WillBeExpected();

        bool Equals(object obj);
    }
}