using UnityEngine;

namespace DES.U1.Basics
{
    [CreateAssetMenu(fileName = "so_ColorPalette", menuName = "DES/Color Palette", order = 0)]
    public class ColorPalette : ScriptableObject
    {
        public Color[] colors = new Color[] { Color.cyan, Color.magenta, Color.yellow, Color.green };

        public Color Get(int index)
        {
            if (colors == null || colors.Length == 0) return Color.white;
            index = Mathf.Clamp(index, 0, colors.Length - 1);
            return colors[index];
        }
    }
}
