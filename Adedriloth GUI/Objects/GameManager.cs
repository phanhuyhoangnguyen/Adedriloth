using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adedriloth_GUI
{
    /// <summary>
    /// Game Manager responsible for creating and managing resources, Path, Location
    /// </summary>
    public class GameManager
    {
        private static GameManager _instance;
        private List<Location> _locationList = new List<Location>();

        private Location _home = new Location(new string[] { "Home" }, "Home", "Your Home");
        private Location _town = new Location(new string[] { "Town" }, "Market Town", "Market Town: An Interesting Crowded place");   //Trading Currency, Buying new weapon
        private Location _forest = new Location(new string[] { "Forest" }, "Forest", "Forest: Mysterious Place");
        private Location _beach = new Location(new string[] { "Beach" }, "Local Beach", "Beach: A big blue sea");
        private Location _mountain = new Location(new string[] { "Mountain" }, "Dragon Mountain", "Mountain: A dangerous place where hero kills monster to gain gold and exp");
        private Location _cave = new Location(new string[] { "Cave" }, "Cave", "Pitch Black Place: Inside the mountain");
        private Location _treasureRoom = new Location(new string[] { "TreasureRoom" }, "Treasure Room", "A place full of Treasure");
        private Location _enemyRoom = new Location(new string[] { "EnemyRoom" }, "Enemy Room", "Trap Room: The place full of monster");
        private Location _lost = new Location(new string[] { "NoWhere" }, "No Where", "Lost");
        private Location _sea = new Location(new string[] { "Sea" }, "Sea", "A Big Ocean");
        private Location _trapRoom = new TrapRoom(new string[] { "TrapRoom" }, "Trap Room");

        //private Chest _chest = new Chest(new string[] { "chest1" }, "Treasure Chest", "A Chest contain valuable items");

        private Path _toHome;
        private Path _escape;
        private Path _toSea;

        private Item housekey = new Key(new string[] { "houseKey" }, "House's Key");
        private Item blueStone = new BreakableKey(new string[] { "BlueStone" }, "Blue Stone");
        private Item dagger = new Dagger(new string[] { "dagger" }, "Dagger", 15, "A short knife with a pointed and edge blade");
        private Item gun = new Gun(new string[] { "ShortGun" }, "Short Gun", 1, "A Gun");

        CommandHandler cmdSearch = new CommandHandler();

        CastingHandler castSearch = new CastingHandler();

        private static Stack<GameState> _state = new Stack<GameState>();

        private Random r = new Random();

        private GameManager()
        {
            _state.Push(GameState.Quitting);

            _state.Push(GameState.Playing);
        }

        public void AddLocation(Location loc)
        {
            _locationList.Add(loc);
        }

        public void LoadLocation()
        {
            AddLocation(_home);
            AddLocation(_town);
            AddLocation(_forest);
            AddLocation(_beach);
            AddLocation(_mountain);
            AddLocation(_cave);
            AddLocation(_treasureRoom);
            AddLocation(_enemyRoom);
            AddLocation(_trapRoom);

            _treasureRoom.Inventory.Put(dagger);
            _treasureRoom.Inventory.Put(gun);
            _treasureRoom.Inventory.Put(blueStone);
            //_treasureRoom.Inventory.Put(_chest);
            //_chest.Inventory.Put(dagger);
            //_chest.Inventory.Put(gun);
            //_chest.Inventory.Put(blueStone);
        }

        public void Init()
        {
            LoadLocation();
            LoadPath();
            InitializeHero();
            LoadEnemy();
            cmdSearch.AddCmdList(castSearch);
        }

        public void LoadPath()
        {
            _toHome = new Door(new string[] { "North", "houseDoor", "houseKey" }, _home);
            _escape = new Door(new string[] { "West", "TrapDoor", "BlueStone" }, _cave);
            _toSea = new Door(new string[] { "North", "", "" }, _sea);

            _home.AddPath(new Path(new string[] { "South" }, _town));
            _town.AddPath(_toHome);

            _town.AddPath(new Path(new string[] { "East" }, _forest));
            _town.AddPath(new Path(new string[] { "West" }, _beach));
            _town.AddPath(new Path(new string[] { "South" }, _mountain));

            _forest.AddPath(new Path(new string[] { "West" }, _town));
            _forest.AddPath(new Path(new string[] { "North" }, _lost));
            _forest.AddPath(new Path(new string[] { "South" }, _mountain));

            _lost.AddPath(new Path(new string[] { "South" }, _forest));

            _beach.AddPath(_toSea);
            _beach.AddPath(new Path(new string[] { "East" }, _town));
            _beach.AddPath(new Path(new string[] { "South" }, _mountain));

            _mountain.AddPath(new Path(new string[] { "North" }, _town));
            _mountain.AddPath(new Path(new string[] { "South" }, _cave));

            _cave.AddPath(new Path(new string[] { "North" }, _mountain));
            _cave.AddPath(new Path(new string[] { "South" }, _enemyRoom));
            _cave.AddPath(new Path(new string[] { "West" }, _treasureRoom));
            _cave.AddPath(new Path(new string[] { "East" }, _trapRoom));

            _trapRoom.AddPath(_escape);
            _treasureRoom.AddPath(new Path(new string[] { "East" }, _cave));
            _enemyRoom.AddPath(new Path(new string[] { "North" }, _cave));
        }

        public void InitializeHero()
        {
            HeroManager.Instance.CurrentHero.Inventory.Put(housekey);
            HeroManager.Instance.CurrentHero.Location = _home;
            HeroManager.Instance.SpellHero.SpellBook.AddSpell(new Teleportation(SkillLevel.novice));
            HeroManager.Instance.SpellHero.SpellBook.AddSpell(new Explosion(SkillLevel.novice));
        }

        public GameState CurrentState
        {
            get
            {
                return _state.Peek();
            }
        }

        public void EndCurrentState()
        {
            _state.Pop();
        }

        private void LoadEnemy()
        {
            for (int i = 0; i < 5; i++)
                EnemyManager.Instance.EnemyGenerating(GetRandoomLocation());
        }

        public Location GetRandoomLocation()
        {

            return _locationList[r.Next(1, _locationList.Count)];
        }

        /// <summary>
        /// Singleton Patten: Game Manager Object Manage itself
        /// </summary>
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }

        public Location LocateLocation(string loc)
        {
            foreach (Location s in _locationList)
            {
                if (s.AreYou(loc))
                    return s;
            }
            return null;
        }

        public string AttackController(CanCauseDamage attack, Enemy receive)
        {
            string _result = null;
            _result = attack.Hit(receive) + Environment.NewLine;
            _result += EnemyManager.Instance.Attack();
            return _result;
        }

        public void HandleUserInput(string[] input)
        {
            OutputManager.Instance.Output += cmdSearch.Execute(HeroManager.Instance.CurrentHero, input);
        }
    }
}
