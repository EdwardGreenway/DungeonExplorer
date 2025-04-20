using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// This interface contains the methods used in the inventory class
    /// </summary>
    interface ICollect
    {   
        void EngageInventory();

        void ShowEquippedWeapon();

        void ShowWeaponInventory();

        void ShowPotionInventory();

        void Inspect();

        void InspectWeapon(Item searchForWeapon);

        void InspectPotion(Item searchForPotion);

        void EquipWeapon();

        void DrinkPotion();

        void Discard();

        void DiscardWeapon(Item searchForWeapon);

        void DiscardPotion(Item searchForPotion);

        void SortInventory();

        void CollectItem(Item collectedItem);

        void AddItemToInv(Item collectedItem);
    }
}
