using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Engine.Game;

public interface IRenderable
{
    Transform Transform { get; protected set; }

    void Render(IRenderer renderer);
}