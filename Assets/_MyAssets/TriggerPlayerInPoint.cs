using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerInPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Marker"))
        {
            CanvasUI.Instance.ShowNextPointButton();
        }
    }
}
