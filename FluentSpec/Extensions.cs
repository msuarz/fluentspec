namespace FluentSpec {

    internal static class Extensions {
        
        internal static string Quoted(this string Unquoted) {
            return "\"" + Unquoted + "\"";
        }
    }
}