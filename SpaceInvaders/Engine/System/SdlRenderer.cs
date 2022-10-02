using SDL2;
using SpaceInvaders.Engine.Game;

namespace SpaceInvaders.Engine.System;

public class SdlRenderer : IRenderer
{
    private readonly IntPtr rendererHandle;

    public SdlRenderer(IntPtr rendererHandle)
    {
        this.rendererHandle = rendererHandle;
    }

    public void Present()
    {
        SDL.SDL_RenderPresent(this.rendererHandle);
    }

    public void Destroy()
    {
        SDL.SDL_DestroyRenderer(this.rendererHandle);
    }
}