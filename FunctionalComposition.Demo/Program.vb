Imports FunctionalComposition.ActionEx

Public Module Program
    Public Sub Main()
        Dim actions As IEnumerable(Of Action(Of ConsoleColor, ConsoleColor)) = {AddressOf Missiles.FireColoredMissiles,
                                                                                AddressOf Missiles.FireColoredMissiles,
                                                                                AddressOf Missiles.FireColoredMissiles}
        Dim fireMissiles = actions.DoZip()
        Dim foregroundColors As IEnumerable(Of ConsoleColor) = {ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue}
        Dim backgroundColors As IEnumerable(Of ConsoleColor) = {ConsoleColor.DarkGreen, ConsoleColor.DarkBlue, ConsoleColor.DarkRed}

        fireMissiles(foregroundColors, backgroundColors)

        Console.ReadLine()
    End Sub
End Module
