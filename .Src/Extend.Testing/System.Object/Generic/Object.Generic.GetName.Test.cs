#region Usings

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        private event PropertyChangedEventHandler PropertyChanged;

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

        private class SubModel
        {
            #region Properties

            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public String Foo { get; set; }

            #endregion
        }

        [Test]
        public void GetNameOverloadTest()
        {
            var model = new TestModel();
            var actual = model.Age.GetName( () => model.Age );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameOverloadTest1()
        {
            var model = new TestModel();
            var actual = model.Name.GetName( () => model.Name );

            Assert.AreEqual( "Name", actual );
        }

        [Test]
        public void GetNameOverloadTest2()
        {
            var actual = PropertyChanged.GetName( () => PropertyChanged );

            actual.Should()
                  .Be( "PropertyChanged" );
        }

        [Test]
        public void GetNameOverloadTest3()
        {
            const String myString = "";
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => myString.GetName( () => myString );
            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void GetNameOverloadTest4()
        {
            var model = new TestModel
            {
                SubModel = new SubModel()
            };
            var actual = model.SubModel.Foo.GetName( () => model.SubModel.Foo );

            Assert.AreEqual( "Foo", actual );
        }

        [Test]
        public void GetNameOverloadTestNullCheck()
        {
            Expression<Func<Object>> fieldName = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetName( fieldName );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetNameTest()
        {
            var model = new TestModel();
            var actual = model.GetName( x => x.Age );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameTest1()
        {
            var model = new TestModel();
            var actual = model.GetName( x => x.Name );

            Assert.AreEqual( "Name", actual );
        }

        [Test]
        public void GetNameTest2()
        {
            var actual = this.GetName( x => x.PropertyChanged );

            actual.Should()
                  .Be( "PropertyChanged" );
        }

        [Test]
        public void GetNameTest3()
        {
            var model = new TestModel();
            Expression<Func<TestModel, Object>> expression1 = x => x.Age;
            var actual = model.GetName( expression1 );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameTest4()
        {
            var model = new TestModel();
            var actual = model.GetName( x => x.SubModel.Foo );

            Assert.AreEqual( "Foo", actual );
        }

        [Test]
        public void GetNameTestNotSupportedException()
        {
            const String myString = "";
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => myString.GetName( x => myString );
            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void GetNameTestNullCheck()
        {
            Expression<Func<Object, Object>> fieldName = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".GetName( fieldName );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}