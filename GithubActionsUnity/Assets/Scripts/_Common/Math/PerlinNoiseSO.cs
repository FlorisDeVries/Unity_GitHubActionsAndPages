using UnityEngine;

namespace _Common.Math
{
    [CreateAssetMenu(fileName = "PerlinNoiseSO", menuName = "Project/Math/Perlin Noise Settings")]
    public class PerlinNoiseSO : ScriptableObject
    {
        [SerializeField] private float _width = 40;
        [SerializeField] private float _height = 40;
        [SerializeField] private float _scale = 20;
        [Range(0.0f, 1.0f)]
        [SerializeField] private float _cutoff = .5f;

        public float Sample(float x, float y)
        {
            return Mathf.PerlinNoise(x / _width * _scale, y / _height * _scale);
        }

        public bool SampleWithCutoff(float x, float y)
        {
            var noiseSample = Mathf.PerlinNoise((float)x / _width * _scale, (float)y / _height * _scale);

            return noiseSample > _cutoff;
        }
    }
}