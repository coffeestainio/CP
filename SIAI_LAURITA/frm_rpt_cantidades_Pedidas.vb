Imports System.Data.sqlclient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_cantidades_Pedidas
    'Dim Pedido_detalle As DataTable
    Dim ds As New DataSet
    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues
    Private Sub frm_rpt_cantidades_Pedidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim rcantidades As New rpt_cantidades_pedidas

            With myForms.frm_rpt_cantidades_pedidas_opciones


                dstable(ds, "Pedido_detalle", "SELECT * FROM Pedido_detalle where " + .criterio + " order by id_producto", "")
                dstable(ds, "bodega_detalle", "SELECT * FROM bodega_detalle where id_bodega=" + .cbid_movil.Text + " order by id_producto", "id_producto")
                rcantidades.SetDataSource(ds)


                rParameterFieldDefinitions = rcantidades.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("Movil")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Móvil " + .cbid_movil.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("fecha_entrega")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Entrega " + .Dtpfecha_entrega.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                crv.ReportSource = rcantidades
            End With
        Catch myerror As Exception
            MsgBox(myerror.Message)
        End Try
    End Sub
End Class