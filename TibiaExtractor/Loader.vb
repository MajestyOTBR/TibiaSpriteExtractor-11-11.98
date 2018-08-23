Imports OpenTibia.Core
Imports OpenTibia.Geom
Imports OpenTibia.Obd
Imports OpenTibia.Utils
Imports OpenTibia.Collections
Imports OpenTibia.Utilities
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Linq
Imports OpenTibia
Imports OpenTibia.Client.Things
Imports OpenTibia.Client.Sprites
Imports OpenTibia.Client
Imports System.IO

Public Class Loader
    Private Ver As Core.Version
    Private Dat As New ThingTypeStorage
    Private Spr As New SpriteStorage
    Public Property SpriteCache As New Object
    Dim oc As IClient
    Public Property Version() As Core.Version
        Get
            Return Ver
        End Get
        Set(value As Core.Version)
            Ver = value
        End Set
    End Property
    Public Property Data() As ThingTypeStorage
        Get
            Return Dat
        End Get
        Set(value As ThingTypeStorage)
            Dat = value
        End Set
    End Property
    Public Property SSprt() As SpriteStorage
        Get
            Return Spr
        End Get
        Set(value As SpriteStorage)
            Spr = value
        End Set
    End Property

    Public Sub New()
        SpriteCache = New SpriteCache()
        Version = Nothing
        Dat = New ThingTypeStorage()
        Spr = New SpriteStorage()
        oc = New ClientImpl()
    End Sub
    Public Function LoadVersion(path As String, feats As ClientFeatures) As Core.Version
        Dim stream As System.IO.FileStream = New System.IO.FileStream(path + "\Tibia.dat", System.IO.FileMode.OpenOrCreate)
        Dim reader As System.IO.BinaryReader = New System.IO.BinaryReader(stream)
        Dim sig = reader.ReadUInt32()
        reader.Close()
        reader.Dispose()
        stream.Dispose()
        Dim ver = DetermineVersion(sig)
        Return ver
    End Function
    Public Function LoadOc(path As String) As Boolean
        Dim stream As System.IO.FileStream = New System.IO.FileStream(path + "\Tibia.dat", System.IO.FileMode.OpenOrCreate)
        Dim reader As System.IO.BinaryReader = New System.IO.BinaryReader(stream)
        Dim sig = reader.ReadUInt32()
        reader.Close()
        reader.Dispose()
        Version = DetermineVersion(sig)
        If (oc.Load(path + "\Tibia.dat", path + "\Tibia.spr", Version) = True) Then
            Data = oc.Things
            SSprt = oc.Sprites
            Return True
        End If
        Return False
    End Function
    Public Function Load(path As String, feats As ClientFeatures) As Boolean
        Try
            Dim stream As System.IO.FileStream = New System.IO.FileStream(path + "\Tibia.dat", System.IO.FileMode.OpenOrCreate)
            Dim reader As System.IO.BinaryReader = New System.IO.BinaryReader(stream)
            Dim sig = reader.ReadUInt32()
            reader.Close()
            reader.Dispose()
            Version = DetermineVersion(sig)
            Data = ThingTypeStorage.Load(path + "\Tibia.dat", Version, feats)
            SSprt = SpriteStorage.Load(path + "\Tibia.spr", Version, feats)
            oc.Load(path + "\Tibia.dat", path + "\Tibia.spr", Version)
            If ((IsNothing(Data)) And (IsNothing(SSprt))) Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function
    Public Function DetermineVersion(signature As UInt32) As Core.Version
        Dim DatVersionHex = Hex(signature)
        Dim Datver = CUInt("&H" + DatVersionHex)
        Select Case Datver
            Case &H38DE
                Return New Core.Version(1077, &H38DE, &H5525213D, 0)'1077
            Case &H42A3
                Return New Core.Version(1098, &H42A3, &H57BBD603, 0)'1098
            Case &H4A10
                Return New Core.Version(1000, &H4A10, &H59E48E02, 0) '1000
            Case Else
                MessageBox.Show("Client not supported")
        End Select
        Return Nothing
    End Function
    Public Sub Save(data As Client.Things.ThingTypeStorage, sprite As Client.Sprites.SpriteStorage, path As String)
        Try

            If (SSprt.Save(path + "\Tibia.spr", Version, Client.ClientFeatures.None) = True) Then
                MessageBox.Show("Spr was saved")
            End If
            If (data.Save(path + "\Tibia.dat", Version, Client.ClientFeatures.None) = True) Then
                MessageBox.Show("Dat was saved")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Public Sub Save(path As String)
        Try

            If (SSprt.Save(path + "\Tibia.spr", Version) = True) Then
                MessageBox.Show("Spr was saved")
            End If

            If (Data.Save(path + "Tibia.dat", Version) = True) Then
                MessageBox.Show("Dat was saved")
            End If

            MessageBox.Show("done")
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Public Sub SaveOc(path As String)
        Try

            oc.Save(CurDir() + "\extracted\Tibia.spr", CurDir() + "\extracted\Tibia.dat", Version)
            MessageBox.Show("done")
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Public Function OcAdd(Thingy As Client.Things.ThingType, sprit As Client.Sprites.Sprite) As Boolean

        If (oc.Sprites.AddSprite(sprit) And oc.Things.AddThing(Thingy)) = True Then
            Return True
        End If
        Return False
    End Function
    Public Function AddSprite(sprit As Client.Sprites.Sprite) As Boolean
        If SSprt.AddSprite(sprit) Then
            Return True
        End If
        Return False
    End Function
    Public Function AddDat(Thingy As Client.Things.ThingType) As Boolean
        If Data.AddThing(Thingy) Then
            Return True
        End If
        Return False
    End Function
    Public Function AddDatandSprit(Thingy As Client.Things.ThingType, sprit As Client.Sprites.Sprite) As Boolean
        If (Data.AddThing(Thingy) And SSprt.AddSprite(sprit)) = True Then
            Return True
        End If
        Return False
    End Function
    Public Sub ChangeVersion(value As Core.Version)
        Version = value
    End Sub

End Class
