#region Usings

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

        [Test]
        public void BuildTestGeneric()
        {
            var instanceBuilder = typeof (Foo).CreateInstanceBuilder();

            var actual = instanceBuilder.Build<Foo>();
            actual.Should()
                  .NotBeNull();

            actual.MyInt16.Should()
                  .Be( 0 );
            actual.MyString.Should()
                  .NotBeEmpty();
            actual.Bars.Count.Should()
                  .NotBe( 0 );
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