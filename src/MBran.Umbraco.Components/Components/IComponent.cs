using System;

namespace MBran.Umbraco.Components
{
    public interface IComponent
    {
        string Name { get; }
        Type Controller { get; }
    }
}
