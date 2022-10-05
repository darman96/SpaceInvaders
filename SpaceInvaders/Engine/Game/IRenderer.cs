using SpaceInvaders.Engine.Math;
using SpaceInvaders.Engine.System;

namespace SpaceInvaders.Engine.Game;

public interface IRenderer
{
    void DrawRect(Rect rect, Color color, bool fill = false);
    void DrawRect(Vector2F position, Vector2F size, Color color, bool fill = false);
    void DrawLine(Vector2F start, Vector2F end, Color color);

    void RenderText(string text, Vector2F position, int size, SdlFont sdlFont, Color color);
    void RenderTextCentered(string text, Vector2F position, int size, SdlFont sdlFont, Color color);
}