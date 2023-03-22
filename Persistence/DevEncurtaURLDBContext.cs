using DevEncurtaUrl.Entities;

namespace DevEncurtaUrl.Persistence
{
    public class DevEncurtaURLDBContext
    {
        private int _currentIndex = 1;
        public DevEncurtaURLDBContext()
        {
            Links = new List<ShortenedCustomLink>();
        }

        public List<ShortenedCustomLink> Links { get; set; }

        public void AddLink(ShortenedCustomLink link) 
        {
            link.Id = _currentIndex;

            _currentIndex++;

            Links.Add(link);
        }
    }

}
