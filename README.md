
# Suckless Assert

[![Build Status](https://travis-ci.org/robotology/osqp-eigen.svg?branch=master)](https://travis-ci.org/robotology/osqp-eigen)
[![Build status](https://ci.appveyor.com/api/projects/status/ciycnb5lskga8kr1?svg=true)](https://ci.appveyor.com/project/Ja-rek/suckless-assert)
[![Build status](https://buildstats.info/nuget/Suckless.Assert?vWidth=60&dWidth=60)](https://www.nuget.org/packages/Suckless.Assert/)

Library for expressing side effects by creating a contract for beginning value (arguments). This technique can be referred to as "design by contract", "defense programming" or "guard methods".
The Suckless Assert is much faster and simpler than other similar libraries that support fluent API and can get field/property name by the lambda expression.

## Instalation

| CLI | Command |
| ------ | ------ |
| PM | Install-Package Suckless.Assert |
| dotnet | add package Suckless.Assert |
| paket | add Suckless.Assert |

After that use:
``using static Suckless.Asserts.Assertions;``

### Requirements 
Netstandard2.0, C# 7.2 or higher.

## Compare The API
The Suckless Assert:
```csharp
    Assert(anyValue).NotEmpty();
```
Others:
```csharp
    Guard.Argument(anyValue).NotNull().NotEmpty();
    Guard.That(anyValue).IsNotNull().IsNotEmpty();
```
With lambda.
```csharp
    Assert(() => anyValue).NotEmpty();
```
Others:
```csharp
    Guard.That(() => anyValue).IsNotNull().IsNotEmpty();
    anyValue.ThrowIf(() => anyValue).Null().OrIf.Empty();
```

### The API Conception
The Suckless Assert accepted the conventions "Always assert not null first". For example when you "assert" that any field/property is not empty then the value cannot be null as well. Wherefore in this situation, it will throw an ArgumentNullException or ArgumentOutOfRange. So you don't need to "assert not null" explicitly. This is avoiding strange behaves like throwing any internal exception of the library like ApplicationException("If you want to use extension method NotEmpty() the argument of assertion cannot be null") which have just to push you to assert first "not null". For example ``Assert(value).NotNul().NotEmpty();``.
```csharp
    Assert(anyValue).NotEmpty();
    //Throws ArguemntOutOfRange with the message "The value: string cannot be empty."
    //or ArgumentNullExcpetion with the message "The value: string cannot be null."
```
The name of an argument you can get by use lambda or string parameter.
```csharp
    Assert(() => name).NotEmpty();
    Assert(anyValue, nameof(name)).NotEmpty();
    //Now it will generate message like that: "The name: string cannot be empty."
```
Allow null.
```csharp
    AllowNull.Assert(anyValue).NotEmpty();
    //Not throwing ArgumentNullException.
```
Change message.
```csharp
    Assert(anyValue).NotEmpty("Custom message");
```
Assign value straight to the field.
```csharp
    var name = Assert(anyValue).NotEmpty().Value;
```
Fluent API
```csharp
    Assert(name).Count(5,20).NotEqual("My Name");
```
If you want to assert only "not null" use the optional method or consider option/maybe type instead of.
```csharp
    AssertNotNull(anyValue);
```

## Compare Performance
|                              Method |           Mean |       Error |      StdDev |
|------------------------------------ |---------------:|------------:|------------:|
|                           DawnGuard |      15.146 ns |   0.3262 ns |   0.4354 ns |
|                     CodeGuardAssert |      37.658 ns |   0.9533 ns |   2.7045 ns |
|                      SucklessAssert |       5.432 ns |   0.0303 ns |   0.0269 ns |


|                              Method |           Mean |       Error |      StdDev |
|------------------------------------ |---------------:|------------:|------------:|
|                  DawnGuardValueType |       4.837 ns |   0.0206 ns |   0.0161 ns |
|            CodeGuardAssertValueType |      30.061 ns |   0.0766 ns |   0.0640 ns |
|             SucklessAssertValueType |       1.883 ns |   0.0088 ns |   0.0073 ns |


|                              Method |           Mean |       Error |      StdDev |
|------------------------------------ |---------------:|------------:|------------:|
|                     DawnGuardLambda | 150,222.522 ns | 546.0984 ns | 510.8208 ns |
|            ArgumentAssertionsLambda |  14,605.021 ns |  35.5085 ns |  27.7227 ns |
|                     CodeGuardLambda |   1,648.504 ns |   6.9454 ns |   6.4968 ns |
|                SucklessAssertLambda |   1,502.484 ns |   3.0418 ns |   2.8453 ns |


|                              Method |           Mean |       Error |      StdDev |
|------------------------------------ |---------------:|------------:|------------:|
| CodeGuardAssertLambdaNestedProperty | 183,439.747 ns | 631.5918 ns | 590.7913 ns |
|  SucklessAssertLambdaNestedProperty |   3,539.126 ns |   7.6255 ns |   6.7598 ns |


Why you should care about it.?
Because the "assertions" can be everywhere and you should be aware of performance issues that it can cause. 
Of Course, if the performance is important for you.

### Why It's Faster

Let's look to the IL code of ``Metadata<TValue>`` and check what realy is going on there.
```
.class public sequential ansi sealed beforefieldinit Suckless.Asserts.Metadata`1<TValue>
        extends [netstandard]System.ValueType
{
        .custom instance void System.Runtime.CompilerServices.IsByRefLikeAttribute::.ctor() = (
                01 00 00 00
        )
        .custom instance void [netstandard]System.ObsoleteAttribute::.ctor(string, bool) = (
                01 00 52 54 79 70 65 73 20 77 69 74 68 20 65 6d
                62 65 64 64 65 64 20 72 65 66 65 72 65 6e 63 65
                73 20 61 72 65 20 6e 6f 74 20 73 75 70 70 6f 72
                74 65 64 20 69 6e 20 74 68 69 73 20 76 65 72 73
                69 6f 6e 20 6f 66 20 79 6f 75 72 20 63 6f 6d 70
                69 6c 65 72 2e 01 00 00
        )
        .custom instance void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor() = (
                01 00 00 00
        )
```
This is what is intresting for as.
```
.custom instance void System.Runtime.CompilerServices.IsByRefLikeAttribute::.ctor() = (
                01 00 00 00
        )
```
The attribute of a compiler indicates that a structure is "byref-like". So it means that the compiler just tells the CLR that this is the ref struct which can live only on the stack it will never place on a heap. Thanks to this, we reduce the pressure of the GC.

Hence, a metadata structure is passed by reference to the extension methods, it's mean that the value will be not copied in memory.
```csharp
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> Empty(in this Metadata<string> metadata, string message = null)
        {
```

The next move was avoiding compiling an expression.
```csharp
    Get(Expression<Func<TValue>> expression)
    {
        var value = expression.Compile().Invoke();
    }
```
Instead, I use "ConstantExpression" which is more tricky but gives big performance boost.
[MetadataFactory](https://github.com/Ja-rek/Suckless.Assert/blob/master/Suckless.Asserts/MetadataFactory.cs)

The performance boost you can see here:

|                          Method |            Mean |         Error |        StdDev |
|-------------------------------- |----------------:|--------------:|--------------:|
|     CompileAndInvokeExpresssion | 159,328.0012 ns | 2,888.5969 ns | 2,701.9953 ns |
|              ConstantExpression |   1,418.8669 ns |    21.1379 ns |    19.7724 ns |

The last go was to minimize the number of instances and generic types.
The code is a compromise between principle DRY and writing "fast code".
So just keep it in mind.

## How To Add Own Assert

Just write your own extension method like that:
```csharp
    public static ref readonly Metadata<int> LuckyNumber(in this Metadata<int> metadata)
    {
        if (metadata.Value != 69)
        {
            throw Exception($"The {metadata.Name} contains {metadata.Value} but should contain 69.");
        }

        return ref metadata;
    }
```

