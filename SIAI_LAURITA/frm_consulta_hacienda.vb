Public Class frm_consulta_hacienda
    Dim Documento As DataTable
    Dim Dvdocumento As DataView
    Dim TPD As DataTable
    Dim TDD As DataTable
    Dim criterio As String
    Dim tipo As String
    Dim Building As Boolean
    Dim rowc As DataRow
    Dim FIV As Decimal

    Private Sub frm_consulta_documento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CONN1.Close()
        myForms.frm_principal.ToolStrip.Enabled = True
    End Sub
    Private Sub frm_consulta_documento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        OpenConn()
        Building = True
        Documento_crear()
        Building = False
        Filtro()
        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Sub
    Private Sub Filtro()
        ' Try

        criterio = " and factura.fecha>='" + EDATE(dtpdesde.Text) + " 00:00:01' and factura.fecha<='" + EDATE(dtphasta.Text) + " 23:59:59'"
        Dim Factura As DataTable
        Factura = FACMError(criterio)
        Documento_cargar(Factura, 1)

        Dvdocumento = New DataView(Documento)
        Dvdocumento.Sort = "fecha, id_documento"
        dtgdocumento.DataSource = Dvdocumento
        'Catch myerror As Exception
        '(Me.Name, myerror)
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

        Dim cliente As DataColumn = New DataColumn("id_cliente")
        cliente.DataType = System.Type.GetType("System.String")
        Documento.Columns.Add(cliente)

        Dim Monto As DataColumn = New DataColumn("coderror")
        Monto.DataType = System.Type.GetType("System.String")
        Documento.Columns.Add(Monto)

        Dim anulado As DataColumn = New DataColumn("descripcionerror")
        anulado.DataType = System.Type.GetType("System.String")
        Documento.Columns.Add(anulado)

    End Sub

    Private Sub Documento_cargar(ByVal Table As DataTable, ByVal Tipo As Integer)
        '     Try
        Dim rowd As DataRow
        Documento.Rows.Clear()
        Dim z As Integer
        For z = 0 To Table.Rows.Count - 1
            With Table.Rows(z)
                rowd = Documento.NewRow

                rowd("id_documento") = .Item("id_documento")
                rowd("fecha") = .Item("fecha")
                rowd("id_cliente") = .Item("id_cliente")
                rowd("coderror") = .Item("coderror")
                rowd("descripcionerror") = .Item("descripcionerror")
                Documento.Rows.Add(rowd)
            End With
        Next
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub dtpdesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpdesde.ValueChanged
        If Not Building Then Filtro()
    End Sub

    Private Sub dtphasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtphasta.ValueChanged
        If Not Building Then Filtro()
    End Sub

    Private Sub cbtipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Building Then Filtro()
    End Sub
End Class