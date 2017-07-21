Imports System.IO
Module GetPDF
    Sub Main()
        'Show message if drawings directory structure not found
        Dim DPath As String = My.Settings.DPath

        ' HACK Override DrawingPath
        'DPath = "c:\temp\"

        ' Check if DPath exists
        If Not Directory.Exists(DPath) Then
            Console.WriteLine(DPath & " is not available.")
            Console.WriteLine()
            Console.Write("Press a key to exit")
            Console.Read()
            Exit Sub
        End If

        'Setup and perform search
        ' HACK Override GetPDF search extension
        'Dim strDWG As String = ToolNo & "*.jpg"

        Dim currpath As String = Directory.GetCurrentDirectory

        ' HACK Override Job Directory
        'currpath = "C:\etest\32702qd"
        Dim ToolNo As String = GetToolNo(currpath)
        Dim strDWG As String = ToolNo & "*.pdf"

        ' HACK Overide Drawing Name
        'strDWG = "32702.pdf"
        Dim fsGpdf As New FileSearch
        fsGpdf.Search(DPath, strDWG)

        'Show message if drawing not found
        If Not fsGpdf.Files.Count > 0 Then
            Console.WriteLine("Drawing not found")
        End If

        'Open each matching file with default pdf reader
        Dim xFile As FileInfo
        For Each xFile In fsGpdf.Files
            Process.Start(xFile.FullName)
        Next
    End Sub 'Main
    Function GetToolNo(ByVal currpath As String) As String
        Dim myPath As String = currpath
        Dim myDirectory As System.IO.DirectoryInfo
        myDirectory = New System.IO.DirectoryInfo(myPath)
        Dim ToolNo As String = Left(myDirectory.Name, 5)
        Return ToolNo
    End Function 'GetToolNo
End Module
