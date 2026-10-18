using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Item : MonoBehaviour, IPointerClickHandler
{
    bool isBought = false;
    // get the component of the item and change the color of the item to indicate it has been bought
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
    void Update()
    {
        if (isBought == true)
        {
            // Change the color of the item to indicate it has been bought
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            // Change the color of the item to indicate it has not been bought
            GetComponent<Image>().color = Color.red;
        }
    }
}
