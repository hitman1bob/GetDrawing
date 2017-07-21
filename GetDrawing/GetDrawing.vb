Imports System.IO
Module GetDrawing

    Sub Main()
        Dim x As New FileSearch()
        Dim BaseDirName As String = "C:\scratch\pics\"
        Dim FileNameMask As String = "*.jpg;*.jpeg"

        x.Search(BaseDirName, FileNameMask)

        Dim xfile As FileInfo
        For Each xfile In x.Files
            Console.WriteLine(xfile.FullName)
        Next

        Console.WriteLine("Number of matching files = " & Chr(9) & Chr(9) & x.Files.Count) ' number of files that match "*.jpg" and "*.jpeg" in C:\Documents and Settings\btownsend\My Documents\My Pictures\
        Console.WriteLine("Number of searched directories = " & Chr(9) & x.Directories.Count) ' the total number of directories looked through
        Console.WriteLine("Press a key to continue")
        Console.ReadKey()

    End Sub


End Module
