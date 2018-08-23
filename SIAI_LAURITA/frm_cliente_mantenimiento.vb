Public Class frm_cliente_mantenimiento
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txttelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtobservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txttelefono_encargado As System.Windows.Forms.TextBox
    Friend WithEvents txtnombre_encargado As System.Windows.Forms.TextBox
    Friend WithEvents txtfax As System.Windows.Forms.TextBox
    Friend WithEvents txtdireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblid_cliente As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents txtplazo As System.Windows.Forms.TextBox
    Friend WithEvents txtlimite_credito As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pbnombre_sociedad As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbprecio As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbcomercio As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtIdentificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbIdentificacion As System.Windows.Forms.ComboBox
    Friend WithEvents cbDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbCanton As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumeroRepresentante As System.Windows.Forms.TextBox
    Friend WithEvents txtRepresentante As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cliente_mantenimiento))
        Me.lbltitulo = New System.Windows.Forms.Label
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtNumeroRepresentante = New System.Windows.Forms.TextBox
        Me.txtRepresentante = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cbDistrito = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cbCanton = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cbProvincia = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbIdentificacion = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtIdentificacion = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbcomercio = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbprecio = New System.Windows.Forms.ComboBox
        Me.pbnombre_sociedad = New System.Windows.Forms.PictureBox
        Me.txtplazo = New System.Windows.Forms.TextBox
        Me.txtlimite_credito = New System.Windows.Forms.TextBox
        Me.txttelefono = New System.Windows.Forms.TextBox
        Me.txtobservaciones = New System.Windows.Forms.TextBox
        Me.txttelefono_encargado = New System.Windows.Forms.TextBox
        Me.txtnombre_encargado = New System.Windows.Forms.TextBox
        Me.txtfax = New System.Windows.Forms.TextBox
        Me.txtdireccion = New System.Windows.Forms.TextBox
        Me.txtemail = New System.Windows.Forms.TextBox
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblid_cliente = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.pbnombre_sociedad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltitulo
        '
        Me.lbltitulo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbltitulo.Location = New System.Drawing.Point(0, 0)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(734, 26)
        Me.lbltitulo.TabIndex = 11
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btncancelar
        '
        Me.btncancelar.Image = CType(resources.GetObject("btncancelar.Image"), System.Drawing.Image)
        Me.btncancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancelar.Location = New System.Drawing.Point(377, 578)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(88, 32)
        Me.btncancelar.TabIndex = 16
        Me.btncancelar.Text = "Cancelar"
        Me.ToolTip1.SetToolTip(Me.btncancelar, "No Guardar los Datos")
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Image = CType(resources.GetObject("btnaceptar.Image"), System.Drawing.Image)
        Me.btnaceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaceptar.Location = New System.Drawing.Point(267, 578)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(88, 32)
        Me.btnaceptar.TabIndex = 15
        Me.btnaceptar.Text = "Aceptar"
        Me.ToolTip1.SetToolTip(Me.btnaceptar, "Guarda los datos")
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtNumeroRepresentante)
        Me.Panel1.Controls.Add(Me.txtRepresentante)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.cbDistrito)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.cbCanton)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.cbProvincia)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.cbIdentificacion)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtIdentificacion)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cbcomercio)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cbprecio)
        Me.Panel1.Controls.Add(Me.pbnombre_sociedad)
        Me.Panel1.Controls.Add(Me.txtplazo)
        Me.Panel1.Controls.Add(Me.txtlimite_credito)
        Me.Panel1.Controls.Add(Me.txttelefono)
        Me.Panel1.Controls.Add(Me.txtobservaciones)
        Me.Panel1.Controls.Add(Me.txttelefono_encargado)
        Me.Panel1.Controls.Add(Me.txtnombre_encargado)
        Me.Panel1.Controls.Add(Me.txtfax)
        Me.Panel1.Controls.Add(Me.txtdireccion)
        Me.Panel1.Controls.Add(Me.txtemail)
        Me.Panel1.Controls.Add(Me.txtnombre)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblid_cliente)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(23, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(689, 543)
        Me.Panel1.TabIndex = 0
        '
        'txtNumeroRepresentante
        '
        Me.txtNumeroRepresentante.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroRepresentante.Location = New System.Drawing.Point(584, 437)
        Me.txtNumeroRepresentante.MaxLength = 8
        Me.txtNumeroRepresentante.Name = "txtNumeroRepresentante"
        Me.txtNumeroRepresentante.Size = New System.Drawing.Size(80, 26)
        Me.txtNumeroRepresentante.TabIndex = 108
        Me.ToolTip1.SetToolTip(Me.txtNumeroRepresentante, "Escriba el teléfono del encargado")
        '
        'txtRepresentante
        '
        Me.txtRepresentante.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepresentante.Location = New System.Drawing.Point(166, 435)
        Me.txtRepresentante.MaxLength = 35
        Me.txtRepresentante.Name = "txtRepresentante"
        Me.txtRepresentante.Size = New System.Drawing.Size(328, 26)
        Me.txtRepresentante.TabIndex = 107
        Me.ToolTip1.SetToolTip(Me.txtRepresentante, "Escriba el nombre del encargado")
        '
        'Label19
        '
        Me.Label19.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label19.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(514, 437)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 24)
        Me.Label19.TabIndex = 110
        Me.Label19.Text = "Teléfono"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label20.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(16, 437)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(159, 24)
        Me.Label20.TabIndex = 109
        Me.Label20.Text = "Representante Legal"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbDistrito
        '
        Me.cbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDistrito.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDistrito.Location = New System.Drawing.Point(166, 225)
        Me.cbDistrito.Name = "cbDistrito"
        Me.cbDistrito.Size = New System.Drawing.Size(250, 26)
        Me.cbDistrito.TabIndex = 106
        Me.ToolTip1.SetToolTip(Me.cbDistrito, "Seleccione el Destino")
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 225)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 24)
        Me.Label18.TabIndex = 105
        Me.Label18.Text = "Distrito"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbCanton
        '
        Me.cbCanton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCanton.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCanton.Location = New System.Drawing.Point(422, 185)
        Me.cbCanton.Name = "cbCanton"
        Me.cbCanton.Size = New System.Drawing.Size(202, 26)
        Me.cbCanton.TabIndex = 104
        Me.ToolTip1.SetToolTip(Me.cbCanton, "Seleccione el Destino")
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(356, 185)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 24)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "Canton"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbProvincia
        '
        Me.cbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProvincia.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProvincia.Location = New System.Drawing.Point(166, 185)
        Me.cbProvincia.Name = "cbProvincia"
        Me.cbProvincia.Size = New System.Drawing.Size(184, 26)
        Me.cbProvincia.TabIndex = 102
        Me.ToolTip1.SetToolTip(Me.cbProvincia, "Seleccione el Destino")
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 24)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "Provincia"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbIdentificacion
        '
        Me.cbIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbIdentificacion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIdentificacion.Items.AddRange(New Object() {"Fisico", "Juridico", "Dimex", "Nite", "Extranjero"})
        Me.cbIdentificacion.Location = New System.Drawing.Point(410, 79)
        Me.cbIdentificacion.Name = "cbIdentificacion"
        Me.cbIdentificacion.Size = New System.Drawing.Size(214, 26)
        Me.cbIdentificacion.TabIndex = 100
        Me.ToolTip1.SetToolTip(Me.cbIdentificacion, "Seleccione el Destino")
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(366, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 24)
        Me.Label12.TabIndex = 99
        Me.Label12.Text = "Tipo:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIdentificacion
        '
        Me.txtIdentificacion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdentificacion.Location = New System.Drawing.Point(166, 77)
        Me.txtIdentificacion.MaxLength = 20
        Me.txtIdentificacion.Name = "txtIdentificacion"
        Me.txtIdentificacion.Size = New System.Drawing.Size(194, 26)
        Me.txtIdentificacion.TabIndex = 98
        Me.ToolTip1.SetToolTip(Me.txtIdentificacion, "Escriba el E-mail del cliente")
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 24)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "Identificacion"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(288, 312)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 24)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Tipo de Negocio:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbcomercio
        '
        Me.cbcomercio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcomercio.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcomercio.Items.AddRange(New Object() {"Abastecedor", "Mini Super", "Super Mercado"})
        Me.cbcomercio.Location = New System.Drawing.Point(422, 310)
        Me.cbcomercio.Name = "cbcomercio"
        Me.cbcomercio.Size = New System.Drawing.Size(165, 26)
        Me.cbcomercio.TabIndex = 95
        Me.ToolTip1.SetToolTip(Me.cbcomercio, "Seleccione el Destino")
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 296)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 24)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Precio"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbprecio
        '
        Me.cbprecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbprecio.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbprecio.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cbprecio.Location = New System.Drawing.Point(166, 296)
        Me.cbprecio.Name = "cbprecio"
        Me.cbprecio.Size = New System.Drawing.Size(40, 26)
        Me.cbprecio.TabIndex = 91
        Me.ToolTip1.SetToolTip(Me.cbprecio, "Seleccione el Destino")
        '
        'pbnombre_sociedad
        '
        Me.pbnombre_sociedad.Image = CType(resources.GetObject("pbnombre_sociedad.Image"), System.Drawing.Image)
        Me.pbnombre_sociedad.Location = New System.Drawing.Point(593, 58)
        Me.pbnombre_sociedad.Name = "pbnombre_sociedad"
        Me.pbnombre_sociedad.Size = New System.Drawing.Size(12, 12)
        Me.pbnombre_sociedad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbnombre_sociedad.TabIndex = 90
        Me.pbnombre_sociedad.TabStop = False
        Me.pbnombre_sociedad.Visible = False
        '
        'txtplazo
        '
        Me.txtplazo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtplazo.Location = New System.Drawing.Point(166, 330)
        Me.txtplazo.MaxLength = 2
        Me.txtplazo.Name = "txtplazo"
        Me.txtplazo.Size = New System.Drawing.Size(40, 26)
        Me.txtplazo.TabIndex = 8
        Me.txtplazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtplazo, "Escriba el plazo (en días)  del cliente")
        '
        'txtlimite_credito
        '
        Me.txtlimite_credito.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlimite_credito.Location = New System.Drawing.Point(166, 364)
        Me.txtlimite_credito.MaxLength = 8
        Me.txtlimite_credito.Name = "txtlimite_credito"
        Me.txtlimite_credito.Size = New System.Drawing.Size(87, 26)
        Me.txtlimite_credito.TabIndex = 10
        Me.txtlimite_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtlimite_credito, "Escriba el límite de crédito  del cliente")
        '
        'txttelefono
        '
        Me.txttelefono.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttelefono.Location = New System.Drawing.Point(166, 262)
        Me.txttelefono.MaxLength = 8
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(78, 26)
        Me.txttelefono.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txttelefono, "Escriba el teléfono del cliente")
        '
        'txtobservaciones
        '
        Me.txtobservaciones.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtobservaciones.Location = New System.Drawing.Point(166, 476)
        Me.txtobservaciones.MaxLength = 50
        Me.txtobservaciones.Multiline = True
        Me.txtobservaciones.Name = "txtobservaciones"
        Me.txtobservaciones.Size = New System.Drawing.Size(392, 39)
        Me.txtobservaciones.TabIndex = 14
        '
        'txttelefono_encargado
        '
        Me.txttelefono_encargado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttelefono_encargado.Location = New System.Drawing.Point(584, 398)
        Me.txttelefono_encargado.MaxLength = 8
        Me.txttelefono_encargado.Name = "txttelefono_encargado"
        Me.txttelefono_encargado.Size = New System.Drawing.Size(80, 26)
        Me.txttelefono_encargado.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.txttelefono_encargado, "Escriba el teléfono del encargado")
        '
        'txtnombre_encargado
        '
        Me.txtnombre_encargado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre_encargado.Location = New System.Drawing.Point(166, 396)
        Me.txtnombre_encargado.MaxLength = 35
        Me.txtnombre_encargado.Name = "txtnombre_encargado"
        Me.txtnombre_encargado.Size = New System.Drawing.Size(328, 26)
        Me.txtnombre_encargado.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.txtnombre_encargado, "Escriba el nombre del encargado")
        '
        'txtfax
        '
        Me.txtfax.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfax.Location = New System.Drawing.Point(336, 262)
        Me.txtfax.MaxLength = 8
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(80, 26)
        Me.txtfax.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtfax, "Escriba el número de Fax del cliente")
        '
        'txtdireccion
        '
        Me.txtdireccion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdireccion.Location = New System.Drawing.Point(166, 144)
        Me.txtdireccion.MaxLength = 50
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(458, 26)
        Me.txtdireccion.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtdireccion, "Escriba la dirección del cliente")
        '
        'txtemail
        '
        Me.txtemail.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.Location = New System.Drawing.Point(166, 112)
        Me.txtemail.MaxLength = 100
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(458, 26)
        Me.txtemail.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtemail, "Escriba el E-mail del cliente")
        '
        'txtnombre
        '
        Me.txtnombre.AcceptsReturn = True
        Me.txtnombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(166, 44)
        Me.txtnombre.MaxLength = 45
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(421, 26)
        Me.txtnombre.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtnombre, "Escriba el nombre de la sociedad")
        '
        'Label16
        '
        Me.Label16.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label16.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(514, 398)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 24)
        Me.Label16.TabIndex = 84
        Me.Label16.Text = "Teléfono"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 398)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 24)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Encargado"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 364)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 24)
        Me.Label15.TabIndex = 77
        Me.Label15.Text = "Límite"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 330)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 24)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Plazo"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 24)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Dirección"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 24)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "E-mail"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(288, 264)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 24)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Fax"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblid_cliente
        '
        Me.lblid_cliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblid_cliente.Location = New System.Drawing.Point(163, 11)
        Me.lblid_cliente.Name = "lblid_cliente"
        Me.lblid_cliente.Size = New System.Drawing.Size(50, 24)
        Me.lblid_cliente.TabIndex = 61
        Me.lblid_cliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 24)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Código"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 479)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 24)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Observaciones"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 262)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 24)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Teléfono"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 24)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(593, 56)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(11, 12)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 67
        Me.PictureBox3.TabStop = False
        '
        'frm_cliente_mantenimiento
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(737, 623)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.lbltitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_cliente_mantenimiento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Clientes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbnombre_sociedad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Provincias As ArrayList
    Public loading As Boolean = False

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Try
            Dim Fi As Boolean = False

            If txtnombre.Text = "" Then
                pbnombre_sociedad.Visible = True
                Fi = True
            Else
                pbnombre_sociedad.Visible = False
            End If


            If Fi Then
                MessageBox.Show("Hay campos requeridos sin completar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            With myForms.frm_datos_mantenimiento
                Dim r As DataRow = TS(.Dscliente.Tables(0), "nombre", txtnombre.Text)
                If Not (r Is Nothing) Then
                    If (lbltitulo.Text = "Incluir Cliente") Or (lbltitulo.Text <> "Incluir Cliente" And .dtgcliente.Item("dtgcid", .dtgcliente.CurrentRow.Index).Value <> r("id_cliente")) Then
                        MessageBox.Show("Nombre de Cliente Ya Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtnombre.Focus()
                        SendKeys.Send("{home}+{end}")
                        Exit Sub
                    End If
                End If

                If lbltitulo.Text = "Incluir Cliente" Then
                    .rowc = .Dvcliente.Table.NewRow()
                End If
                .rowc("nombre") = txtnombre.Text
                .rowc("email") = IIf(txtemail.Text = "", "", txtemail.Text)
                .rowc("direccion") = IIf(txtdireccion.Text = "", "", txtdireccion.Text)
                .rowc("telefono") = IIf(txttelefono.Text = "", "", txttelefono.Text)
                .rowc("fax") = IIf(txtfax.Text = "", "", txtfax.Text)
                .rowc("limite_credito") = Val(txtlimite_credito.Text)
                .rowc("precio") = cbprecio.SelectedIndex + 1
                .rowc("observaciones") = IIf(txtobservaciones.Text = "", "", txtobservaciones.Text)
                .rowc("nombre_encargado") = IIf(txtnombre_encargado.Text = "", "", txtnombre_encargado.Text)
                .rowc("telefono_encargado") = IIf(txttelefono_encargado.Text = "", "", txttelefono_encargado.Text)
                .rowc("plazo") = Val(txtplazo.Text)
                .rowc("comercio") = cbcomercio.SelectedIndex
                .rowc("provincia") = Val(cbProvincia.SelectedIndex + 1)
                .rowc("canton") = Val(cbCanton.SelectedIndex + 1)
                .rowc("distrito") = Val(cbDistrito.SelectedIndex + 1)
                .rowc("identificacion") = txtIdentificacion.Text
                .rowc("tipoIdentificacion") = cbIdentificacion.SelectedIndex + 1
                .rowc("representante") = txtRepresentante.Text
                .rowc("numeroRepresentante") = txtNumeroRepresentante.Text

                OpenConn()
                If lbltitulo.Text = "Incluir Cliente" Then .Dvcliente.Table.Rows.Add(.rowc)
                .Dacliente.Update(.Dscliente, "cliente")
            End With
            Me.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try

    End Sub



    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub txtlimite_credito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlimite_credito.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtlimite_credito.Text, False)
        End If
    End Sub


    Private Sub txtplazo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtplazo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtplazo.Text, False)
        End If
    End Sub

    Private Sub txtidentificacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtnombre_sociedad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtnombre_comercial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtemail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtemail.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtdireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdireccion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txttelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub cbdia_cierre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub cbid_agente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbid_lista_precios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtnombre_encargado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre_encargado.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txttelefono_encargado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono_encargado.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtobservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtobservaciones.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            btnaceptar.Focus()
        End If
    End Sub


    Private Sub cbCanton_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCanton.SelectedIndexChanged
        Dim selectedCanton As Canton
        Dim selectedProvincia As Provincia

        selectedProvincia = Provincias(cbProvincia.SelectedIndex)
        selectedCanton = selectedProvincia.cantones(cbCanton.SelectedIndex)

        cbDistrito.Items.Clear()

        For Each dist As Distrito In selectedCanton.distritos
            cbDistrito.Items.Add(dist.name)
        Next

        cbDistrito.SelectedIndex = 0
    End Sub

    Private Sub cbProvincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProvincia.SelectedIndexChanged
        Dim selectedProv As Provincia
        selectedProv = Provincias(cbProvincia.SelectedIndex)
        cbCanton.Items.Clear()

        For Each cant As Canton In selectedProv.cantones
            cbCanton.Items.Add(cant.name)
        Next

        cbCanton.SelectedIndex = 0
    End Sub

    Private Sub frm_cliente_mantenimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Provincias.Count = 0 Then
            Provincias = PopulateDistritos()
        End If

        If Not loading Then
            cbProvincia.Items.Clear()

            For Each prov As Provincia In Provincias
                cbProvincia.Items.Add(prov.name)
            Next
            cbProvincia.SelectedIndex = 0
        End If

    End Sub

    Public Sub PopulateCBAddress()
        Provincias = PopulateDistritos()

        For Each prov As Provincia In Provincias
            cbProvincia.Items.Add(prov.name)
        Next
        cbProvincia.SelectedIndex = 0

    End Sub
End Class
