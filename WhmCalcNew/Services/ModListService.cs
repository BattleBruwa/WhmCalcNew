using System.IO;
using System.Text.Json;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services
{
    public class ModListService : IModListService
    {
        // Путь до файла с модификаторами
        private readonly string jsonPath = string.Concat(Path.GetFullPath("../../../Data"), "\\Modificators.json");

        // Все модификаторы
        public List<Modificator> ModificatorsList { get; set; }

        public async Task InitializeModListAsync()
        {
            using (FileStream fs = new FileStream($"{jsonPath}", FileMode.Open, FileAccess.Read))
            {
                ModificatorsList = new(await JsonSerializer.DeserializeAsync<List<Modificator>>(fs));
                ModificatorsList = ModificatorsList.OrderBy(x => x.Id).ToList();
            }
            
        }
    }
}
