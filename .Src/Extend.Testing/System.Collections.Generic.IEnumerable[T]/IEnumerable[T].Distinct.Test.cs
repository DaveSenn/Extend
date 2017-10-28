#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
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
            Assert.Equal( 3, actual.Count );
            Assert.Equal( 1, actual.Count( x => x.Value == "Test" ) );
            Assert.Equal( 1, actual.Count( x => x.Value == "Test1" ) );
            Assert.Equal( 1, actual.Count( x => x.Value == "Test2" ) );
        }

        [Fact]
        public void DistinctTestNullCheck()
        {
            List<KeyValuePair<Object, Object>> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.Distinct( x => x.Value );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
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