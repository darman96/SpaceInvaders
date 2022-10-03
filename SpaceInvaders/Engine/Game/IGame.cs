namespace SpaceInvaders.Engine.Game;

public interface IGame
{
    IApplication Application { get; }
    IWindow Window { get; }
    IRenderer Renderer { get; }
    
    public void Init();
    public void Update(float deltaTime);
    public void Render();
}