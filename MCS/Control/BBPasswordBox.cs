using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MCS.Control
{
    public sealed class BBPasswordBox : TextBox
    {
        static BBPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BBPasswordBox),
             new FrameworkPropertyMetadata(typeof(BBPasswordBox)));
        }

        [DefaultValue("")]
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
