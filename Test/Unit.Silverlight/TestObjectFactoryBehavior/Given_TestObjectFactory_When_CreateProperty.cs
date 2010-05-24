using System.Reflection;
using FluentSpec;
using FluentSpec.Classes;
using FluentSpec.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit.Silverlight.TestObjectFactoryBehavior {

    [TestClass]
    public class Given_TestObjectFactory_When_CreateProperty : BehaviorOf<TestObjectFactory> {

        private readonly PropertyInfo ExpectedProperty = Helper.TesteableProperty;
        
        [TestInitialize]
        public override void Setup() { base.Setup(); }

        [TestMethod]
        public void Should_Setup_Property() {

            Given.ShouldTestProperty.WillReturn(true);
            When.CreateProperty(ExpectedProperty);
            Assert.AreSame(ExpectedProperty, Actual.Property);
        }

        [TestMethod]
        public void Should_SetupDependencyProperty_If_ShouldTestProperty() {
            
            Given.ShouldTestProperty.WillReturn(true);
            When.CreateProperty(ExpectedProperty);
            Should.SetupDependencyProperty();
        }

        [TestMethod]
        public void ShouldNot_SetupDependencyProperty_If_ShouldNotTestProperty() {
            
            Given.ShouldTestProperty.WillReturn(false);
            When.CreateProperty(ExpectedProperty);
            ShouldNot.SetupDependencyProperty();
        }
    }
}