using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// データベースの何番目のアイテムのボタンが押されたか判定する
public class ShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int _id = -1; // アイテムのID
    public int _cost = -1; // アイテムのコスト
    public Inventory _inventory; // インベントリへの参照
    public ShopDataBase _dataBase; // ショップのデータベースへの参照
    public GenerateShopItemList _gsl; // ショップアイテムリストの生成への参照
    public Player _player; // プレイヤーへの参照
    InventoryButton _ib; // インベントリボタンへの参照
    [SerializeField] Button _button; // ボタンコンポーネントへの参照

    public void Pay()
    {
        if (_player._gold >= _cost)
        {
            _player._gold -= _cost; // コストを支払う
            _dataBase.UpdateGold(); // ゴールドの表示を更新する

            if (_inventory._buttonDic.Count == 0 || !(_inventory._buttonDic.ContainsKey(_id)))
            {
                // インベントリに該当のアイテムが存在しない場合、新しいボタンを生成する
                var tmpitem = Instantiate(_button);
                tmpitem.transform.SetParent(_gsl._InventoryTarget.transform);
                _inventory._buttonDic.Add(_id, tmpitem);
                _dataBase._itemObjs[_id]._itemcount++;
                _ib = tmpitem.GetComponent<InventoryButton>();
                _ib._id = _id;
                _ib._dataBase = _dataBase;
                _ib._inventory = _inventory;
                Text str = tmpitem.GetComponentInChildren<Text>();
                str.text = _dataBase._itemObjs[_id].ItemName + "×" + _dataBase._itemObjs[_id]._itemcount;
            }
            else
            {
                // インベントリに該当のアイテムが存在する場合、アイテムの個数を増やす
                _dataBase._itemObjs[_id]._itemcount++;
                Text str = _inventory._buttonDic[_id].GetComponentInChildren<Text>();
                str.text = _dataBase._itemObjs[_id].ItemName + "×" + _dataBase._itemObjs[_id]._itemcount;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _dataBase._discription.text = _dataBase._itemObjs[_id]._description; // アイテムの説明を表示する
        _dataBase._image.enabled = true; // アイテムの画像を表示する
        _dataBase._image.sprite = _dataBase._itemObjs[_id]._sprite; // アイテムの画像を設定する
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _dataBase._discription.text = ""; // 説明テキストを空にする
        _dataBase._image.enabled = false; // 画像を非表示にする
    }
}