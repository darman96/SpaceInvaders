namespace SpaceInvaders.Engine.Event;

public interface IEventHandler
{
    public HashSet<EventType> EventTypes { get; }

    public void HandleEvent(EventType type);
}