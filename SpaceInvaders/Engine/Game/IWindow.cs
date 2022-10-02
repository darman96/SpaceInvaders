using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Engine.Game;

public interface IWindow
{
    string Title { get; }
    Vector2I Position { get; }
    Vector2I Size { get; }
    
    void SetTitle(string title);
    void SetSize(Vector2I size);
    void SetSize(int width, int height);
    void SetPosition(Vector2I position);
    void SetPosition(int x, int y);
    void SetVsync(bool enabled);
}