using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services
{
    public class ModListService : IModListService
    {
        // Путь до файла с модификаторами
        private readonly string jsonPath = string.Concat(Path.GetFullPath("../../../Data"), "\\Modificators.json");
        // Выбранные модификаторы
        public ObservableCollection<Modificator> PickedModificators { get; set; } = new();
        // Все модификаторы
        public List<Modificator> ModificatorsList { get; set; } = new();

        public ModListService()
        {
            Initialize();
        }

        private async Task Initialize()
        {
            using (FileStream fs = new FileStream($"{jsonPath}", FileMode.Open, FileAccess.Read))
            {
                ModificatorsList = await JsonSerializer.DeserializeAsync<List<Modificator>>(fs);
            }
        }
    }
}
