using System;

public class WeaponFactory
{
    public Weapon CreateWeapon(string weaponTypeName, string weaponRarityString, string weaponName)
    {
        Type weaponType = Type.GetType(weaponTypeName);
        WeaponRarity weaponRarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), weaponRarityString);
        Weapon newWeapon = (Weapon)Activator.CreateInstance(weaponType, new object[] { weaponRarity, weaponName });
        return newWeapon;
    }
}