using FluentSpec;
using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specs.Helpers;

namespace Specs {

    public class given_a_virtual_Property_is_set_during_a_test {
    
        [TestClass]
        public class when_the_Call_is_recorded : BehaviorOf<LogClass> {
            
            [TestMethod]
            public void should_signal_the_recorded_Call() {
                var Call = TestObjectFor<Call>();

                When.Record(Call);
                Call.Should().WasRecordedBy(It);
            }
        }
        
        [TestClass]
        public class when_the_Call_was_recorded : BehaviorOf<CallClass> {}
        
        [TestClass]
        public class when_the_Call_is_switched_to_getter : BehaviorOf<CallClass> {
        
            readonly object Value = new object();

            [TestInitialize]
            public void SetUp() {
                Given.MethodInfo = Actors.VirtualSetter;
                Given.Method = "set_VirtualProperty";
                Given.Args = new [] { Value };

                When.SwitchToGetter();
            }
            
            [TestMethod]
            public void the_Method_prefix_should_change_to_get() {

                Then.Method.ShouldBe("get_VirtualProperty");
            }
            
            [TestMethod]
            public void the_Value_should_become_the_Result() {
                
                Then.Result.ShouldBe(Value);
            }
            
            [TestMethod]
            public void the_getter_should_have_the_same_Args_except_the_Value() {
                
                Then.Args.Length.ShouldBe(0);
            }
        }
        
    }
}