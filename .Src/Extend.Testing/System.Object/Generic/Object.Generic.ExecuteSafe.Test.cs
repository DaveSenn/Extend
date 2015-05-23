#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ExecuteSafeTestCase()
        {
            var expectedValue = RandomValueEx.GetRandomString();
            var actual = expectedValue.ExecuteSafe( x => { throw new InvalidOperationException( expectedValue ); } );

            Assert.IsNull( actual.Result );
            Assert.IsNotNull( actual.Exception );
            Assert.AreEqual( expectedValue, actual.Exception.Message );

            var list = new List<String>();
            Assert.IsTrue( list.NotAny() );
            actual = expectedValue.ExecuteSafe( list.Add );

            Assert.IsNull( actual.Exception );
            Assert.AreEqual( expectedValue, actual.Result );
            Assert.AreEqual( list[0], expectedValue );
        }

        [Test]
        public void ExecuteSafeTestCase1()
        {
            var expectedValue = RandomValueEx.GetRandomString();
            var actual = expectedValue.ExecuteSafe( x =>
            {
                if ( expectedValue.Length > 0 )
                    throw new InvalidOperationException( expectedValue );
                return expectedValue;
            } );

            Assert.IsNull( actual.Result );
            Assert.IsNotNull( actual.Exception );
            Assert.AreEqual( expectedValue, actual.Exception.Message );

            actual = expectedValue.ExecuteSafe( x => expectedValue );

            Assert.IsNull( actual.Exception );
            Assert.AreEqual( actual.Result, expectedValue );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteSafeTestCase1NullCheck()
        {
            Func<String, String> func = null;
            "".ExecuteSafe( func );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteSafeTestCaseNullCheck()
        {
            Action<String> action = null;
            "".ExecuteSafe( action );
        }
    }
}

/*
		public static ExecutionResult<TResult> ExecuteSafe<T, TResult>(this T value, Func<T, TResult> func)
		{
			func.ThrowIfNull (() => func);

			var result = new ExecutionResult<TResult> ();
			try
			{
				result.Result = func(value);
			}
			catch (Exception ex)
			{
				result.Exception = ex;
			}
			return result;
		}
 * */