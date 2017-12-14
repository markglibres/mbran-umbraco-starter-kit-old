namespace MBran.Core.Components
{
    public interface IComponentRenderString
    {
        string RenderViewToString(string viewPath, object model=null);
    }
}
