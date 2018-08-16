Imports System
Imports System.IO
Imports ProtoBuf

Public Class DatProto
    <ProtoContract>
    Class Light
        <ProtoMember(1)>
        Public Property Brightness As UInt32 = 1
        <ProtoMember(2)>
        Public Property Color As UInt32 = 2
    End Class
    <ProtoContract>
    Class Elevation
        <ProtoMember(1)>
        Public Property X As UInt32 = 1
        <ProtoMember(2)>
        Public Property Y As UInt32 = 2
    End Class
    <ProtoContract>
    Class Height
        <ProtoMember(1)>
        Public Property Elevation As UInt32 = 1
    End Class
    <ProtoContract>
    Class Minimap
        <ProtoMember(1)>
        Public Property Color As UInt32 = 1
    End Class
    <ProtoContract>
    Class LensHelp
        <ProtoMember(1)>
        Public Property Id As UInt32 = 1
    End Class
    <ProtoContract>
    Class Clothes
        <ProtoMember(1)>
        Public Property Slot As UInt32 = 1
    End Class
    <ProtoContract>
    Class DefaultAction

        Public Enum PLAYER_ACTION
            PLAYER_ACTION_NONE = 0
            PLAYER_ACTION_LOOK = 1
            PLAYER_ACTION_USE = 2
            PLAYER_ACTION_OPEN = 3
            PLAYER_ACTION_AUTOWALK_HIGHLIGHT = 4
        End Enum
        Public Property Action As DefaultAction.PLAYER_ACTION = 1
    End Class
    <ProtoContract>
    Class Market
        <ProtoMember(1)>
        Public Property Category As UInt32 = 1
        <ProtoMember(2)>
        Public Property TradeAs As UInt32 = 2
        <ProtoMember(3)>
        Public Property ShowAs As UInt32 = 3
        <ProtoMember(4)>
        Public Property Name As String = 4
        <ProtoMember(5)>
        Public Property Vocation As UInt32 = 5
        <ProtoMember(6)>
        Public Property Level As UInt32 = 6 'def 0
    End Class
    <ProtoContract>
    Class FrameGroup
        <ProtoMember(1)>
        Public Property FixedFrameGroup As UInt32 = 1 ' ?
        <ProtoMember(2)>
        Public Property Id As UInt32 = 2 ' ?
        <ProtoMember(3)>
        Public Property SpriteInfo_ As SpriteInfo

        Class SpriteInfo
            <ProtoMember(1)>
            Public Property PatternX As UInt32 = 1
            <ProtoMember(2)>
            Public Property PatternY As UInt32 = 2
            <ProtoMember(3)>
            Public Property PatternZ As UInt32 = 3
            <ProtoMember(4)>
            Public Property Layers As UInt32 = 4
            <ProtoMember(5)>
            Public Property SpriteIDs As UInt32 = 5
            <ProtoMember(6)>
            Public Property Animations As SpriteAnimation
            <ProtoMember(7)>
            Public Property CropSize As UInt32 = 7
            <ProtoMember(8)>
            Public Property IsOpaque As Boolean = 8
            <ProtoMember(9)>
            Public Property Size As Size  ' size does Not seem To appear at all

            Class SpriteAnimation
                Public Enum ANIMATION_LOOP_TYPE
                    ANIMATION_LOOP_TYPE_PINGPONG = -1
                    ANIMATION_LOOP_TYPE_INFINITE = 0
                    ANIMATION_LOOP_TYPE_COUNTED = 1
                End Enum
            End Class
            <ProtoMember(1)>
            Public Property StartPhase As UInt32 = 1
            <ProtoMember(2)>
            Public Property Synced As Boolean = 2
            <ProtoMember(3)>
            Public Property RandomStartPhase As Boolean = 3 ' default=False]
            <ProtoMember(4)>
            Public Property LoopType As SpriteAnimation.ANIMATION_LOOP_TYPE = 4
            <ProtoMember(5)>
            Public Property LoopCount As UInt32 = 5
            <ProtoMember(6)>
            Public Property Phases As SpritePhase

            Class SpritePhase
                <ProtoMember(1)>
                Public Property MinDuration As UInt32 = 1
                <ProtoMember(2)>
                Public Property MaxDuration As UInt32 = 2
            End Class
        End Class

        Class Size
            <ProtoMember(1)>
            Public Property Width As UInt32 = 1
            <ProtoMember(2)>
            Public Property Height As UInt32 = 2
        End Class
    End Class
    <ProtoContract>
    Class Appearance
        <ProtoMember(1)>
        Public Property ClientID As UInt32 = 1
        <ProtoMember(2)>
        Public Property FrameGroups As FrameGroup
        <ProtoMember(3)>
        Public Property Attributes As DatProto.Attributes
    End Class
    <ProtoContract>
    Class DatFile
        <ProtoMember(1)>
        Public Property Objects As Appearance
        <ProtoMember(2)>
        Public Property Outfits As Appearance
        <ProtoMember(3)>
        Public Property Effects As Appearance
        <ProtoMember(4)>
        Public Property Missiles As Appearance
    End Class
    <ProtoContract>
    Class Attributes
        <ProtoMember(1)>
        Public Property Ground_ As Ground
        <ProtoMember(2)>
        Public Property GroundBorder As Boolean = 2
        <ProtoMember(3)>
        Public Property Bottom As Boolean = 3
        <ProtoMember(4)>
        Public Property Top As Boolean = 4
        <ProtoMember(5)>
        Public Property Container As Boolean = 5
        <ProtoMember(6)>
        Public Property Stackable As Boolean = 6
        <ProtoMember(7)>
        Public Property Use As Boolean = 7
        <ProtoMember(8)>
        Public Property ForceUse As Boolean = 8
        <ProtoMember(9)>
        Public Property MultiUse As Boolean = 9
        <ProtoMember(10)>
        Public Property Writable_ As Writable
        <ProtoMember(11)>
        Public Property WritableOnce_ As WritableOnce
        <ProtoMember(12)>
        Public Property Splash As Boolean = 12
        <ProtoMember(13)>
        Public Property Unwalkable As Boolean = 13
        <ProtoMember(14)>
        Public Property Unmovable As Boolean = 14
        <ProtoMember(15)>
        Public Property Unsight As Boolean = 15
        <ProtoMember(16)>
        Public Property BlockPath As Boolean = 16
        <ProtoMember(17)>
        Public Property NoMoveAnimation As Boolean = 17
        <ProtoMember(18)>
        Public Property Pickupable As Boolean = 18
        <ProtoMember(19)>
        Public Property FluidContainer As Boolean = 19
        <ProtoMember(20)>
        Public Property Hangable As Boolean = 20
        <ProtoMember(21)>
        Public Property Hook_ As Hook
        <ProtoMember(22)>
        Public Property Rotatable As Boolean = 22
        <ProtoMember(23)>
        Public Property Light_ As Light
        <ProtoMember(24)>
        Public Property DontHide As Boolean = 24
        <ProtoMember(25)>
        Public Property Translucent As Boolean = 25
        <ProtoMember(26)>
        Public Property Elevation_ As Elevation
        <ProtoMember(27)>
        Public Property Height_ As Height
        <ProtoMember(27)>
        Public Property LyingObject As Boolean = 28
        <ProtoMember(29)>
        Public Property AlwaysAnimated As Boolean = 29
        <ProtoMember(30)>
        Public Property MinimapColor As Minimap
        <ProtoMember(31)>
        Public Property LenshelpType As LensHelp
        <ProtoMember(32)>
        Public Property FullGround As Boolean = 32
        <ProtoMember(33)>
        Public Property IgnoreLook As Boolean = 33
        <ProtoMember(34)>
        Public Property Cloth As Clothes
        <ProtoMember(35)>
        Public Property DefaultAction_ As DefaultAction
        <ProtoMember(36)>
        Public Property MarketData As Market
        <ProtoMember(37)>
        Public Property Wrappable As Boolean = 37
        <ProtoMember(38)>
        Public Property Unwrappable As Boolean = 38
        <ProtoMember(39)>
        Public Property Topeffect As Boolean = 39

        Class Ground
            <ProtoMember(1)>
            Public Property Speed As UInt32 = 1
        End Class
        Class Writable
            <ProtoMember(1)>
            Public Property Length As UInt32 = 1
        End Class
        Class WritableOnce
            <ProtoMember(1)>
            Public Property Length As UInt32 = 1
        End Class
        Class Hook
            Public Enum HOOK_TYPE
                HOOK_SOUTH = 1
                HOOK_EAST = 2
            End Enum
        End Class
        <ProtoMember(1)>
        Public Property Direction As Hook.HOOK_TYPE = 1
    End Class

    'saving/loading
    Public Sub Writefile(filename As String)
        Dim fs As FileStream = File.Create(filename)
        ''option 1
        'Dim objData As Appearance = New Appearance With {.ClientID = "blahblahblah"}
        'Serializer.Serialize(fs, objData) 'saving

        ''option 2
        Dim objData1 As DatFile = New DatFile
        Serializer.Serialize(fs, objData1)
    End Sub
    Public Sub Readfile(filename As String)
        Dim fs As FileStream = File.Open(filename, FileMode.Open)
        Dim objData1 = Serializer.Deserialize(Of DatFile)(fs) 'loading

    End Sub
End Class
