using SpaceInvaders.Util.Extensions;

namespace SpaceInvaders.Engine.Game;

public abstract class Actor
{
    public Actor? Parent { get; private set; }
    
    protected IApplication? Application = default;
    
    private Dictionary<string, Actor> actors = new();

    public abstract void OnInitialize();
    public abstract void OnUpdate(float deltaTime);
    public abstract void OnRender();

    public void Initialize(IApplication application, Actor? parent = null)
    {
        this.Parent = parent;
        this.Application = application;
        this.OnInitialize();
        
        this.actors.Values.ForEach(actor => actor.Initialize(this.Application, this));
    }

    public void Update(float deltaTime)
    {
        this.OnUpdate(deltaTime);
        this.actors.Values.ForEach(actor => actor.Update(deltaTime));
    }

    public void Render()
    {
        this.OnRender();
        this.actors.Values.ForEach(actor => actor.Render());
    }
    
    public TActor RegisterActor<TActor>(string name) 
        where TActor : Actor, new()
    {
        if (this.actors.ContainsKey(name))
            throw new Exception($"Actor with name {name} already exits!");

        var actor = new TActor();
        this.actors[name] = actor;
        return actor;
    }

    public void RemoveActor(string name)
    {
        if (!this.actors.ContainsKey(name))
            throw new Exception($"Actor with name {name} does not exist!");

        this.actors.Remove(name);
    }
}