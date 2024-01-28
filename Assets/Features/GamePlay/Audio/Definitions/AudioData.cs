using Ragon.Protocol;

namespace GamePlay.Audio.Definitions
{
    public class AudioData
    {
        public AudioData(string link, AudioMetadata metadata)
        {
            
            Link = link;
            Author = metadata.Author;
            Title = metadata.Title;
        }
        
        public AudioData(string link, string author, string title)
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

        public static AudioData Deserialize(RagonBuffer buffer)
        {
            var link = buffer.ReadString();
            var author = buffer.ReadString();
            var title = buffer.ReadString();

            return new AudioData(link, author, title);
        }
    }
}