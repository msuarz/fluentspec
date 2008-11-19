using System;

namespace FluentSpec {

    public class BehaviorOf<SubjectClass> {

        private readonly SubjectClass Subject = TestObjectFor<SubjectClass>();

        private TestProcessor TestSubject { get { return (TestProcessor) Subject; } }

        protected static T TestObjectFor<T>() { return 
            Create.TestObjectFor<T>()
        ;}

        protected SubjectClass Given { get { return
            (SubjectClass) TestSubject.Given
        ;}}

        protected SubjectClass When { get { return
            (SubjectClass) TestSubject.When
        ;}}

        protected SubjectClass Should { get { return
            (SubjectClass) TestSubject.Should
        ;}}

        protected SubjectClass ShouldNot { get { return
            (SubjectClass) TestSubject.ShouldNot
        ;}}

        protected SubjectClass Then { get { return Should; } }
        protected SubjectClass Expected { get { return Subject; } }
        protected SubjectClass Actual { get { return Subject; } }
        protected SubjectClass That { get { return When; } }

        protected void WillThrow(Exception Exception) {
            Subject.WillThrow(Exception);
        }
    }
}