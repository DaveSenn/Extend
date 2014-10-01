#region Using

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        //[Test]
        //public void GetNameTestCase()
        //{
        //    var varName = "";
        //    var actual = varName.GetName( x => varName );

        //    Assert.AreEqual( "varName", actual );
        //}

        

        //[Test]
        //public void GetNameTestCase1()
        //{
        //    const String varName = "value";
        //    var actual = varName.GetName(() => varName);

        //    Assert.AreEqual("varName", actual);
        //}

        //[Test]
        //public void GetNameTestCase2()
        //{
        //    var intValue = 10;
        //    var actual = intValue.GetName(() => intValue);

        //    Assert.AreEqual("intValue", actual);
        //}


        //private Int32 _globalIntValue = 10;
        //[Test]
        //public void GetNameTestCase3()
        //{
        //    var actual = _globalIntValue.GetName(() => _globalIntValue);

        //    Assert.AreEqual("_globalIntValue", actual);
        //}

        //private event PropertyChangedEventHandler propertyChanged;
        //[Test]
        //public void GetNameTestCase4()
        //{
        //    var actual = propertyChanged.GetName(() => propertyChanged);

        //    Assert.AreEqual("propertyChanged", actual);
        //}

        //[Test]
        //public void GetNameTestCase5()
        //{
        //    var model = new TestModel();
        //    var actual = model.Age.GetName(() => model.Age);

        //    Assert.AreEqual("Age", actual);
        //}

        //[Test]
        //public void GetNameTestCase6()
        //{
        //    var model = new TestModel();
        //    Expression<Func<TestModel, object>> expression1 = x => x.Age;

        //    var actual = model.GetName(expression1);

        //    Assert.AreEqual("Age", actual);
        //}

        //[Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void GetNameTestCase1NullCheck()
        //{
        //    Expression<Func<Object>> fieldName = null;
        //    "".GetName(fieldName);
        //}

        [Test]
        public void GetNameTestCase()
        {
            var model = new TestModel();
            var actual = model.GetName(x => x.Age);

            Assert.AreEqual("Age", actual);
        }

        [Test]
        public void GetNameTestCase1()
        {
            var model = new TestModel();
            var actual = model.GetName(x => x.Name);

            Assert.AreEqual("Name", actual);
        }

        private event PropertyChangedEventHandler PropertyChanged;
        [Test]
        public void GetNameTestCase2()
        {
            var model = new TestModel();
            var actual = this.GetName(x => x.PropertyChanged);

            Assert.AreEqual("PropertyChanged", actual);
        }

        [Test]
        public void GetNameTestCase3()
        {
            var model = new TestModel();
            Expression<Func<TestModel, object>> expression1 = x => x.Age;
            var actual = model.GetName(expression1);

            Assert.AreEqual("Age", actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNameTestCaseNullCheck()
        {
            Expression<Func<Object, Object>> fieldName = null;
            "".GetName(fieldName);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void GetNameTestCaseNotSupportedException()
        {
            const String myString = "";
            myString.GetName(x => myString);
        }
        
        [Test]
        public void GetNameOverloadTestCase()
        {
            var model = new TestModel();
            var actual = model.Age.GetName(() => model.Age);

            Assert.AreEqual("Age", actual);
        }

        [Test]
        public void GetNameOverloadTestCase1()
        {
            var model = new TestModel();
            var actual = model.Name.GetName(() => model.Name);

            Assert.AreEqual("Name", actual);
        }

        [Test]
        public void GetNameOverloadTestCase2()
        {
            var model = new TestModel();
            var actual = PropertyChanged.GetName(() => PropertyChanged);

            Assert.AreEqual("PropertyChanged", actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNameOverloadTestCaseNullCheck()
        {
            Expression<Func<Object>> fieldName = null;
            "".GetName(fieldName);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void GetNameOverloadTestCase3()
        {
            const String myString = "";
            myString.GetName(() => myString);
        }

        private class TestModel
        {
            public Int32 Age { get; set; }
            public String Name { get; set; }

        }
    }

    
}