Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_bodega_existencia_opciones
    Dim VVP As DataTable
    Dim Dev As DataTable
    Dim Facs As DataTable
    Public Producto As DataTable
    Public Proveedor As DataTable
    Public familia As DataTable

    Dim rowprv As DataRow
    Dim rowl As DataRow
    Dim rowprd As DataRow

    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues

    Const AR As String = " AND NOT EXISTS ( SELECT * FROM ildi_inventa.dbo.Reversion  WHERE ildi_inventa.dbo.reversion.Tipo = 2 and ildi_inventa.dbo.reversion.id_documento=ildi_inventa.dbo.bodega_ajuste.id_bodega_ajuste)"
    Const MR As String = " AND NOT EXISTS ( SELECT * FROM ildi_inventa.dbo.Reversion  WHERE ildi_inventa.dbo.reversion.Tipo = 4 and ildi_inventa.dbo.reversion.id_documento=ildi_inventa.dbo.bodega_movimiento.id_bodega_movimiento)"

    Private Sub frm_rpt_bodega_existencia_opciones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CONN1.Close()
        CONN2.Close()
    End Sub

  

    Private Sub frm_rpt_venta_producto_opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CONN1.Open()
            CONN2.Open()

        
            CB_crear(cbid_bodega, "bodega", "id_bodega")
            cbid_bodega.Items.Insert(0, "TODAS")
            cbid_bodega.SelectedIndex = 0


            CB_crear(cbid_familia, "familia", "id_familia")
            cbid_familia.Items.Insert(0, "TODAS")
            cbid_familia.SelectedIndex = 0

            CB_crear(cbid_Proveedor, "Proveedor", "id_proveedor")
            cbid_Proveedor.Items.Insert(0, "TODOS")
            cbid_Proveedor.SelectedIndex = 0

        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        btnaceptar.Enabled = False

        Dim rbe As New rpt_bodega_existencia

        Dim C1 As String = ""
        Dim C2 As String = ""
        Dim C3 As String = ""
        Dim CBMS As String = ""
        Dim CBME As String = ""

        C1 = "fecha>='07/23/07' and fecha<='" + EDATE(dtphasta.Text) + "'" + IIf(cbid_bodega.SelectedIndex > 0, " and id_bodega=" + cbid(cbid_bodega.Text), "")


        CBMS = "fecha>='07/23/07' and fecha<='" + EDATE(dtphasta.Text) + "'" + IIf(cbid_bodega.SelectedIndex > 0, " and id_bodega_origen=" + cbid(cbid_bodega.Text), "")
        CBME = "fecha>='07/23/07' and fecha<='" + EDATE(dtphasta.Text) + "'" + IIf(cbid_bodega.SelectedIndex > 0, " and id_bodega_destino=" + cbid(cbid_bodega.Text), "")


        If Val(txtid_producto.Text) > 0 Then
            C2 = " Producto.id_producto = " + txtid_producto.Text
            C3 = " ildi.dbo.Producto.id_producto = " + txtid_producto.Text
        End If

        If cbid_Proveedor.SelectedIndex > 0 Then
            C2 = C2 + IIf(C2 = "", "", " and ") + " producto.id_proveedor=" + cbid(cbid_Proveedor.Text)
            C3 = C3 + IIf(C2 = "", "", " and ") + " ildi.dbo.producto.id_proveedor=" + cbid(cbid_Proveedor.Text)
        End If
        If cbid_familia.SelectedIndex > 0 Then
            C2 = C2 + IIf(C2 = "", "", " and ") + " producto.id_familia=" + cbid(cbid_familia.Text)
            C3 = C3 + IIf(C3 = "", "", " and ") + " ildi.dbo.producto.id_familia=" + cbid(cbid_familia.Text)
        End If


        Dim P As DataTable = Table1("select id_producto,nombre,presentacion from ildi.dbo.producto " + IIf(C3 = "", "", " where eliminado=0 and") + C3, "")


        Dim cantidad As DataColumn = New DataColumn("cantidad")
        cantidad.DataType = System.Type.GetType("System.Decimal")
        cantidad.DefaultValue = 0
        P.Columns.Add(cantidad)

        If Not chktf.Checked Then

            Dim FP As DataTable = FACP(C1, C2)


            Dim Dev As DataTable = DEVP(C1, C2)

            Dim sql As String = "select ildi_inventa.dbo.bodega_ajuste_detalle.id_producto,ildi_inventa.dbo.bodega_ajuste.fecha," + _
            "ildi.dbo.producto.nombre,ildi.dbo.producto.presentacion, " + _
            " CASE WHEN ildi_inventa.dbo.bodega_ajuste_detalle.tipo = 0 THEN ildi_inventa.dbo.bodega_ajuste_detalle.cantidad  ELSE ildi_inventa.dbo.bodega_ajuste_detalle.cantidad*-1 END AS cantidad" + _
            " from ildi_inventa.dbo.bodega_ajuste_detalle inner join ildi_inventa.dbo.bodega_ajuste on ildi_inventa.dbo.bodega_ajuste_detalle.id_bodega_ajuste=ildi_inventa.dbo.bodega_ajuste.id_bodega_ajuste " + AR + IIf(C1 = "", "", " and ") + C1 + _
            " inner join ildi.dbo.producto on ildi_inventa.dbo.bodega_ajuste_detalle.id_producto=ildi.dbo.producto.id_producto  " + IIf(C3 = "", "", " and ") + C3



            Dim BA As DataTable = Table2(sql, "")


            sql = "select ildi_inventa.dbo.bodega_movimiento_detalle.id_producto,ildi_inventa.dbo.bodega_movimiento.fecha," + _
          "ildi.dbo.producto.nombre,ildi.dbo.producto.presentacion, " + _
          "ildi_inventa.dbo.bodega_movimiento_detalle.cantidad *-1  AS cantidad" + _
          " from ildi_inventa.dbo.bodega_movimiento_detalle inner join ildi_inventa.dbo.bodega_movimiento on ildi_inventa.dbo.bodega_movimiento_detalle.id_bodega_movimiento=ildi_inventa.dbo.bodega_movimiento.id_bodega_movimiento " + MR + IIf(CBMS = "", "", " and ") + CBMS + _
          "inner join ildi.dbo.producto on ildi_inventa.dbo.bodega_movimiento_detalle.id_producto=ildi.dbo.producto.id_producto " + IIf(C3 = "", "", " and ") + C3

            Dim BMS As DataTable = Table2(sql, "")


            sql = "select ildi_inventa.dbo.bodega_movimiento_detalle.id_producto,ildi_inventa.dbo.bodega_movimiento.fecha," + _
          "ildi.dbo.producto.nombre,ildi.dbo.producto.presentacion, " + _
          "ildi_inventa.dbo.bodega_movimiento_detalle.cantidad" + _
          " from ildi_inventa.dbo.bodega_movimiento_detalle inner join ildi_inventa.dbo.bodega_movimiento on ildi_inventa.dbo.bodega_movimiento_detalle.id_bodega_movimiento=ildi_inventa.dbo.bodega_movimiento.id_bodega_movimiento " + MR + IIf(CBME = "", "", " and ") + CBME + _
          "inner join ildi.dbo.producto on ildi_inventa.dbo.bodega_movimiento_detalle.id_producto=ildi.dbo.producto.id_producto  " + IIf(C3 = "", "", " and ") + C3

            Dim BME As DataTable = Table2(sql, "")




            Dim T1 As DataTable = TABLE_ADD(P, FP)
            Dim T2 As DataTable = TABLE_ADD(T1, Dev)
            Dim T3 As DataTable = TABLE_ADD(T2, BA)
            Dim T4 As DataTable = TABLE_ADD(T3, BMS)
            Dim inventa As DataTable = TABLE_ADD(T4, BME)

            rbe.SetDataSource(inventa)

        Else
            rbe.SetDataSource(P)

        End If



        rParameterFieldDefinitions = rbe.DataDefinition.ParameterFields


        rParameterFieldLocation = rParameterFieldDefinitions.Item("bodega")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Bodega: " + cbid_bodega.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = " al " + dtphasta.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

        rParameterFieldLocation = rParameterFieldDefinitions.Item("proveedor")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Proveedor: " + cbid_bodega.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        rParameterFieldLocation = rParameterFieldDefinitions.Item("familia")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Familia: " + cbid_familia.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        rParameterFieldLocation = rParameterFieldDefinitions.Item("tf")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = IIf(chktf.Checked, 1, 0)
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        Dim rv As New frm_Report_Viewer
        rv.crv.ReportSource = rbe
        rv.Text = "Bodega Existencia"
        rv.Show()
        btnaceptar.Enabled = True

    End Sub



    Public Sub Producto_identificar()
        ' Try
        '
        Producto = Table1("select * from producto where id_producto=" + txtid_producto.Text, "")

        If Producto.Rows.Count = 0 Then
            MessageBox.Show("Producto no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        rowprd = Producto.Rows(0)
        lblproducto_nombre.Text = rowprd("nombre")
        SendKeys.Send("{tab}")
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub



    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub txtid_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_producto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_producto.Text) = 0 Then
                SendKeys.Send("{tab}")
            Else
                Producto_identificar()
            End If
        Else
            If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                BUSQUEDA = "bodega_existencia"
                Dim producto_buscar As New frm_producto_buscar
                producto_buscar.Owner = Me
                producto_buscar.Show()
                producto_buscar.txtbuscar_producto.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_producto.Text, False)
            End If
        End If
    End Sub

    Private Sub txtid_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_producto.TextChanged

    End Sub
End Class