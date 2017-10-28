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
        public void ToDictionaryTest()
        {
            var list = new List<Tuple<Int32, String>>
            {
                new Tuple<Int32, String>( 1, "test1.1" ),
                new Tuple<Int32, String>( 1, "test1.2" ),
                new Tuple<Int32, String>( 1, "test1.3" ),
                new Tuple<Int32, String>( 2, "test2.1" ),
                new Tuple<Int32, String>( 2, "test2.2" ),
                new Tuple<Int32, String>( 2, "test2.3" ),
                new Tuple<Int32, String>( 3, "test3.1" ),
                new Tuple<Int32, String>( 3, "test3.2" ),
                new Tuple<Int32, String>( 3, "test3.3" )
            };

            var groups = list.GroupBy( x => x.Item1 );
            var actual = groups.ToDictionary();

            Assert.Equal( 3, actual.Count );

            Assert.Equal( 3,
                          actual[1]
                              .Count );
            Assert.Equal( 3,
                          actual[2]
                              .Count );
            Assert.Equal( 3,
                          actual[3]
                              .Count );
        }

        [Fact]
        public void ToDictionaryTestNullCheck()
        {
            IEnumerable<IGrouping<Object, Object>> groupings = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => groupings.ToDictionary();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}