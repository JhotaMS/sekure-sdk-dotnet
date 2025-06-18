namespace Sekure.Models
{
    public class PresubscribedByIds
    {
        public PresubscribedByIds(
            int id
            , string name
        )
        {
            Id = id;
            Name = name;
        }

        public PresubscribedByIds()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
