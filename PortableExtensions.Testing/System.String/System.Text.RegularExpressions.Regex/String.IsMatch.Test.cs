#region Using

using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void IsMatchTestCase()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsMatch( emaiLpattern );
            Assert.IsTrue( actual );

            actual = invalidEmail.IsMatch( emaiLpattern );
            Assert.IsFalse( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IsMatchTestCaseNullCheck()
        {
            StringEx.IsMatch( null, "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IsMatchTestCaseNullCheck1()
        {
            "".IsMatch( null );
        }

        [TestCase]
        public void IsMatchTestCase1()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsMatch( emaiLpattern, RegexOptions.Compiled );
            Assert.IsTrue( actual );

            actual = invalidEmail.IsMatch( emaiLpattern, RegexOptions.None );
            Assert.IsFalse( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IsMatchTestCase1NullCheck()
        {
            StringEx.IsMatch( null, "", RegexOptions.CultureInvariant );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IsMatchTestCase1NullCheck1()
        {
            "".IsMatch( null, RegexOptions.Multiline );
        }

        [TestCase]
        public void IsMatchTestCase2()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsMatch( emaiLpattern, RegexOptions.Compiled, 10.ToSeconds() );
            Assert.IsTrue( actual );

            actual = invalidEmail.IsMatch( emaiLpattern, RegexOptions.None, 10.ToSeconds() );
            Assert.IsFalse( actual );
        }

        //[TestCase]
        //[ExpectedException(typeof(RegexMatchTimeoutException))]
        //public void IsMatchTestCase2TimeoutCheck()
        //{
        //    var pattern = @"^[a-zA-Z0-9]*$";
        //    var validEmail = RandomValueEx.GetRandomStrings( 10000 ).StringJoin("").Replace( "-","" );

        //    StringEx.IsMatch(validEmail, pattern, RegexOptions.Singleline, 2.ToMilliseconds());
        //}

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IsMatchTestCase2NullCheck()
        {
            StringEx.IsMatch( null, "", RegexOptions.CultureInvariant, 10.ToSeconds() );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IsMatchTestCase2NullCheck1()
        {
            "".IsMatch( null, RegexOptions.Multiline, 10.ToSeconds() );
        }
    }
}