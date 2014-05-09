using NUnit.Framework;
using System;

namespace PortableExtensions.Tetst
{
    [TestFixture]
    public class EventHandlerExTest
    {
        private event EventHandler MyTestEv;

        private event EventHandler MyTestEv1;

        private event EventHandler<MyEventArgs> MyGenericEv;

        private event EventHandler<MyEventArgs> MyGenericEv1;

        [Test]
        public void RaiseTest()
        {
            EventHandlerEx.Raise ( MyTestEv, this, new EventArgs () );

            var sender = this;
            var args = new EventArgs ();
            var evRaised = false;
            MyTestEv += ( s, e ) =>
            {
                Assert.AreSame ( sender, s );
                Assert.AreSame ( args, e );
                evRaised = true;
            };
            EventHandlerEx.Raise ( MyTestEv, sender, args );
            Assert.IsTrue ( evRaised );
        }

        [Test]
        public void RaiseTestNullCheck()
        {
            EventHandlerEx.Raise ( null, this, new EventArgs () );
        }

        [Test]
        public void RaiseTestNullCheck1()
        {
            EventHandlerEx.Raise ( MyTestEv1, null, new EventArgs () );
        }

        [Test]
        public void RaiseTestNullCheck2()
        {
            EventHandlerEx.Raise ( null, null, null );
        }

        [Test]
        public void RaiseTTest()
        {
            EventHandlerEx.RaiseT ( MyGenericEv, this, new MyEventArgs () );

            var sender = this;
            var args = new MyEventArgs { Value = Guid.NewGuid ().ToString () };
            var evRaised = false;
            MyGenericEv += ( s, e ) =>
            {
                Assert.AreSame ( sender, s, "test1" );
                Assert.AreSame ( args, e, "test2" );
                evRaised = true;
            };
            EventHandlerEx.RaiseT ( MyGenericEv, sender, args );
            Assert.IsTrue ( evRaised );
        }

        [Test]
        public void RaiseTTestNullCheck()
        {
            EventHandlerEx.RaiseT ( null, this, new MyEventArgs () );
        }

        [Test]
        public void RaiseTTestNullCheck1()
        {
            EventHandlerEx.RaiseT ( MyGenericEv1, null, new MyEventArgs () );
        }

        [Test]
        public void RaiseTTestNullCheck2()
        {
            EventHandlerEx.RaiseT<MyEventArgs> ( null, null, null );
        }
    }

    public delegate void MyEventArgsEventHandler( Object sender, MyEventArgs args );

    public class MyEventArgs : EventArgs
    {
        public String Value { get; set; }
    }
}