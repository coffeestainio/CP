Imports System.Data.sqlclient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_cliente
    Dim Cliente As DataTable
    Private Sub frm_rpt_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim rcliente As New rpt_cliente
            Cliente = Table("select * from cliente order by nombre_comercial", "")
            rcliente.SetDataSource(Cliente)
            crv.ReportSource = rcliente
        Catch myerror As Exception
            MsgBox(myerror.Message)
        End Try
    End Sub
End Class