#region Usings

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            public String FirstName { get; set; }

            [Display( Name = "LastName-DisplayName" )]
            public String LastName { get; set; }

            [MyTest( Value = "1" )]
            [MyTest( Value = "2" )]
            public DateTime DateOfBirth { get; set; }

            #endregion
        }

        private class TestPersonInherit : TestPerson
        {
            #region Properties

            [MyTest( Value = "10000" )]
            public Double Weight { get; set; }

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
        public void GetAttributeDefinitionsTest()
        {
            var actual = typeof (TestPerson).GetAttributeDefinitions<DisplayAttribute>()
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
            var actual = typeof (TestPerson).GetAttributeDefinitions<MyTestAttribute>()
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
            var actual = typeof (TestPersonInherit).GetAttributeDefinitions<MyTestAttribute>()
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