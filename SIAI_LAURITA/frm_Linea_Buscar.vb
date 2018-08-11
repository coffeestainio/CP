Public Class frm_Linea_Buscar
    Dim Linea As DataTable
    Dim Dvlinea As DataView
    Private Sub frm_linea_Buscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SendKeys.Send("{right}")
    End Sub



    Private Sub txtbuscar_linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbuscar_linea.TextChanged
        Linea = Table("select id_linea,nombre from linea where  nombre Like '%" & txtbuscar_linea.Text & "%'", "")
        Dvlinea = New DataView(Linea)
        Dvlinea.Sort = "nombre"
        dtglinea.DataSource = Dvlinea
    End Sub
    Private Sub Asignar_id_linea()
        Try
            Select Case BUSQUEDA
                Case "rpt_producto_opciones"
                    myForms.frm_rpt_producto_opciones.txtid_linea.Text = dtglinea.Item("id", dtglinea.CurrentRow.Index).Value
                    myForms.frm_rpt_producto_opciones.Identifica_linea()
                Case "rpt_venta_producto_cliente_opciones"
                    myForms.frm_rpt_venta_producto_cliente_opciones.txtid_linea.Text = dtglinea.Item("id", dtglinea.CurrentRow.Index).Value
                    myForms.frm_rpt_venta_producto_cliente_opciones.Identifica_linea()
            End Select
            Me.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
    Private Sub dtglinea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtglinea.Click
        Asignar_id_linea()
    End Sub

    Private Sub dtglinea_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtglinea.CellContentClick
        Asignar_id_linea()
    End Sub
End Class