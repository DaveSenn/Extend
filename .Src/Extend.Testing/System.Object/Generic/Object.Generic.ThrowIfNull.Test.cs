#region Usings

using System;
using System.Linq.Expressions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ThrowIfNullTest()
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
        public void ThrowIfNullTest1()
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
        public void ThrowIfNullTest2()
        {
            var varName = RandomValueEx.GetRandomString();
            varName.ThrowIfNull( "varName" );

            varName = null;
            var errorMessage = String.Empty;
            try
            {
                varName.ThrowIfNull( "varName" );
            }
            catch ( ArgumentNullException ex )
            {
                errorMessage = ex.Message;
            }

            Assert.IsTrue( errorMessage.Contains( "varName" ) );
        }

        [Test]
        public void ThrowIfNullTest3()
        {
            var varName = RandomValueEx.GetRandomString();
            varName.ThrowIfNull( "varName" );

            varName = null;
            var expectedErrorMessage = RandomValueEx.GetRandomString();
            var errorMessage = String.Empty;
            try
            {
                varName.ThrowIfNull( "varName", expectedErrorMessage );
            }
            catch ( ArgumentNullException ex )
            {
                errorMessage = ex.Message;
            }

            Assert.IsTrue( errorMessage.Contains( expectedErrorMessage ) );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ThrowIfNullTestNullCheck()
        {
            String value = null;
            value.ThrowIfNull( () => value );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ThrowIfNullTestNullCheck1()
        {
            String value = null;
            Expression<Func<String>> expression = null;
            value.ThrowIfNull( expression );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ThrowIfNullTestNullCheck2()
        {
            String value = null;
            value.ThrowIfNull( "varName" );
        }
    }
}