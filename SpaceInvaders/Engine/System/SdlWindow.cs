using System.Diagnostics;
using SDL2;
using SpaceInvaders.Engine.Game;
using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Engine.System;

public record WindowProps(
    string Title, int Width, int Height, bool Vsync);

public class SdlWindow : IWindow
{
    public string Title => SDL.SDL_GetWindowTitle(this.windowHandle);

    public Vector2I Position
    {
        get
        {
            SDL.SDL_GetWindowPosition(this.windowHandle, out var x, out var y);
            return new Vector2I(x, y);
        }
    }

    public Vector2I Size
    {
        get
        {
            SDL.SDL_GetWindowSize(this.windowHandle, out var width, out var height);
            return new Vector2I(width, height);
        }
    }

    private readonly IntPtr windowHandle;
    private readonly IntPtr rendererHandle;

    private bool closeRequested = false;
    
    public SdlWindow(IntPtr windowHandle, IntPtr rendererHandle)
    {
        this.windowHandle = windowHandle;
        this.rendererHandle = rendererHandle;
    }

    public void SetTitle(string title)
        => SDL.SDL_SetWindowTitle(this.windowHandle, title);

    public void SetSize(Vector2I size)
        => this.SetSize(size.X, size.Y);

    public void SetSize(int width, int height)
        => SDL.SDL_SetWindowSize(this.windowHandle, width, height);

    public void SetPosition(Vector2I position)
        => this.SetPosition(position.X, position.Y);

    public void SetPosition(int x, int y)
        => SDL.SDL_SetWindowPosition(this.windowHandle, x, y);

    public void SetVsync(bool enabled)
        => SDL.SDL_RenderSetVSync(this.rendererHandle, enabled ? 1 : 0);

    public bool ShouldClose() 
        => this.closeRequested;

    public void PollEvents()
    {
        while (SDL.SDL_PollEvent(out var currentEvent) != 0)
        {
            switch (currentEvent.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    this.closeRequested = true;
                    break;
                case SDL.SDL_EventType.SDL_FIRSTEVENT:
                case SDL.SDL_EventType.SDL_APP_TERMINATING:
                case SDL.SDL_EventType.SDL_APP_LOWMEMORY:
                case SDL.SDL_EventType.SDL_APP_WILLENTERBACKGROUND:
                case SDL.SDL_EventType.SDL_APP_DIDENTERBACKGROUND:
                case SDL.SDL_EventType.SDL_APP_WILLENTERFOREGROUND:
                case SDL.SDL_EventType.SDL_APP_DIDENTERFOREGROUND:
                case SDL.SDL_EventType.SDL_LOCALECHANGED:
                case SDL.SDL_EventType.SDL_DISPLAYEVENT:
                case SDL.SDL_EventType.SDL_WINDOWEVENT:
                case SDL.SDL_EventType.SDL_SYSWMEVENT:
                case SDL.SDL_EventType.SDL_KEYDOWN:
                case SDL.SDL_EventType.SDL_KEYUP:
                case SDL.SDL_EventType.SDL_TEXTEDITING:
                case SDL.SDL_EventType.SDL_TEXTINPUT:
                case SDL.SDL_EventType.SDL_KEYMAPCHANGED:
                case SDL.SDL_EventType.SDL_TEXTEDITING_EXT:
                case SDL.SDL_EventType.SDL_MOUSEMOTION:
                case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                case SDL.SDL_EventType.SDL_MOUSEBUTTONUP:
                case SDL.SDL_EventType.SDL_MOUSEWHEEL:
                case SDL.SDL_EventType.SDL_JOYAXISMOTION:
                case SDL.SDL_EventType.SDL_JOYBALLMOTION:
                case SDL.SDL_EventType.SDL_JOYHATMOTION:
                case SDL.SDL_EventType.SDL_JOYBUTTONDOWN:
                case SDL.SDL_EventType.SDL_JOYBUTTONUP:
                case SDL.SDL_EventType.SDL_JOYDEVICEADDED:
                case SDL.SDL_EventType.SDL_JOYDEVICEREMOVED:
                case SDL.SDL_EventType.SDL_CONTROLLERAXISMOTION:
                case SDL.SDL_EventType.SDL_CONTROLLERBUTTONDOWN:
                case SDL.SDL_EventType.SDL_CONTROLLERBUTTONUP:
                case SDL.SDL_EventType.SDL_CONTROLLERDEVICEADDED:
                case SDL.SDL_EventType.SDL_CONTROLLERDEVICEREMOVED:
                case SDL.SDL_EventType.SDL_CONTROLLERDEVICEREMAPPED:
                case SDL.SDL_EventType.SDL_CONTROLLERTOUCHPADDOWN:
                case SDL.SDL_EventType.SDL_CONTROLLERTOUCHPADMOTION:
                case SDL.SDL_EventType.SDL_CONTROLLERTOUCHPADUP:
                case SDL.SDL_EventType.SDL_CONTROLLERSENSORUPDATE:
                case SDL.SDL_EventType.SDL_FINGERDOWN:
                case SDL.SDL_EventType.SDL_FINGERUP:
                case SDL.SDL_EventType.SDL_FINGERMOTION:
                case SDL.SDL_EventType.SDL_DOLLARGESTURE:
                case SDL.SDL_EventType.SDL_DOLLARRECORD:
                case SDL.SDL_EventType.SDL_MULTIGESTURE:
                case SDL.SDL_EventType.SDL_CLIPBOARDUPDATE:
                case SDL.SDL_EventType.SDL_DROPFILE:
                case SDL.SDL_EventType.SDL_DROPTEXT:
                case SDL.SDL_EventType.SDL_DROPBEGIN:
                case SDL.SDL_EventType.SDL_DROPCOMPLETE:
                case SDL.SDL_EventType.SDL_AUDIODEVICEADDED:
                case SDL.SDL_EventType.SDL_AUDIODEVICEREMOVED:
                case SDL.SDL_EventType.SDL_SENSORUPDATE:
                case SDL.SDL_EventType.SDL_RENDER_TARGETS_RESET:
                case SDL.SDL_EventType.SDL_RENDER_DEVICE_RESET:
                case SDL.SDL_EventType.SDL_POLLSENTINEL:
                case SDL.SDL_EventType.SDL_USEREVENT:
                case SDL.SDL_EventType.SDL_LASTEVENT:
                    Debug.WriteLine($"[Window] Unhandled Event: {currentEvent.type}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
    public void Clear()
    {
        SDL.SDL_SetRenderDrawColor(this.rendererHandle, 0, 0, 0, 255);
        SDL.SDL_RenderClear(this.rendererHandle);
    }

    public void Destroy()
    {
        SDL.SDL_DestroyWindow(this.windowHandle);
    }
}