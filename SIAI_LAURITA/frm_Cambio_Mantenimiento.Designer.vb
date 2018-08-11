<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Cambio_Mantenimiento
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Cambio_Mantenimiento))
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.lblprecio = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtid_producto = New System.Windows.Forms.TextBox
        Me.cbunidad = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblproducto_nombre = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblempaque = New System.Windows.Forms.Label
        Me.lblconsumidor = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbltitulo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pbcantidad = New System.Windows.Forms.PictureBox
        Me.pbid_producto = New System.Windows.Forms.PictureBox
        Me.lbliv = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        CType(Me.pbcantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbid_producto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtcantidad
        '
        Me.txtcantidad.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidad.Location = New System.Drawing.Point(94, 45)
        Me.txtcantidad.MaxLength = 15
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(54, 26)
        Me.txtcantidad.TabIndex = 1
        Me.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtcantidad, "Escriba la cantidad del Producto")
        '
        'lblprecio
        '
        Me.lblprecio.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprecio.Location = New System.Drawing.Point(96, 126)
        Me.lblprecio.Name = "lblprecio"
        Me.lblprecio.Size = New System.Drawing.Size(111, 24)
        Me.lblprecio.TabIndex = 47
        Me.lblprecio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 24)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Precio"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtid_producto
        '
        Me.txtid_producto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_producto.Location = New System.Drawing.Point(94, 8)
        Me.txtid_producto.MaxLength = 6
        Me.txtid_producto.Name = "txtid_producto"
        Me.txtid_producto.Size = New System.Drawing.Size(62, 26)
        Me.txtid_producto.TabIndex = 0
        Me.txtid_producto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtid_producto, "Escriba el Código del Producto")
        '
        'cbunidad
        '
        Me.cbunidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbunidad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbunidad.Items.AddRange(New Object() {"Und", "Caj", "Blt", "Pqt"})
        Me.cbunidad.Location = New System.Drawing.Point(93, 83)
        Me.cbunidad.Name = "cbunidad"
        Me.cbunidad.Size = New System.Drawing.Size(65, 24)
        Me.cbunidad.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cbunidad, "Seleccione la presentacion del Producto")
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 24)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Cantidad"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblproducto_nombre
        '
        Me.lblproducto_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproducto_nombre.Location = New System.Drawing.Point(201, 11)
        Me.lblproducto_nombre.Name = "lblproducto_nombre"
        Me.lblproducto_nombre.Size = New System.Drawing.Size(450, 23)
        Me.lblproducto_nombre.TabIndex = 42
        Me.lblproducto_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 24)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Código"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblempaque
        '
        Me.lblempaque.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempaque.Location = New System.Drawing.Point(180, 83)
        Me.lblempaque.Name = "lblempaque"
        Me.lblempaque.Size = New System.Drawing.Size(111, 24)
        Me.lblempaque.TabIndex = 75
        Me.lblempaque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblconsumidor
        '
        Me.lblconsumidor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconsumidor.Location = New System.Drawing.Point(409, 126)
        Me.lblconsumidor.Name = "lblconsumidor"
        Me.lblconsumidor.Size = New System.Drawing.Size(101, 24)
        Me.lblconsumidor.TabIndex = 74
        Me.lblconsumidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(288, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 24)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Consumidor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltitulo
        '
        Me.lbltitulo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.Red
        Me.lbltitulo.Location = New System.Drawing.Point(-1, -1)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(729, 27)
        Me.lbltitulo.TabIndex = 10
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 24)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Unidad"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblempaque)
        Me.Panel1.Controls.Add(Me.lblconsumidor)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cbunidad)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.pbcantidad)
        Me.Panel1.Controls.Add(Me.pbid_producto)
        Me.Panel1.Controls.Add(Me.lbliv)
        Me.Panel1.Controls.Add(Me.txtcantidad)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.lblprecio)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblproducto_nombre)
        Me.Panel1.Controls.Add(Me.txtid_producto)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(24, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(681, 175)
        Me.Panel1.TabIndex = 0
        '
        'pbcantidad
        '
        Me.pbcantidad.Image = CType(resources.GetObject("pbcantidad.Image"), System.Drawing.Image)
        Me.pbcantidad.Location = New System.Drawing.Point(154, 57)
        Me.pbcantidad.Name = "pbcantidad"
        Me.pbcantidad.Size = New System.Drawing.Size(12, 12)
        Me.pbcantidad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbcantidad.TabIndex = 70
        Me.pbcantidad.TabStop = False
        Me.pbcantidad.Visible = False
        '
        'pbid_producto
        '
        Me.pbid_producto.Image = CType(resources.GetObject("pbid_producto.Image"), System.Drawing.Image)
        Me.pbid_producto.Location = New System.Drawing.Point(183, 18)
        Me.pbid_producto.Name = "pbid_producto"
        Me.pbid_producto.Size = New System.Drawing.Size(12, 12)
        Me.pbid_producto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbid_producto.TabIndex = 69
        Me.pbid_producto.TabStop = False
        Me.pbid_producto.Visible = False
        '
        'lbliv
        '
        Me.lbliv.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbliv.Location = New System.Drawing.Point(213, 128)
        Me.lbliv.Name = "lbliv"
        Me.lbliv.Size = New System.Drawing.Size(33, 24)
        Me.lbliv.TabIndex = 62
        Me.lbliv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(154, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 58
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(183, 18)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 56
        Me.PictureBox3.TabStop = False
        '
        'frm_Cambio_Mantenimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 219)
        Me.Controls.Add(Me.lbltitulo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Name = "frm_Cambio_Mantenimiento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbcantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbid_producto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblprecio As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtid_producto As System.Windows.Forms.TextBox
    Friend WithEvents cbunidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblproducto_nombre As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblempaque As System.Windows.Forms.Label
    Friend WithEvents lblconsumidor As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbcantidad As System.Windows.Forms.PictureBox
    Friend WithEvents pbid_producto As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbliv As System.Windows.Forms.Label
End Class
