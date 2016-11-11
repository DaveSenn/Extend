#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Internal.Testing
{
    [TestFixture]
    public class LookuptValueProviderTest
    {
        [Test]
        public void CtorNullRefrenceTest()
        {
            // ReSharper disable once ObjectCreationAsStatement
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new LookuptValueProvider( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
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

        [Test]
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

        [Test]
        public void GetValueNullValueTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyString", null }
            };
            var target = new LookuptValueProvider(values);

            var value = target.GetValue("MyString");
            value.Should()
                 .BeNull();
        }

        [Test]
        public void GetValueNullValueWithFormatTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyString", null }
            };
            var target = new LookuptValueProvider(values);

            var value = target.GetValue("MyString:00000");
            value.Should()
                 .BeEmpty();
        }

        [Test]
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

        [Test]
        public void GetValueMissingKeyTest()
        {
            var values = new Dictionary<String, Object>
            {
                { "MyString", "asdf" }
            };
            var target = new LookuptValueProvider(values);

            Action test = () => target.GetValue("MyInt");
            test.ShouldThrow<FormatException>()
                .WithInnerException<KeyNotFoundException>();
        }
    }
}