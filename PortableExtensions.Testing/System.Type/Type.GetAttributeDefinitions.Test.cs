#region Using

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class TypeExTest
    {
        [TestCase]
        public void GetAttributeDefinitionsTestCase()
        {
            var actual = typeof ( TestPerson ).GetAttributeDefinitions<DisplayAttribute>().ToList();
            Assert.AreEqual( 2, actual.Count );

            var actualItem = actual.Single( x => x.Property.Name == "FirstName" );
            Assert.AreEqual(1, actualItem.Attributes.CountOptimized());
            Assert.AreEqual( "FirstName-DisplayName", actualItem.Attributes.Single().Name );

            actualItem = actual.Single( x => x.Property.Name == "LastName" );
            Assert.AreEqual(1, actualItem.Attributes.CountOptimized());
            Assert.AreEqual( "LastName-DisplayName", actualItem.Attributes.Single().Name );
        }

        [TestCase]
        public void GetAttributeDefinitionsTestCase1()
        {
            var actual = typeof ( TestPerson ).GetAttributeDefinitions<MyTestAttribute>().ToList();
            Assert.AreEqual( 1, actual.Count );

            var actualItem = actual.Single( x => x.Property.Name == "DateOfBirth" );
            Assert.AreEqual(2, actualItem.Attributes.CountOptimized());
            Assert.AreEqual( 1, actualItem.Attributes.Count( x => x.Value == "1" ) );
            Assert.AreEqual( 1, actualItem.Attributes.Count( x => x.Value == "2" ) );
        }

        [TestCase]
        public void GetAttributeDefinitionsTestCase2()
        {
            var actual = typeof ( TestPersonInherit ).GetAttributeDefinitions<MyTestAttribute>().ToList();
            Assert.AreEqual( 2, actual.Count );

            var actualItem = actual.Single( x => x.Property.Name == "DateOfBirth" );
            Assert.AreEqual(2, actualItem.Attributes.CountOptimized());
            Assert.AreEqual( 1, actualItem.Attributes.Count( x => x.Value == "1" ) );
            Assert.AreEqual( 1, actualItem.Attributes.Count( x => x.Value == "2" ) );

            actualItem = actual.Single( x => x.Property.Name == "Weight" );
            Assert.AreEqual(1, actualItem.Attributes.CountOptimized());
            Assert.AreEqual( "10000", actualItem.Attributes.Single().Value );
        }

        private class TestPerson
        {
            [Display( Name = "FirstName-DisplayName" )]
            public String FirstName { get; set; }

            [Display( Name = "LastName-DisplayName" )]
            public String LastName { get; set; }

            [MyTest( Value = "1" )]
            [MyTest( Value = "2" )]
            public DateTime DateOfBirth { get; set; }
        }

        private class TestPersonInherit : TestPerson
        {
            [MyTest( Value = "10000" )]
            public Double Weight { get; set; }
        }

        [AttributeUsage( AttributeTargets.Property, AllowMultiple = true, Inherited = true )]
        private class MyTestAttribute : Attribute
        {
            public String Value { get; set; }
        }
    }
}