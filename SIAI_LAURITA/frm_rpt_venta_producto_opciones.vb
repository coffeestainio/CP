Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_venta_producto_opciones
    Dim VVP As DataTable
    Dim Facs As DataTable
    Public Producto As DataTable
    Public Proveedor As DataTable
    Public linea As DataTable

    Dim rowprv As DataRow
    Dim rowl As DataRow
    Dim rowprd As DataRow

    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues

    Private Sub frm_rpt_venta_producto_opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Proveedor = Table("select * from proveedor", "id_proveedor")
        Producto = Table("select * from producto", "id_producto")
        linea = Table("select * from linea", "id_linea")
        CB_crear(cbid_usuario, "usuario", "id_usuario")
        cbid_usuario.Items.Insert(0, "TODOS")
        cbid_usuario.SelectedIndex = 0
    End Sub
    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        btnaceptar.Enabled = False

        Dim C1 As String = ""
        Dim c2 As String = ""
        Dim c3 As String = ""
        Dim c4 As String = ""


        C1 = " fecha>='" + EDATE(Dtpdesde.Text) + " 00:00:01' and fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"
        If Val(txtid_proveedor.Text) > 0 Then c2 = c2 + "  producto.id_proveedor=" + txtid_proveedor.Text
        If Val(txtid_linea.Text) > 0 Then c2 = c2 + IIf(c2 = "", "", " and ") + " producto.id_linea=" + txtid_linea.Text
        If Val(txtid_producto.Text) > 0 Then c2 = " producto.id_producto='" + txtid_producto.Text + "'"
        If cbid_usuario.SelectedIndex > 0 Then
            c3 = "factura.id_usuario=" + cbid(cbid_usuario.Text)
        End If


        VVP = FACP(C1 + IIf(c3 = "", "", " and ") + c3, c2, c4)

        Dim Dev As DataTable = DEVP(C1, c2, c3, c4)
        Dim z As Integer
        For z = 0 To Dev.Rows.Count - 1
            VVP.ImportRow(Dev.Rows(z))
        Next

        Dim rVP As New rpt_venta_producto

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
        rParameterDiscreteValue.Value = IIf(Val(txtid_proveedor.Text) > 0, txtid_proveedor.Text + "-" + lblproveedor_nombre.Text, "")
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        rParameterFieldLocation = rParameterFieldDefinitions.Item("linea")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = IIf(Val(txtid_linea.Text) > 0, txtid_linea.Text + "-" + lbllinea_nombre.Text, "")
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



        Dim rv As New frm_Report_Viewer
        rv.crv.ReportSource = rVP
        rv.Text = "Venta Producto"
        rv.Show()
        btnaceptar.Enabled = True

    End Sub

    Private Sub frm_rpt_venta_opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Producto = Table("select * from producto", "id_producto")
        Linea = Table("select * from linea", "id_linea")
        Proveedor = Table("select * from proveedor", "id_proveedor")
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

    Public Sub Identifica_Producto()
        ' Try
        '
        rowprd = Producto.Rows.Find(txtid_producto.Text)
        If rowprd Is Nothing Then
            MessageBox.Show("Producto no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        lblproducto_nombre.Text = rowprd("nombre")
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



    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
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
                BUSQUEDA = "rpt_venta_producto_opciones"
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
                BUSQUEDA = "rpt_venta_producto_opciones"
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
                BUSQUEDA = "rpt_venta_producto_opciones"
                Dim producto_buscar As New frm_producto_buscar
                producto_buscar.Owner = Me
                producto_buscar.Show()
                producto_buscar.txtbuscar_producto.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_producto.Text, False)
            End If
        End If
    End Sub
End Class