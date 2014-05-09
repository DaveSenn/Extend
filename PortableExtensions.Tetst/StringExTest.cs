using NUnit.Framework;
using System;
using TestingHelper;

namespace PortableExtensions.Tetst
{
    [TestFixture]
    public class StringExTest
    {
        [Test]
        public void IsEmptyTest()
        {
            Assert.IsTrue ( StringEx.IsEmpty ( "" ) );
            Assert.IsTrue ( StringEx.IsEmpty ( null ) );
            Assert.IsTrue ( StringEx.IsEmpty ( "  " ) );

            Assert.IsFalse ( StringEx.IsEmpty ( "." ) );
            Assert.IsFalse ( StringEx.IsEmpty ( ".  ." ) );
        }

        [Test]
        public void IsNotEmptyTest()
        {
            Assert.IsFalse ( StringEx.IsNotEmpty ( "" ) );
            Assert.IsFalse ( StringEx.IsNotEmpty ( null ) );
            Assert.IsFalse ( StringEx.IsNotEmpty ( "  " ) );

            Assert.IsTrue ( StringEx.IsNotEmpty ( "." ) );
            Assert.IsTrue ( StringEx.IsNotEmpty ( ".  ." ) );
        }

        [Test]
        public void FormatTest()
        {
            var valueInt = RandomEx.GetRandomInt ();
            var valueString = Guid.NewGuid ().ToString ();

            Assert.AreEqual ( "Test:", String.Format ( "Test:" ) );
            Assert.AreEqual ( String.Format ( "Test: {0}", valueInt ), String.Format ( "Test: {0}", valueInt ) );
            Assert.AreEqual ( String.Format ( "Test: {0} - {1}", valueInt, valueString ), String.Format ( "Test: {0} - {1}", valueInt, valueString ) );

            Assert.AreEqual ( String.Format ( "Test: {0} - {0} End", valueInt ), String.Format ( "Test: {0} - {0} End", valueInt ) );
            Assert.AreEqual ( String.Format ( "Test: {1} - {1} End", valueInt, valueString ), String.Format ( "Test: {1} - {1} End", valueInt, valueString ) );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void FormatTestNullCheck()
        {
            StringEx.Format ( null, 10, 11, 12 );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void FormatTestNullCheck1()
        {
            StringEx.Format ( "", null );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void FormatTestNullCheck2()
        {
            StringEx.Format ( null, null );
        }

        [Test]
        public void SafeToIntTest()
        {
            var value = "10";
            Assert.AreEqual ( 10, StringEx.SafeToInt ( value ) );

            value = Int32.MinValue.ToString ();
            Assert.AreEqual ( Int32.MinValue, StringEx.SafeToInt ( value ) );

            value = Int32.MaxValue.ToString ();
            Assert.AreEqual ( Int32.MaxValue, StringEx.SafeToInt ( value ) );

            value = "test";
            Assert.AreEqual ( null, StringEx.SafeToInt ( value ) );

            value = "";
            Assert.AreEqual ( null, StringEx.SafeToInt ( value ) );
        }

        [Test]
        public void IsMatchTest()
        {
            Assert.IsTrue ( StringEx.IsMatch ( "12", @"\d{2}" ) );
            Assert.IsFalse ( StringEx.IsMatch ( "test", @"\d{2}" ) );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void IsMatchTestNUllCheck()
        {
            StringEx.IsMatch ( null, "%d" );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void IsMatchTestNUllCheck1()
        {
            StringEx.IsMatch ( "test", null );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void IsMatchTestNUllCheck2()
        {
            StringEx.IsMatch ( null, null );
        }

        [Test]
        public void IsNotMatchTest()
        {
            Assert.IsTrue ( StringEx.IsNotMatch ( "test", @"\d{2}" ) );
            Assert.IsFalse ( StringEx.IsNotMatch ( "12", @"\d{2}" ) );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void IsNotMatchTestNUllCheck()
        {
            StringEx.IsNotMatch ( null, "%d" );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void IsNotMatchTestNUllCheck1()
        {
            StringEx.IsNotMatch ( "test", null );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void IsNotMatchTestNUllCheck2()
        {
            StringEx.IsNotMatch ( null, null );
        }
    }
}