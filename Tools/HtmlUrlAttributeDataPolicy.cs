#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    [Flags]
    internal enum HtmlUrlAttributeDataPolicy
    {
        None = 0,
        Image = 1,
        Audio = 2,
        Video = 4,
        Media = Image | Audio | Video
    }
}
