Imports System.Data.SqlClient
Public Class frm_principal
    Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "
    <System.STAThread()> _
       Public Shared Sub Main()
        System.Windows.Forms.Application.EnableVisualStyles()
        System.Windows.Forms.Application.Run(New frm_principal)
    End Sub
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
    Friend WithEvents sl1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sl2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btndatos As System.Windows.Forms.ToolStripButton
    Friend WithEvents btncredito As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnbodega As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TSMbajuste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnreporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnmovimiento As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TSMfactura_anular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMrecibo_anular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMdevolucion_reversar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents SLBL1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SLBL2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SLBL3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnpedido As System.Windows.Forms.ToolStripButton
    Friend WithEvents btncompra As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnpunto As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TSMIPuntos_Estado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMPDebito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnconsulta As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TSMIdocumentos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMIpedidos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMImovimientos_cuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmicredito_vencido As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmicuentas_cobrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmirecibo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsminota_credito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmidevolucion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmireversar_nc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SLBL4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripButton

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_principal))
        Me.sl1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.sl2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.btnpedido = New System.Windows.Forms.ToolStripButton
        Me.btncompra = New System.Windows.Forms.ToolStripButton
        Me.btndatos = New System.Windows.Forms.ToolStripButton
        Me.btncredito = New System.Windows.Forms.ToolStripDropDownButton
        Me.TSMImovimientos_cuenta = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmicredito_vencido = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmicuentas_cobrar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmirecibo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsminota_credito = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmidevolucion = New System.Windows.Forms.ToolStripMenuItem
        Me.btnbodega = New System.Windows.Forms.ToolStripDropDownButton
        Me.TSMbajuste = New System.Windows.Forms.ToolStripMenuItem
        Me.btnreporte = New System.Windows.Forms.ToolStripButton
        Me.btnpunto = New System.Windows.Forms.ToolStripDropDownButton
        Me.TSMIPuntos_Estado = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMPDebito = New System.Windows.Forms.ToolStripMenuItem
        Me.btnmovimiento = New System.Windows.Forms.ToolStripDropDownButton
        Me.TSMfactura_anular = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMrecibo_anular = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMdevolucion_reversar = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmireversar_nc = New System.Windows.Forms.ToolStripMenuItem
        Me.btnconsulta = New System.Windows.Forms.ToolStripDropDownButton
        Me.TSMIdocumentos = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMIpedidos = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.SLBL1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.SLBL2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.SLBL3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.SLBL4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox11 = New System.Windows.Forms.PictureBox
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sl1
        '
        Me.sl1.Name = "sl1"
        Me.sl1.Size = New System.Drawing.Size(1013, 17)
        Me.sl1.Spring = True
        Me.sl1.Text = "Best IT"
        Me.sl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sl2
        '
        Me.sl2.Name = "sl2"
        Me.sl2.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnpedido, Me.btncompra, Me.btndatos, Me.btncredito, Me.btnbodega, Me.btnreporte, Me.btnpunto, Me.btnmovimiento, Me.btnconsulta, Me.ToolStripDropDownButton1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1028, 61)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'btnpedido
        '
        Me.btnpedido.Image = CType(resources.GetObject("btnpedido.Image"), System.Drawing.Image)
        Me.btnpedido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnpedido.Name = "btnpedido"
        Me.btnpedido.Size = New System.Drawing.Size(101, 58)
        Me.btnpedido.Text = "Pedidos"
        Me.btnpedido.ToolTipText = "Crear, Cargar, Consultar, Facturar Pedidos"
        '
        'btncompra
        '
        Me.btncompra.Image = CType(resources.GetObject("btncompra.Image"), System.Drawing.Image)
        Me.btncompra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncompra.Name = "btncompra"
        Me.btncompra.Size = New System.Drawing.Size(107, 58)
        Me.btncompra.Text = "Compras"
        Me.btncompra.ToolTipText = "Compras"
        '
        'btndatos
        '
        Me.btndatos.Image = CType(resources.GetObject("btndatos.Image"), System.Drawing.Image)
        Me.btndatos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btndatos.Name = "btndatos"
        Me.btndatos.Size = New System.Drawing.Size(89, 58)
        Me.btndatos.Text = "Datos"
        Me.btndatos.ToolTipText = "Agentes, Clientes, Productos, Listas de Precios, Proveedores, Usuarios, Parámetro" & _
            "s"
        '
        'btncredito
        '
        Me.btncredito.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMImovimientos_cuenta, Me.tsmicredito_vencido, Me.tsmicuentas_cobrar, Me.ToolStripSeparator1, Me.tsmirecibo, Me.ToolStripSeparator2, Me.tsminota_credito, Me.ToolStripSeparator3, Me.tsmidevolucion})
        Me.btncredito.Image = CType(resources.GetObject("btncredito.Image"), System.Drawing.Image)
        Me.btncredito.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncredito.Name = "btncredito"
        Me.btncredito.Size = New System.Drawing.Size(91, 58)
        Me.btncredito.Text = "CPC"
        '
        'TSMImovimientos_cuenta
        '
        Me.TSMImovimientos_cuenta.Name = "TSMImovimientos_cuenta"
        Me.TSMImovimientos_cuenta.Size = New System.Drawing.Size(201, 22)
        Me.TSMImovimientos_cuenta.Text = "Movimientos de Cuenta"
        '
        'tsmicredito_vencido
        '
        Me.tsmicredito_vencido.Name = "tsmicredito_vencido"
        Me.tsmicredito_vencido.Size = New System.Drawing.Size(201, 22)
        Me.tsmicredito_vencido.Text = "Crédito Vencido"
        '
        'tsmicuentas_cobrar
        '
        Me.tsmicuentas_cobrar.Name = "tsmicuentas_cobrar"
        Me.tsmicuentas_cobrar.Size = New System.Drawing.Size(201, 22)
        Me.tsmicuentas_cobrar.Text = "Cuentas x Cobrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(198, 6)
        '
        'tsmirecibo
        '
        Me.tsmirecibo.Name = "tsmirecibo"
        Me.tsmirecibo.Size = New System.Drawing.Size(201, 22)
        Me.tsmirecibo.Text = "Recibo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(198, 6)
        '
        'tsminota_credito
        '
        Me.tsminota_credito.Name = "tsminota_credito"
        Me.tsminota_credito.Size = New System.Drawing.Size(201, 22)
        Me.tsminota_credito.Text = "Nota Crédito"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(198, 6)
        '
        'tsmidevolucion
        '
        Me.tsmidevolucion.Name = "tsmidevolucion"
        Me.tsmidevolucion.Size = New System.Drawing.Size(201, 22)
        Me.tsmidevolucion.Text = "Devolución"
        '
        'btnbodega
        '
        Me.btnbodega.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMbajuste})
        Me.btnbodega.Image = CType(resources.GetObject("btnbodega.Image"), System.Drawing.Image)
        Me.btnbodega.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnbodega.Name = "btnbodega"
        Me.btnbodega.Size = New System.Drawing.Size(108, 58)
        Me.btnbodega.Text = "Bodega"
        '
        'TSMbajuste
        '
        Me.TSMbajuste.Name = "TSMbajuste"
        Me.TSMbajuste.Size = New System.Drawing.Size(107, 22)
        Me.TSMbajuste.Text = "Ajuste"
        '
        'btnreporte
        '
        Me.btnreporte.Image = CType(resources.GetObject("btnreporte.Image"), System.Drawing.Image)
        Me.btnreporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnreporte.Name = "btnreporte"
        Me.btnreporte.Size = New System.Drawing.Size(105, 58)
        Me.btnreporte.Text = "Reportes"
        Me.btnreporte.ToolTipText = "Reportes Varios"
        '
        'btnpunto
        '
        Me.btnpunto.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMIPuntos_Estado, Me.TSMPDebito})
        Me.btnpunto.Image = CType(resources.GetObject("btnpunto.Image"), System.Drawing.Image)
        Me.btnpunto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnpunto.Name = "btnpunto"
        Me.btnpunto.Size = New System.Drawing.Size(105, 58)
        Me.btnpunto.Text = "Puntos"
        '
        'TSMIPuntos_Estado
        '
        Me.TSMIPuntos_Estado.Name = "TSMIPuntos_Estado"
        Me.TSMIPuntos_Estado.Size = New System.Drawing.Size(166, 22)
        Me.TSMIPuntos_Estado.Text = "Estado de Cuenta"
        '
        'TSMPDebito
        '
        Me.TSMPDebito.Name = "TSMPDebito"
        Me.TSMPDebito.Size = New System.Drawing.Size(166, 22)
        Me.TSMPDebito.Text = "Debitar"
        '
        'btnmovimiento
        '
        Me.btnmovimiento.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMfactura_anular, Me.TSMrecibo_anular, Me.TSMdevolucion_reversar, Me.tsmireversar_nc})
        Me.btnmovimiento.Image = CType(resources.GetObject("btnmovimiento.Image"), System.Drawing.Image)
        Me.btnmovimiento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnmovimiento.Name = "btnmovimiento"
        Me.btnmovimiento.Size = New System.Drawing.Size(138, 58)
        Me.btnmovimiento.Text = "Movimientos"
        '
        'TSMfactura_anular
        '
        Me.TSMfactura_anular.Name = "TSMfactura_anular"
        Me.TSMfactura_anular.Size = New System.Drawing.Size(205, 22)
        Me.TSMfactura_anular.Text = "Anular Factura"
        '
        'TSMrecibo_anular
        '
        Me.TSMrecibo_anular.Name = "TSMrecibo_anular"
        Me.TSMrecibo_anular.Size = New System.Drawing.Size(205, 22)
        Me.TSMrecibo_anular.Text = "Anular Recibo"
        '
        'TSMdevolucion_reversar
        '
        Me.TSMdevolucion_reversar.Name = "TSMdevolucion_reversar"
        Me.TSMdevolucion_reversar.Size = New System.Drawing.Size(205, 22)
        Me.TSMdevolucion_reversar.Text = "Reversar Devolución"
        '
        'tsmireversar_nc
        '
        Me.tsmireversar_nc.Name = "tsmireversar_nc"
        Me.tsmireversar_nc.Size = New System.Drawing.Size(205, 22)
        Me.tsmireversar_nc.Text = "Reversar Nota de Crédito"
        '
        'btnconsulta
        '
        Me.btnconsulta.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMIdocumentos, Me.TSMIpedidos})
        Me.btnconsulta.Image = CType(resources.GetObject("btnconsulta.Image"), System.Drawing.Image)
        Me.btnconsulta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnconsulta.Name = "btnconsulta"
        Me.btnconsulta.Size = New System.Drawing.Size(115, 58)
        Me.btnconsulta.Text = "Consulta"
        '
        'TSMIdocumentos
        '
        Me.TSMIdocumentos.Name = "TSMIdocumentos"
        Me.TSMIdocumentos.Size = New System.Drawing.Size(142, 22)
        Me.TSMIdocumentos.Text = "Documentos"
        '
        'TSMIpedidos
        '
        Me.TSMIpedidos.Name = "TSMIpedidos"
        Me.TSMIpedidos.Size = New System.Drawing.Size(142, 22)
        Me.TSMIpedidos.Text = "Pedidos"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(98, 52)
        Me.ToolStripDropDownButton1.Text = "Conteo"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SLBL1, Me.SLBL2, Me.SLBL3, Me.SLBL4})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1028, 22)
        Me.StatusStrip1.TabIndex = 8
        '
        'SLBL1
        '
        Me.SLBL1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.SLBL1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SLBL1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SLBL1.ForeColor = System.Drawing.Color.LightSlateGray
        Me.SLBL1.Name = "SLBL1"
        Me.SLBL1.Size = New System.Drawing.Size(974, 17)
        Me.SLBL1.Spring = True
        Me.SLBL1.Text = "Software by Pablo Calvo | 6059-8238 | pcalvo@artifexdigitalstudio.com"
        Me.SLBL1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SLBL2
        '
        Me.SLBL2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.SLBL2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.SLBL2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLBL2.Name = "SLBL2"
        Me.SLBL2.Size = New System.Drawing.Size(4, 17)
        '
        'SLBL3
        '
        Me.SLBL3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.SLBL3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.SLBL3.Name = "SLBL3"
        Me.SLBL3.Size = New System.Drawing.Size(4, 17)
        '
        'SLBL4
        '
        Me.SLBL4.Name = "SLBL4"
        Me.SLBL4.Size = New System.Drawing.Size(0, 17)
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label12.Location = New System.Drawing.Point(13, 588)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(151, 41)
        Me.Label12.TabIndex = 123
        Me.Label12.Text = "Best IT"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox11
        '
        Me.PictureBox11.BackColor = System.Drawing.SystemColors.Highlight
        Me.PictureBox11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(109, 223)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(811, 214)
        Me.PictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox11.TabIndex = 122
        Me.PictureBox11.TabStop = False
        '
        'frm_principal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1028, 661)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox11)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SIAA2 CP"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub frm_principal_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Application.Exit()
    End Sub

    Private Sub frm_principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If USUARIO_NIVEL = 1 Then
            btnconsulta.Visible = False
            btncredito.Visible = False
            btnmovimiento.Visible = False
        End If
    End Sub



    Private Sub btndatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndatos.Click
        ToolStrip.Enabled = False
        Dim datos_mantenimiento As New frm_datos_mantenimiento
        myForms.frm_datos_mantenimiento = datos_mantenimiento
        myForms.frm_datos_mantenimiento.Owner = Me
        datos_mantenimiento.Show()
    End Sub





    Private Sub btnreporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreporte.Click
        ToolStrip.Enabled = False
        Dim reportes_admin As New frm_reportes_admin
        reportes_admin.Owner = Me
        reportes_admin.Show()
    End Sub

    Private Sub TSMfactura_anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMfactura_anular.Click
        ToolStrip.Enabled = False
        Dim factura_anular As New frm_factura_anular
        factura_anular.Owner = Me
        factura_anular.Show()
    End Sub

    Private Sub TSMrecibo_anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMrecibo_anular.Click
        ToolStrip.Enabled = False
        Dim recibo_anular As New frm_recibo_anular
        recibo_anular.Owner = Me
        recibo_anular.Show()
    End Sub



    Private Sub TSMdevolucion_reversar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMdevolucion_reversar.Click
        ToolStrip.Enabled = False
        Dim devolucion_reversar As New frm_devolucion_reversar
        devolucion_reversar.Owner = Me
        devolucion_reversar.Show()

    End Sub



    Private Sub TSMbajuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMbajuste.Click
        ToolStrip.Enabled = False
        Dim bodega_ajuste As New frm_bodega_ajuste
        myForms.frm_bodega_ajuste = frm_bodega_ajuste
        myForms.frm_bodega_ajuste.Owner = Me
        frm_bodega_ajuste.Show()
    End Sub





    Private Sub btnpedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpedido.Click
        ToolStrip.Enabled = False
        Dim Pedido As New frm_pedido
        Consulta = False
        myForms.frm_pedido = Pedido
        myForms.frm_pedido.Owner = Me
        Pedido.Show()
    End Sub

    Private Sub btncompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncompra.Click
        ToolStrip.Enabled = False
        Dim Compra As New frm_Compra
        myForms.frm_Compra = Compra
        myForms.frm_Compra.Owner = Me
        Compra.Show()
    End Sub

    Private Sub TSMPDebito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMPDebito.Click
        ToolStrip.Enabled = False
        Dim puntos_debito As New frm_Puntos_Debito
        myForms.frm_puntos_debito = puntos_debito
        myForms.frm_puntos_debito.Owner = Me
        puntos_debito.Show()
    End Sub

    Private Sub TSMIdocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMIdocumentos.Click
        ToolStrip.Enabled = False
        Dim consulta_documento As New frm_consulta_documento
        myForms.frm_consulta_documento = consulta_documento
        myForms.frm_consulta_documento.Owner = Me
        consulta_documento.Show()
    End Sub


    Private Sub TSMIpedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMIpedidos.Click
        ToolStrip.Enabled = False
        Dim Pedidos As New frm_Pedidos
        Consulta = False
        Pedidos.Owner = Me
        Pedidos.Show()
    End Sub

    Private Sub TSMImovimientos_cuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMImovimientos_cuenta.Click
        ToolStrip.Enabled = False
        Dim estado As New frm_rpt_estado_opciones
        myForms.frm_rpt_estado_opciones = estado
        myForms.frm_rpt_estado_opciones.Owner = Me
        estado.Show()
    End Sub

    Private Sub tsmicredito_vencido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmicredito_vencido.Click
        ToolStrip.Enabled = False
        Dim vencido As New frm_rpt_credito_vencido_opciones
        myForms.frm_rpt_credito_vencido_opciones = vencido
        myForms.frm_rpt_credito_vencido_opciones.Owner = Me
        vencido.Show()
    End Sub

    Private Sub tsmicuentas_cobrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmicuentas_cobrar.Click
        ToolStrip.Enabled = False
        Dim pendiente As New frm_rpt_cuentasxcobrar
        myForms.frm_rpt_cuentasxcobrar = pendiente
        myForms.frm_rpt_cuentasxcobrar.Owner = Me
        pendiente.Show()
    End Sub

    Private Sub tsmirecibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmirecibo.Click
        ToolStrip.Enabled = False
        Consulta = False
        Dim recibo As New frm_recibo
        myForms.frm_recibo = recibo
        myForms.frm_recibo.Owner = Me
        recibo.Show()
    End Sub

    Private Sub tsminota_credito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsminota_credito.Click
        ToolStrip.Enabled = False
        Consulta = False
        Dim nota_credito As New frm_Nota_Credito
        myForms.frm_nota_credito = nota_credito
        myForms.frm_nota_credito.Owner = Me
        nota_credito.Show()
    End Sub

    Private Sub tsmidevolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmidevolucion.Click
        ToolStrip.Enabled = False
        Consulta = False
        Dim devolucion As New frm_devolucion
        myForms.frm_devolucion = devolucion
        myForms.frm_devolucion.Owner = Me
        devolucion.Show()
    End Sub

    Private Sub btncredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncredito.Click

    End Sub

    Private Sub tsmireversar_nc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmireversar_nc.Click
        ToolStrip.Enabled = False
        Consulta = False
        Dim rnc As New frm_Nota_Credito_Reversar
        rnc.Owner = Me
        rnc.Show()
    End Sub

    Private Sub TSMIPuntos_Estado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMIPuntos_Estado.Click
        ToolStrip.Enabled = False
        Consulta = False
        Dim rpt_puntos_estado_opciones As New frm_rpt_Puntos_estado_opciones
        myForms.frm_rpt_puntos_estado_opciones = rpt_puntos_estado_opciones
        myForms.frm_rpt_puntos_estado_opciones.Owner = Me
        rpt_puntos_estado_opciones.Show()
    End Sub

    Private Sub ToolStripDropDownButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ToolStrip.Enabled = False
        Dim rpt_existencia_conteo As New frm_existencia_conteo
        myForms.frm_existencia_conteo = rpt_existencia_conteo
        myForms.frm_existencia_conteo.Owner = Me
        rpt_existencia_conteo.Show()
    End Sub

    Private Sub RestearExistenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        existencias_resetear()
    End Sub

    Public Sub existencias_resetear()
        Dim res As Integer
        res = MsgBox("Esta función volvera a 0 las existencias de todos los productos. ¿Desea Continuar?", MsgBoxStyle.YesNo)
        If res = vbNo Then Exit Sub
        OpenConn()
        sqlquery("Update producto set existencia = 0")
        CONN1.Close()
        MsgBox("Operación completada con exito")
    End Sub

    Private Sub ToolStripDropDownButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton1.Click
        ToolStrip.Enabled = False
        Dim inventario As New frm_inventario
        myForms.frm_inventario = inventario
        myForms.frm_inventario.Owner = Me
        inventario.Show()
    End Sub

    Private Sub SLBL1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLBL1.Click

    End Sub
End Class
