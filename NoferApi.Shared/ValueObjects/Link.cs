namespace NoferApi.Shared.ValueObjects;

public record Link
{
    public string Value { get; }

    private Link(string value)
    {
        Value = value;
    }

    public static Link FromString(string url)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uri) ||
            uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
        {
            throw new ArgumentException("Invalid URL. Only absolute HTTP or HTTPS URLs are allowed.", nameof(url));
        }

        return new Link(uri.ToString());
    }
    
    public static implicit operator string(Link link) => link.Value;
    public static implicit operator Uri(Link link) => new(link.Value);
}
