using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ChildMaskAnchor : MonoBehaviour
{
    [SerializeField] RectTransform targetParent;
    RectTransform thisRectTransform;
    void Awake()
    {
        thisRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition(targetParent);
    }

    void SetPosition(RectTransform targetTransform)
    {
        thisRectTransform.offsetMin = new Vector2(-targetTransform.offsetMin.x,-targetTransform.offsetMin.y);
        thisRectTransform.offsetMax = new Vector2(-targetTransform.offsetMax.x,-targetTransform.offsetMax.y);
        // thisRectTransform.position = targetTransform.position;
        // thisRectTransform.sizeDelta = targetTransform.sizeDelta;
    }
}
