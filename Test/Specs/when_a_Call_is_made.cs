using FluentSpec.Classes;
using FluentSpec.Specs.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSpec.Specs {

    [TestClass]
    public class when_a_Call_is_made {

        [TestMethod]        
        public void it_should_be_created_as_a_Method() {
            
            ObjectFactory.Call(Actors.Method, null)
                .ShouldBeA<Method>();
        }

        [TestMethod]        
        public void it_should_be_created_as_a_Property() {
            
            ObjectFactory.Call(Actors.VirtualGetter, null)
                .ShouldBeA<Property>();
        }

        [TestMethod]
        public void it_should_be_detected_as_a_Property() {
            
            Actors.VirtualSetter.IsProperty().ShouldBeTrue();
            Actors.VirtualGetter.IsProperty().ShouldBeTrue();
        }
    }
}