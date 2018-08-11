Imports System.Data.SqlClient
Public Class frm_Linea_Mantenimiento
    Private Sub frm_Linea_Mantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'Try
        Dim Fi As Boolean = False
        If txtid_linea.Text = "" Then
            pbid_linea.Visible = True
            Fi = True
        Else
            pbid_linea.Visible = False
        End If


        If txtnombre.Text = "" Then
            pbnombre.Visible = True
            Fi = True
        Else
            pbnombre.Visible = False
        End If



        If Fi Then
            MessageBox.Show("Hay campos requeridos sin completar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        With myForms.frm_datos_mantenimiento

            Dim r As DataRow
            r = TS(.Linea, "nombre", txtnombre.Text)
            If Not (r Is Nothing) Then
                If (lbltitulo.Text = "Incluir Linea") Or (lbltitulo.Text <> "Incluir Linea" And .dtglinea.Item("dtglnid", .dtglinea.CurrentRow.Index).Value <> r("id_Linea")) Then
                    MessageBox.Show("Nombre de Linea Ya Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtnombre.Focus()
                    SendKeys.Send("{home}+{end}")
                    Exit Sub
                End If
            End If

            r = TS(.Linea, "id_Linea", txtid_linea.Text)
            If Not (r Is Nothing) Then
                If (lbltitulo.Text = "Incluir Linea") Or (lbltitulo.Text <> "Incluir Linea" And .dtglinea.Item("dtglnid", .dtglinea.CurrentRow.Index).Value <> r("id_Linea")) Then
                    MessageBox.Show("Código de Linea Ya Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtid_linea.Focus()
                    SendKeys.Send("{home}+{end}")
                    Exit Sub
                End If
            End If

            If lbltitulo.Text = "Incluir Linea" Then
                .rowl = .DvLinea.Table.NewRow()
            End If

            .rowl("nombre") = txtnombre.Text

            Dim sql As String
            Dim cmd As New SqlCommand
            cmd.Connection = CONN1

            If lbltitulo.Text = "Incluir Linea" Then
                sql = "insert into Linea (id_Linea,nombre) values (" + _
                "'" + txtid_linea.Text + "'," + _
                "'" + txtnombre.Text + "')"
            Else
                sql = "update Linea set " + _
                "id_linea='" + txtid_linea.Text + "'," + _
                "nombre='" + txtnombre.Text + "'" + _
                " where id_Linea='" + txtid_linea.Text + "'"
            End If
            cmd.CommandText = sql
            OpenConn()
            cmd.ExecuteNonQuery()
        End With
        Me.Close()
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub txtnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtid_linea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_linea.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtid_linea.Text, False)
        End If
    End Sub

    Private Sub txtid_linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_linea.TextChanged

    End Sub

    Private Sub txtnombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnombre.TextChanged

    End Sub
End Class