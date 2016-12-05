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
    public partial class PropertyInfoExTest
    {
        [Test]
        public void GetValueWithoutIndexPropertyNullTest()
        {
            PropertyInfo propertyInfo = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => propertyInfo.GetValueWithoutIndex( new TestModel() );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetValueWithoutIndexSourceNullTest()
        {
            var property = typeof(TestModel).GetPublicSettableProperties()
                                            .First();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => property.GetValueWithoutIndex( null );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
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