using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] GameObject nextPointButton;

    #region Singleton
    private static CanvasUI instance;
    public static CanvasUI Instance
    {
        get
        {
            if (instance == null)
            {
                return FindObjectOfType<CanvasUI>();
            }
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        nextPointButton.GetComponent<Button>().onClick.AddListener(RouteManager.Instance.SetNextPoint);
        nextPointButton.GetComponent<Button>().onClick.AddListener(HideNextPointButton);
    }

    public void ShowNextPointButton()
    {
        nextPointButton.SetActive(true);
    }
    
    public void HideNextPointButton()
    {
        nextPointButton.SetActive(false);
    }
}
