namespace HtmlInsights.Formatters
{
    public interface IFormatter<T>
    {
        void Format(T context);
    }
}
