using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private Image imageComponent;
    private RectTransform rectTransform;
    private RectTransform dragParent;
    private Vector2 dragOffset;
    [SerializeField] private bool instantiateVisual = true;
    private Vector3 offset;

    [Header("Movement")]
    [SerializeField] private float moveSpeedLimit = 50;

    [Header("Selection")]
    public bool selected;
    public float selectionOffset = 50;
    private float pointerDownTime;
    private float pointerUpTime;

    [Header("Visual")]

    [Header("States")]
    public bool isHovering;
    public bool isDragging;
    [HideInInspector] public bool wasDragged;

    [Header("Events")]
    [HideInInspector] public UnityEvent<Card> PointerEnterEvent;
    [HideInInspector] public UnityEvent<Card> PointerExitEvent;
    [HideInInspector] public UnityEvent<Card, bool> PointerUpEvent;
    [HideInInspector] public UnityEvent<Card> PointerDownEvent;
    [HideInInspector] public UnityEvent<Card> BeginDragEvent;
    [HideInInspector] public UnityEvent<Card> EndDragEvent;
    [HideInInspector] public UnityEvent<Card, bool> SelectEvent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        dragParent = transform.parent as RectTransform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDragEvent.Invoke(this);
        isDragging = true;
    
        if (rectTransform != null && dragParent != null &&
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                dragParent, eventData.position, eventData.pressEventCamera, out Vector2 pointerPosition))
        {
            dragOffset = (Vector2)rectTransform.localPosition - pointerPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (rectTransform == null || dragParent == null ||
            !RectTransformUtility.ScreenPointToLocalPointInRectangle(
                dragParent, eventData.position, eventData.pressEventCamera, out Vector2 pointerPosition))
        {
            return;
        }

        Vector2 position = pointerPosition + dragOffset;
        rectTransform.localPosition = new Vector3(position.x, position.y, rectTransform.localPosition.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EndDragEvent.Invoke(this);
        isDragging = false;
    }
}
