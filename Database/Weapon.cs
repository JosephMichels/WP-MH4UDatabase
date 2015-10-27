﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH4U_Database.Database
{
    class Weapon
    {
        public int _id { get; set; }
        public int parent_id { get; set; }
        public string wtype { get; set; }
        public int creation_cost { get; set; }
        public int upgrade_cost { get; set; }
        public int attack { get; set; }
        public int max_attack { get; set; }
        public string element{get;set;}
        public int element_attack { get; set; }
        public string element_2 { get; set; }
        public int element_2_attack { get; set; }
        public string awaken { get; set; }
        public int awaken_attack { get; set; }

        public string total_element
        {
            get
            {
                if (string.IsNullOrEmpty(element))
                {
                    if (!string.IsNullOrEmpty(awaken))
                        return "(" + awaken + " " + awaken_attack + ")";
                    return "None";
                }
                else if (string.IsNullOrEmpty(element_2))
                    return element_attack + " " + element;
                else
                    return element_attack + " " + element + "/" + element_2_attack + " " + element_2;
            }
        }

        public int defense { get; set; }
        string _sharpness;
        public string sharpness 
        { 
            get{return _sharpness;}
            set
            {
                _sharpness = value;
                SetupSharpness();
            }
        }
        public string _affinity;
        public string affinity
        {
            get { return _affinity; }
            set
            {
                string s = value;
                if (s.Length == 0)
                    s = "0";
                _affinity = s + "%";
                    
            }
        }
        public string phial { get; set; }
        public string charges { get; set; }
        public int num_slots { get; set; }
        public int tree_depth { get; set; }
        public int final { get; set; }
        public string shelling_type { get; set; }

        //Variables from item
        public string item_name { get; set; }
        public string icon_name { get; set; }
        public int item_rarity { get; set; }
        public string icon_path
        {
            get
            {
                return "/Assets/icons_items/" + icon_name;
            }
        }
        //Possibly item name

        public string slots
        {
            get
            {
                switch (num_slots)
                {
                    case 0: return "---";
                    case 1: return "\u25CB--";
                    case 2: return "\u25CB\u25CB-";
                    case 3: return "\u25CB\u25CB\u25CB";
                    default: return "Error";
                }
            }
        }

        public Sharpness _defaultSharpness;
        public Sharpness DefaultSharpness { get { return _defaultSharpness; } }

        void SetupSharpness()
        {
            //Create the actual sharpness objects
            int[] s1 = new int[7];
            int[] s2 = new int[7];

            try
            {
                string[] sharpP = sharpness.Split(' ');
                string[] sharp1 = sharpP[0].Split('.');
                string[] sharp2 = sharpP[1].Split('.');

                for (int i = 0; i < sharp1.Length; i++)
                    s1[i] = int.Parse(sharp1[i]);
                for (int i = 0; i < sharp2.Length; i++)
                    s2[i] = int.Parse(sharp2[i]);
            }
            catch (Exception e)
            {
            }

            _defaultSharpness = new Sharpness();
            _defaultSharpness.Red = s1[0];
            _defaultSharpness.Orange = s1[1];
            _defaultSharpness.Yellow = s1[2];
            _defaultSharpness.Green = s1[3];
            _defaultSharpness.Blue = s1[4];
            _defaultSharpness.White = s1[5];
            _defaultSharpness.Purple = s1[6];
            //Sharpness+1
            _defaultSharpness.Red1 = s2[0];
            _defaultSharpness.Orange1 = s2[1];
            _defaultSharpness.Yellow1 = s2[2];
            _defaultSharpness.Green1 = s2[3];
            _defaultSharpness.Blue1 = s2[4];
            _defaultSharpness.White1 = s2[5];
            _defaultSharpness.Purple1 = s2[6];
        }
    }
}