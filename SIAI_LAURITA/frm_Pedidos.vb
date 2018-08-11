Imports System.Data.SqlClient
Public Class frm_Pedidos
    Dim Pedidos As DataTable
    Dim Cliente As DataTable
    Dim Cargando As Boolean


    Public Sub Filtro()
    

        Pedidos = Table("select id_pedido,id_cliente,fecha,alistar from Pedido order by id_pedido", "id_pedido")
        Dim nombre As DataColumn = New DataColumn("nombre")
        nombre.DataType = System.Type.GetType("System.String")
        Pedidos.Columns.Add(nombre)

        Dim i As Integer
        Dim row As DataRow
        For i = 0 To Pedidos.Rows.Count - 1
            row = Cliente.Rows.Find(Pedidos.Rows(i).Item("id_cliente"))
            Pedidos.Rows(i).Item("nombre") = row("id_cliente").ToString + "-" + row("nombre")
        Next
        dtgpedido.DataSource = Pedidos
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub frm_Pedidos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myForms.frm_principal.ToolStrip.Enabled = True
        CONN1.Close()
    End Sub

    Private Sub frm_Pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargando = True
        OpenConn()
        Cliente = Table("select * from cliente", "id_cliente")
        Filtro()
        Cargando = False
    End Sub

    Private Sub cbid_destino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not cargando Then Filtro()
    End Sub

    Private Sub dtpdesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not cargando Then Filtro()
    End Sub

    Private Sub dtphasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not cargando Then Filtro()
    End Sub

    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

  
    

    Private Sub rbfecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Cargando Then Filtro()
    End Sub

    Private Sub rbentrega_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Cargando Then Filtro()
    End Sub

    Private Sub Btnincluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnincluir.Click
        Dim Pedido As New frm_pedido
        myForms.frm_pedido = Pedido
        myForms.frm_pedido.Owner = Me
        Pedido.Show()
    End Sub

  
    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        If Pedidos.Rows.Count = 0 Then
            MessageBox.Show("Nada que Modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim row As DataRow = Pedidos.Rows(BindingContext(Pedidos).Position())
        Dim Pedido As New frm_pedido
        myForms.frm_pedido = Pedido
        myForms.frm_pedido.Owner = Me
        Pedido.Show()
        Pedido.txtid_cliente.Text = row("id_cliente")
        Pedido.Identifica_cliente()
    End Sub

    
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        If USUARIO_NIVEL < 3 Then
            MsgBox("Usuario tiene restringida esta funcion")
            Exit Sub
        End If
        If Pedidos.Rows.Count = 0 Then
            MessageBox.Show("Nada que Eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim pedidoID As String = dtgpedido.Item("id_pedido", dtgpedido.CurrentRow.Index).Value()
        Dim res As DialogResult = MessageBox.Show("Elimnar Pedido " + pedidoID, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = Windows.Forms.DialogResult.Yes Then
            Dim cmd As New SqlCommand
            cmd.Connection = CONN1
            cmd.CommandText = "delete from Pedido where id_Pedido=" + pedidoID
            OpenConn()
            cmd.ExecuteNonQuery()
            cmd.CommandText = "delete from Pedido_detalle where id_Pedido=" + pedidoID
            OpenConn()
            cmd.ExecuteNonQuery()
            Filtro()
        End If
    End Sub

    Private Sub dtgpedido_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgpedido.CellContentClick

    End Sub
End Class