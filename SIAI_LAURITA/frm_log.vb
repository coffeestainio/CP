Imports System.Data.sqlclient
Imports System.Management
Public Class frm_log
    Inherits System.Windows.Forms.Form
    
    Dim Intento As Integer

    Private ReadOnly key() As Byte = _
                  {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, _
                  15, 16, 17, 18, 19, 20, 21, 22, 23, 24}
    Private ReadOnly iv() As Byte = {8, 7, 6, 5, 4, 3, 2, 1}

    ' instantiate the class with the arrays
    Private TripleDES As New TripleDES(key, iv)

    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btningresar As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtclave As System.Windows.Forms.TextBox
    Friend WithEvents frmlog As System.Windows.Forms.GroupBox
    Friend WithEvents pbclave As System.Windows.Forms.PictureBox
    Friend WithEvents pbnombre As System.Windows.Forms.PictureBox
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

#Region " Windows Form Designer generated code "
    <System.STAThread()> _
    Public Shared Sub Main()
        System.Windows.Forms.Application.EnableVisualStyles()
        System.Windows.Forms.Application.Run(New frm_log)
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblversion As System.Windows.Forms.Label
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_log))
        Me.lblversion = New System.Windows.Forms.Label
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtclave = New System.Windows.Forms.TextBox
        Me.btnsalir = New System.Windows.Forms.Button
        Me.btningresar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.frmlog = New System.Windows.Forms.GroupBox
        Me.pbclave = New System.Windows.Forms.PictureBox
        Me.pbnombre = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.frmlog.SuspendLayout()
        CType(Me.pbclave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbnombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblversion
        '
        Me.lblversion.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblversion.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblversion.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lblversion.Location = New System.Drawing.Point(0, -1)
        Me.lblversion.Name = "lblversion"
        Me.lblversion.Size = New System.Drawing.Size(555, 24)
        Me.lblversion.TabIndex = 3
        Me.lblversion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtnombre
        '
        Me.txtnombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(120, 28)
        Me.txtnombre.MaxLength = 14
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(128, 26)
        Me.txtnombre.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.txtnombre, "Escriba el nombre del Usuario")
        '
        'txtclave
        '
        Me.txtclave.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtclave.Location = New System.Drawing.Point(120, 62)
        Me.txtclave.MaxLength = 14
        Me.txtclave.Name = "txtclave"
        Me.txtclave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(119)
        Me.txtclave.Size = New System.Drawing.Size(128, 25)
        Me.txtclave.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.txtclave, "Escriba la contraseña del Usuario")
        '
        'btnsalir
        '
        Me.btnsalir.Image = CType(resources.GetObject("btnsalir.Image"), System.Drawing.Image)
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsalir.Location = New System.Drawing.Point(160, 93)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(88, 32)
        Me.btnsalir.TabIndex = 3
        Me.btnsalir.Text = "Salir"
        Me.ToolTip.SetToolTip(Me.btnsalir, "Salir del Sistema")
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btningresar
        '
        Me.btningresar.Image = CType(resources.GetObject("btningresar.Image"), System.Drawing.Image)
        Me.btningresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btningresar.Location = New System.Drawing.Point(59, 93)
        Me.btningresar.Name = "btningresar"
        Me.btningresar.Size = New System.Drawing.Size(88, 32)
        Me.btningresar.TabIndex = 1
        Me.btningresar.Text = "Ingresar"
        Me.ToolTip.SetToolTip(Me.btningresar, "Ingresa al SIAI")
        Me.btningresar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Usuario"
        '
        'Label5
        '
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 24)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Contraseña"
        '
        'frmlog
        '
        Me.frmlog.Controls.Add(Me.pbclave)
        Me.frmlog.Controls.Add(Me.pbnombre)
        Me.frmlog.Controls.Add(Me.txtclave)
        Me.frmlog.Controls.Add(Me.txtnombre)
        Me.frmlog.Controls.Add(Me.btnsalir)
        Me.frmlog.Controls.Add(Me.btningresar)
        Me.frmlog.Controls.Add(Me.PictureBox2)
        Me.frmlog.Controls.Add(Me.PictureBox3)
        Me.frmlog.Controls.Add(Me.Label5)
        Me.frmlog.Controls.Add(Me.Label4)
        Me.frmlog.Location = New System.Drawing.Point(224, 26)
        Me.frmlog.Name = "frmlog"
        Me.frmlog.Size = New System.Drawing.Size(304, 134)
        Me.frmlog.TabIndex = 0
        Me.frmlog.TabStop = False
        '
        'pbclave
        '
        Me.pbclave.Image = CType(resources.GetObject("pbclave.Image"), System.Drawing.Image)
        Me.pbclave.Location = New System.Drawing.Point(254, 71)
        Me.pbclave.Name = "pbclave"
        Me.pbclave.Size = New System.Drawing.Size(12, 12)
        Me.pbclave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbclave.TabIndex = 70
        Me.pbclave.TabStop = False
        Me.pbclave.Visible = False
        '
        'pbnombre
        '
        Me.pbnombre.Image = CType(resources.GetObject("pbnombre.Image"), System.Drawing.Image)
        Me.pbnombre.Location = New System.Drawing.Point(256, 32)
        Me.pbnombre.Name = "pbnombre"
        Me.pbnombre.Size = New System.Drawing.Size(12, 12)
        Me.pbnombre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbnombre.TabIndex = 69
        Me.pbnombre.TabStop = False
        Me.pbnombre.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(256, 71)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 17
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(256, 32)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 15
        Me.PictureBox3.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label3
        '
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label3.Location = New System.Drawing.Point(0, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(553, 24)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Best It"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(35, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(138, 106)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 72
        Me.PictureBox1.TabStop = False
        '
        'frm_log
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(552, 189)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.frmlog)
        Me.Controls.Add(Me.lblversion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(150, 150)
        Me.Name = "frm_log"
        Me.Opacity = 0.9
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.frmlog.ResumeLayout(False)
        Me.frmlog.PerformLayout()
        CType(Me.pbclave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbnombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub frm_log_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim License As Boolean = False
            Select Case cpuInfo()
                Case "078BFBFF00020FC2" 'developer
                    License = True
                Case "0383FBFF00000681" 'central
                    License = True
                Case "AFE9FBFF000006D8" 'Laptop sony
                    License = True
            End Select

            ' If Not License Then
            'MessageBox.Show("Copia Sin Licencia", "", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            'Application.Exit()
            'End If


            Path = System.AppDomain.CurrentDomain.BaseDirectory()
            Intento = 0


            CONN1 = New SqlConnection(SERVER)


            OpenConn()

            Prst(1) = "Und"
            Prst(2) = "Caj"
            Prst(3) = "Blt"
            Prst(4) = "Pqt"
            lblversion.Text = "SIAA2 CP ver.  " + Version


        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub Comprobar()
        Try
            Intento = Intento + 1
            If Intento > 3 Then
                MessageBox.Show("Excedio el Número de Intentos Permitidos", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End If
            Dim fi As Boolean
            If txtnombre.Text = "" Then
                pbnombre.Visible = True
                fi = True
            Else
                pbnombre.Visible = False
            End If
            If txtclave.Text = "" Then
                pbclave.Visible = True
                fi = True
            Else
                pbclave.Visible = False
            End If
            If fi Then
                MessageBox.Show("Hay campos requeridos sin completar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim Usuario As DataTable

            Usuario = Table("Select * from usuario where eliminado=0 and nombre='" + txtnombre.Text + "'", "")

            If Usuario.Rows.Count = 0 Then
                MessageBox.Show("Usuario No Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtnombre.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
            End If
            With Usuario.Rows(0)

                If TripleDES.Decrypt(.Item("clave")) <> txtclave.Text Then
                    MessageBox.Show("Clave Incorrecta", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtclave.Focus()
                    SendKeys.Send("{home}+{end}")
                    Exit Sub
                End If

                USUARIO_NOMBRE = .Item("nombre")
                USUARIO_NIVEL = .Item("nivel")
                USUARIO_ID = .Item("id_usuario")


                ID_ESTACION = RFile(Path + "id")

                Dim principal As New frm_principal
                myForms.frm_principal = principal
                myForms.frm_principal.SLBL2.Text = "Usuario " + USUARIO_NOMBRE + "   "
                myForms.frm_principal.SLBL3.Text = "Estación " + ID_ESTACION
                myForms.frm_principal.SLBL4.Text = "Ver " + Version


                CONN1.Close()
                principal.Show()
            End With
            Me.Hide()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btningresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btningresar.Click
        Comprobar()
    End Sub
    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Application.Exit()
    End Sub

    Private Sub txtid_usuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtclave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtclave.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Comprobar()
        End If
    End Sub

    Private Function cpuInfo() As String
        Dim ID As String = " "
        Dim moSearch As New ManagementObjectSearcher("Select * from Win32_Processor")
        Dim moReturn As ManagementObjectCollection = moSearch.Get
        For Each mo As ManagementObject In moReturn
            ID = mo("ProcessorID")
        Next
        Return ID
    End Function
End Class
Public Class myForms
    Private Shared m_datos_mantenimiento As frm_datos_mantenimiento
    Public Shared Property frm_datos_mantenimiento() As frm_datos_mantenimiento
        Get
            Return m_datos_mantenimiento
        End Get
        Set(ByVal Value As frm_datos_mantenimiento)
            m_datos_mantenimiento = Value
        End Set
    End Property

    Private Shared m_existencia_conteo As frm_existencia_conteo
    Public Shared Property frm_existencia_conteo() As frm_existencia_conteo
        Get
            Return m_existencia_conteo
        End Get
        Set(ByVal Value As frm_existencia_conteo)
            m_existencia_conteo = Value
        End Set
    End Property

    Private Shared m_principal As frm_principal
    Public Shared Property frm_principal() As frm_principal
        Get
            Return m_principal
        End Get
        Set(ByVal Value As frm_principal)
            m_principal = Value
        End Set
    End Property

    Private Shared m_hacienda As frm_consulta_hacienda
    Public Shared Property frm_hacienda() As frm_consulta_hacienda
        Get
            Return m_hacienda
        End Get
        Set(ByVal Value As frm_consulta_hacienda)
            m_hacienda = Value
        End Set
    End Property
    
    Private Shared m_pedido As frm_pedido
    Public Shared Property frm_pedido() As frm_pedido
        Get
            Return m_pedido
        End Get
        Set(ByVal Value As frm_pedido)
            m_pedido = Value
        End Set
    End Property
    Private Shared m_pedido_mantenimiento As frm_pedido_mantenimiento
    Public Shared Property frm_pedido_mantenimiento() As frm_pedido_mantenimiento
        Get
            Return m_pedido_mantenimiento
        End Get
        Set(ByVal Value As frm_pedido_mantenimiento)
            m_pedido_mantenimiento = Value
        End Set
    End Property

    Private Shared m_inventario_mantenimiento As frm_inventario_mantenimiento
    Public Shared Property frm_inventario_mantenimiento() As frm_inventario_mantenimiento
        Get
            Return m_inventario_mantenimiento
        End Get
        Set(ByVal Value As frm_inventario_mantenimiento)
            m_inventario_mantenimiento = Value
        End Set
    End Property

    Private Shared m_rpt_puntos_estado_opciones As frm_rpt_Puntos_estado_opciones
    Public Shared Property frm_rpt_puntos_estado_opciones() As frm_rpt_Puntos_estado_opciones
        Get
            Return m_rpt_puntos_estado_opciones
        End Get
        Set(ByVal Value As frm_rpt_Puntos_estado_opciones)
            m_rpt_puntos_estado_opciones = Value
        End Set
    End Property

    Private Shared m_inventario As frm_inventario
    Public Shared Property frm_inventario() As frm_inventario
        Get
            Return m_inventario

        End Get
        Set(ByVal Value As frm_inventario)
            m_inventario = Value
        End Set
    End Property

    Private Shared m_devolucion As frm_devolucion
    Public Shared Property frm_devolucion() As frm_devolucion
        Get
            Return m_devolucion
        End Get
        Set(ByVal Value As frm_devolucion)
            m_devolucion = Value
        End Set
    End Property


    

    Private Shared m_recibo As frm_recibo
    Public Shared Property frm_recibo() As frm_recibo
        Get
            Return m_recibo
        End Get
        Set(ByVal Value As frm_recibo)
            m_recibo = Value
        End Set
    End Property

   

    Private Shared m_Bodega_ajuste_mantenimiento As frm_bodega_ajuste_mantenimiento
    Public Shared Property frm_Bodega_ajuste_mantenimiento() As frm_bodega_ajuste_mantenimiento
        Get
            Return m_Bodega_ajuste_mantenimiento
        End Get
        Set(ByVal Value As frm_bodega_ajuste_mantenimiento)
            m_Bodega_ajuste_mantenimiento = Value
        End Set
    End Property

    Private Shared m_frm_bodega_ajuste As frm_bodega_ajuste
    Public Shared Property frm_bodega_ajuste() As frm_bodega_ajuste
        Get
            Return m_frm_bodega_ajuste
        End Get
        Set(ByVal Value As frm_bodega_ajuste)
            m_frm_bodega_ajuste = Value
        End Set
    End Property

    Private Shared m_consulta_documento As frm_consulta_documento
    Public Shared Property frm_consulta_documento() As frm_consulta_documento
        Get
            Return m_consulta_documento
        End Get
        Set(ByVal Value As frm_consulta_documento)
            m_consulta_documento = Value
        End Set
    End Property

    Private Shared m_pedidos As frm_Pedidos
    Public Shared Property frm_pedidos() As frm_Pedidos
        Get
            Return m_pedidos
        End Get
        Set(ByVal Value As frm_Pedidos)
            m_pedidos = Value
        End Set
    End Property

    Private Shared m_cambio As frm_cambio
    Public Shared Property frm_cambio() As frm_cambio
        Get
            Return m_cambio
        End Get
        Set(ByVal Value As frm_Cambio)
            m_cambio = Value
        End Set
    End Property

    Private Shared m_Cambio_Mantenimiento As frm_Cambio_Mantenimiento
    Public Shared Property frm_Cambio_Mantenimiento() As frm_Cambio_Mantenimiento
        Get
            Return m_Cambio_Mantenimiento
        End Get
        Set(ByVal Value As frm_Cambio_Mantenimiento)
            m_Cambio_Mantenimiento = Value
        End Set
    End Property

    Private Shared m_Compra As frm_Compra
    Public Shared Property frm_Compra() As frm_Compra
        Get
            Return m_Compra
        End Get
        Set(ByVal Value As frm_Compra)
            m_Compra = Value
        End Set
    End Property

    Private Shared m_Compra_Mantenimiento As frm_Compra_Mantenimiento
    Public Shared Property frm_Compra_Mantenimiento() As frm_Compra_Mantenimiento
        Get
            Return m_Compra_Mantenimiento
        End Get
        Set(ByVal Value As frm_Compra_Mantenimiento)
            m_Compra_Mantenimiento = Value
        End Set
    End Property

    Private Shared m_rpt_producto_opciones As frm_rpt_producto_opciones
    Public Shared Property frm_rpt_producto_opciones() As frm_rpt_producto_opciones
        Get
            Return m_rpt_producto_opciones
        End Get
        Set(ByVal Value As frm_rpt_producto_opciones)
            m_rpt_producto_opciones = Value
        End Set
    End Property

    Private Shared m_rpt_venta_producto_cliente_opciones As frm_rpt_venta_producto_cliente_opciones
    Public Shared Property frm_rpt_venta_producto_cliente_opciones() As frm_rpt_venta_producto_cliente_opciones
        Get
            Return m_rpt_venta_producto_cliente_opciones
        End Get
        Set(ByVal Value As frm_rpt_venta_producto_cliente_opciones)
            m_rpt_venta_producto_cliente_opciones = Value
        End Set
    End Property

    Private Shared m_rpt_venta_neta_cliente_opciones As frm_rpt_venta_neta_cliente_opciones
    Public Shared Property frm_rpt_venta_neta_cliente_opciones() As frm_rpt_venta_neta_cliente_opciones
        Get
            Return m_rpt_venta_neta_cliente_opciones
        End Get
        Set(ByVal Value As frm_rpt_venta_neta_cliente_opciones)
            m_rpt_venta_neta_cliente_opciones = Value
        End Set
    End Property

    Private Shared m_puntos_debito As frm_puntos_debito
    Public Shared Property frm_puntos_debito() As frm_puntos_debito
        Get
            Return m_puntos_debito
        End Get
        Set(ByVal Value As frm_Puntos_Debito)
            m_puntos_debito = Value
        End Set
    End Property


    Private Shared m_rpt_venta_producto_opciones As frm_rpt_venta_producto_opciones
    Public Shared Property frm_rpt_venta_producto_opciones() As frm_rpt_venta_producto_opciones
        Get
            Return m_rpt_venta_producto_opciones
        End Get
        Set(ByVal Value As frm_rpt_venta_producto_opciones)
            m_rpt_venta_producto_opciones = Value
        End Set
    End Property

    Private Shared m_rpt_estado_opciones As frm_rpt_estado_opciones
    Public Shared Property frm_rpt_estado_opciones() As frm_rpt_estado_opciones
        Get
            Return m_rpt_estado_opciones
        End Get
        Set(ByVal Value As frm_rpt_estado_opciones)
            m_rpt_estado_opciones = Value
        End Set
    End Property

    Private Shared m_rpt_credito_vencido_opciones As frm_rpt_credito_vencido_opciones
    Public Shared Property frm_rpt_credito_vencido_opciones() As frm_rpt_credito_vencido_opciones
        Get
            Return m_rpt_credito_vencido_opciones
        End Get
        Set(ByVal Value As frm_rpt_credito_vencido_opciones)
            m_rpt_credito_vencido_opciones = Value
        End Set
    End Property

    Private Shared m_rpt_cuentasxcobrar As frm_rpt_cuentasxcobrar
    Public Shared Property frm_rpt_cuentasxcobrar() As frm_rpt_cuentasxcobrar
        Get
            Return m_rpt_cuentasxcobrar
        End Get
        Set(ByVal Value As frm_rpt_cuentasxcobrar)
            m_rpt_cuentasxcobrar = Value
        End Set
    End Property

    Private Shared m_nota_credito As frm_Nota_Credito
    Public Shared Property frm_nota_credito() As frm_Nota_Credito
        Get
            Return m_nota_credito
        End Get
        Set(ByVal Value As frm_Nota_Credito)
            m_nota_credito = Value
        End Set
    End Property

   
End Class