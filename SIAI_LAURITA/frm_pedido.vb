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
    Dim FK(0) As String
    Dim FC(0) As String

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
    Public facturaClave As String
    Public facturaConsecutivo As String
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


    Private Sub frm_pedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Consulta Then
                OpenConn()

                Producto = Table("select * from producto  order by id_producto", "id_producto")
                cliente = Table("select * from cliente where eliminado=0 order by id_cliente", "id_cliente")
                Agente = Table("select * from agente where eliminado=0 order by id_agente", "id_agente")
                TPD_crear()

                CB_crear(cbid_agente, "Agente", "id_agente")

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
        If USUARIO_NIVEL < 2 Then
            btndescgeneralp.Enabled = False
        End If
    End Sub


    Public Sub Identifica_cliente()
        ' Try
        '
        'cliente = Table("select * from cliente where eliminado=0 and id_cliente = " & txtid_cliente.Text, "id_cliente")
        rowc = cliente.Rows.Find(txtid_cliente.Text)
        If rowc Is Nothing Then
            MessageBox.Show("Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        lblcliente_nombre.Text = rowc("nombre")
        txtplazo.Text = rowc("plazo")
        Estado()
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
            Producto_Incluir()
            If USUARIO_NIVEL < 2 Then
                botones(False)
                btncambios.Enabled = False
                btnfacturar.Enabled = False
                btnproformar.Enabled = False
                btnproformarweb.Enabled = False
                btnguardar.Enabled = False
                btnAlistar.Enabled = False
            End If
            btncambios.Enabled = False
            btnfacturar.Enabled = False
            btnproformar.Enabled = False
            btnproformarweb.Enabled = False
            btnguardar.Enabled = False
            btnAlistar.Enabled = False
        Else
            Dim row As DataRow
            row = Pedido.Rows.Find(cbid_pedido.Text)
            txtplazo.Text = row("plazo")
            TPD_cargar()
            Totales()
            dtgpedido.DataSource = TPD
            botones(False)
            'If USUARIO_NIVEL > 1 Then
            If alistarFlag = False Then
                btncambios.Enabled = True
                btnfacturar.Enabled = True
                btnproformar.Enabled = True
                btnproformarweb.Enabled = True
                btnguardar.Enabled = True
                btnAlistar.Enabled = True
            End If
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

                    mf = m
                    If .Item("iv") Then
                        tGravado = tGravado + mf
                        'tiv = tiv + mf * PIV
                        tiv = tiv + ((mf - d) * PIV)
                    Else
                        tExento = tExento + mf
                    End If
                    tdescuento = tdescuento + d
                    productos = productos + 1
                End With
            Next i

            total = tExento + tGravado + tiv - tdescuento
            lblproductos.Text = TPD.Rows.Count
            lbltotal.Text = "₡ " + FormatNumber(total, 2)
            If total > 0 And alistarFlag = False Then
                botones(True)
            Else
                botones(False)
                If Alistar = "" Then
                    btnincluir.Enabled = True
                End If
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
        If USUARIO_NIVEL < 2 Then
            btnincluir.Enabled = False
            btnmodificar.Enabled = False
            btndescgeneralp.Enabled = False
            btndescpp.Enabled = False
            btneliminar.Enabled = False
        End If
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
            lblvencido.Text = ""
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub Producto_Incluir()
        Dim Pedido_mantenimiento As New frm_pedido_mantenimiento
        myForms.frm_pedido_mantenimiento = Pedido_mantenimiento
        myForms.frm_pedido_mantenimiento.Owner = Me
        Pedido_mantenimiento.Show()
        Pedido_mantenimiento.lbltitulo.Text = "Incluir Producto"
    End Sub

    

    Public Sub botones(ByVal e As Boolean)
        btnincluir.Enabled = e
        btnmodificar.Enabled = e
        btneliminar.Enabled = e
        btndescpp.Enabled = e
        btnguardar.Enabled = e
        btnproformar.Enabled = e
        btnproformarweb.Enabled = e
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
            .lbltotal.Text = "₡ " + FormatNumber(total, 2)
        End With
        pedido_totales.Show()
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
        Dim PD_alistar As DataTable
        PD_alistar = Table("select alistar from pedido where id_pedido= " + cbid_pedido.Text, "")
        IIf(PD_alistar.Rows(0).Item("alistar").ToString <> "", alistarFlag = True, alistarFlag = False)
        Alistar = PD_alistar.Rows(0).Item("alistar").ToString

        Dim PD As DataTable
        PD = Table("select * from pedido_detalle where id_pedido=" + cbid_pedido.Text, "")
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

                rowtpd("descuento") = .Item("descuento") * 100
                rowtpd("precio") = .Item("precio")

                Dim util As Decimal
                
                rowtpd("iv") = .Item("iv")

                rowp = Producto.Rows.Find(.Item("id_producto"))
                If rowc("precio") = 1 Then
                    util = rowp("utilidad_1")
                ElseIf rowc("precio") = 2 Then
                    util = rowp("utilidad_2")
                ElseIf rowc("precio") = 3 Then
                    util = rowp("utilidad_3")
                Else
                    util = rowp("utilidad_4")

                End If
                rowtpd("nombre") = rowp("nombre")
                rowtpd("empaque") = rowp("empaque")
                rowtpd("consumidor") = rowp("costo") * (1 + util) / rowp("empaque") / rowp("sub_empaque") * (1 + rowp("detalle")) * (1 + IIf(rowp("iv"), PIV, 0))

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


    Private Sub Estado()
        Dim Vencido As Decimal = 0.0
        Dim criterio As String = "(factura.id_cliente=" + rowc("id_cliente").ToString + ")"
        Dim FAC As DataTable = FACS2(criterio, "id_Factura")

        For z As Integer = 0 To FAC.Rows.Count - 1
            With FAC.Rows(z)
                If Not .Item("vence") > Date.Today Then
                    Vencido = Vencido + .Item("saldo")
                End If
            End With
        Next

        If Vencido > 0 Then
            lblvencido.Text = "VENCIDO ₡" + FormatNumber(Vencido, 2)
        Else
            lblvencido.Text = ""
        End If

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
        If TPD.Rows.Count = 0 Then
            MessageBox.Show("No Hay Productos que Guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Val(txtid_cliente.Text) = 0 Then
            MessageBox.Show("Debe Escribir un Codigo de cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        If cliente_ID <> txtid_cliente.Text Then
            MessageBox.Show("Escriba de Nuevo el codigo del Cliente y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        Alistar = ""
        Guardar(False)
        Me.Close()
    End Sub


    Public Sub Guardar(ByVal alistarza As Boolean)
        'Try


        Dim cmd As New SqlCommand
        cmd.Connection = CONN1
        Dim Sql As String
        Dim P As DataTable
        If cbid_pedido.Text = "Nuevo" Then
            Sql = "Insert into Pedido (id_cliente,id_agente,fecha,Alistar,plazo,id_usuario) values (" + _
            txtid_cliente.Text + "," + _
            cbid(cbid_agente.Text).ToString + "," + _
            "'" + EDATE(Date.Today.ToShortDateString) + "'," & _
            "'" + Alistar.ToString + "'," + _
            Val(txtplazo.Text).ToString + "," + _
            USUARIO_ID.ToString + ")"

            P = Table(Sql + " select @@IDENTITY as id_pedido", "")
            PedidoID = P.Rows(0).Item("id_Pedido")

        Else

            If Alistar = "" Then
                Sql = "Update pedido set " + _
                "id_cliente=" + txtid_cliente.Text + "," + _
                "id_agente=" + cbid(cbid_agente.Text) + "," + _
                "plazo=" + Val(txtplazo.Text).ToString + "" + _
                " where id_pedido=" + cbid_pedido.Text
            Else
                Sql = "Update pedido set " + _
                "id_cliente=" + txtid_cliente.Text + "," + _
                "id_agente=" + cbid(cbid_agente.Text) + "," + _
                "Alistar='" + Alistar.ToString + "'," + _
                "plazo=" + Val(txtplazo.Text).ToString + "" + _
                " where id_pedido=" + cbid_pedido.Text
            End If

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

    Public Sub Alistar_Imprimir()




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

        rParameterFieldLocation = rParameterFieldDefinitions.Item("usuario_nombre")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = USUARIO_NOMBRE
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

        rParameterFieldLocation = rParameterFieldDefinitions.Item("mensaje")
        rParameterValues = rParameterFieldLocation.CurrentValues
        rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        rParameterDiscreteValue.Value = PMensaje
        rParameterValues.Add(rParameterDiscreteValue)
        rParameterFieldLocation.ApplyCurrentValues(rParameterValues)





        If ID_ESTACION = 1 Then
            rAlistar.PrintOptions.PrinterName = "REPORTES"
        Else
            rAlistar.PrintOptions.PrinterName = "\\" + PRINTER + "\REPORTES"
        End If
        rAlistar.PrintToPrinter(1, False, 1, 99)

        'Dim rv As New frm_Report_Viewer
        'rv.crv.ReportSource = rAlistar
        'rv.Show()


        Me.Close()


    End Sub


    Private Sub btnAlistar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlistar.Click
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

    Private Sub btnfacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfacturar.Click
        If USUARIO_NIVEL = 1 Then
            MsgBox("Usuario tiene restringida esta funcion")
            Exit Sub
        End If
        Try
            If TPD.Rows.Count = 0 Then
                MessageBox.Show("No Hay Productos que Facturar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Val(txtid_cliente.Text) = 0 Then
                MessageBox.Show("Debe Escribir un Codigo de cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_cliente.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If
            If cliente_ID <> txtid_cliente.Text Then
                MessageBox.Show("Escriba de Nuevo el codigo del Cliente y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_cliente.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If

            Dim hacienda As Boolean = True

            Dim res As DialogResult
            res = MessageBox.Show("Desea incluir RECEPTOR en la factura?", "Sistema de Facturacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If res = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            If res = Windows.Forms.DialogResult.No Then
                hacienda = False
            End If

            btnfacturar.Enabled = False

            Dim facturagenerada As Boolean = False

            ' seleccionar el usuario que hizo el pedido
            If cbid_pedido.Text = "Nuevo" Then
                facturagenerada = Facturas_Generar(USUARIO_ID, hacienda)
            Else
                Dim TPU As DataTable
                TPU = Table("select id_usuario from Pedido where id_pedido = " & cbid_pedido.Text, "")
                facturagenerada = Facturas_Generar(Val(TPU.Rows(0).Item(0).ToString), hacienda)
            End If

            Facturas_imprimir("F", True)

            ' EjectuarFacturacionElectronica()

            If facturagenerada Then

                If Not cbid_pedido.Text = "Nuevo" Then
                    Dim cmd As New SqlCommand
                    cmd.Connection = CONN1
                    cmd.CommandText = "delete from Pedido where id_pedido=" + cbid_pedido.Text
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "delete from pedido_detalle where id_pedido=" + cbid_pedido.Text
                    cmd.ExecuteNonQuery()
                End If
            Else
                MsgBox("Hubo un error al generar la factura, favor de verificar el pedido")

            End If

            Me.Close()

        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try




    End Sub

    Private Function Facturas_Generar(ByVal id_usuario As Integer, ByVal hacienda As Integer) As Boolean
        Try

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

            Tsort(TPD, "nombre")


            Dim Facturas As Integer = IIf(TPD.Rows.Count > 28, IIf(TPD.Rows.Count Mod 28 > 0, Int(TPD.Rows.Count / 28) + 1, TPD.Rows.Count / 28), 1)
            ReDim FS(Facturas + 1)
            ReDim FK(Facturas + 1)
            ReDim FC(Facturas + 1)


            'Dim numConsecutivo As String = "0"
            'Dim claveNumerica As String = "0"

            Dim h As Integer

            For h = 1 To Facturas

                Dim consec As Integer = Table("select top 1 consecutivoElectronico as consecutivo from factura order by consecutivoElectronico desc", "").Rows(0).Item("consecutivo")
                consec = consec + 1

                Dim numConsecutivo As String = "0010000101" + consec.ToString("0000000000")
                Dim claveNumerica As String = "506" + Date.Today.ToString("ddMMyy") + CEDULA + numConsecutivo + "1" + "12345670"


                FGravado = 0
                FExento = 0
                Fdescuento = 0
                Fiv = 0

                Sql = "INSERT INTO FACTURA (id_cliente,clavenumerica,numconsecutivo,consecutivoelectronico, id_agente,fecha,plazo,clienteTributa,piv, id_usuario) values (" & _
                txtid_cliente.Text & "," & _
                "'" & claveNumerica & "'," & _
                "'" & numConsecutivo & "'," & _
                consec & "," & _
                cbid(cbid_agente.Text) & "," & _
                "getDate()," & _
                Val(txtplazo.Text).ToString & "," & _
                hacienda & "," + _
                PIV.ToString & "," & _
                id_usuario & ")"


                F = Table(Sql & " select @@IDENTITY as id_factura", "")

                FacturaID = F.Rows(0).Item("id_factura")
                FacturaClave = claveNumerica
                FacturaConsecutivo = numConsecutivo
                FS(h) = FacturaID
                FK(h) = facturaClave
                FC(h) = facturaConsecutivo

                LI = 28 * (h - 1)
                LS = IIf((LI + 27) >= TPD.Rows.Count, TPD.Rows.Count - 1, LI + 27)

                Dim z As Integer
                For z = LI To LS

                    With TPD.Rows(z)
                        Sql = "insert into Factura_detalle (id_factura,id_producto,cantidad,unidad,precio,descuento,iv) values (" & _
                        FacturaID & "," & _
                        "'" & .Item("id_producto") & "'," & _
                        .Item("cantidad").ToString & "," & _
                        .Item("unidad").ToString & "," & _
                        .Item("precio").ToString & "," & _
                        (.Item("descuento") / 100).ToString & "," & _
                        IIf(.Item("iv"), "1", "0") & ")"

                        cmd.CommandText = Sql
                        cmd.ExecuteNonQuery()

                        Sql = "update Producto set existencia=existencia-" + (IIf(.Item("unidad") = 1, .Item("cantidad"), .Item("cantidad") * .Item("empaque"))).ToString + _
                        " where id_Producto='" + .Item("id_producto") + "'"

                        cmd.CommandText = Sql
                        cmd.ExecuteNonQuery()
                    End With
                Next z

            Next h

        Catch ex As Exception
            ONEX(Me.Name, ex)
            Return False
        End Try

        Return True

    End Function


    Private Sub Facturas_imprimir(ByVal Doc As String, ByVal imprimir As Boolean)
        Try

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
            Dim Facturas As Integer = IIf(TPD.Rows.Count > 28, IIf(TPD.Rows.Count Mod 28 > 0, Int(TPD.Rows.Count / 28) + 1, TPD.Rows.Count / 28), 1)
            Dim h As Integer

            For h = 1 To Facturas
                'Facturas()
                V_Factura.Rows.Clear()

                FGravado = 0
                FExento = 0
                Fdescuento = 0
                Fiv = 0

                LI = 28 * (h - 1)
                LS = IIf((LI + 27) >= TPD.Rows.Count, TPD.Rows.Count - 1, LI + 27)

                Dim z As Integer
                For z = LI To LS

                    With TPD.Rows(z)

                        m = .Item("precio") * .Item("cantidad") * (1 - .Item("descuento") / 100)
                        d = .Item("precio") * .Item("cantidad") * (.Item("descuento") / 100)

                        .Item("precio") = .Item("precio") * (1 - .Item("descuento") / 100)

                        mf = m
                        If .Item("iv") Then
                            FGravado = FGravado + mf
                            Fiv = Fiv + (mf * PIV)
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

                rParameterFieldLocation = rParameterFieldDefinitions.Item("documento")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                If (Doc = "P") Then
                    rParameterDiscreteValue.Value = "PROFORMA"
                Else
                    If Consulta Then
                        rParameterDiscreteValue.Value = "ClaveNumerica: " + facturaClave + vbCrLf + "Consecutivo: " + facturaConsecutivo
                    Else
                        If Doc = "F" Then
                            rParameterDiscreteValue.Value = "ClaveNumerica: " + FK(h) + vbCrLf + "Consecutivo: " + FC(h)
                        Else
                            rParameterDiscreteValue.Value = ""
                        End If

                    End If
                End If

                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


                rParameterFieldLocation = rParameterFieldDefinitions.Item("tantos")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = h.ToString + "/" + Facturas.ToString
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

                rParameterFieldLocation = rParameterFieldDefinitions.Item("descuento")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = FormatNumber(Fdescuento, 2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("Total")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "₡ " + FormatNumber(FGravado + Fiv + FExento, 2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("facturaid")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                If Consulta Then
                    rParameterDiscreteValue.Value = FacturaID

                Else
                    If Doc = "F" Then
                        rParameterDiscreteValue.Value = FS(h)
                    Else
                        rParameterDiscreteValue.Value = ""
                    End If

                End If


                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("usuario_nombre")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = USUARIO_NOMBRE
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("totalg")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = IIf(h = Facturas, "TOTAL GENERAL  ₡" + FormatNumber(total, 2), "")
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("men1")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = IIf(Consulta, "", M1)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("men2")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = IIf(Consulta, "", M2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("men3")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = IIf(Consulta, "", M3)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                'Dim rv As New frm_Report_Viewer
                'rv.crv.ReportSource = rfactura
                'rv.Show()

                If imprimir Then

                    If Produccion Then

                        Dim printed As Boolean = False
                        While Equals(printed, False)
                            Try
                                If ID_ESTACION = 1 Then
                                    If Doc = "P" Then
                                        rfactura.PrintOptions.PrinterName = "REPORTES"
                                    Else
                                        rfactura.PrintOptions.PrinterName = "FACTURAS"
                                    End If
                                Else
                                    If Doc = "P" Then
                                        rfactura.PrintOptions.PrinterName = "\\" + PRINTER + "\REPORTES"
                                    Else
                                        rfactura.PrintOptions.PrinterName = "\\" + PRINTER + "\FACTURAS"
                                    End If
                                End If

                                ' impresion 

                                rfactura.PrintToPrinter(1, False, 1, 1)
                                printed = True
                            Catch ex As Exception
                                Dim response As MsgBoxResult = MsgBox("La impresion fallo. Desea intentarlo nuevamente?", MsgBoxStyle.YesNo, "Fallo en la impresion")
                                If response = MsgBoxResult.No Then
                                    printed = True
                                End If
                            End Try
                        End While

                    Else
                        Dim rv As New frm_Report_Viewer
                        rv.crv.ReportSource = rfactura
                        rv.Show()

                    End If

                Else

                    Dim filePath As String = getSaveLocation()
                    If filePath <> "" Then
                        rfactura.ExportToDisk(ExportFormatType.PortableDocFormat, filePath)
                        rfactura.Dispose()
                        rfactura.Close()
                    End If


                End If

            Next h
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try


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

        'V_Factura.PrimaryKey = New DataColumn() {V_Factura.Columns("id_producto")}



        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        ' End Try

    End Sub


    Private Sub btcambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncambios.Click
        If USUARIO_NIVEL = 1 Then
            MsgBox("Este usuario tiene restringida esta opcion")
            Exit Sub
        End If
        Dim cambio As New frm_Cambio
        myForms.frm_cambio = cambio
        myForms.frm_cambio.Owner = Me
        cambio.Show()
        cambio.lblcliente_nombre.Text = txtid_cliente.Text + "-" + lblcliente_nombre.Text
        cambio.lblid_Pedido.Text = cbid_pedido.Text
    End Sub

    Private Sub btnproformar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnproformar.Click
        Alistar = ""
        Guardar(True)
        Tsort(TPD, "nombre")
        Facturas_imprimir("P", True)
        Me.Close()
    End Sub

    Private Sub txtplazo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtplazo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtplazo.Text, False)
        End If


    End Sub


    Private Sub btndescpp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndescpp.Click
        Dim descuento As New frm_Pedido_descproductop
        With descuento
            .Owner = Me
            .Show()
            If dtgpedido.SelectedRows.Count = 1 Then
                .lblid_producto.Text = dtgpedido.Item("id_producto", dtgpedido.CurrentRow.Index).Value
                .lblnombre_producto.Text = dtgpedido.Item("nombre", dtgpedido.CurrentRow.Index).Value
            ElseIf dtgpedido.SelectedRows.Count = 0 Then
                Exit Sub
            Else
                .lblnombre_producto.Text = "Productos Seleccionados: " & dtgpedido.SelectedRows.Count
            End If
        End With
    End Sub

    Private Sub btndescgeneralp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndescgeneralp.Click
        Dim descgen As New frm_pedido_descgeneralp
        descgen.Owner = myForms.frm_principal
        descgen.Show()
    End Sub

    Private Sub dtgpedido_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgpedido.CellContentClick

    End Sub

    Private Sub dtgpedido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgpedido.KeyDown
        ' If USUAR Then
        'Else
        If cbid_pedido.Text <> "Nuevo" And Alistar <> "" Then
            Exit Sub
        End If
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
                '.cbunidad.Items.Add("Und")
                '.cbunidad.Items.Add(Prst(row("unidad")))
                .cbunidad.SelectedIndex = IIf(row("unidad") > 1, 1, 0)
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



    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Facturas_imprimir("F", True)
    End Sub

    Private Sub btnproformarweb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnproformarweb.Click
        Alistar = ""
        Guardar(True)
        Tsort(TPD, "nombre")
        Facturas_imprimir("P", False)
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
End Class