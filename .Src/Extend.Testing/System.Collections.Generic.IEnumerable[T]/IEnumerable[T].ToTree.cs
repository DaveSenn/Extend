#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void ToTreeTest()
        {
            var collection = new List<HierarchicItem>();

            for ( var i = 0; i < 5; i++ )
                collection.Add( new HierarchicItem
                {
                    Id = i,
                    Value = i.ToString(),
                    ParentId = i == 0 ? null : i - 1 as Int32?
                } );

            collection.Add(new HierarchicItem
            {
                Id = 10,
                Value = "10",
                ParentId = null
            });

            var actual = collection.ToTree( x => x.Id, x => x.ParentId, null );
            
            var result = actual.Count == 1 ? new TreeNode<HierarchicItem>(actual.First().Value, actual.First().Children) : new TreeNode<HierarchicItem>(null, actual);

            var s = result.ToString();
        }

        /*
       /// <summary>
       ///     TODO: MOVE TO EXTEND.
       /// </summary>
       /// <param name="breadcrumbItems"></param>
       /// <returns></returns>
       private TreeNode<BreadcrumbItem> ToTree( IEnumerable<BreadcrumbItem> breadcrumbItems )
           => new TreeNode<BreadcrumbItem>( null, 
           
                ToTree( 
                    breadcrumbItems, 
                    x => x.BreadcrumbItemId, 
                    x => x.Parent?.BreadcrumbItemId ?? Guid.Empty, 
                    Guid.Empty ) );
       */

        private class HierarchicItem
        {
            public Int32 Id { get; set; }
            public Int32? ParentId { get; set; }

            public String Value { get; set; }

            #region Overrides of Object

            /// <summary>Returns a string that represents the current object.</summary>
            /// <returns>A string that represents the current object.</returns>
            public override String ToString() 
                => Value;

            #endregion
        }
    }
}