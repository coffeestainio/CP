Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frm_devolucion

    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues

    Dim Factura As DataTable
    Public FD As DataTable
    Dim Cliente As DataTable
    Dim Bodega As DataTable

    Public devolucion As DataTable

    Dim Producto As DataTable
    Public rowc As DataRow

    Public TGravado As Decimal
    Public TExento As Decimal
    Public Tdescuento As Decimal
    Public Tiv As Decimal
    Public Total As Decimal


    Dim Frm(2) As String

    Dim L As Integer
    Public Formulario As Integer
    Dim Factura_ID As String
    Public Fecha As String
    Public DevolucionID As String
    Public PIV As Decimal



    Public Sub Identifica_Factura()

        Factura = FACMDescuento(" factura.id_factura=" + txtid_factura.Text + " and factura.sincronizada = 1 and coderror = 'Error:00'", True, "")

        If Factura.Rows.Count = 0 Then
            MessageBox.Show("Factura No Existe o No ha sido enviada a hacienda", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_factura.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        With Factura.Rows(0)
            If .Item("anulado") Then
                MessageBox.Show("Factura Fue Anulada", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_factura.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If

            Cliente = Table("Select * from cliente where id_cliente=" + .Item("id_cliente").ToString, "")
            rowc = Cliente.Rows(0)
            lblid_cliente.Text = .Item("id_cliente").ToString + " - " + rowc("nombre")
            Factura_ID = txtid_factura.Text
            lblplazo.Text = .Item("plazo")
            lblfecha.Text = .Item("fecha")
            lblmonto.Text = FormatNumber(.Item("Monto").ToString, 2)
            PIV = .Item("piv")


            FD = Table("select id_Producto,cantidad,precio,unidad,descuento*100 as descuento,iv from factura_detalle where id_factura=" + .Item("id_factura").ToString + " order by id_producto", "id_producto")
            FD_Completar()
            Devolucion_Crear()

            dtgfactura_detalle.DataSource = FD
            dtgdevolucion.DataSource = devolucion

            ToolStrip.Enabled = True
        End With
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub


    Private Sub frm_devolucion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not Consulta Then
                myForms.frm_principal.ToolStrip.Enabled = True
                CONN1.Close()
                Fecha = Date.Today.ToShortDateString + "  " + Format(Now, "short Time")
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub frm_devolucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Consulta Then OpenConn()
           
            Frm(1) = "ORIGINAL -  CLIENTE"
            Frm(2) = "COPIA - ARCHIVO"
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub


    Public Sub Totales()
        Try
            Dim mf As Decimal
            Dim m As Decimal = 0
            Dim d As Decimal = 0


            Dim productos As Decimal = 0
            TGravado = 0
            TExento = 0
            Tdescuento = 0
            Tiv = 0
            Total = 0
            Dim i As Integer

            For i = 0 To devolucion.Rows.Count - 1
                With devolucion.Rows(i)
                    m = .Item("precio") * .Item("cantidad")
                    d = m * (.Item("descuento") / 100)
                    mf = m
                    If .Item("iv") Then
                        TGravado = TGravado + mf
                        Tiv = Tiv + ((mf - d) * PIV)
                    Else
                        TExento = TExento + mf
                    End If
                    Tdescuento = Tdescuento + d
                    productos = productos + 1
                End With
            Next i

            Total = TExento + TGravado + Tiv - Tdescuento
            lblproductos.Text = productos
            lbltotal.Text = "¢ " + FormatNumber(Total, 2)
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        Try
            Dim rowf As DataRow = FD.Rows(BindingContext(FD).Position())
            Dim row As DataRow = devolucion.Rows.Find(rowf("id_producto"))
            If Not (row Is Nothing) Then
                MessageBox.Show("Producto ya Existe", "Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim rowd As DataRow = devolucion.NewRow
            rowd("id_producto") = rowf("id_producto")
            rowd("nombre") = rowf("nombre")
            rowd("cantidad") = rowf("cantidad")
            rowd("presentacion") = rowf("presentacion")
            rowd("empaque") = rowf("empaque")
            rowd("precio") = rowf("precio")
            rowd("unidad") = rowf("unidad")
            rowd("descuento") = rowf("descuento")
            rowd("iv") = rowf("iv")
            devolucion.Rows.Add(rowd)
            Totales()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Try
            If devolucion.Rows.Count = 0 Then
                MessageBox.Show("Nada que Eliminar", "Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            devolucion.Rows(BindingContext(devolucion).Position()).Delete()
            Totales()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        'Try
        If devolucion.Rows.Count = 0 Then
            MessageBox.Show("Nada que Modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim devolucion_mantenimiento As New frm_devolucion_mantenimiento
        devolucion_mantenimiento.Owner = Me
        With devolucion_mantenimiento
            Dim row As DataRow = devolucion.Rows(BindingContext(devolucion).Position())
            .Owner = Me
            .txtid_producto.Text = row("id_producto")
            .lblproducto_nombre.Text = row("nombre")
            .lblprecio.Text = row("precio")
            '.lblpresentacion.Text = row("presentacion")
            .cbunidad.SelectedIndex = row("unidad") - 1
            .cbunidad.Enabled = IIf(row("unidad") > 1, 1, 0)
            .txtdescuento.Text = FormatNumber(row("descuento"), 2)
            .lbliv.Text = IIf(row("iv"), "+ iv", "")
            .Show()
        End With
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub



    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        'Try
        If devolucion.Rows.Count = 0 Then
            MessageBox.Show("No Hay Productos que Devolver", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Val(txtid_factura.Text) = 0 Then
            MessageBox.Show("Debe Escribir un Número de Factura", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_factura.Focus()
            pbid_factura.Visible = True
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        If Factura_ID <> txtid_factura.Text Then
            MessageBox.Show("Escriba de Nuevo el Número de Factura y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_factura.Focus()
            pbid_factura.Visible = True
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        If devolucion.Rows.Count = 0 Then
            MessageBox.Show("No Seleccionó Ningun Producto", "Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        btnguardar.Enabled = False
        Dim cmd As New SqlCommand
        cmd.Connection = CONN1
        Dim D As DataTable
        Dim sql As String

        Dim consec As Integer = Nothing
        Try
            consec = Table("select top 1 consecutivoElectronico as consecutivo from devolucion order by consecutivoElectronico desc", "").Rows(0).Item("consecutivo")
            consec += 1
        Catch
            consec = 1
        End Try


        Dim numConsecutivo As String = "0010000103" + consec.ToString("0000000000")
        Dim claveNumerica As String = "506" + Date.Today.ToString("ddMMyy") + CEDULA + numConsecutivo + "1" + "12345670"
        Dim claveNumericaFactura As String = Factura.Rows(0).Item("claveNumerica")
        Dim clienteTributa As Boolean = Factura.Rows(0).Item("clienteTributa")
        Dim fechaEmisionFactura As String = " (select fecha from factura where id_factura = " + txtid_factura.Text + ")"


        sql = "insert into devolucion (id_factura,fecha,id_cliente,fechaEmisionFactura, numeroBoleta, claveNumerica,NumConsecutivo,consecutivoElectronico, claveNumericaFactura,clienteTributa,id_usuario) values (" + _
        txtid_factura.Text & "," & _
        "getDate()," & _
        rowc("id_cliente").ToString & "," & _
        "" & fechaEmisionFactura & "," & _
        "'" & txtBoleta.Text & "'," & _
        "'" & claveNumerica.ToString & "'," & _
        "'" & numConsecutivo.ToString & "'," & _
         consec.ToString & "," & _
        "'" & claveNumericaFactura.ToString & "'," & _
        "'" & clienteTributa.ToString & "'," & _
        USUARIO_ID.ToString & ")"

        D = Table(sql + " select @@IDENTITY as id_devolucion", "")
        DevolucionID = D.Rows(0).Item("id_devolucion")

        sql = "insert into Nota_credito (fecha,id_cliente,exento,gravado,descuento,tiv,piv,observaciones,id_usuario) values (" + _
                "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
                rowc("id_cliente").ToString + "," + _
                (TExento).ToString + "," + _
                (TGravado).ToString + "," + _
                (Tdescuento).ToString + "," + _
                (Tiv).ToString + "," + _
                (PIV).ToString + "," + _
                "'DEV " & DevolucionID & "-" & txtBoleta.Text & "'," + _
        USUARIO_ID + ")"


        Dim T As DataTable = Table(sql + " select @@IDENTITY as id_nota_credito", "")

        sql = "update devolucion set id_nota_credito=" + T.Rows(0).Item("id_nota_credito").ToString + _
        " where id_devolucion=" + DevolucionID

        cmd.CommandText = sql
        OpenConn()
        cmd.ExecuteNonQuery()

        Dim i As Integer

        For i = 0 To devolucion.Rows.Count - 1
            With devolucion.Rows(i)
                sql = "update producto set existencia=existencia+" + _
                IIf(.Item("unidad") = 1, .Item("cantidad").ToString, (.Item("cantidad") * .Item("empaque")).ToString) + _
                " where id_producto=" + .Item("id_producto").ToString

                cmd.CommandText = sql
                OpenConn()
                cmd.ExecuteNonQuery()

                sql = "insert into  devolucion_detalle (id_devolucion,id_producto, unidad, precio, descuento, IV, cantidad) values (" + _
                DevolucionID + "," + _
                "'" & .Item("id_producto") & "'," & _
                .Item("unidad").ToString + "," + _
                .Item("precio").ToString + "," + _
                (.Item("descuento") / 100).ToString & "," & _
                "'" + .Item("IV").ToString + "'," + _
                .Item("cantidad").ToString + ")"


                cmd.CommandText = sql
                OpenConn()
                cmd.ExecuteNonQuery()



            End With
        Next

        imprimir(1)
        imprimir(2)

        Me.Close()
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub



    Private Sub txtid_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_factura.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_factura.Text) = 0 Then
                Me.Close()
            Else
                Identifica_Factura()
            End If
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtid_factura.Text, False)
        End If
    End Sub

    Public Sub FD_Completar()

        Dim presentacion As DataColumn = New DataColumn("presentacion")
        presentacion.DataType = System.Type.GetType("System.String")
        FD.Columns.Add(presentacion)

        Dim nombre As DataColumn = New DataColumn("nombre")
        nombre.DataType = System.Type.GetType("System.String")
        FD.Columns.Add(nombre)

        Dim empaque As DataColumn = New DataColumn("empaque")
        empaque.DataType = System.Type.GetType("System.Int32")
        FD.Columns.Add(empaque)
       

        Dim monto As DataColumn = New DataColumn("monto")
        monto.DataType = System.Type.GetType("System.Decimal")
        monto.Expression = "cantidad * precio"
        FD.Columns.Add(monto)

        Dim z As Integer
        For z = 0 To FD.Rows.Count - 1
            With FD.Rows(z)
                Producto = Table("select id_producto,nombre,presentacion,empaque from producto where id_producto=" + .Item("id_producto").ToString, "")
                If Producto.Rows.Count > 0 Then
                    .Item("nombre") = Producto.Rows(0).Item("nombre")
                    .Item("empaque") = Producto.Rows(0).Item("empaque")
                    .Item("presentacion") = Prst(FD.Rows(z).Item("unidad"))

                End If
            End With
        Next
    End Sub

    Private Sub Devolucion_Crear()
        devolucion = Table("select id_producto,cantidad,unidad,precio,descuento,iv from factura_detalle where id_factura=0", "id_producto")

        Dim presentacion As DataColumn = New DataColumn("presentacion")
        presentacion.DataType = System.Type.GetType("System.String")
        devolucion.Columns.Add(presentacion)

        Dim empaque As DataColumn = New DataColumn("empaque")
        empaque.DataType = System.Type.GetType("System.Int32")
        devolucion.Columns.Add(empaque)

        Dim nombre As DataColumn = New DataColumn("nombre")
        nombre.DataType = System.Type.GetType("System.String")
        devolucion.Columns.Add(nombre)

        Dim monto As DataColumn = New DataColumn("monto")
        monto.DataType = System.Type.GetType("System.Decimal")
        monto.Expression = "cantidad * precio"
        devolucion.Columns.Add(monto)
    End Sub

    Private Sub btntotales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntotales.Click
        Try
            Dim devolucion_totales As New frm_pedido_totales
            With devolucion_totales
                .Owner = Me
                .lblgravado.Text = FormatNumber(TGravado, 2)
                .lblexento.Text = FormatNumber(TExento, 2)
                .lbldescuento.Text = FormatNumber(Tdescuento, 2)
                .lbliv.Text = FormatNumber(Tiv, 2)
                .lbltotal.Text = "¢ " + FormatNumber(Total, 2)
            End With
            devolucion_totales.Show()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub



    Private Sub imprimir(ByVal Doc As String)
        Try

            Dim rdevolucion As New rpt_devolucion

            rdevolucion.SetDataSource(devolucion)

            rParameterFieldDefinitions = rdevolucion.DataDefinition.ParameterFields


            rParameterFieldLocation = rParameterFieldDefinitions.Item("negocio")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = NEGOCIO
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("CJ")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = CJ
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("WEB")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = WEB
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("negocio_TELEFONO")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = TELEFONO
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("negocio_DIRECCION")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = DIRECCION
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("factura")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Factura: " + txtid_factura.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("devolucionid")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Devolución:   " + DevolucionID
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("cliente")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Cliente: " + lblid_cliente.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("fecha")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Fecha: " + IIf(Consulta, Fecha, Date.Today.ToShortDateString)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("%")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = IIf(Tdescuento > 0, "-%", "")
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("gravado")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(TGravado, 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("iv")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(Tiv, 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("exento")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(TExento, 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("Total")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "¢ " + FormatNumber(Total, 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("usuario")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "hecho por: " + USUARIO_NOMBRE
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



            rParameterFieldLocation = rParameterFieldDefinitions.Item("formulario")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = Frm(Doc)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



            rParameterFieldLocation = rParameterFieldDefinitions.Item("tdescuento")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = IIf(Tdescuento > 0, "Descuento", "")
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("descuento")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = IIf(Tdescuento > 0, FormatNumber(Tdescuento, 2), "")
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            'If ID_ESTACION = 1 Then
            '    rdevolucion.PrintOptions.PrinterName = "REPORTES"
            'Else
            '    rdevolucion.PrintOptions.PrinterName = "\\" + PRINTER + "\REPORTES"
            'End If
            'rdevolucion.PrintToPrinter(1, False, 1, 1)

            Dim rv As New frm_Report_Viewer
            rv.crv.ReportSource = rdevolucion
            rv.Show()

        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try


    End Sub


   
    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        imprimir(1)
        imprimir(2)
    End Sub
End Class