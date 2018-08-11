Imports System.Data.SqlClient
Public Class frm_Nota_Credito_Reversar
    Dim cliente As DataTable
    Dim NC As DataTable
    Dim movimiento_ID As String
    

    Public Sub Identifica_Movimiento()

        'Try

        Dim criterio As String = "nota_credito.id_nota_credito = " + txtid_movimiento.Text
        
        NC = NCM(criterio, True, "")

        If NC.Rows.Count = 0 Then
            MessageBox.Show("Nota de Crédito No Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_movimiento.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        With NC.Rows(0)
            If .Item("anulado") Then
                MessageBox.Show("Nota de Crédito Ya Fue Reversada", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_movimiento.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If


            Dim ncd As DataTable = NCA("id_nota_credito=" + .Item("id_nota_credito").ToString, "")

            If ncd.Rows.Count > 0 Then
                MessageBox.Show("Nota de Crédito Fue Aplicada en Recibo #" + ncd.Rows(0).Item("id_recibo").ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_movimiento.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If



            'cliente = Table("Select nombre_comercial from cliente where id_cliente=" + Fac.Rows(0).Item("id_cliente").ToString, "")
            lblid_cliente.Text = .Item("id_cliente").ToString + " - " + .Item("nombre")
            movimiento_ID = txtid_movimiento.Text
            lblfecha.Text = .Item("fecha")
            lblexento.Text = FormatNumber(.Item("exento"), 2)
            lblgravado.Text = FormatNumber(.Item("gravado"), 2)
            lbliv.Text = FormatNumber(.Item("gravado") * .Item("piv"), 2)
            lblmonto.Text = FormatNumber(.Item("monto"), 2)
        End With
        '        Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    

   
    Private Sub frm_descuento_financiero_anular_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            myForms.frm_principal.ToolStrip.Enabled = True
            CONN1.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub frm_descuento_financiero_anular_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            OpenConn()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub txtid_movimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_movimiento.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_movimiento.Text) = 0 Then
                Me.Close()
            Else
                Identifica_Movimiento()
            End If
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtid_movimiento.Text, False)
        End If
    End Sub

    Private Sub txtid_movimiento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_movimiento.TextChanged

    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Try
            If Val(txtid_movimiento.Text) = 0 Then
                MessageBox.Show("Debe Escribir un Número de Nota de Crédito", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_movimiento.Focus()
                pbid_movimiento.Visible = True
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If

            If movimiento_ID <> txtid_movimiento.Text Then
                MessageBox.Show("Escriba de Nuevo el Número de Nota de crédito y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_movimiento.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If

            Dim cmd As New SqlCommand
            cmd.Connection = CONN1
            Dim sql As String

            sql = "insert into Reversion (id_documento,tipo,fecha,id_usuario) values (" + _
               txtid_movimiento.Text + "," + _
            "6" + "," + _
            "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
           USUARIO_ID + ")"

            cmd.CommandText = sql
            OpenConn()
            cmd.ExecuteNonQuery()

            Me.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub
End Class