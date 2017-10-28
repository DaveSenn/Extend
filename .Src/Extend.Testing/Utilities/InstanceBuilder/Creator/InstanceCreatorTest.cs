#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    [Collection( "InstanceCreator" )]
    public class InstanceCreatorTest
    {
        [Fact]
        public void ActivatorFailTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<ModelNeedingFactory>();

            Action test = () => options.Complete()
                                       // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                       .CreateInstance();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage( "Failed to create instance due to missing or invalid factory for type 'Extend.Testing.InstanceCreatorTest+ModelWithCtor'." );
        }

        [Fact]
        public void AnonymousItemNameDefaultValueTest()
            => InstanceCreator.AnonymousItemName.Should()
                              .Be( "[AnonymousItem]" );

        [Fact]
        public void AnonymousItemNameTest()
        {
            var expected = RandomValueEx.GetRandomString();
            InstanceCreator.AnonymousItemName = expected;
            InstanceCreator.AnonymousItemName.Should()
                           .Be( expected );

            InstanceCreator.AnonymousItemName = "[AnonymousItem]";
        }

        [Fact]
        public void CreateInstanceICollectionTest()
        {
            var actual = InstanceCreator
                .CreateInstance<ModelWithCollection>();

            actual.Should()
                  .NotBeNull();

            actual.MyArray.Should()
                  .NotBeEmpty();
            actual.MyList.Should()
                  .NotBeEmpty();
            actual.MyEnumerable.Should()
                  .NotBeEmpty();
            actual.MyListInterface.Should()
                  .NotBeEmpty();
            actual.MyCollection.Should()
                  .NotBeEmpty();
        }

        [Fact]
        public void CreateInstanceOptionsTest()
        {
            var actual = InstanceCreator.CreateInstanceOptions<TestModel>();
            actual.Should()
                  .NotBeNull();
        }

        [Fact]
        public void CreateInstanceTest()
        {
            var actual = InstanceCreator.CreateInstance<TestModel>();
            actual.Should()
                  .NotBeNull();
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void DefaultMemberSelectionRulesDefaultTest()
        {
            var actual = InstanceCreator.DefaultMemberSelectionRules;

            actual.Count.Should()
                  .Be( 1,
                       actual.Select( x => x.RuleName )
                             .StringJoin( ", " ) );
            actual.Count( x => x.RuleName == "Include all members" )
                  .Should()
                  .Be( 1 );
        }

        [Fact]
        public void DefaultMemberSelectionRulesTest()
        {
            var rule = new AllMemberSelectionRule( MemberSelectionMode.Include );
            InstanceCreator.DefaultMemberSelectionRules.Add( rule );

            InstanceCreator.DefaultMemberSelectionRules.Contains( rule )
                           .Should()
                           .BeTrue();

            InstanceCreator.DefaultMemberSelectionRules.Remove( rule );
        }

        [Fact]
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

        [Fact]
        public void ExcludeMemberTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>();
            options.Excluding( x => x.ByPath( y => y.MyIntList ) );

            var actual = options.Complete()
                                .CreateInstance();
            actual.MyIntList.Should()
                  .BeNull();
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void FactoryThrowsExceptionTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>()
                                         .WithFactory( x => throw new Exception( "Factory Failed" ) )
                                         .For( x => x.IsTypeOf<Double>() );

            Action test = () => options.Complete()
                                       // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                       .CreateInstance();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage( "Factory has thrown exception." );
        }

        [Fact]
        public void MultipleMatchingFactoriesInGlobalConfigTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>();

            var factory = new ExpressionInstanceFactory( x => 100 )
                .AddSelectionRule( new TypeMemberSelectionRule( typeof(Double), MemberSelectionMode.Include, CompareMode.Is ) );
            InstanceCreator.DefaultFactories.Add( factory );

            Action test = () => options.Complete()
                                       // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                       .CreateInstance();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage(
                    "Found multiple matching factories for member (in global configuration). Type is 'System.Double'.  Please make sure only one factory matches the member." );

            InstanceCreator.DefaultFactories.Remove( factory );
            InstanceCreator.DefaultFactories.Contains( factory )
                           .Should()
                           .BeFalse();
        }

        [Fact]
        public void MultipleMatchingFactoriesInOptionsTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>()
                                         .WithFactory( x => 100 )
                                         .For( x => x.IsTypeOf<Double>() )
                                         .WithFactory( x => 200 )
                                         .For( x => x.IsTypeOf<Double>() );

            Action test = () => options.Complete()
                                       // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                       .CreateInstance();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage( "Found multiple matching factories for member (in options). Type is 'System.Double'. Please make sure only one factory matches the member." );
        }

        [Fact]
        public void NoMatchingSelectionRuleTest()
        {
            var rules = new List<IMemberSelectionRule>( InstanceCreator.DefaultMemberSelectionRules );
            InstanceCreator.DefaultMemberSelectionRules.Clear();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => InstanceCreator.CreateInstance<TestModel>();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage( "Found no selection rule targeting member." );

            rules.ForEach( x => InstanceCreator.DefaultMemberSelectionRules.Add( x ) );
        }

        [Fact]
        public void PopulateCollectionsDefaultValueTest() => InstanceCreator.PopulateCollections.Should()
                                                                            .BeTrue();

        [Fact]
        public void PopulateCollectionsMaxCountDefaultValueTest() => InstanceCreator.PopulateCollectionsMaxCount.Should()
                                                                                    .Be( 10 );

        [Fact]
        public void PopulateCollectionsMaxCountTest()
        {
            var expeted = RandomValueEx.GetRandomInt32();
            InstanceCreator.PopulateCollectionsMaxCount = expeted;
            InstanceCreator.PopulateCollectionsMaxCount.Should()
                           .Be( expeted );
            InstanceCreator.PopulateCollectionsMaxCount = 10;
        }

        [Fact]
        public void PopulateCollectionsMinCountDefaultValueTest() => InstanceCreator.PopulateCollectionsMinCount.Should()
                                                                                    .Be( 2 );

        [Fact]
        public void PopulateCollectionsMinCountTest()
        {
            var expeted = RandomValueEx.GetRandomInt32();
            InstanceCreator.PopulateCollectionsMinCount = expeted;
            InstanceCreator.PopulateCollectionsMinCount.Should()
                           .Be( expeted );
            InstanceCreator.PopulateCollectionsMinCount = 2;
        }

        [Fact]
        public void PopulateCollectionsTest()
        {
            var expeted = RandomValueEx.GetRandomBoolean();
            InstanceCreator.PopulateCollections = expeted;
            InstanceCreator.PopulateCollections.Should()
                           .Be( expeted );
            InstanceCreator.PopulateCollections = true;
        }

        [Fact]
        public void PopulateDitionaryTest()
        {
            var actual = InstanceCreator.CreateInstance<ModelWithDitionary>();
            actual.MyStringDitionary.Any()
                  .Should()
                  .BeTrue();
            actual.MyInt32Ditionary.Any()
                  .Should()
                  .BeTrue();
            actual.MyStringKeyDitionary.Any()
                  .Should()
                  .BeTrue();
            actual.MyInt32KeyDitionary.Any()
                  .Should()
                  .BeTrue();
            actual.ComplexDictionary.Any( x => x.Value.MyInt32Enumerable.Any() )
                  .Should()
                  .BeTrue();
        }

        [Fact]
        public void RootFactoryThrowExceptionTest()
        {
            var options = InstanceCreator.CreateInstanceOptions<TestModel>()
                                         .WithFactory( x => throw new Exception( "22" ) )
                                         .For( x => x.IsTypeOf<TestModel>() );

            Action test = () => options.Complete()
                                       // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                       .CreateInstance();
            test.ShouldThrow<CreateInstanceException>()
                .WithMessage( "Failed to create root object of type: TestModel." );
        }

        [Fact]
        public void RuleInspectorDefaultValueTest() => InstanceCreator.RuleInspector.Should()
                                                                      .BeOfType<MemberSelectionRuleInspector>();

        [Fact]
        public void RuleInspectorTest()
        {
            var expeted = new MemberSelectionRuleInspector();
            InstanceCreator.RuleInspector = expeted;
            InstanceCreator.RuleInspector.Should()
                           .BeSameAs( expeted );
        }

        [Fact]
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

        [Fact]
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

        #region Nested Types

        private class ModelNeedingFactory
        {
            #region Properties

            // ReSharper disable once UnusedMember.Local
            public ModelWithCtor MyProperty { get; set; }

            #endregion
        }

        private class ModelWithCollection
        {
            // ReSharper disable UnusedMember.Local
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            // ReSharper disable CollectionNeverUpdated.Local
            public String[] MyArray { get; set; }

            public List<String> MyList { get; set; }
            public IEnumerable<String> MyEnumerable { get; set; }
            public IList<String> MyListInterface { get; set; }

            public ICollection<String> MyCollection { get; set; }
            // ReSharper restore CollectionNeverUpdated.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
            // ReSharper restore UnusedMember.Local
        }

        private class ModelWithCtor
        {
            #region Ctor

            // ReSharper disable once UnusedParameter.Local
            public ModelWithCtor( String arg )
            {
            }

            #endregion
        }

        private class ModelWithDitionary : ModelWithCollection
        {
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            // ReSharper disable CollectionNeverUpdated.Local
            // ReSharper disable UnusedMember.Local
            public Dictionary<String, String> MyStringDitionary { get; set; }

            public Dictionary<Int32, Int32> MyInt32Ditionary { get; set; }
            public Dictionary<String, Int32> MyStringKeyDitionary { get; set; }
            public Dictionary<Int32, String> MyInt32KeyDitionary { get; set; }

            public Dictionary<Int32, TestModel> ComplexDictionary { get; set; }
            // ReSharper restore UnusedMember.Local
            // ReSharper restore CollectionNeverUpdated.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }

        private class SimpleTestModel
        {
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            public String MyString { get; set; }

            public Int32 MyInt32 { get; set; }
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }

        public class SubModel
        {
            #region Properties

            public String MyString { get; set; }

            public Int32? MyNullableInt32 { get; set; }

            public DateTime? MyDateTime { get; set; }

            #endregion
        }

        private class TestModel
        {
            // ReSharper disable UnusedMember.Local
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            public Int16 MyInt16 { get; set; }

            public Int32 MyInt32 { get; set; }
            public Int64 MyInt64 { get; set; }
            public Double MyDouble { get; set; }
            public Char MyChar { get; set; }
            public String MyString { get; set; }
            public Boolean MyBoolean { get; set; }
            public DateTime MyDateTime { get; set; }

            // ReSharper disable once CollectionNeverUpdated.Local
            public List<String> MyStringList { get; set; }

            public List<Int32> MyIntList { get; set; }
            public IEnumerable<String> MyStringEnumerable { get; set; }
            public IEnumerable<Int32> MyInt32Enumerable { get; set; }
            public String[] MyStringArray { get; set; }
            public Int32[] MyIntArray { get; set; }

            public SubModel MySubModel { get; set; }
            // ReSharper restore UnusedAutoPropertyAccessor.Local
            // ReSharper restore UnusedMember.Local
        }

        #endregion
    }
}