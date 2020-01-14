using System;
using System.Collections.Generic;
using System.IO;
using CustomTreeView.UI.Model;
using Newtonsoft.Json;

namespace CustomTreeView.UI.Utils
{
    static class CheckListAggregator
    {
        public static string CheckListJsonPath { get; private set; } = AppDomain.CurrentDomain.BaseDirectory + @"Resources\CheckList.json";
        private static List<CheckListElement> checkList;

        /// <summary>
        /// Создает и возвращает чек-лист
        /// </summary>
        /// <returns> Чек-лист </returns>
        public static List<CheckListElement> CreateCheckList()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Resources"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\Resources");
            }
            if (File.Exists(CheckListJsonPath))
            {
                try
                {
                    checkList = JsonConvert.DeserializeObject<List<CheckListElement>>(File.ReadAllText(CheckListJsonPath));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    checkList = GetDefaultCheckList();
                    File.WriteAllText(CheckListJsonPath, JsonConvert.SerializeObject(checkList, Formatting.Indented));
                }
            }
            else
            {
                checkList = GetDefaultCheckList();
                File.WriteAllText(CheckListJsonPath, JsonConvert.SerializeObject(checkList, Formatting.Indented));
            }

            return checkList;
        }

        public static void SaveCheckList(List<CheckListElement> newCheckList)
        {
            checkList = newCheckList;
            File.WriteAllText(CheckListJsonPath, JsonConvert.SerializeObject(checkList, Formatting.Indented));
        }

        /// <summary>
        /// Создает и возвращает дефолтный чек-лист
        /// </summary>
        /// <returns> Дефолтный чек-лист </returns>
        private static List<CheckListElement> GetDefaultCheckList()
        {
            return new List<CheckListElement>()
            {
                new CheckListElement("1", "Пример пункта 1"),
                new CheckListElement("2", "Пример пункта 2",
                    children: new List<CheckListElement>()
                    {
                        new CheckListElement("2.1", "Пример подпункта 1", 1),
                        new CheckListElement("2.2", "Пример подпункта 2", 1),
                        new CheckListElement("2.3", "Пример подпункта 3", 1)
                    }),
                new CheckListElement(null, "Пример раздела 1", pickable: false,
                    children: new List<CheckListElement>()
                    {
                        new CheckListElement("3", "Пример пункта 1", 1),
                        new CheckListElement("4", "Пример пункта 2", 1),
                        new CheckListElement("5", "Пример пункта 3", 1)
                    }),
                new CheckListElement(null, "Пример раздела 2", pickable: false,
                    children: new List<CheckListElement>()
                    {
                        new CheckListElement("6", "Пример пункта 1", 1),
                        new CheckListElement("7", "Пример пункта 2", 1, children: new List<CheckListElement>()
                            {
                                new CheckListElement("7.1", "Пример подпункта 1", 2),
                                new CheckListElement("7.2", "Пример подпункта 2", 2)
                            })
                    }),
            };
        }
    }
}
