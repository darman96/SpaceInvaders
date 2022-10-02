using SpaceInvaders.Engine.Game;

namespace SpaceInvaders.Engine.System;

public abstract class SdlGame : IGame
{
    public IApplication Application => this.sdlApplication;
    
    private readonly SdlApplication sdlApplication;

    protected SdlGame(WindowProps props)
    {
        this.sdlApplication = new SdlApplication(props, this);
    }

    public void Run() 
        => this.sdlApplication.Run();

    public abstract void Init();
    public abstract void Update(float deltaTime);
    public abstract void Render();
}