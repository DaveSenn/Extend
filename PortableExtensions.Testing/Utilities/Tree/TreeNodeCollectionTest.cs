#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class TreeNodeCollectionTest
    {
        [Test]
        public void AddTestCase ()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var expected = RandomValueEx.GetRandomString();
            var actual = target.Add( expected );

            Assert.AreEqual( actual.Value, expected );
            Assert.IsTrue( target.Contains( actual ) );
            Assert.AreEqual( 1, target.Count );
            Assert.AreSame( target, actual.Parent );
        }

        [Test]
        public void AddTestCase1 ()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            String expected = null;
            var actual = target.Add( expected );

            Assert.AreEqual( actual.Value, expected );
            Assert.IsTrue( target.Contains( actual ) );
            Assert.AreEqual( 1, target.Count );
            Assert.AreSame( target, actual.Parent );
        }

        [Test]
        public void AddTestCase2 ()
        {
            var parent = new TreeNode<String>();
            var target = new TreeNodeCollection<String>( parent );

            var item = new TreeNode<String>();
            target.Add( item );

            Assert.IsTrue( target.Contains( item ) );
            Assert.AreEqual( 1, target.Count );
            Assert.AreSame( target, item.Parent );
        }

        [Test]
        public void CtorTestCase ()
        {
            var parent = new TreeNode<String>();

            var target = new TreeNodeCollection<String>( parent );
            Assert.AreSame( parent, target.Parent );
        }
    }
}