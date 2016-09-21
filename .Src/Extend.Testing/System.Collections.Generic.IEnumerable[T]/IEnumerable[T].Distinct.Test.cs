#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Test]
        public void DistinctTest()
        {
            var list = new List<KeyValuePair<String, String>>
            {
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test" ),
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test" ),
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test1" ),
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test1" ),
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test2" ),
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test2" )
            };

            var actual = list.Distinct( x => x.Value )
                             .ToList();
            Assert.AreEqual( 3, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Value == "Test" ) );
            Assert.AreEqual( 1, actual.Count( x => x.Value == "Test1" ) );
            Assert.AreEqual( 1, actual.Count( x => x.Value == "Test2" ) );
        }

        [Test]
        public void DistinctTestNullCheck()
        {
            List<KeyValuePair<Object, Object>> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.Distinct( x => x.Value );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void DistinctTestNullCheck1()
        {
            Func<Object, Boolean> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().Distinct( func );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}