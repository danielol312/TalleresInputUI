using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ToolTip : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public Transform parentAfterClick;
    [SerializeField] private GameObject toolTip;
    [SerializeField] TMP_Text name;
    [SerializeField] TMP_Text category;
    [SerializeField] TMP_Text damage;
    [SerializeField] TMP_Text information;
    public void IniciatializeToolTip(DragableItem dragableItem)
    {
        name.text = dragableItem.itemName;
        category.text = dragableItem.category.ToString();
        damage.text = "Damage: "+dragableItem.damage.ToString();
        information.text = "'" + dragableItem.information+ "'";
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //toolTip.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("has entered");
        toolTip.SetActive(true);
        parentAfterClick = transform.parent;// stores the item slot where it was dragged from 
        transform.SetParent(transform.root);// sets the transform to the root parent;
        transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("has exit");
        toolTip.SetActive(false);
        transform.SetParent(parentAfterClick);
    }
}
