namespace FluentSpec {

    public interface TestProcessor {

        bool ExpectSubjectAction { get; }
        void Process(Log Log, Call Call);
        object Result { get; }

        object Given { get; }
        object When { get; }
        object Should { get; }
        object ShouldNot { get; }
        
        void IgnoreArgs();
    }
}