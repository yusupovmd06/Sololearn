namespace SoloLearn.payload
{
    public class TestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<QuestionDto> Questions { get; set; } = new List<QuestionDto>();

        public TestDto(string name, string description, IList<QuestionDto> questions)
        {
            Name = name;
            Description = description;
            Questions = questions;
        }
        
        
    }

    
}