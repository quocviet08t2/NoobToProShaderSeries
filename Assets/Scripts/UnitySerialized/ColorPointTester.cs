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

    public class ColorPointTester : MonoBehaviour
    {
        public ColorPoint point;
        public ColorPoint[] points;
        public Vector3 vector;
        public Vector3[] vectors;
    }
}
