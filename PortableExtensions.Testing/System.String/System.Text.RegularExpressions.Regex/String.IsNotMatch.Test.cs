#region Usings

using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void IsNotMatchTestCase()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsNotMatch( emaiLpattern );
            Assert.IsFalse( actual );

            actual = invalidEmail.IsNotMatch( emaiLpattern );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsNotMatchTestCase1()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsNotMatch( emaiLpattern, RegexOptions.Compiled );
            Assert.IsFalse( actual );

            actual = invalidEmail.IsNotMatch( emaiLpattern, RegexOptions.None );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsNotMatchTestCase1NullCheck()
        {
            StringEx.IsNotMatch( null, "", RegexOptions.CultureInvariant );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsNotMatchTestCase1NullCheck1()
        {
            "".IsNotMatch( null, RegexOptions.Multiline );
        }

        [Test]
        public void IsNotMatchTestCase2()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsNotMatch( emaiLpattern, RegexOptions.Compiled, 10.ToSeconds() );
            Assert.IsFalse( actual );

            actual = invalidEmail.IsNotMatch( emaiLpattern, RegexOptions.None, 10.ToSeconds() );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsNotMatchTestCase2NullCheck()
        {
            StringEx.IsNotMatch( null, "", RegexOptions.CultureInvariant, 10.ToSeconds() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsNotMatchTestCase2NullCheck1()
        {
            "".IsNotMatch( null, RegexOptions.Multiline, 10.ToSeconds() );
        }

        [Test]
        [ExpectedException( typeof (RegexMatchTimeoutException) )]
        public void IsNotMatchTestCase2TimeoutCheck()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = RandomValueEx.GetRandomStrings( 10000 )
                                          .StringJoin( Environment.NewLine );

            var actual = validEmail.IsNotMatch( emaiLpattern, RegexOptions.Multiline, 3.ToMilliseconds() );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsNotMatchTestCaseNullCheck()
        {
            StringEx.IsNotMatch( null, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsNotMatchTestCaseNullCheck1()
        {
            "".IsNotMatch( null );
        }
    }
}