using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Engine.Game;

public interface IRenderer
{
    void DrawRect(Rect rect, Color color, bool fill = false);
    void DrawRect(Vector2I position, Vector2I size, Color color, bool fill = false);
}