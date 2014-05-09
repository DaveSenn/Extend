#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [TestCase]
        public void ThrowIfNullTestCase()
        {
            var varName = RandomValueEx.GetRandomString();
            this.ThrowIfNull( varName, x => varName );

            varName = null;
            var errorMessage = String.Empty;
            try
            {
                this.ThrowIfNull( varName, x => varName );
            }
            catch ( ArgumentNullException ex )
            {
                errorMessage = ex.Message;
            }

            Assert.IsTrue( errorMessage.Contains( "varName" ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ThrowIfNullTestCaseNullCheck()
        {
            String value = null;
            this.ThrowIfNull( value, x => value );
        }

        [TestCase]
        public void ThrowIfNullTestCase1()
        {
            var varName = RandomValueEx.GetRandomString();
            this.ThrowIfNull( varName, x => varName );

            varName = null;
            var expectedErrorMessage = RandomValueEx.GetRandomString();
            var errorMessage = String.Empty;
            try
            {
                this.ThrowIfNull( varName, x => varName, expectedErrorMessage );
            }
            catch ( ArgumentNullException ex )
            {
                errorMessage = ex.Message;
            }

            Assert.IsTrue( errorMessage.Contains( expectedErrorMessage ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ThrowIfNullTestCase1NullCheck()
        {
            String value = null;
            this.ThrowIfNull( value, x => value, "" );
        }

        [TestCase]
        public void ThrowIfNullTestCase2()
        {
            var varName = RandomValueEx.GetRandomString();
            varName.ThrowIfNull( () => varName );

            varName = null;
            var errorMessage = String.Empty;
            try
            {
                varName.ThrowIfNull( () => varName );
            }
            catch ( ArgumentNullException ex )
            {
                errorMessage = ex.Message;
            }

            Assert.IsTrue( errorMessage.Contains( "varName" ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ThrowIfNullTestCase2NullCheck()
        {
            String value = null;
            value.ThrowIfNull( () => value );
        }

        [TestCase]
        public void ThrowIfNullTestCase3()
        {
            var varName = RandomValueEx.GetRandomString();
            varName.ThrowIfNull( () => varName );

            varName = null;
            var expectedErrorMessage = RandomValueEx.GetRandomString();
            var errorMessage = String.Empty;
            try
            {
                varName.ThrowIfNull( () => varName, expectedErrorMessage );
            }
            catch ( ArgumentNullException ex )
            {
                errorMessage = ex.Message;
            }

            Assert.IsTrue( errorMessage.Contains( expectedErrorMessage ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ThrowIfNullTestCase3NullCheck()
        {
            String value = null;
            value.ThrowIfNull( () => value, "" );
        }
    }
}