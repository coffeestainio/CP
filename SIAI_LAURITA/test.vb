Imports System.Data.sqlclient
Public Class test
    Dim tabla As DataTable
    Private Sub test_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tabla = t()
        dtg.DataSource = tabla
    End Sub
End Class