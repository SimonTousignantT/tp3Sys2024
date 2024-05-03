using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryUi : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
    //    EventManager.GetInstance().SubscribeTo(EEvents.On_Item_Added_To_Inventory, RefreshInventory);
    //}
    //private void RefreshInventory(Dictionary<string, object> parameters)
    //{
    //    List<ItemAmountData> itemList = parameters["ItemList"] as List<ItemAmountData>;
    //    foreach(ItemAmountData item in itemList)
    //    {

    //    }
    //}


    //private void AddItem(EItemKey item)
    //{
    //    ItemAmountData amountOf = InventoryAmount.Find(x => item == x.ID);
    //    if(amountOf != null)
    //    {
    //        amountOf.Amount++;
    //    }
    //    else
    //    {
    //        amountOf = new ItemAmountData(item);
    //        InventoryAmount.Add(amountOf);
    //    }


    //}

    //Dictionary<string, object> eventParams = new Dictionary<string, object>();
    //eventParams.Add("ItemList",InventoryAmount);
    //EventManager.GetInstance().TriggerEvent(EEvents.On_Item_Added_To_Inventory, eventParams);

}
    
