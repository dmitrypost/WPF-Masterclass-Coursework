using Contacts.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Contacts.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        public static readonly DependencyProperty ContactProperty = DependencyProperty.Register(
            "Contact", typeof(Contact), typeof(ContactControl), 
            new PropertyMetadata(new Contact(),ContactChangedCallback));

        private static void ContactChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is ContactControl control)) return;
            if (!(e.NewValue is Contact contact)) return;

            control.NameTextBlock.Text = contact.Name;
            control.EmailTextBlock.Text = contact.Email;
            control.PhoneTextBlock.Text = contact.Phone;
        }

        public Contact Contact
        {
            get => (Contact) GetValue(ContactProperty);
            set => SetValue(ContactProperty, value);
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
