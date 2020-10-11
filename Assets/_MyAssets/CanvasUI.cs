using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] GameObject nextPointButton;
    [SerializeField] GameObject toggleInfoButton;

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
        //nextPointButton.GetComponent<Button>().onClick.AddListener(HideNextPointButton);
    }

    public void ToggleNextPointButton(bool enable)
    {
        nextPointButton.SetActive(enable);
    }
    
    public void ToggleInfoButton(bool enable, RoutePointData data)
    {
        toggleInfoButton.SetActive(enable);
    }
}
