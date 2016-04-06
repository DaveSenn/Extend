#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ExecuteSafeTest()
        {
            var expectedValue = RandomValueEx.GetRandomString();
            var actual = expectedValue.ExecuteSafe( x => { throw new InvalidOperationException( expectedValue ); } );

            Assert.IsNull( actual.Result );
            Assert.IsNotNull( actual.Exception );
            Assert.AreEqual( expectedValue, actual.Exception.Message );

            var list = new List<String>();
            Assert.IsTrue( list.NotAny() );
            actual = expectedValue.ExecuteSafe( list.Add );

            Assert.IsNull( actual.Exception );
            Assert.AreEqual( expectedValue, actual.Result );
            Assert.AreEqual( list[0], expectedValue );
        }

        [Test]
        public void ExecuteSafeTest1()
        {
            var expectedValue = RandomValueEx.GetRandomString();
            var actual = expectedValue.ExecuteSafe( x =>
            {
                if ( expectedValue.Length > 0 )
                    throw new InvalidOperationException( expectedValue );
                return expectedValue;
            } );

            Assert.IsNull( actual.Result );
            Assert.IsNotNull( actual.Exception );
            Assert.AreEqual( expectedValue, actual.Exception.Message );

            actual = expectedValue.ExecuteSafe( x => expectedValue );

            Assert.IsNull( actual.Exception );
            Assert.AreEqual( actual.Result, expectedValue );
        }

        [Test]
        public void ExecuteSafeTest1NullCheck()
        {
            Func<String, String> func = null;
            Action test = () => "".ExecuteSafe( func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteSafeTestNullCheck()
        {
            Action<String> action = null;
            Action test = () => "".ExecuteSafe( action );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}