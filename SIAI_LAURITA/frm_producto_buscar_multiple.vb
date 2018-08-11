Public Class frm_producto_buscar_multiple
    Dim producto As DataTable
    Dim DvProducto As DataView



    Private Sub txtbuscar_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbuscar_producto.TextChanged
        If txtbuscar_producto.Text.Length > 0 Then
            If IsNumeric(txtbuscar_producto.Text.Substring(0, 1)) Then
                producto = Table("select id_producto,nombre from producto where  id_Producto Like '" & txtbuscar_producto.Text & "%'", "")
                DvProducto = New DataView(producto)
                DvProducto.Sort = "id_producto"
            Else
                producto = Table("select id_producto,nombre from producto where  nombre Like '%" & txtbuscar_producto.Text & "%'", "")
                DvProducto = New DataView(producto)
                DvProducto.Sort = "nombre"

            End If
        End If

        dtgproducto.DataSource = DvProducto
    End Sub

    
    Private Sub Producto_Seleccionar()
        lb_seleccionados.Items.Add(dtgproducto.Item("id_producto", dtgproducto.CurrentRow.Index).Value)
    End Sub

    Private Sub dtgproducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgproducto.Click
        Producto_Seleccionar()
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Dim tc As String = ""
        For z As Integer = 0 To lb_seleccionados.Items.Count - 1
            tc = tc + IIf(tc = "", "(", " or ") + "factura_Detalle.id_producto='" + lb_seleccionados.Items(z) + "'"
        Next
        tc = tc + ")"
        myForms.frm_rpt_venta_producto_cliente_opciones.produs = tc
        Me.Close()
    End Sub
End Class