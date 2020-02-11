using Contacts.Interfaces;
using Contacts.Models;
using System.Windows;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        private readonly IContactRepository _contactRepository;
        private readonly int _contactId;

        public ContactWindow(IContactRepository contactRepository, int contactId)
        {
            _contactRepository = contactRepository;
            _contactId = contactId;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_contactId == 0) return;
            
            var contact = _contactRepository.GetContact(_contactId);

            Title = "Modify Contact";
            
            NameTextBox.Text = contact.Name;
            EmailTextBox.Text = contact.Email;
            PhoneTextBox.Text = contact.Phone;
            DeleteButton.Visibility = Visibility.Visible;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var contact = new Contact
            {
                Id = _contactId,
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Phone = PhoneTextBox.Text
            };
            _contactRepository.UpsertContact(contact);
            Close();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete {NameTextBox.Text}?", "Confirm Delete",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No) return;

            _contactRepository.DeleteContact(_contactId);
            Close();
        }
    }
}
