using System;
using System.Collections.ObjectModel;
using AttaxxPlus.Model;
using AttaxxPlus.ViewModel;

namespace AttaxxPlus.Boosters
{
    /// <summary>
    /// Booster filling all empty fields with the opponents' color (assuming 2 players).
    /// </summary>
    public class SurrenderBooster : BoosterBase
    {
        // EVIP: compact override of getter for Title returning constant.
        public override string Title => "Surrender";

        public SurrenderBooster() : base()
        {
            LoadImage(new Uri(@"ms-appx:///Boosters/SurrenderBooster.png"));
        }

        public override bool TryExecute(Field selectedField, Field currentField)
        {
            int winner = GameViewModel.CurrentPlayer == 1 ? 2 : 1;
            ObservableCollection<FieldViewModelList> fieldVMs = GameViewModel.Fields;
            for (int idx = 0; idx < GameViewModel.Fields.Count; idx++)
            {
                ObservableCollection<FieldViewModel> fields = fieldVMs[idx];
                for (int idx2 = 0; idx2 < fields.Count; idx2++)
                {
                    fields[idx2].Model.Owner = winner;
                }
            }
            return true;
        }
    }
}
