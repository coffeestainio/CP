Public Class frm_Compra_Mantenimiento
    Public Producto_ID As String
    Dim Consumidor As Decimal
    Dim Util As Decimal
    Dim rowp As DataRow
    Dim PF As Decimal

    Public Sub Identifica_producto()
        'Try
        With myForms.frm_Compra
            rowp = .Producto.Rows.Find(txtid_producto.Text)
            If rowp Is Nothing Then
                MessageBox.Show("producto no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If

            Dim row As DataRow
            row = .TCD.Rows.Find(txtid_producto.Text)
            If Not (row Is Nothing) Then
                If (lbltitulo.Text = "Incluir Producto") Or (lbltitulo.Text <> "Incluir Producto" And .TCD.Rows(.BindingContext(.TCD).Position()).Item("id_producto") <> row("id_producto")) Then
                    MessageBox.Show("Código de Producto Ya Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtid_producto.Focus()
                    SendKeys.Send("{home}+{end}")
                    Exit Sub
                End If
            End If

            lblproducto_nombre.Text = rowp("nombre")
            lblempaque.Text = "Empaque  " + rowp("empaque").ToString


            lbliv.Text = IIf(rowp("iv"), "+ iv", "")

            If rowp("presentacion") = 1 Then
                lblpresentacion.Text = "Und"
            ElseIf rowp("presentacion") = 2 Then
                lblpresentacion.Text = "Caj"
            ElseIf rowp("presentacion") = 3 Then
                lblpresentacion.Text = "Blt"
            Else
                lblpresentacion.Text = "Pqt"
            End If
            txtprecio.Text = rowp("costo")
            lblprecio_actual.Text = FormatNumber(rowp("costo"), 2)

            txtcantidad.Focus()
            Producto_ID = txtid_producto.Text
            SendKeys.Send("{home}+{end}")
        End With
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub


    Private Sub txtid_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_producto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) And txtid_producto.Text.Length = 6 Then
            Identifica_producto()
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = Convert.ToChar(Keys.Return) And Val(txtid_producto.Text) = 0 Then
            e.Handled = True
            Me.Close()
            Exit Sub
        End If

        If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
            BUSQUEDA = "Compra"
            Dim producto_buscar As New frm_producto_buscar
            producto_buscar.Owner = Me
            producto_buscar.Show()
            producto_buscar.txtbuscar_producto.Text = e.KeyChar
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtid_producto.Text, False)
        End If


    End Sub



    Private Sub Actualizar()
        'Try
        If Val(txtid_producto.Text) = 0 Then
            pbid_producto.Visible = True
            MessageBox.Show("Debe digitar un código de producto", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            pbid_producto.Visible = True
            txtid_producto.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        Else
            pbid_producto.Visible = False
        End If

        If Producto_ID <> txtid_producto.Text Then
            MessageBox.Show("Escriba de Nuevo el Número de producto y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            pbid_producto.Visible = True
            txtid_producto.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        If Val(txtcantidad.Text) = 0 Then
            pbcantidad.Visible = True
            MessageBox.Show("Debe digitar una cantidad", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
            pbcantidad.Visible = True
            txtcantidad.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        Else
            pbcantidad.Visible = False
        End If

        Dim row As DataRow
        With myForms.frm_Compra


            If lbltitulo.Text = "Incluir Producto" Then
                row = .TCD.NewRow()
            Else
                row = .TCD.Rows(.BindingContext(.TCD).Position())
            End If

            row("id_producto") = txtid_producto.Text

            row("nombre") = lblproducto_nombre.Text
            row("cantidad") = txtcantidad.Text
            row("unidad") = rowp("presentacion")
            row("empaque") = rowp("empaque")
            row("precio") = PF

            row("iv") = IIf(lbliv.Text = "", 0, 1)

            If lbltitulo.Text = "Incluir Producto" Then
                .TCD.Rows.Add(row)
            End If

            .Totales()
        End With

        If lbltitulo.Text = "Incluir Producto" Then
            limpiar()
        Else
            myForms.frm_Compra.Totales()
            Me.Close()
        End If
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Sub
    Private Sub txtcantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtcantidad.Text, True)
        End If
    End Sub


    Private Sub limpiar()
        Try
            txtid_producto.Text = ""
            txtcantidad.Text = ""
            lblproducto_nombre.Text = ""
            lbliv.Text = ""
            lblempaque.Text = ""
            txtid_producto.Focus()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub



    Private Sub txtid_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_producto.TextChanged
        If txtid_producto.Text.Length = 6 Then
            Identifica_producto()
        End If
    End Sub

    

    Public Sub precio_final_calcular()

        Dim d1 As Decimal
        Dim d2 As Decimal
        d1 = Val(txtprecio.Text) * Val(txtdesca.Text) / 100
        d2 = (Val(txtprecio.Text) - d1) * Val(txtdescb.Text) / 100
        Pf = Val(txtprecio.Text) - d1 - d2
        lblprecio_final.Text = FormatNumber(Pf, 2)
    End Sub

    Private Sub txtprecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            precio_final_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtprecio.Text, True)
        End If
    End Sub

    Private Sub txtdesca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesca.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            precio_final_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtdesca.Text, True)
        End If
    End Sub


    Private Sub txtdescb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescb.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            precio_final_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtdescb.Text, True)
        End If
    End Sub

    

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Actualizar()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub
End Class