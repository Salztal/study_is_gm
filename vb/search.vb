Option Explicit

Sub SearchKeywordInXlsxFiles()
    Dim folderPath As String
    Dim keyword As String
    Dim resultSheet As Worksheet
    Dim rowNum As Long
    
    ' ユーザーにフォルダを選択させる
    With Application.FileDialog(msoFileDialogFolderPicker)
        .Title = "フォルダを選択してください"
        If .Show = -1 Then
            folderPath = .SelectedItems(1)
        Else
            Exit Sub
        End If
    End With
    
    ' キーワードを入力させる
    keyword = InputBox("検索するキーワードを入力してください:", "キーワード入力")
    If keyword = "" Then Exit Sub
    
    ' 結果出力用シートを作成
    Set resultSheet = ThisWorkbook.Sheets.Add
    resultSheet.Name = "検索結果"
    resultSheet.Cells(1, 1).Value = "ファイルパス"
    resultSheet.Cells(1, 2).Value = "シート名"
    resultSheet.Cells(1, 3).Value = "セル番地"
    resultSheet.Cells(1, 4).Value = "値"
    rowNum = 2
    
    ' フォルダ内のファイルを再帰的に検索
    Call SearchFilesInFolder(folderPath, keyword, resultSheet, rowNum)
    
    MsgBox "検索が完了しました。", vbInformation
End Sub

Sub SearchFilesInFolder(ByVal folderPath As String, ByVal keyword As String, ByRef resultSheet As Worksheet, ByRef rowNum As Long)
    Dim fso As Object
    Dim folder As Object
    Dim subfolder As Object
    Dim file As Object
    
    Set fso = CreateObject("Scripting.FileSystemObject")
    Set folder = fso.GetFolder(folderPath)
    
    ' フォルダ内の各ファイルを処理
    For Each file In folder.Files
        If LCase(fso.GetExtensionName(file.Name)) = "xlsx" Then
            Call SearchKeywordInFile(file.path, keyword, resultSheet, rowNum)
        End If
    Next file
    
    ' サブフォルダ内のファイルを再帰的に処理
    For Each subfolder In folder.SubFolders
        Call SearchFilesInFolder(subfolder.path, keyword, resultSheet, rowNum)
    Next subfolder
End Sub

Sub SearchKeywordInFile(ByVal filePath As String, ByVal keyword As String, ByRef resultSheet As Worksheet, ByRef rowNum As Long)
    Dim wb As Workbook
    Dim ws As Worksheet
    Dim cell As Range
    
    ' 非表示のままワークブックを開く
    Application.ScreenUpdating = False
    Set wb = Workbooks.Open(filePath, ReadOnly:=True, Password:="", IgnoreReadOnlyRecommended:=True)
    
    ' 各シートを検索
    For Each ws In wb.Worksheets
        For Each cell In ws.UsedRange
            If InStr(1, cell.Value, keyword, vbTextCompare) > 0 Then
                resultSheet.Cells(rowNum, 1).Value = filePath
                resultSheet.Cells(rowNum, 2).Value = ws.Name
                resultSheet.Cells(rowNum, 3).Value = cell.Address
                resultSheet.Cells(rowNum, 4).Value = cell.Value
                rowNum = rowNum + 1
            End If
        Next cell
    Next ws
    
    ' ワークブックを閉じる
    wb.Close SaveChanges:=False
    Application.ScreenUpdating = True
End Sub

