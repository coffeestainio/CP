Imports System.Data.sqlclient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_Proveedor
    Dim Proveedor As DataTable
    Private Sub frm_rpt_Proveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim rProveedor As New rpt_Proveedor
            Proveedor = Table("select * from Proveedor order by nombre", "")
            rProveedor.SetDataSource(Proveedor)
            crv.ReportSource = rProveedor
        Catch myerror As Exception
            MsgBox(myerror.Message)
        End Try
    End Sub
End Class