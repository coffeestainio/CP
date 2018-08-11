Imports System.Data.SqlClient
Public Class frm_recibo_anular

    Dim TTR As DataTable
    Dim Recibo As DataTable
    Dim Cliente As DataTable
    Dim Recibo_detalle As DataTable

    Dim recibo_id As String
    Dim Monto As Decimal
    Dim Id_cliente As String
    Dim id_factura As Integer



    Public Sub Identifica_Recibo()
        'Try

        Recibo = RECM("recibo.id_recibo=" + txtid_recibo.Text, True, "")
        If Recibo.Rows.Count = 0 Then
            MessageBox.Show("Recibo No Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_recibo.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        With Recibo.Rows(0)

            If .Item("anulado") Then
                MessageBox.Show("Recibo Ya Fue Anulado", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_recibo.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If

            If .Item("forma_pago") = 1 Then
                lblforma_pago.Text = "Efectivo"
            ElseIf .Item("forma_pago") = 2 Then
                lblforma_pago.Text = "Cheque"
            Else
                lblforma_pago.Text = "Transferencia"
            End If

            TTR = Table("select id_Factura from recibo_detalle where id_recibo =" & .Item("id_recibo"), "")
            id_factura = TTR.Rows(0).Item(0)

            Cliente = Table("Select nombre from cliente where id_cliente=" + .Item("id_cliente").ToString, "")
            
            lblid_cliente.Text = .Item("id_cliente").ToString + " - " + Cliente.Rows(0).Item("nombre")
            lblfecha.Text = .Item("fecha")
            lblmonto.Text = FormatNumber(.Item("monto").ToString, 2)
            recibo_id = txtid_recibo.Text
        End With
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub frm_recibo_anular_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            myForms.frm_principal.ToolStrip.Enabled = True
            CONN1.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub frm_recibo_anular_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            OpenConn()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub txtid_recibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_recibo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_recibo.Text) = 0 Then
                Me.Close()
            Else
                Identifica_Recibo()
            End If
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtid_recibo.Text, False)
        End If
    End Sub

   
    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'Try
        If Val(txtid_recibo.Text) = 0 Then
            MessageBox.Show("Debe Escribir un Número de Recibo", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_recibo.Focus()
            SendKeys.Send("{home}+{end}")
            pbid_recibo.Visible = True
            Exit Sub
        End If
        If recibo_id <> txtid_recibo.Text Then
            MessageBox.Show("Escriba de Nuevo el Número de recibo y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_recibo.Focus()
            SendKeys.Send("{home}+{end}")
            pbid_recibo.Visible = True
            Exit Sub
        End If
        Dim cmd As New SqlCommand
        cmd.Connection = CONN1
        Dim sql As String

        sql = "insert into Reversion (id_documento,tipo,fecha,id_usuario) values (" + _
        txtid_recibo.Text + "," + _
        "4" + "," + _
        "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
        USUARIO_ID + ")"



        cmd.CommandText = sql
        OpenConn()
        cmd.ExecuteNonQuery()

        Dim tnc As DataTable
        Dim i As Integer

        tnc = Table("select * from nota_credito_detalle where id_recibo =  " + txtid_recibo.Text, "")
        For i = 0 To tnc.Rows.Count - 1
            sqlquery("update tfacs set saldo= saldo + 2*(" & Val(tnc.Rows(i).Item("aplicado")) & ") where id_factura = " & tnc.Rows(i).Item("id_Factura"))
        Next


        sql = "delete from Nota_credito_detalle where id_recibo=" + txtid_recibo.Text
        cmd.CommandText = sql
        OpenConn()
        cmd.ExecuteNonQuery()


        Dim tt As DataTable
        tt = Table("Select * from recibo_detalle where id_recibo = " & txtid_recibo.Text, "")
        For i = 0 To tt.Rows.Count - 1
            sqlquery("update tfacs set saldo= saldo + " & tt.Rows(i).Item("abono") & " where id_factura = " & tt.Rows(i).Item("id_factura"))
        Next


        Me.Close()
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

   
End Class