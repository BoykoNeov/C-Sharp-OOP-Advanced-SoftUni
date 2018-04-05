using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        Dictionary<string, Weapon> weaponsByName = new Dictionary<string, Weapon>();

        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputs = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputs[0];
            GemFactory gemFactory = new GemFactory();
            WeaponFactory weaponFactory = new WeaponFactory();

            switch (command)
            {
                case "Create":
                    string[] weaponParams = inputs[1].Split();
                    string weaponName = inputs[2];
                    string weaponRarity = weaponParams[0];
                    string weaponType = weaponParams[1];
                    Weapon newWeapon = weaponFactory.CreateWeapon(weaponType, weaponRarity, weaponName);
                    weaponsByName[weaponName] = newWeapon;
                    break;

                case "Add":
                    string[] gemParams = inputs[3].Split();
                    string gemType = gemParams[1];
                    string gemClarity = gemParams[0];

                    IWeaponSocketInsertable newItem = gemFactory.CreateGem(gemType, gemClarity);

                    string weaponToInsert = inputs[1];
                    int socketToInsertTo = int.Parse(inputs[2]);
                    weaponsByName[weaponToInsert].InsertIntoSocket(socketToInsertTo, newItem);

                    break;

                case "Remove":
                    string itemToRemoveFrom = inputs[1];
                    int socketToRemoveFrom = int.Parse(inputs[2]);
                    weaponsByName[itemToRemoveFrom].RemoveFromSocket(socketToRemoveFrom);
                    break;

                case "Print":
                    Console.WriteLine(weaponsByName[inputs[1]]);
                    break;
            }
        }
    }
}