Imports System.Data.sqlclient
Imports System.io
Imports System.math


Module Module1


    Public Const SERVER As String = "server=Server01\SQLExpress;User ID=sa;password=SQLCP123456!;Database=CP2;Persist Security Info=True"
    'Public Const SERVER As String = "Server=tcp:cp2.database.windows.net,1433;Initial Catalog=CP2_Test2;Persist Security Info=False;User ID=CPSQL;Password=SQLCP12345!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
    'Public Const SERVER As String = "server=Server01\SQLExpress;User ID=sa;password=SQLCP123456!;Database=CP2Viejo;Persist Security Info=True"
    'Public Const SERVER As String = "server=SERVER01\SQL2017;User ID=sa;password=SQLCP12345!;Database=CP;Persist Security Info=True"


    Public Const PRINTER As String = "S1"

    Public Const Version As String = "4.3.09.04 Facturacion con Hacienda"

    Public Const NEGOCIO As String = "COMERCIAL POZOS S.A."

    Public Const CJ As String = "3-101-159911"
    Public Const WEB As String = " "
    Public Const TELEFONO As String = "2282-6030  2282-4516"
    Public Const DIRECCION As String = "100 Sur Iglesia Pozos, Santa Ana"

    Public Const CEDULA = "003101159911"

    Public Prst(4) As String

    Public ID_ESTACION As String
    Public Path As String
    Public CONN1 As SqlConnection
    Dim cmd1 As New SqlCommand

    Public USUARIO_NOMBRE As String
    Public USUARIO_NIVEL As Integer
    Public USUARIO_ID As String
    Public BUSQUEDA As String
    Public Consulta As Boolean

    Friend Sub Tsort(ByRef DT As DataTable, ByVal OrderBy As String)
        Dim DTn As New DataTable
        Dim Rows() As DataRow
        Dim Row As DataRow

        DTn = DT.Clone
        Rows = DT.Select("", OrderBy)
        For Each Row In Rows
            DTn.ImportRow(Row)
        Next

        DT = DTn
    End Sub


    Public Sub OpenConn()
        If CONN1.State = ConnectionState.Closed Then
            CONN1.Open()
        End If
    End Sub

    Public Sub EjectuarFacturacionElectronica()
        Process.Start("cmd", "/c dotnet H:/FacElecCP/FacElec.dll")
    End Sub

    Public Sub dstable(ByVal dataset As DataSet, ByVal tabla_nombre As String, ByVal sql As String, ByVal Pk As String)
        Try
            Dim dr As SqlDataReader
            Dim drcmd As SqlCommand
            OpenConn()
            drcmd = New SqlCommand(sql, CONN1)
            dr = drcmd.ExecuteReader()
            Dim schemaTable As DataTable = dr.GetSchemaTable()
            Dim dataTable As DataTable = New DataTable(tabla_nombre)
            Dim intCounter As Integer

            For intCounter = 0 To schemaTable.Rows.Count - 1
                Dim dataRow As DataRow = schemaTable.Rows(intCounter)
                Dim columnName As String = CType(dataRow("ColumnName"), String)
                Dim column As DataColumn = New DataColumn(columnName, CType(dataRow("DataType"), Type))
                dataTable.Columns.Add(column)
            Next

            If Pk <> "" Then dataTable.PrimaryKey = New DataColumn() {dataTable.Columns(Pk)}
            dataset.Tables.Add(dataTable)

            While dr.Read()

                Dim dataRow As DataRow = dataTable.NewRow()

                For intCounter = 0 To dr.FieldCount - 1
                    dataRow(intCounter) = dr.GetValue(intCounter)
                Next
                dataTable.Rows.Add(dataRow)
            End While
            dr.Close()
        Catch myerror As Exception
            ONEX("dsTable", myerror)
        End Try
    End Sub

    Public Function EDATE(ByVal fecha As String) As String
        'Try
        Return fecha.Substring(3, 2) + "/" + fecha.Substring(0, 2) + "/" + fecha.Substring(6, 4)
        'Catch myerror As Exception
        'ONEX("edate", myerror)
        'Return "01/01/2000"
        'End Try
    End Function


    Public Sub AddParams(ByVal cmd As SqlCommand, ByVal ParamArray cols() As String)
        Try
            Dim col As String
            For Each col In cols
                cmd.Parameters.Add("@" + col, SqlDbType.Char, 0, col)
            Next
        Catch myerror As SqlException
            ONEX("AddParams", myerror)
        End Try
    End Sub

    Public Function FACS2(ByVal C As String, ByVal Pk As String) As DataTable
        Dim Sld As Decimal
        Dim DTA As DataTable = FACS(C, Pk)
        'Dim DTB As DataTable = Table("select * from tfacs where " & C, Pk)
        'Dim fac As DataTable

        'Dim Rows() As DataRow
        'Dim Row As DataRow

        'fac = DTA.Clone

        'Rows = DTA.Select("", "")
        'For Each Row In Rows
        '    fac.ImportRow(Row)
        'Next

        'Rows = DTB.Select("", "")
        'For Each Row In Rows
        '    Sld = Round(Row.Item("saldo"), 2)
        '    If Sld > 0 Then
        '        fac.ImportRow(Row)
        '    End If
        'Next

        Return DTA

    End Function


    Public Function FACS(ByVal C As String, ByVal Pk As String) As DataTable
        'Try
        Dim Fac As DataTable
        Dim Facx As DataTable
        Dim RecD As DataTable
        Dim Nc As DataTable

        Dim Trec As Decimal
        Dim TNC As Decimal
        Dim Sld As Decimal

        Dim i As Integer
        Dim j As Integer

        Fac = FAC_S()
        Facx = FACM1(C + IIf(C = "", "", " and ") + " factura.fecha>='01/01/2011'", False, Pk) 'para cp = edate(date.today)

        'Dim xSaldo As DataColumn = New DataColumn("Saldo")
        'xSaldo.DataType = System.Type.GetType("System.Decimal")
        'xSaldo.DefaultValue = 0
        'Facx.Columns.Add(xSaldo)

        For i = 0 To Facx.Rows.Count - 1
            With Facx.Rows(i)
                '        'Recibo
                '        Trec = 0.0
                '        RecD = RECA(.Item("id_factura").ToString)
                '        For j = 0 To RecD.Rows.Count - 1
                '            With RecD.Rows(j)
                '                Trec = Trec + .Item("abono")
                '            End With
                '        Next j

                '        'Nota credito
                '        TNC = 0.0
                '        Nc = NCA("id_factura=" + .Item("id_factura").ToString, "")
                '        For j = 0 To Nc.Rows.Count - 1
                '            TNC = TNC + Nc.Rows(j).Item("aplicado")
                '        Next j

                'Sld = Round(.Item("monto"), 2) - Trec - TNC

                If .Item("saldo") > 0.1 Then
                    Fac.ImportRow(Facx.Rows(i))
                End If
            End With
        Next i


        Return Fac

        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Function

    Public Function FACM1(ByVal C As String, ByVal Anulados As Boolean, ByVal PK As String) As DataTable
        Dim sql As String
        sql = "SELECT Factura.Id_Factura, Factura.FECHA, factura.fecha+factura.plazo as vence,Factura.Id_Cliente, CLIENTE.NOMBRE, factura.id_agente,Factura.Plazo, factura.piv," + _
        "SUM(CASE WHEN factura_detalle.iv = 0 THEN (Factura_Detalle.Precio) * Factura_Detalle.CANTIDAD " + _
        " ELSE  0 END) AS exento," + _
        "SUM(CASE WHEN factura_detalle.iv = 1 THEN (Factura_Detalle.Precio) * Factura_Detalle.CANTIDAD " + _
        "ELSE  0 END) AS gravado, " + _
        "SUM((Factura_Detalle.Precio) * Factura_Detalle.CANTIDAD * (1 - Factura_Detalle.Descuento)) AS subtotal," + _
        "SUM(CASE WHEN factura_detalle.iv = 1 THEN ((Factura_Detalle.Precio) * Factura_Detalle.CANTIDAD) * FACTURA.PIV " + _
        "ELSE 0 END) AS IV," + _
        "SUM(CASE WHEN factura_detalle.iv = 0 THEN (Factura_Detalle.Precio) * Factura_Detalle.CANTIDAD * (1 - Factura_Detalle.Descuento) " + _
        "ELSE (Factura_Detalle.Precio)* factura_detalle.cantidad * (1 + factura.piv) * (1 - Factura_Detalle.Descuento) END) AS MONTO, " + _
        "SUM(CASE WHEN factura_detalle.iv = 0 THEN (Factura_Detalle.Precio) *  Factura_Detalle.CANTIDAD * (1 - Factura_Detalle.Descuento) " + _
        "ELSE (Factura_Detalle.Precio)* factura_detalle.cantidad * (1 + factura.piv) * (1 - Factura_Detalle.Descuento) END) " + _
        " - (select isnull(sum (R.abono),0) from recibo_Detalle as R where R.id_Factura = FACTURA.id_factura " + _
        " and R.id_Recibo not in (select id_documento as id_recibo from reversion where tipo = 4)) " + _
        " - (select isnull(sum (NC.aplicado),0) from nota_credito_Detalle as NC where NC.id_Factura = FACTURA.id_factura) as SALDO, " + _
        " CASE WHEN NOT EXISTS (SELECT * FROM Reversion WHERE reversion.Tipo = 2 AND reversion.id_documento = factura.id_factura) THEN 0 ELSE 1 END AS anulado" + _
        " FROM Factura INNER JOIN Factura_Detalle ON Factura.Id_Factura = Factura_Detalle.Id_Factura " + _
        IIf(Anulados, "", " and NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 2 and reversion.id_documento=factura.id_factura)") + _
        " INNER JOIN CLIENTE ON Factura.Id_Cliente = CLIENTE.Id_Cliente " + _
          IIf(C = "", "", " and " + C) + _
        " GROUP BY Factura.Id_Factura, Factura.FECHA, Factura.Id_Cliente, CLIENTE.NOMBRE, factura.id_agente,Factura.Plazo, factura.piv"

        Dim Tbl As DataTable = Table(sql, PK)
        Return Tbl
    End Function



    Public Function FACMError(ByVal C As String) As DataTable
        Dim sql As String
        sql = "select id_factura id_documento, fecha, id_cliente, coderror, descripcionerror from factura where sincronizada = 1 and Coderror <> 'Error:00' " + _
        C

        Dim Tbl As DataTable = Table(sql, "")
        Return Tbl
    End Function


    Public Function FACM(ByVal C As String, ByVal Anulados As Boolean, ByVal PK As String) As DataTable
        Dim sql As String
        sql = "SELECT Factura.Id_Factura, Factura.FECHA, factura.fecha+factura.plazo as vence,Factura.Id_Cliente, CLIENTE.NOMBRE, factura.id_agente,Factura.Plazo, factura.piv, factura.claveNumerica, factura.numConsecutivo, factura.clienteTributa, " + _
        "SUM(CASE WHEN factura_detalle.iv = 0 THEN (Factura_Detalle.Precio) * Factura_Detalle.CANTIDAD " + _
        " ELSE  0 END) AS exento," + _
        "SUM(CASE WHEN factura_detalle.iv = 1 THEN (Factura_Detalle.Precio) * Factura_Detalle.CANTIDAD " + _
        "ELSE  0 END) AS gravado, " + _
        "SUM((Factura_Detalle.Precio) * Factura_Detalle.CANTIDAD) AS subtotal," + _
        "SUM(CASE WHEN factura_detalle.iv = 1 THEN (Factura_Detalle.Precio) * Factura_Detalle.CANTIDAD * FACTURA.PIV " + _
        "ELSE 0 END) AS IV," + _
        "SUM(CASE WHEN factura_detalle.iv = 0 THEN (Factura_Detalle.Precio) * Factura_Detalle.CANTIDAD " + _
        "ELSE (Factura_Detalle.Precio)* factura_detalle.cantidad * (1 + factura.piv) END) AS MONTO, " + _
        " CASE WHEN NOT EXISTS (SELECT * FROM Reversion WHERE reversion.Tipo = 2 AND reversion.id_documento = factura.id_factura) THEN 0 ELSE 1 END AS anulado" + _
        " FROM Factura INNER JOIN Factura_Detalle ON Factura.Id_Factura = Factura_Detalle.Id_Factura " + _
        " INNER JOIN CLIENTE ON Factura.Id_Cliente = CLIENTE.Id_Cliente " + _
        IIf(Anulados, "", " and NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 2 and reversion.id_documento=factura.id_factura)") + _
        IIf(C = "", "", " and " + C) + _
        " GROUP BY Factura.Id_Factura, Factura.FECHA, Factura.Id_Cliente, CLIENTE.NOMBRE, factura.id_agente,Factura.Plazo, factura.piv, factura.claveNumerica, factura.numConsecutivo, factura.clienteTributa"


        Dim Tbl As DataTable = Table(sql, PK)
        Return Tbl
    End Function






    Public Function FAC_S() As DataTable
        Dim T As DataTable = New DataTable("T")

        Dim id_factura As DataColumn = New DataColumn("id_factura")
        id_factura.DataType = System.Type.GetType("System.Int32")
        id_factura.DefaultValue = 0
        T.Columns.Add(id_factura)

        Dim fecha As DataColumn = New DataColumn("fecha")
        fecha.DataType = System.Type.GetType("System.DateTime")
        T.Columns.Add(fecha)

        Dim vence As DataColumn = New DataColumn("vence")
        vence.DataType = System.Type.GetType("System.DateTime")
        T.Columns.Add(vence)


        Dim id_cliente As DataColumn = New DataColumn("id_cliente")
        id_cliente.DataType = System.Type.GetType("System.Int32")
        id_cliente.DefaultValue = 0
        T.Columns.Add(id_cliente)


        Dim nombre As DataColumn = New DataColumn("nombre")
        nombre.DataType = System.Type.GetType("System.String")
        nombre.DefaultValue = ""
        T.Columns.Add(nombre)


        Dim id_agente As DataColumn = New DataColumn("id_agente")
        id_agente.DataType = System.Type.GetType("System.Int32")
        id_agente.DefaultValue = 0
        T.Columns.Add(id_agente)

        Dim plazo As DataColumn = New DataColumn("plazo")
        plazo.DataType = System.Type.GetType("System.Int32")
        plazo.DefaultValue = 0
        T.Columns.Add(plazo)


        Dim exento As DataColumn = New DataColumn("exento")
        exento.DataType = System.Type.GetType("System.Decimal")
        exento.DefaultValue = 0
        T.Columns.Add(exento)

        Dim gravado As DataColumn = New DataColumn("gravado")
        gravado.DataType = System.Type.GetType("System.Decimal")
        gravado.DefaultValue = 0
        T.Columns.Add(gravado)

        Dim iv As DataColumn = New DataColumn("iv")
        iv.DataType = System.Type.GetType("System.Decimal")
        iv.DefaultValue = 0
        T.Columns.Add(iv)


        Dim subtotal As DataColumn = New DataColumn("subtotal")
        subtotal.DataType = System.Type.GetType("System.Decimal")
        subtotal.DefaultValue = 0
        T.Columns.Add(subtotal)

        Dim monto As DataColumn = New DataColumn("monto")
        monto.DataType = System.Type.GetType("System.Decimal")
        monto.DefaultValue = 0
        T.Columns.Add(monto)

        Dim piv As DataColumn = New DataColumn("piv")
        piv.DataType = System.Type.GetType("System.Decimal")
        piv.DefaultValue = 0
        T.Columns.Add(piv)

        Dim anulado As DataColumn = New DataColumn("anulado")
        anulado.DataType = System.Type.GetType("System.Boolean")
        anulado.DefaultValue = 0
        T.Columns.Add(anulado)

        Dim Saldo As DataColumn = New DataColumn("Saldo")
        Saldo.DataType = System.Type.GetType("System.Decimal")
        Saldo.DefaultValue = 0
        T.Columns.Add(Saldo)

        T.PrimaryKey = New DataColumn() {T.Columns("id_factura")}

        Return T
    End Function


    Public Function FACP(ByVal C1 As String, ByVal C2 As String, ByVal C4 As String) As DataTable
        Dim sql As String
        sql = "SELECT Factura_Detalle.Id_Producto, Producto.NOMBRE, Producto.EMPAQUE, Factura.Id_Cliente, CLIENTE.NOMBRE AS cliente_nombre, " + _
        "SUM(CASE WHEN factura_detalle.unidad = 1 THEN Factura_Detalle.CANTIDAD " + _
        "WHEN factura_detalle.unidad > 1 THEN factura_detalle.cantidad * producto.empaque END) AS cantidad," + _
        "SUM(Factura_Detalle.CANTIDAD * Factura_Detalle.Precio) AS monto," + _
        "CASE WHEN PRODUCTO.PRESENTACION = 1 THEN 'Und' WHEN PRODUCTO.PRESENTACION = 2 THEN 'Caj' WHEN PRODUCTO.PRESENTACION = 3 THEN " + _
        "'Blt' WHEN PRODUCTO.PRESENTACION = 4 THEN 'Pqt' END AS presentacion_nombre " + _
        " FROM Factura INNER JOIN Factura_Detalle ON Factura.Id_Factura = Factura_Detalle.Id_Factura and NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 2 and reversion.id_documento=factura.id_factura)" + IIf(C1 = "", "", " and ") + C1 + _
        " INNER JOIN CLIENTE ON Factura.Id_Cliente = CLIENTE.Id_Cliente " + C4 + " INNER JOIN " + _
        "Producto ON Factura_Detalle.Id_Producto = Producto.Id_Producto " + IIf(C2 = "", "", " and ") + C2 + _
        " GROUP BY Factura.Id_Cliente, CLIENTE.NOMBRE, Factura_Detalle.Id_Producto, Producto.NOMBRE, Producto.EMPAQUE, Producto.Presentacion " + _
        " ORDER BY Factura.Id_Cliente, Factura_Detalle.Id_Producto "

        Dim Tbl As DataTable = Table(sql, "")
        Return Tbl
    End Function

    Public Function NCA(ByVal C As String, ByVal Pk As String) As DataTable
        'Try
        Dim SQL As String
        Dim NCD As DataTable
        SQL = "select * from nota_credito_detalle where " + C

        NCD = Table(SQL, Pk)
        Return NCD
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Function


    Public Function RECA(ByVal C As String) As DataTable
        Dim sql As String
        sql = "SELECT Recibo_Detalle.id_recibo, Recibo_Detalle.abono, Recibo.fecha" + _
        " FROM Recibo_Detalle INNER JOIN Recibo ON Recibo_Detalle.id_recibo = Recibo.id_recibo" + _
        " and NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 4 and reversion.id_documento=recibo.id_recibo)" + _
        " AND Recibo_Detalle.id_factura =" + C

        Dim RED As DataTable = Table(sql, "")
        Return RED
    End Function




    Public Function NCM(ByVal C As String, ByVal Anulados As Boolean, ByVal Pk As String) As DataTable
        Dim sql As String
        Dim tbl As DataTable
        sql = "select nota_credito.id_Nota_credito,nota_credito.fecha,nota_credito.id_cliente,nota_credito.gravado,nota_credito.exento,nota_credito.piv,nota_credito.observaciones," + _
        "nota_credito.gravado*nota_credito.piv as iv,nota_credito.exento+nota_credito.gravado+(nota_credito.gravado*nota_credito.piv) as monto," + _
        "cliente.nombre,  " + _
        "CASE WHEN NOT EXISTS (SELECT * FROM Reversion WHERE reversion.Tipo = 6 AND reversion.id_documento = nota_credito.id_nota_credito) THEN 0 ELSE 1 END AS anulado" + _
        " FROM nota_credito INNER JOIN cliente ON nota_credito.Id_cliente = cliente.Id_cliente " + _
        IIf(Anulados, "", " and NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 6 and reversion.id_documento=nota_credito.id_nota_credito)") + _
        IIf(C = "", "", " and " + C)

        tbl = Table(sql, "")
        Return tbl
    End Function


    Public Function NCDIS(ByVal C As String, ByVal Pk As String) As DataTable
        'Try
        Dim NC As DataTable
        Dim sql As String

        sql = "SELECT * FROM Nota_Credito WHERE " + _
        " NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 6 and reversion.id_documento=nota_credito.id_nota_credito)" + _
        " and NOT EXISTS (SELECT * FROM nota_credito_detalle  WHERE nota_credito_detalle.id_nota_credito = nota_credito.id_nota_credito)" + _
        IIf(C = "", "", " And " + C)

        NC = Table(sql, Pk)

        Dim monto As DataColumn = New DataColumn("monto")
        monto.DataType = System.Type.GetType("System.Decimal")
        monto.Expression = "exento + gravado * (1 + piv)"
        NC.Columns.Add(monto)

        Return NC
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Function


    Public Function DEVP(ByVal C1 As String, ByVal C2 As String, ByVal C3 As String, ByVal C4 As String) As DataTable
        Dim sql As String
        sql = "SELECT devolucion.fecha,devolucion_Detalle.Id_Producto, producto.nombre,producto.empaque,devolucion_detalle.cantidad*-1 as cantidad," + _
        "devolucion_detalle.cantidad*(factura_detalle.precio/producto.empaque-factura_detalle.precio/producto.empaque*factura_detalle.descuento)*-1 as monto, " + _
        "devolucion.id_cliente,cliente.nombre as cliente_nombre" + _
        " FROM devolucion INNER JOIN devolucion_Detalle ON devolucion.Id_devolucion = devolucion_Detalle.Id_devolucion" + _
        " and NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 8 and reversion.id_documento=devolucion.id_devolucion)" + _
         IIf(C1 = "", "", " And " + C1) + _
        " INNER JOIN FACTURA_DETALLE ON devolucion.Id_factura = FACTURA_DETALLE.id_factura and factura_detalle.id_producto=devolucion_detalle.id_producto " + _
        " INNER JOIN CLIENTE ON devolucion.Id_Cliente = cliente.id_cliente " + C4 + _
        " INNER JOIN Producto ON devolucion_Detalle.Id_Producto = Producto.Id_producto" + IIf(C2 = "", "", " and " + C2) + _
        " INNER JOIN FACTURA ON devolucion.Id_FACTURA = FACTURA.id_FACTURA " + IIf(C3 = "", "", " and ") + C3

        Dim Tbl As DataTable = Table(sql, "")

        Return Tbl
    End Function



    Public Function chk(ByVal k As Integer) As Boolean
        Try
            If k = 39 Then
                chk = True
                Exit Function
            End If
        Catch myerror As SqlException
            ONEX("chk", myerror)
        End Try
    End Function


    Public Function DEVM(ByVal C As String, ByVal Anulados As Boolean, ByVal Pk As String) As DataTable


        'Try

        Dim DTgravado As Decimal
        Dim DTexento As Decimal
        Dim DTiv As Decimal
        Dim DTdescuento As Decimal

        Dim TEX As Decimal
        Dim TGA As Decimal
        Dim TIV As Decimal

        Dim m As Decimal
        Dim mf As Decimal
        Dim d As Decimal


        Dim Dev As DataTable
        Dim DevD As DataTable
        Dim Fac As DataTable
        Dim FacD As DataTable
        Dim rowfd As DataRow

        Dim i As Integer
        Dim j As Integer
        Dim sql As String

        sql = "select devolucion.id_devolucion,devolucion.fecha,devolucion.id_cliente,devolucion.id_factura,devolucion.id_nota_credito,cliente.nombre, " + _
        " CASE WHEN NOT EXISTS (SELECT * FROM Reversion WHERE reversion.Tipo = 8 AND reversion.id_documento = devolucion.id_devolucion) THEN 0 ELSE 1 END AS anulado" + _
        " from devolucion inner join cliente on devolucion.id_cliente=cliente.id_cliente " + _
        IIf(C = "", "", " where " + C) + _
        IIf(Anulados, "", " and NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 8 and reversion.id_documento=devolucion.id_devolucion)")


        Dev = Table(sql, Pk)
        Dim exento As DataColumn = New DataColumn("exento")
        exento.DataType = System.Type.GetType("System.Decimal")
        exento.DefaultValue = 0
        Dev.Columns.Add(exento)

        Dim gravado As DataColumn = New DataColumn("gravado")
        gravado.DataType = System.Type.GetType("System.Decimal")
        gravado.DefaultValue = 0
        Dev.Columns.Add(gravado)

        Dim iv As DataColumn = New DataColumn("iv")
        iv.DataType = System.Type.GetType("System.Decimal")
        iv.DefaultValue = 0
        Dev.Columns.Add(iv)

        Dim Monto As DataColumn = New DataColumn("Monto")
        Monto.DataType = System.Type.GetType("System.Decimal")
        Monto.DefaultValue = 0
        Dev.Columns.Add(Monto)


        For i = 0 To Dev.Rows.Count - 1
            With Dev.Rows(i)

                DTgravado = 0.0
                DTexento = 0.0
                DTdescuento = 0.0
                DTiv = 0.0
                TEX = 0
                TGA = 0
                TIV = 0

                DevD = Table("select * from devolucion_detalle where id_devolucion=" + .Item("id_devolucion").ToString + " order by id_producto", "")


                Dim ddiv As DataColumn = New DataColumn("ddiv")
                ddiv.DataType = System.Type.GetType("System.Boolean")
                DevD.Columns.Add(ddiv)

                FacD = Table("select * from factura_detalle where id_factura=" + .Item("id_factura").ToString, "id_producto")


                For j = 0 To DevD.Rows.Count - 1
                    With DevD.Rows(j)
                        rowfd = FacD.Rows.Find(.Item("id_producto"))
                        .Item("precio") = rowfd("precio")
                        .Item("descuento") = rowfd("descuento")
                        .Item("ddiv") = rowfd("iv")

                        m = 0
                        mf = 0
                        d = 0


                        m = .Item("precio") * .Item("cantidad")
                        d = m * (.Item("descuento"))
                        mf = m - d
                        If .Item("ddiv") Then
                            DTgravado = DTgravado + mf
                            Dim l As String = Dev.Rows(i).Item("id_factura").ToString
                            Fac = Table("select piv from factura where factura.id_factura=" + Dev.Rows(i).Item("id_factura").ToString, "")
                            DTiv = DTiv + mf * Fac.Rows(0).Item("PIV")

                            TGA = TGA + mf
                            TIV = TIV + mf * Fac.Rows(0).Item("PIV")
                        Else
                            DTexento = DTexento + mf

                            TEX = TEX + mf
                        End If
                        DTdescuento = DTdescuento + d
                    End With
                Next j

                .Item("exento") = TEX
                .Item("gravado") = TGA
                .Item("iv") = TIV
                .Item("monto") = DTexento + DTgravado + DTiv
            End With
        Next i
        Return Dev
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)

        'End Try
    End Function
    Public Function RECM(ByVal C As String, ByVal ANULADOS As Boolean, ByVal PK As String) As DataTable

        Dim sql As String

        sql = "SELECT RECIBO.Id_recibo, RECIBO.FECHA, RECIBO.referencia,RECIBO.Id_Cliente, CLIENTE.NOMBRE,RECIBO.forma_pago," + _
        " SUM(RECIBO_DETALLE.abono) as monto," + _
        " CASE WHEN NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 4 and reversion.id_documento=recibo.id_recibo) THEN 0 ELSE 1 END AS anulado" + _
        " FROM RECIBO INNER JOIN Recibo_Detalle ON RECIBO.Id_recibo = recibo_Detalle.Id_recibo" + _
        IIf(ANULADOS, "", " and NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 4 and reversion.id_documento=recibo.id_recibo") + _
        IIf(C = "", "", " and " + C) + _
        " INNER JOIN CLIENTE ON RECIBO.Id_Cliente = cliente.id_cliente " + _
        " GROUP BY RECIBO.Id_recibo, RECIBO.FECHA, RECIBO.referencia,RECIBO.Id_Cliente, CLIENTE.NOMBRE, RECIBO.forma_pago"

        Dim Tbl As DataTable = Table(sql, PK)
        Return Tbl
    End Function




    Public Function FACPTS(ByVal c As String, ByVal anulados As Boolean) As DataTable
        Dim sql As String
        sql = "SELECT     Factura.Id_Factura, Factura.FECHA, Factura.Id_Cliente, CLIENTE.NOMBRE, factura.id_agente,Factura.Plazo, factura.piv, " + _
        "SUM(CASE WHEN factura_detalle.iv = 0 THEN Factura_Detalle.Precio * Factura_Detalle.CANTIDAD WHEN factura_detalle.iv = 1 THEN factura_detalle.precio* 0 END) AS exento," + _
        "SUM(CASE WHEN factura_detalle.iv = 1 THEN Factura_Detalle.Precio * Factura_Detalle.CANTIDAD WHEN factura_detalle.iv = 0 THEN factura_detalle.precio * 0 END) AS gravado, " + _
        "SUM(Factura_Detalle.Precio * Factura_Detalle.CANTIDAD) AS subtotal," + _
        "SUM(CASE WHEN factura_detalle.iv = 1 THEN Factura_Detalle.Precio * Factura_Detalle.CANTIDAD * FACTURA.PIV WHEN factura_detalle.iv = 0 THEN factura_detalle.precio* 0 END) AS IV," + _
        "SUM(CASE WHEN factura_detalle.iv = 0 THEN Factura_Detalle.Precio * Factura_Detalle.CANTIDAD WHEN factura_detalle.iv = 1 THEN factura_detalle.precio* factura_detalle.cantidad * (1 + factura.piv) END) AS MONTO, " + _
        "SUM(factura_detalle.precio*factura_detalle.cantidad*factura_detalle.descuento) AS Puntos" + _
        " FROM Factura INNER JOIN Factura_Detalle ON Factura.Id_Factura = Factura_Detalle.Id_Factura and NOT EXISTS (SELECT * FROM Reversion  WHERE reversion.Tipo = 2 and reversion.id_documento=factura.id_factura)" + IIf(c = "", "", "and " + c) + _
        " INNER JOIN CLIENTE ON Factura.Id_Cliente = CLIENTE.Id_Cliente " + _
        " GROUP BY Factura.Id_Factura, Factura.FECHA, Factura.Id_Cliente, CLIENTE.NOMBRE, factura.id_agente,Factura.Plazo, factura.piv" + _
        " ORDER BY Factura.Id_Factura "

        Dim Tbl As DataTable = Table(sql, "")
        Return Tbl

    End Function




    Public Function FACPS(ByVal C As String) As DataTable

        'Try

        Dim Fac As DataTable
        Dim Facx As DataTable
        Dim Deb As DataTable


        Dim i As Integer
        Dim TDeb As Decimal

        Fac = FACPTS("factura.id_factura=0", False)

        Dim psaldo As DataColumn = New DataColumn("psaldo")
        psaldo.DataType = System.Type.GetType("System.Decimal")
        psaldo.DefaultValue = 0
        Fac.Columns.Add(psaldo)


        Facx = FACPTS(C, False)

        Dim xpsaldo As DataColumn = New DataColumn("psaldo")
        xpsaldo.DataType = System.Type.GetType("System.Decimal")
        xpsaldo.DefaultValue = 0
        Facx.Columns.Add(xpsaldo)


        For i = 0 To Facx.Rows.Count - 1
            With Facx.Rows(i)
                Dim sql As String
                sql = "SELECT     Puntos_Debito_Detalle.id_factura, SUM(Puntos_Debito_Detalle.puntos) AS TPuntos" + _
                " FROM Puntos_Debito INNER JOIN" + _
                " Puntos_Debito_Detalle ON Puntos_Debito.ID_Debito = Puntos_Debito_Detalle.id_Debito AND Puntos_Debito.anulado = 0 AND" + _
                " Puntos_Debito_Detalle.id_factura =" + .Item("id_factura").ToString + _
                " GROUP BY Puntos_Debito_Detalle.id_factura"
                Deb = Table(sql, "")


                'Debito
                If Deb.Rows.Count > 0 Then

                    TDeb = Deb.Rows(0).Item("tpuntos")
                Else
                    TDeb = 0
                End If


                .Item("Psaldo") = Round(.Item("puntos"), 2) - TDeb

                If .Item("Psaldo") > 0 Then Fac.ImportRow(Facx.Rows(i))
            End With
        Next

        Return Fac

        'Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        'End Try
    End Function




    Public Function DEBP(ByVal c As String, ByVal anulados As Boolean) As DataTable
        Dim sql As String
        sql = "SELECT  puntos_debito.Id_debito, puntos_debito.id_cliente,puntos_debito.FECHA, puntos_debito.referencia,puntos_debito.anulado," + _
        " SUM(puntos_debito_detalle.puntos) AS Puntos" + _
        " FROM Puntos_debito INNER JOIN PUntos_debito_Detalle ON Puntos_debito.Id_debito = puntos_debito_Detalle.Id_debito" + IIf(c = "", "", " and" + c) + _
        " GROUP BY Puntos_debito.Id_debito,puntos_debito.fecha,puntos_debito.id_cliente,puntos_debito.referencia,puntos_debito.anulado" + _
        " ORDER BY Puntos_debito.Id_debito"

        Dim Tbl As DataTable = Table(sql, "")
        Return Tbl
    End Function

    Public Function Numerico(ByVal K As Integer, ByVal T As String, ByVal d As Boolean) As Boolean
        Try
            If K = 46 And InStr(T, ".") > 0 Then
                Numerico = True
                Exit Function
            ElseIf (K < 48 Or K > 57) And K <> IIf(d, 46, 0) And K <> 8 Then
                Numerico = True
            End If
        Catch myerror As SqlException
            ONEX("numerico", myerror)
        End Try
    End Function

    Public Sub sqlquery(ByVal sql As String)
        Dim cmd As New SqlClient.SqlCommand()
        OpenConn()
        cmd = New SqlClient.SqlCommand(sql, CONN1)
        cmd.CommandText = sql
        cmd.CommandType = CommandType.Text
        cmd.ExecuteNonQuery()
    End Sub

    Public Function Table(ByVal Q As String, ByVal Pk As String) As DataTable
        'Try
        Dim command As New SqlCommand(Q, CONN1)
        command.CommandTimeout = 1200
        OpenConn()
        Dim reader As SqlDataReader = command.ExecuteReader()
        Dim schema As DataTable = reader.GetSchemaTable()
        Dim columns(schema.Rows.Count - 1) As DataColumn
        Dim column As DataColumn


        For i As Integer = 0 To columns.GetUpperBound(0) Step 1
            column = New DataColumn
            column.AllowDBNull = CBool(schema.Rows(i)("AllowDBNull"))
            column.AutoIncrement = CBool(schema.Rows(i)("IsAutoIncrement"))
            column.ColumnName = CStr(schema.Rows(i)("ColumnName"))
            column.DataType = CType(schema.Rows(i)("DataType"), Type)

            If column.DataType Is GetType(String) Then
                column.MaxLength = CInt(schema.Rows(i)("ColumnSize"))
            End If

            column.ReadOnly = CBool(schema.Rows(i)("IsReadOnly"))
            column.Unique = CBool(schema.Rows(i)("IsUnique"))
            columns(i) = column
        Next i

        Dim data As New DataTable
        Dim row As DataRow
        data.Columns.AddRange(columns)

        While reader.Read()
            row = data.NewRow()
            For i As Integer = 0 To columns.GetUpperBound(0)
                row(i) = reader(i)
            Next i
            data.Rows.Add(row)
        End While
        reader.Close()
        If Pk <> "" Then data.PrimaryKey = New DataColumn() {data.Columns(Pk)}
        Return data
        ' Catch myerror As Exception
        'ONEX("Table", myerror)
        'Return Nothing
        'End Try
    End Function
    Public Function cb_buscar(ByVal cb As ComboBox, ByVal T As String) As Integer
        Try
            Dim i As Integer = 0
            Dim Z As Integer
            For Z = 0 To cb.Items.Count - 1
                cb.SelectedIndex = Z
                If IIf(IsNumeric(cb.Text.Substring(1, 1)), cb.Text.Substring(0, 2), cb.Text.Substring(0, 1)) = T Then
                    i = Z
                    Exit For
                End If
            Next
            If i = 0 And cb.Items.Count = 0 Then i = -1
            Return i
        Catch myerror As Exception
            ONEX("cb_buscar", myerror)
            Return -1
        End Try
    End Function



    Public Function CB_crear(ByVal cb As ComboBox, ByVal Tbl As String, ByVal PK As String) As ComboBox
        'Try
        Dim T As DataTable
        T = Table("select " + PK + ",nombre from " + Tbl + " where eliminado=0 order by " + PK, "")
        Dim z As Integer
        For z = 0 To T.Rows.Count - 1
            cb.Items.Add(T.Rows(z).Item(PK).ToString + "-" + T.Rows(z).Item("nombre"))
        Next
        If cb.Items.Count > 0 Then cb.SelectedIndex = 0
        Return cb
        'Catch myerror As Exception
        ' Dim nd As New ComboBox
        ' ONEX("Genera_cb", myerror)
        ' Return nd
        ' End Try
    End Function

    Public Function CB_crear_NoEliminado(ByVal cb As ComboBox, ByVal Tbl As String, ByVal PK As String) As ComboBox
        'Try
        Dim T As DataTable
        T = Table("select " + PK + ",nombre from " + Tbl + " order by " + PK, "")
        Dim z As Integer
        For z = 0 To T.Rows.Count - 1
            cb.Items.Add(T.Rows(z).Item(PK).ToString + "-" + T.Rows(z).Item("nombre"))
        Next
        If cb.Items.Count > 0 Then cb.SelectedIndex = 0
        Return cb
        'Catch myerror As Exception
        ' Dim nd As New ComboBox
        ' ONEX("Genera_cb", myerror)
        ' Return nd
        ' End Try
    End Function

    Public Function cbid(ByVal T As String) As String
        Return IIf(IsNumeric(T.Substring(1, 1)), T.Substring(0, 2), T.Substring(0, 1))
    End Function


    Public Function TS(ByVal Tbl As DataTable, ByVal F As String, ByVal Text As String) As DataRow
        Dim Pos As Integer = -1
        Dim z As Integer
        For z = 0 To Tbl.Rows.Count - 1
            With Tbl.Rows(z)
                If .Item(F) = Text Then
                    Pos = z
                    Exit For
                End If
            End With
        Next
        If Pos < 0 Then
            Return Nothing
        Else
            Return Tbl.Rows(Pos)
        End If
    End Function


    Public Function RFile(ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As String
        Try
            Dim strContents As String
            Dim objReader As StreamReader
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch Ex As Exception
            Return "0"
        End Try
    End Function


    Public Sub wFile(ByVal strData As String, ByVal FullPath As String)
        Try
            Dim objReader As StreamWriter
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ONEX(ByVal ID As String, ByVal e As Exception)
        Try
            Dim T As String = Now.ToString
            Dim FN As String = Path + T.Substring(0, 2) + "." + T.Substring(3, 2) + "." + T.Substring(6, 4) + " " + T.Substring(11, 2) + "." + T.Substring(14, 2) + "." + T.Substring(17, 2) + ".txt"
            wFile(ID + " - " + e.Message, FN)
            MsgBox(e.Message)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            Exit Sub
        End Try
    End Sub

End Module