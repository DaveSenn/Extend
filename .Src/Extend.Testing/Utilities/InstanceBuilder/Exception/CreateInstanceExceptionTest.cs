#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class CreateInstanceExceptionTest
    {
        [Test]
        public void FactoryInformationTest()
        {
            var target = new CreateInstanceException( "msg", new Exception(), "info1", "info2", new MemberInformation() );
            target.FactoryInformation.Should()
                  .Be( "info1" );
        }

        [Test]
        public void InnerExceptionTest()
        {
            var expected = new Exception();
            var target = new CreateInstanceException( "msg", expected );
            target.InnerException.Should()
                  .BeSameAs( expected );
        }

        [Test]
        public void MemberInformationTest()
        {
            var expected = new MemberInformation();
            var target = new CreateInstanceException( "msg", new Exception(), "info1", "info2", expected );
            target.MemberInformation.Should()
                  .BeSameAs( expected );
        }

        [Test]
        public void MessageTest()
        {
            var target = new CreateInstanceException( "msg" );
            target.Message.Should()
                  .Be( "msg" );
        }

        [Test]
        public void SelectionRuleRuleInformationTest()
        {
            var target = new CreateInstanceException( "msg", new Exception(), "info1", "info2", new MemberInformation() );
            target.SelectionRuleRuleInformation.Should()
                  .Be( "info2" );
        }
    }
}