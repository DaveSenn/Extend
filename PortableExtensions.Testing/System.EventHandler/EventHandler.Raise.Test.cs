#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class EventHandlerExTest
    {
        [TestCase]
        public void RaiseTestCase()
        {
            var helperClass = new HelperClass();
            var eventArgs = new SampleEventArgs( RandomValueEx.GetRandomString() );
            helperClass.RaiseEvent( eventArgs );

            EventArgs actual = null;
            helperClass.MyEvent += ( sender, e ) => actual = e;
            helperClass.RaiseEvent( eventArgs );
            Assert.AreSame( eventArgs, actual );
        }

        [TestCase]
        public void RaiseTestCase1()
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
            public event EventHandler<SampleEventArgs> MyGenericEvent;
            public event EventHandler MyEvent;

            public void RaiseGenericEvent( SampleEventArgs args )
            {
                MyGenericEvent.Raise( this, args );
            }

            public void RaiseEvent( EventArgs args )
            {
                MyEvent.Raise( this, args );
            }
        }

        private class SampleEventArgs : EventArgs
        {
            public SampleEventArgs( String message )
            {
                Message = message;
            }

            public String Message { get; private set; }
        }
    }
}