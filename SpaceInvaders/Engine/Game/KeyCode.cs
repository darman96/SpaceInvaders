namespace SpaceInvaders.Engine.Game;

public enum KeyCode
{
    Unknown = 0,
    
    // -- Numbers --
    Number_0 = 48, // 0x00000030
    Number_1 = 49, // 0x00000031
    Number_2 = 50, // 0x00000032
    Number_3 = 51, // 0x00000033
    Number_4 = 52, // 0x00000034
    Number_5 = 53, // 0x00000035
    Number_6 = 54, // 0x00000036
    Number_7 = 55, // 0x00000037
    Number_8 = 56, // 0x00000038
    Number_9 = 57, // 0x00000039
    
    // -- Letters --
    A = 97, // 0x00000061
    B = 98, // 0x00000062
    C = 99, // 0x00000063
    D = 100, // 0x00000064
    E = 101, // 0x00000065
    F = 102, // 0x00000066
    G = 103, // 0x00000067
    H = 104, // 0x00000068
    I = 105, // 0x00000069
    J = 106, // 0x0000006A
    K = 107, // 0x0000006B
    L = 108, // 0x0000006C
    M = 109, // 0x0000006D
    N = 110, // 0x0000006E
    O = 111, // 0x0000006F
    P = 112, // 0x00000070
    Q = 113, // 0x00000071
    R = 114, // 0x00000072
    S = 115, // 0x00000073
    T = 116, // 0x00000074
    U = 117, // 0x00000075
    V = 118, // 0x00000076
    W = 119, // 0x00000077
    X = 120, // 0x00000078
    Y = 121, // 0x00000079
    Z = 122, // 0x0000007A
    
    // -- Modifiers --
    LeftCtrl = 1073742048, // 0x400000E0
    LeftShift = 1073742049, // 0x400000E1
    LeftAlt = 1073742050, // 0x400000E2
    RightCtrl = 1073742052, // 0x400000E4
    RightShift = 1073742053, // 0x400000E5
    RightAlt = 1073742054, // 0x400000E6
    SDLK_LGUI = 1073742051, // 0x400000E3
    
    // -- Function keys --
    F1 = 1073741882, // 0x4000003A
    F2 = 1073741883, // 0x4000003B
    F3 = 1073741884, // 0x4000003C
    F4 = 1073741885, // 0x4000003D
    F5 = 1073741886, // 0x4000003E
    F6 = 1073741887, // 0x4000003F
    F7 = 1073741888, // 0x40000040
    F8 = 1073741889, // 0x40000041
    F9 = 1073741890, // 0x40000042
    F10 = 1073741891, // 0x40000043
    F11 = 1073741892, // 0x40000044
    F12 = 1073741893, // 0x40000045

    // -- Misc --
    Backspace = 8,
    Tab = 9,
    Return = 13, // 0x0000000D
    Escape = 27, // 0x0000001B
    Space = 32, // 0x00000020
    Delete = 127, // 0x0000007F
    Capslock = 1073741881, // 0x40000039
    Print = 1073741894, // 0x40000046
    Scroll = 1073741895, // 0x40000047
    Pause = 1073741896, // 0x40000048
    Insert = 1073741897, // 0x40000049
    Home = 1073741898, // 0x4000004A
    PageUp = 1073741899, // 0x4000004B
    End = 1073741901, // 0x4000004D
    PageDown = 1073741902, // 0x4000004E
    Right = 1073741903, // 0x4000004F
    Left = 1073741904, // 0x40000050
    Down = 1073741905, // 0x40000051
    Up = 1073741906, // 0x40000052
    
    SDLK_EXCLAIM = 33, // 0x00000021
    SDLK_QUOTEDBL = 34, // 0x00000022
    SDLK_HASH = 35, // 0x00000023
    SDLK_DOLLAR = 36, // 0x00000024
    SDLK_PERCENT = 37, // 0x00000025
    SDLK_AMPERSAND = 38, // 0x00000026
    SDLK_QUOTE = 39, // 0x00000027
    SDLK_LEFTPAREN = 40, // 0x00000028
    SDLK_RIGHTPAREN = 41, // 0x00000029
    SDLK_ASTERISK = 42, // 0x0000002A
    SDLK_PLUS = 43, // 0x0000002B
    SDLK_COMMA = 44, // 0x0000002C
    SDLK_MINUS = 45, // 0x0000002D
    SDLK_PERIOD = 46, // 0x0000002E
    SDLK_SLASH = 47, // 0x0000002F
    SDLK_COLON = 58, // 0x0000003A
    SDLK_SEMICOLON = 59, // 0x0000003B
    SDLK_LESS = 60, // 0x0000003C
    SDLK_EQUALS = 61, // 0x0000003D
    SDLK_GREATER = 62, // 0x0000003E
    SDLK_QUESTION = 63, // 0x0000003F
    SDLK_AT = 64, // 0x00000040
    SDLK_LEFTBRACKET = 91, // 0x0000005B
    SDLK_BACKSLASH = 92, // 0x0000005C
    SDLK_RIGHTBRACKET = 93, // 0x0000005D
    SDLK_CARET = 94, // 0x0000005E
    SDLK_UNDERSCORE = 95, // 0x0000005F
    SDLK_BACKQUOTE = 96, // 0x00000060

    // -- Numpad --
    NumLock = 1073741907, // 0x40000053
    NumPadDivide = 1073741908, // 0x40000054
    NumPadMultiply = 1073741909, // 0x40000055
    NumPadMinus = 1073741910, // 0x40000056
    NumPadPlus = 1073741911, // 0x40000057
    NumPadEnter = 1073741912, // 0x40000058
    NumPad_1 = 1073741913, // 0x40000059
    NumPad_2 = 1073741914, // 0x4000005A
    NumPad_3 = 1073741915, // 0x4000005B
    NumPad_4 = 1073741916, // 0x4000005C
    NumPad_5 = 1073741917, // 0x4000005D
    NumPad_6 = 1073741918, // 0x4000005E
    NumPad_7 = 1073741919, // 0x4000005F
    NumPad_8 = 1073741920, // 0x40000060
    NumPad_9 = 1073741921, // 0x40000061
    NumPad_0 = 1073741922, // 0x40000062
}