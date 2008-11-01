namespace FluentSpec {

    public interface Log {

        void Record(Call Call);
        bool Recorded(Call Call);

        void Expect(Call Call);
        Call Expected(Call actualcall);
    }
}