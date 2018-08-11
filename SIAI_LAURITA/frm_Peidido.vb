Imports System.Data.sqlclient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_pedido
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
    Public Formulario As Integer
    Public L As Integer
    Public Fecha As String
    Public FacturaID As String
    Public PedidoID As String
    Public PIV As Decimal
    Dim M1 As String
    Dim M2 As String
    Dim M3 As String



    Private Sub frm_pedido_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Consulta Then myForms.frm_pedidos.Filtro()
    End Sub

    Private Sub frm_pedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub


    Private Sub frm_pedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Consulta Then

                Producto = Table("select * from producto  order by id_producto", "id_producto")
                cliente = Table("select * from cliente where eliminado=0 order by id_cliente", "id_cliente")
                Agente = Table("select * from agente where eliminado=0 order by id_agente", "id_agente")
                TPD_crear()

                CB_crear(cbid_agente, Agente)

                Dim Ptro As DataTable
                Ptro = Table("select * from parametro", "")
                With Ptro.Rows(0)
                    PIV = .Item("iv")
                    M1 = .Item("m1")
                    M2 = .Item("m2")
                    M3 = .Item("m3")
                End With
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub


    Public Sub Identifica_cliente()
        ' Try
        '
        rowc = cliente.Rows.Find(txtid_cliente.Text)
        If rowc Is Nothing Then
            MessageBox.Show("Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        lblcliente_nombre.Text = rowc("nombre")
        txtplazo.Text = rowc("plazo")
        'Estado()
        cbid_pedido.Focus()
        Carga_pedidos()
        cliente_ID = txtid_cliente.Text
        identifica_pedido()
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub Carga_pedidos()
        'Try
        Cargandopedidos = True
        Pedido = Table("Select * from pedido where  id_cliente=" + txtid_cliente.Text + " order by id_pedido", "id_pedido")
        cbid_pedido.Items.Clear()
        Dim z As Integer
        For z = 0 To Pedido.Rows.Count - 1
            cbid_pedido.Items.Add(Pedido.Rows(z).Item("id_pedido").ToString)
        Next
        cbid_pedido.Items.Add("Nuevo")
        cbid_pedido.SelectedIndex = 0
        Cargandopedidos = False
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        ' End Try
    End Sub



    Private Sub identifica_pedido()
        'Try
        ToolStrip1.Enabled = True
        If cbid_pedido.Text = "Nuevo" Then
            TPD.Rows.Clear()
            dtgpedido.DataSource = TPD
            Incluir_producto()
        Else
            Dim row As DataRow
            row = Pedido.Rows.Find(cbid_pedido.Text)
            txtplazo.Text = row("plazo")
            TPD_cargar()
            Totales()
            dtgpedido.DataSource = TPD
        End If
        ' Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        '  End Try
    End Sub



    Public Sub Totales()
        Try
            Dim mf As Decimal
            Dim m As Decimal = 0
            Dim d As Decimal = 0


            Dim productos As Decimal = 0
            tGravado = 0
            tExento = 0
            tdescuento = 0
            tiv = 0
            total = 0
            Dim i As Integer

            For i = 0 To TPD.Rows.Count - 1
                With TPD.Rows(i)
                    m = .Item("precio") * .Item("cantidad")
                    d = m * (.Item("descuento") / 100)

                    mf = m - d
                    If .Item("iv") Then
                        tGravado = tGravado + mf
                        tiv = tiv + mf * PIV
                    Else
                        tExento = tExento + mf
                    End If
                    tdescuento = tdescuento + d
                    productos = productos + 1
                End With
            Next i

            total = tExento + tGravado + tiv
            lblproductos.Text = productos
            lbltotal.Text = "¢ " + FormatNumber(total, 2)
            If total > 0 Then
                botones(True)
            Else
                botones(False)
                btnincluir.Enabled = True
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub






    Private Sub limpiar()
        Try
            lblcliente_nombre.Text = ""
            txtid_cliente.Text = ""
            txtplazo.Text = ""
            cbid_agente.SelectedIndex = 0
            cbid_pedido.Items.Clear()
            TPD.Rows.Clear()
            Totales()
            txtid_cliente.Focus()
            ToolStrip1.Enabled = False
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub Incluir_producto()
        Dim Pedido_mantenimiento As New frm_pedido_mantenimiento
        myForms.frm_pedido_mantenimiento = Pedido_mantenimiento
        myForms.frm_pedido_mantenimiento.Owner = Me
        Pedido_mantenimiento.Show()
        Pedido_mantenimiento.lbltitulo.Text = "Incluir Producto"
    End Sub

    Private Sub tsbfacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub botones(ByVal e As Boolean)
        btnincluir.Enabled = e
        btnmodificar.Enabled = e
        btneliminar.Enabled = e
        btnguardar.Enabled = e
        btnproformar.Enabled = e
        btnAlistar.Enabled = e
        btnfacturar.Enabled = e

    End Sub


    Private Sub btntotales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntotales.Click
        Dim pedido_totales As New frm_pedido_totales
        With pedido_totales
            .Owner = Me
            .lblgravado.Text = FormatNumber(tGravado, 2)
            .lblexento.Text = FormatNumber(tExento, 2)
            .lbldescuento.Text = FormatNumber(tdescuento, 2)
            .lbliv.Text = FormatNumber(tiv, 2)
            .lbltotal.Text = "¢ " + FormatNumber(total, 2)
        End With
        pedido_totales.Show()
    End Sub




    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'imprimir()
    End Sub

    Private Sub txtid_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_cliente.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_cliente.Text) = 0 Then
                Me.Close()
            Else
                Identifica_cliente()
            End If
        Else

            If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                BUSQUEDA = "Pedido"

                Dim cliente_buscar As New frm_cliente_buscar
                cliente_buscar.Owner = Me
                cliente_buscar.Show()
                cliente_buscar.txtbuscar_cliente.Text = e.KeyChar

            Else

                e.Handled = Numerico(Asc(e.KeyChar), txtid_cliente.Text, False)
            End If
        End If

    End Sub

    Private Sub cbid_pedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbid_pedido.SelectedIndexChanged
        If Not Cargandopedidos Then identifica_pedido()
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

        Dim consumidor As DataColumn = New DataColumn("consumidor")
        consumidor.DataType = System.Type.GetType("System.Decimal")
        TPD.Columns.Add(consumidor)

        Dim descuento As DataColumn = New DataColumn("descuento")
        descuento.DataType = System.Type.GetType("System.Decimal")
        descuento.DefaultValue = 0
        TPD.Columns.Add(descuento)



        Dim iv As DataColumn = New DataColumn("iv")
        iv.DataType = System.Type.GetType("System.Boolean")
        TPD.Columns.Add(iv)


        Dim Monto As DataColumn = New DataColumn("Monto")
        Monto.DataType = System.Type.GetType("System.Decimal")
        Monto.Expression = "cantidad * precio"
        TPD.Columns.Add(Monto)

        Dim ubicacion As DataColumn = New DataColumn("ubicacion")
        ubicacion.DataType = System.Type.GetType("System.Int32")
        TPD.Columns.Add(ubicacion)

        TPD.PrimaryKey = New DataColumn() {TPD.Columns("id_producto")}

        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        ' End Try

    End Sub

    Public Sub TPD_cargar()
        'Try
        Dim PD As DataTable
        PD = Table("select * from pedido_detalle where id_pedido=" + cbid_pedido.Text, "")
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
                ElseIf .Item("unidad") = 1 Then
                    rowtpd("unidad_nombre") = "Caj"
                ElseIf .Item("unidad") = 1 Then
                    rowtpd("unidad_nombre") = "Blt"
                Else
                    rowtpd("unidad_nombre") = "Pqt"
                End If

                rowtpd("descuento") = .Item("descuento") * 100
                rowtpd("precio") = .Item("precio")


                rowtpd("iv") = .Item("iv")

                rowp = Producto.Rows.Find(.Item("id_producto"))
                rowtpd("nombre") = rowp("nombre")
                rowtpd("empaque") = rowp("empaque")
                rowtpd("consumidor") = .Item("precio") * (1 + rowp("detalle")) * (1 + IIf(rowp("iv"), PIV, 0))

                rowtpd("ubicacion") = IIf(.Item("unidad") = 1, rowp("id_pasillo"), rowp("id_b_r"))

                TPD.Rows.Add(rowtpd)
            End With
        Next
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub


    Private Sub Estado()

        'Try

        Dim da As Integer
        Dim d As Integer
        Dim vencido As Decimal = 0.0
        Dim sinvencer As Decimal = 0.0

        Dim Factura As DataTable
        Factura = FACS("where id_cliente=" + txtid_cliente.Text, "", True)

        Dim z As Integer
        For z = 0 To Factura.Rows.Count - 1
            With Factura.Rows(z)
                If .Item("vence") > Date.Today Then
                    sinvencer = sinvencer + .Item("saldo")
                Else
                    vencido = vencido + .Item("saldo")
                    d = DateDiff(DateInterval.Day, .Item("vence"), Date.Today)
                    If d > da Then da = d
                End If
            End With
        Next

        If vencido > 0 Then
            pbmoroso.Visible = True
            lblvencido.Text = FormatNumber(vencido, 2)
            lbldias_atraso.Text = da.ToString
        Else
            pbaldia.Visible = True
        End If
        lbldisponible.Text = FormatNumber(rowc("limite_Credito") - vencido - sinvencer, 2)
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub




    Private Sub btnincluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnincluir.Click
        Incluir_producto()
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        Try
            Dim Pedido_mantenimiento As New frm_pedido_mantenimiento
            myForms.frm_pedido_mantenimiento = Pedido_mantenimiento
            With myForms.frm_pedido_mantenimiento
                myForms.frm_pedido_mantenimiento.Owner = Me
                .lbltitulo.Text = "Modificar Producto"
                Dim row As DataRow = TPD.Rows(BindingContext(TPD).Position())
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

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Try
            If TPD.Rows.Count = 0 Then
                MessageBox.Show("Nada que Eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim row As DataRow = TPD.Rows(BindingContext(TPD).Position())
            Dim res As DialogResult = MessageBox.Show("Elimnar " + row("nombre"), "Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = Windows.Forms.DialogResult.Yes Then
                row.Delete()
                Totales()
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        Guardar()
        Me.Close()
    End Sub


    Private Sub Guardar()
        'Try
        If TPD.Rows.Count = 0 Then
            MessageBox.Show("No Hay Productos que Guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Val(txtid_cliente.Text) = 0 Then
            MessageBox.Show("Debe Escribir un Código de cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        If cliente_ID <> txtid_cliente.Text Then
            MessageBox.Show("Escriba de Nuevo el código del Cliente y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = CONN1
        Dim Sql As String
        Dim P As DataTable
        If cbid_pedido.Text = "Nuevo" Then
            Sql = "Insert into Pedido (id_cliente,id_agente,fecha,plazo,id_usuario) values (" + _
            txtid_cliente.Text + "," + _
            cbid(cbid_agente.Text) + "," + _
            "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
            txtplazo.Text + "," + _
            USUARIO_ID + ")"

            P = Table(Sql + " select @@IDENTITY as id_pedido", "")
            PedidoID = P.Rows(0).Item("id_Pedido")

        Else
            Sql = "Update pedido set " + _
            "id_cliente=" + txtid_cliente.Text + "," + _
            "id_agente=" + cbid(cbid_agente.Text) + "," + _
            "fecha='" + EDATE(Date.Today.ToShortDateString) + "'," + _
            "plazo=" + txtplazo.Text + "," + _
            "id_usuario=" + USUARIO_ID + _
            " where id_pedido=" + cbid_pedido.Text

            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()

            PedidoID = cbid_pedido.Text

            cmd.CommandText = "delete from pedido_detalle where id_pedido=" + cbid_pedido.Text
            cmd.ExecuteNonQuery()
        End If

        Dim i As Integer
        For i = 0 To TPD.Rows.Count - 1
            With TPD.Rows(i)
                Sql = "insert into Pedido_detalle (id_pedido,id_producto,cantidad,unidad,precio,descuento,iv) values (" + _
                PedidoID + "," + _
                "'" + .Item("id_producto") + "'," + _
                .Item("cantidad").ToString + "," + _
                .Item("unidad").ToString + "," + _
                .Item("precio").ToString + "," + _
                (.Item("descuento") / 100).ToString + "," + _
                IIf(.Item("iv"), "1", "0") + ")"
            End With
            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()
        Next i
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub



    Private Sub btnAlistar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlistar.Click
        Guardar()

        Dim rAlistar As New rpt_Alistar


        rAlistar.SetDataSource(TPD)

        rParameterFieldDefinitions = rAlistar.DataDefinition.ParameterFields

        rParameterFieldLocation = rParameterFieldDefinitions.Item("cliente")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = txtid_cliente.Text + "-" + lblcliente_nombre.Text
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        rParameterFieldLocation = rParameterFieldDefinitions.Item("pedido")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = "Pedido " + PedidoID
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

        rParameterFieldLocation = rParameterFieldDefinitions.Item("direccion")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = rowc("direccion")
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


        Dim rv As New frm_Report_Viewer
        rv.crv.ReportSource = rAlistar
        rv.Show()
        Me.Close()

    End Sub

    Private Sub btnfacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfacturar.Click
        'Try
        If TPD.Rows.Count = 0 Then
            MessageBox.Show("No Hay Productos que Facturar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Val(txtid_cliente.Text) = 0 Then
            MessageBox.Show("Debe Escribir un Código de cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        If cliente_ID <> txtid_cliente.Text Then
            MessageBox.Show("Escriba de Nuevo el código del Cliente y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        btnfacturar.Enabled = False

        Facturas_Generar()
        Facturas_imprimir()


        ' If Not cbid_pedido.Text = "Nuevo" Then
        'Dim cmd As New SqlCommand
        'cmd.Connection = CONN1

        'cmd.CommandText = "delete from Pedido where id_pedido=" + cbid_pedido.Text
        'cmd.ExecuteNonQuery()
        'cmd.CommandText = "delete from pedido_detalle where id_pedido=" + cbid_pedido.Text
        'cmd.ExecuteNonQuery()
        'End If



        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try




    End Sub

    Private Sub Facturas_Generar()

        Dim Sql As String
        Dim cmd As New SqlCommand
        cmd.Connection = CONN1

        Dim F As DataTable

        Dim FGravado As Decimal
        Dim FExento As Decimal
        Dim Fdescuento As Decimal
        Dim Fiv As Decimal


        Dim LI As Integer
        Dim LS As Integer



        Dim Facturas As Integer = IIf(TPD.Rows.Count > 30, IIf(TPD.Rows.Count Mod 30 > 0, Int(TPD.Rows.Count / 30) + 1, TPD.Rows.Count / 30), 1)
        ReDim FS(Facturas + 1)

        Dim h As Integer

        For h = 1 To Facturas

            FGravado = 0
            FExento = 0
            Fdescuento = 0
            Fiv = 0

            Sql = "INSERT INTO FACTURA (id_cliente,id_agente,fecha,plazo,id_usuario,piv) values (" + _
            txtid_cliente.Text + "," + _
            cbid(cbid_agente.Text) + "," + _
            "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
            txtplazo.Text + "," + _
            USUARIO_ID + "," + _
            PIV.ToString + ")"

            F = Table(Sql + " select @@IDENTITY as id_factura", "")

            FacturaID = F.Rows(0).Item("id_factura")
            FS(h) = FacturaID

            LI = 30 * (h - 1)
            LS = IIf((LI + 29) > TPD.Rows.Count, TPD.Rows.Count - 1, LI + 29)

            Dim z As Integer
            For z = LI To LS

                With TPD.Rows(z)
                    Sql = "insert into Factura_detalle (id_factura,id_producto,cantidad,unidad,precio,descuento,iv) values (" + _
                    FacturaID + "," + _
                    "'" + .Item("id_producto") + "'," + _
                    .Item("cantidad").ToString + "," + _
                    .Item("unidad").ToString + "," + _
                    .Item("precio").ToString + "," + _
                    (.Item("descuento") / 100).ToString + "," + _
                    IIf(.Item("iv"), "1", "0").ToString + ")"

                    cmd.CommandText = Sql
                    cmd.ExecuteNonQuery()

                    Sql = "update Producto set existencia=existencia-" + (IIf(.Item("unidad") = 1, .Item("cantidad"), .Item("cantidad") * .Item("empaque"))).ToString + _
                    " where id_Producto='" + .Item("id_producto") + "'"

                    cmd.CommandText = Sql
                    cmd.ExecuteNonQuery()

                    
                End With
            Next z

        Next h
    End Sub


    Private Sub Facturas_imprimir()


        Dim FGravado As Decimal
        Dim FExento As Decimal
        Dim Fdescuento As Decimal
        Dim Fiv As Decimal

        Dim mf As Decimal
        Dim m As Decimal
        Dim d As Decimal

        Dim LI As Integer
        Dim LS As Integer


        V_Factura_crear()
        Dim Facturas As Integer = IIf(TPD.Rows.Count > 30, IIf(TPD.Rows.Count Mod 30 > 0, Int(TPD.Rows.Count / 30) + 1, TPD.Rows.Count / 30), 1)
        Dim h As Integer

        For h = 1 To Facturas
            V_Factura.Rows.Clear()

            FGravado = 0
            FExento = 0
            Fdescuento = 0
            Fiv = 0

            LI = 30 * (h - 1)
            LS = IIf((LI + 29) > TPD.Rows.Count, TPD.Rows.Count - 1, LI + 29)

            Dim z As Integer
            For z = LI To LS

                With TPD.Rows(z)

                    m = .Item("precio") * .Item("cantidad")
                    d = m * (.Item("descuento") / 100)

                    mf = m - d
                    If .Item("iv") Then
                        FGravado = FGravado + mf
                        Fiv = Fiv + mf * PIV
                    Else
                        FExento = FExento + mf
                    End If
                    Fdescuento = Fdescuento + d
                End With
                V_Factura.ImportRow(TPD.Rows(z))
            Next z

            Dim rfactura As New rpt_Factura

            rfactura.SetDataSource(V_Factura)

            rParameterFieldDefinitions = rfactura.DataDefinition.ParameterFields

            rParameterFieldLocation = rParameterFieldDefinitions.Item("tantos")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Factura " + h.ToString + "/" + Facturas.ToString
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("cliente")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = txtid_cliente.Text + "-" + lblcliente_nombre.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("direccion")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = rowc("direccion")
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("vencimiento")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = DateAdd(DateInterval.Day, Val(txtplazo.Text), Date.Today)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



            rParameterFieldLocation = rParameterFieldDefinitions.Item("contado")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = IIf(Val(txtplazo.Text) > 0, "", "X")
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("credito")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = IIf(Val(txtplazo.Text) > 0, "X", "")
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("telefono")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = rowc("telefono")
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)




            rParameterFieldLocation = rParameterFieldDefinitions.Item("gravado")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(FGravado, 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("iv")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(Fiv, 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("exento")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(FExento, 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("Total")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(FGravado + Fiv + FExento, 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("facturaid")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FS(h)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("totalg")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = IIf(h = Facturas, "Total General " + FormatNumber(total, 2), "")
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("m1")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = M1
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("m2")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = M1
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("m3")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = M1
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            Dim rv As New frm_Report_Viewer
            rv.crv.ReportSource = rfactura
            rv.Show()


        Next h

    End Sub


    Public Sub V_Factura_crear()
        'Try

        V_Factura = New DataTable("V_Factura")
        Dim id_producto As DataColumn = New DataColumn("id_producto")
        id_producto.DataType = System.Type.GetType("System.String")
        V_Factura.Columns.Add(id_producto)

        Dim nombre As DataColumn = New DataColumn("nombre")
        nombre.DataType = System.Type.GetType("System.String")
        V_Factura.Columns.Add(nombre)

        Dim cantidad As DataColumn = New DataColumn("cantidad")
        cantidad.DataType = System.Type.GetType("System.Int32")
        V_Factura.Columns.Add(cantidad)

        Dim unidad_nombre As DataColumn = New DataColumn("unidad_nombre")
        unidad_nombre.DataType = System.Type.GetType("System.String")
        V_Factura.Columns.Add(unidad_nombre)


        Dim unidad As DataColumn = New DataColumn("unidad")
        unidad.DataType = System.Type.GetType("System.Int16")
        V_Factura.Columns.Add(unidad)

        Dim empaque As DataColumn = New DataColumn("empaque")
        empaque.DataType = System.Type.GetType("System.Int16")
        V_Factura.Columns.Add(empaque)


        Dim precio As DataColumn = New DataColumn("precio")
        precio.DataType = System.Type.GetType("System.Decimal")
        V_Factura.Columns.Add(precio)

        Dim consumidor As DataColumn = New DataColumn("consumidor")
        consumidor.DataType = System.Type.GetType("System.Decimal")
        V_Factura.Columns.Add(consumidor)

        Dim descuento As DataColumn = New DataColumn("descuento")
        descuento.DataType = System.Type.GetType("System.Decimal")
        descuento.DefaultValue = 0
        V_Factura.Columns.Add(descuento)



        Dim iv As DataColumn = New DataColumn("iv")
        iv.DataType = System.Type.GetType("System.Boolean")
        V_Factura.Columns.Add(iv)


        Dim Monto As DataColumn = New DataColumn("Monto")
        Monto.DataType = System.Type.GetType("System.Decimal")
        Monto.Expression = "cantidad * precio"
        V_Factura.Columns.Add(Monto)

        Dim ubicacion As DataColumn = New DataColumn("ubicacion")
        ubicacion.DataType = System.Type.GetType("System.Int32")
        V_Factura.Columns.Add(ubicacion)

        V_Factura.PrimaryKey = New DataColumn() {V_Factura.Columns("id_producto")}

        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        ' End Try

    End Sub
    
End Class