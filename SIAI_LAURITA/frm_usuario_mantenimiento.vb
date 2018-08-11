Public Class frm_usuario_mantenimiento
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtclave2 As System.Windows.Forms.TextBox
    Friend WithEvents txtclave1 As System.Windows.Forms.TextBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtobservaciones As System.Windows.Forms.TextBox
    Friend WithEvents cbnivel As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Contraseña As System.Windows.Forms.Label
    Friend WithEvents Nombre As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents pbnombre_real As System.Windows.Forms.PictureBox
    Friend WithEvents txtnombre_real As System.Windows.Forms.TextBox
    Friend WithEvents pbclave2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbclave1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbid_usuario As System.Windows.Forms.PictureBox
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_usuario_mantenimiento))
        Me.lbltitulo = New System.Windows.Forms.Label
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pbclave2 = New System.Windows.Forms.PictureBox
        Me.pbclave1 = New System.Windows.Forms.PictureBox
        Me.pbid_usuario = New System.Windows.Forms.PictureBox
        Me.txtnombre_real = New System.Windows.Forms.TextBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.pbnombre_real = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtclave2 = New System.Windows.Forms.TextBox
        Me.txtclave1 = New System.Windows.Forms.TextBox
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtobservaciones = New System.Windows.Forms.TextBox
        Me.cbnivel = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Contraseña = New System.Windows.Forms.Label
        Me.Nombre = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.pbclave2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbclave1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbid_usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbnombre_real, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltitulo
        '
        Me.lbltitulo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbltitulo.Location = New System.Drawing.Point(0, 0)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(572, 24)
        Me.lbltitulo.TabIndex = 13
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btncancelar
        '
        Me.btncancelar.Image = CType(resources.GetObject("btncancelar.Image"), System.Drawing.Image)
        Me.btncancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancelar.Location = New System.Drawing.Point(296, 289)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(88, 32)
        Me.btncancelar.TabIndex = 7
        Me.btncancelar.Text = "Cancelar"
        Me.ToolTip1.SetToolTip(Me.btncancelar, "No Guardar los Datos")
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Image = CType(resources.GetObject("btnaceptar.Image"), System.Drawing.Image)
        Me.btnaceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaceptar.Location = New System.Drawing.Point(202, 289)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(88, 32)
        Me.btnaceptar.TabIndex = 6
        Me.btnaceptar.Text = "Aceptar"
        Me.ToolTip1.SetToolTip(Me.btnaceptar, "Guardar los Datos")
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.pbclave2)
        Me.Panel1.Controls.Add(Me.pbclave1)
        Me.Panel1.Controls.Add(Me.pbid_usuario)
        Me.Panel1.Controls.Add(Me.txtnombre_real)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.pbnombre_real)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtclave2)
        Me.Panel1.Controls.Add(Me.txtclave1)
        Me.Panel1.Controls.Add(Me.txtnombre)
        Me.Panel1.Controls.Add(Me.txtobservaciones)
        Me.Panel1.Controls.Add(Me.cbnivel)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Contraseña)
        Me.Panel1.Controls.Add(Me.Nombre)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Location = New System.Drawing.Point(12, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(555, 246)
        Me.Panel1.TabIndex = 0
        '
        'pbclave2
        '
        Me.pbclave2.Image = CType(resources.GetObject("pbclave2.Image"), System.Drawing.Image)
        Me.pbclave2.Location = New System.Drawing.Point(245, 119)
        Me.pbclave2.Name = "pbclave2"
        Me.pbclave2.Size = New System.Drawing.Size(12, 12)
        Me.pbclave2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbclave2.TabIndex = 71
        Me.pbclave2.TabStop = False
        Me.pbclave2.Visible = False
        '
        'pbclave1
        '
        Me.pbclave1.Image = CType(resources.GetObject("pbclave1.Image"), System.Drawing.Image)
        Me.pbclave1.Location = New System.Drawing.Point(245, 85)
        Me.pbclave1.Name = "pbclave1"
        Me.pbclave1.Size = New System.Drawing.Size(12, 12)
        Me.pbclave1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbclave1.TabIndex = 70
        Me.pbclave1.TabStop = False
        Me.pbclave1.Visible = False
        '
        'pbid_usuario
        '
        Me.pbid_usuario.Image = CType(resources.GetObject("pbid_usuario.Image"), System.Drawing.Image)
        Me.pbid_usuario.Location = New System.Drawing.Point(269, 19)
        Me.pbid_usuario.Name = "pbid_usuario"
        Me.pbid_usuario.Size = New System.Drawing.Size(12, 12)
        Me.pbid_usuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbid_usuario.TabIndex = 69
        Me.pbid_usuario.TabStop = False
        Me.pbid_usuario.Visible = False
        '
        'txtnombre_real
        '
        Me.txtnombre_real.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre_real.Location = New System.Drawing.Point(133, 42)
        Me.txtnombre_real.MaxLength = 35
        Me.txtnombre_real.Name = "txtnombre_real"
        Me.txtnombre_real.Size = New System.Drawing.Size(328, 26)
        Me.txtnombre_real.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtnombre_real, "Escriba el nombre real del usuario")
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(471, 50)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 40
        Me.PictureBox5.TabStop = False
        '
        'pbnombre_real
        '
        Me.pbnombre_real.Image = CType(resources.GetObject("pbnombre_real.Image"), System.Drawing.Image)
        Me.pbnombre_real.Location = New System.Drawing.Point(467, 50)
        Me.pbnombre_real.Name = "pbnombre_real"
        Me.pbnombre_real.Size = New System.Drawing.Size(12, 12)
        Me.pbnombre_real.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbnombre_real.TabIndex = 39
        Me.pbnombre_real.TabStop = False
        Me.pbnombre_real.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 27)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Nombre Real"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtclave2
        '
        Me.txtclave2.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtclave2.Location = New System.Drawing.Point(133, 109)
        Me.txtclave2.MaxLength = 10
        Me.txtclave2.Name = "txtclave2"
        Me.txtclave2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(119)
        Me.txtclave2.Size = New System.Drawing.Size(106, 25)
        Me.txtclave2.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtclave2, "Escriba de nuevo la contraseña del usuario")
        '
        'txtclave1
        '
        Me.txtclave1.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtclave1.Location = New System.Drawing.Point(133, 73)
        Me.txtclave1.MaxLength = 10
        Me.txtclave1.Name = "txtclave1"
        Me.txtclave1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(119)
        Me.txtclave1.Size = New System.Drawing.Size(106, 25)
        Me.txtclave1.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtclave1, "Escriba la contraseña del usuario")
        '
        'txtnombre
        '
        Me.txtnombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(133, 9)
        Me.txtnombre.MaxLength = 12
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(128, 26)
        Me.txtnombre.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtnombre, "Escriba el nombre del usuario")
        '
        'txtobservaciones
        '
        Me.txtobservaciones.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtobservaciones.Location = New System.Drawing.Point(133, 189)
        Me.txtobservaciones.MaxLength = 50
        Me.txtobservaciones.Multiline = True
        Me.txtobservaciones.Name = "txtobservaciones"
        Me.txtobservaciones.Size = New System.Drawing.Size(392, 39)
        Me.txtobservaciones.TabIndex = 5
        '
        'cbnivel
        '
        Me.cbnivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbnivel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbnivel.ItemHeight = 18
        Me.cbnivel.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbnivel.Location = New System.Drawing.Point(133, 147)
        Me.cbnivel.Name = "cbnivel"
        Me.cbnivel.Size = New System.Drawing.Size(57, 26)
        Me.cbnivel.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cbnivel, "Seleccione el nivel de seguridad del usuario")
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 28)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Nivel"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(245, 119)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 32
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 24)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Observaciones"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Confirmación"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Contraseña
        '
        Me.Contraseña.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contraseña.Location = New System.Drawing.Point(13, 73)
        Me.Contraseña.Name = "Contraseña"
        Me.Contraseña.Size = New System.Drawing.Size(96, 24)
        Me.Contraseña.TabIndex = 26
        Me.Contraseña.Text = "Contraseña"
        Me.Contraseña.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Nombre
        '
        Me.Nombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(13, 11)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(72, 16)
        Me.Nombre.TabIndex = 24
        Me.Nombre.Text = "Usuario"
        Me.Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(269, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 31
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(245, 85)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 33
        Me.PictureBox2.TabStop = False
        '
        'frm_usuario_mantenimiento
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(581, 333)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.lbltitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_usuario_mantenimiento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Usuarios"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbclave2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbclave1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbid_usuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbnombre_real, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private ReadOnly key() As Byte = _
                     {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, _
                     15, 16, 17, 18, 19, 20, 21, 22, 23, 24}
    Private ReadOnly iv() As Byte = {8, 7, 6, 5, 4, 3, 2, 1}

    ' instantiate the class with the arrays
    Private TripleDES As New TripleDES(key, iv)


    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Try
            Dim Fi As Boolean = False
            If txtnombre.Text = "" Then
                pbid_usuario.Visible = True
                Fi = True
            Else
                pbid_usuario.Visible = False
            End If
            If txtnombre_real.Text = "" Then
                pbnombre_real.Visible = True
                Fi = True
            Else
                pbnombre_real.Visible = False
            End If
            If txtclave1.Text = "" Then
                pbclave1.Visible = True
                Fi = True
            Else
                pbclave1.Visible = False
            End If
            If txtclave2.Text = "" Then
                pbclave2.Visible = True
                Fi = True
            Else
                pbclave2.Visible = False
            End If
            If Fi Then
                MessageBox.Show("Hay campos requeridos sin completar", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If txtclave1.Text <> txtclave2.Text Then
                MessageBox.Show("La contraseña debe ser igual a la confirmación", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                pbclave1.Visible = True
                pbclave2.Visible = True
            End If

            If txtclave1.Text.Length < 6 Then
                MessageBox.Show("La contraseña debe ser Mínimo de 6 Caracteres", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtclave1.Focus()
                SendKeys.Send("{home}+{end}")
                Exit Sub
                pbclave1.Visible = True
                pbclave2.Visible = True
            End If

            With myForms.frm_datos_mantenimiento

                Dim r As DataRow = TS(.Dsusuario.Tables(0), "nombre", txtnombre.Text)
                If Not (r Is Nothing) Then
                    If (lbltitulo.Text = "Incluir Usuario") Or (lbltitulo.Text <> "Incluir Usuario" And .dtgusuario.Item("dtguid", .dtgusuario.CurrentRow.Index).Value <> r("id_usuario")) Then
                        MessageBox.Show("Nombre de Usuario Ya Existe", "Mantenimiento usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtnombre.Focus()
                        SendKeys.Send("{home}+{end}")
                        Exit Sub
                    End If
                End If

                If lbltitulo.Text = "Incluir Usuario" Then
                    .rowu = .Dvusuario.Table.NewRow()
                End If


                .rowu("nombre") = txtnombre.Text
                .rowu("nivel") = cbnivel.SelectedIndex + 1
                .rowu("clave") = TripleDES.Encrypt(txtclave1.Text)
                .rowu("observaciones") = IIf(txtobservaciones.Text = "", "", txtobservaciones.Text)
                .rowu("nombre_real") = txtnombre_real.Text
                If lbltitulo.Text = "Incluir Usuario" Then .Dvusuario.Table.Rows.Add(.rowu)
                .Dausuario.Update(.Dsusuario, "usuario")
            End With
            Me.Close()
        Catch myerror As Exception
            ONEX(Me.Name, myerror)
        End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub txtnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtclave1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtclave1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtclave2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtclave2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbnivel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbnivel.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtobservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtobservaciones.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            btnaceptar.Focus()
        End If
    End Sub

    Private Sub txtnombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnombre.TextChanged

    End Sub

    Private Sub txtnombre_real_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre_real.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtnombre_real_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnombre_real.TextChanged

    End Sub

    Private Sub txtclave1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtclave1.TextChanged

    End Sub
End Class
