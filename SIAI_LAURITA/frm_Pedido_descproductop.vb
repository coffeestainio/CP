Public Class frm_Pedido_descproductop
    Private Sub txtdescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescuento.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtdescuento.Text, True)
        End If
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Try
            With myForms.frm_pedido
                Dim selectedRows As DataGridViewSelectedRowCollection = .dtgpedido.SelectedRows
                If selectedRows.Count = 1 Then
                    Dim row As DataRow = .TPD.Rows.Find(lblid_producto.Text)
                    Dim descuento As Decimal = row("consumidor") * Val(txtdescuento.Text) / 100

                    row("descuento") = Val(txtdescuento.Text)
                    row("consumidor") = row("consumidor") - descuento

                Else
                    For Each row As DataGridViewRow In selectedRows

                        Dim codigo As String = row.Cells("id_producto").Value

                        Dim trow As DataRow = .TPD.Rows.Find(codigo)
                        Dim descuento As Decimal = trow("consumidor") * Val(txtdescuento.Text) / 100
                        trow("descuento") = Val(txtdescuento.Text)
                        trow("consumidor") = trow("consumidor") - descuento
                    Next
                End If
            End With
            Me.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub frm_mesa_descuento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myForms.frm_pedido.Totales()
    End Sub


    Private Sub txtdescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdescuento.TextChanged

    End Sub
End Class