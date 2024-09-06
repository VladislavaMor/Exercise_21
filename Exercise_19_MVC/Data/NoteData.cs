using Exercise_21.Models;

namespace Exercise_21.Data
{

    public class NoteData
    {
        private readonly PhoneBookContext context;

        public NoteData(PhoneBookContext Context)
        {
            this.context = Context;
        }

        public void AddNote(Note car)
        {
            context.Notes.Add(car);
            context.SaveChanges();
        }

        public IEnumerable<Note> GetNotes()
        {
            return this.context.Notes;
        }
    }
}
