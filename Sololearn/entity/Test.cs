using Sololearn.entity.templates;

namespace Sololearn.entity
{
    public class Test : AbsLongEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IList<Question> Questions { get; set; } = new List<Question>();

        public Test() { }
        public Test(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        public Test(string name, string description, IList<Question> questions)
        {
            Name = name;
            Description = description;
            Questions = questions;
        }

    }
}
