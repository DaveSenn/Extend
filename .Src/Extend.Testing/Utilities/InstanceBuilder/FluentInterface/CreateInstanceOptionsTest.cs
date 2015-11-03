﻿#region Usings

using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class CreateInstanceOptionsTest
    {
        [Test]
        public void AllMembersTest()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.AllMembers();
            actual.Should()
                  .BeSameAs( target );

            target.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = target.MemberSelectionRules.First() as AllMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ByPathExpressionArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Expression<Func<String, Object>> expression = null;
            Action test = () => target.ByPath( expression );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ByPathExpressionTest()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.ByPath( x => x.Length );
            actual.Should()
                  .BeSameAs( target );

            target.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = target.MemberSelectionRules.First() as PathMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ByPathStringArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            String expression = null;
            Action test = () => target.ByPath( expression );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ByPathStringTest()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.ByPath( "test" );
            actual.Should()
                  .BeSameAs( target );

            target.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = target.MemberSelectionRules.First() as PathMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void CompleteTest()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.Complete();

            actual.Should()
                  .BeSameAs( target );
        }

        [Test]
        public void ExcludingAllMembersTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.Excluding( x =>
            {
                functionCalled = true;
                return x.AllMembers();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as AllMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingChildrenOfAllMembersTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.ExcludingChildrenOf( x =>
            {
                functionCalled = true;
                return x.AllMembers();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as AllMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingChildrenOfExpressionTest()
        {
            var target = new CreateInstanceOptions<String>();
            target.ExcludingChildrenOf( x => true );

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as ExpressionMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingChildrenOfFuncArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Func<IIncludeExcludeOptions<String>, IIncludeExcludeOptions<String>> configurationFunc = null;
            Action test = () => target.ExcludingChildrenOf( configurationFunc );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExcludingChildrenOfIsNotTypeOfTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.ExcludingChildrenOf( x =>
            {
                functionCalled = true;
                return x.IsNotTypeOf<String>();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as TypeMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingChildrenOfIsTypeOfTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.ExcludingChildrenOf( x =>
            {
                functionCalled = true;
                return x.IsTypeOf<String>();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as TypeMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingChildrenOfPathExpressionTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.ExcludingChildrenOf( x =>
            {
                functionCalled = true;
                return x.ByPath( y => y.Length );
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as PathMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingChildrenOfPathStringTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.ExcludingChildrenOf( x =>
            {
                functionCalled = true;
                return x.ByPath( "Test" );
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as PathMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingChildrenOfPredicateArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Func<IMemberInformation, Boolean> predicate = null;
            Action test = () => target.ExcludingChildrenOf( predicate );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExcludingExpressionTest()
        {
            var target = new CreateInstanceOptions<String>();
            target.Excluding( x => true );

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as ExpressionMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingFuncArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Func<IIncludeExcludeOptions<String>, IIncludeExcludeOptions<String>> configurationFunc = null;
            Action test = () => target.Excluding( configurationFunc );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExcludingIsNotTypeOfTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.Excluding( x =>
            {
                functionCalled = true;
                return x.IsNotTypeOf<String>();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as TypeMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingIsTypeOfTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.Excluding( x =>
            {
                functionCalled = true;
                return x.IsTypeOf<String>();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as TypeMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingPathExpressionTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.Excluding( x =>
            {
                functionCalled = true;
                return x.ByPath( y => y.Length );
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as PathMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingPathStringTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.Excluding( x =>
            {
                functionCalled = true;
                return x.ByPath( "Test" );
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as PathMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void ExcludingPredicateArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Func<IMemberInformation, Boolean> predicate = null;
            Action test = () => target.Excluding( predicate );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ForFuncArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            target.WithFactory( x => "test" );
            Func<IIncludeExcludeOptions<String>, IIncludeExcludeOptions<String>> configurationFunc = null;
            Action test = () => target.For( configurationFunc );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ForFuncInvalidOperationExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Action test = () => target.For( x => x.AllMembers() );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void ForFuncTest()
        {
            var funcCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.WithFactory( x => "test" );
            var actual = target.For( x =>
            {
                funcCalled = true;
                return x.AllMembers();
            } );

            funcCalled.Should()
                      .BeTrue();

            actual.Should()
                  .BeSameAs( target );

            var factory = target.Factories.First();
            factory.SelectionRules.Count.Should()
                   .Be( 1 );
            var rule = factory.SelectionRules.First() as AllMemberSelectionRule;
            rule.Should()
                .NotBeNull();
        }

        [Test]
        public void ForPredicateArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            target.WithFactory( x => "test" );
            Func<IMemberInformation, Boolean> predicate = null;
            Action test = () => target.For( predicate );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ForPredicateInvalidOperationExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Action test = () => target.For( x => true );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void ForPredicateTest()
        {
            var target = new CreateInstanceOptions<String>();
            target.WithFactory( x => true );
            var actual = target.For( x => true );

            actual.Should()
                  .BeSameAs( target );

            var factory = target.Factories.First();
            factory.SelectionRules.Count.Should()
                   .Be( 1 );
            var rule = factory.SelectionRules.First() as ExpressionMemberSelectionRule;
            rule.Should()
                .NotBeNull();
        }

        [Test]
        public void IncludingAllMembersTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.Including( x =>
            {
                functionCalled = true;
                return x.AllMembers();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as AllMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingChildrenOfAllMembersTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.IncludingChildrenOf( x =>
            {
                functionCalled = true;
                return x.AllMembers();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as AllMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingChildrenOfExpressionTest()
        {
            var target = new CreateInstanceOptions<String>();
            target.IncludingChildrenOf( x => true );

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as ExpressionMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingChildrenOfFuncArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Func<IIncludeExcludeOptions<String>, IIncludeExcludeOptions<String>> configurationFunc = null;
            Action test = () => target.IncludingChildrenOf( configurationFunc );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IncludingChildrenOfIsNotTypeOfTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.IncludingChildrenOf( x =>
            {
                functionCalled = true;
                return x.IsNotTypeOf<String>();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as TypeMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingChildrenOfIsTypeOfTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.IncludingChildrenOf( x =>
            {
                functionCalled = true;
                return x.IsTypeOf<String>();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as TypeMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingChildrenOfPathExpressionTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.IncludingChildrenOf( x =>
            {
                functionCalled = true;
                return x.ByPath( y => y.Length );
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as PathMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingChildrenOfPathStringTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.IncludingChildrenOf( x =>
            {
                functionCalled = true;
                return x.ByPath( "Test" );
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberChildrenSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberChildrenSelectionRules.First() as PathMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingChildrenOfPredicateArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Func<IMemberInformation, Boolean> predicate = null;
            Action test = () => target.IncludingChildrenOf( predicate );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IncludingExpressionTest()
        {
            var target = new CreateInstanceOptions<String>();
            target.Including( x => true );

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as ExpressionMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingFuncArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Func<IIncludeExcludeOptions<String>, IIncludeExcludeOptions<String>> configurationFunc = null;
            Action test = () => target.Including( configurationFunc );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IncludingIsNotTypeOfTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.Including( x =>
            {
                functionCalled = true;
                return x.IsNotTypeOf<String>();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as TypeMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingIsTypeOfTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.Including( x =>
            {
                functionCalled = true;
                return x.IsTypeOf<String>();
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as TypeMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingPathExpressionTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.Including( x =>
            {
                functionCalled = true;
                return x.ByPath( y => y.Length );
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as PathMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingPathStringTest()
        {
            var functionCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.Including( x =>
            {
                functionCalled = true;
                return x.ByPath( "Test" );
            } );

            functionCalled.Should()
                          .BeTrue();

            var actual = target.Complete();
            actual.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = actual.MemberSelectionRules.First() as PathMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IncludingPredicateArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Func<IMemberInformation, Boolean> predicate = null;
            Action test = () => target.Including( predicate );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsNotTypeOfTest()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.IsNotTypeOf<String>();
            actual.Should()
                  .BeSameAs( target );

            target.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = target.MemberSelectionRules.First() as TypeMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void IsTypeOfTest()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.IsTypeOf<String>();
            actual.Should()
                  .BeSameAs( target );

            target.MemberSelectionRules.Count.Should()
                  .Be( 1 );

            var actualRule = target.MemberSelectionRules.First() as TypeMemberSelectionRule;
            actualRule.Should()
                      .NotBeNull();
        }

        [Test]
        public void NotForFuncArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            target.WithFactory( x => "test" );
            Func<IIncludeExcludeOptions<String>, IIncludeExcludeOptions<String>> configurationFunc = null;
            Action test = () => target.NotFor( configurationFunc );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void NotForFuncInvalidOperationExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Action test = () => target.NotFor( x => x.AllMembers() );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void NotForFuncTest()
        {
            var funcCalled = false;
            var target = new CreateInstanceOptions<String>();
            target.WithFactory( x => "test" );
            var actual = target.NotFor( x =>
            {
                funcCalled = true;
                return x.AllMembers();
            } );

            funcCalled.Should()
                      .BeTrue();

            actual.Should()
                  .BeSameAs( target );

            var factory = target.Factories.First();
            factory.SelectionRules.Count.Should()
                   .Be( 1 );
            var rule = factory.SelectionRules.First() as AllMemberSelectionRule;
            rule.Should()
                .NotBeNull();
        }

        [Test]
        public void NotForPredicateArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            target.WithFactory( x => "test" );
            Func<IMemberInformation, Boolean> predicate = null;
            Action test = () => target.NotFor( predicate );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void NotForPredicateInvalidOperationExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Action test = () => target.NotFor( x => true );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void NotForPredicateTest()
        {
            var target = new CreateInstanceOptions<String>();
            target.WithFactory( x => true );
            var actual = target.NotFor( x => true );

            actual.Should()
                  .BeSameAs( target );

            var factory = target.Factories.First();
            factory.SelectionRules.Count.Should()
                   .Be( 1 );
            var rule = factory.SelectionRules.First() as ExpressionMemberSelectionRule;
            rule.Should()
                .NotBeNull();
        }

        [Test]
        public void PopulateCollectionItemCountArgumentExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Action test = () => target.PopulateCollectionItemCount( 400, 300 );
            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void PopulateCollectionItemCountTest()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.PopulateCollectionItemCount( 100, 200 );
            actual.Should()
                  .BeSameAs( target );
            target.PopulateCollectionsMinCount.Should()
                  .Be( 100 );
            target.PopulateCollectionsMaxCount.Should()
                  .Be( 200 );
        }

        [Test]
        public void PopulateCollectionItemCountTest1()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.PopulateCollectionItemCount( 100, null );
            actual.Should()
                  .BeSameAs( target );
            target.PopulateCollectionsMinCount.Should()
                  .Be( 100 );
            target.PopulateCollectionsMaxCount.Should()
                  .Be( null );
        }

        [Test]
        public void PopulateCollectionItemCountTest2()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.PopulateCollectionItemCount( null, 200 );
            actual.Should()
                  .BeSameAs( target );
            target.PopulateCollectionsMinCount.Should()
                  .Be( null );
            target.PopulateCollectionsMaxCount.Should()
                  .Be( 200 );
        }

        [Test]
        public void PopulateCollectionMembersTest()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.PopulateCollectionMembers( false );
            actual.Should()
                  .BeSameAs( target );
            target.PopulateCollections.Should()
                  .Be( false );
        }

        [Test]
        public void PopulateCollectionMembersTest1()
        {
            var target = new CreateInstanceOptions<String>();
            var actual = target.PopulateCollectionMembers( null );
            actual.Should()
                  .BeSameAs( target );
            target.PopulateCollections.Should()
                  .Be( null );
        }

        [Test]
        public void WithFactoryArgumentNullExceptionTest()
        {
            var target = new CreateInstanceOptions<String>();
            Func<IMemberInformation, Object> factory = null;
            Action test = () => target.WithFactory( factory );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void WithFactoryTest()
        {
            var target = new CreateInstanceOptions<String>();
            Func<IMemberInformation, Object> factory = x => "test";
            var actual = target.WithFactory( factory );
            actual.Should()
                  .BeSameAs( target );
            target.Factories.Count.Should()
                  .Be( 1 );
            var actualFactoryResult = ( target.Factories.First() as ExpressionInstanceFactory ).CreateValue( null );
            actualFactoryResult.Should()
                               .Be( "test" );
        }
    }
}