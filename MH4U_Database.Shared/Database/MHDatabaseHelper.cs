using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MH4U_Database.Database
{
    class MHDatabaseHelper
    {
        static SQLiteAsyncConnection _connection;

        public MHDatabaseHelper()
        {
            InitializeConnection();
        }

        static void InitializeConnection()
        {
            //Lazy loading of the connection.
            if(_connection== null)
                _connection = new SQLiteAsyncConnection("Assets\\mh4u.db");
        }

        #region Monster Queries

        public static async Task<List<Monster>> GetAllLargeMonsters()
        {
            InitializeConnection();
            return await _connection.QueryAsync<Monster>("SELECT * FROM monsters WHERE class='Boss' ORDER BY sort_name");
        }

        public static async Task<List<Monster>> GetAllSmallMonsters()
        {
            InitializeConnection();
            return await _connection.QueryAsync<Monster>("SELECT * FROM monsters WHERE class='Minion' ORDER BY sort_name");
        }

        public static async Task<Monster> GetMonster(int id)
        {
            InitializeConnection();
            var mon = await _connection.QueryAsync<Monster>("SELECT * FROM monsters WHERE _id=?",id);
            return mon.FirstOrDefault<Monster>();
        }

        /// <summary>
        /// Gets all monsters associated with a quest.
        /// </summary>
        /// <param name="id">id of the quest.</param>
        /// <returns>List of monsters</returns>
        public static async Task<List<Monster>> GetMonstersForQuest(int id)
        {
            InitializeConnection();
            return await _connection.QueryAsync<Monster>("SELECT m._id AS _id,m.name AS name,m.icon_name AS icon_name FROM monster_to_quest LEFT OUTER JOIN monsters m ON monster_id=m._id WHERE quest_id=?", id);
        }

        #endregion

        #region Monster Damage Queries

        public static async Task<List<MonsterDamage>> GetMonsterDamageForMonster(int id)
        {
            InitializeConnection();
            return await _connection.QueryAsync<MonsterDamage>("SELECT * FROM monster_damage WHERE monster_id=?",id);
        }

        #endregion

        #region Monster Weakness Query

        public static async Task<MonsterWeakness> GetMonsterWeakness(int id)
        {
            InitializeConnection();
            var result = await _connection.QueryAsync<MonsterWeakness>("SELECT * FROM monster_weakness WHERE monster_id=?", id);
            return result.FirstOrDefault();
        }

        #endregion

        #region Monster Status Queries

        public static async Task<List<MonsterStatus>> GetMonsterStatusForMonster(int id)
        {
            InitializeConnection();
            return await _connection.QueryAsync<MonsterStatus>("SELECT status,initial,increase,max,duration,damage FROM monster_status WHERE monster_id=?", id);
        }

        #endregion

        #region Item Queries

        public static async Task<List<Item>> GetAllItems()
        {
            InitializeConnection();
            return await _connection.QueryAsyncWithPopulateAction<Item>("SELECT _id,name,type,icon_name FROM items",(row)=> {
                return new Item()
                {
                    _id = SQLite3.ColumnInt(row, 0),
                    name = SQLite3.ColumnString(row, 1),
                    type = SQLite3.ColumnString(row, 2),
                    icon_name = SQLite3.ColumnString(row,3),
                    //sub_type = SQLite3.ColumnString(row, 4)
                };
            });
        }

        public static async Task<Item> GetItem(long id)
        {
            InitializeConnection();
            var result = _connection.QueryAsync<Item>("SELECT * FROM items WHERE _id=?",id);
            List<Item> item = await result;
            return item.FirstOrDefault<Item>();
        }

        public static Item GetItemSync(long id)
        {
            SQLiteConnectionWithLock con = _connection.GetConnection();
            using (con.Lock())
            {
                return con.Query<Item>("SELECT * FROM items WHERE _id=?", id).FirstOrDefault<Item>();
            }
        }

        public static async Task<List<Item>> GetItemSearch(string q)
        {
            InitializeConnection();
            q = '%' + q + '%';
            return await _connection.QueryAsync<Item>("SELECT * FROM items WHERE name LIKE ?", q);
        }

        #endregion

        #region Weapon Queries

        public static async Task<Weapon> GetWeapon(long id)
        {
            InitializeConnection();
            string s = @"SELECT w.*,i.name AS item_name,i.rarity AS item_rarity,i.icon_name FROM weapons w JOIN items i ON i._id=w._id WHERE w._id=?";
            var weapons = await _connection.QueryAsync<Weapon>(s, id);
            return weapons.FirstOrDefault<Weapon>();
        }

        public static async Task<List<Weapon>> GetWeaponsByType(string type)
        {
            InitializeConnection();

            string vals = "w._id,w.parent_id,w.wtype,w.attack,w.max_attack,w.element,w.element_attack,w.element_2,w.element_2_attack,w.awaken,w.awaken_attack,w.defense,w.affinity,w.num_slots,w.tree_depth,";

            if (type.Equals("Bow"))
                vals += "w.charges,w.coatings,w.recoil,";
            else if (type.Contains("Bowgun"))
                vals += "w.recoil,w.deviation,w.reload_speed,";
            else
                vals += "w.sharpness,";

            if (type.Equals("Hunting Horn"))
                vals += "w.horn_notes,";
            if (type.Equals("Charge Blade") || type.Equals("Switch Axe"))
                vals += "w.phial,";


            string s = @"SELECT " + vals + "i.name AS item_name,i.rarity AS item_rarity FROM weapons w JOIN items i ON i._id=w._id WHERE w.wtype=?";
            return await _connection.QueryAsync<Weapon>(s, type);
        }

        public static List<Weapon> GetWeaponParents(int id)
        {
            InitializeConnection();
            var con = _connection.GetConnection();
            using (con.Lock())
            {
                int parentId = id;
                List<Weapon> weapons = new List<Weapon>();
                do
                {
                    Weapon w = con.Query<Weapon>("SELECT w._id,w.creation_cost,w.parent_id,w.final,i.name AS item_name FROM weapons w LEFT OUTER JOIN items i ON w._id=i._id WHERE w._id=?", parentId).FirstOrDefault();
                    if (w == null)
                    {
                        if (weapons.Count > 0) weapons[weapons.Count - 1].tree_depth = -1; //This a hack to mark the child most element for XAML binding
                        return weapons;
                    }

                    parentId = w.parent_id;
                    weapons.Insert(0, w);   //Insert to the front of the list

                } while (true);
            }
        }

        public static async Task<List<Weapon>> GetWeaponChildren(int id)
        {
            InitializeConnection();

            string q = "SELECT w._id,w.creation_cost,i.name AS item_name FROM weapons w LEFT OUTER JOIN items i ON w._id = i._id WHERE w.parent_id=?";
            return await _connection.QueryAsync<Weapon>(q, id);
        }

        #endregion

        #region Horn Melody Query

        public static async Task<List<HornMelody>> GetHornMelodies(string notes)
        {
            InitializeConnection();
            return await _connection.QueryAsync<HornMelody>("SELECT notes,song,effect1,effect2,duration,extension FROM horn_melodies WHERE notes=?", notes);
        }

        #endregion

        #region Armor Queries

        public static async Task<Armor> GetArmor(int id)
        {
            InitializeConnection();
            //a - armor
            //i - item
            string s = "SELECT a.*,i.name AS item_name,i.icon_name AS icon_name,i.rarity AS rarity FROM armor a JOIN items i ON i._id=a._id WHERE a._id=?";
            var armor = await _connection.QueryAsync<Armor>(s, id);
            return armor.FirstOrDefault<Armor>(); 
        }

        //type can be "Blade","Gunner", or "Both"
        public static async Task<List<Armor>> GetArmorForHunterType(string type)
        {
            InitializeConnection();
            //a - armor
            //i - item

            //Note the query results are stripped down for performance reasons. The result of the query is used for a list
            // and all that is needed is icon,name, and slot (for grouping purposes)
            string s = "SELECT a._id,a.slot,i.name AS item_name,i.icon_name AS icon_name FROM armor a JOIN items i ON i._id=a._id WHERE a.hunter_type=?";
            return await _connection.QueryAsync<Armor>(s, type);
        }



        #endregion

        #region Hunting Rewards

        public static async Task<List<HuntingReward>> GetHuntingRewardsForMonsterRank(long id, string rank)
        {
            InitializeConnection();
            //m - monster
            //h - hunting reward
            //i - item
            string s =
            @"SELECT h._id,h.item_id,h.monster_id,h.condition,h.rank,h.percentage,h.stack_size,
            i.name AS item_name, i.icon_name AS item_icon,
            m.name AS monster_name, m.icon_name AS monster_icon
            FROM hunting_rewards h 
            LEFT OUTER JOIN monsters m ON h.monster_id=m._id
            LEFT OUTER JOIN items i ON h.item_id=i._id
            WHERE h.monster_id=" + id.ToString() + " AND h.rank='" + rank + "'";
            return await _connection.QueryAsync<HuntingReward>(s);
        }

        public static async Task<List<HuntingReward>> GetHuntingRewardsForItem(long id)
        {
            InitializeConnection();
            //m - monster
            //h - hunting reward
            //i - item
            string s =
            @"SELECT h._id,h.item_id,h.monster_id,h.condition,h.rank,h.percentage,h.stack_size,
            i.name AS item_name, i.icon_name AS item_icon,
            m.name AS monster_name, m.icon_name AS monster_icon
            FROM hunting_rewards h 
            LEFT OUTER JOIN monsters m ON h.monster_id=m._id
            LEFT OUTER JOIN items i ON h.item_id=i._id
            WHERE h.item_id=" + id.ToString();
            return await _connection.QueryAsync<HuntingReward>(s);
        }

        #endregion

        #region Quest Reward Queries

        public static async Task<List<QuestRewards>> GetQuestRewardsForItem(long id)
        {
            InitializeConnection();
            //r - quest reward
            //i - item
            //q - quest
            string s =
            @"SELECT r._id,r.quest_id,r.reward_slot,r.percentage,r.stack_size,r.item_id,
            i.name AS item_name,i.icon_name AS item_icon,
            q.name AS quest_name,q.hub AS quest_hub,q.stars AS quest_stars
            FROM quest_rewards r
            LEFT OUTER JOIN items i ON r.item_id=i._id
            LEFT OUTER JOIN quests q ON r.quest_id=q._id
            WHERE r.item_id=" + id.ToString();
            return await _connection.QueryAsync<QuestRewards>(s);
        }

        public static async Task<List<QuestRewards>> GetQuestRewardsForQuest(int id)
        {
            //SELECT qr.item_id,i.name,i.icon_name,qr.reward_slot,qr.percentage,qr.stack_size FROM quest_rewards JOIN items i ON i._id=qr.item_id WHERE qr.quest_id=?
            InitializeConnection();
            return await _connection.QueryAsync<QuestRewards>("SELECT qr.item_id,i.name AS item_name,i.icon_name AS item_icon,qr.reward_slot,qr.percentage,qr.stack_size FROM quest_rewards qr JOIN items i ON i._id=qr.item_id WHERE qr.quest_id=?", id);
        }

        #endregion

        #region Quest Queries

        /// <summary>
        /// Gets all events for a given hub.
        /// </summary>
        /// <param name="hub">Needs to be "Caravan","Guild", or "Event"</param>
        /// <returns></returns>
        public static async Task<List<Quest>> GetAllQuestsForHub(string hub)
        {
            InitializeConnection();
            return await _connection.QueryAsync<Quest>("SELECT _id,name,stars,type FROM quests WHERE hub=? AND name!=\"\" ORDER BY stars", hub);
        }

        /// <summary>
        /// Gets details info about a quest. Joins with LOCATION to populate location_name.
        /// </summary>
        /// <param name="id">id of the quest to retrieve info about.</param>
        /// <returns></returns>
        public static async Task<Quest> GetQuest(int id)
        {
            InitializeConnection();

            var result =  await _connection.QueryAsync<Quest>(@"SELECT q._id,q.name,l.name AS location_name,q.stars,q.hub,q.reward,q.fee,q.hrp,q.goal,q.sub_goal,q.sub_reward,q.sub_hrp 
                                                                FROM quests q LEFT OUTER JOIN locations l ON location_id=l._id WHERE q._id=?", id);
            return result.FirstOrDefault();
        }

        public static async Task<List<Quest>> GetQuestsForMonster(int id)
        {
            InitializeConnection();

            return await _connection.QueryAsync<Quest>("SELECT q._id,q.name,q.stars,q.hub FROM monster_to_quest m LEFT OUTER JOIN quests q ON m.quest_id=q._id WHERE m.monster_id=?", id);
        }

        #endregion

        #region Component Queries

        public static async Task<List<Component>> GetComponentsForComponent(long id)
        {
            InitializeConnection();
            //c - component
            //i1 - created item
            //i2 - component item
            string s =
            @"
            SELECT c._id,c.quantity,c.type,
            i1.name AS created_item_name,i1._id AS created_item_id,i1.sub_type AS created_item_subtype,i1.type AS created_item_type,i1.rarity AS created_item_rarity,i1.icon_name AS created_item_icon,
            i2.name AS comp_item_name,i2._id AS comp_item_id,i2.sub_type AS comp_item_subtype,i2.type AS comp_item_type,i2.rarity AS comp_item_rarity,i2.icon_name AS comp_item_icon
            FROM components c
            LEFT OUTER JOIN items i1 ON c.created_item_id=i1._id
            LEFT OUTER JOIN items i2 ON c.component_item_id=i2._id
            WHERE c.component_item_id=" + id.ToString();
            return await _connection.QueryAsync<Component>(s);
        }

        public static async Task<List<Component>> GetComponentsForItem(long id)
        {
            InitializeConnection();
            //c - component
            //i1 - created item
            //i2 - component item
            string s =
            @"
            SELECT c._id,c.quantity,c.type,
            i1.name AS created_item_name,i1._id AS created_item_id,i1.sub_type AS created_item_subtype,i1.type AS created_item_type,i1.rarity AS created_item_rarity,i1.icon_name AS created_item_icon,
            i2.name AS comp_item_name,i2._id AS comp_item_id,i2.sub_type AS comp_item_subtype,i2.type AS comp_item_type,i2.rarity AS comp_item_rarity,i2.icon_name AS comp_item_icon
            FROM components c
            LEFT OUTER JOIN items i1 ON c.created_item_id=i1._id
            LEFT OUTER JOIN items i2 ON c.component_item_id=i2._id
            WHERE c.created_item_id=" + id.ToString();
            return await _connection.QueryAsync<Component>(s);
        }

        #endregion

        #region Gathering Queries

        public static async Task<List<Gathering>> GetGatheringRewardsForItem(long id)
        {
            InitializeConnection();
            //g - gathering
            //i - item
            //l - location
            string s =
            @"SELECT g._id,g.item_id,g.location_id,g.area,g.site,g.rank,g.percentage,
            i.name AS item_name,i.icon_name AS item_icon,
            l.name AS location_name
            FROM gathering g
            LEFT OUTER JOIN items i ON g.item_id=i._id
            LEFT OUTER JOIN locations l ON g.location_id=l._id
            WHERE g.item_id=?
            ORDER BY g.rank DESC";
            return await _connection.QueryAsync<Gathering>(s, id);
        }

        #endregion

        #region  Skill Tree Queries

        public static async Task<List<ItemToSkillTree>> GetSkillTreesForItem(int id)
        {
            //i - items
            //ist - item_to_skill_tree
            //st - skill_trees
            InitializeConnection();
            string s =
            @"SELECT ist._id,ist.item_id,ist.skill_tree_id,ist.point_value,
            st.name AS skill_tree_name
            FROM item_to_skill_tree ist
            LEFT OUTER JOIN skill_trees st ON ist.skill_tree_id=st._id
            WHERE ist.item_id=?";
            return await _connection.QueryAsync<ItemToSkillTree>(s, id);
        }

        public static async Task<List<ItemToSkillTree>> GetArmorForSkillTree(int id,string subtype)
        {
            //i - items
            //ist - item_to_skill_tree
            //st - skill_trees
            InitializeConnection();
            string s =
            @"SELECT ist.item_id,ist.point_value,
            i.name AS item_name,i.icon_name AS icon_name
            FROM item_to_skill_tree ist
            LEFT OUTER JOIN items i ON ist.item_id=i._id
            WHERE ist.skill_tree_id=? AND i.sub_type=?";
            return await _connection.QueryAsync<ItemToSkillTree>(s, id,subtype);
        }

        public static async Task<List<ItemToSkillTree>> GetDecorationsForSkillTree(int id)
        {
            //i - items
            //ist - item_to_skill_tree
            //st - skill_trees
            InitializeConnection();
            string s =
            @"SELECT ist.item_id,ist.point_value,
            i.name AS item_name,i.icon_name AS icon_name
            FROM item_to_skill_tree ist
            LEFT OUTER JOIN items i ON ist.item_id=i._id
            WHERE ist.skill_tree_id=? AND i.type='Decoration'";
            return await _connection.QueryAsync<ItemToSkillTree>(s, id);
        }

        public static async Task<List<SkillTree>> GetAllSkillTrees()
        {
            InitializeConnection();
            return await _connection.QueryAsync<SkillTree>("SELECT _id,name FROM skill_trees ORDER BY name");
        }

        public static async Task<List<Skill>> GetSkillsForSkillTree(int id)
        {
            InitializeConnection();
            return await _connection.QueryAsync<Skill>("SELECT required_skill_tree_points,name,description FROM skills WHERE skill_tree_id=?",id);
        }

        public static async Task<SkillTree> GetSkillTree(int id)
        {
            InitializeConnection();
            var st = await _connection.QueryAsync<SkillTree>("SELECT _id,name FROM skill_trees WHERE _id=?", id);
            return st.FirstOrDefault();
        }

        #endregion

        #region Location/Habitat Queries

        public static async Task<List<Habitat>> GetHabitatForMonster(int id)
        {
            InitializeConnection();
            //l - location
            //h - monster_habitat
            string s = @"SELECT h.*,l.name AS location_name FROM monster_habitat h LEFT OUTER JOIN locations l ON h.location_id=l._id WHERE h.monster_id=?";
            return await _connection.QueryAsync<Habitat>(s, id);
        }

        #endregion

        #region Decoration Queries

        public static async Task<Decoration> GetDecoration(int id)
        {
            InitializeConnection();
            var result = _connection.QueryAsync<Decoration>("SELECT d.*,i.name AS item_name,i.icon_name AS icon_name,i.rarity AS item_rarity FROM decorations d JOIN items i ON i._id=d._id WHERE d._id=?", id);
            List<Decoration> item = await result;
            return item.FirstOrDefault<Decoration>();
        }

        #endregion

        #region Item Combination Queries

        public static async Task<List<Combination>> GetAllCombinations()
        {
            InitializeConnection();
            string s =
                @"select i1.name AS created_item_name,c.created_item_id,i1.icon_name AS created_item_icon,
                         i2.name AS item_1_name,i2._id AS item_1_id,i2.icon_name AS item_1_icon,
                         i3.name AS item_2_name,i3._id AS item_2_id,i3.icon_name AS item_2_icon,
                         c.percentage,c.amount_made_min,c.amount_made_max 
                from combining c 
                join items i1 on c.created_item_id=i1._id 
                join items i2 on c.item_1_id=i2._id 
                join items i3 on c.item_2_id=i3._id";
            return await _connection.QueryAsync<Combination>(s);
        }

        //TODO:Get combinations for item (created + ingredient)

        #endregion

        #region Wyporium Queries

        public static async Task<List<WyporiumTrade>> GetWyporiumTrades()
        {
            InitializeConnection();
            //Wyporium w
            //Item in
            //Item out
            //Quest q
            string s =
            @"select    w.*,
                        in1.name AS item_in_name,in1.icon_name AS item_in_icon,
                        out.name AS item_out_name,out.icon_name AS item_out_icon,
                        q.name AS quest_name,q.hub AS quest_hub,q.stars AS quest_stars
                        from wyporium w 
                        join items in1 on w.item_in_id=in1._id 
                        join items out on w.item_out_id=out._id 
                        join quests q on w.unlock_quest_id=q._id";
            return await _connection.QueryAsync<WyporiumTrade>(s);
        }

        #endregion

        #region Felyne Skill Queries

        public static async Task<List<FelyneSkill>> GetFelyneSkills()
        {
            InitializeConnection();
            string s =
            @"select * from felyne_skills";
            return await _connection.QueryAsync<FelyneSkill>(s);
        }

        #endregion

    }

}
