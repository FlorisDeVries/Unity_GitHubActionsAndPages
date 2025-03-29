using System.Collections.Generic;
using System.Linq;
using _Common.BaseClasses;
using UnityEngine;
using UnityEngine.UIElements;

namespace UserInput.Resources
{
    [CreateAssetMenu(fileName = "MouseData", menuName = "Project/Input/MouseData")]
    public class MouseData : ASingletonResource<MouseData>
    {
        protected override string ResourcePath => "Input/MouseData";
        
        public Vector3 WorldPosition { get; private set; }
        public Vector2 ScreenPosition { get; private set; }
        public Vector2 ScreenPositionYInverted { get; private set; }

        public GameObject CurrentlyHovering { get; private set; }

        private Dictionary<UIDocument, bool> _overUIStates = new();

        public bool CursorOverUI => _overUIStates?.Any(x => x.Value) ?? false;

        public void SetPosition(Vector3 position)
        {
            WorldPosition = position;
        }

        public void SetMouseScreenPosition(Vector2 position)
        {
            ScreenPosition = position;
            ScreenPositionYInverted = new Vector2(position.x, Screen.height - position.y);
        }

        public void SetCursorOverUIState(UIDocument document, bool overUI)
        {
            _overUIStates ??= new Dictionary<UIDocument, bool>();
            _overUIStates.TryAdd(document, overUI);
            _overUIStates[document] = overUI;
        }

        public void SetCurrentlyHovering(GameObject hovering)
        {
            CurrentlyHovering = hovering;
        }
    }
}