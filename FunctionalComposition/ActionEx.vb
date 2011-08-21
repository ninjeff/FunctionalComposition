Imports System.Runtime.CompilerServices

Public Module ActionEx
    Public Function Null() As Action
        Return Sub()
               End Sub
    End Function

    Public Function Null(Of T)() As Action(Of T)
        Return Sub(x)
               End Sub
    End Function

    Public Function Null(Of T1, T2)() As Action(Of T1, T2)
        Return Sub(x, y)
               End Sub
    End Function

    Public Function Null(Of T1, T2, T3)() As Action(Of T1, T2, T3)
        Return Sub(x, y, z)
               End Sub
    End Function

    Public Function Null(Of T1, T2, T3, T4)() As Action(Of T1, T2, T3, T4)
        Return Sub(x, y, z, w)
               End Sub
    End Function

    <Extension()>
    Public Function Compose(actions As IEnumerable(Of Action)) As Action
        Return Sub()
                   For Each action In actions
                       action()
                   Next
               End Sub
    End Function

    <Extension()>
    Public Function Compose(Of T)(actions As IEnumerable(Of Action(Of T))) As Action(Of T)
        Return Sub(x)
                   For Each action In actions
                       action(x)
                   Next
               End Sub
    End Function

    <Extension()>
    Public Function Compose(Of T1, T2)(actions As IEnumerable(Of Action(Of T1, T2))) As Action(Of T1, T2)
        Return Sub(x1, x2)
                   For Each action In actions
                       action(x1, x2)
                   Next
               End Sub
    End Function

    <Extension()>
    Public Function Compose(Of T1, T2, T3)(actions As IEnumerable(Of Action(Of T1, T2, T3))) As Action(Of T1, T2, T3)
        Return Sub(x1, x2, x3)
                   For Each action In actions
                       action(x1, x2, x3)
                   Next
               End Sub
    End Function

    <Extension()>
    Public Function Compose(Of T1, T2, T3, T4)(actions As IEnumerable(Of Action(Of T1, T2, T3, T4))) As Action(Of T1, T2, T3, T4)
        Return Sub(x1, x2, x3, x4)
                   For Each action In actions
                       action(x1, x2, x3, x4)
                   Next
               End Sub
    End Function

    <Extension()>
    Public Function DoZip(Of T)(actions As IEnumerable(Of Action(Of T))) As Action(Of IEnumerable(Of T))
        Return Sub(xs)
                   Dim zipped = actions.ZipWithArguments(xs)
                   Dim all = zipped.Compose()
                   all()
               End Sub
    End Function

    <Extension()>
    Public Function DoZip(Of T1, T2)(actions As IEnumerable(Of Action(Of T1, T2))) As Action(Of IEnumerable(Of T1), IEnumerable(Of T2))
        Return Sub(xs, ys)
                   Dim zipped = actions.ZipWithArguments(xs, ys)
                   Dim all = zipped.Compose()
                   all()
               End Sub
    End Function

    <Extension()>
    Public Function DoZip(Of T1, T2, T3)(actions As IEnumerable(Of Action(Of T1, T2, T3))) As Action(Of IEnumerable(Of T1), IEnumerable(Of T2), IEnumerable(Of T3))
        Return Sub(xs, ys, zs)
                   Dim zipped = actions.ZipWithArguments(xs, ys, zs)
                   Dim all = zipped.Compose()
                   all()
               End Sub
    End Function

    <Extension()>
    Public Function DoZip(Of T1, T2, T3, T4)(actions As IEnumerable(Of Action(Of T1, T2, T3, T4))) As Action(Of IEnumerable(Of T1), IEnumerable(Of T2), IEnumerable(Of T3), IEnumerable(Of T4))
        Return Sub(xs, ys, zs, ws)
                   Dim zipped = actions.ZipWithArguments(xs, ys, zs, ws)
                   Dim all = zipped.Compose()
                   all()
               End Sub
    End Function

    <Extension()>
    Public Function ZipWithArguments(Of T)(actions As IEnumerable(Of Action(Of T)), arguments As IEnumerable(Of T)) As IEnumerable(Of Action)
        Return actions.Zip(Of T, Action)(arguments, Function(a, x) Sub() a(x))
    End Function

    <Extension()>
    Public Function ZipWithArguments(Of T1, T2)(actions As IEnumerable(Of Action(Of T1, T2)), xs As IEnumerable(Of T1), ys As IEnumerable(Of T2)) As IEnumerable(Of Action)
        Return actions.Zip(Of T1, Action(Of T2))(xs, Function(a, x) Sub(y) a(x, y)).ZipWithArguments(ys)
    End Function

    <Extension()>
    Public Function ZipWithArguments(Of T1, T2, T3)(actions As IEnumerable(Of Action(Of T1, T2, T3)), xs As IEnumerable(Of T1), ys As IEnumerable(Of T2), zs As IEnumerable(Of T3)) As IEnumerable(Of Action)
        Return actions.Zip(Of T1, Action(Of T2, T3))(xs, Function(a, x) Sub(y, z) a(x, y, z)).ZipWithArguments(ys, zs)
    End Function

    <Extension()>
    Public Function ZipWithArguments(Of T1, T2, T3, T4)(actions As IEnumerable(Of Action(Of T1, T2, T3, T4)), xs As IEnumerable(Of T1), ys As IEnumerable(Of T2), zs As IEnumerable(Of T3), ws As IEnumerable(Of T4)) As IEnumerable(Of Action)
        Return actions.Zip(Of T1, Action(Of T2, T3, T4))(xs, Function(a, x) Sub(y, z, w) a(x, y, z, w)).ZipWithArguments(ys, zs, ws)
    End Function

    <Extension()>
    Public Function AppliedTo(Of T)(a As Action(Of T), x As T) As Action
        Return Sub() a(x)
    End Function
End Module
