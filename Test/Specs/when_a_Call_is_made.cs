using FluentSpec;
using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specs.Helpers;

namespace Specs {

    [TestClass]
    public class when_a_Call_is_made {
        
        [TestMethod]
        public void it_should_be_detected_as_a_Property() {
            
            Actors.VirtualSetter.IsProperty().ShouldBeTrue();
            Actors.VirtualGetter.IsProperty().ShouldBeTrue();
        }
    }
}