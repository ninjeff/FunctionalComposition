Imports System.Runtime.CompilerServices

Public Module FunctionEx
    Public Function Constant(Of TResult)(c As TResult) As Func(Of TResult)
        Return Function() c
    End Function

    Public Function Constant(Of T, TResult)(c As TResult) As Func(Of T, TResult)
        Return Function(x) c
    End Function

    Public Function Constant(Of T1, T2, TResult)(c As TResult) As Func(Of T1, T2, TResult)
        Return Function(x, y) c
    End Function

    Public Function Constant(Of T1, T2, T3, TResult)(c As TResult) As Func(Of T1, T2, T3, TResult)
        Return Function(x, y, z) c
    End Function

    Public Function Constant(Of T1, T2, T3, T4, TResult)(c As TResult) As Func(Of T1, T2, T3, T4, TResult)
        Return Function(x, y, z, w) c
    End Function

    Public Function Identity(Of T)() As Func(Of T, T)
        Return Function(x) x
    End Function

    <Extension()>
    Public Function Compose(Of TOutput, TResult)(functions As IEnumerable(Of Func(Of TOutput)),
                                                     aggregator As Func(Of IEnumerable(Of TOutput), TResult)) As Func(Of TResult)
        Return Function() aggregator(functions.DoAll())
    End Function

    <Extension()>
    Public Function Compose(Of T, TOutput, TResult)(functions As IEnumerable(Of Func(Of T, TOutput)),
                                                        aggregator As Func(Of IEnumerable(Of TOutput), TResult)) As Func(Of T, TResult)
        Return Function(x) aggregator(functions.DoAll(x))
    End Function

    <Extension()>
    Public Function DoAll(Of TResult)(functions As IEnumerable(Of Func(Of TResult))) As IEnumerable(Of TResult)
        Return From f In functions Select f()
    End Function

    <Extension()>
    Public Function DoAll(Of T, TResult)(functions As IEnumerable(Of Func(Of T, TResult)), x As T) As IEnumerable(Of TResult)
        Return From f In functions Select f(x)
    End Function
End Module
