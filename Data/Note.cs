using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Note
    {
        public string UserName { get; set; }
        public string TextNote { get; set; }
        public Date DateNote { get; set; }
        public Note(string username, string text, Date date)
        {
            UserName = username;
            TextNote = text;
            DateNote = date;
        }
    }

    public class Notes
    {
        public Dictionary<string, List<Note>> NoteList = new Dictionary<string, List<Note>>();
        public List<Note> ReadDictionary(string UserName)
        {
            return NoteList[UserName];
        }
        public void WriteDictionary(string user, string text, Date dat)
        {
            NoteList[user].Add(new Note(user, text, dat));
        }
    }
}
