using UnityEngine;
[CreateAssetMenu(fileName = "New PowerUp Object", menuName = "Inventory System/Items/PowerUp")]
public class PowerUpObject : ItemObj
{
    [SerializeField] int _powerUpOffencivePower;
    [SerializeField] int _powerUppowerUpDiffensivePower;
    public void Awake()
    {
        _type = ItemType.PowerUP;
    }
    public override void UseItem()
    {
        var player = FindObjectOfType<Player>();
        player._offencivePower = Mathf.Min(player._offencivePower+_powerUpOffencivePower,player._offenciveLimit);
        player._diffensivePower =Mathf.Min(player._diffensivePower+_powerUppowerUpDiffensivePower,player._diffenciveLimit);
    }

}
