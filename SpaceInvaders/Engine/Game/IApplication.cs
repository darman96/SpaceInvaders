using SpaceInvaders.Engine.System;

namespace SpaceInvaders.Engine.Game;

public interface IApplication
{
    IWindow Window { get; }
    IRenderer Renderer { get; }
    IKeyState KeyState { get; }
    
    
    void Initialize(WindowProps props);
    void Run();
}