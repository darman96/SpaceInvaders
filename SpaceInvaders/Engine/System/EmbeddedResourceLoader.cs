using System.Reflection;
using Microsoft.Extensions.FileProviders;

namespace SpaceInvaders.Engine.System;

public static class EmbeddedResourceLoader
{
    public static byte[] Load(string name)
    {
        var provider = new EmbeddedFileProvider(Assembly.GetCallingAssembly());
        using var resourceStream = provider.GetFileInfo(name).CreateReadStream();
        using var reader = new BinaryReader(resourceStream);
        return reader.ReadBytes((int)resourceStream.Length);
    }
}