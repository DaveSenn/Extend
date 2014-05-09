using NUnit.Framework;
using System;
using TestingHelper;

namespace PortableExtensions.Tetst
{
    [TestFixture]
    public class ObjectExTest
    {
        [Test]
        public void IsNullTest()
        {
            Object obj = null;
            Assert.IsTrue ( obj.IsNull () );

            obj = "test";
            Assert.IsFalse ( obj.IsNull () );
        }

        [Test]
        public void IsNotNullTest()
        {
            Object obj = null;
            Assert.IsFalse ( obj.IsNotNull () );

            obj = "test";
            Assert.IsTrue ( obj.IsNotNull () );
        }

        public String TestProeprty { get; set; }

        [Test]
        public void GetNameTest()
        {
            TestProeprty = null;
            Assert.AreEqual ( "TestProeprty", ObjectEx.GetName ( this, x => x.TestProeprty ) );

            TestProeprty = "test";
            Assert.AreEqual ( "TestProeprty", ObjectEx.GetName ( this, x => x.TestProeprty ) );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void GetNameTestNullCheck()
        {
            Assert.AreEqual ( "TestProeprty", ObjectEx.GetName<ObjectExTest, String> ( this, null ) );
        }

        [Test]
        public void ThrowIfNullTest()
        {
            ObjectEx.ThrowIfNull ( this, RandomEx.GetRandomString (), x => x.TestProeprty );

            var message = RandomEx.GetRandomString ();
            var exceptionThrown = false;
            try
            {
                ObjectEx.ThrowIfNull ( this, null, x => x.TestProeprty, message );
            }
            catch( ArgumentNullException ex )
            {
                Assert.AreEqual ( message + "\r\nParameter name: TestProeprty", ex.Message );
                exceptionThrown = true;
            }
            Assert.IsTrue ( exceptionThrown );

            exceptionThrown = false;
            try
            {
                ObjectEx.ThrowIfNull ( this, null, x => x.TestProeprty );
            }
            catch( ArgumentNullException ex )
            {
                Assert.AreEqual ( "TestProeprty can not be null.\r\nParameter name: TestProeprty", ex.Message );
                exceptionThrown = true;
            }
            Assert.IsTrue ( exceptionThrown );
        }

        [Test]
        public void ThrowIfNullTest1()
        {
            String test = null;
            var message = RandomEx.GetRandomString ();
            var exceptionThrown = false;
            try
            {
                ObjectEx.ThrowIfNull ( this, test, x => test, message );
            }
            catch( ArgumentNullException ex )
            {
                Assert.AreEqual ( message + "\r\nParameter name: test", ex.Message );
                exceptionThrown = true;
            }
            Assert.IsTrue ( exceptionThrown );

            test = RandomEx.GetRandomString ();
            ObjectEx.ThrowIfNull ( this, test, x => test, message );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void ThrowIfNullTest2()
        {
            ObjectEx.ThrowIfNull ( this, null, x => x.TestProeprty, null );
        }

        [Test]
        public void ThrowIfNullTestOverload()
        {
            ObjectEx.ThrowIfNull ( RandomEx.GetRandomString (), () => this.TestProeprty );

            var message = RandomEx.GetRandomString ();
            var exceptionThrown = false;
            try
            {
                ObjectEx.ThrowIfNull ( null, () => this.TestProeprty, message );
            }
            catch( ArgumentNullException ex )
            {
                Assert.AreEqual ( message + "\r\nParameter name: TestProeprty", ex.Message );
                exceptionThrown = true;
            }
            Assert.IsTrue ( exceptionThrown );

            exceptionThrown = false;
            try
            {
                ObjectEx.ThrowIfNull ( null, () => this.TestProeprty );
            }
            catch( ArgumentNullException ex )
            {
                Assert.AreEqual ( "TestProeprty can not be null.\r\nParameter name: TestProeprty", ex.Message );
                exceptionThrown = true;
            }
            Assert.IsTrue ( exceptionThrown );
        }

        [Test]
        public void ThrowIfNullTestOverload1()
        {
            String test = null;
            var message = RandomEx.GetRandomString ();
            var exceptionThrown = false;
            try
            {
                ObjectEx.ThrowIfNull ( test, () => test, message );
            }
            catch( ArgumentNullException ex )
            {
                Assert.AreEqual ( message + "\r\nParameter name: test", ex.Message );
                exceptionThrown = true;
            }
            Assert.IsTrue ( exceptionThrown );

            test = RandomEx.GetRandomString ();
            ObjectEx.ThrowIfNull ( test, () => test, message );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void ThrowIfNullTestOverload2()
        {
            ObjectEx.ThrowIfNull ( null, () => this.TestProeprty, null );
        }
    }
}