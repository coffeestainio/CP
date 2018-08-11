Imports System.Data.SqlClient
Public Class frm_factura_anular
    
    Dim Fac As DataTable
    Dim FD As DataTable
    Dim Factura_ID As String
    Dim cc As String
    


    Private Sub txtid_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_factura.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_factura.Text) = 0 Then
                Me.Close()
            Else
                Identifica_factura()
            End If
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtid_factura.Text, False)
        End If
    End Sub

    Public Sub Identifica_Factura()
        'Try
        cc = "factura.id_factura=" + txtid_factura.Text
       

        Fac = FACM(cc, True, "")

        If Fac.Rows.Count = 0 Then
            MessageBox.Show("Factura No Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_factura.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        With Fac.Rows(0)
            If .Item("anulado") Then
                MessageBox.Show("Factura Ya Fue Anulada", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_factura.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If
            Dim Recd As DataTable = RECA(txtid_factura.Text)
            If Recd.Rows.Count > 0 Then
                Dim Recibos As String = ""
                Dim k As Integer
                For k = 0 To Recd.Rows.Count - 1
                    Recibos = Recibos + Recd.Rows(k).Item("id_recibo").ToString + " ,"
                Next

                If Recibos <> "" Then
                    MessageBox.Show("Factura Asociada con recibo(s) " + Recibos, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtid_factura.Focus()
                    SendKeys.Send("{home}+{end}")
                    Exit Sub
                End If
            End If

            cc = "devolucion.id_devolucion=" + txtid_factura.Text
           


            Dim Dev As DataTable
            Dev = DEVM(cc, False, "")
            If Dev.Rows.Count > 0 Then
                Dim devs As String = ""
                Dim t As Integer
                For t = 0 To Dev.Rows.Count - 1
                    devs = devs + Dev.Rows(t).Item("id_devolucion").ToString + " ,"
                Next
                MessageBox.Show("Factura Asociada con Devolucion(es) " + devs, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_factura.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If

           

            Dim ncd As DataTable = NCA("id_factura=" + txtid_factura.Text, "")
            If ncd.Rows.Count > 0 Then
                Dim ncs As String = ""
                Dim k As Integer
                For k = 0 To Recd.Rows.Count - 1
                    ncs = ncs + ncd.Rows(k).Item("id_nota_credito").ToString + " ,"
                Next

                If ncs <> "" Then
                    MessageBox.Show("Factura Asociada con Notas Crédito " + ncs, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtid_factura.Focus()
                    SendKeys.Send("{home}+{end}")
                    Exit Sub
                End If
            End If


            'cliente = Table("Select nombre_comercial from cliente where id_cliente=" + .Item("id_cliente").ToString, "")
            lblid_cliente.Text = .Item("id_cliente").ToString + " - " + .Item("nombre")
            Factura_ID = txtid_factura.Text
            lblplazo.Text = .Item("plazo")
            lblfecha.Text = .Item("fecha")
            lblmonto.Text = FormatNumber(.Item("Monto").ToString, 2)
        End With
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        ' End Try
    End Sub

    Private Sub frm_factura_anular_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            myForms.frm_principal.ToolStrip.Enabled = True
            CONN1.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub frm_factura_anular_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            OpenConn()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'Try
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

        Dim cmd As New SqlCommand
        cmd.Connection = CONN1
        Dim sql As String

        sql = "insert into Reversion (id_documento,tipo,fecha,id_usuario) values (" + _
         txtid_factura.Text + "," + _
         "2" + "," + _
          "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
         USUARIO_ID + ")"

        cmd.CommandText = sql
        OpenConn()
        cmd.ExecuteNonQuery()
        '

        sqlquery("delete from tfacs where id_factura = " & txtid_factura.Text)

        FD = Table("select * from factura_detalle where id_factura=" + txtid_factura.Text, "")



        dim p as DataTable

        Dim i As Integer
        For i = 0 To FD.Rows.Count - 1
            With FD.Rows(i)
                p=table("select empaque from producto where id_producto="+.Item("id_producto").ToString ,"")
                if p.rows.count>0 then

                    sql = "update producto set existencia=existencia+" + _
                   IIf(.Item("unidad") = 1, .Item("cantidad").ToString, (.Item("cantidad") * p.Rows(0).Item("empaque")).ToString) + _
                   " where id_producto=" + .Item("id_producto").ToString
                    cmd.CommandText = sql
                    OpenConn()
                    cmd.ExecuteNonQuery()
                End If

            End With
        Next
        Me.Close()
        'Catch myerror As Exception
        '(Me.Name, myerror)
        'End Try
    End Sub

End Class