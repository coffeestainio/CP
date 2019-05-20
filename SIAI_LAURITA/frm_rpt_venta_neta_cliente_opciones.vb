Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_venta_neta_cliente_opciones
    Dim VVC As DataTable
    Dim Facs As DataTable
    Dim Producto As DataTable
    Public Cliente As DataTable
    Dim Criterio As String
    Dim CriterioNC As String
    Dim rowc As DataRow

    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues
    Private Sub frm_rpt_venta_cliente_opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cliente = Table("select * from cliente", "id_cliente")
        Producto = Table("select * from producto", "id_producto")
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        btnaceptar.Enabled = False
        Criterio = "fecha>='" + EDATE(Dtpdesde.Text) + " 00:00:00' and fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"
        CriterioNC = "fecha>='" + EDATE(Dtpdesde.Text) + "' and fecha<='" + EDATE(dtphasta.Text) + "'"

        If Val(txtid_cliente.Text) > 0 Then

            Criterio = Criterio + " and FACTURA.Id_Cliente=" + txtid_cliente.Text
            CriterioNC = CriterioNC + " and CLIENTE.Id_Cliente=" + txtid_cliente.Text
        End If

        Facs = FACM(Criterio, False, "")
        Dim nc As DataTable
        nc = NCM(CriterioNC, False, "")

        Dim documento As DataColumn = New DataColumn("documento")
        documento.DataType = System.Type.GetType("System.String")
        Facs.Columns.Add(documento)


        Dim z As Integer
        For z = 0 To Facs.Rows.Count - 1
            With Facs.Rows(z)
                .Item("documento") = .Item("id_Factura")
            End With
        Next

        
        Dim rownc As DataRow
        For z = 0 To nc.Rows.Count - 1
            With nc.Rows(z)
                rownc = Facs.NewRow
                rownc("id_Factura") = .Item("id_nota_credito")
                rownc("documento") = .Item("id_nota_credito")
                rownc("id_cliente") = .Item("id_cliente")
                rownc("fecha") = .Item("fecha")
                rownc("exento") = .Item("exento") * -1
                rownc("gravado") = .Item("gravado") * -1
                rownc("subtotal") = (.Item("gravado") + .Item("exento")) * -1
                rownc("iv") = .Item("iv") * -1
                rownc("monto") = .Item("monto") * -1
                rownc("nombre") = .Item("nombre")
                rownc("id_agente") = 0
                rownc("plazo") = 0
                rownc("piv") = .Item("piv")
                rownc("piv") = .Item("piv")
                rownc("anulado") = .Item("anulado")

                Facs.Rows.Add(rownc)
            End With
        Next



        Dim rVC As Object

        If cbresumido.Checked = False Then
            rVC = New rpt_venta_neta_cliente
        Else
            rVC = New rpt_venta_neta_resumido
        End If

        rVC.SetDataSource(Facs)


        rParameterFieldDefinitions = rVC.DataDefinition.ParameterFields

        rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Del " + Dtpdesde.Text + " al " + dtphasta.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

        rParameterFieldLocation = rParameterFieldDefinitions.Item("id_cliente")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = txtid_cliente.Text + " - " + lblcliente_nombre.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

        Dim rv As New frm_Report_Viewer
        rv.crv.ReportSource = rVC
        rv.Text = "Ventas por Cliente"
        rv.Show()
        btnaceptar.Enabled = True

    End Sub

    Private Sub frm_rpt_venta_opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cliente = Table("select * from cliente", "id_cliente")
        Producto = Table("select * from producto", "id_producto")

    End Sub


    Public Sub Identifica_cliente()
        ' Try
        '
        rowc = Cliente.Rows.Find(txtid_cliente.Text)
        If rowc Is Nothing Then
            MessageBox.Show("cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        lblcliente_nombre.Text = rowc("nombre")
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
            Identifica_Cliente()
        Else
            If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                BUSQUEDA = "rpt_venta_neta_cliente_opciones"
                Dim Cliente_buscar As New frm_Cliente_Buscar
                Cliente_buscar.Owner = Me
                Cliente_buscar.Show()
                Cliente_buscar.txtbuscar_Cliente.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_cliente.Text, False)
            End If
        End If
    End Sub


End Class