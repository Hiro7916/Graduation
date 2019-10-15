using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Buttonのフォーカス機能
/// </summary>
public class focusScript : MonoBehaviour
{
    [SerializeField]
    private GameObject firstFocus;

    void Start()
    {
        //現在フォーカスされるButton
        EventSystem.current.SetSelectedGameObject(firstFocus);
    }

    void Update()
    {
        
    }
}
