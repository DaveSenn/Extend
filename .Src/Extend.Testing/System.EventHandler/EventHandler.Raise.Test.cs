#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class EventHandlerExTest
    {
        [Fact]
        public void RaiseTest()
        {
            var helperClass = new HelperClass();
            var eventArgs = new SampleEventArgs();
            helperClass.RaiseEvent( eventArgs );

            EventArgs actual = null;
            helperClass.MyEvent += ( sender, e ) => actual = e;
            helperClass.RaiseEvent( eventArgs );
            Assert.Same( eventArgs, actual );
        }

        [Fact]
        public void RaiseTest1()
        {
            var helperClass = new HelperClass();
            var eventArgs = new SampleEventArgs();
            helperClass.RaiseGenericEvent( eventArgs );

            SampleEventArgs actual = null;
            helperClass.MyGenericEvent += ( sender, e ) => actual = e;
            helperClass.RaiseGenericEvent( eventArgs );
            Assert.Same( eventArgs, actual );
        }

        #region Nested Types

        private class HelperClass
        {
            public event EventHandler MyEvent;
            public event EventHandler<SampleEventArgs> MyGenericEvent;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            public void RaiseEvent( EventArgs args ) => MyEvent.Raise( this, args );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            public void RaiseGenericEvent( SampleEventArgs args ) => MyGenericEvent.Raise( this, args );
        }

        private class SampleEventArgs : EventArgs
        {
        }

        #endregion
    }
}