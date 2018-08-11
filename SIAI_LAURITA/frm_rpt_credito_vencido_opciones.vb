Imports System.Data.sqlclient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_credito_vencido_opciones
    Public V_Estado_Cuenta As DataTable
    Public cliente As DataTable
    Dim Vencido As Integer
    Dim Sinvencer As Integer
    Dim ClienteID As String
    Dim rowc As DataRow



    Public Sub Identifica_cliente()
        ' Try
        cliente = Table("select * from cliente where id_cliente=" + txtid_cliente.Text, "")
        If Cliente.Rows.Count = 0 Then
            MessageBox.Show("cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        rowc = cliente.Rows(0)
        ClienteID = txtid_cliente.Text
        lblcliente_nombre.Text = rowc("nombre")
        SendKeys.Send("{tab}")
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub frm_rpt_credito_vencido_opciones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            CONN1.Close()
            myForms.frm_principal.ToolStrip.Enabled = True
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub frm_rpt_credito_vencido_opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            OpenConn()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub txtid_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_cliente.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_cliente.Text) = 0 Then
                Me.Close()
            Else
                Identifica_cliente()
            End If
        Else
            If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                BUSQUEDA = "credito_vencido"
                Dim cliente_buscar As New frm_cliente_buscar
                cliente_buscar.Owner = Me
                cliente_buscar.Show()
                cliente_buscar.txtbuscar_cliente.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_cliente.Text, False)
            End If
        End If
    End Sub

    Private Sub txtid_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_cliente.TextChanged

    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'Try
        btnaceptar.Enabled = False


        Dim rParameterDiscreteValue As ParameterDiscreteValue
        Dim rParameterFieldDefinitions As ParameterFieldDefinitions
        Dim rParameterFieldLocation As ParameterFieldDefinition
        Dim rParameterValues As ParameterValues

        Dim criterio As String = ""

        If ClienteID <> txtid_cliente.Text Then
            MessageBox.Show("Escriba de Nuevo el Número de cliente y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            btnaceptar.Enabled = True
            Exit Sub
        End If

        


        If txtid_cliente.Text <> "" Then
            criterio = " factura.id_cliente=" + rowc("id_cliente").ToString
        End If


        Dim Facx As DataTable
        Dim Fac As DataTable = FAC_S()


        Facx = FACS2(criterio, "")

        Dim xestado As DataColumn = New DataColumn("estado")
        xestado.DataType = System.Type.GetType("System.Int32")
        Facx.Columns.Add(xestado)


        Dim estado As DataColumn = New DataColumn("estado")
        estado.DataType = System.Type.GetType("System.Int32")
        Fac.Columns.Add(estado)








        Dim z As Integer
        For z = 0 To Facx.Rows.Count - 1
            With Facx.Rows(z)
                .Item("estado") = DateDiff("d", Date.Today, .Item("vence"))
                If .Item("vence") <= dtphasta.Value Then
                    Fac.ImportRow(Facx.Rows(z))
                End If
            End With
        Next

        Dim rPendiente As New rpt_credito_vencido

        rPendiente.SetDataSource(Fac)
        rParameterFieldDefinitions = rPendiente.DataDefinition.ParameterFields


        rParameterFieldLocation = rParameterFieldDefinitions.Item("negocio")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = NEGOCIO
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Hasta el " + dtphasta.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        Dim rv As New frm_Report_Viewer

        rv.crv.ReportSource = rPendiente
        rv.Text = "Crédito Vencido"
        rv.Show()

        btnaceptar.Enabled = True
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub
End Class