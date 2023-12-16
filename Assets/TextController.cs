using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    public VisualElement root;
    public Label titleText;
    public float switchTime = 1f;

    public string text1;
    public string text2;
    // Start is called before the first frame update
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        titleText = root.Q<Label>("Title");

    }
    void Start()
    {
        DetectLevel();
        titleText.text = text1;
        
        StartCoroutine(Delay());
        StartCoroutine(Kill());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TextSwitcher()
    {
        titleText.text = text2;
    }

    IEnumerator Delay()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(switchTime);
        TextSwitcher();
    }

    private void DetectLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int index = currentScene.buildIndex;

        switch (index)
        {
            case 0: //Level 1
                text1 = "Level 1";
                text2 = "Stairway to Heaven";
                break;

            case 1: //Level 2
                text1 = "Level 2";
                text2 = "Sledgehammer";
                break;

            case 2: //Level 3 
                text1 = "Level 3";
                text2 = "Ricochet";
                break;

            default : break;
        }
    }

    IEnumerator Kill()
    {
        Debug.Log("Disabling...");
        yield return new WaitForSeconds(4);
        DisableHUD();
    }
    private void DisableHUD()
    {
        gameObject.SetActive(false);
    }
}
