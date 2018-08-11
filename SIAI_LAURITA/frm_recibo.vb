Imports System.Data.sqlclient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class frm_recibo
    Inherits System.Windows.Forms.Form

    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues

    Public cliente As DataTable
    Public rowc As DataRow
    Public Fc As DataTable
    Dim DVFP As DataView
    Dim FP As DataTable
    Dim NCP As DataTable
    Public NCA As DataTable
    Public NCD As DataTable


    Public Total As Decimal
    Dim NCA_subtotal As Decimal
    Dim FC_subtotal As Decimal
    Public Saldo_Nuevo As Decimal
    Dim TNCP As Decimal = 0


    Dim Cliente_ID As String
    Dim Vencido As Decimal
    Dim Sinvencer As Decimal
    Dim L As Integer
    Dim Formulario As Integer
    Public Fecha As String
    Public ReciboID As String

    Public criterio As String

    Public Docs As DataTable

    
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
                BUSQUEDA = "Recibo"

                Dim cliente_buscar As New frm_cliente_buscar
                cliente_buscar.Owner = Me
                cliente_buscar.Show()
                cliente_buscar.txtbuscar_cliente.Text = e.KeyChar

            Else

                e.Handled = Numerico(Asc(e.KeyChar), txtid_cliente.Text, False)
            End If
        End If
    End Sub

    Public Sub Identifica_cliente()
        'Try
        cliente = Table("select * from cliente where eliminado=0 and id_cliente=" + txtid_cliente.Text, "")
        If cliente.Rows.Count = 0 Then
            MessageBox.Show("Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        rowc = cliente.Rows(0)
        lblnombre_cliente.Text = rowc("nombre")
        
        Cliente_ID = txtid_cliente.Text
        Estado()
        

        ' Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub frm_recibo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not Consulta Then
                myForms.frm_principal.ToolStrip.Enabled = True
                CONN1.Close()
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
    Private Sub frm_recibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        If Not Consulta Then
            OpenConn()

            FC_S()
            
            dtgfc.DataSource = Fc
            cbforma_pago.SelectedIndex = 0
            Fecha = Date.Today.ToShortDateString + "  " + Format(Now, "short Time")
        End If
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub


    Public Sub FC_S()
        FC = New DataTable("FC")

        Dim id_factura As DataColumn = New DataColumn("id_factura")
        id_factura.DataType = System.Type.GetType("System.Int32")
        id_factura.DefaultValue = 0
        Fc.Columns.Add(id_factura)

        Dim fecha As DataColumn = New DataColumn("fecha")
        fecha.DataType = System.Type.GetType("System.DateTime")
        Fc.Columns.Add(fecha)

        Dim abono As DataColumn = New DataColumn("abono")
        abono.DataType = System.Type.GetType("System.Decimal")
        abono.DefaultValue = 0
        Fc.Columns.Add(abono)

        Dim abono_aplicado As DataColumn = New DataColumn("abono_aplicado")
        abono_aplicado.DataType = System.Type.GetType("System.Decimal")
        abono_aplicado.DefaultValue = 0
        Fc.Columns.Add(abono_aplicado)


        Dim saldo As DataColumn = New DataColumn("saldo")
        saldo.DataType = System.Type.GetType("System.Decimal")
        saldo.DefaultValue = 0
        Fc.Columns.Add(saldo)

        Dim monto As DataColumn = New DataColumn("monto")
        monto.DataType = System.Type.GetType("System.Decimal")
        monto.DefaultValue = 0
        Fc.Columns.Add(monto)

        Dim vence As DataColumn = New DataColumn("vence")
        vence.DataType = System.Type.GetType("System.DateTime")
        Fc.Columns.Add(vence)

        Fc.PrimaryKey = New DataColumn() {Fc.Columns("id_factura")}

    End Sub

    Private Sub NCA_S()
        NCA = New DataTable("nca")

        Dim id_nota_credito As DataColumn = New DataColumn("id_nota_Credito")
        id_nota_credito.DataType = System.Type.GetType("System.Int32")
        id_nota_credito.DefaultValue = 0
        NCA.Columns.Add(id_nota_credito)

        Dim id_cliente As DataColumn = New DataColumn("id_cliente")
        id_cliente.DataType = System.Type.GetType("System.Int32")
        id_cliente.DefaultValue = 0
        NCA.Columns.Add(id_cliente)

        Dim fecha As DataColumn = New DataColumn("fecha")
        fecha.DataType = System.Type.GetType("System.DateTime")
        NCA.Columns.Add(fecha)

        
        Dim monto As DataColumn = New DataColumn("monto")
        monto.DataType = System.Type.GetType("System.Decimal")
        monto.DefaultValue = 0
        NCA.Columns.Add(monto)

        Dim exento As DataColumn = New DataColumn("exento")
        exento.DataType = System.Type.GetType("System.Decimal")
        exento.DefaultValue = 0
        NCA.Columns.Add(exento)

        Dim gravado As DataColumn = New DataColumn("gravado")
        gravado.DataType = System.Type.GetType("System.Decimal")
        gravado.DefaultValue = 0
        NCA.Columns.Add(gravado)

        Dim piv As DataColumn = New DataColumn("piv")
        piv.DataType = System.Type.GetType("System.Decimal")
        piv.DefaultValue = 0
        NCA.Columns.Add(piv)

        Dim id_usuario As DataColumn = New DataColumn("id_usuario")
        id_usuario.DataType = System.Type.GetType("System.Int32")
        id_usuario.DefaultValue = 0
        NCA.Columns.Add(id_usuario)

        Dim observaciones As DataColumn = New DataColumn("observaciones")
        observaciones.DataType = System.Type.GetType("System.String")
        NCA.Columns.Add(observaciones)

        NCA.PrimaryKey = New DataColumn() {NCA.Columns("id_nota_credito")}

    End Sub




    Private Sub NCD_S()
        NCD = New DataTable("NCD")

        Dim id_nota_credito As DataColumn = New DataColumn("id_nota_Credito")
        id_nota_credito.DataType = System.Type.GetType("System.Int32")
        id_nota_credito.DefaultValue = 0
        NCD.Columns.Add(id_nota_credito)


        Dim aplicado As DataColumn = New DataColumn("aplicado")
        aplicado.DataType = System.Type.GetType("System.Decimal")
        aplicado.DefaultValue = 0
        NCD.Columns.Add(aplicado)


        Dim id_factura As DataColumn = New DataColumn("id_factura")
        id_factura.DataType = System.Type.GetType("System.Int32")
        id_factura.DefaultValue = 0
        NCD.Columns.Add(id_factura)

    End Sub


    Public Sub Totales()

        Dim z As Integer
        Total = 0
        FC_subtotal = 0
        NCA_subtotal = 0

        For z = 0 To Fc.Rows.Count - 1
            FC_subtotal = FC_subtotal + Fc.Rows(z).Item("abono")
        Next



        For z = 0 To NCA.Rows.Count - 1
            NCA_subtotal = NCA_subtotal + NCA.Rows(z).Item("monto")
        Next

        Total = FC_subtotal - NCA_subtotal
        Saldo_Nuevo = Vencido + Sinvencer - Total


        lblfc_subltotal.Text = FormatNumber(FC_subtotal, 2)
        lblnca_subtotal.Text = FormatNumber(NCA_subtotal, 2)
        lbltotal.Text = FormatNumber(Total, 2)
        lblsaldo_nuevo.Text = FormatNumber(Saldo_Nuevo, 2)

    End Sub


    Private Sub Estado()
        'Try
        Sinvencer = 0.0
        Vencido = 0.0
        TNCP = 0


        criterio = "id_cliente=" + rowc("id_cliente").ToString + ")"

        FP = FACS2("(factura." + criterio, "id_factura")

        Dim abono As DataColumn = New DataColumn("abono")
        abono.DataType = System.Type.GetType("System.Decimal")
        abono.DefaultValue = 0
        FP.Columns.Add(abono)

        Dim z As Integer
        For z = 0 To FP.Rows.Count - 1
            With FP.Rows(z)
                If .Item("vence") > Date.Today Then
                    Sinvencer = Sinvencer + .Item("saldo")
                Else
                    Vencido = Vencido + .Item("saldo")
                End If
            End With
        Next

        DVFP = New DataView(FP)
        DVFP.Sort = "Vence"

        NCP = NCDIS("(" + criterio, "id_nota_credito")
        For z = 0 To NCP.Rows.Count - 1
            TNCP = TNCP + NCP.Rows(z).Item("monto")
        Next
        Vencido = Vencido - TNCP

        NCA_S()

        dtgfp.DataSource = DVFP
        dtgncp.DataSource = NCP
        dtgnca.DataSource = NCA


        ToolStrip.Enabled = IIf(Vencido + Sinvencer > 0, True, False)
        lblsaldo_nuevo.Text = FormatNumber(Vencido, 2)
        lblvencido.Text = FormatNumber(Vencido, 2)
        lblsinvencer.Text = FormatNumber(Sinvencer, 2)
        lblsaldototal.Text = FormatNumber(Vencido + Sinvencer, 2)

        Fc.Rows.Clear()

        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub



    Private Sub imprimir()
        Try

            Dim rrecibo As New rpt_recibo

            rrecibo.SetDataSource(Docs)

            rParameterFieldDefinitions = rrecibo.DataDefinition.ParameterFields


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

            rParameterFieldLocation = rParameterFieldDefinitions.Item("TELEFONO")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = TELEFONO
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("DIRECCION")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = DIRECCION
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("id_recibo")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Recibo # " + ReciboID
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("fecha")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Fecha: " + IIf(Consulta, Fecha, Date.Today.ToShortDateString)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("cliente")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = lblnombre_cliente.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("id_cliente")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Cliente " + txtid_cliente.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("forma_pago")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = cbforma_pago.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("referencia")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = txtreferencia.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("monto")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Monto  ¢ " + FormatNumber(Total, 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

          
            rParameterFieldLocation = rParameterFieldDefinitions.Item("saldo_nuevo")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = IIf(Consulta, "", "Saldo ¢ " + FormatNumber(Saldo_Nuevo, 2))
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("usuario")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "hecho por: " + USUARIO_NOMBRE
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rrecibo.PrintOptions.PrinterName = "\\estacion06\recibos"
            rrecibo.PrintToPrinter(1, False, 1, 1)

            'Dim rv As New frm_Report_Viewer
            'rv.crv.ReportSource = rrecibo
            'rv.Show()


        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub


    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        'Docs_Crear()
        imprimir()
    End Sub




    Private Sub txtreferencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtreferencia.KeyPress
        e.Handled = chk(Asc(e.KeyChar))
    End Sub



    

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        'Try
        If Fc.Rows.Count = 0 Then
            MessageBox.Show("Nada que Modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim recibo_mantenimiento As New frm_recibo_mantenimiento
        recibo_mantenimiento.Owner = Me
        With recibo_mantenimiento
            Dim rowf As DataRow = Fc.Rows(BindingContext(Fc).Position())
            .Owner = Me
            .lblid_factura.Text = rowf("id_factura")
            .Saldo = rowf("saldo")
            .lblsaldo.Text = FormatNumber(rowf("saldo"), 2)
            .Show()
        End With
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub


  
    Private Sub Docs_Crear()

        Dim z As Integer
        Docs_S()
        NCD_S()

        Dim nsaldo As DataColumn = New DataColumn("nsaldo")
        nsaldo.DataType = System.Type.GetType("System.Decimal")
        nsaldo.DefaultValue = 0
        Fc.Columns.Add(nsaldo)

        For z = 0 To Fc.Rows.Count - 1
            Fc.Rows(z).Item("nsaldo") = Fc.Rows(z).Item("saldo")
        Next


        Dim fci As Integer = 0
        Dim Disp As Decimal
        Dim row As DataRow
        Dim rowncd As DataRow

        For z = 0 To NCA.Rows.Count - 1
            Disp = NCA.Rows(z).Item("monto")
            Do While Disp > 0 And fci <= Fc.Rows.Count - 1
                With Fc.Rows(fci)
                    If .Item("nsaldo") > Disp Then
                        rowncd = NCD.NewRow
                        rowncd("id_nota_credito") = NCA.Rows(z).Item("id_nota_credito")
                        rowncd("id_factura") = .Item("id_factura")
                        rowncd("aplicado") = Disp
                        NCD.Rows.Add(rowncd)
                        .Item("nsaldo") = .Item("nsaldo") - Disp
                        Disp = 0
                    Else
                        rowncd = NCD.NewRow
                        rowncd("id_nota_credito") = NCA.Rows(z).Item("id_nota_credito")
                        rowncd("id_factura") = .Item("id_factura")
                        rowncd("aplicado") = .Item("nsaldo")
                        NCD.Rows.Add(rowncd)
                        Disp = Disp - .Item("nsaldo")
                        .Item("nsaldo") = 0
                        fci = fci + 1
                    End If
                End With

            Loop
        Next

        For z = 0 To NCD.Rows.Count - 1
            row = Docs.NewRow
            row("id_documento") = NCD.Rows(z).Item("id_factura")
            row("abono") = NCD.Rows(z).Item("aplicado")
            row("id_Nota_credito") = NCD.Rows(z).Item("id_nota_credito")
            row("tipo") = 1
            Docs.Rows.Add(row)
        Next

        Dim Aplicado As Decimal
        For z = 0 To Fc.Rows.Count - 1
            Aplicado = 0
            With Fc.Rows(z)
                For i As Integer = 0 To NCD.Rows.Count - 1
                    If NCD.Rows(i).Item("id_factura") = .Item("id_factura") Then
                        Aplicado = Aplicado + NCD.Rows(i).Item("aplicado")
                    End If
                Next
                .Item("abono_aplicado") = .Item("abono") - Aplicado
            End With
        Next

        For z = 0 To Fc.Rows.Count - 1
            row = Docs.NewRow
            row("id_documento") = Fc.Rows(z).Item("id_factura")
            row("abono") = Fc.Rows(z).Item("abono_aplicado")
            Docs.Rows.Add(row)
        Next

    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        'Try
        If dtgfc.Rows.Count = 0 Then
            MessageBox.Show("No Seleccionó Facturas para Cancelar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Val(txtid_cliente.Text) = 0 Then
            MessageBox.Show("Debe Escribir un Código de cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            pbid_cliente.Visible = True
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        If Cliente_ID <> txtid_cliente.Text Then
            MessageBox.Show("Escriba de Nuevo el Código del Cliente y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            pbid_cliente.Visible = True
            Exit Sub
        End If

        
        If Total < 0 Then
            MessageBox.Show("El Monto del Recibo debe ser Mayor a Cero", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If


        btnguardar.Enabled = False
        Docs_Crear()



        Dim cmd As New SqlCommand
        cmd.Connection = CONN1
        Dim sql As String


        sql = "insert into recibo (id_cliente,forma_pago,referencia,id_usuario,id_caja) values (" + _
        txtid_cliente.Text + "," + _
       (cbforma_pago.SelectedIndex + 1).ToString + "," + _
        "'" + txtreferencia.Text + "'," + _
        USUARIO_ID + "," + _
        "0" + ")"


        Dim R As DataTable = Table(sql + " select @@IDENTITY as id_recibo", "")

        ReciboID = R.Rows(0).Item("id_recibo")

        For I As Integer = 0 To Fc.Rows.Count - 1
            With Fc.Rows(I)
                sqlquery("update tfacs set saldo= saldo - " & .Item("abono") & " where id_factura = " & .Item("id_factura"))
                sql = "insert into recibo_detalle (id_recibo,id_factura,abono) values (" + _
                ReciboID + "," + _
                .Item("id_factura").ToString + "," + _
                .Item("abono_aplicado").ToString + ")"


                cmd.CommandText = sql
                OpenConn()
                cmd.ExecuteNonQuery()

            End With
        Next

        For z As Integer = 0 To NCD.Rows.Count - 1
            With NCD.Rows(z)

                sqlquery("update tfacs set saldo = saldo - " & .Item("aplicado") & " where id_factura = " & .Item("id_Factura"))
                sql = "insert into nota_credito_detalle (id_nota_credito,id_factura,fecha,aplicado,id_recibo) values (" + _
                .Item("id_nota_credito").ToString + "," + _
                .Item("id_factura").ToString + "," + _
                "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
                .Item("aplicado").ToString + "," + _
                ReciboID + ")"

                cmd.CommandText = sql
                OpenConn()
                cmd.ExecuteNonQuery()
            End With
        Next


        imprimir()
        Me.Close()

        ' Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub txtid_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_cliente.TextChanged

    End Sub

    Private Sub btnfc_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfc_agregar.Click
        Try
            If FP.Rows.Count = 0 Then
                MessageBox.Show("No Seleccionó Ninguna Factura", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim rowfp As DataRow = DVFP.Table.Rows.Find(dtgfp.Item("fpid_factura", dtgfp.CurrentRow.Index).Value)
            rowfp.Item("abono") = rowfp.Item("saldo")
            Fc.ImportRow(rowfp)
            rowfp.Delete()
            Totales()
        Catch ex As Exception
            MessageBox.Show("No Seleccionó Ninguna Factura", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub btnfc_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfc_eliminar.Click
        If Fc.Rows.Count = 0 Then
            MessageBox.Show("No Seleccionó Ninguna Factura", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim rowfc As DataRow = Fc.Rows.Find(dtgfc.Item("fcid_factura", dtgfc.CurrentRow.Index).Value)
        FP.ImportRow(rowfc)
        rowfc.Delete()
        Totales()
    End Sub

    Private Sub btnnca_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnca_agregar.Click
        If NCP.Rows.Count = 0 Then
            MessageBox.Show("No Seleccionó Ninguna Nota de Crédito", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim rowncp As DataRow = NCP.Rows.Find(dtgncp.Item("ncpid_nota_credito", dtgncp.CurrentRow.Index).Value)
        NCA.ImportRow(rowncp)
        rowncp.Delete()
        Totales()
    End Sub

    Private Sub btnnca_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnca_eliminar.Click
        If NCA.Rows.Count = 0 Then
            MessageBox.Show("No Seleccionó Ninguna Nota de Crédito", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim rownca As DataRow = NCA.Rows.Find(dtgnca.Item("ncaid_nota_credito", dtgnca.CurrentRow.Index).Value)
        NCP.ImportRow(rownca)
        rownca.Delete()
        Totales()
    End Sub

    Public Sub Docs_S()
        Docs = New DataTable("doc")



        Dim id_documento As DataColumn = New DataColumn("id_documento")
        id_documento.DataType = System.Type.GetType("System.Int32")
        id_documento.DefaultValue = 0
        Docs.Columns.Add(id_documento)

        Dim tipo As DataColumn = New DataColumn("tipo")
        tipo.DataType = System.Type.GetType("System.Int32")
        tipo.DefaultValue = 0
        Docs.Columns.Add(tipo)

        Dim id_nota_credito As DataColumn = New DataColumn("id_nota_credito")
        id_nota_credito.DataType = System.Type.GetType("System.Int32")
        id_nota_credito.DefaultValue = 0
        Docs.Columns.Add(id_nota_credito)

        Dim monto As DataColumn = New DataColumn("abono")
        monto.DataType = System.Type.GetType("System.Decimal")
        monto.DefaultValue = 0
        Docs.Columns.Add(monto)

    End Sub

    Private Sub btnabonototal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnabonototal.Click
        'Try
        If Fc.Rows.Count = 0 Then
            MessageBox.Show("Nada que Modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim recibo_mantenimiento As New frm_recibo_mantenimiento_abono
        recibo_mantenimiento.Owner = Me
        With recibo_mantenimiento
            .Owner = Me
            .Show()
        End With
    End Sub

    Private Sub txtfiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfiltro.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            btnfc_agregar_Click(sender, e)
            txtfiltro.Text = ""
        End If
    End Sub

    Private Sub txtfiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfiltro.TextChanged
        If (txtfiltro.Text.Length > 0) Then
            DVFP.Sort = "id_factura"
            DVFP.RowFilter = "id_factura + '' LIKE '%" & txtfiltro.Text & "%'"
        Else
            DVFP.RowFilter = "0 = 0"
        End If
    End Sub
End Class