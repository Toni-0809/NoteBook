using Notebook.Core.Entity;
using Notebook.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Core.Data
{
    public class NoteDataSource
    {
        /// <summary>
        /// Относительный путь к файлу, где хранятся данные
        /// </summary>
        private readonly string path = ".\\note_data.json";

        /// <summary>
        /// Метод чтения данных в формате JSON 
        /// и их десериализация
        /// </summary>
        /// <returns></returns>
        public List<Note> Get()
        {
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Note>>(data);
            }
            return null;
        }

        /// <summary>
        /// Метод записи данных в формате JSON 
        /// и их десериализация
        /// </summary>
        /// <returns></returns>
        public void Write(List<Note> data)
        {
            File.WriteAllText(path, DataSerializer.Serialize(data));
        }
    }
}
