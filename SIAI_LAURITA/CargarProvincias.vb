
Imports System.Xml
Imports System.IO

Module CargarProvincias
    Public Class Provincia
        Public name As String
        Public id As Integer
        Public cantones As ArrayList

        Public Sub New(ByVal n As String, ByVal i As Integer, ByVal cant As ArrayList)
            name = n
            id = i
            cantones = cant
        End Sub

    End Class

    Public Class Canton
        Public name As String
        Public id As Integer
        Public distritos As ArrayList

        Public Sub New(ByVal n As String, ByVal i As Integer, ByVal dist As ArrayList)
            name = n
            id = i
            distritos = dist
        End Sub

    End Class

    Public Class Distrito
        Public name As String
        Public id As Integer

        Public Sub New(ByVal n As String, ByVal i As Integer)
            name = n
            id = i
        End Sub

    End Class


    Public Function PopulateDistritos() As ArrayList
        Dim xmldoc As New XmlDataDocument()
        Dim xmlnode As XmlNodeList
        Dim xmlcanton As XmlNodeList
        Dim xmldistrito As XmlNodeList

        Dim i As Integer
        Dim j As Integer
        Dim h As Integer

        Dim nombreProvincia As String
        Dim nombreCanton As String
        Dim nombreDistrito As String

        Dim Provincias As New ArrayList()
        Dim cantones As New ArrayList()
        Dim distritos As New ArrayList()

        Dim fs As New FileStream("provincias.xml", FileMode.Open, FileAccess.Read)
        xmldoc.Load(fs)
        xmlnode = xmldoc.GetElementsByTagName("provincia")
        For i = 0 To xmlnode.Count - 1

            nombreProvincia = xmlnode(i).FirstChild.InnerText.Trim
            xmlcanton = xmlnode(i).LastChild.SelectNodes("canton")
            cantones = New ArrayList()

            For j = 0 To xmlcanton.Count - 1
                nombreCanton = xmlcanton(j).FirstChild.InnerText.Trim
                xmldistrito = xmlcanton(j).LastChild.SelectNodes("distrito")
                distritos = New ArrayList()

                For h = 0 To xmldistrito.Count - 1
                    nombreDistrito = xmldistrito(h).FirstChild.InnerText.Trim
                    distritos.Add(New Distrito(nombreDistrito, h))
                Next

                cantones.Add(New Canton(nombreCanton, j + 1, distritos))
            Next

            Provincias.Add(New Provincia(nombreProvincia, i + 1, cantones))
        Next

        Return Provincias
    End Function

End Module
