using DungeonExplorer;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DungeonExplorer
{
    public class Inventory : ICollect
    {
        public Player Player { get; set; }
        public int WepInvSize { get; }
        public int PotInvSize { get; }
        public Weapon[] WeaponInv { get; set; }
        public Potion[] PotionInv { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Weapon EmptyWeapon { get; set; }
        public Potion EmptyPotion { get; set; }
        public Inventory(int wepInvSize, int potInvSize, Player player)
        {
            this.WepInvSize = wepInvSize;
            this.PotInvSize = potInvSize;
            this.Player = player;

            WeaponInv = new Weapon[wepInvSize];
            PotionInv = new Potion[potInvSize];

            EmptyWeapon = ItemCatalogue.Quality_0_Items.FirstOrDefault(x => x.Name == "[EMPTY]" && x is Weapon) as Weapon;
            EmptyPotion = ItemCatalogue.Quality_0_Items.FirstOrDefault(x => x.Name == "[EMPTY]" && x is Potion) as Potion;

            for (int i = 0; i < WepInvSize; i++)
            {
                WeaponInv[i] = EmptyWeapon;
            }
            for (int i = 0; i < PotInvSize; i++)
            {
                PotionInv[i] = EmptyPotion;
            }

            Item defaultWeapon = ItemCatalogue.Quality_0_Items.FirstOrDefault(x => x.Name == "Rusty Dagger" && x is Weapon) as Weapon;
            EquippedWeapon = defaultWeapon as Weapon;

            Item defaultPotion = ItemCatalogue.Quality_0_Items.FirstOrDefault(x => x.Name == "Tiny Health Potion" && x is Potion) as Potion;
            PotionInv[0] = (Potion)defaultPotion;
        }

        public void EngageInventory()
        {
            Console.WriteLine(Player.Name + " Opens their inventory...\n");

            bool invEngaged = true;
            while (invEngaged == true)
            {
                ShowEquippedWeapon();
                ShowWeaponInventory();
                ShowPotionInventory();

                Console.WriteLine("----------------------");
                Console.WriteLine("What would you like to do with your items? [1/2/3/4/5/6]\n" +
                    "1. Inspect an item\n" +
                    "2. Equip a weapon\n" +
                    "3. Drink a potion\n" +
                    "4. Discard an item\n" +
                    "5. Sort inventory\n" +
                    "6. Exit inventory\n");

                bool isChoosing = true;
                while (isChoosing == true)
                {
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            isChoosing = false;
                            Inspect();
                            break;

                        case "2":
                            isChoosing = false;
                            EquipWeapon();
                            break;

                        case "3":
                            isChoosing = false;
                            DrinkPotion();
                            break;

                        case "4":
                            isChoosing = false;
                            Discard();
                            break;

                        case "5":
                            isChoosing = false;
                            SortInventory();
                            break;

                        case "6":
                            isChoosing = false;
                            invEngaged = false;

                            Console.WriteLine(Player.Name + " closes their inventory...\n");
                            break;

                        default:
                            Console.WriteLine("Invalid input, try again.\n");
                            break;
                    }
                }
            }
        }

        public void ShowEquippedWeapon()

        {
            Console.WriteLine("---Equipped Weapon---");
            Console.WriteLine("<<<[" + EquippedWeapon.Name + "]>>>");

            Console.WriteLine(" <Quality: " + EquippedWeapon.Quality + ">");
            Console.WriteLine(" <Damage: " + EquippedWeapon.Damage + ">");
            Console.WriteLine(" <Speed: " + EquippedWeapon.Speed + ">");
        }

        public void ShowWeaponInventory()
        {
            Console.WriteLine("---Weapon Inventory---");
            for (int i = 0; i < WeaponInv.Length; i++)
            {
                Console.WriteLine("- " + WeaponInv[i].Name);
            }
        }

        public void ShowPotionInventory()
        {
            Console.WriteLine("---Potion Inventory---");
            for (int i = 0; i < PotionInv.Length; i++)
            {
                Console.WriteLine("- " + PotionInv[i].Name);
            }
        }

        public void Inspect()
        {

            Console.WriteLine("Which item would you like to inspect?\n");
            ShowWeaponInventory();
            ShowPotionInventory();
            string choice = Console.ReadLine().ToLower();

            Item searchForWeapon = WeaponInv.FirstOrDefault(x => x.Name.ToLower() == choice);
            Item searchForPotion = PotionInv.FirstOrDefault(x => x.Name.ToLower() == choice);


            if (searchForWeapon != null && searchForWeapon is Weapon && searchForWeapon.Name != "[EMPTY]")
            {
                InspectWeapon(searchForWeapon);
            }
            else if (searchForPotion != null && searchForPotion is Potion && searchForPotion.Name != "[EMPTY]")
            {
                InspectPotion(searchForPotion);
            }
            else if ((searchForPotion != null || searchForWeapon != null) && (searchForWeapon.Name == "[EMPTY]" || searchForPotion.Name == "[EMPTY]"))
            {
                Console.WriteLine("Cannot inspect an empty inventory space...\n");
            }
            else
            {
                Console.WriteLine("That item is not in your inventory...\n");
            }



            bool choosing = true;
            while (choosing == true)
            {
                Console.WriteLine("Will you inspect another item? [Y/N]");

                string yesOrNo = Console.ReadLine().ToLower();
                switch (yesOrNo)
                {
                    case "y":
                        choosing = false;
                        Inspect();
                        break;

                    case "n":
                        choosing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again...\n");
                        break;
                }
            }
        }

        public void InspectWeapon(Item searchForWeapon)
        {
            Weapon searchedWeapon = searchForWeapon as Weapon;

            Console.WriteLine("Name: " + searchedWeapon.Name);
            Console.WriteLine("Quality: " + searchedWeapon.Quality);
            Console.WriteLine("Damage: " + searchedWeapon.Damage);
            Console.WriteLine("Speed: " + searchedWeapon.Speed);
        }

        public void InspectPotion(Item searchForPotion)
        {
            Potion searchedPotion = searchForPotion as Potion;

            Console.WriteLine("Name: " + searchedPotion.Name);
            Console.WriteLine("Quality: " + searchedPotion.Quality);
            Console.WriteLine("Healing Amount: " + searchedPotion.HealingAmount);
        }

        public void EquipWeapon()
        {

            Console.WriteLine("Which weapon do you want to equip?\n");

            ShowWeaponInventory();
            string choice = Console.ReadLine().ToLower();
            Weapon searchedWeapon = WeaponInv.FirstOrDefault(x => x.Name.ToLower() == choice);

            if (searchedWeapon != null && searchedWeapon.Name != "[EMPTY]")
            {
                Weapon temp = EquippedWeapon as Weapon;
                int itemLocation = Array.IndexOf(WeaponInv, searchedWeapon);

                WeaponInv[itemLocation] = temp;
                EquippedWeapon = searchedWeapon;

    
                Console.WriteLine(Player.Name + " now wields the " + EquippedWeapon.Name + " as their weapon.\n");
            }
            else if (searchedWeapon != null && searchedWeapon.Name == "[EMPTY]")
            {
                Console.WriteLine("Cannot equip an empty inventory space...\n");
            }
            else
            {
                Console.WriteLine("That item is not in your inventory...\n");
            }
        }

        public void DrinkPotion()
        {
            // Ask the player which potion they want to drink

            Console.WriteLine("Which potion do you want to drink?\n");

            ShowPotionInventory();
            string choice = Console.ReadLine().ToLower();
            Potion searchedPotion = PotionInv.FirstOrDefault(x => x.Name.ToLower() == choice);

            // Check to see if their choice is valid

            if (searchedPotion != null && searchedPotion.Name != "[EMPTY]")
            {
                // If it's a valid choice, add potion's healing amount to player's health
                Player.Health = Player.Health + searchedPotion.HealingAmount;

                // Get rid of the potion once it has been consumed
                int searchedPotionPosition = Array.IndexOf(PotionInv, searchedPotion);
                PotionInv[searchedPotionPosition] = EmptyPotion;

                //report this information to the player 
                Console.WriteLine(Player.Name + " drank the " + searchedPotion.Name + ", they recovered " + searchedPotion.HealingAmount + " health points.\n");
                Console.WriteLine(Player.Name + " now has " + Player.Health + " health points.");
            }
            else if (searchedPotion != null && searchedPotion.Name == "[EMPTY]")
            {
                Console.WriteLine("Cannot drink an empty inventory space...\n");
            }
            else
            {
                Console.WriteLine("That item is not in your inventory...\n");
            }

            // Ask the player if they want another potion

            bool choosing = true;
            while (choosing == true)
            {
                Console.WriteLine("Will you drink another potion? [Y/N]");

                string yesOrNo = Console.ReadLine();
                switch (yesOrNo)
                {
                    case "y":
                        choosing = false;
                        DrinkPotion();
                        break;

                    case "n":
                        choosing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again...\n");
                        break;
                }
            }
        }

        public void Discard()
        {

            Console.WriteLine("Which item would you like to discard?\n");
            ShowWeaponInventory();
            ShowPotionInventory();
            string choice = Console.ReadLine().ToLower();

            Item searchForWeapon = WeaponInv.FirstOrDefault(x => x.Name.ToLower() == choice);
            Item searchForPotion = PotionInv.FirstOrDefault(x => x.Name.ToLower() == choice);


            if (searchForWeapon != null && searchForWeapon is Weapon && searchForWeapon.Name != "[EMPTY]")
            {
                DiscardWeapon(searchForWeapon);
            }

            else if (searchForPotion != null && searchForPotion is Potion && searchForPotion.Name != "[EMPTY]")
            {
                DiscardPotion(searchForPotion);
            }

            else if ((searchForPotion != null || searchForWeapon != null) && (searchForWeapon.Name == "[EMPTY]" || searchForPotion.Name == "[EMPTY]"))
            {
                Console.WriteLine("Cannot discard an empty inventory space...\n");
            }

            else
            {
                Console.WriteLine("That item is not in your inventory...\n");
            }

            // Ask the player if they want to discard another item
            bool choosing = true;
            while (choosing == true)
            {
                Console.WriteLine("Will you discard another item? [Y/N]");

                string yesOrNo = Console.ReadLine().ToLower();
                switch (yesOrNo)
                {
                    case "y":
                        choosing = false;
                        Discard();
                        break;

                    case "n":
                        choosing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again...\n");
                        break;
                }
            }
        }

        public void DiscardWeapon(Item searchForWeapon)
        {
            int searchedWeaponPosition = Array.IndexOf(WeaponInv, searchForWeapon);
            WeaponInv[searchedWeaponPosition] = EmptyWeapon;

            Console.WriteLine(Player.Name + " has discarded their " + searchForWeapon.Name + ".");
        }

        public void DiscardPotion(Item searchForPotion)
        {
            int searchedPotionPosition = Array.IndexOf(PotionInv, searchForPotion);
            PotionInv[searchedPotionPosition] = EmptyPotion;

            Console.WriteLine(Player.Name + " has discarded their " + searchForPotion.Name + ".");
        }

        public void SortInventory()
        {
            Console.WriteLine("How would you like to sort your inventory? [1/2/3/4]");
            Console.WriteLine("1. By Name\n2. By Quality\n3. By Damage [Weapons] & By Health Healed [Potions] \n4. By Speed [Weapons] & By Health Healed [Potions]");

            bool choosing = true;
            while (choosing == true)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        choosing = false;

                        var sortedWeapons_N = WeaponInv.OrderBy(n => n.Name).Where(n => n.Name != "[EMPTY]");
                        var sortedPotions_N = PotionInv.OrderBy(n => n.Name).Where(n => n.Name != "[EMPTY]");

                        List<Weapon> tempWeapons_N = sortedWeapons_N.ToList();
                        List<Potion> tempPotions_N = sortedPotions_N.ToList();

                        if (tempWeapons_N.Count < WepInvSize)
                        {
                            for (int i = tempWeapons_N.Count; i < WepInvSize; i++)
                            {
                                tempWeapons_N.Add(EmptyWeapon);
                            }
                            WeaponInv = tempWeapons_N.ToArray();
                        }
                        else
                        {
                            WeaponInv = tempWeapons_N.ToArray();
                        }

                        if (tempPotions_N.Count < PotInvSize)
                        {
                            for (int i = tempPotions_N.Count; i < PotInvSize; i++)
                            {
                                tempPotions_N.Add(EmptyPotion);
                            }
                            PotionInv = tempPotions_N.ToArray();
                        }
                        else
                        {
                            PotionInv = tempPotions_N.ToArray();
                        }

                        Console.WriteLine("Items sorted by their name.");
                        break;

                    case "2":
                        choosing = false;

                        var sortedWeapons_Q = WeaponInv.OrderBy(n => n.Quality).Where(n => n.Name != "[EMPTY]");
                        var sortedPotions_Q = PotionInv.OrderBy(n => n.Quality).Where(n => n.Name != "[EMPTY]");

                        List<Weapon> tempWeapons_Q = sortedWeapons_Q.ToList();
                        List<Potion> tempPotions_Q = sortedPotions_Q.ToList();

                        if (tempWeapons_Q.Count < WepInvSize)
                        {
                            for (int i = tempWeapons_Q.Count; i < WepInvSize; i++)
                            {
                                tempWeapons_Q.Add(EmptyWeapon);
                            }
                            WeaponInv = tempWeapons_Q.ToArray();
                        }
                        else
                        {
                            WeaponInv = tempWeapons_Q.ToArray();
                        }

                        if (tempPotions_Q.Count < PotInvSize)
                        {
                            for (int i = tempPotions_Q.Count; i < PotInvSize; i++)
                            {
                                tempPotions_Q.Add(EmptyPotion);
                            }
                            PotionInv = tempPotions_Q.ToArray();
                        }
                        else
                        {
                            PotionInv = tempPotions_Q.ToArray();
                        }

                        Console.WriteLine("Items have been sorted by their quality.");
                        break;

                    case "3":
                        choosing = false;

                        var sortedWeapons_DH = WeaponInv.OrderBy(n => n.Damage).Where(n => n.Name != "[EMPTY]");
                        var sortedPotions_DH = PotionInv.OrderBy(n => n.HealingAmount).Where(n => n.Name != "[EMPTY]");

                        List<Weapon> tempWeapons_DH = sortedWeapons_DH.ToList();
                        List<Potion> tempPotions_DH = sortedPotions_DH.ToList();

                        if (tempWeapons_DH.Count < WepInvSize)
                        {
                            for (int i = tempWeapons_DH.Count; i < WepInvSize; i++)
                            {
                                tempWeapons_DH.Add(EmptyWeapon);
                            }
                            WeaponInv = tempWeapons_DH.ToArray();
                        }
                        else
                        {
                            WeaponInv = tempWeapons_DH.ToArray();
                        }

                        if (tempPotions_DH.Count < PotInvSize)
                        {
                            for (int i = tempPotions_DH.Count; i < PotInvSize; i++)
                            {
                                tempPotions_DH.Add(EmptyPotion);
                            }
                            PotionInv = tempPotions_DH.ToArray();
                        }
                        else
                        {
                            PotionInv = tempPotions_DH.ToArray();
                        }


                        Console.WriteLine("Weapons have been sorted by their damage, potions have been sorted by the health they heal.");
                        break;

                    case "4":
                        choosing = false;

                        var sortedWeapons_SH = WeaponInv.OrderBy(n => n.Speed).Where(n => n.Name != "[EMPTY]");
                        var sortedPotions_SH = PotionInv.OrderBy(n => n.HealingAmount).Where(n => n.Name != "[EMPTY]");

                        List<Weapon> tempWeapons_SH = sortedWeapons_SH.ToList();
                        List<Potion> tempPotions_SH = sortedPotions_SH.ToList();

                        if (tempWeapons_SH.Count < WepInvSize)
                        {
                            for (int i = tempWeapons_SH.Count; i < WepInvSize; i++)
                            {
                                tempWeapons_SH.Add(EmptyWeapon);
                            }
                            WeaponInv = tempWeapons_SH.ToArray();
                        }
                        else
                        {
                            WeaponInv = tempWeapons_SH.ToArray();
                        }

                        if (tempPotions_SH.Count < PotInvSize)
                        {
                            for (int i = tempPotions_SH.Count; i < PotInvSize; i++)
                            {
                                tempPotions_SH.Add(EmptyPotion);
                            }
                            PotionInv = tempPotions_SH.ToArray();
                        }
                        else
                        {
                            PotionInv = tempPotions_SH.ToArray();
                        }


                        Console.WriteLine("Weapons have been sorted by their speed, potions have been sorted by the health they heal.");
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again...\n");
                        break;
                }
            }
        }

        public void CollectItem(Item collectedItem)
        {
            bool choosing = true;
            while (choosing == true)
            {
                Console.WriteLine("Do you want to add the " + collectedItem.Name + " your inventory? [Y/N]");
                string yesOrNo = Console.ReadLine().ToLower();
                switch (yesOrNo)
                {
                    case "y":
                        choosing = false;
                        AddItemToInv(collectedItem);
                        break;

                    case "n":
                        choosing = false;
                        Console.WriteLine(Player.Name + " discarded the " + collectedItem.Name + ".");
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again...\n");
                        break;
                }
            }
        }

        public void AddItemToInv(Item collectedItem)
        {
            if (collectedItem is Weapon)
            {
                AddWeapon(collectedItem);
            }
            else if (collectedItem is Potion)
            {
                AddPotion(collectedItem);
            }
            else
            {
                Console.WriteLine("Something went wrong, item is an unrecognised type...");
            }
        }

        public void AddWeapon(Item collectedItem)
        {
            Weapon searchForEmpty = WeaponInv.FirstOrDefault(x => x.Name == "[EMPTY]");

            if (searchForEmpty == null)
            {
                Console.WriteLine(Player.Name + "'s weapon inventory is full, will you discard a weapon to store the " + collectedItem.Name + "? [Y/N]");

                bool choosing = true;
                while (choosing == true)
                {
                    string yesOrNo = Console.ReadLine().ToLower();
                    switch (yesOrNo)
                    {
                        case "y":
                            choosing = false;

                            bool isChoosing = true;
                            while (isChoosing == true)
                            {
                                Console.WriteLine("Which item weapon will you discard to store the " + collectedItem.Name + "?");
                                ShowWeaponInventory();

                                string choice = Console.ReadLine().ToLower();
                                Weapon searchForWeapon = WeaponInv.FirstOrDefault(x => x.Name.ToLower() == choice);

                                if (searchForWeapon != null && searchForWeapon is Weapon && searchForWeapon.Name != "[EMPTY]")
                                {
                                    isChoosing = false;

                                    int searchedWeaponPosition = Array.IndexOf(WeaponInv, searchForWeapon);
                                    WeaponInv[searchedWeaponPosition] = collectedItem as Weapon;

                                    Console.WriteLine(Player.Name + " has discarded their " + searchForWeapon.Name + " to store their " + collectedItem.Name + ".");
                                }

                                else
                                {
                                    Console.WriteLine("That is not in your inventory...");
                                }
                            }
                            break;

                        case "n":
                            choosing = false;
                            Console.WriteLine(Player.Name + " discarded the " + collectedItem.Name + ".");
                            break;

                        default:
                            Console.WriteLine("Invalid input, try again...\n");
                            break;
                    }
                }
            }
            else
            {
                int firstEmptySpace = Array.IndexOf(WeaponInv, searchForEmpty);

                Weapon storeItem = collectedItem as Weapon;
                WeaponInv[firstEmptySpace] = storeItem;

                Console.WriteLine(Player.Name + " stored the " + collectedItem.Name + " in their inventory.");
            }
        }

        public void AddPotion(Item collectedItem)
        {
            Potion searchForEmpty = PotionInv.FirstOrDefault(x => x.Name == "[EMPTY]");

            if (searchForEmpty == null)
            {
                Console.WriteLine(Player.Name + "'s potion inventory is full, will you discard a potion to store the " + collectedItem.Name + "? [Y/N]");

                bool choosing = true;
                while (choosing == true)
                {
                    string yesOrNo = Console.ReadLine().ToLower();
                    switch (yesOrNo)
                    {
                        case "y":
                            choosing = false;

                            bool isChoosing = true;
                            while (isChoosing == true)
                            {
                                Console.WriteLine("Which potion will you discard to store the " + collectedItem.Name + "?");
                                ShowPotionInventory();

                                string choice = Console.ReadLine().ToLower();
                                Potion searchForPotion = PotionInv.FirstOrDefault(x => x.Name.ToLower() == choice);

                                if (searchForPotion != null && searchForPotion is Potion && searchForPotion.Name != "[EMPTY]")
                                {
                                    isChoosing = false;

                                    int searchedPotionPositon = Array.IndexOf(PotionInv, searchForPotion);
                                    PotionInv[searchedPotionPositon] = collectedItem as Potion;

                                    Console.WriteLine(Player.Name + " has discarded their " + searchForPotion.Name + " to store their " + collectedItem.Name + ".");
                                }

                                else
                                {
                                    Console.WriteLine("That is not in your inventory...");
                                }
                            }
                            break;

                        case "n":
                            choosing = false;
                            Console.WriteLine(Player.Name + " discarded the " + collectedItem.Name + ".");
                            break;

                        default:
                            Console.WriteLine("Invalid input, try again...\n");
                            break;
                    }
                }

                Console.WriteLine(Player.Name + " stored the " + collectedItem.Name + " in their inventory.");
            }
            else
            {
                int firstEmptySpace = Array.IndexOf(PotionInv, searchForEmpty);

                Potion storeItem = collectedItem as Potion;
                PotionInv[firstEmptySpace] = storeItem;

                Console.WriteLine(Player.Name + " stored the " + collectedItem.Name + " in their inventory.");
            }
        }
    }
} 