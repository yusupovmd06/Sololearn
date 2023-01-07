using Sololearn.entity.templates;

namespace Sololearn.entity
{
    public class Subject : AbsLongEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Test> Tests { get; set; } = new List<Test>();
        
        public Subject() { }
        public Subject(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
