#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    
    public partial class TypeExTest
    {
        [Fact]
        public void GetImplementedInterfaces()
        {
            var actual = typeof(Dictionary<Int32, String>).GetImplementedInterfaces();
            actual.Should()
                  .HaveCount( 10 );
        }

        [Fact]
        public void GetImplementedInterfaces1()
        {
            var actual = typeof(TestType).GetImplementedInterfaces()
                                         .ToList();
            actual.Should()
                  .HaveCount( 1 );
            actual[0].Should()
                     .Be( typeof(ITest) );
        }

        [Fact]
        public void GetImplementedInterfaces2()
        {
            var actual = typeof(SecondTest).GetImplementedInterfaces()
                                           .ToList();
            actual.Should()
                  .HaveCount( 2 );
            actual[0].Should()
                     .Be( typeof(ISecondTest) );
            actual[1].Should()
                     .Be( typeof(ITest) );
        }

        [Fact]
        public void GetImplementedInterfaces3()
        {
            var actual = typeof(ThirdTest).GetImplementedInterfaces()
                                          .ToList();
            actual.Should()
                  .HaveCount( 3 );
            actual.Count( x => x == typeof(ITest) )
                  .Should()
                  .Be( 1 );
            actual.Count( x => x == typeof(ISecondTest) )
                  .Should()
                  .Be( 1 );
            actual.Count( x => x == typeof(IThirdTest) )
                  .Should()
                  .Be( 1 );
        }

        [Fact]
        public void GetImplementedInterfacesNullValueTest()
        {
            Type type = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => type.GetImplementedInterfaces();
            test.ShouldThrow<ArgumentNullException>();
        }

        private interface ITest
        {
        }

        private interface ISecondTest : ITest
        {
        }

        /// <summary>
        ///     Third test
        /// </summary>
        private interface IThirdTest
        {
        }

        public class TestType : ITest
        {
        }

        public class SecondTest : ISecondTest
        {
        }

        public class ThirdTest : IThirdTest, ISecondTest
        {
        }
    }
}