<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_rpt_producto_opciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_rpt_producto_opciones))
        Me.lblprd_linea = New System.Windows.Forms.Label
        Me.lblprd_proveedor = New System.Windows.Forms.Label
        Me.lbllinea_nombre = New System.Windows.Forms.Label
        Me.lblproveedor_nombre = New System.Windows.Forms.Label
        Me.txtid_linea = New System.Windows.Forms.TextBox
        Me.txtid_proveedor = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbltitulo = New System.Windows.Forms.Label
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.chkbloqueados = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblprd_linea
        '
        Me.lblprd_linea.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprd_linea.Location = New System.Drawing.Point(12, 46)
        Me.lblprd_linea.Name = "lblprd_linea"
        Me.lblprd_linea.Size = New System.Drawing.Size(83, 24)
        Me.lblprd_linea.TabIndex = 62
        Me.lblprd_linea.Text = "Línea"
        Me.lblprd_linea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblprd_proveedor
        '
        Me.lblprd_proveedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprd_proveedor.Location = New System.Drawing.Point(12, 14)
        Me.lblprd_proveedor.Name = "lblprd_proveedor"
        Me.lblprd_proveedor.Size = New System.Drawing.Size(83, 24)
        Me.lblprd_proveedor.TabIndex = 61
        Me.lblprd_proveedor.Text = "Proveedor"
        Me.lblprd_proveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbllinea_nombre
        '
        Me.lbllinea_nombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllinea_nombre.Location = New System.Drawing.Point(140, 48)
        Me.lbllinea_nombre.Name = "lbllinea_nombre"
        Me.lbllinea_nombre.Size = New System.Drawing.Size(387, 24)
        Me.lbllinea_nombre.TabIndex = 60
        Me.lbllinea_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblproveedor_nombre
        '
        Me.lblproveedor_nombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproveedor_nombre.Location = New System.Drawing.Point(140, 14)
        Me.lblproveedor_nombre.Name = "lblproveedor_nombre"
        Me.lblproveedor_nombre.Size = New System.Drawing.Size(387, 24)
        Me.lblproveedor_nombre.TabIndex = 59
        Me.lblproveedor_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtid_linea
        '
        Me.txtid_linea.AcceptsReturn = True
        Me.txtid_linea.AcceptsTab = True
        Me.txtid_linea.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_linea.Location = New System.Drawing.Point(96, 46)
        Me.txtid_linea.MaxLength = 8
        Me.txtid_linea.Name = "txtid_linea"
        Me.txtid_linea.Size = New System.Drawing.Size(38, 26)
        Me.txtid_linea.TabIndex = 1
        '
        'txtid_proveedor
        '
        Me.txtid_proveedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_proveedor.Location = New System.Drawing.Point(96, 14)
        Me.txtid_proveedor.MaxLength = 8
        Me.txtid_proveedor.Name = "txtid_proveedor"
        Me.txtid_proveedor.Size = New System.Drawing.Size(38, 26)
        Me.txtid_proveedor.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.chkbloqueados)
        Me.Panel1.Controls.Add(Me.lblprd_proveedor)
        Me.Panel1.Controls.Add(Me.txtid_proveedor)
        Me.Panel1.Controls.Add(Me.txtid_linea)
        Me.Panel1.Controls.Add(Me.lblprd_linea)
        Me.Panel1.Controls.Add(Me.lbllinea_nombre)
        Me.Panel1.Controls.Add(Me.lblproveedor_nombre)
        Me.Panel1.Location = New System.Drawing.Point(22, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(562, 115)
        Me.Panel1.TabIndex = 0
        '
        'lbltitulo
        '
        Me.lbltitulo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbltitulo.Location = New System.Drawing.Point(-1, -2)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(608, 28)
        Me.lbltitulo.TabIndex = 67
        Me.lbltitulo.Text = "Reporte Productos"
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btncancelar
        '
        Me.btncancelar.Image = CType(resources.GetObject("btncancelar.Image"), System.Drawing.Image)
        Me.btncancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancelar.Location = New System.Drawing.Point(311, 164)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(103, 36)
        Me.btncancelar.TabIndex = 3
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Image = CType(resources.GetObject("btnaceptar.Image"), System.Drawing.Image)
        Me.btnaceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaceptar.Location = New System.Drawing.Point(180, 164)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(103, 36)
        Me.btnaceptar.TabIndex = 2
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'chkbloqueados
        '
        Me.chkbloqueados.AutoSize = True
        Me.chkbloqueados.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbloqueados.Location = New System.Drawing.Point(15, 78)
        Me.chkbloqueados.Name = "chkbloqueados"
        Me.chkbloqueados.Size = New System.Drawing.Size(102, 20)
        Me.chkbloqueados.TabIndex = 63
        Me.chkbloqueados.Text = "Bloqueados"
        Me.chkbloqueados.UseVisualStyleBackColor = True
        '
        'frm_rpt_producto_opciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 212)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.lbltitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_rpt_producto_opciones"
        Me.Opacity = 0.9
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblprd_linea As System.Windows.Forms.Label
    Friend WithEvents lblprd_proveedor As System.Windows.Forms.Label
    Friend WithEvents lbllinea_nombre As System.Windows.Forms.Label
    Friend WithEvents lblproveedor_nombre As System.Windows.Forms.Label
    Friend WithEvents txtid_linea As System.Windows.Forms.TextBox
    Friend WithEvents txtid_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents chkbloqueados As System.Windows.Forms.CheckBox
End Class
