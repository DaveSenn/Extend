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
    public partial class IDictionaryExTest
    {
        [Fact]
        public void StringJoinTest()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var actual = dictionary.StringJoin();
            var expected = "{0}={1}{2}={3}".F( dictionary.First()
                                                         .Key,
                                               dictionary.First()
                                                         .Value,
                                               dictionary.Last()
                                                         .Key,
                                               dictionary.Last()
                                                         .Value );
            Assert.Equal( expected, actual );

            actual = dictionary.StringJoin( ",", ";" );
            expected = "{0},{1};{2},{3}".F( dictionary.First()
                                                      .Key,
                                            dictionary.First()
                                                      .Value,
                                            dictionary.Last()
                                                      .Key,
                                            dictionary.Last()
                                                      .Value );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void StringJoinTestNullCheck()
        {
            Dictionary<String, String> dictionary = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => dictionary.StringJoin( "" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}