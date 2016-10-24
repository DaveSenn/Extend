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

        [Test]
        public void ToStringTest()
        {
            var target = new CreateInstanceException( "message",
                                                      new Exception( "Inner Exception" ),
                                                      "Factory Info",
                                                      "Selection Rule",
                                                      new MemberInformation
                                                      {
                                                          MemberType = typeof(String),
                                                          MemberName = "Name",
                                                          MemberPath = "Path",
                                                          MemberObject = "test"
                                                      } );

            var actual = target.ToString();
            actual.Should()
                  .Be(
                      "CreateInstanceException: message\r\nMember Information='Name: 'Name' Path 'Path' Type 'System.String''\r\n\r\n\r\n ---> System.Exception: Inner Exception\r\n   --- End of inner exception stack trace ---\r\n" );
        }
    }
}