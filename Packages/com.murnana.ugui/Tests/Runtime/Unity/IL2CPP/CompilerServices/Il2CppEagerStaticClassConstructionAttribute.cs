#nullable enable
using System;
using System.Diagnostics;

namespace Unity.IL2CPP.CompilerServices
{
    // Modelled after: https://github.com/dotnet/corert/blob/master/src/Runtime.Base/src/System/Runtime/CompilerServices/EagerStaticClassConstructionAttribute.cs
    //
    // When applied to a type this custom attribute will cause any static class constructor to be run eagerly
    // at module load time rather than deferred till just before the class is used.
    [Conditional (conditionString: "ENABLE_IL2CPP")]
    [AttributeUsage (validOn: AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    internal sealed class Il2CppEagerStaticClassConstructionAttribute : Attribute
    {
    }
}