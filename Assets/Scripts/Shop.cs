using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public string Name { get; set; }
    public string Cost { get; set; }

    // use later for when i click to purchase item
    // on item click. make it move to inventory slot

    public void SetGold(int newTotalGold)
    {
        totalGold = newTotalGold
    }

    public string GetGold()
    {
        return totalGold;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            {
                totalGold - (.5 * cost of item) = newTotalGold
            }
    }
}


