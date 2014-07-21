using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Simpler.Net.Wpf
{
    /// <summary>
    /// Inherit from this class in order to simplify WPF binding (INotifyPropertyChanged).
    /// </summary>
    public abstract class Bindable : INotifyPropertyChanged
    {
        /// <summary>
        /// Custom event handler attachment point.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets value of a property and raises PropertyChanged event for the property.
        /// </summary>
        /// <typeparam name="T">Type of property.</typeparam>
        /// <param name="property">Property to change.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="propName">Name of property (will be detected automatically).</param>
        /// <returns>TRUE if the value was set and change notification raised, FALSE if the values matched.</returns>
        protected virtual Boolean SetAndNotify<T>(ref T property, T value, [CallerMemberName] String propName = "")
        {
            if (Equals(property, value))
                return false;
            property = value;
            OnPropertyChanged(propName);
            return true;
        }
    }
}
