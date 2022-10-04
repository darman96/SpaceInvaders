namespace SpaceInvaders.Engine.Math;

public struct Rect
{
    public Vector2I Position;
    public Vector2I Size;
    
    public Rect(Vector2I position, Vector2I size)
    {
        this.Position = position;
        this.Size = size;
    }
}