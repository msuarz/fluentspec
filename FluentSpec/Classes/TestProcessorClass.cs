using System;

namespace FluentSpec.Classes {

    public class TestProcessorClass : TestProcessor {
    
        public const string DidNotCall = "Did not call ";
        public const string ShouldNotCall = "Should not call ";

        public Log Log { get; set; }
        public Call Call { get; set; }
        public Action Execute { get; set; }

        public TestProcessorClass() { Reset(); }

        public void Process(Log Log, Call Call) {
            Setup(Log, Call);
            Execute();
            Reset();
        }
        
        public virtual void Setup(Log Log, Call Call) {
            this.Log = Log; 
            this.Call = Call;
            if (ShouldIgnoreArgs) Call.IgnoreArgs();
        }

        public bool ShouldIgnoreArgs;
        public void IgnoreArgs() { ShouldIgnoreArgs = true; }

        public virtual void Reset() {
            Execute = Record;
            ShouldIgnoreArgs = false;
        }

        public object Given { get {
            Execute = Expect;
            return this;
        }}

        public void Expect() {
            Call.WillBeExpected();
            Log.Expect(Call);
            CallBuilder.ActiveCall = Call;
        }

        public bool ExpectSubjectAction { get { return Execute == Record; } }

        public object When { get { 
            CallBuilder.ActiveCall = null;
            Execute = Record;
            return this;
        }}

        public void Record() {
            Log.Record(Call);
            ThrowExceptionIfExpected();
        }

        public virtual void ThrowExceptionIfExpected() {
            if (UnexpectedCall) return;
            
            if (ExpectedCall.ShouldThrowException)
                throw ExpectedCall.Exception;
        }

        public object Should { get {
            CallBuilder.ActiveCall = null;
            Execute = VerifyCalled;
            return this;
        }}

        public object ShouldNot { get {
            CallBuilder.ActiveCall = null;
            Execute = VerifyDidNotCall;
            return this;
        }}

        public void VerifyCalled() { if (!Log.Recorded(Call)) 
            throw new Exception(DidNotCall + Call)
        ;}

        public void VerifyDidNotCall() { if (Log.Recorded(Call)) 
            throw new Exception(ShouldNotCall + Call)
        ;}

        public object Result { get { return UnexpectedCall ? 
            Call.Result : ExpectedCall.Result
        ;}}
        
        public virtual bool UnexpectedCall { get { return ExpectedCall == null; } }

        public virtual Call ExpectedCall { get { return Log.Expected(Call); } }
    }
}