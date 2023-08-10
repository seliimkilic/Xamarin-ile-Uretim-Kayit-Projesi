using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using CevikMetalTeknik.Model;
using System.Threading.Tasks;

namespace CevikMetalTeknik.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection db;
        public NoteDatabase(string dbveri)
        {
            db = new SQLiteAsyncConnection(dbveri);
            db.CreateTableAsync<Note>().Wait();
        }
        public Task<int> yeniNote (Note note)
        {
            return db.InsertAsync(note);
        }
        public Task <List <Note> >  GetNotesAsync() 
        {
            return db.Table<Note>().ToListAsync();
        }
        
        public Task<int> güncelleNote(Note note)
        {
            return db.UpdateAsync(note);
        }
        public Task<int> SilNote(Note note)
        {
            return db.DeleteAsync(note);
        }


    }
}
