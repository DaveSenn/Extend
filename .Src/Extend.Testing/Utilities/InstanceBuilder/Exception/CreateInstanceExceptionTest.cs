#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class CreateInstanceExceptionTest
    {
        [Fact]
        public void FactoryInformationTest()
        {
            var target = new CreateInstanceException( "msg", new Exception(), "info1", "info2", new MemberInformation() );
            target.FactoryInformation.Should()
                  .Be( "info1" );
        }

        [Fact]
        public void InnerExceptionTest()
        {
            var expected = new Exception();
            var target = new CreateInstanceException( "msg", expected );
            target.InnerException.Should()
                  .BeSameAs( expected );
        }

        [Fact]
        public void MemberInformationTest()
        {
            var expected = new MemberInformation();
            var target = new CreateInstanceException( "msg", new Exception(), "info1", "info2", expected );
            target.MemberInformation.Should()
                  .BeSameAs( expected );
        }

        [Fact]
        public void MessageTest()
        {
            var target = new CreateInstanceException( "msg" );
            target.Message.Should()
                  .Be( "msg" );
        }

        [Fact]
        public void SelectionRuleRuleInformationTest()
        {
            var target = new CreateInstanceException( "msg", new Exception(), "info1", "info2", new MemberInformation() );
            target.SelectionRuleRuleInformation.Should()
                  .Be( "info2" );
        }

        [Fact]
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