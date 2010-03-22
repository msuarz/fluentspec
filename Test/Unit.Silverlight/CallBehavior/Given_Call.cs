using FluentSpec;
using FluentSpec.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit.Silverlight.CallBehavior {
    [TestClass]
    public class Given_Call : BehaviorOf<Method> {

        #region stunts

        const string Method = "Method";
        const string AnotherMethod = "AnotherMethod";
        Method Another;
        readonly object ExpectedResult = new object();
        readonly object[] Args = new object[0];
        readonly object[] AnotherArgs = new object[0];

        #endregion
        #region givens

        private void GivenSameMethods() {
            Given.Name = Method;
            Another.Name = Method;
        }

        private void GivenDifferentMethods() {
            Given.Name = Method;
            Another.Name = AnotherMethod;
        }

        private void GivenSameArgs() {
            Given.Args = Args;
            Another.Args = Args;
        }

        private void GivenDifferentArgs() {
            Given.Args = Args;
            Another.Args = AnotherArgs;
        }

        #endregion

        [TestInitialize]
        public override void Setup() {
            base.Setup();
            Another = TestObjectFor<Method>();
        }
        
        [TestMethod]
        public void When_Equals_Another() {

            GivenSameMethods();
            Given.HaveMatchingArgsWith(Another).WillReturn(true);

            Assert.IsTrue(That.Equals(Another));
        }
        
        [TestMethod]
        public void When_not_Equals_Another_based_on_Method() {
            
            Assert.IsFalse(That.Equals(Another));
        }
        
        [TestMethod]
        public void When_not_Equals_Another_based_on_Args() {

            GivenSameMethods();
            Assert.IsFalse(That.Equals(Another));
        }
        
        [TestMethod]
        public void When_does_not_HaveMatchingArgsWith_Another() {
            
            Assert.IsFalse(That.HaveMatchingArgsWith(Another));
        }
        
        [TestMethod]
        public void When_HaveMatchingArgsWith_Another_If_ShouldIgnoreArgs() {
            
            Given.ShouldIgnoreArgs = true;
            Assert.IsTrue(That.HaveMatchingArgsWith(Another));
        }
        
        [TestMethod]
        public void When_HaveMatchingArgsWith_Another_If_ShouldIgnoreArgs_Of_Another() {

            Another.ShouldIgnoreArgs = true;
            Assert.IsTrue(That.HaveMatchingArgsWith(Another));
        }
        
        [TestMethod]
        public void When_HaveMatchingArgsWith_Another_If_AreEqual_Args() {
            
            GivenSameArgs();
            Given.Comparer.AreEqual(Args, Args).WillReturn(true);
            
            Assert.IsTrue(That.HaveMatchingArgsWith(Another));
        }
        
        [TestMethod]
        public void When_ShouldIgnoreArgs() {
            
            Assert.IsFalse(That.ShouldIgnoreArgs);
            When.IgnoreArgs();
            Assert.IsTrue(That.ShouldIgnoreArgs);
        }
        
        [TestMethod]
        public void When_Result_Should_return_Default() {
            
            Given.Default.WillReturn(ExpectedResult);
            Assert.AreSame(ExpectedResult, Actual.Result);
        }
        
        [TestMethod]
        public void When_Result_Should_return_Result() {
            
            When.Result = ExpectedResult;
            Assert.AreSame(ExpectedResult, Actual.Result);
        }
        
        [TestMethod]
        public void When_Default_is_not_null() {

            Given.ReturnType.Is(typeof(object));            
            Assert.IsNotNull(Actual.Default);
        }
        
        [TestMethod]
        public void When_Default_is_null() {

            Given.ReturnType.Is(typeof(void));
            Assert.IsNull(Actual.Default);
        }
        
        [TestMethod]
        public void When_GetHashCode_Should_Equal() {
            
            GivenSameMethods();
            GivenSameArgs();
            
            Assert.IsTrue(That.GetHashCode() == Another.GetHashCode());
        }

        [TestMethod]
        public void When_GetHashCode_Should_Equal_If_Properties_Are_Null() {

            Given.Name = Another.Name = null;
            Given.Args = Another.Args = null;

            Assert.IsTrue(That.GetHashCode() == Another.GetHashCode());
        }

        [TestMethod]
        public void When_GetHashCode_Should_NotEqual_If_DifferentMethods() {

            GivenDifferentMethods();
            GivenSameArgs();

            Assert.IsTrue(That.GetHashCode() != Another.GetHashCode());
        }
        
        [TestMethod]
        public void When_GetHashCode_Should_NotEqual_If_DifferentArgs() {

            GivenSameMethods();
            GivenDifferentArgs();

            Assert.IsTrue(That.GetHashCode() != Another.GetHashCode());
        }
    }
}