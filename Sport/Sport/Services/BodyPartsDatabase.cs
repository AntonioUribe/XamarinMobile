using Sport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Services
{
    public class BodyPartsDatabase
    {
        /// <summary>
        /// obtener la lista de BodyParts async
        /// </summary>
        /// <returns>List BodyParts</returns>
        public Task<List<BodyParts>> GetBodyPartsAsync()
        {
            return App._database.Table<BodyParts>().ToListAsync();
        }

        /// <summary>
        /// Obtener BodyParts con la variable id
        /// </summary>
        /// <param name="id">id BodyParts</param>
        /// <returns>BodyParts</returns>
        public Task<BodyParts> GetBodyPartsAsync(int id)
        {
            return App._database.Table<BodyParts>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Buscar BodyParts
        /// </summary>
        /// <param name="a">string text</param>
        /// <returns>List of bodyparts</returns>
        public Task<List<BodyParts>> SearchExerciseAsync(string a)
        {
            string searchNoSpaces = a.Replace(" ", "%");
            var get_docnumb = App._database.QueryAsync<BodyParts>("SELECT * FROM BodyParts WHERE Name LIKE ?", "%" + searchNoSpaces + "%");

            return get_docnumb;
        }

        /// <summary>
        /// Actualizar o insertar BodyParts
        /// </summary>
        /// <param name="body">Class BodyParts</param>
        /// <returns></returns>
        public Task<int> SaveBodyPartsAsync(BodyParts body)
        {
            if (body.Id != 0)
                return App._database.UpdateAsync(body);
            else
            {
                return App._database.InsertAsync(body);
            }
        }

        /// <summary>
        /// Eliminar BodyParts
        /// </summary>
        /// <param name="body">Class BodyParts</param>
        /// <returns></returns>
        public Task<int> DeleteBodyPartslAsync(BodyParts body)
        {
            return App._database.DeleteAsync(body);
        }

        /// <summary>
        /// Add BodyParts if table database BodyParts is empty
        /// agregar BodyParts si la tabla de BodyParts es vacio 
        /// </summary>
        /// <returns></returns>
        public async Task AddBodyPartsDatabase()
        {
            List<BodyParts> bodyParts = await GetBodyPartsAsync();
            List<string> parts = new List<string>() { "back", "biceps", "quadriceps", "triceps", "calves", "abs", "shoulders", "pectorals", "neck", "forearms", "buttocks", "ischios" };
            if(bodyParts.Count == 0)
            {
                foreach (var part in parts)
                    await SaveBodyPartsAsync(new BodyParts { Name = part });
            }
        }
    }
}
