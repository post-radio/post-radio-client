namespace Global.Services.Backend.Abstract
{
    public interface IRequestHeader
    {
        string Type { get; }
        string Value { get; }
    }
}