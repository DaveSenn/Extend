#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
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

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ThrowIfNullTestCase2NullCheck()
        {
            String value = null;
            value.ThrowIfNull( () => value );
        }

        [Test]
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

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ThrowIfNullTestCase3NullCheck()
        {
            String value = null;
            value.ThrowIfNull( () => value, "" );
        }
    }
}