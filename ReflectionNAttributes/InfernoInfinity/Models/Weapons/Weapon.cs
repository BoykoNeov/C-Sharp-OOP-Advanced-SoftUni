using System.Linq;

public abstract class Weapon
{
    private int minDamage;
    private int maxDamage;

    protected Weapon(int minDamage, int maxDamage, int socketsCount, WeaponRarity rarity, string weaponName)
    {
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;

        this.Rarity = rarity;
        this.Sockets = new IWeaponSocketInsertable[socketsCount];

        this.Name = weaponName;
    }

    public string Name { get; protected set; }

    public int MinDamage
    {
        get
        {
            int damageWithRarityBonus = this.minDamage * (int)this.Rarity;
            int bonusFromStrength = 2 * this.StrengthBonus;
            int bonusFromAgility = 1 * this.AgilityBonus;
            int result = damageWithRarityBonus + bonusFromStrength + AgilityBonus;
            return result;
        }

        protected set => minDamage = value;
    }

    public int MaxDamage
    {
        get
        {
            int damageWithRarityBonus =  this.maxDamage * (int)this.Rarity;
            int bonusFromStrength = 3 * this.StrengthBonus;
            int bonusFromAgility = 4 * this.AgilityBonus;
            int result = damageWithRarityBonus + bonusFromStrength + bonusFromAgility;
            return result;
        }

        protected set => maxDamage = value;
    }

    public WeaponRarity Rarity { get; private set; }

    public int StrengthBonus
    {
        get
        {
            int bonusFromSockets = 0;

            foreach (IWeaponSocketInsertable item in this.Sockets)
            {
                if (item == null)
                {
                    continue;
                }

                bonusFromSockets += item.StrengthBonus;
            }

            return bonusFromSockets;
        }
    }

    public int AgilityBonus
    {
        get
        {
            int bonusFromSockets = 0;

            foreach (IWeaponSocketInsertable item in this.Sockets)
            {
                if (item == null)
                {
                    continue;
                }

                bonusFromSockets += item.AgilityBonus;
            }

            return bonusFromSockets;
        }
    }

    public int VitalityBonus
    {
        get
        {
            int bonusFromSockets = 0;

            foreach (IWeaponSocketInsertable item in this.Sockets)
            {
                if (item == null)
                {
                    continue;
                }

                bonusFromSockets += item.VitalityBonus;
            }

            return bonusFromSockets;
        }

    }

    public void InsertIntoSocket(int socketNumber, IWeaponSocketInsertable item)
    {
        if (socketNumber > this.Sockets.Length - 1 || socketNumber < 0)
        {
            return;
        }
        else
        {
            this.Sockets[socketNumber] = item;
        }
    }

    public void RemoveFromSocket(int socketNumber)
    {
        if (socketNumber > this.Sockets.Length - 1 || socketNumber < 0)
        {
            return;
        }
        else
        {
            this.Sockets[socketNumber] = null;
        }
    }

    public IWeaponSocketInsertable[] Sockets { get; protected set; }

    public override string ToString()
    {
        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.StrengthBonus} Strength, +{this.AgilityBonus} Agility, +{this.VitalityBonus} Vitality";
    }
}