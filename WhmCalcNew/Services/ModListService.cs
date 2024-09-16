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

        // Все модификаторы
        public List<Modificator> ModificatorsList { get; set; }

        // Выбранные модификаторы
        public ObservableCollection<Modificator> PickedMods { get; set; } = new();

        private string sustainedHits;
        public string SustainedHitsMod 
        { 
            get {  return sustainedHits; }
            set
            {
                switch (value)
                {
                    case "System.Windows.Controls.ComboBoxItem: Cancel": 
                        {
                            PickedMods.Remove(ModificatorsList[5]);
                            sustainedHits = String.Empty;
                        }; break;

                    case "System.Windows.Controls.ComboBoxItem: 1":
                        {
                            Modificator mod = ModificatorsList[5];
                            mod.Condition = 1;
                            PickedMods.Remove(ModificatorsList[5]);
                            PickedMods.Add(mod);
                            sustainedHits = "1";
                        }; break;

                    case "System.Windows.Controls.ComboBoxItem: 2":
                        {
                            Modificator mod = ModificatorsList[5];
                            mod.Condition = 2;
                            PickedMods.Remove(ModificatorsList[5]);
                            PickedMods.Add(mod);
                            sustainedHits = "2";
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 3":
                        {
                            Modificator mod = ModificatorsList[5];
                            mod.Condition = 3;
                            PickedMods.Remove(ModificatorsList[5]);
                            PickedMods.Add(mod);
                            sustainedHits = "3";
                        };
                        break;
                    default: break;

                }
            } 
        }
        #region Методы
        // Вызывается в App.OnSturtup() для заполнения коллекции модификаторов из json файла
        public async Task InitializeModListAsync()
        {
            using (FileStream fs = new FileStream($"{jsonPath}", FileMode.Open, FileAccess.Read))
            {
                ModificatorsList = new(await JsonSerializer.DeserializeAsync<List<Modificator>>(fs));
                ModificatorsList = ModificatorsList.OrderBy(x => x.Id).ToList();
            }
        }
        // ---------------------------------------------------------------------------------
        #endregion
    }
}
