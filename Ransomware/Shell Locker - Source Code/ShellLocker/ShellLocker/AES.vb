﻿Imports System
Imports System.Diagnostics
Imports System.Security.Cryptography
Public Class AES
    Public Class AES
        <DebuggerNonUserCode()>
        Public Sub New()
        End Sub

        Public Shared Function decrypt(byte_ciphertext As Byte(), key As Byte()) As Byte()
            Dim cryptoTransform As ICryptoTransform = New RijndaelManaged() With {.KeySize = 256}.CreateDecryptor(key, key)
            Return cryptoTransform.TransformFinalBlock(byte_ciphertext, 0, byte_ciphertext.Length)
        End Function

        Public Shared Function encrypt(data As Byte(), key As Byte()) As Byte()
            Dim cryptoTransform As ICryptoTransform = New RijndaelManaged() With {.KeySize = 256}.CreateEncryptor(key, key)
            Return cryptoTransform.TransformFinalBlock(data, 0, data.Length)
        End Function

        Public Shared Function generateKey() As Byte()
            Dim rijndaelManaged As RijndaelManaged = New RijndaelManaged()
            rijndaelManaged.KeySize = 256
            rijndaelManaged.GenerateKey()
            Return rijndaelManaged.Key
        End Function
    End Class
End Class
