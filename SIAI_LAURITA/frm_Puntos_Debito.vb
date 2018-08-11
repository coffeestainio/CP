Imports system.data.SqlClient
Imports System.math
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_Puntos_Debito
    Dim clienteID As String
    Dim Cliente As DataTable
    Dim Facs As DataTable
    Dim SA As Decimal
    Dim NCID As String


    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues

    Private Sub frm_Puntos_Debito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not Consulta Then
                myForms.frm_principal.ToolStrip.Enabled = True
                CONN1.Close()
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub frm_Puntos_Debito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Consulta Then
                OpenConn()
                Cliente = Table("select id_cliente,nombre from cliente order by id_cliente", "id_cliente")
            End If
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
    Public Sub Identifica_cliente()
        Try
            Dim rowc As DataRow
            rowc = Cliente.Rows.Find(txtid_cliente.Text)
            If rowc Is Nothing Then
                MessageBox.Show("Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If
            lblnombre_cliente.Text = rowc("nombre")
            clienteID = txtid_cliente.Text
            Estado()
            SendKeys.Send("{tab}")
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
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
                BUSQUEDA = "Puntos_Debito"
                Dim cliente_buscar As New frm_cliente_buscar
                cliente_buscar.Owner = Me
                cliente_buscar.Show()
                cliente_buscar.txtbuscar_cliente.Text = e.KeyChar
            Else
                e.Handled = Numerico(Asc(e.KeyChar), txtid_cliente.Text, False)
            End If
        End If
    End Sub
    Private Sub Estado()
        SA = 0
        Facs = FACPS(" factura.fecha>='09/04/2006' and factura.id_cliente=" + txtid_cliente.Text)
        Dim z As Integer
        For z = 0 To Facs.Rows.Count - 1
            SA = SA + Facs.Rows(z).Item("psaldo")
        Next
        lbldisponible.Text = FormatNumber(SA, 2)
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub txtpuntos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpuntos.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Saldo_Actualizar()
            SendKeys.Send("{tab}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtpuntos.Text, True)
        End If
    End Sub
    Private Sub txtreferencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtreferencia.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    
    Private Sub Saldo_Actualizar()
        lbldebito.Text = FormatNumber(txtpuntos.Text, 2)
        lblrestante.Text = FormatNumber(SA - Val(txtpuntos.Text), 2)
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'Try
        If Val(txtid_cliente.Text) = 0 Then
            MessageBox.Show("Debe Escribir un Código de cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            pbid_cliente.Visible = True
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        If clienteID <> txtid_cliente.Text Then
            MessageBox.Show("Escriba de Nuevo el Código del Cliente y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            pbid_cliente.Visible = True
            Exit Sub
        End If

        If Val(txtpuntos.Text) > Round(SA, 2) Then
            MessageBox.Show("Los Puntos a Debitar NO Pueden ser Mayores a los Disponibles", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtpuntos.Focus()
            pbpuntos.Visible = True
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If



        Dim cmd As New SqlCommand
        cmd.Connection = CONN1
        Dim sql As String


        sql = "insert into Puntos_Debito (fecha,id_cliente,referencia,id_usuario) values (" + _
        "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
        txtid_cliente.Text + "," + _
        "'" + txtreferencia.Text + "'," + _
        USUARIO_ID + ")"

        Dim DebitoID As String
        Dim D As DataTable
        D = Table(sql + " select @@IDENTITY as id_Debito", "")
        DebitoID = D.Rows(0).Item("id_debito").ToString

        Dim PpD As Decimal
        Dim debitado As String
        Dim i As Integer = 0
        PpD = Val(txtpuntos.Text)

        Do While PpD >= 1
            With Facs.Rows(i)
                If .Item("psaldo") >= PpD Then
                    debitado = PpD.ToString
                    PpD = 0
                Else
                    PpD = PpD - .Item("psaldo")
                    debitado = .Item("psaldo").ToString
                End If


                sql = "insert into Puntos_Debito_detalle (id_debito,id_factura,puntos) values (" + _
                DebitoID + "," + _
                .Item("id_factura").ToString + "," + _
                debitado + ")"

                cmd.CommandText = sql
                OpenConn()
                cmd.ExecuteNonQuery()
            End With
            i = i + 1
        Loop

        sql = "insert into Nota_credito (fecha,id_cliente,exento,gravado,piv,observaciones,id_usuario) values (" + _
                "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
                txtid_cliente.Text + "," + _
                txtpuntos.Text + "," + _
                 "0," + _
                "0," + _
                "'Acreditacion Puntos " + EDATE(Date.Today.ToShortDateString) + "'," + _
                USUARIO_ID + ")"

        'cmd.CommandText = sql
        'cmd.ExecuteNonQuery()

        Dim NC As DataTable
        NC = Table(sql + " select @@IDENTITY as id_nota_credito", "")
        NCID = NC.Rows(0).Item("id_nota_credito").ToString

        imprimir()
        Me.Close()

        ' Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub imprimir()
        Try

            Dim rnota_credito As New rpt_Nota_Credito



            rParameterFieldDefinitions = rnota_credito.DataDefinition.ParameterFields

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


            rParameterFieldLocation = rParameterFieldDefinitions.Item("ncid")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Nota de Crédito:   " + NCID
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("cliente")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = txtid_cliente.Text + "-" + lblnombre_cliente.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("fecha")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Fecha: " + Date.Today.ToShortDateString
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("exento")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(Val(txtpuntos.Text), 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("gravado")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "0"
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("iv")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "0"
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("monto")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(txtpuntos.Text, 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("observaciones")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Acreditacion Puntos " + EDATE(Date.Today.ToShortDateString)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("usuario")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "hecho por: " + USUARIO_NOMBRE
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)



            rnota_credito.PrintOptions.PrinterName = "\\estacion06\recibos"
            rnota_credito.PrintToPrinter(1, False, 1, 1)

            'Dim rv As New frm_Report_Viewer
            'rv.crv.ReportSource = rnota_credito
            'rv.Show()

        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try


    End Sub
End Class