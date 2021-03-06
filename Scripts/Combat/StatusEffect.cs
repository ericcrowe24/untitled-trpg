using Godot;
using System.Collections.Generic;
using TRPG.Combat.States;
using TRPG.Characters;

namespace TRPG.Combat {
    public class StatusEffect {
        public string EffectName { get; set; }
        public int Duration { get; set; }
        public bool HasEndOfTurnEffect { get; set; }
        public List<Stat> EOTEffects { get; set; }
        public bool HasPermanentEffet { get; set; }
        public List<Stat> PermEffects { get; set; }
        public Dictionary<Stat, int> StatModifers { get; set; }
        public Dictionary<Stat, int> StatPercentModifiers { get; set; }
    }
}
