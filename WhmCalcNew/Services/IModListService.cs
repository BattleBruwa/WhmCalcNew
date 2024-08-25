﻿using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services
{
    public interface IModListService
    {
        List<Modificator> ModificatorsList { get; set; }
        ObservableCollection<Modificator> PickedModificators { get; set; }
    }
}