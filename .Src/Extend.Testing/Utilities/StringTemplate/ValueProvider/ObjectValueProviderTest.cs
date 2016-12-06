#region Usings

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Internal.Testing
{
    [TestFixture]
    public class ObjectValueProviderTest
    {
        [Test]
        public void CtorNullRefrenceTest()
        {
            // ReSharper disable once ObjectCreationAsStatement
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new ObjectValueProvider( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CtorTest()
        {
            var actual = new ObjectValueProvider( new TestModel() );
            actual.Should()
                  .NotBeNull();
        }

        [Test]
        public void GetValueTest()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyString" );
            actual.Should()
                  .Be( model.MyString );
        }

        [Test]
        public void GetValueTest1()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyInt32" );
            actual.Should()
                  .Be( model.MyInt32.ToString() );
        }

        [Test]
        public void GetValueTest10()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "SubModel.MyDictionaryStringSub[" + model.SubModel.MyDictionaryStringSub.First()
                                                                                   .Key + "]" );
            actual.Should()
                  .Be( model.SubModel.MyDictionaryStringSub[model.SubModel.MyDictionaryStringSub.First()
                                                                 .Key] );
        }

        [Test]
        public void GetValueTest2()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyDouble" );
            actual.Should()
                  .Be( model.MyDouble.ToString( CultureInfo.InvariantCulture ) );
        }

        [Test]
        public void GetValueTest3()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyStringArray[0]" );
            actual.Should()
                  .Be( model.MyStringArray[0] );
        }

        [Test]
        public void GetValueTest4()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyInt32Array[0]" );
            actual.Should()
                  .Be( model.MyInt32Array[0].ToString() );
        }

        [Test]
        public void GetValueTest5()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyListString[0]" );
            actual.Should()
                  .Be( model.MyListString[0] );
        }

        [Test]
        public void GetValueTest6()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyListInt[0]" );
            actual.Should()
                  .Be( model.MyListInt[0].ToString() );
        }

        [Test]
        public void GetValueTest7()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyDictionaryString[" + model.MyDictionaryString.First()
                                                                       .Key + "]" );
            actual.Should()
                  .Be( model.MyDictionaryString[model.MyDictionaryString.First()
                                                     .Key] );
        }

        [Test]
        public void GetValueTest8()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "SubModel.MyStringSub" );
            actual.Should()
                  .Be( model.SubModel.MyStringSub );
        }

        [Test]
        public void GetValueTest9()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "SubModel.MyStringArraySub[0]" );
            actual.Should()
                  .Be( model.SubModel.MyStringArraySub[0] );
        }

        [Test]
        public void GetValueInvalidExpressionTest()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider(model);

            Action test = () => target.GetValue("DOESNotExist");
            test.ShouldThrow<FormatException>();
        }

        private class TestModel
        {
            #region Properties

            public String MyString { get; set; }

            public Int32 MyInt32 { get; set; }

            public Double MyDouble { get; set; }

            public String[] MyStringArray { get; set; }

            public Int32[] MyInt32Array { get; set; }

            public List<String> MyListString { get; set; }

            public List<Int32> MyListInt { get; set; }

            public SubModel SubModel { get; set; }

            public Dictionary<String, String> MyDictionaryString { get; set; }

            #endregion
        }

        private class SubModel
        {
            #region Properties

            public String MyStringSub { get; set; }

            public Int32 MyInt32Sub { get; set; }

            public Double MyDoubleSub { get; set; }

            public String[] MyStringArraySub { get; set; }

            public Int32[] MyInt32ArraySub { get; set; }

            public List<String> MyListStringSub { get; set; }

            public List<Int32> MyListIntSub { get; set; }

            public Dictionary<String, String> MyDictionaryStringSub { get; set; }

            #endregion
        }

        /*


                        [Test]
                        public void GetValueFalseFormatTest()
                        {
                            var values = new Dictionary<String, Object>
                            {
                                { "MyInt", DateTime.Now }
                            };
                            var target = new ObjectValueProvider( values );

                            var actual = target.GetValue( "MyInt:DD" );
                            actual.Should()
                                  .Be( "DD" );
                        }

                        [Test]
                        public void GetValueMissingKeyTest()
                        {
                            var values = new Dictionary<String, Object>
                            {
                                { "MyString", "asdf" }
                            };
                            var target = new ObjectValueProvider( values );

                            Action test = () => target.GetValue( "MyInt" );
                            test.ShouldThrow<FormatException>()
                                .WithInnerException<KeyNotFoundException>();
                        }

                        [Test]
                        public void GetValueMissingKeyWithFormatTest()
                        {
                            var values = new Dictionary<String, Object>
                            {
                                { "MyString", "asdf" }
                            };
                            var target = new ObjectValueProvider( values );

                            Action test = () => target.GetValue( "MyInt:000" );
                            test.ShouldThrow<FormatException>()
                                .WithInnerException<KeyNotFoundException>();
                        }

                        [Test]
                        public void GetValueNoneStringTest()
                        {
                            var values = new Dictionary<String, Object>
                            {
                                { "MyString", "asdf" },
                                { "MyInt", 1234 }
                            };
                            var target = new ObjectValueProvider( values );

                            var value = target.GetValue( "MyInt" );
                            value.Should()
                                 .Be( "1234" );
                        }

                        [Test]
                        public void GetValueNullValueTest()
                        {
                            var values = new Dictionary<String, Object>
                            {
                                { "MyString", null }
                            };
                            var target = new ObjectValueProvider( values );

                            var value = target.GetValue( "MyString" );
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
                            var target = new ObjectValueProvider( values );

                            var value = target.GetValue( "MyString:00000" );
                            value.Should()
                                 .BeEmpty();
                        }

                        [Test]
                        public void GetValueTest()
                        {
                            var values = new Dictionary<String, Object>
                            {
                                { "MyString", "asdf" }
                            };
                            var target = new ObjectValueProvider( values );

                            var value = target.GetValue( "MyString" );
                            value.Should()
                                 .Be( "asdf" );
                        }

                        [Test]
                        public void GetValueWithFormatTest()
                        {
                            var values = new Dictionary<String, Object>
                            {
                                { "MyString", "asdf" },
                                { "MyInt", 1234 }
                            };
                            var target = new ObjectValueProvider( values );

                            var value = target.GetValue( "MyInt:000000" );
                            value.Should()
                                 .Be( "001234" );
                        }

                        */
    }
}