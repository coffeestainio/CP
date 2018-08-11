<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Puntos_Debito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Puntos_Debito))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pbpuntos = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtpuntos = New System.Windows.Forms.TextBox
        Me.txtreferencia = New System.Windows.Forms.TextBox
        Me.pbid_cliente = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.dddd = New System.Windows.Forms.Label
        Me.lblrestante = New System.Windows.Forms.Label
        Me.lbldebito = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbldisponible = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtid_cliente = New System.Windows.Forms.TextBox
        Me.lblnombre_cliente = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbltitulo = New System.Windows.Forms.Label
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.pbpuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbid_cliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.pbpuntos)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtpuntos)
        Me.Panel1.Controls.Add(Me.txtreferencia)
        Me.Panel1.Controls.Add(Me.pbid_cliente)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.dddd)
        Me.Panel1.Controls.Add(Me.lblrestante)
        Me.Panel1.Controls.Add(Me.lbldebito)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lbldisponible)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtid_cliente)
        Me.Panel1.Controls.Add(Me.lblnombre_cliente)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(865, 129)
        Me.Panel1.TabIndex = 0
        '
        'pbpuntos
        '
        Me.pbpuntos.Image = CType(resources.GetObject("pbpuntos.Image"), System.Drawing.Image)
        Me.pbpuntos.Location = New System.Drawing.Point(231, 51)
        Me.pbpuntos.Name = "pbpuntos"
        Me.pbpuntos.Size = New System.Drawing.Size(12, 12)
        Me.pbpuntos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbpuntos.TabIndex = 75
        Me.pbpuntos.TabStop = False
        Me.pbpuntos.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(231, 55)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 74
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 24)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Puntos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtpuntos
        '
        Me.txtpuntos.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpuntos.Location = New System.Drawing.Point(116, 43)
        Me.txtpuntos.MaxLength = 12
        Me.txtpuntos.Name = "txtpuntos"
        Me.txtpuntos.Size = New System.Drawing.Size(109, 26)
        Me.txtpuntos.TabIndex = 2
        Me.txtpuntos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtreferencia
        '
        Me.txtreferencia.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtreferencia.Location = New System.Drawing.Point(116, 80)
        Me.txtreferencia.MaxLength = 25
        Me.txtreferencia.Name = "txtreferencia"
        Me.txtreferencia.Size = New System.Drawing.Size(241, 26)
        Me.txtreferencia.TabIndex = 3
        '
        'pbid_cliente
        '
        Me.pbid_cliente.Image = CType(resources.GetObject("pbid_cliente.Image"), System.Drawing.Image)
        Me.pbid_cliente.Location = New System.Drawing.Point(175, 21)
        Me.pbid_cliente.Name = "pbid_cliente"
        Me.pbid_cliente.Size = New System.Drawing.Size(12, 12)
        Me.pbid_cliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbid_cliente.TabIndex = 71
        Me.pbid_cliente.TabStop = False
        Me.pbid_cliente.Visible = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 24)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Referencia"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(179, 25)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 70
        Me.PictureBox3.TabStop = False
        '
        'dddd
        '
        Me.dddd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dddd.Location = New System.Drawing.Point(622, 80)
        Me.dddd.Name = "dddd"
        Me.dddd.Size = New System.Drawing.Size(94, 24)
        Me.dddd.TabIndex = 42
        Me.dddd.Text = "Restante"
        Me.dddd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblrestante
        '
        Me.lblrestante.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrestante.Location = New System.Drawing.Point(723, 80)
        Me.lblrestante.Name = "lblrestante"
        Me.lblrestante.Size = New System.Drawing.Size(111, 24)
        Me.lblrestante.TabIndex = 41
        Me.lblrestante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbldebito
        '
        Me.lbldebito.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldebito.Location = New System.Drawing.Point(723, 43)
        Me.lbldebito.Name = "lbldebito"
        Me.lbldebito.Size = New System.Drawing.Size(111, 24)
        Me.lbldebito.TabIndex = 40
        Me.lbldebito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(622, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 24)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Debito"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbldisponible
        '
        Me.lbldisponible.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldisponible.Location = New System.Drawing.Point(723, 10)
        Me.lbldisponible.Name = "lbldisponible"
        Me.lbldisponible.Size = New System.Drawing.Size(111, 24)
        Me.lbldisponible.TabIndex = 37
        Me.lbldisponible.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(622, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 24)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Disponible"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtid_cliente
        '
        Me.txtid_cliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_cliente.Location = New System.Drawing.Point(116, 10)
        Me.txtid_cliente.MaxLength = 4
        Me.txtid_cliente.Name = "txtid_cliente"
        Me.txtid_cliente.Size = New System.Drawing.Size(57, 26)
        Me.txtid_cliente.TabIndex = 1
        Me.txtid_cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblnombre_cliente
        '
        Me.lblnombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnombre_cliente.Location = New System.Drawing.Point(201, 10)
        Me.lblnombre_cliente.Name = "lblnombre_cliente"
        Me.lblnombre_cliente.Size = New System.Drawing.Size(404, 24)
        Me.lblnombre_cliente.TabIndex = 27
        Me.lblnombre_cliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 24)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Cliente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltitulo
        '
        Me.lbltitulo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.Purple
        Me.lbltitulo.Location = New System.Drawing.Point(-2, -1)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(891, 27)
        Me.lbltitulo.TabIndex = 12
        Me.lbltitulo.Text = "Debitar Puntos"
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btncancelar
        '
        Me.btncancelar.Image = CType(resources.GetObject("btncancelar.Image"), System.Drawing.Image)
        Me.btncancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancelar.Location = New System.Drawing.Point(451, 179)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(88, 32)
        Me.btncancelar.TabIndex = 5
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Image = CType(resources.GetObject("btnaceptar.Image"), System.Drawing.Image)
        Me.btnaceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaceptar.Location = New System.Drawing.Point(347, 179)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(88, 32)
        Me.btnaceptar.TabIndex = 4
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'frm_Puntos_Debito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 223)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbltitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_Puntos_Debito"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbpuntos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbid_cliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtreferencia As System.Windows.Forms.TextBox
    Friend WithEvents pbid_cliente As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents dddd As System.Windows.Forms.Label
    Friend WithEvents lblrestante As System.Windows.Forms.Label
    Friend WithEvents lbldebito As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbldisponible As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtid_cliente As System.Windows.Forms.TextBox
    Friend WithEvents lblnombre_cliente As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtpuntos As System.Windows.Forms.TextBox
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    Friend WithEvents pbpuntos As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
