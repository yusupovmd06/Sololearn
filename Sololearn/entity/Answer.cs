namespace Sololearn.entity;

using Sololearn.entity.templates;

public class Answer : AbsLongEntity
{
    public string Body { get; set; }
    public long QuestionId { get; set; }
    public bool IsTrue { get; set; }
}
