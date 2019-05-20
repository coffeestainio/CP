
Imports System.Xml
Imports System.IO
Imports System.Text

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

        'Dim fs As New FileStream("provincias.xml", FileMode.Open, FileAccess.Read)

        xmldoc.LoadXml(xmlProvincias())
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

    Private Function xmlProvincias() As String
        return "<?xml version=""1.0"" encoding=""UTF-8""?> " + _
" <provincias> " + _
   " <provincia> " + _
      " <nombre>San Jose</nombre> " + _
      " <codigo>1</codigo> " + _
      " <cantones> " + _
         " <canton> " + _
            " <nombre>San Jose</nombre> " + _
            " <codigo>1</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Carmen</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Merced</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Hospital</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Catedral</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Zapote</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Fco Dos Rios</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Uruca</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Mata Redonda</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pavas</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Hatillo</nombre> " + _
                  " <codigo>10</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Sebastian</nombre> " + _
                  " <codigo>11</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Escazu</nombre> " + _
            " <codigo>2</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Escazu</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Antonio</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Desamparados</nombre> " + _
            " <codigo>3</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Desamparados</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Miguel</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Juan de Dios</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael Arriba</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Antonio</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Frailes</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Patarra</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Cristobal</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rosario</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Damas</nombre> " + _
                  " <codigo>10</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael Abajo</nombre> " + _
                  " <codigo>11</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Gravilias</nombre> " + _
                  " <codigo>12</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Los Guido</nombre> " + _
                  " <codigo>13</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Puriscal</nombre> " + _
            " <codigo>4</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Santiago</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Mercedes Sur</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Barbacoas</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Grifo Alto</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Candelarita</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Desamparaditos</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Antonio</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Chires</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Tarrazu</nombre> " + _
            " <codigo>5</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Marcos</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Lorenzo</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Carlos</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Aserri</nombre> " + _
            " <codigo>6</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Aserri</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tarbaca</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Vuelta del Jorco</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Gabriel</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Legua</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Monterrey</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Salitrillos</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Mora</nombre> " + _
            " <codigo>7</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Colon</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Guayabo</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tabarcia</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Piedras Negras</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Picagres</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Jaris</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Quitirrisi</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Goicoechea</nombre> " + _
            " <codigo>8</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Guadalupe</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Francisco</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Calle Blancos</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Mata de Platano</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Ipis</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rancho Redondo</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Purral</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Santa Ana</nombre> " + _
            " <codigo>9</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Santa Ana</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Salitral</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pozos</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Uruca</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Piedades</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Brasil</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Alajuelita</nombre> " + _
            " <codigo>10</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Alajuelita</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Josecito</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Antonio</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Concepcion</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Felipe</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Vasquez de Coronado</nombre> " + _
            " <codigo>11</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Isidro</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Dulce Nombre de Jesus</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Patalillo</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cascajal</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Acosta</nombre> " + _
            " <codigo>12</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Ignacio</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Guatil Villa</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Palmichal</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cangrejal</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sabanillas</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Tibas</nombre> " + _
            " <codigo>13</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Juan</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cinco Esquinas</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Anselmo Llorente</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Leon XIII</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Colima</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Moravia</nombre> " + _
            " <codigo>14</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Vicente</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jeronimo</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Trinidad</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Montes de Oca</nombre> " + _
            " <codigo>15</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Pedro</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sabanilla</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Mercedes</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Turrubares</nombre> " + _
            " <codigo>16</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Pablo</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Pedro</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Juan de Mata</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Luis</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Carara</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Dota</nombre> " + _
            " <codigo>17</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Santa Maria</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Jardin</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Copey</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Curridabat</nombre> " + _
            " <codigo>18</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Curridabat</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Granadilla</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sanchez</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tirrases</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Perez Zeledon</nombre> " + _
            " <codigo>19</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Isidro del General</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>El general</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Daniel Flores</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rivas</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Pedro</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Platanares</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pejibaye</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cajon</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Baru</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rio Nuevo</nombre> " + _
                  " <codigo>10</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Paramo</nombre> " + _
                  " <codigo>11</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Leon Cortez Castro</nombre> " + _
            " <codigo>20</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Pablo</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Andres</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Llano Bonito</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Isidro</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Cruz</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Antonio</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
      " </cantones> " + _
   " </provincia> " + _
   " <provincia> " + _
      " <nombre>Alajuela</nombre> " + _
      " <codigo>2</codigo> " + _
      " <cantones> " + _
         " <canton> " + _
            " <nombre>Alajuela</nombre> " + _
            " <codigo>1</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Alajuela</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jose</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Carrizal</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Antonio</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Guacima</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Isidro</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sabanilla</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rio Segundo</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Desamparados</nombre> " + _
                  " <codigo>10</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Turrucares</nombre> " + _
                  " <codigo>11</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tambor</nombre> " + _
                  " <codigo>12</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Garita</nombre> " + _
                  " <codigo>13</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sarapiqui</nombre> " + _
                  " <codigo>14</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>San Ramon</nombre> " + _
            " <codigo>2</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Ramon</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santiago</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Juan</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Piedades Norte</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Piedades Sur</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Isidro</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Angeles</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Alfaro</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Volio</nombre> " + _
                  " <codigo>10</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Concepcion</nombre> " + _
                  " <codigo>11</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Zapotal</nombre> " + _
                  " <codigo>12</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Penas Blancas</nombre> " + _
                  " <codigo>13</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Grecia</nombre> " + _
            " <codigo>3</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Grecia</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Isidro</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jose</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Roque</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tacares</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rio Cuarto</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Puente de Piedra</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Bolivar</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>San Mateo</nombre> " + _
            " <codigo>4</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Mateo</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Desmonte</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Jesus Maria</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Labrador</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Atenas</nombre> " + _
            " <codigo>5</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Atenas</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Jesus</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Mercedes</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Isidro</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Concepcion</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jose</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Eulalia</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Escobal</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Naranjo</nombre> " + _
            " <codigo>6</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Naranjo</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Miguel</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jose</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cirri Sur</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jeronimo</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Juan</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>El Rosario</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Palmitos</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Palmares</nombre> " + _
            " <codigo>7</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Palmares</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Zaragoza</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Buenos Aires</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santiago</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Candelaria</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Esquipulas</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Granja</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Poas</nombre> " + _
            " <codigo>8</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Pedro</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Juan</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Carillos</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sabana Redonda</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Orotina</nombre> " + _
            " <codigo>9</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Orotina</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>El Mastate</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Hacienda Vieja</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Coyolar</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Ceiba</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>San Carlos</nombre> " + _
            " <codigo>10</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Quesada</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Florencia</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Buena Vista</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Aguas Zarcas</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Venecia</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pital</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Fortuna</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Tigra</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Palmera</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Venado</nombre> " + _
                  " <codigo>10</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cutris</nombre> " + _
                  " <codigo>11</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Monterrey</nombre> " + _
                  " <codigo>12</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pocosol</nombre> " + _
                  " <codigo>13</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Zarcero</nombre> " + _
            " <codigo>11</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Zarcero</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Laguna</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Guadalupe</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Palmira</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Zapote</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Brisas</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Valverde Vega</nombre> " + _
            " <codigo>12</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Sarchi Norte</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sarchi Sur</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Toro Amarillo</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sabn Pedro</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rodriguez</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Upala</nombre> " + _
            " <codigo>13</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Upala</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Aguas Claras</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jose o Pizote</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Bijagua</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Delicias</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Dos Rios</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Yolillal</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Canalete</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Los Chiles</nombre> " + _
            " <codigo>14</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Los Chiles</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cano Negro</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>El Amparo</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jorge</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Guatuso</nombre> " + _
            " <codigo>15</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Guatuso</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Buena Vista</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cote</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Katira</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
      " </cantones> " + _
   " </provincia> " + _
   " <provincia> " + _
      " <nombre>Cartago</nombre> " + _
      " <codigo>3</codigo> " + _
      " <cantones> " + _
         " <canton> " + _
            " <nombre>Cartago</nombre> " + _
            " <codigo>1</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Oriental</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Occidental</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Carmen</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Nicolas</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Aguacaliente o San Francisco</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Guadalupe o Arenilla</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Corralillo</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tierra Blanca</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Dulce Nombre</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Llano Grande</nombre> " + _
                  " <codigo>10</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Quebradilla</nombre> " + _
                  " <codigo>11</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Paraiso</nombre> " + _
            " <codigo>2</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Paraiso</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santiago</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Orosi</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cachi</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Llanos de Santa Lucia</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>La Union</nombre> " + _
            " <codigo>3</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Tres Rios</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Diego</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Juan</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Concepcion</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Dulce Nombre</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Ramon</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rio Azul</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Jimenez</nombre> " + _
            " <codigo>4</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Juan Vinas</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tucurrique</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pejibaye</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Turrialba</nombre> " + _
            " <codigo>5</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Turrialba</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Suiza</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Peralta</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Cruz</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Teresita</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pavones</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tuis</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tayutic</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Rosa</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tres Equis</nombre> " + _
                  " <codigo>10</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Isabel</nombre> " + _
                  " <codigo>11</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Chirripo</nombre> " + _
                  " <codigo>12</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Alvarado</nombre> " + _
            " <codigo>6</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Pacayas</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cervantes</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Capellades</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Oreamuno</nombre> " + _
            " <codigo>7</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cot</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Potrero Cerrado</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cipreses</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Rosa</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>El Guarco</nombre> " + _
            " <codigo>8</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>El Tejar</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Isidro</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tobosi</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Patio de Agua</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
      " </cantones> " + _
   " </provincia> " + _
   " <provincia> " + _
      " <nombre>Heredia</nombre> " + _
      " <codigo>1</codigo> " + _
      " <cantones> " + _
         " <canton> " + _
            " <nombre>Heredia</nombre> " + _
            " <codigo>1</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Heredia</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Mercedes</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Francisco</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Ulloa</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Vara Blanca</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Barva</nombre> " + _
            " <codigo>2</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Barva</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Pedro</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Pablo</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Roque</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Lucia</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jose de la Montana</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Santo Domingo</nombre> " + _
            " <codigo>3</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Vicente</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Miguel</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Paracito</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santo Tomas</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Rosa</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tures</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Para</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Santa Barbara</nombre> " + _
            " <codigo>4</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Santa Barbara</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Pedro</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Juan</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Jesus</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santo Domingo</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Puraba</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>San Rafael</nombre> " + _
            " <codigo>5</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Josecito</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santiago</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Angeles</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Concepcion</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>San Isidro</nombre> " + _
            " <codigo>6</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Isidro</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jose</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Concepcion</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Francisco</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Belen</nombre> " + _
            " <codigo>7</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Antonio</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Ribera</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Asuncion</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Flores</nombre> " + _
            " <codigo>8</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Joaquin</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Barrantes</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Llorente</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>San Pablo</nombre> " + _
            " <codigo>9</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Pablo</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Sarapiqui</nombre> " + _
            " <codigo>10</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Puerto Viejo</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Virgen</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Las Horquetas</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Llanura de Gaspar</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Curena</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
      " </cantones> " + _
   " </provincia> " + _
   " <provincia> " + _
      " <nombre>Guanacaste</nombre> " + _
      " <codigo>1</codigo> " + _
      " <cantones> " + _
         " <canton> " + _
            " <nombre>Liberia</nombre> " + _
            " <codigo>1</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Liberia</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Canas Dulces</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Mayorga</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Nacascolo</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Curubande</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Nicoya</nombre> " + _
            " <codigo>2</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Nicoya</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Mansion</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Antonio</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Quebrada Honda</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Samara</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Nosara</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Belen de Nosarita</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Santa Cruz</nombre> " + _
            " <codigo>3</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Santa Cruz</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Bolson</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Veintisite de Abril</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tempate</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cartagena</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cuajiniquil</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Diria</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cabo Velas</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tamarindo</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Bagaces</nombre> " + _
            " <codigo>4</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Bagaces</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Fortuna</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Mogote</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rio Naranjo</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Carrillo</nombre> " + _
            " <codigo>5</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Filadelfia</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Palmira</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sardinal</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Belen</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Canas</nombre> " + _
            " <codigo>6</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Canas</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Palmira</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Miguel</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Bebedero</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Porozal</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Abangares</nombre> " + _
            " <codigo>7</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Las Juntas</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sierra</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Juan</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Colorado</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Tilaran</nombre> " + _
            " <codigo>8</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Tilaran</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Quebrada Grande</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tronadora</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Rosa</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Libano</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tierras Morenas</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Arenal</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Nandayure</nombre> " + _
            " <codigo>9</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Carmona</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Rita</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Zapotal</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Pablo</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Porvenir</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Bejuco</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>La Cruz</nombre> " + _
            " <codigo>10</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>La Cruz</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Cecilia</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Garita</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Santa Elena</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Hojancha</nombre> " + _
            " <codigo>11</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Hojancha</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Monte Romo</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Puerto Carillo</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Huacas</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
      " </cantones> " + _
   " </provincia> " + _
   " <provincia> " + _
      " <nombre>Puntarenas</nombre> " + _
      " <codigo>6</codigo> " + _
      " <cantones> " + _
         " <canton> " + _
            " <nombre>Puntarenas</nombre> " + _
            " <codigo>1</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Puntarenas</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pitahaya</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Chomes</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Lepanto</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Paquera</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Manzanillo</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Guacimil</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Barranca</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Monte Verde</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cobano</nombre> " + _
                  " <codigo>10</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Chacarita</nombre> " + _
                  " <codigo>11</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Chira</nombre> " + _
                  " <codigo>12</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Acapulco</nombre> " + _
                  " <codigo>13</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>El Roble</nombre> " + _
                  " <codigo>14</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Arancibia</nombre> " + _
                  " <codigo>15</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Esparza</nombre> " + _
            " <codigo>2</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Espiritu Santo</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Juan Grande</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Macacona</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Rafael</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Jeronimo</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Caldera</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Buenos Aires</nombre> " + _
            " <codigo>3</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Buenos Aires</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Volcan</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Potrero Grande</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Boruca</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pilas</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Colinas</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Changuena</nombre> " + _
                  " <codigo>7</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Biolley</nombre> " + _
                  " <codigo>8</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Brunka</nombre> " + _
                  " <codigo>9</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Montes de Oca</nombre> " + _
            " <codigo>4</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Miramar</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Union</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>San Isidro</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Osa</nombre> " + _
            " <codigo>5</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Puerto Cortes</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Palmar</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sierpe</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Bahia Ballena</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Piedras Blancas</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Bahia Drake</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Aguirre</nombre> " + _
            " <codigo>6</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Quepos</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Savegre</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Naranjito</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Golfito</nombre> " + _
            " <codigo>7</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Golfito</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Puerto Jimenez</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Guaycara</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pavon</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Coto Brus</nombre> " + _
            " <codigo>8</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>San Vito</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sabalito</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Aguabuena</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Limoncito</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pittier</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Guitierrez Braun</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Parrita</nombre> " + _
            " <codigo>9</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Parrita</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Corredores</nombre> " + _
            " <codigo>10</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Corredor</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Cuesta</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Canoas</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Laurel</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Garabito</nombre> " + _
            " <codigo>11</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Jaco</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Tarcoles</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
      " </cantones> " + _
   " </provincia> " + _
   " <provincia> " + _
      " <nombre>Limon</nombre> " + _
      " <codigo>7</codigo> " + _
      " <cantones> " + _
         " <canton> " + _
            " <nombre>Limon</nombre> " + _
            " <codigo>1</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Limon</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Valle de la Estrella</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Matama</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Pococi</nombre> " + _
            " <codigo>2</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Guapiles</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Jimenez</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rita</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Roxana</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cariari</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Colorado</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>La Colonia</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Siquirres</nombre> " + _
            " <codigo>3</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Siquirres</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pacuarito</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Florida</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Germania</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>El Cairo</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Alegria</nombre> " + _
                  " <codigo>6</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Talamanca</nombre> " + _
            " <codigo>4</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Bratsi</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Sixaola</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Cahuita</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Telire</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Matina</nombre> " + _
            " <codigo>5</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Matina</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Batan</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Carrandi</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
         " <canton> " + _
            " <nombre>Guacimo</nombre> " + _
            " <codigo>6</codigo> " + _
            " <distritos> " + _
               " <distrito> " + _
                  " <nombre>Guacimo</nombre> " + _
                  " <codigo>1</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Mercedes</nombre> " + _
                  " <codigo>2</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Pocora</nombre> " + _
                  " <codigo>3</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Rio Jimenez</nombre> " + _
                  " <codigo>4</codigo> " + _
               " </distrito> " + _
               " <distrito> " + _
                  " <nombre>Duacari</nombre> " + _
                  " <codigo>5</codigo> " + _
               " </distrito> " + _
            " </distritos> " + _
         " </canton> " + _
      " </cantones> " + _
   " </provincia> " + _
" </provincias> "

    End Function

End Module
