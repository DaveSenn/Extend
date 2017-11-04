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

            // 1 => root
            HierarchicItem value1;
            collection.Add( value1 = new HierarchicItem
            {
                Id = 1,
                Value = "1",
                Parent = null
            } );

            // 2 => child of 1
            HierarchicItem value2;
            collection.Add( value2 = new HierarchicItem
            {
                Id = 2,
                Value = "2",
                Parent = value1
            } );
            value1.Children.Add( value2 );

            // 3 => child of 2
            HierarchicItem value3;
            collection.Add( value3 = new HierarchicItem
            {
                Id = 3,
                Value = "3",
                Parent = value2
            } );
            value2.Children.Add( value3 );

            // 4 => child of 3
            HierarchicItem value4;
            collection.Add( value4 = new HierarchicItem
            {
                Id = 4,
                Value = "4",
                Parent = value3
            } );
            value3.Children.Add( value4 );

            // 10 => root
            collection.Add( new HierarchicItem
            {
                Id = 10,
                Value = "10",
                Parent = null
            } );

            // 20 => root
            HierarchicItem value20;
            collection.Add( value20 = new HierarchicItem
            {
                Id = 20,
                Value = "20",
                Parent = null
            } );

            // 21 => child of 20
            HierarchicItem value21;
            collection.Add( value21 = new HierarchicItem
            {
                Id = 21,
                Value = "21",
                Parent = value20
            } );
            value20.Children.Add( value21 );

            var actual = collection.ToTreeNodeCollection( x => x.Id, x => x.Parent?.Id, null );

            actual.Should()
                  .HaveCount( 3 );

            // Assert 1 inclusive children
            actual.Where( x => x.Value.Id == 1 )
                  .Should()
                  .HaveCount( 1 );
            var actual1 = actual.First( x => x.Value.Id == 1 );
            actual1.Children.Should()
                   .HaveCount( 1 );

            // Assert 2
            var actual2 = actual1.Children.First();
            actual2.Value.Id.Should()
                   .Be( 2 );
            actual2.Children.Should()
                   .HaveCount( 1 );

            // Assert 3
            var actual3 = actual2.Children.First();
            actual3.Value.Id.Should()
                   .Be( 3 );
            actual3.Children.Should()
                   .HaveCount( 1 );

            // Assert 4
            var actual4 = actual3.Children.First();
            actual4.Value.Id.Should()
                   .Be( 4 );
            actual4.Children.Should()
                   .HaveCount( 0 );

            // Assert 10 inclusive children
            actual.Where( x => x.Value.Id == 10 )
                  .Should()
                  .HaveCount( 1 );
            actual.First( x => x.Value.Id == 10 )
                  .Children.Should()
                  .HaveCount( 0 );

            // Assert 20 inclusive children
            actual.Where( x => x.Value.Id == 20 )
                  .Should()
                  .HaveCount( 1 );
            var actual20Children = actual.First( x => x.Value.Id == 20 )
                                         .Children;
            actual20Children.Should()
                            .HaveCount( 1 );
            actual20Children.First()
                            .Value.Id.Should()
                            .Be( 21 );
            actual20Children.First()
                            .Children.Should()
                            .HaveCount( 0 );
        }

        [Fact]
        public void ToTreeTest_DuplicateId()
        {
            var collection = new List<HierarchicItem>();

            // 1 => root
            HierarchicItem value1;
            collection.Add( value1 = new HierarchicItem
            {
                Id = 1,
                Value = "1",
                Parent = null
            } );

            // 2 => child of 1
            HierarchicItem value2;
            collection.Add( value2 = new HierarchicItem
            {
                Id = 1,
                Value = "2",
                Parent = value1
            } );
            value1.Children.Add( value2 );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => collection.ToTreeNodeCollection( x => x.Id, x => x.Parent?.Id, null );
            test.ShouldThrow<InvalidOperationException>()
                .WithMessage( "The following items do not have a unique id:\r\n	 1\r\n	 2\r\n" );
        }

        [Fact]
        public void ToTreeTest_InconclusiveParentChildRelationship()
        {
            var collection = new List<HierarchicItem>();

            // 1 => root
            HierarchicItem value1;
            collection.Add( value1 = new HierarchicItem
            {
                Id = 1,
                Value = "1",
                Parent = null
            } );

            // 2 => child of 1
            HierarchicItem value2;
            collection.Add( value2 = new HierarchicItem
            {
                Id = 2,
                Value = "2",
                Parent = value1
            } );
            value1.Children.Add( value2 );

            // 4 => child of 3 [ 3 is NOT part of the collection ]
            HierarchicItem value3;
            HierarchicItem value4;
            collection.Add( value4 = new HierarchicItem
            {
                Id = 4,
                Value = "4",
                Parent = value3 = new HierarchicItem
                {
                    Id = 3,
                    Value = "3",
                    Parent = value2
                }
            } );
            value3.Children.Add( value4 );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => collection.ToTreeNodeCollection( x => x.Id, x => x.Parent?.Id, null );
            test.ShouldThrow<InvalidOperationException>()
                .WithMessage( "Could not find a matching parent for the following items:\r\n\t 4\r\n" );
        }

        [Fact]
        public void ToTreeTest_InconclusiveParentChildRelationship1()
        {
            var collection = new List<HierarchicItem>();

            // 1 => root
            HierarchicItem value1;
            collection.Add( value1 = new HierarchicItem
            {
                Id = 1,
                Value = "1",
                Parent = null
            } );

            // 2 => child of 1
            HierarchicItem value2;
            collection.Add( value2 = new HierarchicItem
            {
                Id = 2,
                Value = "2",
                Parent = value1
            } );
            value1.Children.Add( value2 );

            // 4 => child of 3 [ 3 is NOT part of the collection ]
            HierarchicItem value3;
            HierarchicItem value4;
            collection.Add( value4 = new HierarchicItem
            {
                Id = 4,
                Value = "4",
                Parent = value3 = new HierarchicItem
                {
                    Id = 3,
                    Value = "3",
                    Parent = value2
                }
            } );
            value3.Children.Add( value4 );

            // 5 => child of 3 [ 3 is NOT part of the collection ]
            HierarchicItem value5;
            collection.Add( value5 = new HierarchicItem
            {
                Id = 5,
                Value = "5",
                Parent = value3
            } );
            value3.Children.Add( value5 );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => collection.ToTreeNodeCollection( x => x.Id, x => x.Parent?.Id, null );
            test.ShouldThrow<InvalidOperationException>()
                .WithMessage( "Could not find a matching parent for the following items:\r\n\t 4\r\n\t 5\r\n" );
        }

        [Fact]
        public void ToTreeTest1()
        {
            var collection = new List<HierarchicItem>();

            // 1 => root
            HierarchicItem value1;
            collection.Add( value1 = new HierarchicItem
            {
                Id = 1,
                Value = "1",
                Parent = null
            } );

            // 2 => child of 1
            HierarchicItem value2;
            collection.Add( value2 = new HierarchicItem
            {
                Id = 2,
                Value = "2",
                Parent = value1
            } );
            value1.Children.Add( value2 );
            // 2.1 => child of 1
            HierarchicItem value201;
            collection.Add( value201 = new HierarchicItem
            {
                Id = 201,
                Value = "2.1",
                Parent = value1
            } );
            value1.Children.Add( value201 );
            // 2.1 => child of 1
            HierarchicItem value2011;
            collection.Add( value2011 = new HierarchicItem
            {
                Id = 2011,
                Value = "2.11",
                Parent = value201
            } );
            value201.Children.Add( value2011 );

            // 3 => child of 2
            HierarchicItem value3;
            collection.Add( value3 = new HierarchicItem
            {
                Id = 3,
                Value = "3",
                Parent = value2
            } );
            value2.Children.Add( value3 );

            // 4 => child of 3
            HierarchicItem value4;
            collection.Add( value4 = new HierarchicItem
            {
                Id = 4,
                Value = "4",
                Parent = value3
            } );
            value3.Children.Add( value4 );

            // 10 => root
            collection.Add( new HierarchicItem
            {
                Id = 10,
                Value = "10",
                Parent = null
            } );

            // 20 => root
            HierarchicItem value20;
            collection.Add( value20 = new HierarchicItem
            {
                Id = 20,
                Value = "20",
                Parent = null
            } );

            // 21 => child of 20
            HierarchicItem value21;
            collection.Add( value21 = new HierarchicItem
            {
                Id = 21,
                Value = "21",
                Parent = value20
            } );
            value20.Children.Add( value21 );

            var actual = collection.ToTreeNodeCollection( x => x.Id, x => x.Parent?.Id, null );

            actual.Should()
                  .HaveCount( 3 );

            // Assert 1 inclusive children
            actual.Where( x => x.Value.Id == 1 )
                  .Should()
                  .HaveCount( 1 );
            var actual1 = actual.First( x => x.Value.Id == 1 );
            actual1.Children.Should()
                   .HaveCount( 2 );

            // Assert 2.1
            var actual21 = actual1.Children.First( x => x.Value.Id == 201 );
            actual21.Value.Id.Should()
                    .Be( 201 );
            actual21.Children.Should()
                    .HaveCount( 1 );

            // Assert 3
            var actual211 = actual21.Children.First();
            actual211.Value.Id.Should()
                     .Be( 2011 );
            actual211.Children.Should()
                     .HaveCount( 0 );

            // Assert 2
            var actual2 = actual1.Children.First( x => x.Value.Id == 2 );
            actual2.Value.Id.Should()
                   .Be( 2 );
            actual2.Children.Should()
                   .HaveCount( 1 );

            /*
             
[Depth: 1 - Value: '1', Children: 2]
    [Depth: 2 - Value: '2', Children: 1]
        [Depth: 3 - Value: '3', Children: 1]
            [Depth: 4 - Value: '4', Children: 0]

    [Depth: 2 - Value: '2.1', Children: 1]
        [Depth: 3 - Value: '2.11', Children: 0]

[Depth: 1 - Value: '10', Children: 0]
[Depth: 1 - Value: '20', Children: 1]
    [Depth: 2 - Value: '21', Children: 0]
             */

            // Assert 3
            var actual3 = actual2.Children.First();
            actual3.Value.Id.Should()
                   .Be( 3 );
            actual3.Children.Should()
                   .HaveCount( 1 );

            // Assert 4
            var actual4 = actual3.Children.First();
            actual4.Value.Id.Should()
                   .Be( 4 );
            actual4.Children.Should()
                   .HaveCount( 0 );

            // Assert 10 inclusive children
            actual.Where( x => x.Value.Id == 10 )
                  .Should()
                  .HaveCount( 1 );
            actual.First( x => x.Value.Id == 10 )
                  .Children.Should()
                  .HaveCount( 0 );

            // Assert 20 inclusive children
            actual.Where( x => x.Value.Id == 20 )
                  .Should()
                  .HaveCount( 1 );
            var actual20Children = actual.First( x => x.Value.Id == 20 )
                                         .Children;
            actual20Children.Should()
                            .HaveCount( 1 );
            actual20Children.First()
                            .Value.Id.Should()
                            .Be( 21 );
            actual20Children.First()
                            .Children.Should()
                            .HaveCount( 0 );
        }

        #region Nested Types

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

             var result = actual.Count == 1 ? new TreeNode<HierarchicItem>(actual.First().Value, actual.First().Children) : new TreeNode<HierarchicItem>(null, actual);

             var s = result.ToString();
       */

        private class HierarchicItem
        {
            #region Properties

            public Int32 Id { get; set; }

            public HierarchicItem Parent { get; set; }

            public String Value { get; set; }

            // ReSharper disable once CollectionNeverQueried.Local
            public List<HierarchicItem> Children { get; } = new List<HierarchicItem>();

            #endregion

            #region Overrides of Object

            /// <summary>Returns a string that represents the current object.</summary>
            /// <returns>A string that represents the current object.</returns>
            public override String ToString()
                => Value;

            #endregion
        }

        #endregion
    }
}