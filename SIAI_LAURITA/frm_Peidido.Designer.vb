<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_pedido
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_pedido))
        Me.lbltitulo = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnimprimir = New System.Windows.Forms.Button
        Me.btnfacturar = New System.Windows.Forms.Button
        Me.btnproformar = New System.Windows.Forms.Button
        Me.btnincluir = New System.Windows.Forms.Button
        Me.btnAlistar = New System.Windows.Forms.Button
        Me.btnguardar = New System.Windows.Forms.Button
        Me.btneliminar = New System.Windows.Forms.Button
        Me.btnmodificar = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.dtgpedido = New System.Windows.Forms.DataGridView
        Me.lblproductos = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lbltotal = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.btntotales = New System.Windows.Forms.Button
        Me.pnencabezado = New System.Windows.Forms.Panel
        Me.txtplazo = New System.Windows.Forms.TextBox
        Me.txtid_cliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbid_pedido = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbid_agente = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblcliente_nombre = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbldisponible = New System.Windows.Forms.Label
        Me.pbmoroso = New System.Windows.Forms.PictureBox
        Me.pbaldia = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblvencido = New System.Windows.Forms.Label
        Me.lbldias_atraso = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.id_producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unidad_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tpddescuento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TPDMonto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tpdiv = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.unidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.consumidor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.empaque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnajustar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.dtgpedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnencabezado.SuspendLayout()
        CType(Me.pbmoroso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbaldia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltitulo
        '
        Me.lbltitulo.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbltitulo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.White
        Me.lbltitulo.Location = New System.Drawing.Point(12, -2)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(908, 28)
        Me.lbltitulo.TabIndex = 12
        Me.lbltitulo.Text = "Pedidos"
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnajustar)
        Me.Panel1.Controls.Add(Me.btnimprimir)
        Me.Panel1.Controls.Add(Me.btnfacturar)
        Me.Panel1.Controls.Add(Me.btnproformar)
        Me.Panel1.Controls.Add(Me.btnincluir)
        Me.Panel1.Controls.Add(Me.btnAlistar)
        Me.Panel1.Controls.Add(Me.btnguardar)
        Me.Panel1.Controls.Add(Me.btneliminar)
        Me.Panel1.Controls.Add(Me.btnmodificar)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.dtgpedido)
        Me.Panel1.Location = New System.Drawing.Point(20, 106)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(903, 531)
        Me.Panel1.TabIndex = 33
        '
        'btnimprimir
        '
        Me.btnimprimir.Enabled = False
        Me.btnimprimir.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnimprimir.Image = CType(resources.GetObject("btnimprimir.Image"), System.Drawing.Image)
        Me.btnimprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnimprimir.Location = New System.Drawing.Point(845, 452)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(54, 48)
        Me.btnimprimir.TabIndex = 80
        Me.btnimprimir.Text = "Imprimir"
        Me.btnimprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnimprimir.UseVisualStyleBackColor = True
        Me.btnimprimir.Visible = False
        '
        'btnfacturar
        '
        Me.btnfacturar.Enabled = False
        Me.btnfacturar.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfacturar.Image = CType(resources.GetObject("btnfacturar.Image"), System.Drawing.Image)
        Me.btnfacturar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnfacturar.Location = New System.Drawing.Point(845, 398)
        Me.btnfacturar.Name = "btnfacturar"
        Me.btnfacturar.Size = New System.Drawing.Size(54, 48)
        Me.btnfacturar.TabIndex = 79
        Me.btnfacturar.Text = "Factura"
        Me.btnfacturar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnfacturar.UseVisualStyleBackColor = True
        '
        'btnproformar
        '
        Me.btnproformar.Enabled = False
        Me.btnproformar.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnproformar.Image = CType(resources.GetObject("btnproformar.Image"), System.Drawing.Image)
        Me.btnproformar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnproformar.Location = New System.Drawing.Point(845, 344)
        Me.btnproformar.Name = "btnproformar"
        Me.btnproformar.Size = New System.Drawing.Size(54, 48)
        Me.btnproformar.TabIndex = 78
        Me.btnproformar.Text = "Proforma"
        Me.btnproformar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnproformar.UseVisualStyleBackColor = True
        '
        'btnincluir
        '
        Me.btnincluir.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnincluir.Image = CType(resources.GetObject("btnincluir.Image"), System.Drawing.Image)
        Me.btnincluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnincluir.Location = New System.Drawing.Point(843, 3)
        Me.btnincluir.Name = "btnincluir"
        Me.btnincluir.Size = New System.Drawing.Size(56, 48)
        Me.btnincluir.TabIndex = 77
        Me.btnincluir.Text = "Incluir"
        Me.btnincluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnincluir.UseVisualStyleBackColor = True
        '
        'btnAlistar
        '
        Me.btnAlistar.Enabled = False
        Me.btnAlistar.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlistar.Image = CType(resources.GetObject("btnAlistar.Image"), System.Drawing.Image)
        Me.btnAlistar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAlistar.Location = New System.Drawing.Point(845, 228)
        Me.btnAlistar.Name = "btnAlistar"
        Me.btnAlistar.Size = New System.Drawing.Size(54, 48)
        Me.btnAlistar.TabIndex = 76
        Me.btnAlistar.Text = "Alistar"
        Me.btnAlistar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAlistar.UseVisualStyleBackColor = True
        '
        'btnguardar
        '
        Me.btnguardar.Enabled = False
        Me.btnguardar.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardar.Location = New System.Drawing.Point(845, 174)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(54, 48)
        Me.btnguardar.TabIndex = 75
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Enabled = False
        Me.btneliminar.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneliminar.Image = CType(resources.GetObject("btneliminar.Image"), System.Drawing.Image)
        Me.btneliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btneliminar.Location = New System.Drawing.Point(845, 111)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(54, 48)
        Me.btneliminar.TabIndex = 74
        Me.btneliminar.Text = "Eliminar"
        Me.btneliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Enabled = False
        Me.btnmodificar.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmodificar.Image = CType(resources.GetObject("btnmodificar.Image"), System.Drawing.Image)
        Me.btnmodificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnmodificar.Location = New System.Drawing.Point(845, 57)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(54, 48)
        Me.btnmodificar.TabIndex = 73
        Me.btnmodificar.Text = "Modificar"
        Me.btnmodificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.CanOverflow = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStrip1.Enabled = False
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(838, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStrip1.Size = New System.Drawing.Size(61, 527)
        Me.ToolStrip1.TabIndex = 34
        '
        'dtgpedido
        '
        Me.dtgpedido.AllowUserToAddRows = False
        Me.dtgpedido.AllowUserToDeleteRows = False
        Me.dtgpedido.AllowUserToResizeColumns = False
        Me.dtgpedido.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgpedido.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgpedido.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgpedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgpedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_producto, Me.cantidad, Me.Unidad_nombre, Me.nombre, Me.Precio, Me.tpddescuento, Me.TPDMonto, Me.tpdiv, Me.unidad, Me.consumidor, Me.ubicacion, Me.empaque})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgpedido.DefaultCellStyle = DataGridViewCellStyle10
        Me.dtgpedido.Location = New System.Drawing.Point(3, 3)
        Me.dtgpedido.Name = "dtgpedido"
        Me.dtgpedido.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgpedido.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dtgpedido.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgpedido.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dtgpedido.Size = New System.Drawing.Size(822, 523)
        Me.dtgpedido.TabIndex = 35
        '
        'lblproductos
        '
        Me.lblproductos.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproductos.Location = New System.Drawing.Point(611, 651)
        Me.lblproductos.Name = "lblproductos"
        Me.lblproductos.Size = New System.Drawing.Size(29, 24)
        Me.lblproductos.TabIndex = 60
        Me.lblproductos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(513, 650)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 24)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Productos"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.lbltotal)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Location = New System.Drawing.Point(650, 641)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(204, 42)
        Me.Panel3.TabIndex = 61
        '
        'lbltotal
        '
        Me.lbltotal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(72, 6)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(123, 24)
        Me.lbltotal.TabIndex = 58
        Me.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 24)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btntotales
        '
        Me.btntotales.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntotales.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btntotales.Location = New System.Drawing.Point(869, 653)
        Me.btntotales.Name = "btntotales"
        Me.btntotales.Size = New System.Drawing.Size(21, 22)
        Me.btntotales.TabIndex = 59
        Me.btntotales.Text = "+"
        Me.ToolTip1.SetToolTip(Me.btntotales, "Ver Sub Totales")
        Me.btntotales.UseVisualStyleBackColor = True
        '
        'pnencabezado
        '
        Me.pnencabezado.Controls.Add(Me.txtplazo)
        Me.pnencabezado.Controls.Add(Me.txtid_cliente)
        Me.pnencabezado.Controls.Add(Me.Label2)
        Me.pnencabezado.Controls.Add(Me.cbid_pedido)
        Me.pnencabezado.Controls.Add(Me.Label1)
        Me.pnencabezado.Controls.Add(Me.cbid_agente)
        Me.pnencabezado.Controls.Add(Me.Label3)
        Me.pnencabezado.Controls.Add(Me.lblcliente_nombre)
        Me.pnencabezado.Controls.Add(Me.Label6)
        Me.pnencabezado.Location = New System.Drawing.Point(20, 29)
        Me.pnencabezado.Name = "pnencabezado"
        Me.pnencabezado.Size = New System.Drawing.Size(868, 63)
        Me.pnencabezado.TabIndex = 0
        '
        'txtplazo
        '
        Me.txtplazo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtplazo.Location = New System.Drawing.Point(558, 2)
        Me.txtplazo.MaxLength = 3
        Me.txtplazo.Name = "txtplazo"
        Me.txtplazo.Size = New System.Drawing.Size(41, 26)
        Me.txtplazo.TabIndex = 53
        Me.txtplazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtplazo, "Escriba el Código del Cliente")
        '
        'txtid_cliente
        '
        Me.txtid_cliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_cliente.Location = New System.Drawing.Point(68, 0)
        Me.txtid_cliente.MaxLength = 3
        Me.txtid_cliente.Name = "txtid_cliente"
        Me.txtid_cliente.Size = New System.Drawing.Size(41, 26)
        Me.txtid_cliente.TabIndex = 0
        Me.txtid_cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtid_cliente, "Escriba el Código del Cliente")
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(508, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 24)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Plazo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbid_pedido
        '
        Me.cbid_pedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbid_pedido.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbid_pedido.Location = New System.Drawing.Point(725, 3)
        Me.cbid_pedido.Name = "cbid_pedido"
        Me.cbid_pedido.Size = New System.Drawing.Size(128, 26)
        Me.cbid_pedido.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cbid_pedido, "Seleccione el Número de Pedido")
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(660, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 24)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Pedido"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbid_agente
        '
        Me.cbid_agente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbid_agente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbid_agente.Location = New System.Drawing.Point(68, 32)
        Me.cbid_agente.Name = "cbid_agente"
        Me.cbid_agente.Size = New System.Drawing.Size(270, 26)
        Me.cbid_agente.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cbid_agente, "Seleccione el Agente")
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 24)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Agente"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblcliente_nombre
        '
        Me.lblcliente_nombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcliente_nombre.Location = New System.Drawing.Point(115, 2)
        Me.lblcliente_nombre.Name = "lblcliente_nombre"
        Me.lblcliente_nombre.Size = New System.Drawing.Size(387, 24)
        Me.lblcliente_nombre.TabIndex = 38
        Me.lblcliente_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 24)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Cliente"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(319, 649)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 24)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Disponible"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbldisponible
        '
        Me.lbldisponible.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldisponible.Location = New System.Drawing.Point(401, 653)
        Me.lbldisponible.Name = "lbldisponible"
        Me.lbldisponible.Size = New System.Drawing.Size(83, 16)
        Me.lbldisponible.TabIndex = 66
        Me.lbldisponible.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbmoroso
        '
        Me.pbmoroso.Image = CType(resources.GetObject("pbmoroso.Image"), System.Drawing.Image)
        Me.pbmoroso.Location = New System.Drawing.Point(20, 653)
        Me.pbmoroso.Name = "pbmoroso"
        Me.pbmoroso.Size = New System.Drawing.Size(12, 12)
        Me.pbmoroso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbmoroso.TabIndex = 67
        Me.pbmoroso.TabStop = False
        Me.pbmoroso.Visible = False
        '
        'pbaldia
        '
        Me.pbaldia.Image = CType(resources.GetObject("pbaldia.Image"), System.Drawing.Image)
        Me.pbaldia.Location = New System.Drawing.Point(21, 653)
        Me.pbaldia.Name = "pbaldia"
        Me.pbaldia.Size = New System.Drawing.Size(12, 12)
        Me.pbaldia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbaldia.TabIndex = 68
        Me.pbaldia.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbaldia, "Cliente Al Día")
        Me.pbaldia.Visible = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(150, 649)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 24)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Vencido"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblvencido
        '
        Me.lblvencido.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvencido.Location = New System.Drawing.Point(214, 653)
        Me.lblvencido.Name = "lblvencido"
        Me.lblvencido.Size = New System.Drawing.Size(83, 16)
        Me.lblvencido.TabIndex = 70
        Me.lblvencido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbldias_atraso
        '
        Me.lbldias_atraso.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldias_atraso.Location = New System.Drawing.Point(94, 648)
        Me.lbldias_atraso.Name = "lbldias_atraso"
        Me.lbldias_atraso.Size = New System.Drawing.Size(30, 27)
        Me.lbldias_atraso.TabIndex = 72
        Me.lbldias_atraso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(48, 648)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 24)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Días"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'id_producto
        '
        Me.id_producto.DataPropertyName = "id_producto"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.NullValue = Nothing
        Me.id_producto.DefaultCellStyle = DataGridViewCellStyle3
        Me.id_producto.HeaderText = "Cód"
        Me.id_producto.Name = "id_producto"
        Me.id_producto.ReadOnly = True
        Me.id_producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id_producto.Width = 60
        '
        'cantidad
        '
        Me.cantidad.DataPropertyName = "cantidad"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.NullValue = Nothing
        Me.cantidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.cantidad.HeaderText = "Cant"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        Me.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cantidad.Width = 50
        '
        'Unidad_nombre
        '
        Me.Unidad_nombre.DataPropertyName = "Unidad_nombre"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Unidad_nombre.DefaultCellStyle = DataGridViewCellStyle5
        Me.Unidad_nombre.HeaderText = ""
        Me.Unidad_nombre.Name = "Unidad_nombre"
        Me.Unidad_nombre.ReadOnly = True
        Me.Unidad_nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Unidad_nombre.Width = 35
        '
        'nombre
        '
        Me.nombre.DataPropertyName = "nombre"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.DefaultCellStyle = DataGridViewCellStyle6
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nombre.Width = 360
        '
        'Precio
        '
        Me.Precio.DataPropertyName = "precio"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Precio.DefaultCellStyle = DataGridViewCellStyle7
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Precio.Width = 80
        '
        'tpddescuento
        '
        Me.tpddescuento.DataPropertyName = "descuento"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.tpddescuento.DefaultCellStyle = DataGridViewCellStyle8
        Me.tpddescuento.HeaderText = "%"
        Me.tpddescuento.Name = "tpddescuento"
        Me.tpddescuento.ReadOnly = True
        Me.tpddescuento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tpddescuento.Width = 50
        '
        'TPDMonto
        '
        Me.TPDMonto.DataPropertyName = "Monto"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.TPDMonto.DefaultCellStyle = DataGridViewCellStyle9
        Me.TPDMonto.HeaderText = "Monto"
        Me.TPDMonto.Name = "TPDMonto"
        Me.TPDMonto.ReadOnly = True
        Me.TPDMonto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'tpdiv
        '
        Me.tpdiv.DataPropertyName = "iv"
        Me.tpdiv.HeaderText = "iv"
        Me.tpdiv.Name = "tpdiv"
        Me.tpdiv.ReadOnly = True
        Me.tpdiv.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tpdiv.Width = 25
        '
        'unidad
        '
        Me.unidad.DataPropertyName = "unidad"
        Me.unidad.HeaderText = "Column1"
        Me.unidad.Name = "unidad"
        Me.unidad.ReadOnly = True
        Me.unidad.Visible = False
        '
        'consumidor
        '
        Me.consumidor.DataPropertyName = "consumidor"
        Me.consumidor.HeaderText = "Column1"
        Me.consumidor.Name = "consumidor"
        Me.consumidor.ReadOnly = True
        Me.consumidor.Visible = False
        '
        'ubicacion
        '
        Me.ubicacion.DataPropertyName = "ubicacion"
        Me.ubicacion.HeaderText = "Column1"
        Me.ubicacion.Name = "ubicacion"
        Me.ubicacion.ReadOnly = True
        Me.ubicacion.Visible = False
        '
        'empaque
        '
        Me.empaque.DataPropertyName = "empaque"
        Me.empaque.HeaderText = "Column1"
        Me.empaque.Name = "empaque"
        Me.empaque.ReadOnly = True
        Me.empaque.Visible = False
        '
        'btnajustar
        '
        Me.btnajustar.Enabled = False
        Me.btnajustar.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnajustar.Image = CType(resources.GetObject("btnajustar.Image"), System.Drawing.Image)
        Me.btnajustar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnajustar.Location = New System.Drawing.Point(844, 282)
        Me.btnajustar.Name = "btnajustar"
        Me.btnajustar.Size = New System.Drawing.Size(54, 48)
        Me.btnajustar.TabIndex = 81
        Me.btnajustar.Text = "Cambios"
        Me.btnajustar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnajustar.UseVisualStyleBackColor = True
        '
        'frm_pedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 695)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbldias_atraso)
        Me.Controls.Add(Me.lblvencido)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.pbmoroso)
        Me.Controls.Add(Me.pbaldia)
        Me.Controls.Add(Me.lbldisponible)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.pnencabezado)
        Me.Controls.Add(Me.btntotales)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.lblproductos)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbltitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_pedido"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtgpedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.pnencabezado.ResumeLayout(False)
        Me.pnencabezado.PerformLayout()
        CType(Me.pbmoroso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbaldia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgpedido As System.Windows.Forms.DataGridView
    Friend WithEvents lblproductos As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btntotales As System.Windows.Forms.Button
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnencabezado As System.Windows.Forms.Panel
    Friend WithEvents txtid_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbid_pedido As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbid_agente As System.Windows.Forms.ComboBox
    Friend WithEvents lblcliente_nombre As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbldisponible As System.Windows.Forms.Label
    Friend WithEvents pbmoroso As System.Windows.Forms.PictureBox
    Friend WithEvents pbaldia As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblvencido As System.Windows.Forms.Label
    Friend WithEvents lbldias_atraso As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnincluir As System.Windows.Forms.Button
    Friend WithEvents btnAlistar As System.Windows.Forms.Button
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnproformar As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btnfacturar As System.Windows.Forms.Button
    Friend WithEvents txtplazo As System.Windows.Forms.TextBox
    Friend WithEvents id_producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad_nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpddescuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TPDMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpdiv As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents consumidor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ubicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents empaque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnajustar As System.Windows.Forms.Button
End Class
