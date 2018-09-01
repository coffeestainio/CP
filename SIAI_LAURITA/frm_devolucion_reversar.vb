Imports System.Data.SqlClient
Public Class frm_devolucion_reversar
    Dim Dev As DataTable
    Dim Devd As DataTable
    Dim Cliente As DataTable
    Dim F As DataTable
    Dim FD As DataTable

    Public TGravado As Decimal
    Public TExento As Decimal
    Public Tdescuento1 As Decimal
    Public Tdescuento2 As Decimal
    Public Tiv As Decimal
    Public Total As Decimal
    Dim movimiento_ID As String
    Dim PIV As Decimal

    Private Sub txtid_movimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_movimiento.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If Val(txtid_movimiento.Text) = 0 Then
                Me.Close()
            Else
                Identifica_Movimiento()
            End If
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtid_movimiento.Text, False)
        End If
    End Sub

    Public Sub Identifica_Movimiento()
        'Try

        Dev = DEVM(" id_devolucion=" + txtid_movimiento.Text, True, "")

        If Dev.Rows.Count = 0 Then
            MessageBox.Show("Devolución No Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_movimiento.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        With Dev.Rows(0)
            If .Item("anulado") Then
                MessageBox.Show("Devolución Ya Fue Reversada", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_movimiento.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If
            F = FACM("factura.id_factura=" + .Item("id_factura").ToString, False, "")
            piv = F.Rows(0).Item("piv")
            FD = Table("select * from factura_detalle where id_factura=" + .Item("id_factura").ToString + " order by id_Producto", "id_producto")
            Devd = Table("select * from devolucion_detalle where id_devolucion=" + .Item("id_devolucion").ToString + " order by id_producto", "")
            Devd_Completar()


            Cliente = Table("Select nombre from cliente where id_cliente=" + F.Rows(0).Item("id_cliente").ToString, "")
            lblid_cliente.Text = F.Rows(0).Item("id_cliente").ToString + " - " + Cliente.Rows(0).Item("nombre")
            Totales()
            movimiento_ID = txtid_movimiento.Text
            lblfactura.Text = .Item("id_factura").ToString
            lblfecha.Text = .Item("fecha")
            lblmonto.Text = FormatNumber(Total.ToString, 2)
        End With
        '        Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub frm_devolucion_reversar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            myForms.frm_principal.ToolStrip.Enabled = True
            CONN1.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub frm_devolucion_reversar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        If Val(txtid_movimiento.Text) = 0 Then
            MessageBox.Show("Debe Escribir un Número de Devolución", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_movimiento.Focus()
            pbid_movimiento.Visible = True
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        If movimiento_ID <> txtid_movimiento.Text Then
            MessageBox.Show("Escriba de Nuevo el Número de Devolución y Presione Enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_movimiento.Focus()
            pbid_movimiento.Visible = True
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If



        Dim cmd As New SqlCommand
        cmd.Connection = CONN1
        Dim sql As String

        sql = "insert into C_reversion (id_documento,tipo,fecha,id_usuario) values (" + _
        txtid_movimiento.Text + "," + _
        "8" + "," + _
        "'" + EDATE(Date.Today.ToShortDateString) + "'," + _
        USUARIO_ID + ")"

        cmd.CommandText = sql
        OpenConn()
        cmd.ExecuteNonQuery()
        Me.Close()
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub Devd_Completar()

        Dim rowfd As DataRow
        Dim z As Integer
        For z = 0 To Devd.Rows.Count - 1
            With Devd.Rows(z)
                rowfd = FD.Rows.Find(.Item("id_producto"))
                .Item("precio") = rowfd("precio")
                .Item("descuento") = rowfd("descuento")
                .Item("iv") = rowfd("iv")

            End With
        Next

    End Sub

    Public Sub Totales()
        Try
            Dim mf As Decimal
            Dim m As Decimal = 0
            Dim d1 As Decimal = 0
            Dim d2 As Decimal = 0

            Dim productos As Decimal = 0
            TGravado = 0
            TExento = 0
            Tdescuento1 = 0
            Tdescuento2 = 0
            Tiv = 0
            total = 0
            Dim i As Integer

            For i = 0 To Devd.Rows.Count - 1
                With Devd.Rows(i)
                    m = .Item("precio") * .Item("cantidad")
                    d1 = m * (.Item("descuento") / 100)
                    mf = m - d1 - d2
                    If .Item("iv") Then
                        TGravado = TGravado + m
                        Tiv = Tiv + mf * PIV
                    Else
                        TExento = TExento + mf
                    End If
                    Tdescuento1 = Tdescuento1 + d1
                    productos = productos + 1
                End With
            Next i

            total = TGravado + TExento - Tdescuento1 - +Tiv
            
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
End Class