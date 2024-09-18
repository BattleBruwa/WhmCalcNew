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

        #region Свойства - привязки для таблицы кнопок модификаторов
        // Привязка комбобокса SustainedHitsCB
        public string SustainedHitsMod 
        {
            set
            {
                switch (value)
                {
                    case "System.Windows.Controls.ComboBoxItem: Cancel": 
                        {
                            PickedMods.Remove(ModificatorsList[5]);
                        }; break;

                    case "System.Windows.Controls.ComboBoxItem: 1":
                        {
                            Modificator mod = ModificatorsList[5];
                            mod.Condition = 1;
                            PickedMods.Remove(ModificatorsList[5]);
                            PickedMods.Add(mod);
                        }; break;

                    case "System.Windows.Controls.ComboBoxItem: 2":
                        {
                            Modificator mod = ModificatorsList[5];
                            mod.Condition = 2;
                            PickedMods.Remove(ModificatorsList[5]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 3":
                        {
                            Modificator mod = ModificatorsList[5];
                            mod.Condition = 3;
                            PickedMods.Remove(ModificatorsList[5]);
                            PickedMods.Add(mod);
                        };
                        break;
                    default: break;
                }
            } 
        }

        // Привязка комбобокса CritsCB
        public string CritsMod
        {
            set
            {
                switch (value)
                {
                    case "System.Windows.Controls.ComboBoxItem: Cancel":
                        {
                            PickedMods.Remove(ModificatorsList[13]);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 3+":
                        {
                            Modificator mod = ModificatorsList[13];
                            mod.Condition = 3;
                            PickedMods.Remove(ModificatorsList[13]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 4+":
                        {
                            Modificator mod = ModificatorsList[13];
                            mod.Condition = 4;
                            PickedMods.Remove(ModificatorsList[13]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 5+":
                        {
                            Modificator mod = ModificatorsList[13];
                            mod.Condition = 5;
                            PickedMods.Remove(ModificatorsList[13]);
                            PickedMods.Add(mod);
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        // Привязка комбобокса AntiXCB
        public string AntiXMod
        {
            set
            {
                switch (value)
                {
                    case "System.Windows.Controls.ComboBoxItem: Cancel":
                        {
                            PickedMods.Remove(ModificatorsList[8]);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 3+":
                        {
                            Modificator mod = ModificatorsList[8];
                            mod.Condition = 3;
                            PickedMods.Remove(ModificatorsList[8]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 4+":
                        {
                            Modificator mod = ModificatorsList[8];
                            mod.Condition = 4;
                            PickedMods.Remove(ModificatorsList[8]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 5+":
                        {
                            Modificator mod = ModificatorsList[8];
                            mod.Condition = 5;
                            PickedMods.Remove(ModificatorsList[8]);
                            PickedMods.Add(mod);
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        // Привязка комбобокса InvulCB
        public string InvulMod
        {
            set
            {
                switch (value)
                {
                    case "System.Windows.Controls.ComboBoxItem: Cancel":
                        {
                            PickedMods.Remove(ModificatorsList[10]);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 3+":
                        {
                            Modificator mod = ModificatorsList[10];
                            mod.Condition = 3;
                            PickedMods.Remove(ModificatorsList[10]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 4+":
                        {
                            Modificator mod = ModificatorsList[10];
                            mod.Condition = 4;
                            PickedMods.Remove(ModificatorsList[10]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 5+":
                        {
                            Modificator mod = ModificatorsList[10];
                            mod.Condition = 5;
                            PickedMods.Remove(ModificatorsList[10]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 6+":
                        {
                            Modificator mod = ModificatorsList[10];
                            mod.Condition = 6;
                            PickedMods.Remove(ModificatorsList[10]);
                            PickedMods.Add(mod);
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        // Привязка комбобокса FNPCB
        public string FnpMod
        {
            set
            {
                switch (value)
                {
                    case "System.Windows.Controls.ComboBoxItem: Cancel":
                        {
                            PickedMods.Remove(ModificatorsList[9]);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 3+":
                        {
                            Modificator mod = ModificatorsList[9];
                            mod.Condition = 3;
                            PickedMods.Remove(ModificatorsList[9]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 4+":
                        {
                            Modificator mod = ModificatorsList[9];
                            mod.Condition = 4;
                            PickedMods.Remove(ModificatorsList[9]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 5+":
                        {
                            Modificator mod = ModificatorsList[9];
                            mod.Condition = 5;
                            PickedMods.Remove(ModificatorsList[9]);
                            PickedMods.Add(mod);
                        };
                        break;

                    case "System.Windows.Controls.ComboBoxItem: 6+":
                        {
                            Modificator mod = ModificatorsList[9];
                            mod.Condition = 6;
                            PickedMods.Remove(ModificatorsList[9]);
                            PickedMods.Add(mod);
                        };
                        break;
                    default:
                        break;
                }
            }
        }
#endregion

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
