#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class ExpressionEvaluatorTest
    {
        [Fact]
        public void EnableCachingTest()
        {
            ExpressionEvaluator.EnableCaching
                               .Should()
                               .Be( true );

            ExpressionEvaluator.EnableCaching = false;
            ExpressionEvaluator.EnableCaching
                               .Should()
                               .Be( false );

            ExpressionEvaluator.EnableCaching = true;
            ExpressionEvaluator.EnableCaching
                               .Should()
                               .Be( true );
        }

        [Fact]
        public void GetValueTest_CollectionPropertyDoesNotExist()
        {
            Action test = () => ExpressionEvaluator
                .GetValue( "foo[0]",
                           new
                           {
                               bar = new[] { 123, 312 }
                           } );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValueTest_DictionaryInt()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo[0]",
                           new
                           {
                               foo = new Dictionary<Int32, Int32>
                               {
                                   { 0, 10 },
                                   { 1, 11 }
                               }
                           } );

            actual.Should()
                  .Be( 10 );
        }

        [Fact]
        public void GetValueTest_DictionaryInt1()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo(1)",
                           new
                           {
                               foo = new Dictionary<Int32, Int32>
                               {
                                   { 0, 10 },
                                   { 1, 11 }
                               }
                           } );

            actual.Should()
                  .Be( 11 );
        }

        [Fact]
        public void GetValueTest_DictionaryString()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo[\"aa\"]",
                           new
                           {
                               foo = new Dictionary<String, Int32>
                               {
                                   { "aa", 10 },
                                   { "bb", 11 }
                               }
                           } );

            actual.Should()
                  .Be( 10 );
        }

        [Fact]
        public void GetValueTest_DictionaryString1()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo(\"bb\")",
                           new
                           {
                               foo = new Dictionary<String, Int32>
                               {
                                   { "aa", 10 },
                                   { "bb", 11 }
                               }
                           } );

            actual.Should()
                  .Be( 11 );
        }

        [Fact]
        public void GetValueTest_DictionaryString2()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo[aa]",
                           new
                           {
                               foo = new Dictionary<String, Int32>
                               {
                                   { "aa", 10 },
                                   { "bb", 11 }
                               }
                           } );

            actual.Should()
                  .Be( 10 );
        }

        [Fact]
        public void GetValueTest_DictionaryString3()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo(bb)",
                           new
                           {
                               foo = new Dictionary<String, Int32>
                               {
                                   { "aa", 10 },
                                   { "bb", 11 }
                               }
                           } );

            actual.Should()
                  .Be( 11 );
        }

        [Fact]
        public void GetValueTest_DictionaryString4()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo[\"1aa\"]",
                           new
                           {
                               foo = new Dictionary<String, Int32>
                               {
                                   { "1aa", 10 },
                                   { "2bb", 11 }
                               }
                           } );

            actual.Should()
                  .Be( 10 );
        }

        [Fact]
        public void GetValueTest_DictionaryString5()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo(\"1bb\")",
                           new
                           {
                               foo = new Dictionary<String, Int32>
                               {
                                   { "1aa", 10 },
                                   { "1bb", 11 }
                               }
                           } );

            actual.Should()
                  .Be( 11 );
        }

        [Fact]
        public void GetValueTest_DictionaryString6()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo[1aa]",
                           new
                           {
                               foo = new Dictionary<String, Int32>
                               {
                                   { "1aa", 10 },
                                   { "1bb", 11 }
                               }
                           } );

            actual.Should()
                  .Be( 10 );
        }

        [Fact]
        public void GetValueTest_DictionaryString7()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo(1bb)",
                           new
                           {
                               foo = new Dictionary<String, Int32>
                               {
                                   { "1aa", 10 },
                                   { "1bb", 11 }
                               }
                           } );

            actual.Should()
                  .Be( 11 );
        }

        [Fact]
        public void GetValueTest_ExpressionEmpty()
        {
            Action test = () => ExpressionEvaluator.GetValue( String.Empty, new Object() );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetValueTest_ExpressionNull()
        {
            Action test = () => ExpressionEvaluator.GetValue( null, new Object() );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetValueTest_IndexAccessArray()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo[0]",
                           new
                           {
                               foo = new[] { 123, 312 }
                           } );

            actual.Should()
                  .Be( 123 );
        }

        [Fact]
        public void GetValueTest_IndexAccessArray1()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo(1)",
                           new
                           {
                               foo = new[] { 123, 312 }
                           } );

            actual.Should()
                  .Be( 312 );
        }

        [Fact]
        public void GetValueTest_IndexAccessList()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo[0]",
                           new
                           {
                               foo = new List<Int32> { 123, 312 }
                           } );

            actual.Should()
                  .Be( 123 );
        }

        [Fact]
        public void GetValueTest_IndexAccessList1()
        {
            var actual = ExpressionEvaluator
                .GetValue( "foo(1)",
                           new
                           {
                               foo = new List<Int32> { 123, 312 }
                           } );

            actual.Should()
                  .Be( 312 );
        }

        [Fact]
        public void GetValueTest_IndexAccessListNoCacing()
        {
            ExpressionEvaluator.EnableCaching = false;
            var actual = ExpressionEvaluator
                .GetValue( "foo(1)",
                           new
                           {
                               foo = new List<Int32> { 123, 312 }
                           } );

            actual.Should()
                  .Be( 312 );
            ExpressionEvaluator.EnableCaching = true;
        }

        [Fact]
        public void GetValueTest_IndexOneNoneCollection()
        {
            Action test = () => ExpressionEvaluator
                .GetValue( "foo(1)",
                           new
                           {
                               foo = 123
                           } );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValueTest_InvalidIndex()
        {
            Action test = () => ExpressionEvaluator
                .GetValue( "foo(Object)",
                           new
                           {
                               foo = new List<Int32> { 123, 312 }
                           } );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValueTest_InvalidIndexExpression()
        {
            Action test = () => ExpressionEvaluator.GetValue( "foo[0", new { foo = 123 } );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValueTest_InvalidIndexExpression1()
        {
            Action test = () => ExpressionEvaluator.GetValue( "foo[0", new { foo = 123 } );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValueTest_InvalidIndexExpression2()
        {
            Action test = () => ExpressionEvaluator.GetValue( "foo[", new { foo = 123 } );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValueTest_InvalidIndexExpression3()
        {
            Action test = () => ExpressionEvaluator.GetValue( "foo[", new { foo = 123 } );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValueTest_PropertyDoesNotExist()
        {
            Action test = () => ExpressionEvaluator.GetValue( "foo", new { bar = 123 } );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValueTest_SimpleExpression()
        {
            var actual = ExpressionEvaluator.GetValue( "foo", new { foo = 123 } );

            actual.Should()
                  .Be( 123 );
        }

        [Fact]
        public void GetValueTest_SourceNull()
        {
            var actual = ExpressionEvaluator.GetValue( "{Test}", null );

            actual.Should()
                  .BeNull();
        }
    }
}