namespace SpaceInvaders.Engine.Game;

public interface IKeyState
{
    void Update();
    bool IsKeyPressed(KeyCode keycode);
}