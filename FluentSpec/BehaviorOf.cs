using System;

namespace FluentSpec {

    public class BehaviorOf<SubjectClass> {

        SubjectClass Subject = TestObjectFor<SubjectClass>();

        public BehaviorOf() { LastConnector = () => { return Subject; }; }
        
        public virtual void Setup() { Subject = TestObjectFor<SubjectClass>(); }

        private TestProcessor TestSubject { get { return (TestProcessor) Subject; } }

        protected static T TestObjectFor<T>(params object[] Args) { return 
            Create.TestObjectFor<T>(Args)
        ;}

        Func<SubjectClass> LastConnector;
        
        protected SubjectClass Given { get {
            LastConnector = given;
            return (SubjectClass) TestSubject.Given;
        }}
        SubjectClass given() { return Given; }

        protected SubjectClass When { get {
            LastConnector = when;
            return (SubjectClass) TestSubject.When;
        }}
        SubjectClass when() { return When; }

        protected SubjectClass Should { get {
            LastConnector = then;
            return (SubjectClass) TestSubject.Should
        ;}}

        protected SubjectClass ShouldNot { get { 
            LastConnector = then;
            return (SubjectClass) TestSubject.ShouldNot;
        }}

        protected SubjectClass Then { get { return Should; } }
        SubjectClass then() { return Should; }
        
        protected SubjectClass And { get { return LastConnector(); } }
        protected SubjectClass But { get { return And; } }

        protected SubjectClass Expected { get { return Subject; } }
        protected SubjectClass Actual { get { return Subject; } }
        protected SubjectClass It { get { return Subject; } }
        
        protected SubjectClass That { get { return When; } }
        protected SubjectClass The { get { return When; } }

        protected void WillThrow(Exception Exception) {
            Subject.WillThrow(Exception);
        }
    }
}