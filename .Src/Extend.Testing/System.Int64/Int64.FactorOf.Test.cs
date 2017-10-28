#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int64ExTest
    {
        [Fact]
        public void FactorOfDivideByZeroTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => Int64Ex.FactorOf( 0, 100 );
            test.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void FactorOfTest()
        {
            var value = RandomValueEx.GetRandomInt32();
            var factorNumer = RandomValueEx.GetRandomInt32();

            var expected = factorNumer % value == 0;
            var actual = Int64Ex.FactorOf( value, factorNumer );
            actual
                .Should()
                .Be( expected );

            actual = Int64Ex.FactorOf( 10, 100 );
            actual
                .Should()
                .Be( true );

            actual = Int64Ex.FactorOf( 100, 10 );
            actual
                .Should()
                .Be( false );

            actual = Int64Ex.FactorOf( 11, 100 );
            actual
                .Should()
                .Be( false );
        }
    }
}