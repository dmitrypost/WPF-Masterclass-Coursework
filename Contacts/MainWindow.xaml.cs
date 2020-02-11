using Autofac;
using Contacts.Interfaces;
using Contacts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IContactRepository _contactRepository;
        private List<Contact> _contacts;

        public MainWindow()
        {
            _contactRepository = App.IocContainer.Resolve<IContactRepository>();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshContacts();
        }

        private void RefreshContacts()
        {
            _contacts = _contactRepository.GetContacts().ToList();
            DataGridContacts.ItemsSource = _contacts;
            DataGridContacts.Columns[0].Visibility = Visibility.Hidden;
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            var newContactWindow = App.IocContainer.Resolve<ContactWindow>(new NamedParameter("contactId", 0));
            newContactWindow.ShowDialog();
        }

        private void OpenSelected()
        {
            if (!(DataGridContacts.SelectedItem is Contact contact)) return;
            var newContactWindow = App.IocContainer.Resolve<ContactWindow>(new NamedParameter("contactId", contact.Id));
            newContactWindow.ShowDialog();
            RefreshContacts();
        }

        private void DataGridContacts_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenSelected();
        }

        private void TextBoxSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridContacts.ItemsSource = _contacts.Where(x=>x.Name.ToLower().Contains(TextBoxSearch.Text.ToLower()));
        }

    }
}
