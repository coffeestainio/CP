Imports System.data.SqlClient
Public Class frm_producto_mantenimiento
    Inherits System.Windows.Forms.Form
    Dim sql As String
    Dim CF As Decimal
    Dim PIV As Decimal
    Friend WithEvents chkbloqueado As System.Windows.Forms.CheckBox
    Friend WithEvents cbsector As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Public Id_Producto_ant As String


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
    Friend WithEvents txtobservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents chkiv As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbpresentacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents txtbarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pbnombre As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtid_producto As System.Windows.Forms.TextBox
    Friend WithEvents lblproveedor As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbllinea As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbpasillo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbbodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbrack As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtsub_empaque As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtempaque As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtdescb As System.Windows.Forms.TextBox
    Friend WithEvents txtdesca As System.Windows.Forms.TextBox
    Friend WithEvents txtcosto As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblconsumidor4 As System.Windows.Forms.Label
    Friend WithEvents lblconsumidor3 As System.Windows.Forms.Label
    Friend WithEvents lblconsumidor2 As System.Windows.Forms.Label
    Friend WithEvents lblconsumidor1 As System.Windows.Forms.Label
    Friend WithEvents lblprecio4 As System.Windows.Forms.Label
    Friend WithEvents lblprecio3 As System.Windows.Forms.Label
    Friend WithEvents lblprecio2 As System.Windows.Forms.Label
    Friend WithEvents lblprecio1 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtU3 As System.Windows.Forms.TextBox
    Friend WithEvents txtU4 As System.Windows.Forms.TextBox
    Friend WithEvents txtU2 As System.Windows.Forms.TextBox
    Friend WithEvents txtU1 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtdetalle As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblcosto_final As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents pbu4 As System.Windows.Forms.PictureBox
    Friend WithEvents pbu3 As System.Windows.Forms.PictureBox
    Friend WithEvents pbu2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbu1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbdetalle As System.Windows.Forms.PictureBox
    Friend WithEvents pbcosto As System.Windows.Forms.PictureBox
    Friend WithEvents pbsub_empaque As System.Windows.Forms.PictureBox
    Friend WithEvents pbempaque As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbid_producto As System.Windows.Forms.PictureBox
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_producto_mantenimiento))
        Me.lbltitulo = New System.Windows.Forms.Label
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.chkbloqueado = New System.Windows.Forms.CheckBox
        Me.pbu4 = New System.Windows.Forms.PictureBox
        Me.pbu3 = New System.Windows.Forms.PictureBox
        Me.pbu2 = New System.Windows.Forms.PictureBox
        Me.pbu1 = New System.Windows.Forms.PictureBox
        Me.pbdetalle = New System.Windows.Forms.PictureBox
        Me.pbcosto = New System.Windows.Forms.PictureBox
        Me.pbsub_empaque = New System.Windows.Forms.PictureBox
        Me.pbempaque = New System.Windows.Forms.PictureBox
        Me.PictureBox11 = New System.Windows.Forms.PictureBox
        Me.PictureBox10 = New System.Windows.Forms.PictureBox
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.pbid_producto = New System.Windows.Forms.PictureBox
        Me.lblcosto_final = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.lblconsumidor4 = New System.Windows.Forms.Label
        Me.lblconsumidor3 = New System.Windows.Forms.Label
        Me.lblconsumidor2 = New System.Windows.Forms.Label
        Me.lblconsumidor1 = New System.Windows.Forms.Label
        Me.lblprecio4 = New System.Windows.Forms.Label
        Me.lblprecio3 = New System.Windows.Forms.Label
        Me.lblprecio2 = New System.Windows.Forms.Label
        Me.lblprecio1 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtU3 = New System.Windows.Forms.TextBox
        Me.txtU4 = New System.Windows.Forms.TextBox
        Me.txtU2 = New System.Windows.Forms.TextBox
        Me.txtU1 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtdetalle = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtdescb = New System.Windows.Forms.TextBox
        Me.txtdesca = New System.Windows.Forms.TextBox
        Me.txtcosto = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtsub_empaque = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtempaque = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbrack = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cbpasillo = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbbodega = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblproveedor = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbllinea = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtid_producto = New System.Windows.Forms.TextBox
        Me.pbnombre = New System.Windows.Forms.PictureBox
        Me.txtbarcode = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtobservaciones = New System.Windows.Forms.TextBox
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.chkiv = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbpresentacion = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbsector = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.pbu4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbu3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbu2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbdetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbcosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbsub_empaque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbempaque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbid_producto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbnombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltitulo
        '
        Me.lbltitulo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbltitulo.Location = New System.Drawing.Point(0, 0)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(725, 25)
        Me.lbltitulo.TabIndex = 10
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btncancelar
        '
        Me.btncancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancelar.Image = CType(resources.GetObject("btncancelar.Image"), System.Drawing.Image)
        Me.btncancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancelar.Location = New System.Drawing.Point(379, 609)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(88, 32)
        Me.btncancelar.TabIndex = 19
        Me.btncancelar.Text = "Cancelar"
        Me.ToolTip1.SetToolTip(Me.btncancelar, "No Guardar Datos")
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaceptar.Image = CType(resources.GetObject("btnaceptar.Image"), System.Drawing.Image)
        Me.btnaceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaceptar.Location = New System.Drawing.Point(268, 609)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(88, 32)
        Me.btnaceptar.TabIndex = 18
        Me.btnaceptar.Text = "Aceptar"
        Me.ToolTip1.SetToolTip(Me.btnaceptar, "Guardar Datos")
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cbsector)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.chkbloqueado)
        Me.Panel1.Controls.Add(Me.pbu4)
        Me.Panel1.Controls.Add(Me.pbu3)
        Me.Panel1.Controls.Add(Me.pbu2)
        Me.Panel1.Controls.Add(Me.pbu1)
        Me.Panel1.Controls.Add(Me.pbdetalle)
        Me.Panel1.Controls.Add(Me.pbcosto)
        Me.Panel1.Controls.Add(Me.pbsub_empaque)
        Me.Panel1.Controls.Add(Me.pbempaque)
        Me.Panel1.Controls.Add(Me.PictureBox11)
        Me.Panel1.Controls.Add(Me.PictureBox10)
        Me.Panel1.Controls.Add(Me.PictureBox9)
        Me.Panel1.Controls.Add(Me.PictureBox8)
        Me.Panel1.Controls.Add(Me.PictureBox7)
        Me.Panel1.Controls.Add(Me.PictureBox6)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.pbid_producto)
        Me.Panel1.Controls.Add(Me.lblcosto_final)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.lblconsumidor4)
        Me.Panel1.Controls.Add(Me.lblconsumidor3)
        Me.Panel1.Controls.Add(Me.lblconsumidor2)
        Me.Panel1.Controls.Add(Me.lblconsumidor1)
        Me.Panel1.Controls.Add(Me.lblprecio4)
        Me.Panel1.Controls.Add(Me.lblprecio3)
        Me.Panel1.Controls.Add(Me.lblprecio2)
        Me.Panel1.Controls.Add(Me.lblprecio1)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtU3)
        Me.Panel1.Controls.Add(Me.txtU4)
        Me.Panel1.Controls.Add(Me.txtU2)
        Me.Panel1.Controls.Add(Me.txtU1)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtdetalle)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtdescb)
        Me.Panel1.Controls.Add(Me.txtdesca)
        Me.Panel1.Controls.Add(Me.txtcosto)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtsub_empaque)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtempaque)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.cbrack)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cbpasillo)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cbbodega)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lblproveedor)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.lbllinea)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtid_producto)
        Me.Panel1.Controls.Add(Me.pbnombre)
        Me.Panel1.Controls.Add(Me.txtbarcode)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtobservaciones)
        Me.Panel1.Controls.Add(Me.txtnombre)
        Me.Panel1.Controls.Add(Me.chkiv)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cbpresentacion)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(19, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 565)
        Me.Panel1.TabIndex = 0
        '
        'chkbloqueado
        '
        Me.chkbloqueado.AutoSize = True
        Me.chkbloqueado.Location = New System.Drawing.Point(621, 18)
        Me.chkbloqueado.Name = "chkbloqueado"
        Me.chkbloqueado.Size = New System.Drawing.Size(103, 22)
        Me.chkbloqueado.TabIndex = 126
        Me.chkbloqueado.Text = "Bloqueado"
        Me.chkbloqueado.UseVisualStyleBackColor = True
        '
        'pbu4
        '
        Me.pbu4.Image = CType(resources.GetObject("pbu4.Image"), System.Drawing.Image)
        Me.pbu4.Location = New System.Drawing.Point(580, 358)
        Me.pbu4.Name = "pbu4"
        Me.pbu4.Size = New System.Drawing.Size(12, 12)
        Me.pbu4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbu4.TabIndex = 125
        Me.pbu4.TabStop = False
        Me.pbu4.Visible = False
        '
        'pbu3
        '
        Me.pbu3.Image = CType(resources.GetObject("pbu3.Image"), System.Drawing.Image)
        Me.pbu3.Location = New System.Drawing.Point(457, 354)
        Me.pbu3.Name = "pbu3"
        Me.pbu3.Size = New System.Drawing.Size(12, 12)
        Me.pbu3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbu3.TabIndex = 124
        Me.pbu3.TabStop = False
        Me.pbu3.Visible = False
        '
        'pbu2
        '
        Me.pbu2.Image = CType(resources.GetObject("pbu2.Image"), System.Drawing.Image)
        Me.pbu2.Location = New System.Drawing.Point(343, 358)
        Me.pbu2.Name = "pbu2"
        Me.pbu2.Size = New System.Drawing.Size(12, 12)
        Me.pbu2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbu2.TabIndex = 123
        Me.pbu2.TabStop = False
        Me.pbu2.Visible = False
        '
        'pbu1
        '
        Me.pbu1.Image = CType(resources.GetObject("pbu1.Image"), System.Drawing.Image)
        Me.pbu1.Location = New System.Drawing.Point(210, 354)
        Me.pbu1.Name = "pbu1"
        Me.pbu1.Size = New System.Drawing.Size(12, 12)
        Me.pbu1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbu1.TabIndex = 122
        Me.pbu1.TabStop = False
        Me.pbu1.Visible = False
        '
        'pbdetalle
        '
        Me.pbdetalle.Image = CType(resources.GetObject("pbdetalle.Image"), System.Drawing.Image)
        Me.pbdetalle.Location = New System.Drawing.Point(206, 307)
        Me.pbdetalle.Name = "pbdetalle"
        Me.pbdetalle.Size = New System.Drawing.Size(12, 12)
        Me.pbdetalle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbdetalle.TabIndex = 121
        Me.pbdetalle.TabStop = False
        Me.pbdetalle.Visible = False
        '
        'pbcosto
        '
        Me.pbcosto.Image = CType(resources.GetObject("pbcosto.Image"), System.Drawing.Image)
        Me.pbcosto.Location = New System.Drawing.Point(243, 266)
        Me.pbcosto.Name = "pbcosto"
        Me.pbcosto.Size = New System.Drawing.Size(12, 12)
        Me.pbcosto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbcosto.TabIndex = 120
        Me.pbcosto.TabStop = False
        Me.pbcosto.Visible = False
        '
        'pbsub_empaque
        '
        Me.pbsub_empaque.Image = CType(resources.GetObject("pbsub_empaque.Image"), System.Drawing.Image)
        Me.pbsub_empaque.Location = New System.Drawing.Point(429, 222)
        Me.pbsub_empaque.Name = "pbsub_empaque"
        Me.pbsub_empaque.Size = New System.Drawing.Size(12, 12)
        Me.pbsub_empaque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbsub_empaque.TabIndex = 119
        Me.pbsub_empaque.TabStop = False
        Me.pbsub_empaque.Visible = False
        '
        'pbempaque
        '
        Me.pbempaque.Image = CType(resources.GetObject("pbempaque.Image"), System.Drawing.Image)
        Me.pbempaque.Location = New System.Drawing.Point(205, 210)
        Me.pbempaque.Name = "pbempaque"
        Me.pbempaque.Size = New System.Drawing.Size(12, 12)
        Me.pbempaque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbempaque.TabIndex = 118
        Me.pbempaque.TabStop = False
        Me.pbempaque.Visible = False
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(580, 358)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox11.TabIndex = 117
        Me.PictureBox11.TabStop = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(452, 358)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox10.TabIndex = 116
        Me.PictureBox10.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(341, 358)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 115
        Me.PictureBox9.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(210, 358)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 114
        Me.PictureBox8.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(205, 303)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 113
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(236, 266)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 112
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(433, 222)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 111
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(205, 212)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 110
        Me.PictureBox4.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(210, 35)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 109
        Me.PictureBox2.TabStop = False
        '
        'pbid_producto
        '
        Me.pbid_producto.Image = CType(resources.GetObject("pbid_producto.Image"), System.Drawing.Image)
        Me.pbid_producto.Location = New System.Drawing.Point(206, 31)
        Me.pbid_producto.Name = "pbid_producto"
        Me.pbid_producto.Size = New System.Drawing.Size(12, 12)
        Me.pbid_producto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbid_producto.TabIndex = 108
        Me.pbid_producto.TabStop = False
        Me.pbid_producto.Visible = False
        '
        'lblcosto_final
        '
        Me.lblcosto_final.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblcosto_final.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcosto_final.Location = New System.Drawing.Point(566, 254)
        Me.lblcosto_final.Name = "lblcosto_final"
        Me.lblcosto_final.Size = New System.Drawing.Size(115, 24)
        Me.lblcosto_final.TabIndex = 107
        Me.lblcosto_final.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(447, 254)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(109, 24)
        Me.Label27.TabIndex = 106
        Me.Label27.Text = "Costo Final"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblconsumidor4
        '
        Me.lblconsumidor4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblconsumidor4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconsumidor4.Location = New System.Drawing.Point(498, 425)
        Me.lblconsumidor4.Name = "lblconsumidor4"
        Me.lblconsumidor4.Size = New System.Drawing.Size(98, 24)
        Me.lblconsumidor4.TabIndex = 105
        Me.lblconsumidor4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblconsumidor3
        '
        Me.lblconsumidor3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblconsumidor3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconsumidor3.Location = New System.Drawing.Point(371, 425)
        Me.lblconsumidor3.Name = "lblconsumidor3"
        Me.lblconsumidor3.Size = New System.Drawing.Size(98, 24)
        Me.lblconsumidor3.TabIndex = 104
        Me.lblconsumidor3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblconsumidor2
        '
        Me.lblconsumidor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblconsumidor2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconsumidor2.Location = New System.Drawing.Point(257, 425)
        Me.lblconsumidor2.Name = "lblconsumidor2"
        Me.lblconsumidor2.Size = New System.Drawing.Size(98, 24)
        Me.lblconsumidor2.TabIndex = 103
        Me.lblconsumidor2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblconsumidor1
        '
        Me.lblconsumidor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblconsumidor1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconsumidor1.Location = New System.Drawing.Point(130, 425)
        Me.lblconsumidor1.Name = "lblconsumidor1"
        Me.lblconsumidor1.Size = New System.Drawing.Size(98, 24)
        Me.lblconsumidor1.TabIndex = 102
        Me.lblconsumidor1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblprecio4
        '
        Me.lblprecio4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblprecio4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprecio4.Location = New System.Drawing.Point(498, 390)
        Me.lblprecio4.Name = "lblprecio4"
        Me.lblprecio4.Size = New System.Drawing.Size(98, 24)
        Me.lblprecio4.TabIndex = 101
        Me.lblprecio4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblprecio3
        '
        Me.lblprecio3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblprecio3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprecio3.Location = New System.Drawing.Point(371, 390)
        Me.lblprecio3.Name = "lblprecio3"
        Me.lblprecio3.Size = New System.Drawing.Size(98, 24)
        Me.lblprecio3.TabIndex = 100
        Me.lblprecio3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblprecio2
        '
        Me.lblprecio2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblprecio2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprecio2.Location = New System.Drawing.Point(257, 390)
        Me.lblprecio2.Name = "lblprecio2"
        Me.lblprecio2.Size = New System.Drawing.Size(98, 24)
        Me.lblprecio2.TabIndex = 99
        Me.lblprecio2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblprecio1
        '
        Me.lblprecio1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblprecio1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprecio1.Location = New System.Drawing.Point(130, 390)
        Me.lblprecio1.Name = "lblprecio1"
        Me.lblprecio1.Size = New System.Drawing.Size(98, 24)
        Me.lblprecio1.TabIndex = 98
        Me.lblprecio1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(14, 425)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 24)
        Me.Label18.TabIndex = 97
        Me.Label18.Text = "Consumidor"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(14, 390)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 24)
        Me.Label17.TabIndex = 96
        Me.Label17.Text = "Precio"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtU3
        '
        Me.txtU3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtU3.Location = New System.Drawing.Point(401, 354)
        Me.txtU3.MaxLength = 6
        Me.txtU3.Name = "txtU3"
        Me.txtU3.Size = New System.Drawing.Size(50, 26)
        Me.txtU3.TabIndex = 15
        Me.txtU3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtU3, "Digitalice el código de barrar del producto")
        '
        'txtU4
        '
        Me.txtU4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtU4.Location = New System.Drawing.Point(521, 354)
        Me.txtU4.MaxLength = 6
        Me.txtU4.Name = "txtU4"
        Me.txtU4.Size = New System.Drawing.Size(53, 26)
        Me.txtU4.TabIndex = 16
        Me.txtU4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtU4, "Digitalice el código de barrar del producto")
        '
        'txtU2
        '
        Me.txtU2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtU2.Location = New System.Drawing.Point(280, 354)
        Me.txtU2.MaxLength = 6
        Me.txtU2.Name = "txtU2"
        Me.txtU2.Size = New System.Drawing.Size(55, 26)
        Me.txtU2.TabIndex = 14
        Me.txtU2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtU2, "Digitalice el código de barrar del producto")
        '
        'txtU1
        '
        Me.txtU1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtU1.Location = New System.Drawing.Point(134, 350)
        Me.txtU1.MaxLength = 6
        Me.txtU1.Name = "txtU1"
        Me.txtU1.Size = New System.Drawing.Size(70, 26)
        Me.txtU1.TabIndex = 13
        Me.txtU1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtU1, "Digitalice el código de barrar del producto")
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 350)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 24)
        Me.Label16.TabIndex = 91
        Me.Label16.Text = "Utilidad"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtdetalle
        '
        Me.txtdetalle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdetalle.Location = New System.Drawing.Point(134, 298)
        Me.txtdetalle.MaxLength = 6
        Me.txtdetalle.Name = "txtdetalle"
        Me.txtdetalle.Size = New System.Drawing.Size(65, 26)
        Me.txtdetalle.TabIndex = 11
        Me.txtdetalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtdetalle, "Digitalice el código de barrar del producto")
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 300)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 24)
        Me.Label15.TabIndex = 89
        Me.Label15.Text = "Detalle"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtdescb
        '
        Me.txtdescb.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescb.Location = New System.Drawing.Point(317, 256)
        Me.txtdescb.MaxLength = 6
        Me.txtdescb.Name = "txtdescb"
        Me.txtdescb.Size = New System.Drawing.Size(38, 26)
        Me.txtdescb.TabIndex = 10
        Me.txtdescb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtdescb, "Digitalice el código de barrar del producto")
        '
        'txtdesca
        '
        Me.txtdesca.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdesca.Location = New System.Drawing.Point(261, 256)
        Me.txtdesca.MaxLength = 6
        Me.txtdesca.Name = "txtdesca"
        Me.txtdesca.Size = New System.Drawing.Size(34, 26)
        Me.txtdesca.TabIndex = 9
        Me.txtdesca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtdesca, "Digitalice el código de barrar del producto")
        '
        'txtcosto
        '
        Me.txtcosto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcosto.Location = New System.Drawing.Point(134, 256)
        Me.txtcosto.MaxLength = 12
        Me.txtcosto.Name = "txtcosto"
        Me.txtcosto.Size = New System.Drawing.Size(96, 26)
        Me.txtcosto.TabIndex = 8
        Me.txtcosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtcosto, "Digitalice el código de barrar del producto")
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(14, 258)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 24)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "Costo"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtsub_empaque
        '
        Me.txtsub_empaque.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsub_empaque.Location = New System.Drawing.Point(358, 212)
        Me.txtsub_empaque.MaxLength = 6
        Me.txtsub_empaque.Name = "txtsub_empaque"
        Me.txtsub_empaque.Size = New System.Drawing.Size(65, 26)
        Me.txtsub_empaque.TabIndex = 7
        Me.txtsub_empaque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtsub_empaque, "Digitalice el código de barrar del producto")
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(232, 210)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 24)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Sub Empaque"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtempaque
        '
        Me.txtempaque.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtempaque.Location = New System.Drawing.Point(134, 208)
        Me.txtempaque.MaxLength = 6
        Me.txtempaque.Name = "txtempaque"
        Me.txtempaque.Size = New System.Drawing.Size(65, 26)
        Me.txtempaque.TabIndex = 6
        Me.txtempaque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtempaque, "Digitalice el código de barrar del producto")
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 210)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 24)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "Empaque"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbrack
        '
        Me.cbrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbrack.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbrack.Items.AddRange(New Object() {"0", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60"})
        Me.cbrack.Location = New System.Drawing.Point(280, 166)
        Me.cbrack.Name = "cbrack"
        Me.cbrack.Size = New System.Drawing.Size(65, 26)
        Me.cbrack.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cbrack, "Seleccione la presentacion del Producto")
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(228, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 24)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "Rack"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbpasillo
        '
        Me.cbpasillo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbpasillo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbpasillo.Items.AddRange(New Object() {"0", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39"})
        Me.cbpasillo.Location = New System.Drawing.Point(639, 166)
        Me.cbpasillo.Name = "cbpasillo"
        Me.cbpasillo.Size = New System.Drawing.Size(65, 26)
        Me.cbpasillo.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cbpasillo, "Seleccione la presentacion del Producto")
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(577, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 24)
        Me.Label10.TabIndex = 78
        Me.Label10.Text = "Pasillo"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbbodega
        '
        Me.cbbodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbodega.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbbodega.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.cbbodega.Location = New System.Drawing.Point(465, 166)
        Me.cbbodega.Name = "cbbodega"
        Me.cbbodega.Size = New System.Drawing.Size(65, 26)
        Me.cbbodega.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cbbodega, "Seleccione la presentacion del Producto")
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(389, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 24)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Bodega"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblproveedor
        '
        Me.lblproveedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproveedor.Location = New System.Drawing.Point(130, 129)
        Me.lblproveedor.Name = "lblproveedor"
        Me.lblproveedor.Size = New System.Drawing.Size(509, 24)
        Me.lblproveedor.TabIndex = 74
        Me.lblproveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 24)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Proveedor"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbllinea
        '
        Me.lbllinea.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllinea.Location = New System.Drawing.Point(130, 94)
        Me.lbllinea.Name = "lbllinea"
        Me.lbllinea.Size = New System.Drawing.Size(509, 24)
        Me.lbllinea.TabIndex = 72
        Me.lbllinea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 24)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Linea"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtid_producto
        '
        Me.txtid_producto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_producto.Location = New System.Drawing.Point(134, 21)
        Me.txtid_producto.MaxLength = 6
        Me.txtid_producto.Name = "txtid_producto"
        Me.txtid_producto.Size = New System.Drawing.Size(65, 26)
        Me.txtid_producto.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtid_producto, "Digitalice el código de barrar del producto")
        '
        'pbnombre
        '
        Me.pbnombre.Image = CType(resources.GetObject("pbnombre.Image"), System.Drawing.Image)
        Me.pbnombre.Location = New System.Drawing.Point(562, 63)
        Me.pbnombre.Name = "pbnombre"
        Me.pbnombre.Size = New System.Drawing.Size(12, 12)
        Me.pbnombre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbnombre.TabIndex = 69
        Me.pbnombre.TabStop = False
        Me.pbnombre.Visible = False
        '
        'txtbarcode
        '
        Me.txtbarcode.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarcode.Location = New System.Drawing.Point(433, 18)
        Me.txtbarcode.MaxLength = 14
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(145, 26)
        Me.txtbarcode.TabIndex = 70
        Me.ToolTip1.SetToolTip(Me.txtbarcode, "Digitalice el código de barrar del producto")
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(304, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 24)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Código Barras"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtobservaciones
        '
        Me.txtobservaciones.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtobservaciones.Location = New System.Drawing.Point(130, 491)
        Me.txtobservaciones.MaxLength = 50
        Me.txtobservaciones.Multiline = True
        Me.txtobservaciones.Name = "txtobservaciones"
        Me.txtobservaciones.Size = New System.Drawing.Size(466, 39)
        Me.txtobservaciones.TabIndex = 17
        '
        'txtnombre
        '
        Me.txtnombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(134, 57)
        Me.txtnombre.MaxLength = 50
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(422, 26)
        Me.txtnombre.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtnombre, "Escriba el nombre del Producto")
        '
        'chkiv
        '
        Me.chkiv.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkiv.Location = New System.Drawing.Point(236, 303)
        Me.chkiv.Name = "chkiv"
        Me.chkiv.Size = New System.Drawing.Size(16, 16)
        Me.chkiv.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(258, 300)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 24)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "IV"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbpresentacion
        '
        Me.cbpresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbpresentacion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbpresentacion.Items.AddRange(New Object() {"Und", "Caj", "Blt", "Pqt"})
        Me.cbpresentacion.Location = New System.Drawing.Point(134, 168)
        Me.cbpresentacion.Name = "cbpresentacion"
        Me.cbpresentacion.Size = New System.Drawing.Size(65, 26)
        Me.cbpresentacion.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cbpresentacion, "Seleccione la presentacion del Producto")
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 24)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Código"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 490)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 24)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Observaciones"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 24)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Presentación"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 24)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(566, 67)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 29
        Me.PictureBox3.TabStop = False
        '
        'cbsector
        '
        Me.cbsector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbsector.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbsector.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"})
        Me.cbsector.Location = New System.Drawing.Point(639, 210)
        Me.cbsector.Name = "cbsector"
        Me.cbsector.Size = New System.Drawing.Size(65, 26)
        Me.cbsector.TabIndex = 127
        Me.ToolTip1.SetToolTip(Me.cbsector, "Seleccione la presentacion del Producto")
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(577, 212)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 24)
        Me.Label19.TabIndex = 128
        Me.Label19.Text = "Sector"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_producto_mantenimiento
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(822, 653)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.lbltitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frm_producto_mantenimiento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Productos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbu4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbu3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbu2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbdetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbcosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbsub_empaque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbempaque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbid_producto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbnombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'Try
        Dim Fi As Boolean = False
        If txtid_producto.Text = "" Then
            pbid_producto.Visible = True
            Fi = True
        Else
            pbid_Producto.Visible = False
        End If


        If txtnombre.Text = "" Then
            pbnombre.Visible = True
            Fi = True
        Else
            pbnombre.Visible = False
        End If


        If Val(txtempaque.Text) = 0 Then
            pbempaque.Visible = True
            Fi = True
        Else
            pbempaque.Visible = False
        End If

        If Val(txtsub_empaque.Text) = 0 Then
            pbsub_empaque.Visible = True
            Fi = True
        Else
            pbsub_empaque.Visible = False
        End If


        If Val(txtcosto.Text) = 0 Then
            pbcosto.Visible = True
            Fi = True
        Else
            pbcosto.Visible = False
        End If

        If Val(txtdetalle.Text) = 0 Then
            pbdetalle.Visible = True
            Fi = True
        Else
            pbdetalle.Visible = False
        End If

        If Val(txtU1.Text) = 0 Then
            pbu1.Visible = True
            Fi = True
        Else
            pbu1.Visible = False
        End If

        If Val(txtU2.Text) = 0 Then
            pbu2.Visible = True
            Fi = True
        Else
            pbu2.Visible = False
        End If

        If Val(txtU3.Text) = 0 Then
            pbu3.Visible = True
            Fi = True
        Else
            pbu3.Visible = False
        End If

        If Val(txtU4.Text) = 0 Then
            pbu4.Visible = True
            Fi = True
        Else
            pbu4.Visible = False
        End If

        If Fi Then
            MessageBox.Show("Hay campos requeridos sin completar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        With myForms.frm_datos_mantenimiento

            Dim r As DataRow
            r = TS(.Producto, "nombre", txtnombre.Text)
            If Not (r Is Nothing) Then
                If (lbltitulo.Text = "Incluir Producto") Or (lbltitulo.Text <> "Incluir Producto" And .dtgproducto.Item("dtgprdid", .dtgproducto.CurrentRow.Index).Value <> r("id_producto")) Then
                    MessageBox.Show("Nombre de Producto Ya Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtnombre.Focus()
                    SendKeys.Send("{home}+{end}")
                    Exit Sub
                End If
            End If

            r = TS(.Producto, "id_producto", txtid_producto.Text)
            If Not (r Is Nothing) Then
                If (lbltitulo.Text = "Incluir Producto") Or (lbltitulo.Text <> "Incluir Producto" And .dtgproducto.Item("dtgprdid", .dtgproducto.CurrentRow.Index).Value <> r("id_producto")) Then
                    MessageBox.Show("Código de Producto Ya Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtid_producto.Focus()
                    SendKeys.Send("{home}+{end}")
                    Exit Sub
                End If
            End If
            costo_final_calcular()

            If lbltitulo.Text = "Incluir Producto" Then
                .rowprd = .Dvproducto.Table.NewRow()
            End If

            .rowprd("id_producto") = txtid_producto.Text
            .rowprd("nombre") = txtnombre.Text
            .rowprd("observaciones") = IIf(txtobservaciones.Text = "", "", txtobservaciones.Text)
            .rowprd("presentacion") = cbpresentacion.SelectedIndex + 1
            .rowprd("Iv") = IIf(chkiv.Checked, 1, 0)
            .rowprd("barcode") = txtbarcode.Text
            .rowprd("bloqueado") = IIf(chkbloqueado.Checked, 1, 0)

            Dim cmd As New SqlCommand
            cmd.Connection = CONN1

            If lbltitulo.Text = "Incluir Producto" Then
                sql = "insert into producto (id_producto,barcode,nombre,presentacion,id_b_r,id_pasillo,empaque,sub_empaque," + _
                "detalle,costo,iv,utilidad_1,utilidad_2,utilidad_3,utilidad_4,observaciones,id_proveedor,id_linea,id_sector,bloqueado) values (" + _
                "'" + txtid_producto.Text + "'," + _
                "'" + txtbarcode.Text + "'," + _
                "'" + txtnombre.Text + "'," + _
                (cbpresentacion.SelectedIndex + 1).ToString + "," + _
                IIf(cbrack.SelectedIndex > 0, cbrack.Text, cbbodega.Text) + "," + _
                cbpasillo.Text + "," + _
                txtempaque.Text + "," + _
                txtsub_empaque.Text + "," + _
                (txtdetalle.Text / 100).ToString + "," + _
                CF.ToString + "," + _
                IIf(chkiv.Checked, "1", "0") + "," + _
                (txtU1.Text / 100).ToString + "," + _
                (txtU2.Text / 100).ToString + "," + _
                (txtU3.Text / 100).ToString + "," + _
                (txtU4.Text / 100).ToString + "," + _
                "'" + txtobservaciones.Text + "'," + _
                 txtid_producto.Text.Substring(0, 2) + "," + _
               txtid_producto.Text.Substring(2, 2) + ",'" + _
               cbsector.Text + "'," + _
                IIf(chkbloqueado.Checked, "1", "0") + ")"

            Else
                sql = "update producto set " + _
                "id_producto='" + txtid_producto.Text + "'," + _
                "barcode='" + txtbarcode.Text + "'," + _
                "nombre='" + txtnombre.Text + "'," + _
                "presentacion=" + (cbpresentacion.SelectedIndex + 1).ToString + "," + _
                "id_b_r=" + IIf(cbrack.SelectedIndex > 0, cbrack.Text, cbbodega.Text) + "," + _
                "id_pasillo=" + cbpasillo.Text + "," + _
                "empaque=" + txtempaque.Text + "," + _
                "sub_empaque=" + txtsub_empaque.Text + "," + _
                "detalle=" + (txtdetalle.Text / 100).ToString + "," + _
                "costo=" + CF.ToString + "," + _
                "iv=" + IIf(chkiv.Checked, "1", "0") + "," + _
                "utilidad_1=" + (txtU1.Text / 100).ToString + "," + _
                "utilidad_2=" + (txtU2.Text / 100).ToString + "," + _
                "utilidad_3=" + (txtU3.Text / 100).ToString + "," + _
                "utilidad_4=" + (txtU4.Text / 100).ToString + "," + _
                 "observaciones='" + txtobservaciones.Text + "'," + _
                "id_proveedor=" + txtid_producto.Text.Substring(0, 2) + "," + _
                 "id_linea=" + txtid_producto.Text.Substring(2, 2) + "," + _
                 "id_sector='" + cbsector.Text + "'," + _
                 "bloqueado=" + IIf(chkbloqueado.Checked, "1", "0") + _
                 " where id_producto='" + Id_Producto_ant + "'"
            End If
            cmd.CommandText = sql
            OpenConn()
            cmd.ExecuteNonQuery()
        End With
        Me.Close()
        'Catch myerror As Exception
        ' ONEX(Me.Name, myerror)
        'End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub frm_producto_mantenimiento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myForms.frm_datos_mantenimiento.producto_grid()
    End Sub

    Private Sub frm_producto_mantenimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub frm_producto_mantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim parametro As DataTable
        parametro = Table("select * from parametro", "")
        PIV = parametro.Rows(0).Item("iv")
    End Sub

    Public Sub Precio_calcular()
        Dim P1 As Decimal
        Dim P2 As Decimal
        Dim P3 As Decimal
        Dim P4 As Decimal

        Dim C1 As Decimal
        Dim C2 As Decimal
        Dim C3 As Decimal
        Dim C4 As Decimal

        Dim E As Decimal = IIf(Val(txtempaque.Text) = 0, 1, txtempaque.Text)
        Dim SE As Decimal = IIf(Val(txtsub_empaque.Text) = 0, 1, txtsub_empaque.Text)

        P1 = (CF * (1 + Val(txtU1.Text) / 100)) / E
        P2 = (CF * (1 + Val(txtU2.Text) / 100)) / E
        P3 = (CF * (1 + Val(txtU3.Text) / 100)) / E
        P4 = (CF * (1 + Val(txtU4.Text) / 100)) / E


        lblprecio1.Text = FormatNumber(P1, 2)
        lblprecio2.Text = FormatNumber(P2, 2)
        lblprecio3.Text = FormatNumber(P3, 2)
        lblprecio4.Text = FormatNumber(P4, 2)

        Dim Factor As Decimal = (1 + Val(txtdetalle.Text) / 100) * (1 + IIf(chkiv.Checked, PIV, 0))


        C1 = (CF * (1 + Val(txtU1.Text) / 100) * Factor) / E / SE
        C2 = (CF * (1 + Val(txtU2.Text) / 100) * Factor) / E / SE
        C3 = (CF * (1 + Val(txtU3.Text) / 100) * Factor) / E / SE
        C4 = (CF * (1 + Val(txtU4.Text) / 100) * Factor) / E / SE

        lblconsumidor1.Text = FormatNumber(C1, 2)
        lblconsumidor2.Text = FormatNumber(C2, 2)
        lblconsumidor3.Text = FormatNumber(C3, 2)
        lblconsumidor4.Text = FormatNumber(C4, 2)


    End Sub


    Public Sub costo_final_calcular()
        Dim d1 As Decimal
        Dim d2 As Decimal
        d1 = Val(txtcosto.Text) * Val(txtdesca.Text) / 100
        d2 = (Val(txtcosto.Text) - d1) * Val(txtdescb.Text) / 100
        CF = Val(txtcosto.Text) - d1 - d2
        lblcosto_final.Text = FormatNumber(CF, 2)
    End Sub

    Private Sub txtid_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid_producto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            Id_producto_validar()
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtid_producto.Text, False)
        End If
    End Sub

    Private Sub txtempaque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtempaque.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Precio_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtempaque.Text, False)
        End If
    End Sub

    Private Sub txtempaque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempaque.TextChanged

    End Sub

    Private Sub txtsub_empaque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsub_empaque.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Precio_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtsub_empaque.Text, False)
        End If
    End Sub

    Private Sub txtsub_empaque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsub_empaque.TextChanged

    End Sub

    Private Sub txtdetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdetalle.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Precio_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtdetalle.Text, True)
        End If
    End Sub

    Private Sub txtdetalle_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdetalle.MouseHover

    End Sub

    Private Sub txtdetalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdetalle.TextChanged

    End Sub

    Private Sub txtU1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Precio_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtU1.Text, True)
        End If
    End Sub

    Private Sub txtU1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtU1.TextChanged

    End Sub

    Private Sub txtU2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Precio_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtU2.Text, True)
        End If
    End Sub

    Private Sub txtU2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtU2.TextChanged

    End Sub

    Private Sub txtU3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Precio_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtU3.Text, True)
        End If
    End Sub

    Private Sub txtU3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtU3.TextChanged

    End Sub

    Private Sub txtU4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU4.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Precio_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtU4.Text, True)
        End If
    End Sub

    Private Sub txtU4_RightToLeftChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtU4.RightToLeftChanged

    End Sub

    Private Sub txtU4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtU4.TextChanged

    End Sub

    Private Sub chkiv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkiv.CheckedChanged
            Precio_calcular()
    End Sub

    Private Sub txtcosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcosto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            costo_final_calcular()
            Precio_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtcosto.Text, True)
        End If

    End Sub

    Private Sub txtcosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcosto.TextChanged
    End Sub

    Private Sub txtdesca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesca.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            costo_final_calcular()
            Precio_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtdesca.Text, True)
        End If
    End Sub

    Private Sub txtdesca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdesca.TextChanged

    End Sub

    Private Sub txtdescb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescb.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            costo_final_calcular()
            Precio_calcular()
            SendKeys.Send("{TAB}")
        Else
            e.Handled = Numerico(Asc(e.KeyChar), txtdescb.Text, True)
        End If
    End Sub

    Private Sub txtdescb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdescb.TextChanged

    End Sub

    Private Sub chkiv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkiv.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Precio_calcular()
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Sub id_producto_validar()
        If txtid_producto.Text.Length < 6 Then
            MessageBox.Show("El Código del Producto debe ser de 6 espacios", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid_producto.Focus()
            SendKeys.Send("{home}+{end}")
            Exit Sub
        End If

        With myForms.frm_datos_mantenimiento
            Dim rowp As DataRow = .Proveedor.Rows.Find(txtid_producto.Text.Substring(0, 2))
            If rowp Is Nothing Then
                MessageBox.Show("Proveedor NO Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_producto.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If

            Dim rowl As DataRow = .Linea.Rows.Find(txtid_producto.Text.Substring(2, 2))
            If rowl Is Nothing Then
                MessageBox.Show("Linea NO Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtid_producto.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If
            lblproveedor.Text = rowp("nombre")
            lbllinea.Text = rowl("nombre")
        End With

    End Sub

    Private Sub txtid_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid_producto.TextChanged

    End Sub

    Private Sub cbpresentacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbpresentacion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbpresentacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpresentacion.SelectedIndexChanged

    End Sub

    Private Sub cbrack_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbrack.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbrack_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbrack.SelectedIndexChanged

    End Sub

    Private Sub cbbodega_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbbodega.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbbodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbodega.SelectedIndexChanged

    End Sub

    Private Sub cbpasillo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbpasillo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbpasillo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpasillo.SelectedIndexChanged

    End Sub

    Private Sub txtobservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtobservaciones.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            btnaceptar.Focus()
        End If
    End Sub

    Private Sub txtobservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtobservaciones.TextChanged

    End Sub

    Private Sub lblcosto_final_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblcosto_final.Click

    End Sub
End Class
