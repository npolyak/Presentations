using System.ComponentModel;

namespace ItemsPresenterSample
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // fires notification if a property changes
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

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
            }
        }
        #endregion IsSelected Property

        public void ToggleSelection()
        {
            this.IsSelected = !this.IsSelected;
        }
    }
}
