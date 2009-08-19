using FluentSpec;
using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specs {

    public class given_a_virtual_Property_is_setup_for_a_test {
    
        [TestClass]
        public class when_set_to_expected : BehaviorOf<Property> {
            
            [TestMethod]
            public void it_should_switch_to_getter_if_is_setter() {
                
                Given.IsSetter.Is(true);
                When.WillBeExpected();
                It.Should().SwitchToGetter();
            }
        }
        
    }
}