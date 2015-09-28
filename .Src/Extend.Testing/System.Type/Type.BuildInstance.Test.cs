#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TypeExTest
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
        public void BuildInstanceTestGeneric()
        {
            var actual = TypeEx.BuildInstance<Foo>();
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
        public void BuildInstanceTestType()
        {
            var actual = typeof (Foo).BuildInstance() as Foo;
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