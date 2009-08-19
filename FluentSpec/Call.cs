using System;
using System.Reflection;

namespace FluentSpec {

    public interface Call {
    
        string Method { get; }
        Type ReturnType { get; }
        object[] Args { get; }

        object Result { get; set; }
        bool ShouldThrowException { get; }
        Exception Exception { get; }
        MethodInfo MethodInfo { get; }

        void IgnoreArgs();
        void WillThrow(Exception Exception);
        void WillBeExpected();
        void WasRecordedBy(Log Log);

        bool Equals(object obj);
    }
}