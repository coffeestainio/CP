Imports System.Data.sqlclient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_estado
    Inherits System.Windows.Forms.Form
    
    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues

    Dim Movimiento As DataTable
    Dim Sant As Decimal = 0
    Dim Cmper As Decimal = 0
    Dim Dmper As Decimal = 0
    Dim Sact As Decimal = 0
    Dim SQL_desde As String
    Dim SQL_hasta As String
    Dim desde As String
    Dim hasta As String

    Private Sub frm_rpt_estado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With myForms.frm_rpt_estado_opciones
                desde = .Dtpdesde.Text
                hasta = .dtphasta.Text

                Movimiento = Table("Select * from movimiento where id_cliente=" + .txtid_cliente.Text, "")

                Dim z As Integer
                For z = 0 To Movimiento.Rows.Count - 1
                    With Movimiento.Rows(z)
                        Sact = Sact + .Item("monto")
                        If .Item("fecha") < desde Then
                            Sant = Sant + .Item("monto")
                        ElseIf .Item("fecha") <= hasta Then
                            If .Item("monto") < 0 Then
                                Cmper = Cmper + .Item("monto") * -1
                            Else
                                Dmper = Dmper + .Item("monto")
                            End If
                        End If
                    End With
                Next

                SQL_desde = .Dtpdesde.Text.Substring(3, 2) + "/" + .Dtpdesde.Text.Substring(0, 2) + "/" + .Dtpdesde.Text.Substring(6, 4)
                SQL_hasta = .dtphasta.Text.Substring(3, 2) + "/" + .dtphasta.Text.Substring(0, 2) + "/" + .dtphasta.Text.Substring(6, 4)




                Dim restado As New rpt_estado
                Movimiento = Table("select * from movimiento where id_cliente=" + .txtid_cliente.Text + " and fecha>='" + SQL_desde + "' and fecha<='" + SQL_hasta + "'", "")


                restado.SetDataSource(Movimiento)
                rParameterFieldDefinitions = restado.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("cliente")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Cliente: " + .txtid_cliente.Text + " - " + .lblnombre_cliente.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("periodo")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "del " + .Dtpdesde.Text + " al " + .dtphasta.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("cper")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = FormatNumber(Cmper.ToString, 2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("dper")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = FormatNumber(Dmper.ToString, 2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("sant")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = FormatNumber(Sant.ToString, 2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("sact")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = FormatNumber(Sact.ToString, 2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                crv.ReportSource = restado
            End With
        Catch myerror As Exception
            MsgBox(myerror.Message)
        End Try
    End Sub
End Class