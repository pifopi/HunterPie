﻿using HunterPie.Core.Architecture;
using HunterPie.Core.Game.Client;
using HunterPie.Core.Game.Enums;
using System.Collections.ObjectModel;

namespace HunterPie.UI.Overlay.Widgets.Activities.ViewModel
{
    public class TrainingDojoViewModel : Bindable, IActivity
    {
        private int _boosts;
        private int _maxBoosts;
        private int _rounds;
        private int _maxRounds;
        private string _dojoBoostsString;
        private string _dojoRoundsString;

        public int Boosts { get => _boosts; set { SetValue(ref _boosts, value); } }
        public int MaxBoosts { get => _maxBoosts; set { SetValue(ref _maxBoosts, value); } }
        public int Rounds { get => _rounds; set { SetValue(ref _rounds, value); } }
        public int MaxRounds { get => _maxRounds; set { SetValue(ref _maxRounds, value); } }
        public string DojoBoostsString { get => _dojoBoostsString; set { SetValue(ref _dojoBoostsString, value + ":"); } }
        public string DojoRoundsString { get => _dojoRoundsString; set { SetValue(ref _dojoRoundsString, value + ":"); } }

        public ObservableCollection<BuddyViewModel> Buddies { get; } = new();

        public ActivityType Type => ActivityType.TrainingDojo;
    }
}
