#region Usings

#region Usings

using System;
using System.Linq.Expressions;
using FluentAssertions;
using NUnit.Framework;

#endregion

#pragma warning disable 618

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
#pragma warning disable CS0618 // Type or member is obsolete
            varName.ThrowIfNull( () => varName );
#pragma warning restore CS0618 // Type or member is obsolete

            varName = null;
            var errorMessage = String.Empty;
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                varName.ThrowIfNull( () => varName );
#pragma warning restore CS0618 // Type or member is obsolete
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
#pragma warning disable CS0618 // Type or member is obsolete
            varName.ThrowIfNull( () => varName );
#pragma warning restore CS0618 // Type or member is obsolete

            varName = null;
            var expectedErrorMessage = RandomValueEx.GetRandomString();
            var errorMessage = String.Empty;
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                varName.ThrowIfNull( () => varName, expectedErrorMessage );
#pragma warning restore CS0618 // Type or member is obsolete
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
        public void ThrowIfNullTestNullCheck()
        {
            String value = null;
#pragma warning disable CS0618 // Type or member is obsolete
            Action test = () => value.ThrowIfNull( () => value );
#pragma warning restore CS0618 // Type or member is obsolete

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ThrowIfNullTestNullCheck1()
        {
            String value = null;
            Expression<Func<String>> expression = null;
#pragma warning disable CS0618 // Type or member is obsolete
            Action test = () => value.ThrowIfNull( expression );
#pragma warning restore CS0618 // Type or member is obsolete

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ThrowIfNullTestNullCheck2()
        {
            String value = null;
            Action test = () => value.ThrowIfNull( "varName" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}