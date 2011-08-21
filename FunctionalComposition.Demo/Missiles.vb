Public Delegate Sub DFireMissiles()

Public Module Missiles
    Public Sub FireMissiles()
        Console.WriteLine("Firing the missiles!")
    End Sub

    Public Sub FireColoredMissiles(foregroundColor As ConsoleColor, backgroundColor As ConsoleColor)
        Dim oldForegroundColor = Console.ForegroundColor
        Dim oldBackgroundColor = Console.BackgroundColor

        Console.ForegroundColor = foregroundColor
        Console.BackgroundColor = backgroundColor

        Console.WriteLine("Firing the colored missiles!")

        Console.ForegroundColor = oldForegroundColor
        Console.BackgroundColor = oldBackgroundColor
    End Sub
End Module
