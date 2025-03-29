using System;
using Combat;
using UnityEngine;

namespace _Common.Abilities
{
    [Serializable]
    public class AbilityInfo
    {
        /// <summary>
        /// Base damage value of the attack
        /// </summary>
        [Header("Damage")]
        [SerializeField]
        private float _strength;

        /// <summary>
        /// What type of damage is dealt
        /// </summary>
        [SerializeField]
        private AbilityType _abilityType;

        /// <summary>
        /// How long the ability cannot be used after being used
        /// </summary>
        [SerializeField]
        private float _abilityCooldown;

        public float Strength => _strength;
        public float AbilityCooldown => _abilityCooldown;
        public AbilityType AbilityType => _abilityType;

        public AbilityInfo(float strength, AbilityType abilityType = AbilityType.Physical)
        {
            _strength = strength;
            _abilityType = abilityType;
        }
        
        public AbilityInfo(AbilityInfo abilityInfo)
        {
            _strength = abilityInfo._strength;
            _abilityType = abilityInfo._abilityType;
            _abilityCooldown = abilityInfo._abilityCooldown;
        }
        
        public void AddStats(AbilityInfo abilityInfo)
        {
            _strength += abilityInfo._strength;
            _abilityType = abilityInfo._abilityType;
            _abilityCooldown += abilityInfo._abilityCooldown;
        }
        
    }
}