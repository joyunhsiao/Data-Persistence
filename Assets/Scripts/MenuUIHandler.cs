using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI menuRecordTextGUI;

    // Start is called before the first frame update
    void Start()
    {
        menuRecordTextGUI.text = $"Best Score: {GameDataManager.Instance.highestUserName} :{GameDataManager.Instance.highestUserScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        string inputText = inputField.text;
        GameDataManager.Instance.userName = inputText;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
