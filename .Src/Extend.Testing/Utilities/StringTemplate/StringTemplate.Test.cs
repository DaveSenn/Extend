#region Usings

using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class StringTemplate
    {
        #region Ctor

        public StringTemplate()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo( "de-CH" );
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo( "de-CH" );
        }

        #endregion

        [Fact]
        public void FormatWithObject_ComplexTemplate()
        {
            var actual =
                "{{{{123}} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} {MyInt:000000} {MyInt:#-##-#} | MyString: {MyString} | MyDouble: {MyDouble} | MyNull: {MyNull}"
                    .FormatWithObject( new { MyInt = 1234, MyString = "asdf", MyDouble = 12345.987654, Ignore = "asd", MyNull = (String) null } );
            actual.Should()
                  .Be( "{{123} bla} | Ignore: {Ignore} | MyInt: 1234 001234 1-23-4 | MyString: asdf | MyDouble: 12345.987654 | MyNull: " );
        }

        [Fact]
        public void FormatWithObject_ComplexTemplate_InvalidFormat()
        {
            Action test =
                () =>
                    "{{{{123} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} {MyInt:000000} {MyInt:#-##-#} | MyString: {MyString} | MyDouble: {MyDouble} {MyDouble:C} | MyNull: {MyNull}"
                        .FormatWithObject( new { MyInt = 1234, MyString = "asdf", MyDouble = 12345.987654, Ignore = "asd", MyNull = (String) null } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_ComplexTemplate_InvalidFormat1()
        {
            Action test =
                () =>
                    "{{{{123}} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} MyInt:000000} {MyInt:#-##-#} | MyString: {MyString} | MyDouble: {MyDouble} {MyDouble:C} | MyNull: {MyNull}"
                        .FormatWithObject( new { MyInt = 1234, MyString = "asdf", MyDouble = 12345.987654, Ignore = "asd", MyNull = (String) null } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_ComplexTemplate_InvalidFormat2()
        {
            Action test =
                () =>
                    "{{{{123}} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} {MyInt:00000}0} {MyInt:#-##-#} | MyString: {MyString} | MyDouble: {MyDouble} {MyDouble:C} | MyNull: {MyNull}"
                        .FormatWithObject( new { MyInt = 1234, MyString = "asdf", MyDouble = 12345.987654, Ignore = "asd", MyNull = (String) null } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_ComplexTemplate_InvalidFormat3()
        {
            Action test =
                () =>
                    "{{{{123}} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} {MyInt:00{0}000} {MyInt:#-##-#} | MyString: {MyString} | MyDouble: {MyDouble} {MyDouble:C} | MyNull: {MyNull}"
                        .FormatWithObject( new { MyInt = 1234, MyString = "asdf", MyDouble = 12345.987654, Ignore = "asd", MyNull = (String) null } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_ComplexTemplate_InvalidFormat4()
        {
            Action test =
                () =>
                    "{{{{123}} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} {MyInt:000000} {MyInt:#-##-#} | MyString: {MyString} | {MyDo}uble: {MyDouble} {MyDouble:C} | MyNull: {MyNull}"
                        .FormatWithObject( new { MyInt = 1234, MyString = "asdf", MyDouble = 12345.987654, Ignore = "asd", MyNull = (String) null } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_FormatInvalid()
        {
            Action test = () => "{{[]}}{{bar}{foo}}".FormatWithObject( new { foo = 123.45, bar = "asd", MyInt = 123434 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_FormatInvalid1()
        {
            Action test = () => "{{[]}}{bar}{foo}}{MyInt:0000}{".FormatWithObject( new { foo = 123.45, bar = "asd", MyInt = 123434 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_FormatInvalid2()
        {
            Action test = () => "}{{[]}}{bar}{foo}}{MyInt:0000}".FormatWithObject( new { foo = 123.45, bar = "asd", MyInt = 123434 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_FormatInvalid3()
        {
            Action test = () => "{{[]}}{bar}{foo}{MyInt:0000}{{}{bar}".FormatWithObject( new { foo = 123.45, bar = "asd", MyInt = 123434 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_WithDoubleEscapedCurlyBraces_DoesNotFormatString()
        {
            var actual = "{{{{foo}}}}".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "{{foo}}" );
        }

        [Fact]
        public void FormatWithObject_WithDoubleEscapedEndFormatBrace()
        {
            Action test = () => "{foo}}}}bar".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_WithDoubleEscapedEndFormatBraceWhichTerminatesString()
        {
            Action test = () => "{foo}}}}".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_WithEmptyString_ReturnsEmptyString()
        {
            var actual = "".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "" );
        }

        [Fact]
        public void FormatWithObject_WithEndBraceFollowedByDoubleEscapedEndFormatBrace_FormatsCorrectly()
        {
            var actual = "{foo}}}}}bar".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "123.45}}bar" );
        }

        [Fact]
        public void FormatWithObject_WithEndBraceFollowedByEscapedEndFormatBrace_FormatsCorrectly()
        {
            var actual = "{foo}}}bar".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "123.45}bar" );
        }

        [Fact]
        public void FormatWithObject_WithEndBraceFollowedByEscapedEndFormatBraceWhichTerminatesString_FormatsCorrectly()
        {
            var actual = "{foo}}}".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "123.45}" );
        }

        [Fact]
        public void FormatWithObject_WithEscapedCloseBraces_CollapsesDoubleBraces()
        {
            var actual = "hello}}world".FormatWithObject( new Object() );
            actual.Should()
                  .Be( "hello}world" );
        }

        [Fact]
        public void FormatWithObject_WithEscapedEndFormatBrace()
        {
            Action test = () => "{foo}}".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_WithEscapedOpenBraces_CollapsesDoubleBraces()
        {
            var actual = "hello{{world".FormatWithObject( new Object() );
            actual.Should()
                  .Be( "hello{world" );
        }

        [Fact]
        public void FormatWithObject_WithEscapeSequence_EscapesInnerCurlyBraces()
        {
            var actual = "{{{foo}}}".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "{123.45}" );
        }

        [Fact]
        public void FormatWithObject_WithExpressionReturningNull()
        {
            var actual = "{foo}".FormatWithObject( new { foo = (Object) null } );
            actual.Should()
                  .Be( "" );
        }

        [Fact]
        public void FormatWithObject_WithFormatExpressionNotComplete()
        {
            Action test = () => "{bar".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_WithFormatExpressionNotComplete1()
        {
            Action test = () => "{".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_WithFormatExpressionNotStarted()
        {
            Action test = () => "foo}".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_WithFormatExpressionNotStarted1()
        {
            Action test = () => "}".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_WithFormatNameNotInObject()
        {
            Action test = () => "{bar}".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_WithFormatSurroundedByDoubleEscapedBraces_FormatsString()
        {
            var actual = "{{{{{foo}}}}}".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "{{123.45}}" );
        }

        [Fact]
        public void FormatWithObject_WithFormatType_ReturnsFormattedExpression()
        {
            var actual = "{foo:#.#}".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "123.5" );
        }

        [Fact]
        public void FormatWithObject_WithMultipleExpressions_FormatsThemAll()
        {
            var actual = "{foo} {foo} {bar}{baz}".FormatWithObject( new { foo = 123.45, bar = 42, baz = "hello" } );
            actual.Should()
                  .Be( "123.45 123.45 42hello" );
        }

        [Fact]
        public void FormatWithObject_WithNamedExpression_EvalsPropertyOfExpression()
        {
            var actual = "{foo}".FormatWithObject( new { foo = 123 } );
            actual.Should()
                  .Be( "123" );
        }

        [Fact]
        public void FormatWithObject_WithNamedExpressionAndFormatWithObject_EvalsPropertyOfExpression()
        {
            var actual = "{foo:#.##}".FormatWithObject( new { foo = 1.23456 } );
            actual.Should()
                  .Be( "1.23" );
        }

        [Fact]
        public void FormatWithObject_WithNoEndFormatBrace()
        {
            Action test = () => "{bar".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithObject_WithNoFormats_ReturnsFormatStringAsIs()
        {
            var actual = "a b c".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "a b c" );
        }

        [Fact]
        public void FormatWithObject_WithNullFormatString_ThrowsArgumentNullException()
        {
            String format = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => format.FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FormatWithObject_WithSubProperty_ReturnsValueOfSubProperty()
        {
            var actual = "{foo.bar:#.#}ms".FormatWithObject( new { foo = new { bar = 123.45 } } );
            actual.Should()
                  .Be( "123.5ms" );
        }

        [Fact]
        public void FormatWithValues_ComplexTemplate()
        {
            var actual = "{{{{123}} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} {MyInt:000000} {MyInt:#-##-#} | MyString: {MyString} | MyDouble: {MyDouble} | MyNull: {MyNull}"
                .FormatWithValues( new Dictionary<String, Object>
                {
                    { "MyInt", 1234 },
                    { "MyString", "asdf" },
                    { "MyDouble", 12345.987654 },
                    { "Ignore", "asd" },
                    // ReSharper disable once RedundantCast
                    { "MyNull", (String) null }
                } );
            actual.Should()
                  .Be( "{{123} bla} | Ignore: {Ignore} | MyInt: 1234 001234 1-23-4 | MyString: asdf | MyDouble: 12345.987654 | MyNull: " );
        }

        [Fact]
        public void FormatWithValues_ComplexTemplate_InvalidFormat1()
        {
            Action test =
                () =>
                    "{{{{123}} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} MyInt:000000} {MyInt:#-##-#} | MyString: {MyString} | MyDouble: {MyDouble} {MyDouble:C} | MyNull: {MyNull}"
                        .FormatWithValues( new Dictionary<String, Object>
                        {
                            { "MyInt", 1234 },
                            { "MyString", "asdf" },
                            { "MyDouble", 12345.987654 },
                            { "Ignore", "asd" },
                            // ReSharper disable once RedundantCast
                            { "MyNull", (String) null }
                        } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_ComplexTemplate_InvalidFormat2()
        {
            Action test =
                () =>
                    "{{{{123}} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} {MyInt:00000}0} {MyInt:#-##-#} | MyString: {MyString} | MyDouble: {MyDouble} {MyDouble:C} | MyNull: {MyNull}"
                        .FormatWithValues( new Dictionary<String, Object>
                        {
                            { "MyInt", 1234 },
                            { "MyString", "asdf" },
                            { "MyDouble", 12345.987654 },
                            { "Ignore", "asd" },
                            // ReSharper disable once RedundantCast
                            { "MyNull", (String) null }
                        } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_ComplexTemplate_InvalidFormat3()
        {
            Action test =
                () =>
                    "{{{{123}} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} {MyInt:00{0}000} {MyInt:#-##-#} | MyString: {MyString} | MyDouble: {MyDouble} {MyDouble:C} | MyNull: {MyNull}"
                        .FormatWithValues( new Dictionary<String, Object>
                        {
                            { "MyInt", 1234 },
                            { "MyString", "asdf" },
                            { "MyDouble", 12345.987654 },
                            { "Ignore", "asd" },
                            // ReSharper disable once RedundantCast
                            { "MyNull", (String) null }
                        } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_ComplexTemplate_InvalidFormat4()
        {
            Action test =
                () =>
                    "{{{{123}} bla}} | Ignore: {{Ignore}} | MyInt: {MyInt} {MyInt:000000} {MyInt:#-##-#} | MyString: {MyString} | {MyDo}uble: {MyDouble} {MyDouble:C} | MyNull: {MyNull}"
                        .FormatWithValues( new Dictionary<String, Object>
                        {
                            { "MyInt", 1234 },
                            { "MyString", "asdf" },
                            { "MyDouble", 12345.987654 },
                            { "Ignore", "asd" },
                            // ReSharper disable once RedundantCast
                            { "MyNull", (String) null }
                        } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_FormatInvalid()
        {
            Action test = () => "{{[]}}{{bar}{foo}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 }, { "bar", "asd" }, { "MyInt", 123434 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_FormatInvalid1()
        {
            Action test = () => "{{[]}}{bar}{foo}}{MyInt:0000}{".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 }, { "bar", "asd" }, { "MyInt", 123434 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_FormatInvalid2()
        {
            Action test = () => "}{{[]}}{bar}{foo}}{MyInt:0000}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 }, { "bar", "asd" }, { "MyInt", 123434 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_FormatInvalid3()
        {
            Action test =
                () => "{{[]}}{bar}{foo}{MyInt:0000}{{}{bar}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 }, { "bar", "asd" }, { "MyInt", 123434 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_WithDoubleEscapedCurlyBraces_DoesNotFormatString()
        {
            var actual = "{{{{foo}}}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "{{foo}}" );
        }

        [Fact]
        public void FormatWithValues_WithDoubleEscapedEndFormatBrace()
        {
            Action test = () => "{foo}}}}bar".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_WithDoubleEscapedEndFormatBraceWhichTerminatesString()
        {
            Action test = () => "{foo}}}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_WithEmptyString_ReturnsEmptyString()
        {
            var actual = "".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "" );
        }

        [Fact]
        public void FormatWithValues_WithEndBraceFollowedByDoubleEscapedEndFormatBrace_FormatsCorrectly()
        {
            var actual = "{foo}}}}}bar".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "123.45}}bar" );
        }

        [Fact]
        public void FormatWithValues_WithEndBraceFollowedByEscapedEndFormatBrace_FormatsCorrectly()
        {
            var actual = "{foo}}}bar".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "123.45}bar" );
        }

        [Fact]
        public void FormatWithValues_WithEndBraceFollowedByEscapedEndFormatBraceWhichTerminatesString_FormatsCorrectly()
        {
            var actual = "{foo}}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "123.45}" );
        }

        [Fact]
        public void FormatWithValues_WithEscapedCloseBraces_CollapsesDoubleBraces()
        {
            var actual = "hello}}world".FormatWithValues( new Dictionary<String, Object>() );
            actual.Should()
                  .Be( "hello}world" );
        }

        [Fact]
        public void FormatWithValues_WithEscapedEndFormatBrace()
        {
            Action test = () => "{foo}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_WithEscapedOpenBraces_CollapsesDoubleBraces()
        {
            var actual = "hello{{world".FormatWithValues( new Dictionary<String, Object>() );
            actual.Should()
                  .Be( "hello{world" );
        }

        [Fact]
        public void FormatWithValues_WithEscapeSequence_EscapesInnerCurlyBraces()
        {
            var actual = "{{{foo}}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "{123.45}" );
        }

        [Fact]
        public void FormatWithValues_WithExpressionReturningNull()
        {
            var actual = "{foo}".FormatWithValues( new Dictionary<String, Object> { { "foo", null } } );
            actual.Should()
                  .Be( "" );
        }

        [Fact]
        public void FormatWithValues_WithFormatExpressionNotComplete()
        {
            Action test = () => "{bar".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_WithFormatExpressionNotComplete1()
        {
            Action test = () => "{".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_WithFormatExpressionNotStarted()
        {
            Action test = () => "foo}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_WithFormatExpressionNotStarted1()
        {
            Action test = () => "}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_WithFormatNameNotInObject()
        {
            Action test = () => "{bar}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_WithFormatSurroundedByDoubleEscapedBraces_FormatsString()
        {
            var actual = "{{{{{foo}}}}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "{{123.45}}" );
        }

        [Fact]
        public void FormatWithValues_WithFormatType_ReturnsFormattedExpression()
        {
            var actual = "{foo:#.#}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "123.5" );
        }

        [Fact]
        public void FormatWithValues_WithMultipleExpressions_FormatsThemAll()
        {
            var actual = "{foo} {foo} {bar}{baz}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 }, { "bar", 42 }, { "baz", "hello" } } );
            actual.Should()
                  .Be( "123.45 123.45 42hello" );
        }

        [Fact]
        public void FormatWithValues_WithNamedExpression_EvalsPropertyOfExpression()
        {
            var actual = "{foo}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123 } } );
            actual.Should()
                  .Be( "123" );
        }

        [Fact]
        public void FormatWithValues_WithNamedExpressionAndFormatWithValues_EvalsPropertyOfExpression()
        {
            var actual = "{foo:#.##}".FormatWithValues( new Dictionary<String, Object> { { "foo", 1.23456 } } );
            actual.Should()
                  .Be( "1.23" );
        }

        [Fact]
        public void FormatWithValues_WithNoEndFormatBrace()
        {
            Action test = () => "{bar".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void FormatWithValues_WithNoFormats_ReturnsFormatStringAsIs()
        {
            var actual = "a b c".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "a b c" );
        }

        [Fact]
        public void FormatWithValues_WithNullFormatString_ThrowsArgumentNullException()
        {
            String format = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => format.FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}