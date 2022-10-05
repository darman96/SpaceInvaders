namespace SpaceInvaders.Engine.Math;

public struct Rect
{
    public Vector2F Position;
    public Vector2F Size;
    
    public Rect(Vector2F position, Vector2F size)
    {
        this.Position = position;
        this.Size = size;
    }
}