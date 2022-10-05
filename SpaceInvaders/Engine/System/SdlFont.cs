using System.Runtime.InteropServices;
using SDL2;

namespace SpaceInvaders.Engine.System;

public class SdlFont
{
    private GCHandle fontBufferHandle;
    private IntPtr fontBufferPointer;
    private readonly int bufferSize;

    public SdlFont(string name)
    {
        var fontBytes = EmbeddedResourceLoader.Load(name);
        this.bufferSize = fontBytes.Length;
        this.fontBufferHandle = GCHandle.Alloc(fontBytes, GCHandleType.Pinned);
        this.fontBufferPointer = this.fontBufferHandle.AddrOfPinnedObject();
    }

    ~SdlFont()
    {
        this.fontBufferHandle.Free();
    }
    
    public IntPtr GetFontPointer(int size)
    {
        var sdlBuffer = SDL.SDL_RWFromConstMem(this.fontBufferPointer, this.bufferSize);
        return SDL_ttf.TTF_OpenFontRW(sdlBuffer, 1, size);
    }
}