using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] GameObject btn;
    void Awake()
    {
        btn.transform.GetComponent<Button>().onClick.AddListener(ExitGame);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
