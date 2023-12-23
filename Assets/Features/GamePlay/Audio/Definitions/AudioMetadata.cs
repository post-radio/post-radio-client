using Ragon.Protocol;

namespace GamePlay.Audio.Definitions
{
    public class AudioMetadata
    {
        public AudioMetadata(string url, string author, string title)
        {
            Url = url;
            Author = author;
            Title = title;
        }
        
        public readonly string Url;
        public readonly string Author;
        public readonly string Title;
        
        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteString(Url);
            buffer.WriteString(Author);
            buffer.WriteString(Title);
        }

        public static AudioMetadata Deserialize(RagonBuffer buffer)
        {
            var url = buffer.ReadString();
            var author = buffer.ReadString();
            var title = buffer.ReadString();

            return new AudioMetadata(url, author, title);
        }
    }
}