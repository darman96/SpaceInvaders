using SpaceInvaders.Engine.Event;

namespace SpaceInvaders.Engine;

public class Application : IEventHandler
{
    public HashSet<EventType> EventTypes => new()
    {
        EventType.Quit
    };

    private readonly Window window;
    private bool running = true;

    public Application(WindowProps windowProps)
    {
        this.window = new Window(windowProps);
        this.window.AddEventHandler(this);
    }

    public void Run()
    {
        while (this.running)
        {
            this.window.ProcessEvents();
            this.window.Clear();
            this.window.Present();
        }
        
        this.window.Destroy();
    }

    public void HandleEvent(EventType type)
    {
        switch (type)
        {
            case EventType.Quit:
                this.running = false;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}