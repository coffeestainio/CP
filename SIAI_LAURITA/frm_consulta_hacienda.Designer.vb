<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_hacienda
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.bntReenviar = New System.Windows.Forms.Button
        Me.dtphasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpdesde = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbltitulo = New System.Windows.Forms.Label
        Me.dtgdocumento = New System.Windows.Forms.DataGridView
        Me.id_documento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.coderror = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescripcionError = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnContribuyente = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.dtgdocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnContribuyente)
        Me.Panel1.Controls.Add(Me.bntReenviar)
        Me.Panel1.Controls.Add(Me.dtphasta)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpdesde)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(26, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1042, 61)
        Me.Panel1.TabIndex = 47
        '
        'bntReenviar
        '
        Me.bntReenviar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntReenviar.Location = New System.Drawing.Point(842, 5)
        Me.bntReenviar.Name = "bntReenviar"
        Me.bntReenviar.Size = New System.Drawing.Size(193, 43)
        Me.bntReenviar.TabIndex = 68
        Me.bntReenviar.Text = "Reenviar Documentos"
        Me.bntReenviar.UseVisualStyleBackColor = True
        '
        'dtphasta
        '
        Me.dtphasta.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtphasta.Location = New System.Drawing.Point(291, 11)
        Me.dtphasta.Name = "dtphasta"
        Me.dtphasta.Size = New System.Drawing.Size(111, 26)
        Me.dtphasta.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(227, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 24)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Hasta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpdesde
        '
        Me.dtpdesde.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdesde.Location = New System.Drawing.Point(90, 11)
        Me.dtpdesde.Name = "dtpdesde"
        Me.dtpdesde.Size = New System.Drawing.Size(111, 26)
        Me.dtpdesde.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 24)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Desde"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltitulo
        '
        Me.lbltitulo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbltitulo.Location = New System.Drawing.Point(-4, -1)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(745, 27)
        Me.lbltitulo.TabIndex = 46
        Me.lbltitulo.Text = "Consulta de Documentos"
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtgdocumento
        '
        Me.dtgdocumento.AllowUserToAddRows = False
        Me.dtgdocumento.AllowUserToDeleteRows = False
        Me.dtgdocumento.AllowUserToResizeColumns = False
        Me.dtgdocumento.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgdocumento.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgdocumento.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgdocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgdocumento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_documento, Me.id_cliente, Me.fecha, Me.coderror, Me.DescripcionError})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgdocumento.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtgdocumento.Location = New System.Drawing.Point(26, 96)
        Me.dtgdocumento.Name = "dtgdocumento"
        Me.dtgdocumento.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgdocumento.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgdocumento.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgdocumento.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgdocumento.Size = New System.Drawing.Size(1042, 618)
        Me.dtgdocumento.TabIndex = 48
        '
        'id_documento
        '
        Me.id_documento.DataPropertyName = "id_documento"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id_documento.DefaultCellStyle = DataGridViewCellStyle3
        Me.id_documento.HeaderText = "Documento"
        Me.id_documento.Name = "id_documento"
        Me.id_documento.ReadOnly = True
        Me.id_documento.Width = 85
        '
        'id_cliente
        '
        Me.id_cliente.DataPropertyName = "id_cliente"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.NullValue = Nothing
        Me.id_cliente.DefaultCellStyle = DataGridViewCellStyle4
        Me.id_cliente.HeaderText = "Cliente"
        Me.id_cliente.Name = "id_cliente"
        Me.id_cliente.ReadOnly = True
        '
        'fecha
        '
        Me.fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle5
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Width = 150
        '
        'coderror
        '
        Me.coderror.DataPropertyName = "coderror"
        Me.coderror.HeaderText = "Codigo"
        Me.coderror.Name = "coderror"
        Me.coderror.ReadOnly = True
        '
        'DescripcionError
        '
        Me.DescripcionError.DataPropertyName = "descripcionerror"
        Me.DescripcionError.HeaderText = "Descripcion Error"
        Me.DescripcionError.Name = "DescripcionError"
        Me.DescripcionError.ReadOnly = True
        Me.DescripcionError.Width = 550
        '
        'btnContribuyente
        '
        Me.btnContribuyente.BackColor = System.Drawing.SystemColors.Info
        Me.btnContribuyente.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContribuyente.Location = New System.Drawing.Point(643, 5)
        Me.btnContribuyente.Name = "btnContribuyente"
        Me.btnContribuyente.Size = New System.Drawing.Size(193, 43)
        Me.btnContribuyente.TabIndex = 69
        Me.btnContribuyente.Text = "No Contribuyente"
        Me.btnContribuyente.UseVisualStyleBackColor = False
        '
        'frm_consulta_hacienda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 742)
        Me.Controls.Add(Me.dtgdocumento)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbltitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_consulta_hacienda"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtgdocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents dtphasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpdesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtgdocumento As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents id_documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coderror As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionError As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bntReenviar As System.Windows.Forms.Button
    Friend WithEvents btnContribuyente As System.Windows.Forms.Button
End Class
