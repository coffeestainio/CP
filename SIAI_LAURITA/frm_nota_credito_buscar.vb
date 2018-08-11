Public Class frm_nota_credito_buscar
    Dim nc As DataTable
    Private Sub frm_nota_credito_buscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nc = NCDIS(myForms.frm_recibo.criterio, "")
        dtgnc.DataSource = nc
        
    End Sub
    Private Sub NC_Asignar()
        Try
            With myForms.frm_recibo
                Dim i As Integer
                For i = 0 To .documento.Rows.Count - 1
                    With .documento.Rows(i)
                        If .Item("monto") < 0 And .Item("id_documento") = dtgnc.Item("id_nota_credito", dtgnc.CurrentRow.Index).Value Then
                            MessageBox.Show("Nota de Crédito Ya Fue Seleccionada", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End With
                Next
                Dim rowa As DataRow = .Documento.NewRow
                rowa("id_documento") = dtgnc.Item("id_nota_credito", dtgnc.CurrentRow.Index).Value
                rowa("monto") = (dtgnc.Item("monto", dtgnc.CurrentRow.Index).Value) * -1
                .Documento.Rows.Add(rowa)
                .Totales()
            End With
            Me.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub


    Private Sub dtgnc_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgnc.CellContentClick

    End Sub

    Private Sub dtgnc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgnc.Click
        NC_Asignar()
    End Sub
End Class