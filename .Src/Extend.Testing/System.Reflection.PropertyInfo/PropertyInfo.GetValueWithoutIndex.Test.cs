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
        public void GetValueWithoutIndexPropertyNullTest()
        {
            PropertyInfo propertyInfo = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => propertyInfo.GetValueWithoutIndex( new TestModel() );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetValueWithoutIndexSourceNullTest()
        {
            var property = typeof(TestModel).GetPublicSettableProperties()
                                            .First();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => property.GetValueWithoutIndex( null );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetValueWithoutIndexTest()
        {
            var actualModel = new TestModel
            {
                MyString = RandomValueEx.GetRandomString()
            };
            var property = typeof(TestModel).GetPublicSettableProperties()
                                            .First();

            var actual = property.GetValueWithoutIndex( actualModel );

            actual.Should()
                  .Be( actualModel.MyString );
        }
    }
}