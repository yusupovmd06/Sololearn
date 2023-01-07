namespace Sololearn.payload;

public class SubjectDto
{
    public SubjectDto(long id, string name, string description, int numOfQuestions)
    {
        Id = id;
        Name = name;
        Description = description;
        NumOfQuestions = numOfQuestions;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumOfQuestions { get; set; }
}
