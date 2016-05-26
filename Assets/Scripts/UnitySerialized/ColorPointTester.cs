using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace UnitySerialized
{
    [System.Serializable]
    public class ColorPoint
    {
        public Color color;
        public Vector3 position;
    }

    [System.Serializable]
    public class AudioData
    {
        public AudioData(string name)
        {
            Name = name;
        }
        [HideInInspector]
        public string Name;
        public AudioClip[] Value = null;
    }

    public class ColorPointTester : MonoBehaviour
    {
        public ColorPoint point;
        public ColorPoint[] points;
        public Vector3 vector;
        public Vector3[] vectors;

        //public List<AudioData> customList = new List<AudioData>()
        //{
        //    new AudioData("Viet"),
        //    new AudioData("Phan"),
        //    new AudioData("Kaka")
        //};
        public AudioData xxx = new AudioData("Daica");
    }
}
