Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_reportes_admin
    Dim S As String
    Dim ExistenciaProveedor As Boolean
    Dim Criterio As String
    Dim criterionc As String
    Public Linea As DataTable
    Public Proveedor As DataTable
    Public Cliente As DataTable

    Dim rowc As DataRow
    Dim rowprv As DataRow
    Dim rowfm As DataRow


    Public ds As New DataSet
    Dim bodega As DataTable
    Dim LP As DataTable
    Dim producto As DataTable
    Dim V_LPD As DataTable
    Dim V_venta_neta As DataTable
    Dim V_Bodega_Existencia As DataTable

    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues


    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'Try
        btnaceptar.Enabled = False
        Select Case S
            Case "rbagente"
                Dim agente As DataTable
                Dim ragente As New rpt_agente
                agente = Table("select * from agente where eliminado=0 order by nombre", "")
                ragente.SetDataSource(agente)
                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = ragente
                rv.Text = "Agentes"
                rv.Show()
            Case "rbcliente"
                Dim cliente As DataTable
                Dim rcliente As New rpt_cliente
                cliente = Table("select * from cliente where eliminado=0 order by id_cliente", "")
                rcliente.SetDataSource(cliente)
                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rcliente
                rv.Text = "Clientes"
                rv.Show()
            Case "rbproveedor"
                Dim proveedor As DataTable
                Dim rproveedor As New rpt_proveedor
                proveedor = Table("select * from proveedor  order by nombre", "")
                rproveedor.SetDataSource(proveedor)
                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rproveedor
                rv.Text = "Proveedores"
                rv.Show()
            
            Case "rbexistencia"
                Dim Producto As DataTable
                Dim rProducto As New rpt_Existencia

                If Not ExistenciaProveedor Then

                    If cbubicacion.Text = "Todos" Then
                        Criterio = ""
                    ElseIf Val(cbubicacion.Text) < 10 Then
                        Criterio = "where id_b_r=" + cbubicacion.Text
                    ElseIf Val(cbubicacion.Text) < 40 Then
                        Criterio = "where id_pasillo=" + cbubicacion.Text
                    Else
                        Criterio = "where id_b_r=" + cbubicacion.Text
                    End If

                Else
                    If cbProveedor.Text = "Todos" Then
                        Criterio = ""
                    Else
                        Criterio = " where id_proveedor = " + cbid(cbProveedor.Text)
                    End If
                End If

                Producto = Table("select * from Producto " + Criterio + " order by nombre", "")

                Dim existencia_p As DataColumn = New DataColumn("existencia_p")
                existencia_p.DataType = System.Type.GetType("System.Int32")
                Producto.Columns.Add(existencia_p)

                Dim existencia_u As DataColumn = New DataColumn("existencia_u")
                existencia_u.DataType = System.Type.GetType("System.Int32")
                Producto.Columns.Add(existencia_u)

                Dim presentacion_nombre As DataColumn = New DataColumn("presentacion_nombre")
                presentacion_nombre.DataType = System.Type.GetType("System.String")
                Producto.Columns.Add(presentacion_nombre)

                Dim montocolumna As DataColumn = New DataColumn("monto")
                montocolumna.DataType = System.Type.GetType("System.Decimal")
                Producto.Columns.Add(montocolumna)

                Dim ivcolumna As DataColumn = New DataColumn("iv")
                ivcolumna.DataType = System.Type.GetType("System.String")
                Producto.Columns.Add(ivcolumna)

                Dim total As Integer = 0
                Dim monto As Decimal = 0
                Dim iv As Decimal = 1.13
                Dim exento As Decimal = 0
                Dim gravado As Decimal = 0
                Dim impuesto As Decimal = 0
                Dim mon As String
                Dim montounitario As Decimal
                Dim tot As String
                Dim i As Integer
                For i = 0 To Producto.Rows.Count - 1

                    montounitario = (Producto.Rows(i).Item("existencia") * (Producto.Rows(i).Item("costo") / Producto.Rows(i).Item("empaque")))

                    If Producto.Rows(i).Item("IV") = True Then
                        Producto.Rows(i).Item("iv") = "*"
                        gravado = gravado + montounitario
                        iv = 1.13
                    Else
                        Producto.Rows(i).Item("iv") = ""
                        exento = exento + montounitario
                        iv = 1
                    End If

                    total = total + Producto.Rows(i).Item("existencia")
                    impuesto = gravado * 0.13
                    monto = gravado + exento + impuesto

                    Producto.Rows(i).Item("monto") = montounitario * iv

                Next
                tot = FormatNumber(total, 0)
                mon = FormatNumber(monto, 2)

                Dim z As Integer
                For z = 0 To Producto.Rows.Count - 1
                    With Producto.Rows(z)
                        .Item(existencia_p) = Int(.Item("existencia") / .Item("empaque"))
                        .Item(existencia_u) = .Item("existencia") Mod .Item("empaque")
                        If .Item("presentacion") = 1 Then
                            .Item("presentacion_nombre") = "Und"
                        ElseIf .Item("presentacion") = 2 Then
                            .Item("presentacion_nombre") = "Caj"
                        ElseIf .Item("presentacion") = 3 Then
                            .Item("presentacion_nombre") = "Blt"
                        Else
                            .Item("presentacion_nombre") = "Pqt"
                        End If
                    End With
                Next


                rProducto.SetDataSource(Producto)


                rParameterFieldDefinitions = rProducto.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("ubicacion")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                Dim U As String
                If Not ExistenciaProveedor Then
                    If cbubicacion.Text = "Todos" Then
                        U = "Todos"
                    ElseIf cbubicacion.Text < 10 Then
                        U = "Bodega "
                    ElseIf cbubicacion.Text < 40 Then
                        U = "Pasillo "
                    Else
                        U = "Rack "
                    End If
                    U = U + cbubicacion.Text
                Else
                    U = "Proveedor " + cbProveedor.Text
                End If

                rParameterDiscreteValue.Value = U
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("existencia")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = tot
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("monto")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = FormatNumber(mon, 2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("gravado")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = FormatNumber(gravado, 2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("exento")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = FormatNumber(exento, 2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("impuesto")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = FormatNumber(impuesto, 2)
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rProducto
                rv.Text = "Existencias"
                rv.Show()

            Case "rbfactura"
                Dim factura As DataTable
                Dim rfactura As New rpt_facturas
                Criterio = " factura.fecha>='" + EDATE(dtpdesde.Text) + " 00:00:00' and factura.fecha<='" + EDATE(dtphasta.Text) + " 23:59:29'"
                factura = FACM(Criterio, True, "")


                rfactura.SetDataSource(factura)

                rParameterFieldDefinitions = rfactura.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Del " + dtpdesde.Text + " al " + dtphasta.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rfactura
                rv.Text = "Facturas"
                rv.Show()

            Case "rbrecibo"
                Dim recibo As DataTable
                Dim rrecibo As New rpt_recibos
                Criterio = "recibo.fecha>='" + EDATE(dtpdesde.Text) + "' and recibo.fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"
                Criterio = Criterio + IIf(cbforma_pago.SelectedIndex = 0, "", " and recibo.forma_pago = " + cbforma_pago.SelectedIndex.ToString + " ")
                recibo = RECM(Criterio, True, "")
                rrecibo.SetDataSource(recibo)

                rParameterFieldDefinitions = rrecibo.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Del " + dtpdesde.Text + " al " + dtphasta.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


                rParameterFieldLocation = rParameterFieldDefinitions.Item("negocio")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = NEGOCIO
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rrecibo
                rv.Text = "Recibos"
                rv.Show()



            Case "rbbodega_ajuste"

                Dim rbodega_ajuste As New rpt_bodega_ajuste
                Criterio = "where fecha>='" + EDATE(dtpdesde.Text) + "' and fecha<='" + EDATE(dtphasta.Text) + "'"
                Dim V_Bodega_ajuste As DataTable
                V_Bodega_ajuste = Table("select * from C_Bodega_ajuste " + Criterio + " order by fecha,id_producto", "")

                Dim Nombre As DataColumn = New DataColumn("Nombre")
                Nombre.DataType = System.Type.GetType("System.String")
                V_Bodega_ajuste.Columns.Add(Nombre)

                Dim presentacion As DataColumn = New DataColumn("presentacion")
                presentacion.DataType = System.Type.GetType("System.String")
                V_Bodega_ajuste.Columns.Add(presentacion)

                producto = Table("select * from producto  order by id", "id")
                Dim z As Integer
                Dim rowp As DataRow
                For z = 0 To V_Bodega_ajuste.Rows.Count - 1
                    With V_Bodega_ajuste.Rows(z)
                        rowp = producto.Rows.Find(.Item("id_producto").ToString)
                        .Item("nombre") = rowp("nombre")
                        .Item("presentacion") = rowp("presentacion")
                    End With
                Next


                rbodega_ajuste.SetDataSource(V_Bodega_ajuste)

                rParameterFieldDefinitions = rbodega_ajuste.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Del " + dtpdesde.Text + " al " + dtphasta.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)
                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rbodega_ajuste
                rv.Text = "Bodega Ajustes"
                rv.Show()

            Case "rbdevolucion"
                Dim devolucion As DataTable
                Dim rdevolucion As New rpt_devoluciones
                Criterio = "fecha>='" + EDATE(dtpdesde.Text) + " 00:00:00' and fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"
                Dim cliente As DataTable = Table("select id_cliente,nombre from cliente", "id_cliente")
                devolucion = DEVM(Criterio, True, "")


                Dim nombre_sociedad As DataColumn = New DataColumn("nombre_sociedad")
                nombre_sociedad.DataType = System.Type.GetType("System.String")
                devolucion.Columns.Add(nombre_sociedad)
                Dim z As Integer
                Dim rowc As DataRow
                For z = 0 To devolucion.Rows.Count - 1
                    With devolucion.Rows(z)
                        rowc = cliente.Rows.Find(.Item("id_cliente"))
                        .Item("nombre_sociedad") = rowc("nombre")
                    End With
                Next

                rdevolucion.SetDataSource(devolucion)

                rParameterFieldDefinitions = rdevolucion.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Del " + dtpdesde.Text + " al " + dtphasta.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("NEGOCIO")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Comercial Pozos"
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rdevolucion
                rv.Text = "Devoluciones"
                rv.Show()

            Case "rbfaltante"
                Dim v_Faltante As DataTable
                Dim rfaltante As New rpt_Faltante
                Criterio = "where fecha>='" + EDATE(dtpdesde.Text) + "' and fecha<='" + EDATE(dtphasta.Text) + "'"
                v_Faltante = Table("select * from faltante " + Criterio, "")

                Dim nombre As DataColumn = New DataColumn("nombre")
                nombre.DataType = System.Type.GetType("System.String")
                v_Faltante.Columns.Add(nombre)

                Dim presentacion As DataColumn = New DataColumn("presentacion")
                presentacion.DataType = System.Type.GetType("System.Int16")
                v_Faltante.Columns.Add(presentacion)

                Dim presentacion_nombre As DataColumn = New DataColumn("presentacion_nombre")
                presentacion_nombre.DataType = System.Type.GetType("System.String")
                v_Faltante.Columns.Add(presentacion_nombre)

                Dim cantidad_p As DataColumn = New DataColumn("cantidad_p")
                cantidad_p.DataType = System.Type.GetType("System.Decimal")
                v_Faltante.Columns.Add(cantidad_p)

                Dim cantidad_u As DataColumn = New DataColumn("cantidad_u")
                cantidad_u.DataType = System.Type.GetType("System.Decimal")
                v_Faltante.Columns.Add(cantidad_u)

                'Dim id_cliente As DataColumn = New DataColumn("id_cliente")
                'cantidad_u.DataType = System.Type.GetType("System.Int32")
                'v_Faltante.Columns.Add(id_cliente)

                Dim z As Integer
                Dim rowp As DataRow
                For z = 0 To v_Faltante.Rows.Count - 1
                    With v_Faltante.Rows(z)
                        rowp = producto.Rows.Find(.Item("id_producto"))
                        If Not rowp Is Nothing Then
                            .Item("nombre") = rowp("nombre")
                            .Item("presentacion") = rowp("presentacion")

                            If rowp("presentacion") = 1 Then
                                .Item("presentacion_nombre") = "Und"
                            ElseIf rowp("presentacion") = 2 Then
                                .Item("presentacion_nombre") = "Caj"
                            ElseIf rowp("presentacion") = 3 Then
                                .Item("presentacion_nombre") = "Blt"
                            Else
                                .Item("presentacion_nombre") = "Pqt"
                            End If

                            .Item("cantidad_p") = Int(.Item("cantidad") / rowp("empaque"))
                            .Item(cantidad_u) = .Item("cantidad") Mod rowp("empaque")
                            '.Item("id_cliente") = rowp("id_cliente")
                        End If
                    End With
                Next

                rfaltante.SetDataSource(v_Faltante)

                rParameterFieldDefinitions = rfaltante.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Del " + dtpdesde.Text + " al " + dtphasta.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rfaltante
                rv.Text = "Faltantes"
                rv.Show()

            Case "rblista_precios"
                Dim LP As DataTable
                Dim rlista_precios As New rpt_Lista_Precios

                Dim Prt As DataTable = Table("select * from parametro", "")


                LP = Table("select * from Producto order by nombre", "")

                Dim precio As DataColumn = New DataColumn("precio")
                precio.DataType = System.Type.GetType("System.Decimal")
                LP.Columns.Add(precio)

                Dim consumidor As DataColumn = New DataColumn("consumidor")
                consumidor.DataType = System.Type.GetType("System.Decimal")
                LP.Columns.Add(consumidor)


                Dim presentacion_nombre As DataColumn = New DataColumn("presentacion_nombre")
                presentacion_nombre.DataType = System.Type.GetType("System.String")
                LP.Columns.Add(presentacion_nombre)

                Dim Util As String = "Utilidad_" + cblp_precio.Text
                Dim z As Integer
                For z = 0 To LP.Rows.Count - 1
                    With LP.Rows(z)
                        .Item(precio) = .Item("costo") * (1 + .Item(Util)) / .Item("EMPAQUE")
                        .Item("consumidor") = .Item("precio") * (1 + .Item("detalle")) * (1 + IIf(.Item("iv"), Prt.Rows(0).Item("iv"), 0)) / .Item("sub_empaque")
                        If .Item("presentacion") = 1 Then
                            .Item("presentacion_nombre") = "Und"
                        ElseIf .Item("presentacion") = 2 Then
                            .Item("presentacion_nombre") = "Caj"
                        ElseIf .Item("presentacion") = 3 Then
                            .Item("presentacion_nombre") = "Blt"
                        Else
                            .Item("presentacion_nombre") = "Pqt"
                        End If
                    End With
                Next


                rlista_precios.SetDataSource(LP)
                rParameterFieldDefinitions = rlista_precios.DataDefinition.ParameterFields


                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rlista_precios
                rv.Text = "Lista de Precios"
                rv.Show()


            Case "rbpedido"
                Dim Pedido As DataTable
                Dim rPedido As New rpt_Pedido
                Dim cliente As DataTable = Table("select id_cliente,nombre from cliente", "id_cliente")
                Dim usuario As DataTable = Table("select id_usuario,nombre from usuario", "id_usuario")
                Criterio = "where fecha>='" + EDATE(dtpdesde.Text) + "' and fecha<='" + EDATE(dtphasta.Text) + "'"
                Pedido = PM(Criterio)

                Dim cliente_nombre As DataColumn = New DataColumn("cliente")
                cliente_nombre.DataType = System.Type.GetType("System.String")
                Pedido.Columns.Add(cliente_nombre)


                Dim usuario_nombre As DataColumn = New DataColumn("usuario_nombre")
                usuario_nombre.DataType = System.Type.GetType("System.String")
                Pedido.Columns.Add(usuario_nombre)

                Dim z As Integer
                Dim rowu As DataRow
                Dim rowc As DataRow
                For z = 0 To Pedido.Rows.Count - 1
                    With Pedido.Rows(z)
                        rowc = cliente.Rows.Find(.Item("id_cliente"))
                        .Item("cliente") = rowc("id_cliente").ToString + "-" + rowc("nombre")
                        rowu = usuario.Rows.Find(.Item("id_usuario"))
                        .Item("usuario_nombre") = rowu("nombre")
                    End With
                Next

                rPedido.SetDataSource(Pedido)

                rParameterFieldDefinitions = rPedido.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Del " + dtpdesde.Text + " al " + dtphasta.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rPedido
                rv.Text = "Pedidos"
                rv.Show()






            Case "rbnc"
                Dim rnc As New rpt_notas_credito
                Criterio = " nota_credito.fecha>='" + EDATE(dtpdesde.Text) + "' and nota_credito.fecha<='" + EDATE(dtphasta.Text) + "'"
                Dim nc As DataTable = NCM(Criterio, True, "")

                rnc.SetDataSource(nc)

                rParameterFieldDefinitions = rnc.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Del " + dtpdesde.Text + " al " + dtphasta.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



                rParameterFieldLocation = rParameterFieldDefinitions.Item("negocio")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = NEGOCIO
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rnc
                rv.Text = "Notas de Crédito"
                rv.Show()
            Case "rbnca"
                Dim rnca As New rpt_nota_credito_aplicaciones
                Criterio = " fecha>='" + EDATE(dtpdesde.Text) + "' and fecha<='" + EDATE(dtphasta.Text) + "'"
                Dim nc As DataTable = Table("select * from nota_credito_detalle where " + Criterio, "")

                rnca.SetDataSource(nc)

                rParameterFieldDefinitions = rnca.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Del " + dtpdesde.Text + " al " + dtphasta.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



                rParameterFieldLocation = rParameterFieldDefinitions.Item("negocio")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = NEGOCIO
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rnca
                rv.Text = "Notas de Crédito Aplicaciones"
                rv.Show()




            Case "rbventa_resumido"


                Dim Fecha As String = ""
                Dim ClienteId As String

                ClienteId = "General"
                Criterio = "fecha>='" + EDATE(dtpdesde.Text) + " 00:00:00' and fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"
                criterionc = "fecha>='" + EDATE(dtpdesde.Text) + " 00:00:00' and fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"



                Dim rventa_neta As New rpt_venta_neta

                V_Venta_Neta_crear()
                rventa_neta.SetDataSource(V_venta_neta)

                rParameterFieldDefinitions = rventa_neta.DataDefinition.ParameterFields

                rParameterFieldLocation = rParameterFieldDefinitions.Item("rango")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = "Del " + dtpdesde.Text + " al " + dtphasta.Text
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                rParameterFieldLocation = rParameterFieldDefinitions.Item("id_cliente")
                rParameterValues = rParameterFieldLocation.CurrentValues
                rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                rParameterDiscreteValue.Value = ClienteId
                rParameterValues.Add(rParameterDiscreteValue)
                rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

                'rParameterFieldLocation = rParameterFieldDefinitions.Item("negocio")
                'rParameterValues = rParameterFieldLocation.CurrentValues
                'rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                'rParameterDiscreteValue.Value = NEGOCIO
                'rParameterValues.Add(rParameterDiscreteValue)
                'rParameterFieldLocation.ApplyCurrentValues(rParameterValues)




                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rventa_neta
                rv.Text = "Ventas Netas"
                rv.Show()

            Case "rbgrafico"
                Dim rgrafico As New rpt_grafico

                Criterio = "fecha>='" + EDATE(dtpdesde.Text) + " 00:00:00' and fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"

                V_Venta_Neta_crear()
                rgrafico.SetDataSource(V_venta_neta)

                'rParameterFieldDefinitions = rgrafico.DataDefinition.ParameterFields



                Dim rv As New frm_Report_Viewer
                rv.crv.ReportSource = rgrafico
                rv.Text = "Gráfico"
                rv.Show()

        End Select
        btnaceptar.Enabled = True
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub frm_reportes_admin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            CONN1.Close()
            myForms.frm_principal.ToolStrip.Enabled = True
        Catch myerror As SqlException
            MsgBox(myerror.Message)
        End Try
    End Sub

    Private Sub frm_reportes_admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            OpenConn()
            CB_crear_NoEliminado(cbProveedor, "Proveedor", "id_proveedor")
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub Ocultar()
        cbubicacion.Visible = False
        cblp_precio.Visible = False
        cbProveedor.Visible = False
        checkProveedor.Visible = False
        cbforma_pago.Visible = False
    End Sub

    Public Function PM(ByVal C As String) As DataTable
        'Try
        Dim P As DataTable
        Dim PD As DataTable
        Dim PRT As DataTable = Table("select * from parametro", "")

        Dim PTgravado As Decimal
        Dim PTexento As Decimal
        Dim PTiv As Decimal
        Dim PTdescuento As Decimal

        Dim PEX As Decimal
        Dim PGA As Decimal
        Dim PIV As Decimal

        Dim m As Decimal
        Dim mf As Decimal

        Dim i As Integer


        P = Table("select * from pedido " + C, "")


        Dim Monto As DataColumn = New DataColumn("Monto")
        Monto.DataType = System.Type.GetType("System.Decimal")
        Monto.DefaultValue = 0
        P.Columns.Add(Monto)


        For i = 0 To P.Rows.Count - 1
            With P.Rows(i)
                PTgravado = 0.0
                PTexento = 0.0
                PTiv = 0.0
                PTdescuento = 0.0
                PEX = 0
                PGA = 0
                PIV = 0

                PD = Table("select * from pedido_detalle where id_pedido=" + .Item("id_pedido").ToString + " order by id_pedido", "")

                Dim j As Integer
                For j = 0 To PD.Rows.Count - 1
                    With PD.Rows(j)
                        m = .Item("precio") * .Item("cantidad")
                        'd = m * (.Item("descuento"))
                        mf = m
                        If .Item("iv") Then
                            PTgravado = PTgravado + mf
                            PTiv = PTiv + mf * PRT.Rows(0).Item("IV")

                            PGA = PGA + mf
                            PIV = PIV + mf * PRT.Rows(0).Item("IV")
                        Else
                            PTexento = PTexento + mf
                            PEX = PEX + mf
                        End If
                        'FTdescuento = FTdescuento + d
                    End With
                Next j
                .Item("Monto") = PTexento + PTgravado + PTiv
            End With
        Next i

        Return P
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Function

    Private Sub rbventa_resumido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbventa_resumido.CheckedChanged

    End Sub

    Private Sub rbventa_resumido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbventa_resumido.Click
        If rbventa_resumido.Checked Then S = "rbventa_resumido"
        Ocultar()
    End Sub

    Private Sub rbagente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbagente.CheckedChanged

    End Sub

    Private Sub rbagente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbagente.Click
        If rbagente.Checked Then S = "rbagente"
        Ocultar()
    End Sub

    Private Sub rbcliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbcliente.Click
        If rbcliente.Checked Then S = "rbcliente"
        Ocultar()
    End Sub

    Private Sub rbproveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbproveedor.Click
        If rbproveedor.Checked Then S = "rbproveedor"
        Ocultar()
    End Sub

    Private Sub rblinea_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblinea.CheckedChanged

    End Sub

    Private Sub rblinea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblinea.Click
        If rbproveedor.Checked Then S = "rbproveedor"
        Ocultar()
    End Sub

    Private Sub rbfactura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbfactura.Click
        If rbfactura.Checked Then S = "rbfactura"
        Cliente = Table("select * from cliente where eliminado=0", "id_cliente")
        Ocultar()
    End Sub

    Private Sub rbrecibo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbrecibo.Click
        If rbrecibo.Checked Then S = "rbrecibo"
        Cliente = Table("select * from cliente where eliminado=0", "id")
        Ocultar()
        If USUARIO_NIVEL <> 3 Then
            cbforma_pago.Visible = False
            cbforma_pago.SelectedIndex = 0

        Else
            cbforma_pago.SelectedIndex = 0
            cbforma_pago.Visible = True
        End If
    End Sub

    Private Sub rbdevolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdevolucion.Click
        If rbdevolucion.Checked Then S = "rbdevolucion"
        Cliente = Table("select * from cliente where eliminado=0", "id")
        Ocultar()
    End Sub

   

    Private Sub rbproducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbproducto.Click
        Try
            Ocultar()
            If rbproducto.Checked Then
                S = "rbproducto"
                Dim rpt_producto_opciones As New frm_rpt_producto_opciones
                myForms.frm_rpt_producto_opciones = frm_rpt_producto_opciones
                myForms.frm_rpt_producto_opciones.Owner = Me
                frm_rpt_producto_opciones.Show()
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub rbexistencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbexistencia.Click
        Ocultar()
        If rbexistencia.Checked Then
            S = "rbexistencia"
            cbubicacion.Visible = True
            cbubicacion.SelectedIndex = 0
            cbProveedor.Visible = True
            cbProveedor.SelectedIndex = 0
            checkProveedor.Visible = True
        End If
    End Sub

    Private Sub Rbfaltante_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbfaltante.Click
        If Rbfaltante.Checked Then
            S = "rbfaltante"
            producto = Table("select id_producto,nombre,presentacion,empaque from Producto", "id_producto")
        End If
        Ocultar()
    End Sub

    Private Sub Rblista_precios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rblista_precios.Click
        Ocultar()
        If Rblista_precios.Checked Then
            S = "rblista_precios"
            cblp_precio.Visible = True
            cblp_precio.SelectedIndex = 0
        End If
    End Sub

    Private Sub Rbpedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbpedido.Click
        If Rbpedido.Checked Then S = "rbpedido"
        Ocultar()
    End Sub

    Private Sub rbventa_producto_cliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbventa_producto_cliente.Click
        Try
            Ocultar()
            If rbventa_producto_cliente.Checked Then
                Dim rpt_venta_producto_cliente_opciones As New frm_rpt_venta_producto_cliente_opciones
                myForms.frm_rpt_venta_producto_cliente_opciones = frm_rpt_venta_producto_cliente_opciones
                myForms.frm_rpt_venta_producto_cliente_opciones.Owner = Me
                frm_rpt_venta_producto_cliente_opciones.Show()
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub Rbventa_cliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbventa_cliente.Click
        Try
            Ocultar()
            If Rbventa_cliente.Checked Then
                Dim rpt_venta_cliente_opciones As New frm_rpt_venta_cliente_opciones
                myForms.frm_rpt_venta_producto_cliente_opciones = frm_rpt_venta_producto_cliente_opciones
                myForms.frm_rpt_venta_producto_cliente_opciones.Owner = Me
                frm_rpt_venta_cliente_opciones.Show()
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub Rbventa_producto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbventa_producto.Click
        Try
            Ocultar()
            If Rbventa_producto.Checked Then
                Dim rpt_venta_producto_opciones As New frm_rpt_venta_producto_opciones
                myForms.frm_rpt_venta_producto_opciones = frm_rpt_venta_producto_opciones
                myForms.frm_rpt_venta_producto_opciones.Owner = Me
                frm_rpt_venta_producto_opciones.Show()
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub V_Venta_Neta_crear()
        '  Try
        V_venta_neta = Table("select  * from V_venta_neta", "")
        Dim Fac As DataTable
        Fac = FACM(Criterio, False, "")
        Dim rowv As DataRow
        Dim z As Integer
        For z = 0 To Fac.Rows.Count - 1
            With Fac.Rows(z)
                rowv = V_venta_neta.NewRow
                rowv("id_documento") = .Item("id_factura")
                rowv("tipo") = 1
                rowv("fecha") = .Item("fecha")
                rowv("exento") = .Item("exento")
                rowv("gravado") = .Item("gravado")
                rowv("iv") = .Item("iv")
                rowv("monto") = .Item("monto")
                V_venta_neta.Rows.Add(rowv)
            End With
        Next

        Dim nc As DataTable
        nc = NCM(Criterionc, False, "")
        Dim rownc As DataRow
        For z = 0 To nc.Rows.Count - 1
            With nc.Rows(z)
                rownc = V_venta_neta.NewRow
                rownc("tipo") = 5
                rownc("id_documento") = .Item("id_nota_credito")
                rownc("fecha") = .Item("fecha")
                rownc("exento") = .Item("exento") * -1
                rownc("gravado") = .Item("gravado") * -1
                rownc("iv") = .Item("iv") * -1
                rownc("monto") = .Item("monto") * -1
                V_venta_neta.Rows.Add(rownc)
            End With
        Next

        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try

    End Sub

    Private Sub Rbgrafico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbgrafico.CheckedChanged

    End Sub

    Private Sub Rbgrafico_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rbgrafico.Click
        If Rbgrafico.Checked Then S = "rbgrafico"
        Ocultar()
    End Sub

    Private Sub rbnc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnc.CheckedChanged

    End Sub

    Private Sub rbnc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbnc.Click
        If rbnc.Checked Then S = "rbnc"
        Ocultar()
    End Sub

    Private Sub rbnca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnca.CheckedChanged

    End Sub

    Private Sub rbnca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbnca.Click
        If rbnca.Checked Then S = "rbnca"
        Ocultar()
    End Sub

    Private Sub rbventaNeta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbventaNeta.CheckedChanged
        Try
            Ocultar()
            If rbventaNeta.Checked Then
                S = "rbneta"
                Dim rpt_producto_opciones As New frm_rpt_venta_neta_cliente_opciones
                myForms.frm_rpt_venta_neta_cliente_opciones = rpt_producto_opciones
                myForms.frm_rpt_venta_neta_cliente_opciones.Owner = Me
                rpt_producto_opciones.Show()
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub checkProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkProveedor.CheckedChanged
        If checkProveedor.Checked Then
            cbubicacion.Enabled = False
            cbProveedor.Enabled = True
            ExistenciaProveedor = True
        Else
            cbubicacion.Enabled = True
            cbProveedor.Enabled = False
            ExistenciaProveedor = False
        End If
    End Sub
End Class