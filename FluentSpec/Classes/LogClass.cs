using System.Collections.Generic;

namespace FluentSpec.Classes {

    public class LogClass : Log {

        public readonly List<Call> ExpectedCalls = new List<Call>();
        public readonly List<Call> ActualCalls = new List<Call>();

        public void Record(Call Call) {
            ActualCalls.Add(Call);
        }

        public bool Recorded(Call ExpectedCall) { return
            ActualCalls.Exists(Call => Call.Equals(ExpectedCall))        
        ;}

        public void Expect(Call Call) {
            ExpectedCalls.Add(Call);
        }

        public virtual Call Expected(Call ActualCall) { return
            ExpectedCalls.Find(Call => Call.Equals(ActualCall))
        ;}

    }
}