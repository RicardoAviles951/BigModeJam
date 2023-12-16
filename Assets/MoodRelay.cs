using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoodRelay : MonoBehaviour
{
    private VisualElement root;
    private Label moodName;
    private StyleColor moodColor;
    

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        moodName = root.Q<Label>("Mood_Text");
       
    }
    private void OnEnable()
    {
        AbilityManager.MoodChanged += ChangeText;
    }


    private void OnDisable()
    {
        AbilityManager.MoodChanged -= ChangeText;
    }

    public void ChangeText(MoodInfo moodInfo)
    {
        moodName.text = moodInfo.Name;
        moodName.style.color = moodInfo.MoodColor;
        moodName.style.unityFont = moodInfo.Style;


    }
    
}
