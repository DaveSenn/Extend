#region Usings

using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class InstanceValueArgumentsTest
    {
        [Test]
        public void CtorTest()
        {
            var type = typeof (String);
            var propertyName = RandomValueEx.GetRandomString();
            var propertyInfo = typeof (TestModel).GetProperties()
                                                 .First();
            var owner = new Object();
            var target = new InstanceValueArguments( type, propertyName, propertyInfo, owner );

            target.PropertyType.Should()
                  .Be( type );
            target.PropertyName.Should()
                  .Be( propertyName );
            target.PropertyInfo.Should()
                  .BeSameAs( propertyInfo );
            target.PropertyOwner.Should()
                  .BeSameAs( owner );
        }

        private class TestModel
        {
            #region Properties

            public String Property { get; set; }

            #endregion
        }
    }
}