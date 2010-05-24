namespace FluentSpec {

    public static class Given {
    
        public static SubjectClass That<SubjectClass>(SubjectClass Subject) { return
            Subject.Given()
        ;}
    }
}