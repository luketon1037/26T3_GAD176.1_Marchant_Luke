using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public bool isHovering;
    public bool isDragging;
    [HideInInspector] public UnityEvent<Mouse> BeginDragEvent;
    [HideInInspector] public UnityEvent<Mouse> EndDragEvent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDragEvent.Invoke(this);
        isDragging = true;
    }
public void OnEndDrag(PointerEventData eventData) 
    {
        EndDragEvent.Invoke(this);
        isDragging = false;
    }
}
