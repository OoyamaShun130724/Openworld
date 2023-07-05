using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// �f�[�^�x�[�X�̉��Ԗڂ̃A�C�e���̃{�^���������ꂽ�����肷��
public class ShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int _id = -1; // �A�C�e����ID
    public int _cost = -1; // �A�C�e���̃R�X�g
    public Inventory _inventory; // �C���x���g���ւ̎Q��
    public ShopDataBase _dataBase; // �V���b�v�̃f�[�^�x�[�X�ւ̎Q��
    public GenerateShopItemList _gsl; // �V���b�v�A�C�e�����X�g�̐����ւ̎Q��
    public Player _player; // �v���C���[�ւ̎Q��
    InventoryButton _ib; // �C���x���g���{�^���ւ̎Q��
    [SerializeField] Button _button; // �{�^���R���|�[�l���g�ւ̎Q��

    public void Pay()
    {
        if (_player._gold >= _cost)
        {
            _player._gold -= _cost; // �R�X�g���x����
            _dataBase.UpdateGold(); // �S�[���h�̕\�����X�V����

            if (_inventory._buttonDic.Count == 0 || !(_inventory._buttonDic.ContainsKey(_id)))
            {
                // �C���x���g���ɊY���̃A�C�e�������݂��Ȃ��ꍇ�A�V�����{�^���𐶐�����
                var tmpitem = Instantiate(_button);
                tmpitem.transform.SetParent(_gsl._InventoryTarget.transform);
                _inventory._buttonDic.Add(_id, tmpitem);
                _dataBase._itemObjs[_id]._itemcount++;
                _ib = tmpitem.GetComponent<InventoryButton>();
                _ib._id = _id;
                _ib._dataBase = _dataBase;
                _ib._inventory = _inventory;
                Text str = tmpitem.GetComponentInChildren<Text>();
                str.text = _dataBase._itemObjs[_id].ItemName + "�~" + _dataBase._itemObjs[_id]._itemcount;
            }
            else
            {
                // �C���x���g���ɊY���̃A�C�e�������݂���ꍇ�A�A�C�e���̌��𑝂₷
                _dataBase._itemObjs[_id]._itemcount++;
                Text str = _inventory._buttonDic[_id].GetComponentInChildren<Text>();
                str.text = _dataBase._itemObjs[_id].ItemName + "�~" + _dataBase._itemObjs[_id]._itemcount;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _dataBase._discription.text = _dataBase._itemObjs[_id]._description; // �A�C�e���̐�����\������
        _dataBase._image.enabled = true; // �A�C�e���̉摜��\������
        _dataBase._image.sprite = _dataBase._itemObjs[_id]._sprite; // �A�C�e���̉摜��ݒ肷��
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _dataBase._discription.text = ""; // �����e�L�X�g����ɂ���
        _dataBase._image.enabled = false; // �摜���\���ɂ���
    }
}