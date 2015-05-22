#region Usings

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        private event PropertyChangedEventHandler PropertyChanged;

        private class TestModel
        {
            public Int32 Age { get; set; }
            public String Name { get; set; }
            public SubModel SubModel { get; set; }
        }

        private class SubModel
        {
            public String Foo { get; set; }
        }

        [Test]
        public void GetNameOverloadTestCase()
        {
            var model = new TestModel();
            var actual = model.Age.GetName( () => model.Age );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameOverloadTestCase1()
        {
            var model = new TestModel();
            var actual = model.Name.GetName( () => model.Name );

            Assert.AreEqual( "Name", actual );
        }

        [Test]
        public void GetNameOverloadTestCase2()
        {
            var model = new TestModel();
            var actual = PropertyChanged.GetName( () => PropertyChanged );

            Assert.AreEqual( "PropertyChanged", actual );
        }

        [Test]
        [ExpectedException( typeof (NotSupportedException) )]
        public void GetNameOverloadTestCase3()
        {
            const String myString = "";
            myString.GetName( () => myString );
        }

        [Test]
        public void GetNameOverloadTestCase4()
        {
            var model = new TestModel
            {
                SubModel = new SubModel()
            };
            var actual = model.SubModel.Foo.GetName( () => model.SubModel.Foo );

            Assert.AreEqual( "Foo", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetNameOverloadTestCaseNullCheck()
        {
            Expression<Func<Object>> fieldName = null;
            "".GetName( fieldName );
        }

        [Test]
        public void GetNameTestCase()
        {
            var model = new TestModel();
            var actual = model.GetName( x => x.Age );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameTestCase1()
        {
            var model = new TestModel();
            var actual = model.GetName( x => x.Name );

            Assert.AreEqual( "Name", actual );
        }

        [Test]
        public void GetNameTestCase2()
        {
            var model = new TestModel();
            var actual = this.GetName( x => x.PropertyChanged );

            Assert.AreEqual( "PropertyChanged", actual );
        }

        [Test]
        public void GetNameTestCase3()
        {
            var model = new TestModel();
            Expression<Func<TestModel, Object>> expression1 = x => x.Age;
            var actual = model.GetName( expression1 );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameTestCase4()
        {
            var model = new TestModel();
            var actual = model.GetName( x => x.SubModel.Foo );

            Assert.AreEqual( "Foo", actual );
            ;
        }

        [Test]
        [ExpectedException( typeof (NotSupportedException) )]
        public void GetNameTestCaseNotSupportedException()
        {
            const String myString = "";
            myString.GetName( x => myString );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetNameTestCaseNullCheck()
        {
            Expression<Func<Object, Object>> fieldName = null;
            "".GetName( fieldName );
        }
    }
}