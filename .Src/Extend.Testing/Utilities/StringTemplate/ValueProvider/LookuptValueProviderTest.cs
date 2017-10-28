#region Usings

using System;
using System.Collections.Generic;
using Extend.Internal;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing.Internal
{
    public class LookuptValueProviderTest
    {
        [Fact]
        public void CtorNullRefrenceTest()
        {
            // ReSharper disable once ObjectCreationAsStatement
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new LookuptValueProvider( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetValueFalseFormatTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyInt", DateTime.Now }
            };
            var target = new LookuptValueProvider( values );

            var actual = target.GetValue( "MyInt:DD" );
            actual.Should()
                  .Be( "DD" );
        }

        [Fact]
        public void GetValueMissingKeyTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyString", "asdf" }
            };
            var target = new LookuptValueProvider( values );

            Action test = () => target.GetValue( "MyInt" );
            test.ShouldThrow<FormatException>()
                .WithInnerException<KeyNotFoundException>();
        }

        [Fact]
        public void GetValueMissingKeyWithFormatTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyString", "asdf" }
            };
            var target = new LookuptValueProvider( values );

            Action test = () => target.GetValue( "MyInt:000" );
            test.ShouldThrow<FormatException>()
                .WithInnerException<KeyNotFoundException>();
        }

        [Fact]
        public void GetValueNoneStringTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyString", "asdf" },
                { "MyInt", 1234 }
            };
            var target = new LookuptValueProvider( values );

            var value = target.GetValue( "MyInt" );
            value.Should()
                 .Be( "1234" );
        }

        [Fact]
        public void GetValueNullValueTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyString", null }
            };
            var target = new LookuptValueProvider( values );

            var value = target.GetValue( "MyString" );
            value.Should()
                 .BeNull();
        }

        [Fact]
        public void GetValueNullValueWithFormatTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyString", null }
            };
            var target = new LookuptValueProvider( values );

            var value = target.GetValue( "MyString:00000" );
            value.Should()
                 .BeEmpty();
        }

        [Fact]
        public void GetValueTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyString", "asdf" }
            };
            var target = new LookuptValueProvider( values );

            var value = target.GetValue( "MyString" );
            value.Should()
                 .Be( "asdf" );
        }

        [Fact]
        public void GetValueWithFormatTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyString", "asdf" },
                { "MyInt", 1234 }
            };
            var target = new LookuptValueProvider( values );

            var value = target.GetValue( "MyInt:000000" );
            value.Should()
                 .Be( "001234" );
        }
    }
}