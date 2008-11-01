namespace FluentSpec {

    public static class Then {

        public static SubjectClass Should<SubjectClass>(SubjectClass Subject) { return
            Subject.Should()
        ;}

        public static SubjectClass ShouldNot<SubjectClass>(SubjectClass Subject) { return
            Subject.ShouldNot()
        ;}
    }
}