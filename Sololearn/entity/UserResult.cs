namespace Sololearn.entity;

using Sololearn.entity.templates;

public class UserResult : AbsLongEntity
{
    public Question Question { get; set; }
    public Answer Answer { get; set; }
    public string AnswerBody { get; set; } = "";
    public new bool IsActive { get; set; }

    public UserResult() { }

    public UserResult(Question question, Answer answer)
    {
        Question= question;
        Answer= answer;
    }
    public UserResult(Question question, string answerBody)
    {
        Question= question;
        AnswerBody= answerBody;
    }



}