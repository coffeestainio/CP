Public Class frm_existencia_conteo
    Dim Producto_ID As Integer
    Dim criterio As String

    Private Sub cbtipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbubicacion.SelectedIndexChanged
        llenar_grid()
    End Sub
    Public Sub llenar_grid()
        Dim Producto As DataTable
        Dim U As String
        Dim i As Integer

        If Val(cbubicacion.Text) < 10 Then
            criterio = "where id_b_r=" + cbubicacion.Text
             U = "Bodega "
        ElseIf Val(cbubicacion.Text) < 40 Then
            criterio = "where id_pasillo=" + cbubicacion.Text
            U = "Pasillo "
        Else
            criterio = "where id_b_r=" + cbubicacion.Text
            U = "Rack "
        End If

        lblfiltro.Text = U + cbubicacion.Text

        Producto = Table("select id_producto, nombre from Producto " + criterio + " order by nombre", "")

        dtgproducto.DataSource = Producto

        For i = 0 To dtgproducto.RowCount - 1
            dtgproducto.Item("existencia", i).Value = 0
            dtgproducto.Item("unidad", i).Value = "Unidad"
        Next

    End Sub

    Private Sub frm_existencia_conteo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CONN1.Close()
        myForms.frm_principal.ToolStrip.Enabled = True
    End Sub

    Private Sub frm_existencia_conteo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OpenConn()
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        guardar()
    End Sub

    Public Sub guardar()
        Dim res As Integer
        res = MsgBox("Al continuar modificara las existencias de los proudctos. ¿Desea continuar?", MsgBoxStyle.YesNo)
        If res = vbNo Then
            Exit Sub
        End If
        Dim i As Integer
        Dim cantidad As Integer
        Dim total As Integer
        Dim tcant As DataTable

        For i = 0 To dtgproducto.RowCount - 1
            If dtgproducto.Item("unidad", i).Value = "Unidad" Then
                cantidad = 1
            Else
                tcant = Table("select empaque from producto where id_producto = " & dtgproducto.Item("id_producto", i).Value, "")
                cantidad = tcant.Rows(0).Item(0)
            End If
            total = cantidad * dtgproducto.Item("existencia", i).Value

            sqlquery("update producto set existencia = existencia + " & total & " where id_producto = " & dtgproducto.Item("id_producto", i).Value)
        Next
        'Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpasar.SelectedIndexChanged
        Dim i As Integer
        For i = 0 To dtgproducto.RowCount - 1
            dtgproducto.Item("unidad", i).Value = cbpasar.Text
        Next
    End Sub
End Class