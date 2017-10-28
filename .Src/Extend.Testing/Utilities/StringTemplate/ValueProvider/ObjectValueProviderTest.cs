#region Usings

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Extend.Internal;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing.Internal
{
    [Collection( "InstanceCreator" )]
    public class ObjectValueProviderTest
    {
        [Fact]
        public void CtorNullRefrenceTest()
        {
            // ReSharper disable once ObjectCreationAsStatement
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new ObjectValueProvider( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CtorTest()
        {
            var actual = new ObjectValueProvider( new TestModel() );
            actual.Should()
                  .NotBeNull();
        }

        [Fact]
        public void GetValueInvalidExpressionTest()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            Action test = () => target.GetValue( "DOESNotExist" );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void GetValueTest()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyString" );
            actual.Should()
                  .Be( model.MyString );
        }

        [Fact]
        public void GetValueTest1()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyInt32" );
            actual.Should()
                  .Be( model.MyInt32.ToString() );
        }

        [Fact]
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

        [Fact]
        public void GetValueTest2()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyDouble" );
            actual.Should()
                  .Be( model.MyDouble.ToString( CultureInfo.InvariantCulture ) );
        }

        [Fact]
        public void GetValueTest3()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyStringArray[0]" );
            actual.Should()
                  .Be( model.MyStringArray[0] );
        }

        [Fact]
        public void GetValueTest4()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyInt32Array[0]" );
            actual.Should()
                  .Be( model.MyInt32Array[0]
                            .ToString() );
        }

        [Fact]
        public void GetValueTest5()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyListString[0]" );
            actual.Should()
                  .Be( model.MyListString[0] );
        }

        [Fact]
        public void GetValueTest6()
        {
            var model = new TestModel
            {
                MyListInt = new List<Int32>
                {
                    RandomValueEx.GetRandomInt32(),
                    RandomValueEx.GetRandomInt32(),
                    RandomValueEx.GetRandomInt32()
                }
            };
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "MyListInt[0]" );
            actual.Should()
                  .Be( model.MyListInt[0]
                            .ToString() );
        }

        [Fact]
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

        [Fact]
        public void GetValueTest8()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "SubModel.MyStringSub" );
            actual.Should()
                  .Be( model.SubModel.MyStringSub );
        }

        [Fact]
        public void GetValueTest9()
        {
            var model = InstanceCreator.CreateInstance<TestModel>();
            var target = new ObjectValueProvider( model );

            var actual = target.GetValue( "SubModel.MyStringArraySub[0]" );
            actual.Should()
                  .Be( model.SubModel.MyStringArraySub[0] );
        }

        #region Nested Types

        private class SubModel
        {
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            // ReSharper disable CollectionNeverUpdated.Local
            // ReSharper disable UnusedMember.Local
            public String MyStringSub { get; set; }

            public Int32 MyInt32Sub { get; set; }

            public Double MyDoubleSub { get; set; }

            public String[] MyStringArraySub { get; set; }

            public Int32[] MyInt32ArraySub { get; set; }

            public List<String> MyListStringSub { get; set; }

            public List<Int32> MyListIntSub { get; set; }

            public Dictionary<String, String> MyDictionaryStringSub { get; set; }
            // ReSharper restore UnusedMember.Local
            // ReSharper restore CollectionNeverUpdated.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }

        private class TestModel
        {
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            // ReSharper disable CollectionNeverUpdated.Local
            // ReSharper disable UnusedMember.Local
            public String MyString { get; set; }

            public Int32 MyInt32 { get; set; }

            public Double MyDouble { get; set; }

            public String[] MyStringArray { get; set; }

            public Int32[] MyInt32Array { get; set; }

            public List<String> MyListString { get; set; }

            public List<Int32> MyListInt { get; set; }

            public SubModel SubModel { get; set; }

            public Dictionary<String, String> MyDictionaryString { get; set; }
            // ReSharper restore UnusedMember.Local
            // ReSharper restore CollectionNeverUpdated.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }

        #endregion
    }
}