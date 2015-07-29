using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace TimeCount
{
    /// <summary>
    /// Interaction logic for PageTransition.xaml
    /// </summary>
    public partial class PageTransition : UserControl
    {
        Stack<UserControl> pages = new Stack<UserControl>();

        // public UserControl CurrentPage { get; set; }
        public PageTransition()
        {
            InitializeComponent();
        }
        public void ShowPage(UserControl newPage)
        {
            pages.Push(newPage);

            Task.Factory.StartNew(() => ShowNewPage());
        }

        void ShowNewPage()
        {
            Dispatcher.Invoke((Action)delegate
            {
                if (contentPresenter.Content != null)
                {
                    UserControl oldPage = contentPresenter.Content as UserControl;

                    if (oldPage != null)
                    {
                        oldPage.Loaded -= newPage_Loaded;

                        UnloadPage();
                    }
                }
                else
                {
                    ShowNextPage();
                }

            });
        }

        void ShowNextPage()
        {
            UserControl newPage = pages.Pop();

            newPage.Loaded += newPage_Loaded;

            contentPresenter.Content = newPage;
        }

        void UnloadPage()
        {
            Storyboard hidePage = (Resources[string.Format("{0}Out", Properties.Settings.Default.LastSavedTransitionType)] as Storyboard).Clone();

            hidePage.Completed += hidePage_Completed;

            hidePage.Begin(contentPresenter);

        }

        void newPage_Loaded(object sender, RoutedEventArgs e)
        {

            Storyboard showNewPage = Resources[string.Format("{0}In", Properties.Settings.Default.LastSavedTransitionType)] as Storyboard;

            showNewPage.Begin(contentPresenter);

            // CurrentPage = sender as UserControl;

        }

        void hidePage_Completed(object sender, EventArgs e)
        {
            contentPresenter.Content = null;

            ShowNextPage();
        }
    }
}
