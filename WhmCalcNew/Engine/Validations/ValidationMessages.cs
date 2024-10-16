namespace WhmCalcNew.Engine.Validations
{
    class ValidationMessages
    {
        public const string AccuracyError = "Accuracy must be a number between 0 and 6 where 0 is autohit.";

        public const string ArmorPenError = "Armor penetration must be a number between 0 and 6.";

        public const string AttacksError = "Attacks must be a number between 0 and 99, an xDx or xDx + x expression.";

        public const string DamageError = "Damage must be a number between 0 and 99, an xDx or xDx + x expression.";

        public const string StrenghtError = "Strenght must be a number between 0 and 29.";

        public const string TargetNameError = "Target name is invalid.";

        public const string TargetSaveError = "Target save must be a number between 2 and 7.";

        public const string TargetToughnessError = "Target toughness must be a number between 0 and 29.";

        public const string TargetWoundsError = "Target wounds must be a number between 0 and 99.";
    }
}
