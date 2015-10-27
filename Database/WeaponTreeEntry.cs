using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH4U_Database.Database
{
    class WeaponTreeEntry
    {
        public Weapon Weapon { get; set; }
        public List<WeaponTreeEntry> Children { get; set; }

        //Extra info that differs depending on weapon type.
        public string SpecialString
        {
            get
            {
                if (Weapon.wtype.Equals("Charge Blade") || Weapon.wtype.Equals("Switch Axe"))
                    return Weapon.phial;
                else if (Weapon.wtype.Equals("Gunlance"))
                    return Weapon.shelling_type;
                return "";
            }
        }

        public WeaponTreeEntry(Weapon w)
        {
            Weapon = w;
            Children = new List<WeaponTreeEntry>();
        }

        public static List<WeaponTreeEntry> GenerateTree(List<Weapon> weapons)
        {
            List<WeaponTreeEntry> entries = new List<WeaponTreeEntry>();
            WeaponTreeEntry currentEntry;
            Weapon currentWeapon;

            int offset = (int)weapons[0]._id;
            int parent_id;
            int abs_pos;

            for (int i = 0; i < weapons.Count; i++)
            {
                currentWeapon = weapons[i];
                currentEntry = new WeaponTreeEntry(currentWeapon);

                parent_id = (int)currentWeapon.parent_id;
                if (parent_id != 0)
                {
                    abs_pos = parent_id - offset;
                    entries[abs_pos].Children.Add(currentEntry);
                }

                //Add all entries to the list
                entries.Add(currentEntry);
            }

            //Select only the entries that do not have a parent.
            return entries;//entries.Where<WeaponTreeEntry>((e) => { return (e.Weapon.parent_id == 0); }).ToList<WeaponTreeEntry>(); 
        }

        public override string ToString()
        {
            return Weapon.ToString();
        }
    }
}
