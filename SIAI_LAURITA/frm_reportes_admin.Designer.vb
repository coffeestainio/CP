<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reportes_admin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reportes_admin))
        Me.lbltitulo = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.checkProveedor = New System.Windows.Forms.CheckBox
        Me.cbProveedor = New System.Windows.Forms.ComboBox
        Me.lblproveedor = New System.Windows.Forms.Label
        Me.cbproveedores = New System.Windows.Forms.ComboBox
        Me.rbventaNeta = New System.Windows.Forms.RadioButton
        Me.rbnca = New System.Windows.Forms.RadioButton
        Me.rbnc = New System.Windows.Forms.RadioButton
        Me.Rbgrafico = New System.Windows.Forms.RadioButton
        Me.rbventa_resumido = New System.Windows.Forms.RadioButton
        Me.Rbventa_producto = New System.Windows.Forms.RadioButton
        Me.Rbventa_cliente = New System.Windows.Forms.RadioButton
        Me.Rbpedido = New System.Windows.Forms.RadioButton
        Me.rbventa_producto_cliente = New System.Windows.Forms.RadioButton
        Me.cblp_precio = New System.Windows.Forms.ComboBox
        Me.Rbfaltante = New System.Windows.Forms.RadioButton
        Me.rbexistencia = New System.Windows.Forms.RadioButton
        Me.rblinea = New System.Windows.Forms.RadioButton
        Me.rbdevolucion = New System.Windows.Forms.RadioButton
        Me.cbubicacion = New System.Windows.Forms.ComboBox
        Me.rbrecibo = New System.Windows.Forms.RadioButton
        Me.rbfactura = New System.Windows.Forms.RadioButton
        Me.Rblista_precios = New System.Windows.Forms.RadioButton
        Me.rbproducto = New System.Windows.Forms.RadioButton
        Me.rbproveedor = New System.Windows.Forms.RadioButton
        Me.rbagente = New System.Windows.Forms.RadioButton
        Me.rbcliente = New System.Windows.Forms.RadioButton
        Me.dtpdesde = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtphasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.cbforma_pago = New System.Windows.Forms.ComboBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbltitulo
        '
        Me.lbltitulo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbltitulo.Location = New System.Drawing.Point(8, 8)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(762, 27)
        Me.lbltitulo.TabIndex = 11
        Me.lbltitulo.Text = "Reportes Administrador"
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cbforma_pago)
        Me.Panel1.Controls.Add(Me.checkProveedor)
        Me.Panel1.Controls.Add(Me.cbProveedor)
        Me.Panel1.Controls.Add(Me.lblproveedor)
        Me.Panel1.Controls.Add(Me.cbproveedores)
        Me.Panel1.Controls.Add(Me.rbventaNeta)
        Me.Panel1.Controls.Add(Me.rbnca)
        Me.Panel1.Controls.Add(Me.rbnc)
        Me.Panel1.Controls.Add(Me.Rbgrafico)
        Me.Panel1.Controls.Add(Me.rbventa_resumido)
        Me.Panel1.Controls.Add(Me.Rbventa_producto)
        Me.Panel1.Controls.Add(Me.Rbventa_cliente)
        Me.Panel1.Controls.Add(Me.Rbpedido)
        Me.Panel1.Controls.Add(Me.rbventa_producto_cliente)
        Me.Panel1.Controls.Add(Me.cblp_precio)
        Me.Panel1.Controls.Add(Me.Rbfaltante)
        Me.Panel1.Controls.Add(Me.rbexistencia)
        Me.Panel1.Controls.Add(Me.rblinea)
        Me.Panel1.Controls.Add(Me.rbdevolucion)
        Me.Panel1.Controls.Add(Me.cbubicacion)
        Me.Panel1.Controls.Add(Me.rbrecibo)
        Me.Panel1.Controls.Add(Me.rbfactura)
        Me.Panel1.Controls.Add(Me.Rblista_precios)
        Me.Panel1.Controls.Add(Me.rbproducto)
        Me.Panel1.Controls.Add(Me.rbproveedor)
        Me.Panel1.Controls.Add(Me.rbagente)
        Me.Panel1.Controls.Add(Me.rbcliente)
        Me.Panel1.Location = New System.Drawing.Point(21, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(724, 429)
        Me.Panel1.TabIndex = 12
        '
        'checkProveedor
        '
        Me.checkProveedor.AutoSize = True
        Me.checkProveedor.Location = New System.Drawing.Point(219, 231)
        Me.checkProveedor.Name = "checkProveedor"
        Me.checkProveedor.Size = New System.Drawing.Size(86, 17)
        Me.checkProveedor.TabIndex = 92
        Me.checkProveedor.Text = "Proveedores"
        Me.checkProveedor.UseVisualStyleBackColor = True
        '
        'cbProveedor
        '
        Me.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProveedor.Enabled = False
        Me.cbProveedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProveedor.Items.AddRange(New Object() {"Todos"})
        Me.cbProveedor.Location = New System.Drawing.Point(311, 225)
        Me.cbProveedor.Name = "cbProveedor"
        Me.cbProveedor.Size = New System.Drawing.Size(164, 26)
        Me.cbProveedor.TabIndex = 91
        Me.ToolTip1.SetToolTip(Me.cbProveedor, "Seleccione la Lista de Precios")
        Me.cbProveedor.Visible = False
        '
        'lblproveedor
        '
        Me.lblproveedor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproveedor.Location = New System.Drawing.Point(216, 251)
        Me.lblproveedor.Name = "lblproveedor"
        Me.lblproveedor.Size = New System.Drawing.Size(259, 24)
        Me.lblproveedor.TabIndex = 46
        Me.lblproveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbproveedores
        '
        Me.cbproveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbproveedores.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbproveedores.Items.AddRange(New Object() {"Todos", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "00"})
        Me.cbproveedores.Location = New System.Drawing.Point(118, 252)
        Me.cbproveedores.Name = "cbproveedores"
        Me.cbproveedores.Size = New System.Drawing.Size(82, 26)
        Me.cbproveedores.TabIndex = 90
        Me.ToolTip1.SetToolTip(Me.cbproveedores, "Seleccione la Lista de Precios")
        Me.cbproveedores.Visible = False
        '
        'rbventaNeta
        '
        Me.rbventaNeta.AutoSize = True
        Me.rbventaNeta.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbventaNeta.Location = New System.Drawing.Point(491, 119)
        Me.rbventaNeta.Name = "rbventaNeta"
        Me.rbventaNeta.Size = New System.Drawing.Size(161, 21)
        Me.rbventaNeta.TabIndex = 89
        Me.rbventaNeta.Text = "Ventas Netas Cliente"
        Me.rbventaNeta.UseVisualStyleBackColor = True
        '
        'rbnca
        '
        Me.rbnca.AutoSize = True
        Me.rbnca.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbnca.Location = New System.Drawing.Point(491, 39)
        Me.rbnca.Name = "rbnca"
        Me.rbnca.Size = New System.Drawing.Size(220, 21)
        Me.rbnca.TabIndex = 88
        Me.rbnca.Text = "Notas de Crédito Aplicaciones"
        Me.rbnca.UseVisualStyleBackColor = True
        '
        'rbnc
        '
        Me.rbnc.AutoSize = True
        Me.rbnc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbnc.Location = New System.Drawing.Point(491, 12)
        Me.rbnc.Name = "rbnc"
        Me.rbnc.Size = New System.Drawing.Size(135, 21)
        Me.rbnc.TabIndex = 87
        Me.rbnc.Text = "Notas de Crédito"
        Me.rbnc.UseVisualStyleBackColor = True
        '
        'Rbgrafico
        '
        Me.Rbgrafico.AutoSize = True
        Me.Rbgrafico.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbgrafico.Location = New System.Drawing.Point(491, 199)
        Me.Rbgrafico.Name = "Rbgrafico"
        Me.Rbgrafico.Size = New System.Drawing.Size(121, 21)
        Me.Rbgrafico.TabIndex = 64
        Me.Rbgrafico.Text = "Ventas Gráfico"
        Me.Rbgrafico.UseVisualStyleBackColor = True
        '
        'rbventa_resumido
        '
        Me.rbventa_resumido.AutoSize = True
        Me.rbventa_resumido.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbventa_resumido.Location = New System.Drawing.Point(491, 173)
        Me.rbventa_resumido.Name = "rbventa_resumido"
        Me.rbventa_resumido.Size = New System.Drawing.Size(141, 21)
        Me.rbventa_resumido.TabIndex = 63
        Me.rbventa_resumido.Text = "Ventas Resumido"
        Me.rbventa_resumido.UseVisualStyleBackColor = True
        '
        'Rbventa_producto
        '
        Me.Rbventa_producto.AutoSize = True
        Me.Rbventa_producto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbventa_producto.Location = New System.Drawing.Point(491, 146)
        Me.Rbventa_producto.Name = "Rbventa_producto"
        Me.Rbventa_producto.Size = New System.Drawing.Size(133, 21)
        Me.Rbventa_producto.TabIndex = 62
        Me.Rbventa_producto.Text = "Ventas Producto"
        Me.Rbventa_producto.UseVisualStyleBackColor = True
        '
        'Rbventa_cliente
        '
        Me.Rbventa_cliente.AutoSize = True
        Me.Rbventa_cliente.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbventa_cliente.Location = New System.Drawing.Point(491, 93)
        Me.Rbventa_cliente.Name = "Rbventa_cliente"
        Me.Rbventa_cliente.Size = New System.Drawing.Size(119, 21)
        Me.Rbventa_cliente.TabIndex = 61
        Me.Rbventa_cliente.Text = "Ventas Cliente"
        Me.Rbventa_cliente.UseVisualStyleBackColor = True
        '
        'Rbpedido
        '
        Me.Rbpedido.AutoSize = True
        Me.Rbpedido.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbpedido.Location = New System.Drawing.Point(11, 308)
        Me.Rbpedido.Name = "Rbpedido"
        Me.Rbpedido.Size = New System.Drawing.Size(79, 21)
        Me.Rbpedido.TabIndex = 60
        Me.Rbpedido.Text = "Pedidos"
        Me.Rbpedido.UseVisualStyleBackColor = True
        '
        'rbventa_producto_cliente
        '
        Me.rbventa_producto_cliente.AutoSize = True
        Me.rbventa_producto_cliente.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbventa_producto_cliente.Location = New System.Drawing.Point(491, 66)
        Me.rbventa_producto_cliente.Name = "rbventa_producto_cliente"
        Me.rbventa_producto_cliente.Size = New System.Drawing.Size(182, 21)
        Me.rbventa_producto_cliente.TabIndex = 59
        Me.rbventa_producto_cliente.Text = "Ventas Producto Cliente"
        Me.rbventa_producto_cliente.UseVisualStyleBackColor = True
        '
        'cblp_precio
        '
        Me.cblp_precio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cblp_precio.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cblp_precio.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cblp_precio.Location = New System.Drawing.Point(148, 279)
        Me.cblp_precio.Name = "cblp_precio"
        Me.cblp_precio.Size = New System.Drawing.Size(52, 26)
        Me.cblp_precio.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.cblp_precio, "Seleccione la Lista de Precios")
        Me.cblp_precio.Visible = False
        '
        'Rbfaltante
        '
        Me.Rbfaltante.AutoSize = True
        Me.Rbfaltante.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbfaltante.Location = New System.Drawing.Point(11, 254)
        Me.Rbfaltante.Name = "Rbfaltante"
        Me.Rbfaltante.Size = New System.Drawing.Size(86, 21)
        Me.Rbfaltante.TabIndex = 57
        Me.Rbfaltante.Text = "Faltantes"
        Me.Rbfaltante.UseVisualStyleBackColor = True
        '
        'rbexistencia
        '
        Me.rbexistencia.AutoSize = True
        Me.rbexistencia.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbexistencia.Location = New System.Drawing.Point(11, 227)
        Me.rbexistencia.Name = "rbexistencia"
        Me.rbexistencia.Size = New System.Drawing.Size(101, 21)
        Me.rbexistencia.TabIndex = 50
        Me.rbexistencia.Text = "Existencias"
        Me.rbexistencia.UseVisualStyleBackColor = True
        '
        'rblinea
        '
        Me.rblinea.AutoSize = True
        Me.rblinea.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rblinea.Location = New System.Drawing.Point(11, 93)
        Me.rblinea.Name = "rblinea"
        Me.rblinea.Size = New System.Drawing.Size(69, 21)
        Me.rblinea.TabIndex = 49
        Me.rblinea.Text = "Líneas"
        Me.rblinea.UseVisualStyleBackColor = True
        '
        'rbdevolucion
        '
        Me.rbdevolucion.AutoSize = True
        Me.rbdevolucion.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbdevolucion.Location = New System.Drawing.Point(11, 173)
        Me.rbdevolucion.Name = "rbdevolucion"
        Me.rbdevolucion.Size = New System.Drawing.Size(114, 21)
        Me.rbdevolucion.TabIndex = 47
        Me.rbdevolucion.Text = "Devoluciones"
        Me.rbdevolucion.UseVisualStyleBackColor = True
        '
        'cbubicacion
        '
        Me.cbubicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbubicacion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbubicacion.Items.AddRange(New Object() {"Todos", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "00"})
        Me.cbubicacion.Location = New System.Drawing.Point(118, 224)
        Me.cbubicacion.Name = "cbubicacion"
        Me.cbubicacion.Size = New System.Drawing.Size(82, 26)
        Me.cbubicacion.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.cbubicacion, "Seleccione la Lista de Precios")
        Me.cbubicacion.Visible = False
        '
        'rbrecibo
        '
        Me.rbrecibo.AutoSize = True
        Me.rbrecibo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbrecibo.Location = New System.Drawing.Point(11, 146)
        Me.rbrecibo.Name = "rbrecibo"
        Me.rbrecibo.Size = New System.Drawing.Size(80, 21)
        Me.rbrecibo.TabIndex = 7
        Me.rbrecibo.Text = "Recibos"
        Me.rbrecibo.UseVisualStyleBackColor = True
        '
        'rbfactura
        '
        Me.rbfactura.AutoSize = True
        Me.rbfactura.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbfactura.Location = New System.Drawing.Point(11, 119)
        Me.rbfactura.Name = "rbfactura"
        Me.rbfactura.Size = New System.Drawing.Size(84, 21)
        Me.rbfactura.TabIndex = 5
        Me.rbfactura.Text = "Facturas"
        Me.rbfactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbfactura.UseVisualStyleBackColor = True
        '
        'Rblista_precios
        '
        Me.Rblista_precios.AutoSize = True
        Me.Rblista_precios.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rblista_precios.Location = New System.Drawing.Point(11, 281)
        Me.Rblista_precios.Name = "Rblista_precios"
        Me.Rblista_precios.Size = New System.Drawing.Size(131, 21)
        Me.Rblista_precios.TabIndex = 4
        Me.Rblista_precios.Text = "Lista de Precios"
        Me.Rblista_precios.UseVisualStyleBackColor = True
        '
        'rbproducto
        '
        Me.rbproducto.AutoSize = True
        Me.rbproducto.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbproducto.Location = New System.Drawing.Point(11, 200)
        Me.rbproducto.Name = "rbproducto"
        Me.rbproducto.Size = New System.Drawing.Size(93, 21)
        Me.rbproducto.TabIndex = 3
        Me.rbproducto.Text = "Productos"
        Me.rbproducto.UseVisualStyleBackColor = True
        '
        'rbproveedor
        '
        Me.rbproveedor.AutoSize = True
        Me.rbproveedor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbproveedor.Location = New System.Drawing.Point(11, 66)
        Me.rbproveedor.Name = "rbproveedor"
        Me.rbproveedor.Size = New System.Drawing.Size(109, 21)
        Me.rbproveedor.TabIndex = 2
        Me.rbproveedor.Text = "Proveedores"
        Me.rbproveedor.UseVisualStyleBackColor = True
        '
        'rbagente
        '
        Me.rbagente.AutoSize = True
        Me.rbagente.Checked = True
        Me.rbagente.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbagente.Location = New System.Drawing.Point(11, 12)
        Me.rbagente.Name = "rbagente"
        Me.rbagente.Size = New System.Drawing.Size(79, 21)
        Me.rbagente.TabIndex = 1
        Me.rbagente.TabStop = True
        Me.rbagente.Text = "Agentes"
        Me.rbagente.UseVisualStyleBackColor = True
        '
        'rbcliente
        '
        Me.rbcliente.AutoSize = True
        Me.rbcliente.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbcliente.Location = New System.Drawing.Point(11, 39)
        Me.rbcliente.Name = "rbcliente"
        Me.rbcliente.Size = New System.Drawing.Size(79, 21)
        Me.rbcliente.TabIndex = 0
        Me.rbcliente.Text = "Clientes"
        Me.rbcliente.UseVisualStyleBackColor = True
        '
        'dtpdesde
        '
        Me.dtpdesde.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdesde.Location = New System.Drawing.Point(242, 489)
        Me.dtpdesde.Name = "dtpdesde"
        Me.dtpdesde.Size = New System.Drawing.Size(111, 26)
        Me.dtpdesde.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(178, 491)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 24)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Desde"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtphasta
        '
        Me.dtphasta.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtphasta.Location = New System.Drawing.Point(432, 489)
        Me.dtphasta.Name = "dtphasta"
        Me.dtphasta.Size = New System.Drawing.Size(111, 26)
        Me.dtphasta.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(368, 491)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 24)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Hasta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btncancelar
        '
        Me.btncancelar.Image = CType(resources.GetObject("btncancelar.Image"), System.Drawing.Image)
        Me.btncancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancelar.Location = New System.Drawing.Point(395, 535)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(103, 32)
        Me.btncancelar.TabIndex = 14
        Me.btncancelar.Text = "Cancelar"
        Me.ToolTip1.SetToolTip(Me.btncancelar, "No Emitir Reporte")
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Image = CType(resources.GetObject("btnaceptar.Image"), System.Drawing.Image)
        Me.btnaceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaceptar.Location = New System.Drawing.Point(266, 535)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(103, 32)
        Me.btnaceptar.TabIndex = 13
        Me.btnaceptar.Text = "Aceptar"
        Me.ToolTip1.SetToolTip(Me.btnaceptar, "Emitir Reporte")
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'cbforma_pago
        '
        Me.cbforma_pago.FormattingEnabled = True
        Me.cbforma_pago.Items.AddRange(New Object() {"Todos", "Efectivo", "Cheque", "Transferencia", "Tarjeta"})
        Me.cbforma_pago.Location = New System.Drawing.Point(131, 148)
        Me.cbforma_pago.Name = "cbforma_pago"
        Me.cbforma_pago.Size = New System.Drawing.Size(215, 21)
        Me.cbforma_pago.TabIndex = 93
        '
        'frm_reportes_admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 579)
        Me.Controls.Add(Me.dtphasta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpdesde)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbltitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_reportes_admin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    Friend WithEvents dtpdesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtphasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbcliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbagente As System.Windows.Forms.RadioButton
    Friend WithEvents rbfactura As System.Windows.Forms.RadioButton
    Friend WithEvents Rblista_precios As System.Windows.Forms.RadioButton
    Friend WithEvents rbproducto As System.Windows.Forms.RadioButton
    Friend WithEvents rbproveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbrecibo As System.Windows.Forms.RadioButton
    Friend WithEvents cbubicacion As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents rbdevolucion As System.Windows.Forms.RadioButton
    Friend WithEvents rblinea As System.Windows.Forms.RadioButton
    Friend WithEvents rbexistencia As System.Windows.Forms.RadioButton
    Friend WithEvents Rbfaltante As System.Windows.Forms.RadioButton
    Friend WithEvents cblp_precio As System.Windows.Forms.ComboBox
    Friend WithEvents rbventa_producto_cliente As System.Windows.Forms.RadioButton
    Friend WithEvents Rbpedido As System.Windows.Forms.RadioButton
    Friend WithEvents Rbventa_cliente As System.Windows.Forms.RadioButton
    Friend WithEvents Rbventa_producto As System.Windows.Forms.RadioButton
    Friend WithEvents rbventa_resumido As System.Windows.Forms.RadioButton
    Friend WithEvents Rbgrafico As System.Windows.Forms.RadioButton
    Friend WithEvents rbnca As System.Windows.Forms.RadioButton
    Friend WithEvents rbnc As System.Windows.Forms.RadioButton
    Friend WithEvents rbventaNeta As System.Windows.Forms.RadioButton
    Friend WithEvents cbproveedores As System.Windows.Forms.ComboBox
    Friend WithEvents lblproveedor As System.Windows.Forms.Label
    Friend WithEvents checkProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cbforma_pago As System.Windows.Forms.ComboBox
End Class
