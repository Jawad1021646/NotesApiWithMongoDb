using MongoDB.Driver;
using NotesAPI_Mongo.Models;

namespace NotesAPI_Mongo.Services;

public class NoteService
{
    private readonly IMongoCollection<Note> _notes;

    public NoteService(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _notes = database.GetCollection<Note>(config["MongoDB:CollectionName"]);
    }

    public List<Note> Get() => _notes.Find(note => true).ToList();
    public Note Get(string id) => _notes.Find(note => note.Id == id).FirstOrDefault();
    public void Create(Note note) => _notes.InsertOne(note);
    public void Update(string id, Note noteIn) => _notes.ReplaceOne(note => note.Id == id, noteIn);
    public void Remove(string id) => _notes.DeleteOne(note => note.Id == id);
}
