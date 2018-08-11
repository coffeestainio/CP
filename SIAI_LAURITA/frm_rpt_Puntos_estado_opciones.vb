Imports System.Data.sqlclient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_rpt_Puntos_estado_opciones
    Inherits System.Windows.Forms.Form
    Public V_Estado_Cuenta As DataTable
    Dim Factura As DataTable
    Dim Debito As DataTable
    Public cliente As DataTable
    Dim Cliente_ID As String
    

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
                BUSQUEDA = "Puntos_estado"

                Dim cliente_buscar As New frm_cliente_buscar
                cliente_buscar.Owner = Me
                cliente_buscar.Show()
                cliente_buscar.txtbuscar_cliente.Text = e.KeyChar

            Else

                e.Handled = Numerico(Asc(e.KeyChar), txtid_cliente.Text, False)
            End If
        End If
    End Sub

    Public Sub Identifica_cliente()
        Try
            Dim rowc As DataRow
            rowc = cliente.Rows.Find(txtid_cliente.Text)
            If rowc Is Nothing Then
                MessageBox.Show("Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If
            lblnombre_cliente.Text = rowc("nombre")
            Dtpdesde.Focus()
            Cliente_ID = txtid_cliente.Text
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub frm_estado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            CONN1.Close()
            myForms.frm_principal.ToolStrip.Enabled = True
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub frm_estado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            OpenConn()
            cliente = Table("select * from cliente where eliminado=0", "id_cliente")
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'Try
        btnaceptar.Enabled = False
        If Val(txtid_cliente.Text) = 0 Then
            MessageBox.Show("Debe Escribir un Código de cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            btnaceptar.Enabled = True
            Exit Sub
        End If
        If Cliente_ID <> txtid_cliente.Text Then
            MessageBox.Show("Escriba de Nuevo el Número de cliente y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            btnaceptar.Enabled = True
            Exit Sub
        End If

        Dim rParameterDiscreteValue As ParameterDiscreteValue
        Dim rParameterFieldDefinitions As ParameterFieldDefinitions
        Dim rParameterFieldLocation As ParameterFieldDefinition
        Dim rParameterValues As ParameterValues

        Dim criterio As String
        Dim criterio2 As String
        criterio = "factura.fecha>='" + EDATE(Dtpdesde.Text) + "' and factura.fecha<='" + EDATE(dtphasta.Text) + "' and factura.id_cliente=" + txtid_cliente.Text
        criterio2 = " Puntos_debito.fecha>='" + EDATE(Dtpdesde.Text) + "' and puntos_debito.fecha<='" + EDATE(dtphasta.Text) + "' and Puntos_debito.id_cliente=" + txtid_cliente.Text
        V_Estado_Cuenta = Table("select * from V_estado_cuenta", "")


        Factura = FACPTS(criterio, True)
        Debito = DEBP(criterio2, True)

        Dim SA As Decimal = 0
        Dim FS As DataTable = FACPS("factura.fecha>='09/04/2006' and factura.id_cliente=" + txtid_cliente.Text)
        Dim z As Integer
        For z = 0 To FS.Rows.Count - 1
            SA = SA + FS.Rows(z).Item("psaldo")
        Next

        V_Estado_Cuenta_cargar(Factura, "Factura", 0)
        V_Estado_Cuenta_cargar(Debito, "Debito", 1)

        Dim restado As New rpt_Puntos_Estado

        restado.SetDataSource(V_Estado_Cuenta)
        rParameterFieldDefinitions = restado.DataDefinition.ParameterFields

        rParameterFieldLocation = rParameterFieldDefinitions.Item("cliente")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Cliente: " + txtid_cliente.Text + " - " + lblnombre_cliente.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

        rParameterFieldLocation = rParameterFieldDefinitions.Item("periodo")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Movimientos del " + Dtpdesde.Text + " al " + dtphasta.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

        rParameterFieldLocation = rParameterFieldDefinitions.Item("sact")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = FormatNumber(SA, 2)
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

        Dim rv As New frm_Report_Viewer

        rv.crv.ReportSource = restado
        rv.Text = "Estado de Cuenta Puntos"
        rv.Show()


        btnaceptar.Enabled = True
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub V_Estado_Cuenta_cargar(ByVal Tabla As DataTable, ByVal Des As String, ByVal Cr As Boolean)
        Dim rowe As DataRow
        Dim z As Integer
        Dim Tipo As String = ""
        For z = 0 To Tabla.Rows.Count - 1
            With Tabla.Rows(z)
                rowe = V_Estado_Cuenta.NewRow
                rowe("fecha") = .Item("fecha")
                Select Case Des
                    Case "Factura"
                        rowe("id_documento") = .Item("id_factura")
                    Case "Debito"
                        rowe("id_documento") = .Item("id_debito")

                End Select


                rowe("descripcion") = Des
                rowe("monto") = .Item("puntos") * IIf(Cr, -1, 1)
                If Des = "Factura" Then
                    rowe("referencia") = ""
                Else
                    rowe("referencia") = .Item("referencia")
                End If

                V_Estado_Cuenta.Rows.Add(rowe)
                

            End With
        Next
    End Sub


    Private Sub txtid_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_cliente.TextChanged

    End Sub
End Class