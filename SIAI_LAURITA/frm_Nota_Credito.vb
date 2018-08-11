Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frm_Nota_Credito

    Dim rParameterDiscreteValue As ParameterDiscreteValue
    Dim rParameterFieldDefinitions As ParameterFieldDefinitions
    Dim rParameterFieldLocation As ParameterFieldDefinition
    Dim rParameterValues As ParameterValues

    Public Cliente As DataTable
    Dim cliente_ID As String
    Dim L As Integer
    Public Formulario As Integer
    Public Fecha As String
    Public NCID As String
    

    Public Sub cliente_Identificar()
        '  Try
        Cliente = Table("select * from cliente where id_cliente=" + txtid_cliente.Text, "")
        If Cliente.Rows.Count = 0 Then
            MessageBox.Show("cliente No Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If
        lblid_cliente.Text = Cliente.Rows(0).Item("nombre")
        cliente_ID = txtid_cliente.Text     
        SendKeys.Send("{tab}")
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'Try
        If Val(txtid_cliente.Text) = 0 Then
            MessageBox.Show("Debe Escribir un Número de Factura", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_cliente.Focus()
            pbid_cliente.Visible = True
            pbid_cliente.Visible = True
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        Monto_Actualizar()

        If Val(lblmonto.Text) = 0 Then
            MessageBox.Show("Debe Digitar algún Valor", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If


        If Val(txtgravado.Text) > 0 And Val(txtiv.Text) = 0 Then
            MessageBox.Show("Debe Digitar el porcentaje correspondiente al Impuesto de Ventas", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtiv.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If


        Dim cmd As New SqlCommand
        cmd.Connection = CONN1
        Dim sql As String

        'sqlquery("insert into tfacs (t_facs)")

        sql = "insert into nota_credito (fecha,exento,gravado,piv,id_cliente,observaciones,id_usuario) values (" + _
                "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
        Val(txtexento.Text).ToString + "," + _
        Val(txtgravado.Text).ToString + "," + _
        (Val(txtiv.Text) / 100).ToString + "," + _
        Cliente.Rows(0).Item("id_cliente").ToString + "," + _
        "'" + txtobservaciones.Text + "'," + _
        USUARIO_ID + ")"

        Dim NC As DataTable
        NC = Table(sql + " select @@IDENTITY as id_nota_credito", "")
        NCID = NC.Rows(0).Item("id_nota_credito")

        imprimir()
        Me.Close()
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub


    Private Sub txtid_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_cliente.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_cliente.Text) = 0 Then
                Me.Close()
            Else
                cliente_Identificar()
            End If
        Else

            If Not IsNumeric(Convert.ToChar(e.KeyChar)) And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                BUSQUEDA = "Nota_credito"

                Dim cliente_buscar As New frm_cliente_buscar
                cliente_buscar.Owner = Me
                cliente_buscar.Show()
                cliente_buscar.txtbuscar_cliente.Text = e.KeyChar

            Else

                e.Handled = Numerico(Asc(e.KeyChar), txtid_cliente.Text, False)
            End If
        End If
    End Sub

    Private Sub txtid_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_cliente.TextChanged

    End Sub

    
    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub txtexento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtexento.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Monto_Actualizar()
            SendKeys.Send("{tab}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtexento.Text, True)
        End If
    End Sub

    Private Sub txtmonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtexento.TextChanged

    End Sub

    Private Sub txtobservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtobservaciones.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            btnaceptar.Focus()
        Else
            e.Handled = chk(Asc(e.KeyChar))
        End If
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
            rParameterDiscreteValue.Value = txtid_cliente.Text + "-" + lblid_cliente.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("fecha")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = "Fecha: " + IIf(Consulta, Fecha, Date.Today.ToShortDateString)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("exento")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(Val(txtexento.Text), 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("gravado")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = FormatNumber(Val(txtgravado.Text), 2)
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("iv")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = lbliv.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)


            rParameterFieldLocation = rParameterFieldDefinitions.Item("monto")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = lblmonto.Text
            rParameterValues.Add(rParameterDiscreteValue)
            rParameterFieldLocation.ApplyCurrentValues(rParameterValues)

            rParameterFieldLocation = rParameterFieldDefinitions.Item("observaciones")
            rParameterValues = rParameterFieldLocation.CurrentValues
            rParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            rParameterDiscreteValue.Value = txtobservaciones.Text
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

    Private Sub frm_Nota_Credito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myForms.frm_principal.ToolStrip.Enabled = True
        CONN1.Close()
    End Sub

    

    Private Sub frm_Nota_Credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Consulta Then OpenConn()
    End Sub
    Public Sub Monto_Actualizar()
        lbliv.Text = FormatNumber(Val(txtgravado.Text) * Val(txtiv.Text) / 100, 2)
        lblmonto.Text = FormatNumber(Val(txtexento.Text) + Val(txtgravado.Text) + (Val(txtgravado.Text) * Val(txtiv.Text) / 100), 2)
    End Sub

    Private Sub txtgravado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgravado.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Monto_Actualizar()
            SendKeys.Send("{tab}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtgravado.Text, True)
        End If
    End Sub

    Private Sub txtgravado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgravado.TextChanged

    End Sub

    Private Sub txtiv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtiv.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Monto_Actualizar()
            SendKeys.Send("{tab}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtiv.Text, True)
        End If
    End Sub

    Private Sub txtiv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiv.TextChanged

    End Sub

    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        imprimir()
    End Sub
End Class