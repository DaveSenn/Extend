#region Usings

using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class PropertyInfoExTest
    {
        private class TestModel
        {
            #region Properties

            public String MyString { get; set; }

            #endregion
        }

        [Test]
        public void ToMemberInformationNullTest()
        {
            PropertyInfo t = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => t.ToMemberInformation( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
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

        [Test]
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
    }
}