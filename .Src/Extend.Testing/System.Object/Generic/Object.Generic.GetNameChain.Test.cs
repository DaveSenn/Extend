#region Usings

using System;
using System.Linq.Expressions;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void GetNameChainOverload1Test()
        {
            var myInt = RandomValueEx.GetRandomInt32();
            var actual = this.GetNameChain( () => myInt );

            Assert.AreEqual( "myInt", actual );
        }

        [Test]
        public void GetNameChainOverload1Test1()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => model.Age );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameChainOverload1Test2()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( () => model.SubModel.Foo );

            Assert.AreEqual( "SubModel.Foo", actual );
        }

        [Test]
        public void GetNameChainOverload1Test3()
        {
            var model = new TestModel();
            Expression<Func<Object>> expression1 = () => model.Age;
            var actual = model.GetNameChain( expression1 );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameChainOverload1Test4()
        {
            var model = new TestModel();
            Expression<Func<Object>> expression1 = () => model.SubModel.Foo;
            var actual = model.GetNameChain( expression1 );

            Assert.AreEqual( "SubModel.Foo", actual );
        }

        [Test]
        public void GetNameChainOverload1TestNotSupportedException()
        {
            const Int32 myInt = 100;
            Action test = () => this.GetNameChain( x => myInt );
            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void GetNameChainOverload1TestNullCheck()
        {
            Expression<Func<Object>> expression = null;
            Action test = () => "".GetNameChain( expression );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetNameChainTest()
        {
            var myInt = RandomValueEx.GetRandomInt32();
            var actual = this.GetNameChain( x => myInt );

            Assert.AreEqual( "myInt", actual );
        }

        [Test]
        public void GetNameChainTest1()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => model.Age );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameChainTest2()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => model.SubModel.Foo );

            Assert.AreEqual( "SubModel.Foo", actual );
        }

        [Test]
        public void GetNameChainTest3()
        {
            var model = new TestModel();
            Expression<Func<TestModel, Object>> expression1 = x => x.Age;
            var actual = model.GetNameChain( expression1 );

            Assert.AreEqual( "Age", actual );
        }

        [Test]
        public void GetNameChainTest4()
        {
            var model = new TestModel();
            Expression<Func<TestModel, Object>> expression1 = x => x.SubModel.Foo;
            var actual = model.GetNameChain( expression1 );

            Assert.AreEqual( "SubModel.Foo", actual );
        }

        [Test]
        public void GetNameChainTest5()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => PropertyChanged );

            Assert.AreEqual( "PropertyChanged", actual );
        }

        [Test]
        public void GetNameChainTestNotSupportedException()
        {
            const Int32 myInt = 100;
            Action test = () => this.GetNameChain( () => myInt );
            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void GetNameChainTestNullCheck()
        {
            Expression<Func<Object, Object>> expression = null;
            Action test = () => "".GetNameChain( expression );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}