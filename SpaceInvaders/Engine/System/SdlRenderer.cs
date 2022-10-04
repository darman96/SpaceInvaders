using static SDL2.SDL;
using SpaceInvaders.Engine.Game;
using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Engine.System;

internal class SdlRenderer : IRenderer
{
    private readonly IntPtr rendererHandle;

    public SdlRenderer(IntPtr rendererHandle)
    {
        this.rendererHandle = rendererHandle;
    }

    public void Present()
    {
        SDL_RenderPresent(this.rendererHandle);
    }

    public void Destroy()
    {
        SDL_DestroyRenderer(this.rendererHandle);
    }

    public void DrawRect(Rect rect, Color color, bool fill)
         => this.DrawRect(rect.Position, rect.Size, color, fill);

    public void DrawRect(Vector2I position, Vector2I size, Color color, bool fill)
    {
        var rect = new SDL_Rect
        {
            x = position.X,
            y = position.Y,
            w = size.X,
            h = size.Y
        };

        var currentColor = this.getColor();
        this.setColor(color);
        
        if (fill)
            SDL_RenderFillRect(this.rendererHandle, ref rect);
        else
            SDL_RenderDrawRect(this.rendererHandle, ref rect);
        
        this.setColor(currentColor);
    }

    private void setColor(Color color)
    {
        SDL_SetRenderDrawColor(
            this.rendererHandle, 
            (byte)color.R,
            (byte)color.G,
            (byte)color.B,
            (byte)color.A);
    }
    
    private Color getColor()
    {
        SDL_GetRenderDrawColor(this.rendererHandle, out var r, out var g, out var b, out var a);
        return new Color(r, g, b, a);
    }
}