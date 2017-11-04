#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class TypeExTest
    {
        [Fact]
        public void GetAttributeDefinitionsNullTest()
        {
            Type t = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => t.GetAttributeDefinitions<MyDisplayAttribute>();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetAttributeDefinitionsTest()
        {
            var actual = typeof(TestPerson).GetAttributeDefinitions<MyDisplayAttribute>()
                                           .ToList();
            Assert.Equal( 2, actual.Count );

            var actualItem = actual.Single( x => x.Property.Name == "FirstName" );
            Assert.Single( actualItem.Attributes );
            Assert.Equal( "FirstName-DisplayName",
                          actualItem.Attributes.Single()
                                    .Name );

            actualItem = actual.Single( x => x.Property.Name == "LastName" );
            Assert.Single( actualItem.Attributes );
            Assert.Equal( "LastName-DisplayName",
                          actualItem.Attributes.Single()
                                    .Name );
        }

        [Fact]
        public void GetAttributeDefinitionsTest1()
        {
            var actual = typeof(TestPerson).GetAttributeDefinitions<MyTestAttribute>()
                                           .ToList();
            Assert.Single( actual );

            var actualItem = actual.Single( x => x.Property.Name == "DateOfBirth" );
            Assert.Equal( 2, actualItem.Attributes.Count() );
            Assert.Equal( 1, actualItem.Attributes.Count( x => x.Value == "1" ) );
            Assert.Equal( 1, actualItem.Attributes.Count( x => x.Value == "2" ) );
        }

        [Fact]
        public void GetAttributeDefinitionsTest2()
        {
            var actual = typeof(TestPersonInherit).GetAttributeDefinitions<MyTestAttribute>()
                                                  .ToList();
            Assert.Equal( 2, actual.Count );

            var actualItem = actual.Single( x => x.Property.Name == "DateOfBirth" );
            Assert.Equal( 2, actualItem.Attributes.Count() );
            Assert.Equal( 1, actualItem.Attributes.Count( x => x.Value == "1" ) );
            Assert.Equal( 1, actualItem.Attributes.Count( x => x.Value == "2" ) );

            actualItem = actual.Single( x => x.Property.Name == "Weight" );
            Assert.Single( actualItem.Attributes );
            Assert.Equal( "10000",
                          actualItem.Attributes.Single()
                                    .Value );
        }

        #region Nested Types

        [AttributeUsage( AttributeTargets.Property, AllowMultiple = true )]
        private class MyDisplayAttribute : Attribute
        {
            #region Properties

            public String Name { get; set; }

            #endregion
        }

        [AttributeUsage( AttributeTargets.Property, AllowMultiple = true )]
        private class MyTestAttribute : Attribute
        {
            #region Properties

            public String Value { get; set; }

            #endregion
        }

        private class TestPerson
        {
            #region Properties

            [MyDisplay( Name = "FirstName-DisplayName" )]
            // ReSharper disable once UnusedMember.Local
            public String FirstName { get; set; } = "Name";

            [MyDisplay( Name = "LastName-DisplayName" )]
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

        #endregion
    }
}