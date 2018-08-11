<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_nota_credito_buscar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtgnc = New System.Windows.Forms.DataGridView
        Me.id_nota_credito = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_usuario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.anulado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.piv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.exento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gravado = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtgnc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.Location = New System.Drawing.Point(0, -1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(797, 35)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Notas de Crédito"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtgnc
        '
        Me.dtgnc.AllowUserToAddRows = False
        Me.dtgnc.AllowUserToDeleteRows = False
        Me.dtgnc.AllowUserToResizeColumns = False
        Me.dtgnc.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgnc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgnc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgnc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_nota_credito, Me.fecha, Me.Monto, Me.observaciones, Me.id_cliente, Me.id_usuario, Me.anulado, Me.piv, Me.exento, Me.gravado})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgnc.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgnc.Location = New System.Drawing.Point(21, 37)
        Me.dtgnc.Name = "dtgnc"
        Me.dtgnc.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgnc.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgnc.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgnc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgnc.Size = New System.Drawing.Size(747, 388)
        Me.dtgnc.TabIndex = 31
        '
        'id_nota_credito
        '
        Me.id_nota_credito.DataPropertyName = "id_nota_credito"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id_nota_credito.DefaultCellStyle = DataGridViewCellStyle2
        Me.id_nota_credito.HeaderText = "Número"
        Me.id_nota_credito.Name = "id_nota_credito"
        Me.id_nota_credito.ReadOnly = True
        Me.id_nota_credito.Width = 75
        '
        'fecha
        '
        Me.fecha.DataPropertyName = "fecha"
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Width = 90
        '
        'Monto
        '
        Me.Monto.DataPropertyName = "monto"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Monto.DefaultCellStyle = DataGridViewCellStyle3
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        Me.Monto.Width = 120
        '
        'observaciones
        '
        Me.observaciones.DataPropertyName = "observaciones"
        Me.observaciones.HeaderText = "observaciones"
        Me.observaciones.Name = "observaciones"
        Me.observaciones.ReadOnly = True
        Me.observaciones.Width = 400
        '
        'id_cliente
        '
        Me.id_cliente.DataPropertyName = "id_cliente"
        Me.id_cliente.HeaderText = "id_cliente"
        Me.id_cliente.Name = "id_cliente"
        Me.id_cliente.ReadOnly = True
        Me.id_cliente.Visible = False
        '
        'id_usuario
        '
        Me.id_usuario.DataPropertyName = "id_usuario"
        Me.id_usuario.HeaderText = "id_usuario"
        Me.id_usuario.Name = "id_usuario"
        Me.id_usuario.ReadOnly = True
        Me.id_usuario.Visible = False
        '
        'anulado
        '
        Me.anulado.DataPropertyName = "anulado"
        Me.anulado.HeaderText = "anulado"
        Me.anulado.Name = "anulado"
        Me.anulado.ReadOnly = True
        Me.anulado.Visible = False
        '
        'piv
        '
        Me.piv.DataPropertyName = "piv"
        Me.piv.HeaderText = "piv"
        Me.piv.Name = "piv"
        Me.piv.ReadOnly = True
        Me.piv.Visible = False
        '
        'exento
        '
        Me.exento.DataPropertyName = "exento"
        Me.exento.HeaderText = "exento"
        Me.exento.Name = "exento"
        Me.exento.ReadOnly = True
        Me.exento.Visible = False
        '
        'gravado
        '
        Me.gravado.DataPropertyName = "gravado"
        Me.gravado.HeaderText = "gravado"
        Me.gravado.Name = "gravado"
        Me.gravado.ReadOnly = True
        Me.gravado.Visible = False
        '
        'frm_nota_credito_buscar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 437)
        Me.Controls.Add(Me.dtgnc)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_nota_credito_buscar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dtgnc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtgnc As System.Windows.Forms.DataGridView
    Friend WithEvents id_nota_credito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents anulado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents piv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents exento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gravado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
