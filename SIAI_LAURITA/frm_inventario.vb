Imports System.Data.sqlclient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_inventario
    Inherits System.Windows.Forms.Form

    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues

    Public TPD As DataTable
    Dim V_Factura As DataTable
    Public Producto As DataTable
    Dim Pedido As DataTable
    Public cliente As DataTable
    Dim Agente As DataTable
    Public rowc As DataRow

    Dim FS(0) As String

    Dim alistarFlag As Boolean = False

    Dim cliente_ID As String

    Public tGravado As Decimal
    Public tExento As Decimal
    Public tGd As Decimal
    Public tEd As Decimal
    Public tdescuento As Decimal
    Public tiv As Decimal
    Public total As Decimal
    Public Cargandopedidos As Boolean
    Public orden_ruta As String
    Dim Alistar As String
    Public Fecha As String
    Public FacturaID As String
    Public PedidoID As String
    Public PIV As Decimal
    Public PMensaje As String

    Dim M1 As String
    Dim M2 As String
    Dim M3 As String



    Private Sub frm_pedido_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Consulta Then
            myForms.frm_principal.ToolStrip.Enabled = True
            CONN1.Close()
        End If
    End Sub

    Private Sub frm_pedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub Producto_Incluir()
        Dim Inventario_mantenimiento As New frm_inventario_mantenimiento
        myForms.frm_inventario_mantenimiento = Inventario_mantenimiento
        myForms.frm_inventario_mantenimiento.Owner = Me
        Inventario_mantenimiento.Show()
        Inventario_mantenimiento.lbltitulo.Text = "Incluir Producto"
        Inventario_mantenimiento.txtid_producto.Focus()
    End Sub



    Public Sub botones(ByVal e As Boolean)
        btnincluir.Enabled = e
        btnmodificar.Enabled = e
        btneliminar.Enabled = e
    End Sub

    Public Sub totales()
        Dim total As Integer = 0
        Dim precio As Decimal = 0
        For Each producto As DataRow In TPD.Rows
            total = total + producto("cantidad")
            precio = precio + producto("monto")
        Next
        lblTotal.Text = total
        lblmonto.Text = "¢ " + FormatNumber(precio, 2)
    End Sub

    Public Sub TPD_crear()
        'Try

        TPD = New DataTable("TPD")
        Dim id_producto As DataColumn = New DataColumn("id_producto")
        id_producto.DataType = System.Type.GetType("System.String")
        TPD.Columns.Add(id_producto)

        Dim nombre As DataColumn = New DataColumn("nombre")
        nombre.DataType = System.Type.GetType("System.String")
        TPD.Columns.Add(nombre)

        Dim cantidad As DataColumn = New DataColumn("cantidad")
        cantidad.DataType = System.Type.GetType("System.Int32")
        TPD.Columns.Add(cantidad)

        Dim unidad_nombre As DataColumn = New DataColumn("unidad_nombre")
        unidad_nombre.DataType = System.Type.GetType("System.String")
        TPD.Columns.Add(unidad_nombre)


        Dim unidad As DataColumn = New DataColumn("unidad")
        unidad.DataType = System.Type.GetType("System.Int16")
        TPD.Columns.Add(unidad)


        Dim empaque As DataColumn = New DataColumn("empaque")
        empaque.DataType = System.Type.GetType("System.Int16")
        TPD.Columns.Add(empaque)

        Dim precio As DataColumn = New DataColumn("precio")
        precio.DataType = System.Type.GetType("System.Decimal")
        TPD.Columns.Add(precio)

        Dim monto As DataColumn = New DataColumn("monto")
        precio.DataType = System.Type.GetType("System.Decimal")
        TPD.Columns.Add(monto)

        Dim ubicacion As DataColumn = New DataColumn("ubicacion")
        ubicacion.DataType = System.Type.GetType("System.Int32")
        TPD.Columns.Add(ubicacion)

        Dim sector As DataColumn = New DataColumn("id_sector")
        sector.DataType = System.Type.GetType("System.String")
        TPD.Columns.Add(sector)

        TPD.PrimaryKey = New DataColumn() {TPD.Columns("id_producto")}

        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        ' End Try

    End Sub

    Public Sub TPD_cargar()
        'Try
        Dim PD As DataTable
        'Producto = Table("select * from producto where id_producto in (select id_producto from pedido_detalle where id_pedido = " + cbid_pedido.Text + ")", "id_producto")
        Dim z As Integer
        Dim rowp As DataRow
        Dim rowtpd As DataRow
        TPD_crear()

        For z = 0 To PD.Rows.Count - 1
            With PD.Rows(z)
                rowtpd = TPD.NewRow

                rowtpd("id_producto") = .Item("id_producto")
                rowtpd("cantidad") = .Item("Cantidad")
                rowtpd("unidad") = .Item("unidad")


                If .Item("unidad") = 1 Then
                    rowtpd("unidad_nombre") = "Und"
                ElseIf .Item("unidad") = 2 Then
                    rowtpd("unidad_nombre") = "Caj"
                ElseIf .Item("unidad") = 3 Then
                    rowtpd("unidad_nombre") = "Blt"
                Else
                    rowtpd("unidad_nombre") = "Pqt"
                End If

                rowtpd("precio") = .Item("precio")

                rowtpd("nombre") = rowp("nombre")
                rowtpd("empaque") = rowp("empaque")

                rowtpd("ubicacion") = IIf(.Item("unidad") = 1, rowp("id_pasillo"), rowp("id_b_r"))
                rowtpd("id_sector") = rowp("id_sector")

                TPD.Rows.Add(rowtpd)
            End With
        Next
        dtgpedido.Focus()
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub btnincluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnincluir.Click
        Producto_Incluir()
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Producto_Modificar()
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Producto_Eliminar()
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub btnAlistar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Alistar = Date.Now.ToShortTimeString
            'Guardar()

            Dim PM As New frm_Pedido_Mensaje
            PM.Owner = Me
            PM.Show()


        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try


    End Sub


    Private Sub Guardar_Inventario()

        Try
            Dim Sql As String
            Dim cmd As New SqlCommand
            cmd.Connection = CONN1

            Tsort(TPD, "nombre")


            Dim z As Integer
            For z = 0 To TPD.Rows.Count - 1

                With TPD.Rows(z)

                    Sql = "update Producto set existencia=existencia+" + (IIf(.Item("unidad") = 1, .Item("cantidad"), .Item("cantidad") * .Item("empaque"))).ToString + _
                    " where id_Producto='" + .Item("id_producto") + "'"

                    cmd.CommandText = Sql
                    OpenConn()
                    cmd.ExecuteNonQuery()
                End With
            Next z

            MsgBox("Inventario actualizado con éxito.", MsgBoxStyle.Information, "Operación exitosa")

        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try

    End Sub

    Private Sub dtgpedido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgpedido.KeyDown
        ' If USUAR Then
        'Else
        If e.KeyCode = Keys.Insert Then

            Producto_Incluir()
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            Producto_Modificar()
        ElseIf e.KeyCode = Keys.Delete Then
            Producto_Eliminar()
        End If
        'End If
    End Sub

    Private Sub Producto_Modificar()
        Try
            If TPD.Rows.Count = 0 Then
                MessageBox.Show("Nada que Modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim Inventario_mantenimiento As New frm_inventario_mantenimiento
            myForms.frm_inventario_mantenimiento = Inventario_mantenimiento
            With myForms.frm_inventario_mantenimiento
                myForms.frm_inventario_mantenimiento.Owner = Me
                .lbltitulo.Text = "Modificar Producto"
                Dim row As DataRow = TPD.Rows(BindingContext(TPD).Position())
                .Owner = Me

                .txtid_producto.Text = row("id_producto")
                .lblproducto_nombre.Text = row("nombre")
                .lblprecio.Text = row("precio")
                .txtcantidad.Text = row("cantidad")
                .Producto_ID = row("id_producto")
                '.cbunidad.Items.Add("Und")
                '.cbunidad.Items.Add(Prst(row("unidad")))
                .cbunidad.SelectedIndex = IIf(row("unidad") > 1, 1, 0)
                .Show()
                SendKeys.Send("{home}+{end}")
            End With
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
    Private Sub Producto_Eliminar()
        Try
            If TPD.Rows.Count = 0 Then
                MessageBox.Show("Nada que Eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim row As DataRow = TPD.Rows(BindingContext(TPD).Position())
            Dim res As DialogResult = MessageBox.Show("Elimnar " + row("nombre"), "Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = Windows.Forms.DialogResult.Yes Then
                row.Delete()
                totales()
                If TPD.Rows.Count = 0 Then
                    btneliminar.Enabled = False
                    btnmodificar.Enabled = False
                End If

            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Public Function getSaveLocation() As String
        Try
            SaveReportDialog.Filter = "Report Files (*.pdf*)|*.pdf"
            If SaveReportDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                Return SaveReportDialog.FileName
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub frm_inventario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If USUARIO_NIVEL = 3 Then
                btnLimpiar.Visible = True
            End If

            If Not Consulta Then
                OpenConn()

                Producto = Table("select * from producto  order by id_producto", "id_producto")
                TPD_crear()

                TPD.Rows.Clear()
                dtgpedido.DataSource = TPD
                Producto_Incluir()

            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btnguardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        If TPD.Rows.Count = 0 Then
            MessageBox.Show("No Hay Productos que Guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim respuesta As MsgBoxResult
        respuesta = MessageBox.Show("Desea actualizar el inventario?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = MsgBoxResult.No Then
            Exit Sub
        End If
        Alistar = ""
        Guardar_Inventario()
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Try
            Dim respuesta As MsgBoxResult
            respuesta = MessageBox.Show("Esta opción eliminara el inventario de todos los productos. ¿Desea continuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If respuesta = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim sql As String = "update Producto set existencia = 0"

            Dim cmd As New SqlCommand
            cmd.Connection = CONN1
            cmd.CommandText = sql
            OpenConn()
            cmd.ExecuteNonQuery()

            MsgBox("Inventario eliminado con éxito.", MsgBoxStyle.Information, "Operación exitosa")
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
End Class