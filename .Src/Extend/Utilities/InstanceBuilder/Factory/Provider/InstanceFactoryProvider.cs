#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Factory provider.
    /// </summary>
    internal static class InstanceFactoryProvider
    {
        /// <summary>
        ///     Gets the default instance factories.
        /// </summary>
        /// <returns>Returns the factories.</returns>
        internal static IEnumerable<IInstanceFactory> GetDefaultFactories()
        {
            yield return
                new ExpressionInstanceFactory( x => RandomValueEx.GetRandomInt16(), "Int16 Factory", "Factory for Int16 values." )
                    .AddSelectionRule( new TypeMemberSelectionRule( typeof (Int16),
                                                                    MemberSelectionMode.Include,
                                                                    CompareMode.Is,
                                                                    "Int16 Selector",
                                                                    "Includes all members of type Int16" ) );

            yield return
                new ExpressionInstanceFactory( x => RandomValueEx.GetRandomInt32(), "Int32 Factory", "Factory for Int32 values." )
                    .AddSelectionRule( new TypeMemberSelectionRule( typeof (Int32),
                                                                    MemberSelectionMode.Include,
                                                                    CompareMode.Is,
                                                                    "Int32 Selector",
                                                                    "Includes all members of type Int32" ) );

            yield return
                new ExpressionInstanceFactory( x => RandomValueEx.GetRandomInt64(), "Int64 Factory", "Factory for Int64 values." )
                    .AddSelectionRule( new TypeMemberSelectionRule( typeof (Int64),
                                                                    MemberSelectionMode.Include,
                                                                    CompareMode.Is,
                                                                    "Int64 Selector",
                                                                    "Includes all members of type Int64" ) );

            yield return
                new ExpressionInstanceFactory( x => RandomValueEx.GetRandomDouble(), "Double Factory", "Factory for Double values." )
                    .AddSelectionRule( new TypeMemberSelectionRule( typeof (Double),
                                                                    MemberSelectionMode.Include,
                                                                    CompareMode.Is,
                                                                    "Double Selector",
                                                                    "Includes all members of type Double" ) );

            yield return
                new ExpressionInstanceFactory( x => RandomValueEx.GetRandomChar(), "Char Factory", "Factory for Char values." )
                    .AddSelectionRule( new TypeMemberSelectionRule( typeof (Char),
                                                                    MemberSelectionMode.Include,
                                                                    CompareMode.Is,
                                                                    "Char Selector",
                                                                    "Includes all members of type Char" ) );

            yield return
                new ExpressionInstanceFactory( x => RandomValueEx.GetRandomString(), "String Factory", "Factory for String values." )
                    .AddSelectionRule( new TypeMemberSelectionRule( typeof (String),
                                                                    MemberSelectionMode.Include,
                                                                    CompareMode.Is,
                                                                    "String Selector",
                                                                    "Includes all members of type String" ) );

            yield return
                new ExpressionInstanceFactory( x => RandomValueEx.GetRandomBoolean(), "Boolean Factory", "Factory for Boolean values." )
                    .AddSelectionRule( new TypeMemberSelectionRule( typeof (Boolean),
                                                                    MemberSelectionMode.Include,
                                                                    CompareMode.Is,
                                                                    "Boolean Selector",
                                                                    "Includes all members of type Boolean" ) );

            yield return
                new ExpressionInstanceFactory( x => RandomValueEx.GetRandomDateTime(), "DateTime Factory", "Factory for DateTime values." )
                    .AddSelectionRule( new TypeMemberSelectionRule( typeof (DateTime),
                                                                    MemberSelectionMode.Include,
                                                                    CompareMode.Is,
                                                                    "DateTime Selector",
                                                                    "Includes all members of type DateTime" ) );
        }
    }
}