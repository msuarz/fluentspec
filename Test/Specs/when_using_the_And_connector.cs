using System;
using FluentSpec;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specs {

    [TestClass]
    public class when_using_the_And_connector : BehaviorOf<AndSUT>{
    
        [TestMethod]    
        public void should_chain_Givens() {
            
            Given.One.Is(1);
            And.Another.Is(2);

            When.Sum.ShouldBe(3);
        }

        [TestMethod]    
        public void should_chain_Whens() {
            
            Given.One.Is(21);
            And.Another.Is(2);

            When.Sum.ShouldBe(23);
            And.Mult.ShouldBe(42);
        }
        
        [TestMethod]
        public void should_chain_Shoulds() {

            When.Clear();            

            Should.EraseMem();
            And.ClearScreen();
        }
    }
    
    public class AndSUT {

        public virtual int One { get { throw new NotImplementedException(); } }
        public virtual int Another { get { throw new NotImplementedException(); } }
        public virtual int Sum { get { return One + Another; } }
        public virtual int Mult { get { return One * Another; } }

        public virtual void Clear() { EraseMem(); ClearScreen(); }
        public virtual void EraseMem() { throw new NotImplementedException(); }
        public virtual void ClearScreen() { throw new NotImplementedException(); }
    }
    
}