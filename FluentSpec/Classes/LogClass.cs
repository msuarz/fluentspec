using System.Collections.Generic;
using System.Linq;

namespace FluentSpec.Classes {

    public class LogClass : Log {
        
        List<Call> ExpectedCalls = new List<Call>();
        readonly List<Call> ActualCalls = new List<Call>();

        public void Record(Call Call) {
            ActualCalls.Add(Call);
            Call.WasRecordedBy(this);
        }

        public bool Recorded(Call ExpectedCall) { return
            ActualCalls.Where(Call => Call.Equals(ExpectedCall)).FirstOrDefault() != null        
        ;}

        public void Expect(Call ActualCall) {
            ExpectedCalls = ExpectedCalls.Where(Call => !Call.Equals(ActualCall)).ToList();
            ExpectedCalls.Add(ActualCall);
        }

        public virtual Call Expected(Call ActualCall) { return
            ExpectedCalls.Where(Call => Call.Equals(ActualCall)).FirstOrDefault()
        ;}

    }
}