﻿#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void GetRandomItemArgumentNullExceptionTest()
        {
            List<String> list = null;
            Action test = () => list.GetRandomItem();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetRandomItemTest()
        {
            var list = new List<String> { "a", "b", "c", "d" };
            var actual = list.GetRandomItem();

            actual.Should()
                  .NotBeNull();
            list.Should()
                .Contain( actual );
        }
    }
}