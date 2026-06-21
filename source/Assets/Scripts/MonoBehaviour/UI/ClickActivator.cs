using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickActivator : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] List<GameObject> _objectsToToggle;

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach(var obj in _objectsToToggle)
        {
            obj.SetActive(!(obj.activeSelf));
        }
    }
}
