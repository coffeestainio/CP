
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_Cambio
    Public CTPD As DataTable
    Dim Faltante As DataTable

    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues

    Private Sub frm_Cambio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        With myForms.frm_pedido
            .Totales()
            .botones(False)
            .btncambios.Enabled = True
            .btnfacturar.Enabled = True
            .btnproformar.Enabled = True
            .btnguardar.Enabled = True
        End With
    End Sub



    Private Sub frm_Cambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CTPD_crear()
        dtgcambio.DataSource = CTPD

    End Sub


    Public Sub Totales()

        lblproductos.Text = CTPD.Rows.Count
    End Sub

    Private Sub Producto_Incluir()
        Dim Cambio_mantenimiento As New frm_Cambio_Mantenimiento
        myForms.frm_Cambio_Mantenimiento = Cambio_mantenimiento
        myForms.frm_Cambio_Mantenimiento.Owner = Me
        Cambio_mantenimiento.lbltitulo.Text = "Incluir Producto"
        Cambio_mantenimiento.Show()

    End Sub

    Private Sub tsbfacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub botones(ByVal e As Boolean)
        btnincluir.Enabled = e
        btnmodificar.Enabled = e
        btneliminar.Enabled = e
        btnguardar.Enabled = e

    End Sub



    Public Sub Faltante_crear()
        'Try

        Faltante = New DataTable("Faltante")

        Dim id_Producto As DataColumn = New DataColumn("id_Producto")
        id_Producto.DataType = System.Type.GetType("System.String")
        Faltante.Columns.Add(id_Producto)

        Dim fecha As DataColumn = New DataColumn("fecha")
        fecha.DataType = System.Type.GetType("System.DateTime")
        Faltante.Columns.Add(fecha)

        Dim nombre As DataColumn = New DataColumn("nombre")
        nombre.DataType = System.Type.GetType("System.String")
        Faltante.Columns.Add(nombre)

        Dim presentacion As DataColumn = New DataColumn("presentacion")
        presentacion.DataType = System.Type.GetType("System.Int16")
        Faltante.Columns.Add(presentacion)

        Dim presentacion_nombre As DataColumn = New DataColumn("presentacion_nombre")
        presentacion_nombre.DataType = System.Type.GetType("System.String")
        Faltante.Columns.Add(presentacion_nombre)

        Dim cantidad_p As DataColumn = New DataColumn("cantidad_p")
        cantidad_p.DataType = System.Type.GetType("System.Decimal")
        Faltante.Columns.Add(cantidad_p)

        Dim cantidad_u As DataColumn = New DataColumn("cantidad_u")
        cantidad_u.DataType = System.Type.GetType("System.Decimal")
        Faltante.Columns.Add(cantidad_u)

        
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        ' End Try

    End Sub


    Public Sub CTPD_crear()
        'Try

        CTPD = New DataTable("CTPD")
        Dim id_producto As DataColumn = New DataColumn("id_producto")
        id_producto.DataType = System.Type.GetType("System.String")
        CTPD.Columns.Add(id_producto)

        Dim nombre As DataColumn = New DataColumn("nombre")
        nombre.DataType = System.Type.GetType("System.String")
        CTPD.Columns.Add(nombre)

        Dim cantidad As DataColumn = New DataColumn("cantidad")
        cantidad.DataType = System.Type.GetType("System.Int32")
        CTPD.Columns.Add(cantidad)

        Dim unidad_nombre As DataColumn = New DataColumn("unidad_nombre")
        unidad_nombre.DataType = System.Type.GetType("System.String")
        CTPD.Columns.Add(unidad_nombre)


        Dim unidad As DataColumn = New DataColumn("unidad")
        unidad.DataType = System.Type.GetType("System.Int16")
        CTPD.Columns.Add(unidad)


        Dim empaque As DataColumn = New DataColumn("empaque")
        empaque.DataType = System.Type.GetType("System.Int16")
        CTPD.Columns.Add(empaque)

        Dim precio As DataColumn = New DataColumn("precio")
        precio.DataType = System.Type.GetType("System.Decimal")
        CTPD.Columns.Add(precio)

        Dim consumidor As DataColumn = New DataColumn("consumidor")
        consumidor.DataType = System.Type.GetType("System.Decimal")
        CTPD.Columns.Add(consumidor)

        Dim descuento As DataColumn = New DataColumn("descuento")
        descuento.DataType = System.Type.GetType("System.Decimal")
        descuento.DefaultValue = 0
        CTPD.Columns.Add(descuento)



        Dim iv As DataColumn = New DataColumn("iv")
        iv.DataType = System.Type.GetType("System.Boolean")
        CTPD.Columns.Add(iv)


        Dim Monto As DataColumn = New DataColumn("Monto")
        Monto.DataType = System.Type.GetType("System.Decimal")
        Monto.Expression = "cantidad * precio"
        CTPD.Columns.Add(Monto)

        Dim ubicacion As DataColumn = New DataColumn("ubicacion")
        ubicacion.DataType = System.Type.GetType("System.Int32")
        CTPD.Columns.Add(ubicacion)

        CTPD.PrimaryKey = New DataColumn() {CTPD.Columns("id_producto")}

        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        ' End Try

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

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        Guardar()
        Me.Close()
    End Sub


    Private Sub Guardar()
        'Try

        If CTPD.Rows.Count = 0 Then
            MessageBox.Show("No Hay Productos que Guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        Faltante_crear()
        Dim rowf As DataRow

        Dim cmd As New SqlCommand
        cmd.Connection = CONN1
        Dim Sql As String
        Dim z As Integer
        Dim cc As Decimal
        Dim cp As Decimal

        Dim rowtpd As DataRow

        For z = 0 To CTPD.Rows.Count - 1
            With CTPD.Rows(z)
                cc = IIf(.Item("unidad") = 1, .Item("cantidad"), .Item("cantidad") * .Item("empaque"))
                rowtpd = myForms.frm_pedido.TPD.Rows.Find(.Item("id_Producto"))


                If rowtpd Is Nothing Then
                    If cc > 0 Then myForms.frm_pedido.TPD.ImportRow(CTPD.Rows(z))
                Else
                    cp = IIf(rowtpd("unidad") = 1, rowtpd("cantidad"), rowtpd("cantidad") * rowtpd("empaque"))
                    If cc < cp Then
                        Sql = "insert into Faltante (fecha,id_producto,cantidad) values (" + _
                        "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
                        "'" + .Item("id_producto") + "'," + _
                        (cp - cc).ToString + ")"

                        cmd.CommandText = Sql
                        OpenConn()
                        cmd.ExecuteNonQuery()
                        rowf = Faltante.NewRow

                        rowf("id_producto") = .Item("id_Producto")
                        rowf("fecha") = Date.Today.ToShortDateString
                        rowf("nombre") = .Item("nombre")
                        rowf("presentacion") = .Item("unidad")
                        rowf("presentacion_nombre") = .Item("unidad_nombre")
                        rowf("cantidad_p") = Int((cp - cc) / rowtpd("empaque"))
                        rowf("cantidad_u") = (cp - cc) Mod rowtpd("empaque")

                        Faltante.Rows.Add(rowf)

                    End If


                    If cc = 0 Then
                        rowtpd.Delete()
                    Else
                        rowtpd("cantidad") = .Item("cantidad")
                        rowtpd("unidad") = .Item("unidad")
                        rowtpd("unidad_nombre") = .Item("unidad_nombre")
                        rowtpd("precio") = .Item("precio")
                    End If

                End If
            End With
        Next

        If Faltante.Rows.Count > 0 Then Faltante_Reporte()

        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try

    

    End Sub


    Private Sub Faltante_Reporte()

        Dim rfaltante As New rpt_Faltante

        rfaltante.SetDataSource(Faltante)

        rParameterFieldDefinitions = rfaltante.DataDefinition.ParameterFields

        rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Cliente :" + myForms.frm_pedido.lblcliente_nombre.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        Dim rv As New frm_Report_Viewer
        rv.crv.ReportSource = rfaltante
        rv.Text = "Faltantes"
        rv.Show()
        rv.WindowState = FormWindowState.Normal


    End Sub





    Private Sub dtgcambio_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgcambio.CellContentClick

    End Sub

    Private Sub dtgcambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgcambio.KeyDown
        If e.KeyCode = Keys.Insert Then
            Producto_Incluir()
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            Producto_Modificar()
        ElseIf e.KeyCode = Keys.Delete Then
            Producto_Eliminar()
        End If
    End Sub


    Private Sub Producto_Modificar()
        Try
            If CTPD.Rows.Count = 0 Then
                MessageBox.Show("Nada que Modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim Cambio_mantenimiento As New frm_Cambio_Mantenimiento
            myForms.frm_Cambio_Mantenimiento = Cambio_mantenimiento
            With myForms.frm_Cambio_Mantenimiento
                myForms.frm_Cambio_Mantenimiento.Owner = Me
                .lbltitulo.Text = "Modificar Producto"
                Dim row As DataRow = CTPD.Rows(BindingContext(CTPD).Position())
                .Owner = Me

                .txtid_producto.Text = row("id_producto")
                .lblproducto_nombre.Text = row("nombre")
                .lblprecio.Text = row("precio")
                .txtcantidad.Text = row("cantidad")
                .lbliv.Text = IIf(row("iv"), "+ iv", "")
                .Producto_ID = row("id_producto")
                .Show()
                .Precio_Calcular()
                SendKeys.Send("{home}+{end}")
            End With
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
    Private Sub Producto_Eliminar()
        Try
            If CTPD.Rows.Count = 0 Then
                MessageBox.Show("Nada que Eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim row As DataRow = CTPD.Rows(BindingContext(CTPD).Position())
            Dim res As DialogResult = MessageBox.Show("Elimnar " + row("nombre"), "Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = Windows.Forms.DialogResult.Yes Then
                row.Delete()
                Totales()
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

End Class