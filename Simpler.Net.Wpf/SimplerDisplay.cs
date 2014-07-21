using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace Simpler.Net.Wpf
{
    /// <summary>
    /// Wrapper for Window's forms Screen.
    /// </summary>
    public class SimplerDisplay
    {
        private readonly Screen _screen;

        public SimplerDisplay(Screen screen)
        {
            _screen = screen;
        }

        /// <summary>
        /// Gets the working area of the screen.
        /// </summary>
        public Rect WorkingArea
        {
            get
            {
                return new Rect
                {
                    X = _screen.WorkingArea.X,
                    Y = _screen.WorkingArea.Y,
                    Width = _screen.WorkingArea.Width,
                    Height = _screen.WorkingArea.Height
                };
            }
        }

        /// <summary>
        /// Gets the display that a given window is on.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static SimplerDisplay GetDisplayFrom(Window window)
        {
            var windowInteropHelper = new WindowInteropHelper(window);
            var screen = Screen.FromHandle(windowInteropHelper.Handle);
            return new SimplerDisplay(screen);
        }
    }
}
