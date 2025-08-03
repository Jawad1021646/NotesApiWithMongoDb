using NotesAPI_Mongo.Models;
using NotesAPI_Mongo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<NoteService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Inject service
var noteService = app.Services.GetRequiredService<NoteService>();

// Endpoints
app.MapGet("/notes", () => noteService.Get());

app.MapGet("/notes/{id}", (string id) =>
{
    var note = noteService.Get(id);
    return note is null ? Results.NotFound() : Results.Ok(note);
});

app.MapPost("/notes", (Note note) =>
{
    noteService.Create(note);
    return Results.Created($"/notes/{note.Id}", note);
});

app.MapPut("/notes/{id}", (string id, Note noteIn) =>
{
    var existing = noteService.Get(id);
    if (existing is null) return Results.NotFound();

    noteIn.Id = id;
    noteService.Update(id, noteIn);
    return Results.Ok(noteIn);
});

app.MapDelete("/notes/{id}", (string id) =>
{
    var note = noteService.Get(id);
    if (note is null) return Results.NotFound();

    noteService.Remove(id);
    return Results.Ok();
});

app.Run();
