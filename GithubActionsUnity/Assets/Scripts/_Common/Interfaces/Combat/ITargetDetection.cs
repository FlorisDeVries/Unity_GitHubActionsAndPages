using System;
using UnityEngine;

namespace _Common.Interfaces.Combat
{
    public interface ITargetDetection
    {
        public bool HasTarget { get; }
        public Transform Target { get; }
        public Action OnTargetChanged { get; set; }
    }
}