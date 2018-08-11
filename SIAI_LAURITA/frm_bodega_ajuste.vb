Imports System.Data.SqlClient
Public Class frm_bodega_ajuste
    Public Bodega As DataTable
    Public Ajuste As DataTable
    Public Producto As DataTable

    Private Sub frm_ajuste_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            CONN1.Close()
            myForms.frm_principal.ToolStrip.Enabled = True
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub


    Private Sub frm_ajuste_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            OpenConn()
            Producto = Table("select * from producto  order by id_producto", "id_producto")

            Ajuste = Table("select id_bodega,tipo,id_producto,cantidad from bodega_ajuste where id_producto=0", "")

            Dim Nombre As DataColumn = New DataColumn("nombre")
            Nombre.DataType = System.Type.GetType("System.String")
            ajuste.Columns.Add(Nombre)

            Dim presentacion As DataColumn = New DataColumn("presentacion")
            presentacion.DataType = System.Type.GetType("System.String")
            ajuste.Columns.Add(presentacion)

            
            Dim descripcion As DataColumn = New DataColumn("descripcion")
            descripcion.DataType = System.Type.GetType("System.String")
            Ajuste.Columns.Add(descripcion)

            dtgajuste.DataSource = ajuste
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try

    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Try
            If Ajuste.Rows.Count = 0 Then
                MessageBox.Show("Nada que Eliminar ", "", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Dim row As DataRow = Ajuste.Rows(BindingContext(Ajuste).Position())
            Dim res As DialogResult = MessageBox.Show("Eliminar " + row("nombre"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If res = Windows.Forms.DialogResult.Yes Then
                row.Delete()
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btnicluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnicluir.Click
        Try
            Dim bodega_ajuste_mantenimiento As New frm_bodega_ajuste_mantenimiento
            myForms.frm_Bodega_ajuste_mantenimiento = bodega_ajuste_mantenimiento
            With bodega_ajuste_mantenimiento
                'Dim z As Integer
                'For z = 0 To Bodega.Rows.Count - 1
                'With Bodega.Rows(z)
                ' bodega_ajuste_mantenimiento.cbid_bodega.Items.Add(.Item("id").ToString + "-" + .Item("nombre"))
                'End With
                '   Next
                .cbid_bodega.SelectedIndex = 0
                .cbtipo.SelectedIndex = 0
                .Owner = Me
                .Show()
            End With
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        Try
            btnguardar.Enabled = False
            If Ajuste.Rows.Count = 0 Then
                MessageBox.Show("No Hay Ajustes que Aplicar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim cmd As New SqlCommand
            cmd.Connection = CONN1
            Dim sql As String
            Dim z As Integer
            For z = 0 To Ajuste.Rows.Count - 1
                With Ajuste.Rows(z)
                    sql = "insert into C_bodega_ajuste (id_bodega,tipo,id_producto,cantidad,id_usuario,fecha) values (" + _
                    .Item("id_bodega").ToString + "," + _
                    .Item("tipo").ToString + "," + _
                    .Item("id_producto").ToString + "," + _
                    .Item("cantidad").ToString + "," + _
                    USUARIO_ID + "," + _
                    "'" + EDATE(Date.Today.ToShortDateString) + "')"

                    cmd.CommandText = sql
                    OpenConn()
                    cmd.ExecuteNonQuery()


                    sql = "update bodega_detalle set " + _
                    "existencia=existencia" + IIf(.Item("tipo") = 0, "+", "-") + .Item("cantidad").ToString + _
                    " where id_producto=" + .Item("id_producto").ToString + " and id_bodega=" + .Item("id_bodega").ToString

                    cmd.CommandText = sql
                    OpenConn()
                    cmd.ExecuteNonQuery()


                End With
            Next
            Me.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
End Class