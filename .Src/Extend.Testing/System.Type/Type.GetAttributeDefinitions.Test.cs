#region Usings

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TypeExTest
    {
        private class TestPerson
        {
            #region Properties

            [Display( Name = "FirstName-DisplayName" )]
            // ReSharper disable once UnusedMember.Local
            public String FirstName { get; set; } = "Name";

            [Display( Name = "LastName-DisplayName" )]
            // ReSharper disable once UnusedMember.Local
            public String LastName { get; set; } = "LastName";

            [MyTest( Value = "1" )]
            [MyTest( Value = "2" )]
            // ReSharper disable once UnusedMember.Local
            public DateTime DateOfBirth { get; set; } = DateTime.Now;

            #endregion
        }

        private class TestPersonInherit : TestPerson
        {
            #region Properties

            [MyTest( Value = "10000" )]
            // ReSharper disable once UnusedMember.Local
            public Double Weight { get; set; } = 100;

            #endregion
        }

        [AttributeUsage( AttributeTargets.Property, AllowMultiple = true )]
        private class MyTestAttribute : Attribute
        {
            #region Properties

            public String Value { get; set; }

            #endregion
        }

        [Test]
        public void GetAttributeDefinitionsNullTest()
        {
            Type t = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => t.GetAttributeDefinitions<DisplayAttribute>();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAttributeDefinitionsTest()
        {
            var actual = typeof(TestPerson).GetAttributeDefinitions<DisplayAttribute>()
                                           .ToList();
            Assert.AreEqual( 2, actual.Count );

            var actualItem = actual.Single( x => x.Property.Name == "FirstName" );
            Assert.AreEqual( 1, actualItem.Attributes.Count() );
            Assert.AreEqual( "FirstName-DisplayName",
                             actualItem.Attributes.Single()
                                       .Name );

            actualItem = actual.Single( x => x.Property.Name == "LastName" );
            Assert.AreEqual( 1, actualItem.Attributes.Count() );
            Assert.AreEqual( "LastName-DisplayName",
                             actualItem.Attributes.Single()
                                       .Name );
        }

        [Test]
        public void GetAttributeDefinitionsTest1()
        {
            var actual = typeof(TestPerson).GetAttributeDefinitions<MyTestAttribute>()
                                           .ToList();
            Assert.AreEqual( 1, actual.Count );

            var actualItem = actual.Single( x => x.Property.Name == "DateOfBirth" );
            Assert.AreEqual( 2, actualItem.Attributes.Count() );
            Assert.AreEqual( 1, actualItem.Attributes.Count( x => x.Value == "1" ) );
            Assert.AreEqual( 1, actualItem.Attributes.Count( x => x.Value == "2" ) );
        }

        [Test]
        public void GetAttributeDefinitionsTest2()
        {
            var actual = typeof(TestPersonInherit).GetAttributeDefinitions<MyTestAttribute>()
                                                  .ToList();
            Assert.AreEqual( 2, actual.Count );

            var actualItem = actual.Single( x => x.Property.Name == "DateOfBirth" );
            Assert.AreEqual( 2, actualItem.Attributes.Count() );
            Assert.AreEqual( 1, actualItem.Attributes.Count( x => x.Value == "1" ) );
            Assert.AreEqual( 1, actualItem.Attributes.Count( x => x.Value == "2" ) );

            actualItem = actual.Single( x => x.Property.Name == "Weight" );
            Assert.AreEqual( 1, actualItem.Attributes.Count() );
            Assert.AreEqual( "10000",
                             actualItem.Attributes.Single()
                                       .Value );
        }
    }
}