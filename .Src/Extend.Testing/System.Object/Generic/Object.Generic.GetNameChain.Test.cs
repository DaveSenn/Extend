#region Usings

using System;
using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void GetNameChainOverload1Test()
        {
            var myInt = RandomValueEx.GetRandomInt32();
            var actual = this.GetNameChain( () => myInt );

            Assert.Equal( "myInt", actual );
        }

        [Fact]
        public void GetNameChainOverload1Test1()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => model.Age );

            Assert.Equal( "Age", actual );
        }

        [Fact]
        public void GetNameChainOverload1Test2()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( () => model.SubModel.Foo );

            Assert.Equal( "SubModel.Foo", actual );
        }

        [Fact]
        public void GetNameChainOverload1Test3()
        {
            var model = new TestModel();
            Expression<Func<Object>> expression1 = () => model.Age;
            var actual = model.GetNameChain( expression1 );

            Assert.Equal( "Age", actual );
        }

        [Fact]
        public void GetNameChainOverload1Test4()
        {
            var model = new TestModel();
            Expression<Func<Object>> expression1 = () => model.SubModel.Foo;
            var actual = model.GetNameChain( expression1 );

            Assert.Equal( "SubModel.Foo", actual );
        }

        [Fact]
        public void GetNameChainOverload1TestNotSupportedException()
        {
            const Int32 myInt = 100;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => this.GetNameChain( x => myInt );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetNameChainOverload1TestNullCheck()
        {
            Expression<Func<Object>> expression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetNameChain( expression );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetNameChainTest()
        {
            var myInt = RandomValueEx.GetRandomInt32();
            var actual = this.GetNameChain( x => myInt );

            Assert.Equal( "myInt", actual );
        }

        [Fact]
        public void GetNameChainTest1()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => model.Age );

            Assert.Equal( "Age", actual );
        }

        [Fact]
        public void GetNameChainTest2()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => model.SubModel.Foo );

            Assert.Equal( "SubModel.Foo", actual );
        }

        [Fact]
        public void GetNameChainTest3()
        {
            var model = new TestModel();
            Expression<Func<TestModel, Object>> expression1 = x => x.Age;
            var actual = model.GetNameChain( expression1 );

            Assert.Equal( "Age", actual );
        }

        [Fact]
        public void GetNameChainTest4()
        {
            var model = new TestModel();
            Expression<Func<TestModel, Object>> expression1 = x => x.SubModel.Foo;
            var actual = model.GetNameChain( expression1 );

            Assert.Equal( "SubModel.Foo", actual );
        }

        [Fact]
        public void GetNameChainTest5()
        {
            var model = new TestModel();
            var actual = model.GetNameChain( x => PropertyChanged );

            Assert.Equal( "PropertyChanged", actual );
        }

        [Fact]
        public void GetNameChainTestNotSupportedException()
        {
            const Int32 myInt = 100;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => this.GetNameChain( () => myInt );
            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetNameChainTestNullCheck()
        {
            Expression<Func<Object, Object>> expression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetNameChain( expression );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}