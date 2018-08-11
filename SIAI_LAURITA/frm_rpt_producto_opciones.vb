Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_producto_opciones
    Public Linea As DataTable
    Public Producto As DataTable
    Public Proveedor As DataTable
    Dim rowl As DataRow
    Dim rowprv As DataRow


    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues
    Private Sub frm_rpt_producto_opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Proveedor = Table("select id_proveedor,nombre from proveedor", "id_proveedor")
        Linea = Table("select id_linea,nombre from linea", "id_linea")
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        btnaceptar.Enabled = False
        Dim Criterio As String = ""




        If Val(txtid_proveedor.Text) > 0 Then
            Criterio = "id_proveedor=" + txtid_proveedor.Text
        End If
        
        If Val(txtid_linea.Text) > 0 Then
            Criterio = Criterio + IIf(Criterio = "", "", " and ") + "id_linea=" + txtid_linea.Text
        End If

        If chkbloqueados.Checked Then
            Criterio = Criterio + IIf(Criterio = "", "", " and ") + "bloqueado=1"
        End If


        Producto = Table("select * from Producto " + IIf(Criterio = "", "", " where " + Criterio) + " order by nombre", "")

        Dim monto As Decimal = 0
        Dim mon As String
        Dim i As Integer
        For i = 0 To Producto.Rows.Count - 1
            monto = monto + (Producto.Rows(i).Item("existencia") * (Producto.Rows(i).Item("costo") / Producto.Rows(i).Item("empaque")))
        Next
        mon = FormatNumber(monto, 2)


        Dim rProducto As New rpt_producto


        rProducto.SetDataSource(Producto)


        rParameterFieldDefinitions = rProducto.DataDefinition.ParameterFields

        rParameterFieldLocation = rParameterFieldDefinitions.Item("id_linea")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = IIf(Val(txtid_linea.Text), "Línea " + lbllinea_nombre.Text, "")
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

        rParameterFieldLocation = rParameterFieldDefinitions.Item("monto")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = mon
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        rParameterFieldLocation = rParameterFieldDefinitions.Item("id_proveedor")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = IIf(Val(txtid_proveedor.Text), "Proveedor " + lblproveedor_nombre.Text, "")
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        Dim rv As New frm_Report_Viewer
        rv.crv.ReportSource = rProducto
        rv.Text = "Productos"
        rv.Show()
        btnaceptar.Enabled = True


    End Sub

    Public Sub Identifica_linea()
        ' Try
        '
        rowl = Linea.Rows.Find(txtid_linea.Text)
        If rowl Is Nothing Then
            MessageBox.Show("linea no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        lbllinea_nombre.Text = rowl("nombre")
        SendKeys.Send("{tab}")
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Public Sub Identifica_Proveedor()
        ' Try
        '
        rowprv = Proveedor.Rows.Find(txtid_proveedor.Text)
        If rowprv Is Nothing Then
            MessageBox.Show("Proveedor no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        lblproveedor_nombre.Text = rowprv("nombre")
        SendKeys.Send("{tab}")
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub txtid_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_proveedor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_proveedor.Text) = 0 Then
                SendKeys.Send("{tab}")
            Else
                Identifica_Proveedor()
            End If
        Else
            If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                BUSQUEDA = "rpt_producto_opciones"
                Dim proveedor_buscar As New frm_Proveedor_Buscar
                proveedor_buscar.Owner = Me
                proveedor_buscar.Show()
                proveedor_buscar.txtbuscar_Proveedor.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_proveedor.Text, False)
            End If
        End If
    End Sub

    Private Sub txtid_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_proveedor.TextChanged

    End Sub

    Private Sub txtid_linea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_linea.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_linea.Text) = 0 Then
                SendKeys.Send("{tab}")
            Else
                Identifica_linea()

            End If
        Else
            If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                BUSQUEDA = "rpt_producto_opciones"
                Dim linea_buscar As New frm_Linea_Buscar
                linea_buscar.Owner = Me
                linea_buscar.Show()
                linea_buscar.txtbuscar_linea.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_linea.Text, False)
            End If
        End If
    End Sub



    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub txtid_linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_linea.TextChanged

    End Sub
End Class