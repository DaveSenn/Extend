#region Usings

using System;
using System.Linq.Expressions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void GetNameChainOverload1TestCase()
        {
            var myInt = RandomValueEx.GetRandomInt32();
            var actual = this.GetNameChain( () => myInt );

            Assert.AreEqual( "myInt", actual );
        }

        [Test]
        public void GetNameChainOverload1TestCase1()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => model.Age );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameChainOverload1TestCase2()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( () => model.SubModel.Foo );

            Assert.AreEqual( "SubModel.Foo", actual );
        }

        [Test]
        public void GetNameChainOverload1TestCase3()
        {
            var model = new TestModel();
            Expression<Func<Object>> expression1 = () => model.Age;
            var actual = model.GetNameChain( expression1 );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameChainOverload1TestCase4()
        {
            var model = new TestModel();
            Expression<Func<Object>> expression1 = () => model.SubModel.Foo;
            var actual = model.GetNameChain( expression1 );

            Assert.AreEqual( "SubModel.Foo", actual );
        }

        [Test]
        [ExpectedException( typeof (NotSupportedException) )]
        public void GetNameChainOverload1TestCaseNotSupportedException()
        {
            const Int32 myInt = 100;
            this.GetNameChain( () => myInt );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetNameChainOverload1TestCaseNullCheck()
        {
            Expression<Func<Object>> expression = null;
            "".GetNameChain( expression );
        }

        [Test]
        public void GetNameChainTestCase()
        {
            var myInt = RandomValueEx.GetRandomInt32();
            var actual = this.GetNameChain( x => myInt );

            Assert.AreEqual( "myInt", actual );
        }

        [Test]
        public void GetNameChainTestCase1()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => model.Age );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameChainTestCase2()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => model.SubModel.Foo );

            Assert.AreEqual( "SubModel.Foo", actual );
        }

        [Test]
        public void GetNameChainTestCase3()
        {
            var model = new TestModel();
            Expression<Func<TestModel, Object>> expression1 = x => x.Age;
            var actual = model.GetNameChain( expression1 );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameChainTestCase4()
        {
            var model = new TestModel();
            Expression<Func<TestModel, Object>> expression1 = x => x.SubModel.Foo;
            var actual = model.GetNameChain( expression1 );

            Assert.AreEqual( "SubModel.Foo", actual );
        }

        [Test]
        public void GetNameChainTestCase5()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => PropertyChanged );

            Assert.AreEqual( "PropertyChanged", actual );
        }

        [Test]
        [ExpectedException( typeof (NotSupportedException) )]
        public void GetNameChainTestCaseNotSupportedException()
        {
            const Int32 myInt = 100;
            this.GetNameChain( x => myInt );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetNameChainTestCaseNullCheck()
        {
            Expression<Func<Object, Object>> expression = null;
            "".GetNameChain( expression );
        }
    }
}