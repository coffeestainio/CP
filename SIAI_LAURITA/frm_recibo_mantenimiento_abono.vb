Public Class frm_recibo_mantenimiento_abono
    Public Saldo As Decimal

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'Try

        If Val(txtabono.Text) = 0 Then
            pbabono.Visible = True
            MessageBox.Show("Debe Escribir un Monto para el Abono", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            pbabono.Visible = True
            txtabono.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        Else
            pbabono.Visible = False
        End If

        'If Val(txtabono.Text) > Saldo Then
        '    pbabono.Visible = True
        '    MessageBox.Show("El Abono NO Puede Ser Mayor al Saldo de la Factura", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    pbabono.Visible = True
        '    txtabono.Focus()
        '    SendKeys.Send("{home}+{end}")
        '    Exit Sub
        'Else
        '    pbabono.Visible = False
        'End If

        Dim i As Integer
        Dim total As Decimal = Val(txtabono.Text)
        With myForms.frm_recibo
            For i = 0 To .NCA.Rows.Count - 1
                total = total + .NCA.Rows(i).Item("monto")
            Next
            For i = 0 To .Fc.Rows.Count - 1
                Dim row As DataRow = .Fc.Rows.Item(i)
                If total > row("saldo") Then
                    row("abono") = row("saldo")
                    total = total - row("saldo")
                Else
                    row("abono") = total
                    total = 0
                End If
            Next
            'Dim row As DataRow = .Fc.Rows.Find(lblid_factura.Text)
            'row("abono") = txtabono.Text
        End With
        myForms.frm_recibo.Totales()
        Me.Close()
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub txtabono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtabono.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtabono.Text, True)
        End If
    End Sub

    Private Sub txtabono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtabono.TextChanged

    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub
End Class