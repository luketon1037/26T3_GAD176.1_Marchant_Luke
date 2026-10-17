using UnityEngine;
using UnityEngine.EventSystems;
public class Item : MonoBehaviour, IPointerClickHandler
{
    bool isBought = false;
    [SerializeField] private float costOfItem;
    [SerializeField] private GoldSystem GoldSystemReference;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (isBought == false && GoldSystemReference.totalGold >= costOfItem)
                {
                    GoldSystemReference.totalGold -= costOfItem;
                    isBought = true;
                }
            }
        if (eventData.button == PointerEventData.InputButton.Right)
            {
                if (isBought == true)
                {
                    GoldSystemReference.totalGold += 0.5f * costOfItem;
                    isBought = false;
                }
            }
    }

}
