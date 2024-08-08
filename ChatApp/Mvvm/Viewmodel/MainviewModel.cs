using ChatApp.Core;
using ChatApp.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Mvvm.Viewmodel
{
    internal class MainviewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* command */
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;
        public ContactModel SelectedContacts
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainviewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false,
                });
                Message = ""; // Clear the message after sending
            });

            // Populate Messages collection with sample data
            Messages.Add(new MessageModel()
            {
                Username = "Laura",
                UsernameColor = "#C0C0C0",
                ImageSource = "https://icons8.com/photos/photo/a-woman-holding-a-cell-phone--5e0a0044c1f98100016c30ac",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true,
            });

            for (int i = 0; i < 5; i++)
            {
                Messages.Add(new MessageModel()
                {
                    Username = "David",
                    UsernameColor = "#C0C0C0",
                    ImageSource = "https://icons8.com/photos/photo/a-woman-holding-a-cell-phone--5e0a0044c1f98100016c30ac",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false,
                });
            }

            for (int i = 0; i < 5; i++)
            {
                Messages.Add(new MessageModel()
                {
                    Username = "lilian",
                    UsernameColor = "#C0C0C0",
                    ImageSource = "https://icons8.com/photos/photo/a-woman-holding-a-cell-phone--5e0a0044c1f98100016c30ac",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }

            Messages.Add(new MessageModel()
            {
                Username = "lilian",
                UsernameColor = "#C0C0C0",
                ImageSource = "https://icons8.com/photos/photo/a-woman-holding-a-cell-phone--5e0a0044c1f98100016c30ac",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true,
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel()
                {
                    Username = $"Laura {i}",
                    ImageSource = "https://photo-cdn2.icons8.com/m_TADxy4jwt5YJ4TI3FzbTrw_ln9B0WUKcFjn7Xqs7o/rs:fit:244:1072/wm:1:re:0:0:0.65/wmid:moose/q:98/czM6Ly9pY29uczgu/bW9vc2UtcHJvZC5h/c3NldHMvYXNzZXRz/L2VkaXRvci9tb2Rl/bC82ODEvYzZkYmRk/OWMtZWI5Mi00NTFl/LTgzZTAtOTNiODll/YjIxNTI2LnBuZw.png",
                    Messages = Messages
                });
            }
        }
    }
}
