#region Usings

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void GetNameOverloadTest()
        {
            var model = new TestModel();
            var actual = model.Age.GetName( () => model.Age );

            Assert.Equal( "Age", actual );
        }

        [Fact]
        public void GetNameOverloadTest1()
        {
            var model = new TestModel();
            var actual = model.Name.GetName( () => model.Name );

            Assert.Equal( "Name", actual );
        }

        [Fact]
        public void GetNameOverloadTest2()
        {
            var actual = PropertyChanged.GetName( () => PropertyChanged );

            actual.Should()
                  .Be( "PropertyChanged" );
        }

        [Fact]
        public void GetNameOverloadTest3()
        {
            const String myString = "";
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => myString.GetName( () => myString );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetNameOverloadTest4()
        {
            var model = new TestModel
            {
                SubModel = new SubModel()
            };
            var actual = model.SubModel.Foo.GetName( () => model.SubModel.Foo );

            Assert.Equal( "Foo", actual );
        }

        [Fact]
        public void GetNameOverloadTestNullCheck()
        {
            Expression<Func<Object>> fieldName = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetName( fieldName );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetNameTest()
        {
            var model = new TestModel();
            var actual = model.GetName( x => x.Age );

            Assert.Equal( "Age", actual );
        }

        [Fact]
        public void GetNameTest1()
        {
            var model = new TestModel();
            var actual = model.GetName( x => x.Name );

            Assert.Equal( "Name", actual );
        }

        [Fact]
        public void GetNameTest2()
        {
            var actual = this.GetName( x => x.PropertyChanged );

            actual.Should()
                  .Be( "PropertyChanged" );
        }

        [Fact]
        public void GetNameTest3()
        {
            var model = new TestModel();
            Expression<Func<TestModel, Object>> expression1 = x => x.Age;
            var actual = model.GetName( expression1 );

            Assert.Equal( "Age", actual );
        }

        [Fact]
        public void GetNameTest4()
        {
            var model = new TestModel();
            var actual = model.GetName( x => x.SubModel.Foo );

            Assert.Equal( "Foo", actual );
        }

        [Fact]
        public void GetNameTestNotSupportedException()
        {
            const String myString = "";
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => myString.GetName( x => myString );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetNameTestNullCheck()
        {
            Expression<Func<Object, Object>> fieldName = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".GetName( fieldName );

            test.ShouldThrow<ArgumentNullException>();
        }

        private event PropertyChangedEventHandler PropertyChanged;

        #region Nested Types

        private class SubModel
        {
            #region Properties

            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public String Foo { get; set; }

            #endregion
        }

        private class TestModel
        {
            #region Properties

            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public Int32 Age { get; set; }

            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public String Name { get; set; }

            public SubModel SubModel { get; set; }

            #endregion
        }

        #endregion
    }
}