#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class InstanceBuilderTest
    {
        [Test]
        public void CtorTest()
        {
            var type = typeof (Double);
            var target = new InstanceBuilder( type );
            target.InstanceType.Should()
                  .Be( type );

            target.Factories.Count.Should()
                  .Be( 0 );
        }

        [Test]
        public void WithFactoryTest()
        {
            var target = new InstanceBuilder( typeof (String) );
            Func<IInstanceValueArguments, Object> factory = x => "";

            var actual = target.WithFactory( factory );
            actual.Should()
                  .NotBeNull();
        }

        [Test]
        public void WithFactoryTestArgumentNullException()
        {
            var target = new InstanceBuilder( typeof (String) );
            Func<IInstanceValueArguments, Object> factory = x => "";

            Action test = () => target.WithFactory( null );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}