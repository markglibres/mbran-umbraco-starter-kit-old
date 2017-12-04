using Humanizer;
using System;

namespace MBran.Umbraco.Components
{
    public abstract class Component<T> : IComponent
        where T: IComponentController
    {
        public virtual string Name => this.GetType().UnderlyingSystemType.Name.Humanize();

        Type IComponent.Controller => typeof(T);
        
    }
}
