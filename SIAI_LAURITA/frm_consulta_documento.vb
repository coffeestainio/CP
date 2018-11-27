Public Class frm_consulta_documento
    Dim Documento As DataTable
    Dim Dvdocumento As DataView
    Dim TPD As DataTable
    Dim TDD As DataTable
    Dim criterio As String
    Dim tipo As String
    Dim Building As Boolean
    Dim rowc As DataRow
    Dim FIV As Decimal

    Dim cliente As DataTable
    Dim Agente As DataTable
    Dim Bodega As DataTable

    Private Sub frm_consulta_documento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CONN1.Close()
        myForms.frm_principal.ToolStrip.Enabled = True
    End Sub
    Private Sub frm_consulta_documento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        OpenConn()
        Building = True
        cbtipo.SelectedIndex = 0
        cliente = Table("select * from cliente", "id_cliente")
        Agente = Table("select id_agente,nombre from agente", "id_agente")
        Documento_crear()
        Building = False
        Filtro()
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub
    Private Sub Filtro()
        ' Try

        Select Case cbtipo.SelectedIndex

            Case 0
                If Val(txtid_documento.Text) > 0 Then
                    criterio = " factura.id_factura = " + txtid_documento.Text
                Else
                    criterio = " factura.fecha>='" + EDATE(dtpdesde.Text) + "' and factura.fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"
                    If Val(txtid_cliente.Text) > 0 Then criterio = criterio + " and factura.id_cliente=" + txtid_cliente.Text
                End If
                Dim Factura As DataTable
                Factura = FACM(criterio, True, "")
                Documento_cargar(Factura, 1)
            Case 1
                If Val(txtid_documento.Text) > 0 Then
                    criterio = "recibo.id_recibo = " + txtid_documento.Text
                Else
                    criterio = "fecha>='" + EDATE(dtpdesde.Text) + "' and fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"
                    If Val(txtid_cliente.Text) > 0 Then criterio = criterio + " and id_cliente=" + txtid_cliente.Text
                End If
                Dim Recibo As DataTable
                Recibo = RECM(criterio, True, "")
                Documento_cargar(Recibo, 3)

            Case 2
                If Val(txtid_documento.Text) > 0 Then
                    criterio = "id_devolucion = " + txtid_documento.Text
                Else
                    criterio = "fecha>='" + EDATE(dtpdesde.Text) + "' and fecha<='" + EDATE(dtphasta.Text) + "'"
                    If Val(txtid_cliente.Text) > 0 Then criterio = criterio + " and cliente.id_cliente=" + txtid_cliente.Text
                End If
                Dim devolucion As DataTable
                devolucion = DEVM(criterio, True, "")
                Documento_cargar(devolucion, 7)
            Case 3
                If Val(txtid_documento.Text) > 0 Then
                    criterio = "id_nota_credito = " + txtid_documento.Text
                Else
                    criterio = "fecha>='" + EDATE(dtpdesde.Text) + "' and fecha<='" + EDATE(dtphasta.Text) + "'"
                    If Val(txtid_cliente.Text) > 0 Then criterio = criterio + " and cliente.id_cliente=" + txtid_cliente.Text
                End If
                Dim NC As DataTable
                NC = NCM(criterio, True, "")
                Documento_cargar(NC, 5)
        End Select
        Dvdocumento = New DataView(Documento)
        Dvdocumento.Sort = "fecha, id_documento"
        dtgdocumento.DataSource = Dvdocumento
        'Catch myerror As Exception
        '(Me.Name, myerror)
        ' End Try
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
                BUSQUEDA = "Consulta_Documento"
                Dim cliente_buscar As New frm_cliente_buscar
                cliente_buscar.Owner = Me
                cliente_buscar.Show()
                cliente_buscar.txtbuscar_cliente.Text = e.KeyChar
            Else

                e.Handled = Numerico(Asc(e.KeyChar), txtid_cliente.Text, False)
            End If
        End If
    End Sub

    Private Sub txtid_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_cliente.TextChanged

    End Sub

    Public Sub Identifica_cliente()
        Try
            rowc = cliente.Rows.Find(txtid_cliente.Text)
            If rowc Is Nothing Then
                MessageBox.Show("Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If
            lblnombre_cliente.Text = rowc("nombre")
            Filtro()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try

    End Sub

   
   

    Private Sub dtgdocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgdocumento.Click
        Muestra_Documento()
    End Sub

    Private Sub Muestra_Documento()
        'Try
        If Documento.Rows.Count = 0 Then
            MessageBox.Show("Nada que Consultar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Consulta = True

        Dim id_documento As String = dtgdocumento.Item("id_documento", dtgdocumento.CurrentRow.Index).Value.ToString
        Dim anulado As Boolean = dtgdocumento.Item("anulado", dtgdocumento.CurrentRow.Index).Value
        Select Case cbtipo.SelectedIndex
            Case 0
                Dim F As DataTable
                Dim FD As DataTable
                Dim rowf As DataRow
                F = FACM(" factura.id_factura=" + id_documento, True, "")
                rowf = F.Rows(0)
                FD = Table("select  id_producto,cantidad,unidad,precio,descuento,iv from factura_detalle where id_factura=" + id_documento, "")
                Dim Pedido As New frm_pedido
                With Pedido
                    .txtid_cliente.Text = rowf("id_cliente")
                    .rowc = cliente.Rows.Find(rowf("id_cliente"))
                    .lblcliente_nombre.Text = .rowc("nombre")
                    .txtplazo.Text = rowf("plazo").ToString
                    .cbid_agente.SelectedIndex = cb_buscar(.cbid_agente, rowf("id_agente"))
                    .PIV = rowf("piv")
                    FIV = rowf("piv")
                    .Fecha = rowf("fecha").ToString


                    TPD_Crear(FD)
                    .TPD = TPD
                    .dtgpedido.DataSource = .TPD

                    .Totales()
                    .FacturaID = rowf("id_factura").ToString
                    .facturaClave = rowf("claveNumerica").ToString
                    .facturaConsecutivo = rowf("numConsecutivo").ToString
                    .pnencabezado.Enabled = False
                    .botones(False)
                    .btnimprimir.Visible = True
                    .Show()
                End With

            Case 1
                Dim R As DataTable
                Dim rowr As DataRow
                R = RECM("recibo.id_recibo=" + id_documento, True, "")
                rowr = R.Rows(0)

                Dim recibo As New frm_recibo
                With recibo
                    .Show()
                    .txtid_cliente.Text = rowr("id_cliente")
                    cliente = Table("select * from cliente where id_cliente=" + rowr("id_cliente").ToString, "")

                    .rowc = cliente.Rows(0)
                    .lblnombre_cliente.Text = .rowc("nombre")

                    .txtreferencia.Text = rowr("referencia")
                    .cbforma_pago.SelectedIndex = rowr("forma_pago") - 1
                    .Total = FormatNumber(rowr("monto"), 2)

                    .NCA = Table("select id_Nota_credito,aplicado as monto,id_factura  from nota_Credito_detalle where id_recibo=" + rowr("id_recibo").ToString, "")
                    .Fc = Table("select id_factura ,abono,abono as abono_aplicado from recibo_detalle where id_recibo=" + id_documento, "")

                    'Dim abono_aplicado As DataColumn = New DataColumn("abono_aplicado")
                    'abono_aplicado.DataType = System.Type.GetType("System.Decimal")
                    'abono_aplicado.DefaultValue = 0
                    '.Fc.Columns.Add(abono_aplicado)


                    .Docs_S()





                    Dim row As DataRow
                    Dim z As Integer



                    For z = 0 To .NCA.Rows.Count - 1
                        row = .Docs.NewRow
                        row("id_documento") = .NCA.Rows(z).Item("id_factura")
                        row("abono") = .NCA.Rows(z).Item("monto")
                        row("id_Nota_credito") = .NCA.Rows(z).Item("id_nota_credito")
                        row("tipo") = 1
                        .Docs.Rows.Add(row)
                    Next

                    For z = 0 To .Fc.Rows.Count - 1
                        row = .Docs.NewRow
                        row("id_documento") = .Fc.Rows(z).Item("id_factura")
                        row("abono") = .Fc.Rows(z).Item("abono_aplicado")
                        .Docs.Rows.Add(row)
                    Next


                    .dtgfc.DataSource = .Fc
                    .dtgnca.DataSource = .NCA

                    '.Totales()
                    .lbltotal.Text = FormatNumber(rowr("monto"), 2)

                    .ReciboID = rowr("id_recibo").ToString
                    '.txtnumero.Text = rowr("id_recibo").ToString

                    .Fecha = FormatDateTime(rowr("fecha"), DateFormat.ShortDate)

                    .btnimprimir.Visible = True
                    .Panel1.Enabled = False
                    '.btnagregar.Enabled = False
                    '.btneliminar.Enabled = False
                    .btnguardar.Enabled = False

                End With

            Case 2
                Dim Dev As DataTable
                Dim DEvD As DataTable
                Dim Fac As DataTable
                Dim rowf As DataRow
                Dim rowd As DataRow
                Dev = Table("select * from devolucion where id_devolucion=" + id_documento, "")
                rowd = Dev.Rows(0)
                DEvD = Table("select  * from devolucion_detalle where id_devolucion=" + id_documento, "")
                Fac = FACM("factura.id_factura=" + rowd("id_factura").ToString, True, "")
                rowf = Fac.Rows(0)
                Dim devolucion As New frm_devolucion
                With devolucion


                    cliente = Table("select * from cliente where id_cliente=" + rowd("id_cliente").ToString, "")
                    .rowc = cliente.Rows(0)
                    .txtid_factura.Text = rowd("id_factura").ToString
                    .lblid_cliente.Text = rowd("id_cliente").ToString + " - " + rowc("nombre")
                    .lblplazo.Text = rowf("plazo").ToString
                    .lblfecha.Text = rowf("fecha")
                    .lblmonto.Text = FormatNumber(rowf("monto").ToString, 2)


                    TDD_crear(DEvD, rowd("id_factura"))

                    .devolucion = TDD
                    .dtgdevolucion.DataSource = .devolucion
                    .PIV = Fac.Rows(0).Item("piv")
                    .Totales()
                    '
                    .DevolucionID = id_documento
                    .Fecha = FormatDateTime(rowd("fecha"), DateFormat.ShortDate)

                    .pnencabezado.Enabled = False
                    .btnimprimir.Visible = True
                    .Show()
                End With


            Case 3
                Dim NC As DataTable
                Dim monto As Decimal
                NC = Table("select * from nota_credito where id_nota_credito=" + id_documento, "")
                Dim frmNC As New frm_Nota_Credito
                With frmNC
                    cliente = Table("select * from cliente where id_cliente=" + NC.Rows(0).Item("id_cliente").ToString, "")
                    .Cliente = cliente
                    .txtid_cliente.Text = NC.Rows(0).Item("id_cliente")
                    .lblid_cliente.Text = cliente.Rows(0).Item("nombre")
                    .txtexento.Text = FormatNumber(NC.Rows(0).Item("exento"), 2)
                    .txtgravado.Text = FormatNumber(NC.Rows(0).Item("gravado"), 2)
                    .txtiv.Text = FormatNumber(NC.Rows(0).Item("piv") * 100, 2)
                    monto = NC.Rows(0).Item("exento") + NC.Rows(0).Item("gravado") + NC.Rows(0).Item("gravado") * NC.Rows(0).Item("piv")
                    .lblmonto.Text = FormatNumber(monto, 2)


                    .NCID = id_documento
                    .Fecha = FormatDateTime(NC.Rows(0).Item("fecha"), DateFormat.ShortDate)
                    .btnimprimir.Visible = True

                    .btnaceptar.Enabled = False
                    .btncancelar.Enabled = False
                    .Panel.Enabled = False
                    .Show()

                End With

        End Select
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        ' End Try
    End Sub
    Private Sub Documento_crear()
        Documento = New DataTable("documento")
        Dim id_documento As DataColumn = New DataColumn("id_documento")
        id_documento.DataType = System.Type.GetType("System.Int32")
        Documento.Columns.Add(id_documento)

        Dim fecha As DataColumn = New DataColumn("fecha")
        fecha.DataType = System.Type.GetType("System.DateTime")
        Documento.Columns.Add(fecha)

        Dim cliente As DataColumn = New DataColumn("cliente")
        cliente.DataType = System.Type.GetType("System.String")
        Documento.Columns.Add(cliente)

        Dim Monto As DataColumn = New DataColumn("Monto")
        monto.DataType = System.Type.GetType("System.Decimal")
        Documento.Columns.Add(Monto)

        Dim anulado As DataColumn = New DataColumn("anulado")
        anulado.DataType = System.Type.GetType("System.Decimal")
        Documento.Columns.Add(anulado)

    End Sub

    Private Sub Documento_cargar(ByVal Table As DataTable, ByVal Tipo As Integer)
        '     Try
        Dim rowd As DataRow
        Documento.Rows.Clear()
        Dim z As Integer
        For z = 0 To Table.Rows.Count - 1
            With Table.Rows(z)
                rowc = cliente.Rows.Find(.Item("id_cliente"))
                rowd = Documento.NewRow

                Select Case Tipo
                    Case 1
                        rowd("id_documento") = .Item("id_factura")
                    Case 3
                        rowd("id_documento") = .Item("id_recibo")
                    Case 7
                        rowd("id_documento") = .Item("id_devolucion")
                    Case 5
                        rowd("id_documento") = .Item("id_nota_credito")
                End Select


                rowd("fecha") = .Item("fecha")
                rowd("cliente") = rowc("id_cliente").ToString + "-" + rowc("nombre")
                rowd("monto") = .Item("monto")
                rowd("anulado") = .Item("anulado")
                Documento.Rows.Add(rowd)
            End With
        Next
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub TPD_Crear(ByVal FD As DataTable)

        'Try
        TPD = New DataTable("TPD")
        Dim id_producto As DataColumn = New DataColumn("id_producto")
        id_producto.DataType = System.Type.GetType("System.Int32")
        TPD.Columns.Add(id_producto)

        Dim nombre As DataColumn = New DataColumn("nombre")
        nombre.DataType = System.Type.GetType("System.String")
        TPD.Columns.Add(nombre)

        Dim cantidad As DataColumn = New DataColumn("cantidad")
        cantidad.DataType = System.Type.GetType("System.Decimal")
        TPD.Columns.Add(cantidad)

        Dim unidad As DataColumn = New DataColumn("unidad")
        unidad.DataType = System.Type.GetType("System.Int16")
        TPD.Columns.Add(unidad)

        Dim unidad_nombre As DataColumn = New DataColumn("unidad_nombre")
        unidad_nombre.DataType = System.Type.GetType("System.String")
        TPD.Columns.Add(unidad_nombre)

        Dim precio As DataColumn = New DataColumn("precio")
        precio.DataType = System.Type.GetType("System.Decimal")
        TPD.Columns.Add(precio)

        Dim descuento As DataColumn = New DataColumn("descuento")
        descuento.DataType = System.Type.GetType("System.Decimal")
        TPD.Columns.Add(descuento)

        Dim consumidor As DataColumn = New DataColumn("consumidor")
        consumidor.DataType = System.Type.GetType("System.Decimal")
        TPD.Columns.Add(consumidor)

        Dim ubicacion As DataColumn = New DataColumn("ubicacion")
        ubicacion.DataType = System.Type.GetType("System.Int16")
        TPD.Columns.Add(ubicacion)

        Dim empaque As DataColumn = New DataColumn("empaque")
        empaque.DataType = System.Type.GetType("System.Int16")
        TPD.Columns.Add(empaque)
        
        Dim iv As DataColumn = New DataColumn("iv")
        iv.DataType = System.Type.GetType("System.Boolean")
        TPD.Columns.Add(iv)

        Dim Monto As DataColumn = New DataColumn("Monto")
        Monto.DataType = System.Type.GetType("System.Decimal")
        Monto.Expression = "cantidad * precio"
        TPD.Columns.Add(Monto)

        Dim Producto As DataTable
        Producto = Table("select * from producto order by id_producto", "id_producto")

        Dim rowp As DataRow
        Dim rowtpd As DataRow
        Dim z As Integer
        For z = 0 To FD.Rows.Count - 1
            With FD.Rows(z)
                rowtpd = TPD.NewRow
                rowp = Producto.Rows.Find(.Item("id_producto"))
                rowtpd("id_producto") = .Item("id_producto")
                rowtpd("cantidad") = .Item("cantidad")
                rowtpd("Nombre") = rowp("nombre")
                rowtpd("PreCio") = .Item("preCio")
                rowtpd("descuento") = .Item("descuento") * 100
                rowtpd("iv") = .Item("iv")
                TPD.Rows.Add(rowtpd)

                If .Item("unidad") = 1 Then
                    rowtpd("unidad_nombre") = "Und"
                ElseIf .Item("unidad") = 2 Then
                    rowtpd("unidad_nombre") = "Caj"
                ElseIf .Item("unidad") = 3 Then
                    rowtpd("unidad_nombre") = "Blt"
                Else
                    rowtpd("unidad_nombre") = "Pqt"
                End If


                Dim util As Decimal

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
                rowtpd("consumidor") = rowp("costo") * (1 + util) / rowp("empaque") / rowp("sub_empaque") * (1 + rowp("detalle")) * (1 + IIf(rowp("iv"), FIV, 0))
                'descuentos = rowtpd("consumidor") * rowtpd("descuento") / 100
                'rowtpd("consumidor") = rowtpd("consumidor") - descuentos
            End With
        Next
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub TDD_crear(ByVal DD As DataTable, ByVal factura_id As Integer)
        'try
        TDD = New DataTable("dd")
        Dim id_producto As DataColumn = New DataColumn("id_producto")
        id_producto.DataType = System.Type.GetType("System.Int32")
        TDD.Columns.Add(id_producto)

        Dim nombre As DataColumn = New DataColumn("nombre")
        nombre.DataType = System.Type.GetType("System.String")
        TDD.Columns.Add(nombre)

        Dim cantidad As DataColumn = New DataColumn("cantidad")
        cantidad.DataType = System.Type.GetType("System.Decimal")
        TDD.Columns.Add(cantidad)

        Dim presentacion As DataColumn = New DataColumn("presentacion")
        presentacion.DataType = System.Type.GetType("System.String")
        TDD.Columns.Add(presentacion)

        Dim precio As DataColumn = New DataColumn("precio")
        precio.DataType = System.Type.GetType("System.Decimal")
        TDD.Columns.Add(precio)

        Dim descuento As DataColumn = New DataColumn("descuento")
        descuento.DataType = System.Type.GetType("System.Decimal")
        TDD.Columns.Add(descuento)

        Dim iv As DataColumn = New DataColumn("iv")
        iv.DataType = System.Type.GetType("System.Boolean")
        TDD.Columns.Add(iv)

        Dim Monto As DataColumn = New DataColumn("Monto")
        Monto.DataType = System.Type.GetType("System.Decimal")
        Monto.Expression = "cantidad * precio"
        TDD.Columns.Add(Monto)

        Dim Producto As DataTable
        Producto = Table("select * from producto order by id_producto", "id_producto")
        Dim FD As DataTable
        FD = Table("select * from factura_detalle where id_factura=" + factura_id.ToString + "order by id_producto", "id_producto")

        Dim rowp As DataRow
        Dim rowdd As DataRow
        Dim rowfd As DataRow

        Dim z As Integer
        For z = 0 To DD.Rows.Count - 1
            With DD.Rows(z)
                rowdd = TDD.NewRow
                rowp = Producto.Rows.Find(.Item("id_producto"))
                rowfd = FD.Rows.Find(.Item("id_producto"))
                rowdd("id_producto") = .Item("id_producto")
                rowdd("cantidad") = .Item("cantidad")
                rowdd("Presentacion") = rowp("presentacion")
                rowdd("Nombre") = rowp("nombre")
                rowdd("PreCio") = rowfd("preCio")
                rowdd("descuento") = rowfd("descuento") * 100
                rowdd("iv") = rowfd("iv")
                TDD.Rows.Add(rowdd)
            End With
        Next
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub txtid_documento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_documento.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Filtro()
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtid_documento.Text, False)
        End If
    End Sub

    Private Sub txtid_documento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_documento.TextChanged

    End Sub

    Private Sub dtpdesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpdesde.ValueChanged
        If Not Building Then Filtro()
    End Sub

    Private Sub dtphasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtphasta.ValueChanged
        If Not Building Then Filtro()
    End Sub

    Private Sub cbtipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbtipo.SelectedIndexChanged
        If Not Building Then Filtro()
    End Sub

    
    Private Sub dtgdocumento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgdocumento.CellContentClick

    End Sub
End Class