using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ConsoleProject2_ForTheTop.Managers
{
    public class DataManager
    {
        public Dictionary<string, ItemData> ItemDict;
        public Dictionary<string, EquipmentData> EquipmentDict;
        public Dictionary<string, ConsumeData> ConsumeDict;
        public Dictionary<string, EnemyData> EnemyDict;

        readonly string path = $"{System.Environment.CurrentDirectory}\\Resources\\Data\\";

        bool _bSuccess;

        public DataManager()
        {
            _bSuccess = true;
        }

        public void LoadAllData()
        {
            LoadItemData();
            LoadEnemyData();

            if (_bSuccess)
                Util.PrintLine("\nData Load Success!", ConsoleColor.Green);
            else
                Util.PrintLine("\nData Load Failed...", ConsoleColor.DarkRed);

            Thread.Sleep(2500);
        }

        public void LoadItemData()
        {
            // item data
            ItemDict = new Dictionary<string, ItemData>();

            LoadEquipData();
            LoadConsumeData();    
        }

        #region Load
        public void LoadEquipData()
        {
            EquipmentDict = new Dictionary<string, EquipmentData>();

            string jsonStr = DecodeDataFile($"{path}\\ItemData\\EquipmentData.Dat");

            JObject jObject = JObject.Parse(jsonStr);
            JToken token = jObject["Equipment"];
            JArray array = token.Value<JArray>();

            bool bResult = true;
            foreach (JObject obj in array)
            {
                EquipmentData data = new EquipmentData();
                data.Name = obj.Value<string>("Name");
                bResult = Enum.TryParse(obj.Value<string>("ItemType"), out data.ItemType);
                data.Description = obj.Value<string>("Description");
                data.Price = obj.Value<int>("Price");
                bResult = Enum.TryParse(obj.Value<string>("EquipType"), out data.EquipType);
                bResult = Enum.TryParse(obj.Value<string>("EquipSlot"), out data.EquipSlot);
                data.Value = obj.Value<int>("Value");

                EquipmentDict.Add(data.Name, data);
                ItemDict.Add(data.Name, data);
            }

            if (bResult)
            {
                Util.PrintLine("EquipData Load OK!", ConsoleColor.Yellow);
            }
            else
            {
                Util.PrintLine("EquipData Load Error!", ConsoleColor.DarkRed);
                _bSuccess = false;
            }
        }

        public void LoadConsumeData()
        {
            ConsumeDict = new Dictionary<string, ConsumeData>();

            string jsonStr = DecodeDataFile($"{path}\\ItemData\\ConsumeData.Dat");

            JObject jObject = JObject.Parse(jsonStr);
            JToken token = jObject["Consume"];
            JArray array = token.Value<JArray>();

            bool bResult = true;
            foreach (JObject obj in array)
            {
                ConsumeData data = new ConsumeData();
                data.Name = obj.Value<string>("Name");
                bResult = Enum.TryParse(obj.Value<string>("ItemType"), out data.ItemType);
                data.Description = obj.Value<string>("Description");
                data.Price = obj.Value<int>("Price");
                bResult = Enum.TryParse(obj.Value<string>("ConsumeType"), out data.ConsumeType);
                data.Amount = obj.Value<int>("Amount");

                ConsumeDict.Add(data.Name, data);
                ItemDict.Add(data.Name, data);
            }

            if (bResult)
            {
                Util.PrintLine("ConsumeData Load OK!", ConsoleColor.Yellow);
            }
            else
            {
                Util.PrintLine("ConsumeData Load Error!", ConsoleColor.DarkRed);
                _bSuccess = false;
            }
        }

        public void LoadEnemyData()
        {
            EnemyDict = new Dictionary<string, EnemyData>();

            string jsonStr = DecodeDataFile($"{path}\\EnemyData\\EnemyData.Dat");

            JObject jObject = JObject.Parse(jsonStr);
            JToken token = jObject["Enemies"];
            JArray array = token.Value<JArray>();

            foreach (JObject obj in array)
            {
                EnemyData data = new EnemyData();
                data.Name = obj.Value<string>("Name");
                data.MaxHP = obj.Value<int>("MaxHP");
                data.AttackPoint = obj.Value<int>("AttackPoint");
                data.Defense = obj.Value<int>("Defense");
                data.Gold = obj.Value<int>("Gold");

                EnemyDict.Add(data.Name, data);
            }

            Util.PrintLine("EnemyData Load OK!", ConsoleColor.Yellow);
        }
        #endregion

        string DecodeDataFile(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            using (FileStream file = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split('_');
                        char c = '\0';

                        for (int i = 0; i < line.Length-1; i++)
                        {
                            c = (char)int.Parse(line[i]);
                            sb.Append(c);
                        }
                    }
                }
            }

            return sb.ToString();
        }
    }
}
