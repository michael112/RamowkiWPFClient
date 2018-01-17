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

using WPFSample.Controls;

namespace WPFSample.Controllers
{
    public partial class ShowScheduledProgrammeListByWeekDayDialog : Window
    {
        public WeekDayPickerContainer WeekDayPicker { get; set; }

        public ShowScheduledProgrammeListByWeekDayDialog()
        {
            InitializeComponent();
            this.WeekDayPicker = new WeekDayPickerContainer();
            this.WeekDayPickerContainer.Children.Add(this.WeekDayPicker);
        }

        private void OKBtnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
