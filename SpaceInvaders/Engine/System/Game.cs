using SpaceInvaders.Engine.Game;

namespace SpaceInvaders.Engine.System;

public abstract class Game<TApp>
    where TApp : IApplication, new()
{
    private readonly TApp application = new();
    private readonly Dictionary<string, Actor> actorsByName = new();

    protected Game(WindowProps windowProps)
    {
        application.Initialize(windowProps);
    }

    public void Run() 
        => this.application.Run();
    
}