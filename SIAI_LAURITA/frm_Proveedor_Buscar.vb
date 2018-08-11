Public Class frm_Proveedor_Buscar
    Dim Proveedor As DataTable
    Dim DvProveedor As DataView


    Private Sub frm_Proveedor_Buscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub txtbuscar_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbuscar_Proveedor.TextChanged
        Proveedor = Table("select id_proveedor,nombre from proveedor where  nombre Like '%" & txtbuscar_Proveedor.Text & "%'", "")
        DvProveedor = New DataView(Proveedor)
        DvProveedor.Sort = "nombre"
        dtgproveedor.DataSource = DvProveedor
    End Sub
    Private Sub Asignar_id_Proveedor()
        Try
            Select Case BUSQUEDA
                Case "Compra"
                    myForms.frm_Compra.txtid_proveedor.Text = dtgproveedor.Item("id", dtgproveedor.CurrentRow.Index).Value
                    myForms.frm_Compra.Identifica_Proveedor()
                Case "rpt_producto_opciones"
                    myForms.frm_rpt_producto_opciones.txtid_proveedor.Text = dtgproveedor.Item("id", dtgproveedor.CurrentRow.Index).Value
                    myForms.frm_rpt_producto_opciones.Identifica_Proveedor()
                Case "rpt_venta_producto_cliente_opciones"
                    myForms.frm_rpt_venta_producto_cliente_opciones.txtid_proveedor.Text = dtgproveedor.Item("id", dtgproveedor.CurrentRow.Index).Value
                    myForms.frm_rpt_venta_producto_cliente_opciones.Identifica_Proveedor()
            End Select
            Me.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
    Private Sub dtgProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgproveedor.Click
        Asignar_id_Proveedor()
    End Sub

    Private Sub dtgProveedor_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgproveedor.CellContentClick
        Asignar_id_Proveedor()
    End Sub
End Class