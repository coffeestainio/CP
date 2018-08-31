Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_venta_producto_cliente_opciones
    Dim VVP As DataTable
    'Dim Producto As DataTable
    'Dim Cliente As DataTable
    'Dim Proveedor As DataTable
    'Dim Linea As DataTable
    Dim rowl As DataRow
    Dim rowprv As DataRow
    Dim rowc As DataRow
    Dim rowprd As DataRow
    Public C3 As String
    Public produs As String

    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        btnaceptar.Enabled = False
        Dim C1 As String = ""
        Dim C2 As String = ""
        Dim C3 As String = ""
        Dim c4 As String = ""
        C1 = " fecha>='" + EDATE(Dtpdesde.Text) + " 00:00:00' and fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"


        If Val(txtid_cliente.Text) > 0 Then C1 = C1 + " and id_cliente=" + txtid_cliente.Text
        If cbnegocio.SelectedIndex > 0 Then c4 = " and comercio =" & (cbnegocio.SelectedIndex - 1)
        If Val(txtid_proveedor.Text) > 0 Then C2 = " producto.id_proveedor=" + txtid_proveedor.Text
        If Val(txtid_linea.Text) > 0 Then C2 = C2 + IIf(C2 = "", "", " and ") + " producto.id_linea=" + txtid_linea.Text
        C1 = C1 + IIf(C3 = "", "", " and ") + C3
        If Val(txtid_producto.Text) > 0 Then
            C2 = C2 + IIf(C2 = "", "", " and ") + " producto.id_producto='" + txtid_producto.Text + "'"
        ElseIf produs <> Nothing Then
            C2 = C2 + IIf(C2 = "", "", " and ") + produs
        End If

        If cbid_usuario.SelectedIndex > 0 Then
            C3 = "factura.id_usuario=" + cbid(cbid_usuario.Text)
        End If




        VVP = FACP(C1 + IIf(C3 = "", "", " and ") + C3, C2, c4)

        Dim Dev As DataTable = DEVP(C1, C2, C3, c4)
        Dim z As Integer
        For z = 0 To Dev.Rows.Count - 1
            VVP.ImportRow(Dev.Rows(z))
        Next



        ' **
        Tsort(VVP, "id_cliente")

        Dim clientes As Integer
        Dim id_cliente As Integer
        id_cliente = 0
        For z = 0 To VVP.Rows.Count - 1
            If VVP.Rows(z).Item("id_cliente") <> id_cliente Then
                clientes = clientes + 1
                id_cliente = VVP.Rows(z).Item("id_cliente")
            End If
        Next

        Dim rVP As New rpt_Venta_Producto_cliente

        rVP.SetDataSource(VVP)


        rParameterFieldDefinitions = rVP.DataDefinition.ParameterFields

        rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Del " + Dtpdesde.Text + " al " + dtphasta.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

        rParameterFieldLocation = rParameterFieldDefinitions.Item("proveedor")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = IIf(Val(txtid_proveedor.Text) > 0, txtid_proveedor.Text + "-" + Lblproveedor_nombre.Text, "")
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        rParameterFieldLocation = rParameterFieldDefinitions.Item("linea")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = IIf(Val(txtid_linea.Text) > 0, txtid_linea.Text + "-" + lbllinea_nombre.Text, "")
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        rParameterFieldLocation = rParameterFieldDefinitions.Item("clientes")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Clientes = " + clientes.ToString
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)
        rParameterFieldLocation = rParameterFieldDefinitions.Item("comercio")

        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Tipo de Comercio: " + cbnegocio.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)





        Dim rv As New frm_Report_Viewer
        rv.crv.ReportSource = rVP
        rv.Text = "Venta Producto"
        rv.Show()
        btnaceptar.Enabled = True

    End Sub

    Private Sub frm_rpt_venta_opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cliente = Table("select * from cliente", "id_cliente")
        'Producto = Table("select * from producto", "id_producto")
        'Linea = Table("select * from linea", "id_linea")
        'Proveedor = Table("select * from proveedor", "id_proveedor")

        CB_crear(cbid_usuario, "usuario", "id_usuario")
        cbid_usuario.Items.Insert(0, "TODOS")
        cbid_usuario.SelectedIndex = 0
    End Sub

   
    Public Sub Identifica_linea()
        ' Try
        '
        Dim l As DataTable = Table("select * from linea where id_linea=" + txtid_linea.Text, "")

        If l.Rows.Count = 0 Then
            MessageBox.Show("linea no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        rowl = l.Rows(0)
        lbllinea_nombre.Text = rowl("nombre")
        SendKeys.Send("{tab}")
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub


    Public Sub Identifica_cliente()
        ' Try
        '
        Dim C As DataTable = Table("select * from cliente where eliminado=0 and id_cliente=" + txtid_cliente.Text, "")

        If C.Rows.Count = 0 Then
            MessageBox.Show("cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        rowc = C.Rows(0)
        lblcliente_nombre.Text = rowc("nombre")
        SendKeys.Send("{tab}")
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Public Sub Identifica_Producto()
        ' Try
        '

        Dim P As DataTable = Table("select * from producto where id_producto=" + txtid_producto.Text, "")

        If P.Rows.Count = 0 Then
            MessageBox.Show("Producto no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        rowprd = P.Rows(0)
        lblproducto_nombre.Text = rowprd("nombre")
        SendKeys.Send("{tab}")
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub


    Public Sub Identifica_Proveedor()
        ' Try
        '

        Dim Pr As DataTable = Table("select * from proveedor where id_proveedor=" + txtid_proveedor.Text, "")

        If Pr.Rows.Count = 0 Then
            MessageBox.Show("Proveedor no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        rowprv = Pr.Rows(0)
        lblproveedor_nombre.Text = rowprv("nombre")
        SendKeys.Send("{tab}")
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    


   

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub


    Private Sub txtid_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_cliente.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_cliente.Text) = 0 Then
                SendKeys.Send("{tab}")

            Else
                Identifica_cliente()

            End If
        Else
            If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                BUSQUEDA = "rpt_venta_producto_cliente_opciones"
                Dim Cliente_buscar As New frm_cliente_buscar
                Cliente_buscar.Owner = Me
                Cliente_buscar.Show()
                Cliente_buscar.txtbuscar_cliente.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_cliente.Text, False)
            End If
        End If
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
                BUSQUEDA = "rpt_venta_producto_cliente_opciones"
                Dim proveedor_buscar As New frm_Proveedor_Buscar
                proveedor_buscar.Owner = Me
                proveedor_buscar.Show()
                proveedor_buscar.txtbuscar_Proveedor.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_proveedor.Text, False)
            End If
        End If
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
                BUSQUEDA = "rpt_venta_producto_cliente_opciones"
                Dim linea_buscar As New frm_Linea_Buscar
                linea_buscar.Owner = Me
                linea_buscar.Show()
                linea_buscar.txtbuscar_linea.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_linea.Text, False)
            End If
        End If
    End Sub


    Private Sub txtid_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_producto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_producto.Text) = 0 Then
                SendKeys.Send("{tab}")

            Else
                Identifica_Producto()

            End If
        Else
            If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                BUSQUEDA = "rpt_venta_producto_cliente_opciones"
                Dim producto_buscar As New frm_producto_buscar
                producto_buscar.Owner = Me
                producto_buscar.Show()
                producto_buscar.txtbuscar_producto.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_producto.Text, False)
            End If
        End If
    End Sub

   

   
    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        BUSQUEDA = "rpt_venta_producto_cliente_opciones"
        Dim producto_buscar_multiple As New frm_producto_buscar_multiple
        producto_buscar_multiple.Owner = Me
        producto_buscar_multiple.Show()
    End Sub
End Class