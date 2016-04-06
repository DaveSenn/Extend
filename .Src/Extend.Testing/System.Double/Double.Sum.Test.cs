#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class DoubleExTest
    {
        [Test]
        public void SumTest()
        {
            var actual = 10.1d.Sum( 20.1, 30.1, 40.1, 50.1 );
            Assert.AreEqual( 150.5, actual );
        }

        [Test]
        public void SumTest1()
        {
            var actual = ( 10.5 as Double? ).Sum( 20.5, null, 40.5, null );
            Assert.AreEqual( 71.5, actual );

            actual = ( null as Double? ).Sum( new Double?[]
            {
                null,
                null
            } );
            Assert.AreEqual( 0d, actual );
        }

        [Test]
        public void SumTest1NullCheck()
        {
            Double?[] values = null;
            Action test = () => ( 10d as Double? ).Sum( values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTest2()
        {
            var actual = "test".Sum( x => (Double) x.Length, "a", "b", "c", "d" );
            Assert.AreEqual( 8d, actual );

            actual = "".Sum( x => x.Length, "a", "b", "c", "d" );
            Assert.AreEqual( 4d, actual );
        }

        [Test]
        public void SumTest2NullCheck()
        {
            String[] values = null;
            Action test = () => "Test".Sum( x => (Double) x.Length, values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTest2NullCheck2()
        {
            Func<String, Double> func = null;
            Action test = () => "Test".Sum( func, "test", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTest3()
        {
            var actual = "test".Sum( x => x.Length > 1d ? (Double?) x.Length : null, "a", "b", "c", "d" );
            Assert.AreEqual( 4d, actual );

            actual = "test".Sum( x => x.Length > 1d ? (Double?) x.Length : null, "aaaa", "b", "c", "d" );
            Assert.AreEqual( 8d, actual );
        }

        [Test]
        public void SumTest3NullCheck()
        {
            String[] values = null;
            Action test = () => "Test".Sum( x => (Double?) x.Length, values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTest3NullCheck2()
        {
            Func<String, Double?> func = null;
            Action test = () => "Test".Sum( func, "test", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTestNullCheck()
        {
            Double[] values = null;
            Action test = () => 10.1.Sum( values );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}