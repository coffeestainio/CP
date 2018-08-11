Public Class frm_Cambio_Mantenimiento
    Public Producto_ID As String
    Dim Precio As Decimal
    Dim Consumidor As Decimal
    Dim Util As Decimal
    Dim rowp As DataRow
    Public Sub Identifica_producto()
        'Try
        With myForms.frm_Cambio
            rowp = myForms.frm_pedido.Producto.Rows.Find(txtid_producto.Text)
            If rowp Is Nothing Then
                lblproducto_nombre.ForeColor = Color.Red
                lblproducto_nombre.Text = "Producto No Existe"
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If

            'If rowp("bloqueado") Then
            '    lblproducto_nombre.ForeColor = Color.Red
            '    lblproducto_nombre.Text = "Producto Bloqueado"
            '    SendKeys.Send("{home}+{end}")
            '    Exit Sub
            'End If

            Dim row As DataRow
            row = .CTPD.Rows.Find(txtid_producto.Text)
            If Not (row Is Nothing) Then
                If (lbltitulo.Text = "Incluir Producto") Or (lbltitulo.Text <> "Incluir Producto" And .ctpd.Rows(.BindingContext(.ctpd).Position()).Item("id_producto") <> row("id_producto")) Then
                    lblproducto_nombre.ForeColor = Color.Red
                    lblproducto_nombre.Text = "Producto Ya Existe"
                    txtid_producto.Focus()
                    SendKeys.Send("{home}+{end}")
                    Exit Sub
                End If
            End If

            lblproducto_nombre.ForeColor = Color.Black
            lblproducto_nombre.Text = rowp("nombre")
            lblempaque.Text = rowp("empaque").ToString
            cbunidad.Items.Clear()
            cbunidad.Items.Add("Und")

            lbliv.Text = IIf(rowp("iv"), "+ iv", "")

            If rowp("presentacion") = 2 Then
                cbunidad.Items.Add("Caj")
            ElseIf rowp("presentacion") = 3 Then
                cbunidad.Items.Add("Blt")
            Else
                cbunidad.Items.Add("Pqt")
            End If
            cbunidad.SelectedIndex = 0

            If myForms.frm_pedido.rowc("precio") = 1 Then
                Util = rowp("utilidad_1")
            ElseIf myForms.frm_pedido.rowc("precio") = 2 Then
                Util = rowp("utilidad_2")
            ElseIf myForms.frm_pedido.rowc("precio") = 3 Then
                Util = rowp("utilidad_3")
            Else
                Util = rowp("utilidad_4")
            End If


            Precio_Calcular()


            If Precio <= 0 Then
                MessageBox.Show("Producto Debe Tener Especificado un Precio", "Cambio", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_producto.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If



            txtcantidad.Focus()
            Producto_ID = txtid_producto.Text

        End With
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub txtid_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtid_producto.GotFocus
        SendKeys.Send("{home}+{end}")
    End Sub

    Private Sub txtid_producto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtid_producto.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            SendKeys.Send("+{TAB}")
        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtid_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_producto.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) And Val(txtid_producto.Text) = 0 Then
            e.Handled = True
            Me.Close()
            Exit Sub
        End If

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Identifica_producto()
            e.Handled = True
            Exit Sub
        End If

        If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
            BUSQUEDA = "Cambio"
            Dim producto_buscar As New frm_producto_buscar
            producto_buscar.Owner = Me
            producto_buscar.Show()
            producto_buscar.txtbuscar_producto.Text = e.KeyChar
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtid_producto.Text, False)
        End If


    End Sub

    Private Sub frm_Cambio_mantenimiento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myForms.frm_Cambio.Totales()
        myForms.frm_cambio.dtgcambio.Focus()
    End Sub

    Private Sub frm_Cambio_Mantenimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frm_Cambio_mantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

       



        Dim row As DataRow
        With myForms.frm_cambio

            Dim rowtpd As DataRow
            rowtpd = .CTPD.Rows.Find(txtid_producto.Text)
            If Not (rowtpd Is Nothing) Then
                If (lbltitulo.Text = "Incluir Producto") Or (lbltitulo.Text <> "Incluir Producto" And .CTPD.Rows(.BindingContext(.CTPD).Position()).Item("id_producto") <> rowtpd("id_producto")) Then
                    lblproducto_nombre.ForeColor = Color.Red
                    lblproducto_nombre.Text = "Producto Ya Existe"
                    txtid_producto.Focus()
                    SendKeys.Send("{home}+{end}")
                    Exit Sub
                End If
            End If


            If lbltitulo.Text = "Incluir Producto" Then
                row = .CTPD.NewRow()
            Else
                row = .CTPD.Rows(.BindingContext(.CTPD).Position())
            End If

            row("id_producto") = txtid_producto.Text

            row("nombre") = lblproducto_nombre.Text
            row("cantidad") = Val(txtcantidad.Text)
            row("unidad") = IIf(cbunidad.SelectedIndex = 0, 1, rowp("presentacion"))
            row("empaque") = rowp("empaque")
            row("unidad_nombre") = cbunidad.Text
            row("precio") = Precio
            row("consumidor") = Consumidor

            row("iv") = IIf(lbliv.Text = "", 0, 1)
            row("ubicacion") = IIf(cbunidad.SelectedIndex = 0, rowp("id_pasillo"), rowp("id_b_r"))

            If lbltitulo.Text = "Incluir Producto" Then
                .CTPD.Rows.Add(row)
            End If

            .Totales()
        End With

        If lbltitulo.Text = "Incluir Producto" Then
            limpiar()
        Else
            myForms.frm_cambio.Totales()
            Me.Close()
        End If
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Sub
    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txtcantidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcantidad.GotFocus
        SendKeys.Send("{home}+{end}")
    End Sub

    Private Sub txtcantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcantidad.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            SendKeys.Send("+{TAB}")
        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
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
            lblconsumidor.Text = ""
            lblprecio.Text = ""
            lbliv.Text = ""
            lblempaque.Text = ""
            cbunidad.Items.Clear()
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

    Private Sub cbunidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbunidad.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            SendKeys.Send("+{TAB}")
        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbunidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbunidad.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Actualizar()
        End If
    End Sub

    Private Sub cbunidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbunidad.SelectedIndexChanged
        Precio_Calcular()
    End Sub
    Public Sub Precio_Calcular()
        Precio = rowp("costo") * (1 + Util) / IIf(cbunidad.SelectedIndex = 0, rowp("empaque"), 1)
        lblprecio.Text = FormatNumber(Precio, 0)
        Consumidor = rowp("costo") * (1 + Util) * (1 + rowp("detalle")) * (1 + IIf(rowp("iv"), myForms.frm_pedido.PIV, 0)) / rowp("empaque") / rowp("sub_empaque")
        lblconsumidor.Text = FormatNumber(Consumidor, 0)
    End Sub
End Class