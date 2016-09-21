#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class EventHandlerExTest
    {
        [Test]
        public void RaiseTest()
        {
            var helperClass = new HelperClass();
            var eventArgs = new SampleEventArgs( RandomValueEx.GetRandomString() );
            helperClass.RaiseEvent( eventArgs );

            EventArgs actual = null;
            helperClass.MyEvent += ( sender, e ) => actual = e;
            helperClass.RaiseEvent( eventArgs );
            Assert.AreSame( eventArgs, actual );
        }

        [Test]
        public void RaiseTest1()
        {
            var helperClass = new HelperClass();
            var eventArgs = new SampleEventArgs( RandomValueEx.GetRandomString() );
            helperClass.RaiseGenericEvent( eventArgs );

            SampleEventArgs actual = null;
            helperClass.MyGenericEvent += ( sender, e ) => actual = e;
            helperClass.RaiseGenericEvent( eventArgs );
            Assert.AreSame( eventArgs, actual );
        }

        private class HelperClass
        {
            public event EventHandler MyEvent;
            public event EventHandler<SampleEventArgs> MyGenericEvent;

            public void RaiseEvent( EventArgs args ) => MyEvent.Raise( this, args );

            public void RaiseGenericEvent( SampleEventArgs args ) => MyGenericEvent.Raise( this, args );
        }

        private class SampleEventArgs : EventArgs
        {
            #region Properties

            public String Message { get; private set; }

            #endregion

            #region Ctor

            public SampleEventArgs( String message )
            {
                Message = message;
            }

            #endregion
        }
    }
}