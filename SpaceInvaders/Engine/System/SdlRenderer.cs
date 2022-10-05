using SDL2;
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
        SDL_ttf.TTF_Init();
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

    public void DrawRect(Vector2F position, Vector2F size, Color color, bool fill)
    {
        var rect = new SDL_FRect()
        {
            x = position.X,
            y = position.Y,
            w = size.X,
            h = size.Y
        };

        var currentColor = this.getColor();
        this.setColor(color);

        if (fill)
            SDL_RenderFillRectF(this.rendererHandle, ref rect);
        else
            SDL_RenderDrawRectF(this.rendererHandle, ref rect);

        this.setColor(currentColor);
    }

    public void RenderText(string text, Vector2F position, int size, Font font, Color color)
    {
        var fontHandle = font.GetFontPointer(size);
        var texture = this.GetTextureFromText(text, fontHandle, color);
        SDL_ttf.TTF_SizeText(fontHandle, text, out var width, out var height);
        var rect = new SDL_FRect
        {
            x = position.X,
            y = position.Y,
            w = width,
            h = height
        };

        SDL_RenderCopyF(this.rendererHandle, texture, IntPtr.Zero, ref rect);
    }

    public void RenderTextCentered(string text, Vector2F position, int size, Font font, Color color)
    {
        var fontHandle = font.GetFontPointer(size);
        var texture = this.GetTextureFromText(text, fontHandle, color);
        
        SDL_ttf.TTF_SizeText(fontHandle, text, out var width, out var height);
        var rect = new SDL_FRect
        {
            x = position.X - width / 2f,
            y = position.Y,
            w = width,
            h = height
        };

        SDL_RenderCopyF(this.rendererHandle, texture, IntPtr.Zero, ref rect);
    }

    private IntPtr GetTextureFromText(string text, IntPtr font, Color color)
    {
        var surface = SDL_ttf.TTF_RenderText_Solid(
            font,
            text,
            color.ToSdlColor());

        return SDL_CreateTextureFromSurface(this.rendererHandle, surface);
    }

    private void withColor(Color color, Action action)
    {
        var currentColor = this.getColor();
        this.setColor(color);
        action();
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

internal static class SdlColorExtensions
{
    public static SDL_Color ToSdlColor(this Color color)
        => new SDL_Color
        {
            r = (byte)color.R,
            g = (byte)color.G,
            b = (byte)color.B,
            a = (byte)color.A
        };
}