#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void SaveToBooleanTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = expected.ToString()
                                 .SaveToBoolean();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToBooleanTest1()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = "InvalidValue".SaveToBoolean( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToBooleanTest2()
        {
            var actual = true.ToString()
                             .SaveToBoolean( false );

            Assert.AreEqual( true, actual );
        }

        [Test]
        public void SaveToBooleanTest3()
        {
            var actual = "InvalidValue".SaveToBoolean();

            Assert.AreEqual( default(Boolean), actual );
        }

        [Test]
        public void SaveToBooleanTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.SaveToBoolean( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}