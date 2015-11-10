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

            public Int32 Age { get; set; }
            public String Name { get; set; }
            public SubModel SubModel { get; set; }

            #endregion
        }

        private class SubModel
        {
            #region Properties

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
            var model = new TestModel();
            var actual = PropertyChanged.GetName( () => PropertyChanged );

            Assert.AreEqual( "PropertyChanged", actual );
        }

        [Test]
        public void GetNameOverloadTest3()
        {
            const String myString = "";
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
            var model = new TestModel();
            var actual = this.GetName( x => x.PropertyChanged );

            Assert.AreEqual( "PropertyChanged", actual );
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
            ;
        }

        [Test]
        public void GetNameTestNotSupportedException()
        {
            const String myString = "";
            Action test = () => myString.GetName( x => myString );
            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void GetNameTestNullCheck()
        {
            Expression<Func<Object, Object>> fieldName = null;
            Action test = () => "".GetName( fieldName );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}