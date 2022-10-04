using SpaceInvaders.Engine.Game;

namespace SpaceInvaders.Engine.System;

public abstract class SdlGame : Actor
{
    public IWindow Window => this.sdlApplication.Window;
    public IRenderer Renderer => this.sdlApplication.Renderer;
    

    private readonly SdlApplication sdlApplication;

    private readonly Dictionary<string, Actor> actorsByName = new();

    protected SdlGame(WindowProps props)
    {
        this.sdlApplication = new SdlApplication(props, this);
    }

    public void Run() 
        => this.sdlApplication.Run();
    
}