using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodInfo
{
    public string Name { get; set; }
    public Color MoodColor { get; set; }
    public Font Style { get; set; }

    public MoodInfo(string name, Color moodColor, Font font)
    {
        Name = name;
        MoodColor = moodColor;
        Style = font;
    }
}
