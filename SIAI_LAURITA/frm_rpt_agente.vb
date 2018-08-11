Imports System.Data.sqlclient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frm_rpt_agente
    Dim Agente As DataTable


    Private Sub frm_rpt_agente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ragente As New rpt_agente
            Agente = Table("select * from agente order by nombre", "")
            ragente.SetDataSource(Agente)
            crv.ReportSource = ragente
        Catch myerror As Exception
            MsgBox(myerror.Message)
        End Try

    End Sub
    
End Class