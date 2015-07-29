
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TimeCount.Presentation;


using System.Windows;
using TimeCount.Controls;
namespace TimeCount.ViewModels
{
    class SettingsAppearanceViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// The resource key for the accent brush.
        /// </summary>
        public const string KeyAccent = "Accent";
        /// <summary>
        /// The resource key for the accent color.
        /// </summary>
        public const string KeyAccentColor = "AccentColor";

        string selectedTheme ;
        #region"Colors"
        // 28 accent colors 
        private Color[] _AccentColors = new Color[]{
             Color.FromRgb(0x33, 0x99, 0xff),   // blue
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x33, 0x99, 0x33),   // green
            Color.FromRgb(0x8c, 0xbf, 0x26),   // lime
            Color.FromRgb(0xf0, 0x96, 0x09),   // orange
            Color.FromRgb(0xff, 0x45, 0x00),   // orange red
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xff, 0x00, 0x97),   // magenta
            Color.FromRgb(0xa2, 0x00, 0xff),   // purple     
            Color.FromRgb(0xa4, 0xc4, 0x00),   // lime
            Color.FromRgb(0x60, 0xa9, 0x17),   // green
            Color.FromRgb(0x00, 0x8a, 0x00),   // emerald
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x1b, 0xa1, 0xe2),   // cyan
            Color.FromRgb(0x00, 0x50, 0xef),   // cobalt
            Color.FromRgb(0x6a, 0x00, 0xff),   // indigo
            Color.FromRgb(0xaa, 0x00, 0xff),   // violet
            Color.FromRgb(0xf4, 0x72, 0xd0),   // pink
            Color.FromRgb(0xd8, 0x00, 0x73),   // magenta
            Color.FromRgb(0xa2, 0x00, 0x25),   // crimson
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xfa, 0x68, 0x00),   // orange
            Color.FromRgb(0xf0, 0xa3, 0x0a),   // amber
            Color.FromRgb(0xe3, 0xc8, 0x00),   // yellow
            Color.FromRgb(0x82, 0x5a, 0x2c),   // brown
            Color.FromRgb(0x6d, 0x87, 0x64),   // olive
            Color.FromRgb(0x64, 0x76, 0x87),   // steel
            Color.FromRgb(0x76, 0x60, 0x8a),   // mauve
        };
        #endregion 

        private Color selectedAccentColor;
 
        public Color[] AccentColors
        {
            get { return this._AccentColors; }
        }

        public string[] FontSizes
        {
            get { return new string[] { "large", "small" }; }
            //this.SelectedFontSize = AppearanceManager.Current.FontSize == FontSize.Large ? FontLarge : FontSmall;
        }

        public string[] Themes
        {
            get { return new string[] { "Dark", "Light", "Transparent" }; }
        }

        public string SelectedTheme
        {
            //get { return this.selectedTheme; }
            set
            {
                //if (this.selectedTheme != value)
                //{
                    SetTheme(value);
                    this.selectedTheme = value;
                    OnPropertyChanged("SelectedTheme");
               // }
            }
        }

        void SetTheme(string TName)
        {
                //Application.Current.Resources.MergedDictionaries.Clear();
            if (TName == null) TName = "Light"; 
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Themes/" + TName + ".xaml", UriKind.Relative) });
        }

        public string SelectedTranslationType
        {
            set
            {
                Properties.Settings.Default.LastSavedTransitionType = value;
            }
        }

        public Color SelectedAccentColor
        {
            get { return this.selectedAccentColor; }
            set
            {
                if (this.selectedAccentColor != value)
                {
                    this.selectedAccentColor = value;
                    OnPropertyChanged("SelectedAccentColor");
                    // set accent color and brush resources
                    Application.Current.Resources[KeyAccentColor] = value;
                    Application.Current.Resources[KeyAccent] = new SolidColorBrush(value);
                    SetTheme(selectedTheme);
                    //Save the selected accent color to the application settings
                    //Properties.Settings.Default.LastSavedAccentColor = value;
                }
            }
        }

    }
}










   //private Color GetAccentColor()
   //     {
   //         var accentColor = Application.Current.Resources[KeyAccentColor] as Color?;

   //         if (accentColor.HasValue) {
   //             return accentColor.Value;
   //         }

   //         // default color: teal
   //         return Color.FromArgb(0xff, 0x1b, 0xa1, 0xe2);
   //     }