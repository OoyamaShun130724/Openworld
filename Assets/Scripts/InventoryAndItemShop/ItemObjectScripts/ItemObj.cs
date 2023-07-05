using UnityEngine;
using UnityEngine.UI;
//�A�C�e���ɂ�����N���X
public abstract class ItemObj : ScriptableObject
{
    //�A�C�e�����ׂĂɕK�v�ȕϐ���񋓊e�A�C�e�����ɕK�v�ȕϐ��͌p����ɋL�ڂ���
    [Header("�A�C�e���̃v���n�u"),SerializeField] public Sprite _sprite;
    [Header("�A�C�e���̃^�C�v")] public ItemType _type;
    [Header("�l�i")] public int _cost;
    [TextArea(10, 10)] public string _description;
    [SerializeField] string _itemName;
    public int _itemcount = 0;
    public string ItemName => _itemName;
    //�^�C�v���ɕ�������Ŏg�p���̏������������\�b�h
    public abstract void UseItem();
}
//�����𕪂������A�C�e�����^�C�v���ɕ����Ēǉ����Ă���
public enum ItemType
{
    Equipment,//����
    Consumable,//����^
    Heal,//��
    PowerUP,//�p���[�A�b�v�A�C�e��
    Damage,
}

