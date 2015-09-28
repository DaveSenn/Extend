using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Extend.Testing
{
    [TestFixture]
    public class InstanceBuilderWithConditionTest
    {
        [Test]
        public void CtorTest()
        {
            var instanceBuilder = new InstanceBuilder( typeof(String) );
            IInstanceValueFactory factory = new InstanceValueFactory( x => "" );
            var target = new InstanceBuilderWithCondition( instanceBuilder, factory );

            target.Should()
                  .NotBeNull();
        }

        [Test]
        public void WithConditionCombinationTest()
        {
            var instanceBuilder = new InstanceBuilder(typeof(String));
            IInstanceValueFactory factory = new InstanceValueFactory(x => "");
            var target = new InstanceBuilderWithCondition(instanceBuilder, factory);

            var actual = target.WithConditionCombination( ConditionCombinationOption.MatchAny );
            actual.Should()
                  .BeSameAs( target );
        }
    }
}

/*

    /// <summary>
            ///     Adds the given condition to the factory.
            /// </summary>
            /// <exception cref="ArgumentNullException">condition can not be null.</exception>
            /// <param name="condition">The condition to add.</param>
            /// <returns>Returns an instance builder.</returns>
            public IInstanceBuilderWithCondition WithCondition(IInstanceBuilderCondition condition)
            {
                condition.ThrowIfNull(nameof(condition));

                Factory.Conditions.Add(condition);
                return this;
            }



        /// <summary>
            ///     Adds the given factor to the list of factories used to create the înstance values.
            /// </summary>
            /// <exception cref="ArgumentNullException">factory can not be null.</exception>
            /// <param name="factory">The factory to add.</param>
            /// <returns>Returns an instance builder.</returns>
            public IInstanceBuilderWithFactory WithFactory(Func<IInstanceValueArguments, Object> factory)
            {
                factory.ThrowIfNull(nameof(factory));

                return new InstanceBuilderWithFactory(InstanceBuilder, factory);
            }

            

        #endregion
    }

*/
