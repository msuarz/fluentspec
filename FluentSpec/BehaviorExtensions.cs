
namespace FluentSpec {

    public static class BehaviorExtensions {

        private static TestProcessor Test(object Subject) { return 
            (TestProcessor) Subject
        ;}
        
        public static SubjectClass Should<SubjectClass>(this SubjectClass Subject) { return 
            (SubjectClass) Test(Subject).Should
        ;}

        public static SubjectClass ShouldNot<SubjectClass>(this SubjectClass Subject) { return 
            (SubjectClass) Test(Subject).ShouldNot
        ;}

        public static SubjectClass Given<SubjectClass>(this SubjectClass Subject) { return 
            (SubjectClass) Test(Subject).Given
        ;}
    }
}