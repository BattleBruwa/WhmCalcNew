using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WhmCalcNew.Models
{
    public partial class AttackingUnit : IDataErrorInfo
    {
        private string _error;
        public string Error => _error;
        

        public string this[string columnName]
        {
            get
            {
                bool hasError = false;

                switch (columnName)
                {
                    case nameof(Attacks): break;
                    case nameof(Strength):
                        if (Strength < 0 || Strength > 24)
                        {
                            return "Сила модели должна находиться в диапазоне от 0 до 24!";
                        }
                        break;
                    case nameof(Accuracy):
                        if (Accuracy < 0 || Accuracy > 6)
                        {
                            return "Меткость модели должна находиться в диапазоне от 0 до 6!";
                        }
                        break;
                    case nameof(ArmorPen):
                        if (ArmorPen < 0 || ArmorPen > 6)
                        {
                            return "Пробивание брони должно находиться в диапазоне от 0 до 6!";
                        }
                        break;
                    case nameof(Damage): break;
                }
                return string.Empty;
            }
        }

        private bool CheckInputNumbers()
        {
            if ((Strength < 0) || (Accuracy < 0) || (ArmorPen < 0))
            {
                return false;
            }
            return true;
        }
    }
}
