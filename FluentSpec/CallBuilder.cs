using System;

namespace FluentSpec {

    public static class CallBuilder {

        public static Call ActiveCall;

        public static void WillReturn<T>(this object obj, T Result) {
            ActiveCall.Result = Result;
            ActiveCall = null;
        }

        public static void WillThrow<E>(this object obj, E Exception) 
            where E : Exception {
            ActiveCall.WillThrow(Exception);
            ActiveCall = null;
        }

        public static T IgnoringArgs<T>(this T obj) {
            if (UnexpectedCall) (obj as TestProcessor).IgnoreArgs();
            else ActiveCall.IgnoreArgs();
            return obj;
        }
        
        private static bool UnexpectedCall { get { return ActiveCall == null; } }
    }
}