using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace CustomTreeView.UI.Model
{
    /// <summary>
    /// Класс предсавляющий отдельный элемент в чек листе
    /// </summary>
    public class CheckListElement : INotifyPropertyChanged
    {
        private bool markingOfMade;
        private bool pickable;
        private bool isEnabled;
        private int level;

        public CheckListElement(string id, string name, int level = 0, bool pickable = true, List<CheckListElement> children=null, bool markingOfMade = false)
        {
            Id = id;
            Name = name;
            Level = level;
            Pickable = pickable;
            Children = children;
            this.markingOfMade = markingOfMade;
            IsEnabled = Pickable;
        }

        /// <summary>
        /// № действия (если == null, то нет номера)
        /// </summary>
        [JsonProperty("№ действия")]
        public string Id { get; set; }
        
        /// <summary>
        /// Название действия
        /// </summary>
        [JsonProperty("Название действия")]
        public string Name { get; set; }

        /// <summary>
        /// Если == true, то можно отметить
        /// </summary>
        [JsonProperty("Выбираемый")]
        public bool Pickable
        {
            get => pickable;
	        set
            {
                pickable = value;
                if (!pickable)
                {
                    IsEnabled = false;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Вложенные элементы
        /// </summary>
        [JsonProperty("Вложенные элементы")]
        public List<CheckListElement> Children { get; set; }

        /// <summary>
        /// Отметка о выполнении действия
        /// </summary>
       public bool MarkingOfMade
        {
            get => markingOfMade;
	        set
            {
                markingOfMade = value;
                Children?.ForEach(x => x.IsEnabled = markingOfMade);
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get => isEnabled;
	        set
            {
                isEnabled = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// 0 - родитель, 1 - ребенок
        /// </summary>
        [JsonProperty("Степень вложенности")]
        public int Level
        {
            get => level;
            set
            {
                level = value;
                OnPropertyChanged();
            }
        }
        public void RemoveChild(CheckListElement element)
        {
            Children.Remove(element);
            OnPropertyChanged(nameof(Children));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
