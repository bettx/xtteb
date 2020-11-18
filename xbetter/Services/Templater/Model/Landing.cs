using System.Collections.Generic;
using xbetter.Helpers;

namespace xbetter.Services.Templater.Model
{
    public class Landing
    {
        public string Template { get; set; }
        public string TemplateReview { get; set; }
        public string Host { get; set; }
        public string HostName { get; set; }
        public string RedirectLink { get; set; }
        public string MetricaId { get; set; }
        public Header Header { get; set; }
        public Body Body { get; set; }
        public KeyRandom KeyRandom { get; set; }
    }

    public class Header
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Body
    {
        public string SiteName { get; set; }
        public string H1 { get; set; }
        public List<Block> Blocks { get; set; } = new List<Block>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }

    public class Block
    {
        public string MenuTitle { get; set; }
        public string MenuLink { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class Review
    {
        public string Username { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
    }

    public class KeyRandom
    {
        public readonly List<string> Keys = new List<string>();

        public KeyRandom(IEnumerable<string> keys)
        {
            Keys.Clear();
            Keys.AddRange(keys);
            Keys.Shuffle();
        }
    }
}