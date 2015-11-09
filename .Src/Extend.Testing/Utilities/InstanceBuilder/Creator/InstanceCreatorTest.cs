﻿#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class InstanceCreatorTest
    {
        private class TestModel
        {
            #region Properties

            public Int16 MyInt16 { get; set; }
            public Int32 MyInt32 { get; set; }
            public Int64 MyInt64 { get; set; }
            public Double MyDouble { get; set; }
            public Char MyChar { get; set; }
            public String MyString { get; set; }
            public Boolean MyBoolean { get; set; }
            public DateTime MyDateTime { get; set; }
            public List<String> MyStringList { get; set; }
            public List<Int32> MyIntList { get; set; }
            public IEnumerable<String> MyStringEnumerable { get; set; }
            public IEnumerable<Int32> MyInt32Enumerable { get; set; }
            public String[] MyStringArray { get; set; }
            public Int32[] MyIntArray { get; set; }

            public SubModel MySubModel { get; set; }

            #endregion
        }

        public class SubModel
        {
            #region Properties

            public String MyString { get; set; }

            public Int32? MyNullableInt32 { get; set; }

            public DateTime? MyDateTime { get; set; }

            #endregion
        }

        private class ModelNeedingFactory
        {
            #region Properties

            public ModelWithCtor MyProperty { get; set; }

            #endregion
        }

        private class ModelWithCtor
        {
            #region Ctor

            public ModelWithCtor( String arg )
            {
            }

            #endregion
        }

        private class SimpleTestModel
        {
            #region Properties

            public String MyString { get; set; }
            public Int32 MyInt32 { get; set; }

            #endregion
        }

        [Test]
        public void ActivatorFailTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<ModelNeedingFactory>();

            Action test = () => options.Complete()
                                       .CreateInstance();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage( "Failed to create an instance of the following type 'Extend.Testing.InstanceCreatorTest+ModelWithCtor' using Activator." );
        }

        [Test]
        public void AnonymousItemNameDefaultValueTest()
        {
            InstanceCreator.AnonymousItemName.Should()
                           .Be( "[AnonymousItem]" );
        }

        [Test]
        public void AnonymousItemNameTest()
        {
            var expected = RandomValueEx.GetRandomString();
            InstanceCreator.AnonymousItemName = expected;
            InstanceCreator.AnonymousItemName.Should()
                           .Be( expected );

            InstanceCreator.AnonymousItemName = "[AnonymousItem]";
        }

        [Test]
        public void CreateInstanceOptionsTest()
        {
            var actual = InstanceCreator.CreateInstanceOptions<TestModel>();
            actual.Should()
                  .NotBeNull();
        }

        [Test]
        public void CreateInstanceTest()
        {
            var actual = InstanceCreator.CreateInstance<TestModel>();
            actual.Should()
                  .NotBeNull();
        }

        [Test]
        public void DefaultFactoriesDefaultTest()
        {
            var actual = InstanceCreator.DefaultFactories;

            actual.Count.Should()
                  .Be( 8 );
            actual.Count( x => x.FactoryName.Contains( "Int16" ) )
                  .Should()
                  .Be( 1 );
            actual.Count( x => x.FactoryName.Contains( "Int32" ) )
                  .Should()
                  .Be( 1 );
            actual.Count( x => x.FactoryName.Contains( "Int64" ) )
                  .Should()
                  .Be( 1 );
            actual.Count( x => x.FactoryName.Contains( "Double" ) )
                  .Should()
                  .Be( 1 );
            actual.Count( x => x.FactoryName.Contains( "Char" ) )
                  .Should()
                  .Be( 1 );
            actual.Count( x => x.FactoryName.Contains( "String" ) )
                  .Should()
                  .Be( 1 );
            actual.Count( x => x.FactoryName.Contains( "Boolean" ) )
                  .Should()
                  .Be( 1 );
            actual.Count( x => x.FactoryName.Contains( "DateTime" ) )
                  .Should()
                  .Be( 1 );
        }

        [Test]
        public void DefaultFactoriesTest()
        {
            var factory = new ExpressionInstanceFactory( x => "" );
            InstanceCreator.DefaultFactories.Add( factory );

            InstanceCreator.DefaultFactories.Contains( factory )
                           .Should()
                           .BeTrue();

            InstanceCreator.DefaultFactories.Remove( factory );
            InstanceCreator.DefaultFactories.Contains( factory )
                           .Should()
                           .BeFalse();
        }

        [Test]
        public void DefaultMemberChildreSelectionRulesDefaultValueTest()
        {
            var actual = InstanceCreator.DefaultMemberChildreSelectionRules;
            actual.Count.Should()
                  .Be( 2 );

            actual.Count( x => x.RuleName == "Microsoft Type Filter" )
                  .Should()
                  .Be( 1 );
            actual.Count( x => x.RuleName == "Include all child members" )
                  .Should()
                  .Be( 1 );
        }

        [Test]
        public void DefaultMemberSelectionRulesDefaultTest()
        {
            var actual = InstanceCreator.DefaultMemberSelectionRules;

            actual.Count.Should()
                  .Be( 1 );
            actual.Count( x => x.RuleName == "Include all members" )
                  .Should()
                  .Be( 1 );
        }

        [Test]
        public void DefaultMemberSelectionRulesTest()
        {
            var rule = new AllMemberSelectionRule( MemberSelectionMode.Include );
            InstanceCreator.DefaultMemberSelectionRules.Add( rule );

            InstanceCreator.DefaultMemberSelectionRules.Contains( rule )
                           .Should()
                           .BeTrue();
        }

        [Test]
        public void DoNotPopulateCollectionTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>()
                                         .PopulateCollectionMembers( false );

            var actual = options.Complete()
                                .CreateInstance();
            actual.MyIntList.Should()
                  .BeEmpty();
            actual.MyStringList.Should()
                  .BeEmpty();

            actual.MyIntArray.Should()
                  .BeEmpty();
            actual.MyStringArray.Should()
                  .BeEmpty();

            actual.MyInt32Enumerable.Should()
                  .BeEmpty();
            actual.MyStringEnumerable.Should()
                  .BeEmpty();
        }

        [Test]
        public void ExcludeMemberTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>();
            options.Excluding( x => x.ByPath( y => y.MyIntList ) );

            var actual = options.Complete()
                                .CreateInstance();
            actual.MyIntList.Should()
                  .BeNull();
        }

        [Test]
        public void FactoryTest1()
        {
            var actual = InstanceCreator
                .CreateInstanceOptions<TestModel>()
                .WithFactory( x => 666 )
                .For( x => x.IsTypeOf<Int32>() )
                .Complete()
                .CreateInstance();

            actual.MyInt32.Should()
                  .Be( 666 );
            actual.MyIntList.All( x => x == 666 )
                  .Should()
                  .BeTrue();
            actual.MyIntArray.All( x => x == 666 )
                  .Should()
                  .BeTrue();
        }

        [Test]
        public void FactoryTest2()
        {
            var actual = InstanceCreator
                .CreateInstanceOptions<TestModel>()
                .WithFactory( x => 666 )
                .For( x => x.ByPath( y => y.MyInt32 ) )
                .Complete()
                .CreateInstance();

            actual.MyInt32.Should()
                  .Be( 666 );
            actual.MyIntList.All( x => x == 666 )
                  .Should()
                  .BeFalse();
            actual.MyIntArray.All( x => x == 666 )
                  .Should()
                  .BeFalse();
        }

        [Test]
        public void FactoryTest3()
        {
            var actual = InstanceCreator
                .CreateInstanceOptions<TestModel>()
                .WithFactory( x => 666 )
                .For( x => x.ByPath( "MyInt32" ) )
                .Complete()
                .CreateInstance();

            actual.MyInt32.Should()
                  .Be( 666 );
            actual.MyIntList.All( x => x == 666 )
                  .Should()
                  .BeFalse();
            actual.MyIntArray.All( x => x == 666 )
                  .Should()
                  .BeFalse();
        }

        [Test]
        public void FactoryTest4()
        {
            var actual = InstanceCreator
                .CreateInstanceOptions<TestModel>()
                .WithFactory( x => 666 )
                .For( x => x.ByPath( "MyInt32" ) )
                .Complete()
                .CreateInstance();

            actual.MyInt32.Should()
                  .Be( 666 );
            actual.MyIntList.All( x => x == 666 )
                  .Should()
                  .BeFalse();
            actual.MyIntArray.All( x => x == 666 )
                  .Should()
                  .BeFalse();
        }

        [Test]
        public void FactoryTest5()
        {
            var actual = InstanceCreator
                .CreateInstanceOptions<TestModel>()
                .WithFactory( x => 666 )
                .For( x => x.ByPath( "MyInt32" ) )
                .For( x => x.ByPath( $"MyIntList.{InstanceCreator.AnonymousItemName}" ) )
                .Complete()
                .CreateInstance();

            actual.MyInt32.Should()
                  .Be( 666 );
            actual.MyIntList.All( x => x == 666 )
                  .Should()
                  .BeTrue();
            actual.MyIntArray.All( x => x == 666 )
                  .Should()
                  .BeFalse();
        }

        [Test]
        public void FactoryTest6()
        {
            var actual = InstanceCreator
                .CreateInstanceOptions<SimpleTestModel>()
                .WithFactory( x => 666 )
                .For( x => x.AllMembers() )
                .NotFor( x => x.ByPath( y => y.MyString ) )
                .NotFor( x => x.IsTypeOf<SimpleTestModel>() )
                .WithFactory( x => "test" )
                .For( x => x.IsTypeOf<String>() )
                .Complete()
                .CreateInstance();

            actual.MyInt32.Should()
                  .Be( 666 );
            actual.MyString.Should()
                  .Be( "test" );
        }

        [Test]
        public void FactoryThrowsExceptionTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>()
                                         .WithFactory( x => { throw new Exception( "Factory Failed" ); } )
                                         .For( x => x.IsTypeOf<Double>() );

            Action test = () => options.Complete()
                                       .CreateInstance();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage( "Factory has thrown exception." );
        }

        [Test]
        public void MultipleMatchingFactoriesInGlobalConfigTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>();

            var factory = new ExpressionInstanceFactory( x => 100 )
                .AddSelectionRule( new TypeMemberSelectionRule( typeof (Double), MemberSelectionMode.Include, CompareMode.Is ) );
            InstanceCreator.DefaultFactories.Add( factory );

            Action test = () => options.Complete()
                                       .CreateInstance();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage(
                    "Found multiple matching factories for member (in global configuration). Type is 'System.Double'.  Please make sure only one factory matches the member." );

            InstanceCreator.DefaultFactories.Remove( factory );
            InstanceCreator.DefaultFactories.Contains( factory )
                           .Should()
                           .BeFalse();
        }

        [Test]
        public void MultipleMatchingFactoriesInOptionsTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>()
                                         .WithFactory( x => 100 )
                                         .For( x => x.IsTypeOf<Double>() )
                                         .WithFactory( x => 200 )
                                         .For( x => x.IsTypeOf<Double>() );

            Action test = () => options.Complete()
                                       .CreateInstance();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage( "Found multiple matching factories for member (in options). Type is 'System.Double'. Please make sure only one factory matches the member." );
        }

        [Test]
        public void NoMatchingSelectionRuleTest()
        {
            var rules = new List<IMemberSelectionRule>( InstanceCreator.DefaultMemberSelectionRules );
            InstanceCreator.DefaultMemberSelectionRules.Clear();

            Action test = () => InstanceCreator.CreateInstance<TestModel>();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage( "Found no selection rule targeting member." );

            rules.ForEach( x => InstanceCreator.DefaultMemberSelectionRules.Add( x ) );
        }

        [Test]
        public void PopulateCollectionsDefaultValueTest()
        {
            InstanceCreator.PopulateCollections.Should()
                           .BeTrue();
        }

        [Test]
        public void PopulateCollectionsMaxCountDefaultValueTest()
        {
            InstanceCreator.PopulateCollectionsMaxCount.Should()
                           .Be( 10 );
        }

        [Test]
        public void PopulateCollectionsMaxCountTest()
        {
            var expeted = RandomValueEx.GetRandomInt32();
            InstanceCreator.PopulateCollectionsMaxCount = expeted;
            InstanceCreator.PopulateCollectionsMaxCount.Should()
                           .Be( expeted );
            InstanceCreator.PopulateCollectionsMaxCount = 10;
        }

        [Test]
        public void PopulateCollectionsMinCountDefaultValueTest()
        {
            InstanceCreator.PopulateCollectionsMinCount.Should()
                           .Be( 2 );
        }

        [Test]
        public void PopulateCollectionsMinCountTest()
        {
            var expeted = RandomValueEx.GetRandomInt32();
            InstanceCreator.PopulateCollectionsMinCount = expeted;
            InstanceCreator.PopulateCollectionsMinCount.Should()
                           .Be( expeted );
            InstanceCreator.PopulateCollectionsMinCount = 2;
        }

        [Test]
        public void PopulateCollectionsTest()
        {
            var expeted = RandomValueEx.GetRandomBoolean();
            InstanceCreator.PopulateCollections = expeted;
            InstanceCreator.PopulateCollections.Should()
                           .Be( expeted );
            InstanceCreator.PopulateCollections = true;
        }

        [Test]
        public void RootFactoryThrowExceptionTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>()
                                         .WithFactory( x => { throw new Exception( "22" ); } )
                                         .For( x => x.IsTypeOf<TestModel>() );

            Action test = () => options.Complete()
                                       .CreateInstance();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage( "Failed to create root object of type: TestModel." );
        }

        [Test]
        public void RuleInspectorDefaultValueTest()
        {
            InstanceCreator.RuleInspector.Should()
                           .BeOfType<MemberSelectionRuleInspector>();
        }

        [Test]
        public void RuleInspectorTest()
        {
            var expeted = new MemberSelectionRuleInspector();
            InstanceCreator.RuleInspector = expeted;
            InstanceCreator.RuleInspector.Should()
                           .BeSameAs( expeted );
        }

        [Test]
        public void SelectionRuleTest()
        {
            var actual = InstanceCreator
                .CreateInstanceOptions<SimpleTestModel>()
                .Excluding( x => x.ByPath( y => y.MyString ) )
                .WithFactory( x => 666 )
                .For( x => x.IsTypeOf<Int32>() )
                .Complete()
                .CreateInstance();

            actual.MyInt32.Should()
                  .Be( 666 );
            actual.MyString.Should()
                  .BeNull();
        }

        [Test]
        public void SubModelTest()
        {
            var actual = InstanceCreator.CreateInstance<TestModel>();

            actual.MySubModel.MyDateTime.HasValue.Should()
                  .BeTrue();
            actual.MySubModel.MyNullableInt32.HasValue.Should()
                  .BeTrue();
            actual.MySubModel.MyString.Should()
                  .NotBeEmpty();
        }
    }
}