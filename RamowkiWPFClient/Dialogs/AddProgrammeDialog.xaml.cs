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
using System.Windows.Shapes;

using WPFSample.DTO;

namespace WPFSample.Controllers
{
    public partial class AddProgrammeDialog : Window
    {

        public ProgrammeJson Programme { get; set; }

        public AddProgrammeDialog()
        {
            InitializeComponent();
            InitBinding();
        }

        private void InitBinding()
        {
            this.Programme = new ProgrammeJson();
            this.mainContainer.DataContext = this.Programme;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
