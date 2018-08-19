Public Enum ItemFlag As Byte

    Ground = &H0
    GroundBorder = &H1
    OnBottom = &H2
    OnTop = &H3
    Container = &H4
    Stackable = &H5
    ForceUse = &H6
    MultiUse = &H7
    Writable = &H8
    WritableOnce = &H9
    FluidContainer = &HA
    Fluid = &HB
    IsUnpassable = &HC
    IsUnmoveable = &HD
    BlockMissiles = &HE
    BlockPathfinder = &HF
    NoMoveAnimation = &H10
    Pickupable = &H11
    Hangable = &H12
    IsHorizontal = &H13
    IsVertical = &H14
    Rotatable = &H15
    HasLight = &H16
    DontHide = &H17
    Translucent = &H18
    HasOffset = &H19
    HasElevation = &H1A
    Lying = &H1B
    AnimateAlways = &H1C
    Minimap = &H1D
    LensHelp = &H1E
    FullGround = &H1F
    IgnoreLook = &H20
    Cloth = &H21
    Market = &H22
    DefaultAction = &H23
    Wrappable = &H24
    Unwrappable = &H25
    TopEffect = &H26
    Usable = &HFE
    LastFlag = &HFF
    Border = &H27
    unknown = &HA3
End Enum
Public Enum TileStackOrder As Byte

    None = 0
    Border = 1
    Bottom = 2
    Top = 3
End Enum
Public Enum ServerItemType As Byte

    None = 0
    Ground = 1
    Container = 2
    Fluid = 3
    Splash = 4
    Deprecated = 5
End Enum
Public Enum ServerItemGroup As Byte

    None = 0
    Ground = 1
    Container = 2
    Weapon = 3
    Ammunition = 4
    Armor = 5
    Changes = 6
    Teleport = 7
    MagicField = 8
    Writable = 9
    Key = 10
    Splash = 11
    Fluid = 12
    Door = 13
    Deprecated = 14
End Enum
