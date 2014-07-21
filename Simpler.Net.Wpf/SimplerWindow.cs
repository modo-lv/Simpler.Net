using System;
using System.Windows;
using System.Windows.Threading;

namespace Simpler.Net.Wpf
{
    /// <summary>
    /// A simplifying attachment for a WPF Window object.
    /// Specify a window to attach to in the constructor.
    /// </summary>
    public class SimplerWindow
    {
        /// <summary>
        /// Window that this attachment is attached to.
        /// </summary>
        public Window Window;

        /// <summary>
        /// Called when the window has finished loading, including resolving data bindings.
        /// </summary>
        public event EventHandler FullyLoaded;

        protected virtual void OnFullyLoaded()
        {
            if (FullyLoaded != null)
                FullyLoaded(Window, EventArgs.Empty);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SimplerWindow(Window attachTo)
        {
            Window = attachTo;

            if (Window.WindowStartupLocation == WindowStartupLocation.CenterOwner)
            {
                if (Window.Owner != null && Window.Owner.WindowState == WindowState.Maximized)
                    Window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                else
                    FullyLoaded += CenterOwner;
            }

            Window.Loaded += (o, a) => Window.Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(OnFullyLoaded));
        }

        /// <summary>
        /// Create a new instance of a given window with owner automatically set
        /// to this window.
        /// </summary>
        /// <typeparam name="TDialog"></typeparam>
        /// <returns></returns>
        public TDialog NewDialog<TDialog>() where TDialog : Window, new()
        {
            return new TDialog { Owner = Window };
        }

        /// <summary>
        /// Correctly centers the window within its owner.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void CenterOwner(Object sender, EventArgs args)
        {
            var location = Window.WindowStartupLocation;
            if (location != WindowStartupLocation.CenterOwner
                || Window.Owner == null
                || Window.Owner.WindowState == WindowState.Maximized)
            {
                return;
            }

            Window.WindowStartupLocation = WindowStartupLocation.Manual;

            Double left;
            Double top;

            if (Window.Owner != null)
            {
                top = Window.Owner.Top + ((Window.Owner.ActualHeight - Window.ActualHeight) / 2);
                left = Window.Owner.Left + ((Window.Owner.ActualWidth - Window.ActualWidth) / 2);
            }
            else
            {
                var display = SimplerDisplay.GetDisplayFrom(Window);
                top = (display.WorkingArea.Height - Window.ActualHeight) / 2;
                left = (display.WorkingArea.Width - Window.ActualWidth) / 2;
            }

            Window.Top = Math.Max(0, top);
            Window.Left = Math.Max(0, left);

            Window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
    }
}
