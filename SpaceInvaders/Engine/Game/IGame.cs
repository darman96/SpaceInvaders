namespace SpaceInvaders.Engine.Game;

public interface IGame
{
    IApplication Application { get; }
    IWindow Window => this.Application.Window;
    IRenderer Renderer => this.Application.Renderer;
    
    public void Init();
    public void Update(float deltaTime);
    public void Render();
}