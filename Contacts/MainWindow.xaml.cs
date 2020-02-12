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
            ContactsListView.ItemsSource = _contacts;
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            var newContactWindow = App.IocContainer.Resolve<ContactWindow>(new NamedParameter("contactId", 0));
            newContactWindow.ShowDialog();
            RefreshContacts();
        }
        
        private void TextBoxSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ContactsListView.ItemsSource = _contacts.Where(x=>x.Name.ToLower().Contains(TextBoxSearch.Text.ToLower()));
        }
        
        private void ContactsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(ContactsListView.SelectedItem is Contact contact)) return;
            var newContactWindow = App.IocContainer.Resolve<ContactWindow>(new NamedParameter("contactId", contact.Id));
            newContactWindow.ShowDialog();
            RefreshContacts();
        }

    }
}
