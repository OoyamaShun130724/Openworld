using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ShopDataBase _dataBase;
    public Inventory _inventory;
    ItemObj _item;
    public int _id = -1;
    [SerializeField] Text str;
    public void PickItem()
    {
        _item = _dataBase._itemObjs[_id];        
        _item.UseItem();
        _item._itemcount--;
        if (_item._itemcount == 0)
        {
            _inventory._buttonDic.Remove(_id);
            Destroy(this.gameObject);
        }
        Text str = GetComponentInChildren<Text>();
        str.text = _item.ItemName + "Å~" + _item._itemcount;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _dataBase._discription.text = _dataBase._itemObjs[_id]._description;
        _dataBase._image.enabled = true;
        _dataBase._image.sprite = _dataBase._itemObjs[_id]._sprite;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _dataBase._discription.text = "";
        _dataBase._image.enabled = false;
    }
}
