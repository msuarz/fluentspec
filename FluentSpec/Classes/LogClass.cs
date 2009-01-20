using System.Collections.Generic;
using System.Linq;

namespace FluentSpec.Classes {

    public class LogClass : Log {

        public List<Call> ExpectedCalls = new List<Call>();
        public List<Call> ActualCalls = new List<Call>();

        public void Record(Call Call) {
            ActualCalls.Add(Call);
        }

        public bool Recorded(Call ExpectedCall) { return
            ActualCalls.Where(Call => Call.Equals(ExpectedCall)).FirstOrDefault() != null        
        ;}

        public void Expect(Call ActualCall) {
            ExpectedCalls = ExpectedCalls.Where(Call => !Call.Equals(ActualCall)).ToList();
            ExpectedCalls.Add(ActualCall);
        }

        public virtual int IndexOf(Call ActualCall) { return 
            ExpectedCalls.IndexOf(ActualCall)
        ;}

        public virtual Call Expected(Call ActualCall) { return
            ExpectedCalls.Where(Call => Call.Equals(ActualCall)).FirstOrDefault()
        ;}

    }
}