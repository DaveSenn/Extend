#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
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

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ThrowIfNullTestCaseNullCheck()
        {
            String value = null;
            this.ThrowIfNull( value, x => value );
        }

        [Test]
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

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ThrowIfNullTestCase1NullCheck()
        {
            String value = null;
            this.ThrowIfNull( value, x => value, "" );
        }

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
        [ExpectedException( typeof ( ArgumentNullException ) )]
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
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ThrowIfNullTestCase3NullCheck()
        {
            String value = null;
            value.ThrowIfNull( () => value, "" );
        }


        [Test]
        public void ThrowIfNullTestCase4()
        {
            var testClass = new TestClass
            {
                Name = RandomValueEx.GetRandomString()
            };

            testClass.ThrowIfNull<TestClass, String>(testClass, @class => @class.Name);
        }

        private class TestClass
        {
            public String Name { get; set; }
            public Int32 Age { get; set; }
        }
    }

}