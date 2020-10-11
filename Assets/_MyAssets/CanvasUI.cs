using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] GameObject nextPointButton;
    [SerializeField] GameObject toggleInfoButton;
    [SerializeField] GameObject infoPanel;
    [SerializeField] Text infoText;

    private RoutePointData currentData;
    private int currentInfoIndex;

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
        nextPointButton.GetComponent<Button>().onClick.AddListener(HideInfos);
    }

    public void ToggleNextPointButton(bool enable)
    {
        nextPointButton.SetActive(enable);
    }
    
    public void ToggleInfoButton(bool enable, RoutePointData data)
    {
        toggleInfoButton.SetActive(enable);
        currentData = data;
        currentInfoIndex = 0;
        infoText.text = currentData.infoText[currentInfoIndex];
    }

    public void NextInfo()
    {
        if (currentInfoIndex + 1 < currentData.infoText.Length)
        {
            currentInfoIndex++;
            infoText.text = currentData.infoText[currentInfoIndex];
        }
    }

    private void HideInfos()
    {
        toggleInfoButton.SetActive(false);
        infoPanel.SetActive(false);
    }
}
