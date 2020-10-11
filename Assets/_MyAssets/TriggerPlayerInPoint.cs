using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerInPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var rp = other.gameObject.GetComponent<RoutePointData>();
        if(rp)
        {
            CanvasUI.Instance.ToggleNextPointButton(true);
            CanvasUI.Instance.ToggleInfoButton(true, rp);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var rp = other.gameObject.GetComponent<RoutePointData>();
        if (rp)
        {
            CanvasUI.Instance.ToggleNextPointButton(false);
            CanvasUI.Instance.ToggleInfoButton(false, rp);
        }
    }
}
