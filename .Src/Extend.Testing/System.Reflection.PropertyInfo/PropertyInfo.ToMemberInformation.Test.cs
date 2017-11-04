#region Usings

using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class PropertyInfoExTest
    {
        [Fact]
        public void ToMemberInformationNullTest()
        {
            PropertyInfo t = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => t.ToMemberInformation( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToMemberInformationTest()
        {
            var property = typeof(TestModel).GetPublicSettableProperties()
                                            .First();
            var actual = property.ToMemberInformation( null );
            actual.MemberName.Should()
                  .Be( "MyString" );
            actual.MemberObject.Should()
                  .BeNull();
            actual.MemberPath.Should()
                  .Be( "MyString" );
            actual.MemberType.Should()
                  .Be( typeof(String) );
            actual.PropertyInfo.Should()
                  .BeSameAs( property );
        }

        [Fact]
        public void ToMemberInformationTest1()
        {
            var property = typeof(TestModel).GetPublicSettableProperties()
                                            .First();
            var actual = property.ToMemberInformation( new MemberInformation
            {
                MemberName = "Parent"
            } );
            actual.MemberName.Should()
                  .Be( "MyString" );
            actual.MemberObject.Should()
                  .BeNull();
            actual.MemberPath.Should()
                  .Be( "Parent.MyString" );
            actual.MemberType.Should()
                  .Be( typeof(String) );
            actual.PropertyInfo.Should()
                  .BeSameAs( property );
        }

        #region Nested Types

        private class TestModel
        {
            #region Properties

            // ReSharper disable once UnusedMember.Local
            public String MyString { get; set; }

            #endregion
        }

        #endregion
    }
}