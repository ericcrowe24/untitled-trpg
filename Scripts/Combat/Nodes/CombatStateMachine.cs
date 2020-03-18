using Godot;
using System;
using System.Collections.Generic;
using Scripts.Combat.States;
using Scripts.Combat.Mapping;
using Scripts.Characters;
using Scripts.Characters.Jobs;

namespace Scripts.Combat {
    public class CombatStateMachine : Node {
        public List<CharacterState> Units { get; private set; }
        private Dictionary<CharacterState, StateChanges> uncommitedChanges;

        public void Initilize(List<Character> NPCs, List<Character> Guests = null) {
            List<CharacterState> npcs = new List<CharacterState>();
            for (int i = 0; i < NPCs.Count; i++) {
                Units.Add(new AIState(NPCs[i], CharacterState.Type.NPC));
            }

            if (Guests != null || Guests.Count > 0) {
                for (int i = 0; i < Guests.Count; i++) {
                    Units.Add(new AIState(Guests[i], CharacterState.Type.Guest));
                }
            }
        }

        public void CommitChanges() {

        }

        public void UnitAbility(CharacterState unit, Tile target, JobAbility ability) {

        }

        public void UnitAttack(CharacterState unit, Tile target) {

        }

        public void UnitMove(CharacterState unit, Tile target) {

        }

        public void UnitItem(CharacterState unit, Tile target) {

        }

        public void AddPC(Character PC) {
            CharacterState state = new CharacterState(PC, CharacterState.Type.PC);
            foreach (var s in Units) {
                if (s.CharacterType == CharacterState.Type.NPC) {
                    ((AIState)s).AddAggroTarget(state);
                }
            }
        }

        public void RemovePC(CharacterState PC) {
            Units.Remove(PC);
            foreach (var s in Units) {
                if (s.CharacterType == CharacterState.Type.NPC) {
                    ((AIState)s).RemoveAggroTarget(PC);
                }
            }
        }

        public void AddNPC(Character NPC) {
            CharacterState state = new AIState(NPC, CharacterState.Type.NPC);
            foreach(var s in Units){
                if(s.CharacterType == CharacterState.Type.Guest){
                    ((AIState)s).AddAggroTarget(state);
                }
            }
        }

        public void RemoveNPC(CharacterState NPC) {
            Units.Remove(NPC);
            foreach (var s in Units) {
                if (s.CharacterType == CharacterState.Type.Guest) {
                    ((AIState)s).RemoveAggroTarget(NPC);
                }
            }
        }

        public void AddGuest(Character Guest) {
            CharacterState state = new CharacterState(Guest, CharacterState.Type.PC);
            foreach (var s in Units) {
                if (s.CharacterType == CharacterState.Type.NPC) {
                    ((AIState)s).AddAggroTarget(state);
                }
            }
        }

        public void RemoveGuest(CharacterState Guest) {
            Units.Remove(Guest);
            foreach (var s in Units) {
                if (s.CharacterType == CharacterState.Type.NPC) {
                    ((AIState)s).RemoveAggroTarget(Guest);
                }
            }
        }
    }
}