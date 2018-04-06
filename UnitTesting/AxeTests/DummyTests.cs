using NUnit.Framework;
using System;

namespace Tests
{
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            Axe axe = new Axe(2, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.AreEqual(8, dummy.Health);
        }

        [Test]
        public void DeadDummyThrowsExceptionWhenAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            axe.Attack(dummy);
            // Assert.Throws(Is.TypeOf<InvalidOperationException>().And.Message.EqualTo("Dummy is dead."), delegate {})
           // Assert.Throws<InvalidOperationException>(delegate { var a = axe.Attack(dummy) }, "Dead dummy does not throw exception if attacked.");
        }

    //    Assert.Throws(Is.Typeof<MyException>()
    //             .And.Message.EqualTo( "message" )
    //             .And.Property( "MyParam" ).EqualTo( 42 ),
    //  delegate { throw new MyException( "message", 42 );
    //} );


    }
}