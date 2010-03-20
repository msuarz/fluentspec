namespace FluentSpec {

    public static class Extensions {
        
        public static string Quoted(this string Unquoted) {
            return "\"" + Unquoted + "\"";
        }
    }
}