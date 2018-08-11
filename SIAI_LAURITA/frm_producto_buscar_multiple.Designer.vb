<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_producto_buscar_multiple
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_producto_buscar_multiple))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.txtbuscar_producto = New System.Windows.Forms.TextBox
        Me.dtgproducto = New System.Windows.Forms.DataGridView
        Me.id_producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_b_r = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.utilidad_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.utilidad_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.utilidad_3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.utilidad_4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.detalle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_pasillo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.existencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.empaque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sub_empaque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.lb_seleccionados = New System.Windows.Forms.ListBox
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgproducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(34, 58)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(35, 24)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 33
        Me.PictureBox5.TabStop = False
        '
        'txtbuscar_producto
        '
        Me.txtbuscar_producto.AccessibleDescription = ""
        Me.txtbuscar_producto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbuscar_producto.Location = New System.Drawing.Point(75, 56)
        Me.txtbuscar_producto.Name = "txtbuscar_producto"
        Me.txtbuscar_producto.Size = New System.Drawing.Size(329, 26)
        Me.txtbuscar_producto.TabIndex = 32
        Me.txtbuscar_producto.Tag = ""
        '
        'dtgproducto
        '
        Me.dtgproducto.AllowUserToAddRows = False
        Me.dtgproducto.AllowUserToDeleteRows = False
        Me.dtgproducto.AllowUserToResizeColumns = False
        Me.dtgproducto.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgproducto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgproducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgproducto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_producto, Me.nombre, Me.id_b_r, Me.costo, Me.utilidad_1, Me.utilidad_2, Me.utilidad_3, Me.Column1, Me.utilidad_4, Me.detalle, Me.id_pasillo, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column7, Me.existencia, Me.empaque, Me.sub_empaque})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgproducto.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgproducto.Location = New System.Drawing.Point(34, 104)
        Me.dtgproducto.Name = "dtgproducto"
        Me.dtgproducto.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgproducto.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgproducto.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgproducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgproducto.Size = New System.Drawing.Size(512, 455)
        Me.dtgproducto.TabIndex = 34
        '
        'id_producto
        '
        Me.id_producto.DataPropertyName = "id_producto"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id_producto.DefaultCellStyle = DataGridViewCellStyle2
        Me.id_producto.HeaderText = "Cód"
        Me.id_producto.Name = "id_producto"
        Me.id_producto.ReadOnly = True
        Me.id_producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.id_producto.Width = 65
        '
        'nombre
        '
        Me.nombre.DataPropertyName = "nombre"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.DefaultCellStyle = DataGridViewCellStyle3
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.nombre.Width = 400
        '
        'id_b_r
        '
        Me.id_b_r.DataPropertyName = "id_b_r"
        Me.id_b_r.HeaderText = "Column6"
        Me.id_b_r.Name = "id_b_r"
        Me.id_b_r.ReadOnly = True
        Me.id_b_r.Visible = False
        '
        'costo
        '
        Me.costo.DataPropertyName = "costo"
        Me.costo.HeaderText = "Column6"
        Me.costo.Name = "costo"
        Me.costo.ReadOnly = True
        Me.costo.Visible = False
        '
        'utilidad_1
        '
        Me.utilidad_1.DataPropertyName = "utilidad_1"
        Me.utilidad_1.HeaderText = "Column6"
        Me.utilidad_1.Name = "utilidad_1"
        Me.utilidad_1.ReadOnly = True
        Me.utilidad_1.Visible = False
        '
        'utilidad_2
        '
        Me.utilidad_2.DataPropertyName = "utilidad_2"
        Me.utilidad_2.HeaderText = "Column6"
        Me.utilidad_2.Name = "utilidad_2"
        Me.utilidad_2.ReadOnly = True
        Me.utilidad_2.Visible = False
        '
        'utilidad_3
        '
        Me.utilidad_3.DataPropertyName = "utilidad_3"
        Me.utilidad_3.HeaderText = "Column6"
        Me.utilidad_3.Name = "utilidad_3"
        Me.utilidad_3.ReadOnly = True
        Me.utilidad_3.Visible = False
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "presentacion"
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 40
        '
        'utilidad_4
        '
        Me.utilidad_4.DataPropertyName = "utilidad_4"
        Me.utilidad_4.HeaderText = "Column6"
        Me.utilidad_4.Name = "utilidad_4"
        Me.utilidad_4.ReadOnly = True
        Me.utilidad_4.Visible = False
        '
        'detalle
        '
        Me.detalle.DataPropertyName = "detalle"
        Me.detalle.HeaderText = "Column6"
        Me.detalle.Name = "detalle"
        Me.detalle.ReadOnly = True
        Me.detalle.Visible = False
        '
        'id_pasillo
        '
        Me.id_pasillo.DataPropertyName = "id_pasillo"
        Me.id_pasillo.HeaderText = "Column6"
        Me.id_pasillo.Name = "id_pasillo"
        Me.id_pasillo.ReadOnly = True
        Me.id_pasillo.Visible = False
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "barcode"
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "id_Proveedor"
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "id_linea"
        Me.Column4.HeaderText = "Column4"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "observaciones"
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "iv"
        Me.Column7.HeaderText = "Column7"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'existencia
        '
        Me.existencia.DataPropertyName = "existencia"
        Me.existencia.HeaderText = "Column6"
        Me.existencia.Name = "existencia"
        Me.existencia.ReadOnly = True
        Me.existencia.Visible = False
        '
        'empaque
        '
        Me.empaque.DataPropertyName = "empaque"
        Me.empaque.HeaderText = "Column6"
        Me.empaque.Name = "empaque"
        Me.empaque.ReadOnly = True
        Me.empaque.Visible = False
        '
        'sub_empaque
        '
        Me.sub_empaque.DataPropertyName = "sub_empaque"
        Me.sub_empaque.HeaderText = "Column6"
        Me.sub_empaque.Name = "sub_empaque"
        Me.sub_empaque.ReadOnly = True
        Me.sub_empaque.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.Location = New System.Drawing.Point(0, -1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(724, 32)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Buscar Multiples Productos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb_seleccionados
        '
        Me.lb_seleccionados.FormattingEnabled = True
        Me.lb_seleccionados.Location = New System.Drawing.Point(568, 132)
        Me.lb_seleccionados.Name = "lb_seleccionados"
        Me.lb_seleccionados.Size = New System.Drawing.Size(133, 264)
        Me.lb_seleccionados.TabIndex = 35
        '
        'btnaceptar
        '
        Me.btnaceptar.Image = CType(resources.GetObject("btnaceptar.Image"), System.Drawing.Image)
        Me.btnaceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaceptar.Location = New System.Drawing.Point(595, 402)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(88, 32)
        Me.btnaceptar.TabIndex = 36
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(552, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Códigos Seleccionados"
        '
        'frm_producto_buscar_multiple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 585)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.lb_seleccionados)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.txtbuscar_producto)
        Me.Controls.Add(Me.dtgproducto)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_producto_buscar_multiple"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgproducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents txtbuscar_producto As System.Windows.Forms.TextBox
    Friend WithEvents dtgproducto As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lb_seleccionados As System.Windows.Forms.ListBox
    Friend WithEvents id_producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_b_r As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents utilidad_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents utilidad_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents utilidad_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents utilidad_4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_pasillo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents existencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents empaque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sub_empaque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
