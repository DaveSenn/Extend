﻿#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class IntegralInstanceBuilderExTest
    {
        private class Foo
        {
            #region Properties

            public String MyString { get; set; }
            public Int32 MyInt32 { get; set; }
            public Int16 MyInt16 { get; }

            public List<Bar> Bars { get; set; }

            #endregion
        }

        private class Bar
        {
            #region Properties

            public String MyString { get; set; }

            public List<String> MyStrings { get; set; }

            #endregion
        }

        private class TestModelNullable
        {
            public String MyString { get; set; }

            public DateTime? MyDateTime { get; set; }

            public List<DateTime?> DateTimes { get; set; }

            public Foo Foo { get; set; }

            public Byte[] ByteArray { get; set; }

            public String[] StringArray { get; set; }

            //public Int32?[] NullableInts { get; set; }

            public IEnumerable<String> EnumerableStrings { get; set; }
        }

        private class TestModelEnumerable
        {
            public IEnumerable<String> EnumerableStrings { get; set; }
        }

        [Test]
        public void BuildTestIEnuemrable()
        {
            var instanceBuilder = typeof(TestModelEnumerable).CreateInstanceBuilder();
            var actual = instanceBuilder.Build<TestModelEnumerable>();

            actual.EnumerableStrings.Should()
                  .NotBeEmpty();
        }

        [Test]
        public void BuildTestGeneric()
        {
            var instanceBuilder = typeof (TestModelNullable).CreateInstanceBuilder();
            var actual = instanceBuilder.Build<TestModelNullable>();

            actual.DateTimes.Should()
                  .NotBeNull();
        }

        [Test]
        public void BuildTestGenericArgumentNullException()
        {
            IIntegralInstanceBuilder instanceBuilder = null;
            Action test = () => instanceBuilder.Build<Foo>();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void BuildTestNonGenericArgumentNullException()
        {
            IIntegralInstanceBuilder instanceBuilder = null;
            Action test = () => instanceBuilder.Build();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void BuildTestType()
        {
            var instanceBuilder = typeof (Foo).CreateInstanceBuilder();

            var actual = instanceBuilder.Build() as Foo;
            actual.Should()
                  .NotBeNull();

            actual.MyInt16.Should()
                  .Be( 0 );
            actual.MyString.Should()
                  .NotBeEmpty();
            actual.Bars.Count.Should()
                  .NotBe( 0 );
        }
    }
}