Public Class frm_bodega_ajuste_mantenimiento
    Dim Producto_ID As Integer
    Private Sub txtid_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_producto.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Return) Then
                e.Handled = True
                If Val(txtid_producto.Text) = 0 Then
                    Me.Close()
                Else
                    Identifica_producto()
                End If
            Else
                If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                    BUSQUEDA = "Bodega_Ajuste"
                    Dim producto_buscar As New frm_producto_buscar
                    producto_buscar.Owner = Me
                    producto_buscar.Show()
                    producto_buscar.txtbuscar_producto.Text = e.KeyChar
                Else
                    e.Handled = Numerico(Asc(e.KeyChar), txtid_producto.Text, False)
                End If
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Public Sub Identifica_producto()
        Try
            Dim row As DataRow
            row = myForms.frm_bodega_ajuste.Producto.Rows.Find(txtid_producto.Text)
            If row Is Nothing Then
                MessageBox.Show("producto no Existe", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If
            lblproducto_nombre.Text = row("nombre")
            lblpresentacion.Text = row("presentacion")
            txtcantidad.Focus()
            Producto_ID = txtid_producto.Text
            SendKeys.Send("{home}+{end}")
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub



    Private Sub txtid_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_producto.TextChanged

    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Try
            If Val(txtid_producto.Text) = 0 Then
                MessageBox.Show("Escriba un código de Producto", "", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                pbid_producto.Visible = True
                txtid_producto.Focus()
                Exit Sub
            End If
            If Producto_ID <> txtid_producto.Text Then
                MessageBox.Show("Escriba de Nuevo el código del Producto y presione Enter Cantidad ", "", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                pbid_producto.Visible = True
                txtid_producto.Focus()
                Exit Sub
            End If
            If Val(txtcantidad.Text) = 0 Then
                MessageBox.Show("Escriba una Cantidad ", "", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                pbcantidad.Visible = True
                txtcantidad.Focus()
                Exit Sub
            End If

            Dim bodega_ID As String = IIf(IsNumeric(cbid_bodega.Text.Substring(1, 1)), cbid_bodega.Text.Substring(0, 2), cbid_bodega.Text.Substring(0, 1))

            Dim row As DataRow
            Dim rowb As DataRow
            With myForms.frm_bodega_ajuste
                row = .Ajuste.NewRow()
                row("id_producto") = txtid_producto.Text
                row("cantidad") = txtcantidad.Text
                row("nombre") = lblproducto_nombre.Text
                row("presentacion") = lblpresentacion.Text
                row("id_bodega") = bodega_ID
                row("tipo") = cbtipo.SelectedIndex
                rowb = .Bodega.Rows.Find(bodega_ID)
                row("bodega_nombre") = rowb("nombre")
                row("descripcion") = IIf(cbtipo.SelectedIndex = 0, "Entrada", "Salida")
                .Ajuste.Rows.Add(row)
            End With
            limpiar()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub limpiar()
        Try
            txtid_producto.Text = ""
            txtcantidad.Text = ""
            lblproducto_nombre.Text = ""
            lblpresentacion.Text = ""
            cbid_bodega.SelectedIndex = 0
            cbtipo.SelectedIndex = 0
            txtid_producto.Focus()
        Catch myerror As Exception
            MsgBox(myerror.Message)
        End Try
    End Sub

    Private Sub txtcantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtcantidad.Text, True)
        End If
    End Sub

    Private Sub txtcantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcantidad.TextChanged

    End Sub
End Class