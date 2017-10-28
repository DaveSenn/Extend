#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class MemberInformationTest
    {
        [Fact]
        public void MemberNameTest()
        {
            var target = new MemberInformation();
            var expected = RandomValueEx.GetRandomString();
            target.MemberName = expected;
            target.MemberName.Should()
                  .Be( expected );
        }

        [Fact]
        public void MemberObjectTest()
        {
            var target = new MemberInformation();
            var expected = RandomValueEx.GetRandomString();
            target.MemberObject = expected;
            target.MemberObject.Should()
                  .Be( expected );
        }

        [Fact]
        public void MemberPathTest()
        {
            var target = new MemberInformation();
            var expected = RandomValueEx.GetRandomString();
            target.MemberPath = expected;
            target.MemberPath.Should()
                  .Be( expected );
        }

        [Fact]
        public void MemberTypeTest()
        {
            var target = new MemberInformation();
            var expected = typeof(String);
            target.MemberType = expected;
            target.MemberType.Should()
                  .Be( expected );
        }

        [Fact]
        public void PropertyInfoTest()
        {
            var target = new MemberInformation();
            var expected = typeof(MemberInformation).GetPublicSettableProperties()
                                                    .First();
            target.PropertyInfo = expected;
            target.PropertyInfo.Should()
                  .BeSameAs( expected );
        }
    }
}