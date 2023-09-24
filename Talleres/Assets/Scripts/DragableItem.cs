using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    Image image;

    [HideInInspector] public string itemName;
    [HideInInspector] public Sprite itemIcon;
    [HideInInspector] public ItemCategory category;
    [HideInInspector] public string information;
    [HideInInspector] public int damage;

    private void Awake()
    {
        image= GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;// stores the item slot where it was dragged from 
        transform.SetParent(transform.root);// sets the transform to the root parent;
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
    public void InitializeItem(string itemName, Sprite itemIcon, ItemCategory category, string information, int damage)
    {
        this.itemName = itemName;
        this.itemIcon = itemIcon;
        image.sprite= itemIcon;
        this.category = category;
        this.information = information;
        this.damage = damage;
    }
}
