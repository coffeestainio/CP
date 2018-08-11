Imports System.Data.SqlClient
Public Class frm_producto_buscar
    Inherits System.Windows.Forms.Form
    
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents dtgproducto As System.Windows.Forms.DataGridView
    Dim producto As DataTable
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
    Friend WithEvents bloqueado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Dim DvProducto As DataView
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtbuscar_producto As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_producto_buscar))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtbuscar_producto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
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
        Me.bloqueado = New System.Windows.Forms.DataGridViewCheckBoxColumn
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgproducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtbuscar_producto
        '
        Me.txtbuscar_producto.AccessibleDescription = ""
        Me.txtbuscar_producto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbuscar_producto.Location = New System.Drawing.Point(61, 57)
        Me.txtbuscar_producto.Name = "txtbuscar_producto"
        Me.txtbuscar_producto.Size = New System.Drawing.Size(318, 26)
        Me.txtbuscar_producto.TabIndex = 26
        Me.txtbuscar_producto.Tag = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(626, 32)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Buscar Productos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(34, 59)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 29
        Me.PictureBox5.TabStop = False
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
        Me.dtgproducto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_producto, Me.nombre, Me.id_b_r, Me.costo, Me.utilidad_1, Me.utilidad_2, Me.utilidad_3, Me.Column1, Me.utilidad_4, Me.detalle, Me.id_pasillo, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column7, Me.existencia, Me.empaque, Me.sub_empaque, Me.bloqueado})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgproducto.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgproducto.Location = New System.Drawing.Point(34, 105)
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
        Me.dtgproducto.Size = New System.Drawing.Size(566, 403)
        Me.dtgproducto.TabIndex = 30
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
        'bloqueado
        '
        Me.bloqueado.DataPropertyName = "bloqueado"
        Me.bloqueado.HeaderText = "Bloq"
        Me.bloqueado.Name = "bloqueado"
        Me.bloqueado.ReadOnly = True
        Me.bloqueado.Width = 40
        '
        'frm_producto_buscar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(625, 520)
        Me.Controls.Add(Me.dtgproducto)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.txtbuscar_producto)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_producto_buscar"
        Me.Opacity = 0.9
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgproducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frm_producto_buscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SendKeys.Send("{right}")
    End Sub

    Private Sub Asignar_id_producto()
        'Try
        Select Case BUSQUEDA
            Case "Compra"
                myForms.frm_Compra_Mantenimiento.txtid_producto.Text = dtgproducto.Item("id_producto", dtgproducto.CurrentRow.Index).Value
                myForms.frm_Compra_Mantenimiento.Identifica_producto()
            Case "Cambio"
                myForms.frm_Cambio_Mantenimiento.txtid_producto.Text = dtgproducto.Item("id_producto", dtgproducto.CurrentRow.Index).Value
                myForms.frm_Cambio_Mantenimiento.Identifica_producto()
            Case "Pedido"
                myForms.frm_pedido_mantenimiento.txtid_producto.Text = dtgproducto.Item("id_producto", dtgproducto.CurrentRow.Index).Value
                myForms.frm_pedido_mantenimiento.Identifica_producto()
            Case "Inventario"
                myForms.frm_inventario_mantenimiento.txtid_producto.Text = dtgproducto.Item("id_producto", dtgproducto.CurrentRow.Index).Value
                myForms.frm_inventario_mantenimiento.Identifica_producto()
            Case "Bodega_Ajuste"
                myForms.frm_Bodega_ajuste_mantenimiento.txtid_producto.Text = dtgproducto.Item("id_producto", dtgproducto.CurrentRow.Index).Value
                myForms.frm_Bodega_ajuste_mantenimiento.Identifica_producto()
            Case "rpt_venta_producto_cliente_opciones"
                myForms.frm_rpt_venta_producto_cliente_opciones.txtid_producto.Text = dtgproducto.Item("id_producto", dtgproducto.CurrentRow.Index).Value
                myForms.frm_rpt_venta_producto_cliente_opciones.Identifica_Producto()
        End Select
        Me.Close()
        ' Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        ' End Try
    End Sub

    Private Sub txtbuscar_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbuscar_producto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            dtgproducto.Focus()
        End If
    End Sub

    Private Sub txtbuscar_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbuscar_producto.TextChanged
        Try
            If txtbuscar_producto.Text.Length > 0 Then
                If IsNumeric(txtbuscar_producto.Text.Substring(0, 1)) Then
                    producto = Table("select id_producto,nombre,bloqueado from producto where  id_Producto Like '" & txtbuscar_producto.Text & "%'", "")
                    DvProducto = New DataView(producto)
                    DvProducto.Sort = "id_producto"
                Else
                    producto = Table("select id_producto,nombre,bloqueado from producto where  nombre Like '%" & txtbuscar_producto.Text & "%'", "")
                    DvProducto = New DataView(producto)
                    DvProducto.Sort = "nombre"

                End If
            End If

            dtgproducto.DataSource = DvProducto

        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub


    Private Sub dtgproducto_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgproducto.CellContentClick
        Asignar_id_producto()
    End Sub

    Private Sub dtgproducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgproducto.Click
        Asignar_id_producto()
    End Sub



    Private Sub dtgproducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgproducto.KeyDown
        If e.KeyCode = Keys.Return Then
            e.Handled = True
            Asignar_id_producto()
        End If
    End Sub
End Class
