using Sololearn.entity.templates;

namespace Sololearn.entity
{
    public class Question : AbsLongEntity
    {
        public string Body { get; set; }
        public QuestionType Type { get; set; }
        public int Difficulty { get; set; }
        public Test Test { get; set; }

        public Question(long id, DateTime addedAt, bool isActive, bool isDeleted,
            long addedBy, string body, QuestionType questionType, int difficulty, Test test) 
            : base(id, addedAt, isActive, isDeleted,addedBy)
        {
            Body = body;
            Type = questionType;
            Difficulty = difficulty;
            Test = test;
        }

        public Question (string body, QuestionType questionType, int difficulty, Test test)
        {
            Body = body;
            Type = questionType;
            Difficulty = difficulty;
            Test = test;
        }

    }
}
