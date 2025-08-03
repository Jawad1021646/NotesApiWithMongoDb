namespace NotesAPI_Mongo.Models;

public class Note
{
    public string Id { get; set; }  // MongoDB uses string IDs
    public string Title { get; set; }
    public string Content { get; set; }
}
