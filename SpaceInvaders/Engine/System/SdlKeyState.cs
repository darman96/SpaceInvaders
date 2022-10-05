using System.Runtime.InteropServices;
using SDL2;
using SpaceInvaders.Engine.Game;

namespace SpaceInvaders.Engine.System;

public class SdlKeyState : IKeyState
{
    private byte[] keys;

    public SdlKeyState()
    {
        var keyStatePointer = SDL.SDL_GetKeyboardState(out var keyCount);
        this.keys = new byte[keyCount];
        Marshal.Copy(keyStatePointer, this.keys, 0, keyCount);
    }

    public void Update()
    {
        var keyStatePointer = SDL.SDL_GetKeyboardState(out var keyCount);
        this.keys = new byte[keyCount];
        Marshal.Copy(keyStatePointer, this.keys, 0, keyCount);
    }

    public bool IsKeyPressed(KeyCode keycode)
    {
        var sdlCode = (SDL.SDL_Keycode)keycode;
        var scancode = SDL.SDL_GetScancodeFromKey(sdlCode);

        return this.keys[(int)scancode] == 1;
    }
}