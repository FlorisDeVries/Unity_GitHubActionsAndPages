using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

namespace _Common.Extensions
{
    public static class UIDocumentExtensions
    {
        /// <summary>
        /// Creates a new VisualElement and adds it to the rootElement
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="id">Name of the new element, will also be added as a class</param>
        /// <param name="classes">List of all classes to be added</param>
        /// <returns>The created element</returns>
        public static VisualElement Create(this VisualElement rootElement, string id = "", bool visible = true,
            params string[] classes)
        {
            return rootElement.Create<VisualElement>(id, visible, classes);
        }

        /// <summary>
        /// Creates a new VisualElement of type T and adds it to the rootElement
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="id">Name of the new element, will also be added as a class</param>
        /// <param name="classes">List of all classes to be added</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The created element</returns>
        public static T Create<T>(this VisualElement rootElement, string id = "", bool visible = true,
            params string[] classes)
            where T : VisualElement, new()
        {
            var element = new T();
            element.AddToClassList(id);
            foreach (var newClass in classes)
            {
                element.AddToClassList(newClass);
            }

            element.name = id + (visible ? " visible" : " hidden");
            element.pickingMode = visible ? PickingMode.Position : PickingMode.Ignore;

            rootElement.Add(element);
            return element;
        }

        public static VisualElement SetColor(this VisualElement element, Color color, float alpha = 1f)
        {
            var leftBackgroundColor = color;
            leftBackgroundColor.a = alpha;
            element.style.backgroundColor = leftBackgroundColor;

            return element;
        }

        public static void SetText(this Label label, string text, FontAsset font = null, Color color = default)
        {
            label.text = text;
            label.style.color = color;

            if (font)
            {
                label.style.unityFontDefinition = new StyleFontDefinition(font);
            }
        }
    }
}