<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_rpt_venta_producto_cliente_opciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_rpt_venta_producto_cliente_opciones))
        Me.lblprd_linea = New System.Windows.Forms.Label
        Me.lblprd_proveedor = New System.Windows.Forms.Label
        Me.Lblproveedor_nombre = New System.Windows.Forms.Label
        Me.lblcliente_nombre = New System.Windows.Forms.Label
        Me.txtid_linea = New System.Windows.Forms.TextBox
        Me.txtid_proveedor = New System.Windows.Forms.TextBox
        Me.lbltitulo = New System.Windows.Forms.Label
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbid_usuario = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnbuscar = New System.Windows.Forms.Button
        Me.lblproducto_nombre = New System.Windows.Forms.Label
        Me.lbllinea_nombre = New System.Windows.Forms.Label
        Me.txtid_cliente = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtid_producto = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtphasta = New System.Windows.Forms.DateTimePicker
        Me.Dtpdesde = New System.Windows.Forms.DateTimePicker
        Me.cbnegocio = New System.Windows.Forms.ComboBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblprd_linea
        '
        Me.lblprd_linea.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprd_linea.Location = New System.Drawing.Point(18, 130)
        Me.lblprd_linea.Name = "lblprd_linea"
        Me.lblprd_linea.Size = New System.Drawing.Size(83, 24)
        Me.lblprd_linea.TabIndex = 62
        Me.lblprd_linea.Text = "Línea"
        Me.lblprd_linea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblprd_proveedor
        '
        Me.lblprd_proveedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprd_proveedor.Location = New System.Drawing.Point(18, 93)
        Me.lblprd_proveedor.Name = "lblprd_proveedor"
        Me.lblprd_proveedor.Size = New System.Drawing.Size(83, 24)
        Me.lblprd_proveedor.TabIndex = 61
        Me.lblprd_proveedor.Text = "Proveedor"
        Me.lblprd_proveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lblproveedor_nombre
        '
        Me.Lblproveedor_nombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblproveedor_nombre.Location = New System.Drawing.Point(146, 89)
        Me.Lblproveedor_nombre.Name = "Lblproveedor_nombre"
        Me.Lblproveedor_nombre.Size = New System.Drawing.Size(387, 24)
        Me.Lblproveedor_nombre.TabIndex = 60
        Me.Lblproveedor_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblcliente_nombre
        '
        Me.lblcliente_nombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcliente_nombre.Location = New System.Drawing.Point(179, 12)
        Me.lblcliente_nombre.Name = "lblcliente_nombre"
        Me.lblcliente_nombre.Size = New System.Drawing.Size(443, 24)
        Me.lblcliente_nombre.TabIndex = 59
        Me.lblcliente_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtid_linea
        '
        Me.txtid_linea.AcceptsReturn = True
        Me.txtid_linea.AcceptsTab = True
        Me.txtid_linea.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_linea.Location = New System.Drawing.Point(128, 130)
        Me.txtid_linea.MaxLength = 8
        Me.txtid_linea.Name = "txtid_linea"
        Me.txtid_linea.Size = New System.Drawing.Size(38, 26)
        Me.txtid_linea.TabIndex = 2
        '
        'txtid_proveedor
        '
        Me.txtid_proveedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_proveedor.Location = New System.Drawing.Point(128, 89)
        Me.txtid_proveedor.MaxLength = 8
        Me.txtid_proveedor.Name = "txtid_proveedor"
        Me.txtid_proveedor.Size = New System.Drawing.Size(38, 26)
        Me.txtid_proveedor.TabIndex = 1
        '
        'lbltitulo
        '
        Me.lbltitulo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbltitulo.Location = New System.Drawing.Point(-1, 0)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(720, 28)
        Me.lbltitulo.TabIndex = 63
        Me.lbltitulo.Text = "Reporte de Ventas por Producto"
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btncancelar
        '
        Me.btncancelar.Image = CType(resources.GetObject("btncancelar.Image"), System.Drawing.Image)
        Me.btncancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancelar.Location = New System.Drawing.Point(379, 376)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(103, 36)
        Me.btncancelar.TabIndex = 8
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Image = CType(resources.GetObject("btnaceptar.Image"), System.Drawing.Image)
        Me.btnaceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaceptar.Location = New System.Drawing.Point(248, 376)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(103, 36)
        Me.btnaceptar.TabIndex = 7
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cbnegocio)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cbid_usuario)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btnbuscar)
        Me.Panel1.Controls.Add(Me.lblproducto_nombre)
        Me.Panel1.Controls.Add(Me.lbllinea_nombre)
        Me.Panel1.Controls.Add(Me.txtid_cliente)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtid_producto)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtphasta)
        Me.Panel1.Controls.Add(Me.Dtpdesde)
        Me.Panel1.Controls.Add(Me.lblcliente_nombre)
        Me.Panel1.Controls.Add(Me.txtid_proveedor)
        Me.Panel1.Controls.Add(Me.txtid_linea)
        Me.Panel1.Controls.Add(Me.Lblproveedor_nombre)
        Me.Panel1.Controls.Add(Me.lblprd_linea)
        Me.Panel1.Controls.Add(Me.lblprd_proveedor)
        Me.Panel1.Location = New System.Drawing.Point(22, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(675, 339)
        Me.Panel1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 24)
        Me.Label6.TabIndex = 130
        Me.Label6.Text = "Tipo Negocio"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbid_usuario
        '
        Me.cbid_usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbid_usuario.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbid_usuario.Location = New System.Drawing.Point(128, 218)
        Me.cbid_usuario.Name = "cbid_usuario"
        Me.cbid_usuario.Size = New System.Drawing.Size(270, 26)
        Me.cbid_usuario.TabIndex = 125
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 24)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Usuario"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnbuscar
        '
        Me.btnbuscar.Image = CType(resources.GetObject("btnbuscar.Image"), System.Drawing.Image)
        Me.btnbuscar.Location = New System.Drawing.Point(205, 171)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(29, 31)
        Me.btnbuscar.TabIndex = 124
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'lblproducto_nombre
        '
        Me.lblproducto_nombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproducto_nombre.Location = New System.Drawing.Point(221, 171)
        Me.lblproducto_nombre.Name = "lblproducto_nombre"
        Me.lblproducto_nombre.Size = New System.Drawing.Size(389, 24)
        Me.lblproducto_nombre.TabIndex = 72
        Me.lblproducto_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbllinea_nombre
        '
        Me.lbllinea_nombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllinea_nombre.Location = New System.Drawing.Point(172, 132)
        Me.lbllinea_nombre.Name = "lbllinea_nombre"
        Me.lbllinea_nombre.Size = New System.Drawing.Size(387, 24)
        Me.lbllinea_nombre.TabIndex = 71
        Me.lbllinea_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtid_cliente
        '
        Me.txtid_cliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_cliente.Location = New System.Drawing.Point(128, 12)
        Me.txtid_cliente.MaxLength = 4
        Me.txtid_cliente.Name = "txtid_cliente"
        Me.txtid_cliente.Size = New System.Drawing.Size(58, 26)
        Me.txtid_cliente.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 24)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Cliente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtid_producto
        '
        Me.txtid_producto.AcceptsReturn = True
        Me.txtid_producto.AcceptsTab = True
        Me.txtid_producto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_producto.Location = New System.Drawing.Point(128, 171)
        Me.txtid_producto.MaxLength = 8
        Me.txtid_producto.Name = "txtid_producto"
        Me.txtid_producto.Size = New System.Drawing.Size(71, 26)
        Me.txtid_producto.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 24)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Producto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(242, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 24)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Hasta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 24)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Desde"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtphasta
        '
        Me.dtphasta.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtphasta.Location = New System.Drawing.Point(320, 262)
        Me.dtphasta.Name = "dtphasta"
        Me.dtphasta.Size = New System.Drawing.Size(99, 25)
        Me.dtphasta.TabIndex = 6
        '
        'Dtpdesde
        '
        Me.Dtpdesde.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtpdesde.Location = New System.Drawing.Point(128, 261)
        Me.Dtpdesde.Name = "Dtpdesde"
        Me.Dtpdesde.Size = New System.Drawing.Size(99, 25)
        Me.Dtpdesde.TabIndex = 5
        '
        'cbnegocio
        '
        Me.cbnegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbnegocio.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbnegocio.Items.AddRange(New Object() {"TODOS", "Abastecedor", "Mini Super", "Supermercado"})
        Me.cbnegocio.Location = New System.Drawing.Point(128, 52)
        Me.cbnegocio.Name = "cbnegocio"
        Me.cbnegocio.Size = New System.Drawing.Size(158, 26)
        Me.cbnegocio.TabIndex = 131
        '
        'frm_rpt_venta_producto_cliente_opciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 424)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.lbltitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_rpt_venta_producto_cliente_opciones"
        Me.Opacity = 0.9
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblprd_linea As System.Windows.Forms.Label
    Friend WithEvents lblprd_proveedor As System.Windows.Forms.Label
    Friend WithEvents Lblproveedor_nombre As System.Windows.Forms.Label
    Friend WithEvents lblcliente_nombre As System.Windows.Forms.Label
    Friend WithEvents txtid_linea As System.Windows.Forms.TextBox
    Friend WithEvents txtid_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtid_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtphasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtpdesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblproducto_nombre As System.Windows.Forms.Label
    Friend WithEvents lbllinea_nombre As System.Windows.Forms.Label
    Friend WithEvents txtid_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnbuscar As System.Windows.Forms.Button
    Friend WithEvents cbid_usuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbnegocio As System.Windows.Forms.ComboBox
End Class
