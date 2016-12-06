#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class StringTemplate
    {
        [Test]
        public void FormatWithObject_FormatInvalid()
        {
            Action test = () => "{{[]}}{{bar}{foo}}".FormatWithObject( new { foo = 123.45, bar = "asd", MyInt = 123434 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_FormatInvalid1()
        {
            Action test = () => "{{[]}}{bar}{foo}}{MyInt:0000}{".FormatWithObject( new { foo = 123.45, bar = "asd", MyInt = 123434 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_FormatInvalid2()
        {
            Action test = () => "}{{[]}}{bar}{foo}}{MyInt:0000}".FormatWithObject( new { foo = 123.45, bar = "asd", MyInt = 123434 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_FormatInvalid3()
        {
            Action test = () => "{{[]}}{bar}{foo}{MyInt:0000}{{}{bar}".FormatWithObject( new { foo = 123.45, bar = "asd", MyInt = 123434 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_WithDoubleEscapedCurlyBraces_DoesNotFormatString()
        {
            var actual = "{{{{foo}}}}".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "{{foo}}" );
        }

        [Test]
        public void FormatWithObject_WithDoubleEscapedEndFormatBrace()
        {
            Action test = () => "{foo}}}}bar".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_WithDoubleEscapedEndFormatBraceWhichTerminatesString()
        {
            Action test = () => "{foo}}}}".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_WithEmptyString_ReturnsEmptyString()
        {
            var actual = "".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "" );
        }

        [Test]
        public void FormatWithObject_WithEndBraceFollowedByDoubleEscapedEndFormatBrace_FormatsCorrectly()
        {
            var actual = "{foo}}}}}bar".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "123.45}}bar" );
        }

        [Test]
        public void FormatWithObject_WithEndBraceFollowedByEscapedEndFormatBrace_FormatsCorrectly()
        {
            var actual = "{foo}}}bar".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "123.45}bar" );
        }

        [Test]
        public void FormatWithObject_WithEndBraceFollowedByEscapedEndFormatBraceWhichTerminatesString_FormatsCorrectly()
        {
            var actual = "{foo}}}".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "123.45}" );
        }

        [Test]
        public void FormatWithObject_WithEscapedCloseBraces_CollapsesDoubleBraces()
        {
            var actual = "hello}}world".FormatWithObject( new Object() );
            actual.Should()
                  .Be( "hello}world" );
        }

        [Test]
        public void FormatWithObject_WithEscapedEndFormatBrace()
        {
            Action test = () => "{foo}}".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_WithEscapedOpenBraces_CollapsesDoubleBraces()
        {
            var actual = "hello{{world".FormatWithObject( new Object() );
            actual.Should()
                  .Be( "hello{world" );
        }

        [Test]
        public void FormatWithObject_WithEscapeSequence_EscapesInnerCurlyBraces()
        {
            var actual = "{{{foo}}}".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "{123.45}" );
        }

        [Test]
        public void FormatWithObject_WithExpressionReturningNull()
        {
            var actual = "{foo}".FormatWithObject( new { foo = (Object) null } );
            actual.Should()
                  .Be( "" );
        }

        [Test]
        public void FormatWithObject_WithFormatExpressionNotComplete()
        {
            Action test = () => "{bar".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_WithFormatExpressionNotComplete1()
        {
            Action test = () => "{".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_WithFormatExpressionNotStarted()
        {
            Action test = () => "foo}".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_WithFormatExpressionNotStarted1()
        {
            Action test = () => "}".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_WithFormatNameNotInObject()
        {
            Action test = () => "{bar}".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_WithFormatSurroundedByDoubleEscapedBraces_FormatsString()
        {
            var actual = "{{{{{foo}}}}}".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "{{123.45}}" );
        }

        [Test]
        public void FormatWithObject_WithFormatType_ReturnsFormattedExpression()
        {
            var actual = "{foo:#.#}".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "123.5" );
        }

        [Test]
        public void FormatWithObject_WithMultipleExpressions_FormatsThemAll()
        {
            var actual = "{foo} {foo} {bar}{baz}".FormatWithObject( new { foo = 123.45, bar = 42, baz = "hello" } );
            actual.Should()
                  .Be( "123.45 123.45 42hello" );
        }

        [Test]
        public void FormatWithObject_WithNamedExpression_EvalsPropertyOfExpression()
        {
            var actual = "{foo}".FormatWithObject( new { foo = 123 } );
            actual.Should()
                  .Be( "123" );
        }

        [Test]
        public void FormatWithObject_WithNamedExpressionAndFormatWithObject_EvalsPropertyOfExpression()
        {
            var actual = "{foo:#.##}".FormatWithObject( new { foo = 1.23456 } );
            actual.Should()
                  .Be( "1.23" );
        }

        [Test]
        public void FormatWithObject_WithNoEndFormatBrace()
        {
            Action test = () => "{bar".FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithObject_WithNoFormats_ReturnsFormatStringAsIs()
        {
            var actual = "a b c".FormatWithObject( new { foo = 123.45 } );
            actual.Should()
                  .Be( "a b c" );
        }

        [Test]
        public void FormatWithObject_WithNullFormatString_ThrowsArgumentNullException()
        {
            String format = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => format.FormatWithObject( new { foo = 123.45 } );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void FormatWithObject_WithSubProperty_ReturnsValueOfSubProperty()
        {
            var actual = "{foo.bar:#.#}ms".FormatWithObject( new { foo = new { bar = 123.45 } } );
            actual.Should()
                  .Be( "123.5ms" );
        }

        [Test]
        public void FormatWithValues_FormatInvalid()
        {
            Action test = () => "{{[]}}{{bar}{foo}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 }, { "bar", "asd" }, { "MyInt", 123434 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_FormatInvalid1()
        {
            Action test = () => "{{[]}}{bar}{foo}}{MyInt:0000}{".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 }, { "bar", "asd" }, { "MyInt", 123434 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_FormatInvalid2()
        {
            Action test = () => "}{{[]}}{bar}{foo}}{MyInt:0000}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 }, { "bar", "asd" }, { "MyInt", 123434 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_FormatInvalid3()
        {
            Action test =
                () => "{{[]}}{bar}{foo}{MyInt:0000}{{}{bar}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 }, { "bar", "asd" }, { "MyInt", 123434 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_WithDoubleEscapedCurlyBraces_DoesNotFormatString()
        {
            var actual = "{{{{foo}}}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "{{foo}}" );
        }

        [Test]
        public void FormatWithValues_WithDoubleEscapedEndFormatBrace()
        {
            Action test = () => "{foo}}}}bar".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_WithDoubleEscapedEndFormatBraceWhichTerminatesString()
        {
            Action test = () => "{foo}}}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_WithEmptyString_ReturnsEmptyString()
        {
            var actual = "".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "" );
        }

        [Test]
        public void FormatWithValues_WithEndBraceFollowedByDoubleEscapedEndFormatBrace_FormatsCorrectly()
        {
            var actual = "{foo}}}}}bar".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "123.45}}bar" );
        }

        [Test]
        public void FormatWithValues_WithEndBraceFollowedByEscapedEndFormatBrace_FormatsCorrectly()
        {
            var actual = "{foo}}}bar".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "123.45}bar" );
        }

        [Test]
        public void FormatWithValues_WithEndBraceFollowedByEscapedEndFormatBraceWhichTerminatesString_FormatsCorrectly()
        {
            var actual = "{foo}}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "123.45}" );
        }

        [Test]
        public void FormatWithValues_WithEscapedCloseBraces_CollapsesDoubleBraces()
        {
            var actual = "hello}}world".FormatWithValues( new Dictionary<String, Object>() );
            actual.Should()
                  .Be( "hello}world" );
        }

        [Test]
        public void FormatWithValues_WithEscapedEndFormatBrace()
        {
            Action test = () => "{foo}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_WithEscapedOpenBraces_CollapsesDoubleBraces()
        {
            var actual = "hello{{world".FormatWithValues( new Dictionary<String, Object>() );
            actual.Should()
                  .Be( "hello{world" );
        }

        [Test]
        public void FormatWithValues_WithEscapeSequence_EscapesInnerCurlyBraces()
        {
            var actual = "{{{foo}}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "{123.45}" );
        }

        [Test]
        public void FormatWithValues_WithExpressionReturningNull()
        {
            var actual = "{foo}".FormatWithValues( new Dictionary<String, Object> { { "foo", null } } );
            actual.Should()
                  .Be( "" );
        }

        [Test]
        public void FormatWithValues_WithFormatExpressionNotComplete()
        {
            Action test = () => "{bar".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_WithFormatExpressionNotComplete1()
        {
            Action test = () => "{".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_WithFormatExpressionNotStarted()
        {
            Action test = () => "foo}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_WithFormatExpressionNotStarted1()
        {
            Action test = () => "}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_WithFormatNameNotInObject()
        {
            Action test = () => "{bar}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_WithFormatSurroundedByDoubleEscapedBraces_FormatsString()
        {
            var actual = "{{{{{foo}}}}}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "{{123.45}}" );
        }

        [Test]
        public void FormatWithValues_WithFormatType_ReturnsFormattedExpression()
        {
            var actual = "{foo:#.#}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "123.5" );
        }

        [Test]
        public void FormatWithValues_WithMultipleExpressions_FormatsThemAll()
        {
            var actual = "{foo} {foo} {bar}{baz}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 }, { "bar", 42 }, { "baz", "hello" } } );
            actual.Should()
                  .Be( "123.45 123.45 42hello" );
        }

        [Test]
        public void FormatWithValues_WithNamedExpression_EvalsPropertyOfExpression()
        {
            var actual = "{foo}".FormatWithValues( new Dictionary<String, Object> { { "foo", 123 } } );
            actual.Should()
                  .Be( "123" );
        }

        [Test]
        public void FormatWithValues_WithNamedExpressionAndFormatWithValues_EvalsPropertyOfExpression()
        {
            var actual = "{foo:#.##}".FormatWithValues( new Dictionary<String, Object> { { "foo", 1.23456 } } );
            actual.Should()
                  .Be( "1.23" );
        }

        [Test]
        public void FormatWithValues_WithNoEndFormatBrace()
        {
            Action test = () => "{bar".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void FormatWithValues_WithNoFormats_ReturnsFormatStringAsIs()
        {
            var actual = "a b c".FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            actual.Should()
                  .Be( "a b c" );
        }

        [Test]
        public void FormatWithValues_WithNullFormatString_ThrowsArgumentNullException()
        {
            String format = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => format.FormatWithValues( new Dictionary<String, Object> { { "foo", 123.45 } } );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}