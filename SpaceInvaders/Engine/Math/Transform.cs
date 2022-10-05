namespace SpaceInvaders.Engine.Math;

public class Transform
{
    public Vector2F Position { get; private set; }

    public Transform()
        : this(Vector2F.Zero()) {}

    public Transform(Vector2F position)
    {
        this.Position = position;
    }
    
    public void SetPosition(Vector2F position)
    {
        this.Position = position;
    }
}