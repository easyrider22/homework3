using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /** var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "LisaPwd" }); **/

            // following is another condensed way of declaring and assigning values to new users object
            var users = new List<Models.User>
            {
                new Models.User { Name = "Dave", Password = "DavePwd" },
                new Models.User { Name = "Steve", Password = "StevePwd" },
                new Models.User { Name = "Lisa", Password = "LisaPwd" }
            };

            uxList.ItemsSource = users;

            uxList.MouseDoubleClick += new MouseButtonEventHandler(uxList_MouseDoubleClick);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
        }

        private void uxList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            //method 1 using AddHandler couldn't get it to work.


            //method 2
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));


            //method 3
            // most of code copied from: //social.msdn.microsoft.com/Forums/vstudio...how-to-add-event-handler-to-listviewitemmousedoubleclick-programmatically
            // // navigate to the list view item
            /** DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
            }

            if (dep == null)
                return;

            ListViewItem item = (ListViewItem)dep;
            object myDataObject = item.Content;
            System.Diagnostics.Debug.WriteLine(myDataObject); **/
        }
    }
}
