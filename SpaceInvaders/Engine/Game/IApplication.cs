namespace SpaceInvaders.Engine.Game;

public interface IApplication
{
    public IWindow Window { get; }
    public IRenderer Renderer { get; }
    public IKeyState KeyState { get; }
}