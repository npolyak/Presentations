using NP.Concepts.Behaviors;
using NP.Utilities;
using System;
using System.ComponentModel;

namespace SingleSelectionSample
{
    public class PersonViewModel : VMBase, ISelectableItem<PersonViewModel>
    {
        public event Action<PersonViewModel> IsSelectedChanged;

        public string FirstName { get; }

        public string LastName { get; }

        public PersonViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        #region IsSelected Property
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return this._isSelected;
            }
            set
            {
                if (this._isSelected == value)
                {
                    return;
                }

                this._isSelected = value;
                this.OnPropertyChanged(nameof(IsSelected));
                IsSelectedChanged?.Invoke(this);
            }
        }
        #endregion IsSelected Property

        public void ToggleSelection()
        {
            this.IsSelected = !this.IsSelected;
        }

        public void Select()
        {
            IsSelected = true;
        }
    }
}
