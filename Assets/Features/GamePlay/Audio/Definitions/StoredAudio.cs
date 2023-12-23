using Ragon.Protocol;

namespace GamePlay.Audio.Definitions
{
    public class StoredAudio
    {
        public StoredAudio(string link, AudioMetadata metadata)
        {
            Link = link;
            Author = metadata.Author;
            Title = metadata.Title;
        }
        
        public StoredAudio(string link, string author, string title)
        {
            Link = link;
            Author = author;
            Title = title;
        }
        
        public readonly string Link;
        public readonly string Author;
        public readonly string Title;

        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteString(Link);
            buffer.WriteString(Author);
            buffer.WriteString(Title);
        }

        public static StoredAudio Deserialize(RagonBuffer buffer)
        {
            var link = buffer.ReadString();
            var author = buffer.ReadString();
            var title = buffer.ReadString();

            return new StoredAudio(link, author, title);
        }
    }
}