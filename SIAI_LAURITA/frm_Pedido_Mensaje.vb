
Public Class frm_Pedido_Mensaje

    Private Sub txtmensaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmensaje.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtmensaje_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmensaje.TextChanged

    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        btnaceptar.Enabled = False
        myForms.frm_pedido.Guardar(False)
        myForms.frm_pedido.PMensaje = txtmensaje.Text
        myForms.frm_pedido.Alistar_Imprimir()
        Me.Close()
    End Sub
End Class