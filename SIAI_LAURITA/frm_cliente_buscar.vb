Public Class frm_cliente_buscar
    Inherits System.Windows.Forms.Form

    Friend WithEvents dtgcliente As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_familia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents eliminado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn

    Dim Dvcliente As DataView
    Dim cliente As DataTable

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
    Friend WithEvents txtbuscar_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cliente_buscar))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtbuscar_cliente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtgcliente = New System.Windows.Forms.DataGridView
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.barcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_familia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.eliminado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtgcliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtbuscar_cliente
        '
        Me.txtbuscar_cliente.AccessibleDescription = ""
        Me.txtbuscar_cliente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbuscar_cliente.Location = New System.Drawing.Point(63, 56)
        Me.txtbuscar_cliente.Name = "txtbuscar_cliente"
        Me.txtbuscar_cliente.Size = New System.Drawing.Size(341, 26)
        Me.txtbuscar_cliente.TabIndex = 23
        Me.txtbuscar_cliente.Tag = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.Location = New System.Drawing.Point(0, -2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(592, 35)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Buscar Clientes"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtgcliente
        '
        Me.dtgcliente.AllowUserToAddRows = False
        Me.dtgcliente.AllowUserToDeleteRows = False
        Me.dtgcliente.AllowUserToResizeColumns = False
        Me.dtgcliente.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgcliente.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgcliente.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgcliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgcliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.nombre, Me.barcode, Me.precio, Me.id_proveedor, Me.id_familia, Me.iv, Me.eliminado, Me.Column1, Me.Column2, Me.Column7, Me.Column8, Me.Column5, Me.Column6})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgcliente.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgcliente.Location = New System.Drawing.Point(33, 103)
        Me.dtgcliente.Name = "dtgcliente"
        Me.dtgcliente.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgcliente.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgcliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgcliente.Size = New System.Drawing.Size(514, 381)
        Me.dtgcliente.TabIndex = 25
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(33, 58)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 26
        Me.PictureBox5.TabStop = False
        '
        'id
        '
        Me.id.DataPropertyName = "id_cliente"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id.DefaultCellStyle = DataGridViewCellStyle3
        Me.id.HeaderText = "Cód"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 50
        '
        'nombre
        '
        Me.nombre.DataPropertyName = "nombre"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.DefaultCellStyle = DataGridViewCellStyle4
        Me.nombre.HeaderText = "nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 300
        '
        'barcode
        '
        Me.barcode.DataPropertyName = "telefono"
        Me.barcode.HeaderText = "Teléfono"
        Me.barcode.Name = "barcode"
        Me.barcode.ReadOnly = True
        '
        'precio
        '
        Me.precio.DataPropertyName = "precio"
        Me.precio.HeaderText = "Column3"
        Me.precio.Name = "precio"
        Me.precio.ReadOnly = True
        Me.precio.Visible = False
        '
        'id_proveedor
        '
        Me.id_proveedor.DataPropertyName = "fax"
        Me.id_proveedor.HeaderText = "Column1"
        Me.id_proveedor.Name = "id_proveedor"
        Me.id_proveedor.ReadOnly = True
        Me.id_proveedor.Visible = False
        '
        'id_familia
        '
        Me.id_familia.DataPropertyName = "email"
        Me.id_familia.HeaderText = "Column1"
        Me.id_familia.Name = "id_familia"
        Me.id_familia.ReadOnly = True
        Me.id_familia.Visible = False
        '
        'iv
        '
        Me.iv.DataPropertyName = "direccion"
        Me.iv.HeaderText = "Column1"
        Me.iv.Name = "iv"
        Me.iv.ReadOnly = True
        Me.iv.Visible = False
        '
        'eliminado
        '
        Me.eliminado.DataPropertyName = "nombre_encargado"
        Me.eliminado.HeaderText = "Column1"
        Me.eliminado.Name = "eliminado"
        Me.eliminado.ReadOnly = True
        Me.eliminado.Visible = False
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "plazo"
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "limite_credito"
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "telefono_encargado"
        Me.Column7.HeaderText = "Column7"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "identificacion"
        Me.Column8.HeaderText = "Column8"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "observaciones"
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "eliminado"
        Me.Column6.HeaderText = "Column6"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'frm_cliente_buscar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(590, 496)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.dtgcliente)
        Me.Controls.Add(Me.txtbuscar_cliente)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_cliente_buscar"
        Me.Opacity = 0.9
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Buscar Clientes"
        CType(Me.dtgcliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frm_cliente_buscar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub


    Private Sub frm_cliente_buscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

        SendKeys.Send("{right}")
        
    End Sub

    Private Sub txtbuscar_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbuscar_cliente.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            dtgcliente.Focus()
        End If
    End Sub

    Private Sub txtbuscar_cliente_RightToLeftChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbuscar_cliente.RightToLeftChanged

    End Sub
    Private Sub txtbuscar_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbuscar_cliente.TextChanged
        'Try
        
        dtgcliente.DataSource = Dvcliente
        If txtbuscar_cliente.Text.Length > 0 Then

            If IsNumeric(txtbuscar_cliente.Text.Substring(0, 1)) Then
                cliente = Table("select id_cliente,nombre,telefono,identificacion from cliente where eliminado=0 and id_cliente Like '%" & txtbuscar_cliente.Text & "%' or identificacion like '%" & txtbuscar_cliente.Text & "%'", "")
                Dvcliente = New DataView(cliente)

                Dvcliente.Sort = "id_cliente"
                'Dvcliente.RowFilter = "id_cliente = " & txtbuscar_cliente.Text
            Else

                cliente = Table("select id_cliente,nombre,telefono,identificacion from cliente where eliminado=0 and nombre Like '%" & txtbuscar_cliente.Text & "%' or identificacion like '%" & txtbuscar_cliente.Text & "%'", "")
                Dvcliente = New DataView(cliente)

                'Dvcliente.Sort = "nombre"
                Dvcliente.RowFilter = "nombre Like '%" & txtbuscar_cliente.Text & "%'"
            End If
        End If
        dtgcliente.DataSource = Dvcliente
        ' Catch myerror As Exception
        'ONEX(Me.Name, myerror)
        ' End Try
    End Sub
    Private Sub Asignar_id_cliente()
        Try
            Select Case BUSQUEDA
                Case "Pedido"
                    myForms.frm_pedido.txtid_cliente.Text = dtgcliente.Item("id", dtgcliente.CurrentRow.Index).Value
                    myForms.frm_pedido.Identifica_cliente()
                Case ("Recibo")
                    myForms.frm_recibo.txtid_cliente.Text = dtgcliente.Item("id", dtgcliente.CurrentRow.Index).Value
                    myForms.frm_recibo.Identifica_cliente()
                Case ("Nota_credito")
                    myForms.frm_nota_credito.txtid_cliente.Text = dtgcliente.Item("id", dtgcliente.CurrentRow.Index).Value
                    myForms.frm_nota_credito.cliente_Identificar()
                Case ("Puntos_estado")
                    myForms.frm_rpt_puntos_estado_opciones.txtid_cliente.Text = dtgcliente.Item("id", dtgcliente.CurrentRow.Index).Value
                    myForms.frm_rpt_puntos_estado_opciones.Identifica_cliente()

                Case ("movimientos_cuenta")
                    myForms.frm_rpt_estado_opciones.txtid_cliente.Text = dtgcliente.Item("id", dtgcliente.CurrentRow.Index).Value
                    myForms.frm_rpt_estado_opciones.Identifica_cliente()
                Case ("cuentasxcobrar")
                    myForms.frm_rpt_cuentasxcobrar.txtid_cliente.Text = dtgcliente.Item("id", dtgcliente.CurrentRow.Index).Value
                    myForms.frm_rpt_cuentasxcobrar.Identifica_cliente()
                Case ("credito_vencido")
                    myForms.frm_rpt_credito_vencido_opciones.txtid_cliente.Text = dtgcliente.Item("id", dtgcliente.CurrentRow.Index).Value
                    myForms.frm_rpt_credito_vencido_opciones.Identifica_cliente()
                Case ("rpt_venta_producto_cliente_opciones")
                    myForms.frm_rpt_venta_producto_cliente_opciones.txtid_cliente.Text = dtgcliente.Item("id", dtgcliente.CurrentRow.Index).Value
                    myForms.frm_rpt_venta_producto_cliente_opciones.Identifica_cliente()
                    Case ("rpt_venta_neta_cliente_opciones")
                    myForms.frm_rpt_venta_neta_cliente_opciones.txtid_cliente.Text = dtgcliente.Item("id", dtgcliente.CurrentRow.Index).Value
                    myForms.frm_rpt_venta_neta_cliente_opciones.Identifica_cliente()
            End Select
            Me.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub
    Private Sub dtgcliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgcliente.Click
        Asignar_id_cliente()
    End Sub

    Private Sub dtgcliente_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgcliente.CellContentClick
        Asignar_id_cliente()
    End Sub



    Private Sub dtgcliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgcliente.KeyDown
        If e.KeyCode = Keys.Return Then
            e.Handled = True
            Asignar_id_cliente()
        End If
    End Sub
End Class
