using SDL2;
using SpaceInvaders.Engine.Event;
using SpaceInvaders.Util.Extensions;

namespace SpaceInvaders.Engine;

public record WindowProps(
    string Title, int Width, int Height, bool Vsync);

public class Window
{
    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly IntPtr sdlWindow;
    private readonly IntPtr sdlRenderer;

    private HashSet<IEventHandler> eventHandlers = new();

    public Window(WindowProps windowProps)
    {
        this.sdlWindow = SDL.SDL_CreateWindow(
            windowProps.Title,
            SDL.SDL_WINDOWPOS_CENTERED,
            SDL.SDL_WINDOWPOS_CENTERED,
            windowProps.Width, windowProps.Height,
            SDL.SDL_WindowFlags.SDL_WINDOW_VULKAN);

        this.sdlRenderer = SDL.SDL_CreateRenderer(
            this.sdlWindow,
            -1,
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

        SDL.SDL_RenderSetVSync(this.sdlRenderer, windowProps.Vsync ? 1 : 0);
    }

    public void AddEventHandler(IEventHandler handler)
    {
        this.eventHandlers.Add(handler);
    }

    public void Clear()
    {
        SDL.SDL_SetRenderDrawColor(this.sdlRenderer, 0, 0, 0, 255);
        SDL.SDL_RenderClear(this.sdlRenderer);
    }

    public void Present()
    {
        SDL.SDL_RenderPresent(this.sdlRenderer);
    }

    public void ProcessEvents()
    {
        while (SDL.SDL_PollEvent(out var sdlEvent) != 0)
        {
            if (sdlEvent.type == SDL.SDL_EventType.SDL_QUIT)
            {
                this.eventHandlers
                    .Where(handler => handler.EventTypes.Contains(EventType.Quit))
                    .ForEach(handler => handler.HandleEvent(EventType.Quit));
            }
        }
    }

    public void Destroy()
    {
        SDL.SDL_DestroyRenderer(this.sdlRenderer);
        SDL.SDL_DestroyWindow(this.sdlWindow);
    }
}