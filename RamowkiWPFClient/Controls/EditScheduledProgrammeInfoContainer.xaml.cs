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

namespace WPFSample.Controls
{
    public partial class EditScheduledProgrammeInfoContainer : UserControl
    {
        public DateDayPickerContainer DateDayPickerContainer { get; private set; }
        public WeekDayPickerContainer WeekDayPickerContainer { get; private set; }

        public EditScheduledProgrammeInfoContainer()
        {
            InitializeComponent();
            this.DateDayPickerContainer = new DateDayPickerContainer();
            this.WeekDayPickerContainer = new WeekDayPickerContainer();
        }

        private void DayTypeChanged(object sender, RoutedEventArgs e)
        {
            if(IsWeekDayChecked())
            {
                this.DayContainer.Children.Clear();
                this.DayContainer.Children.Add(this.WeekDayPickerContainer);
            }
            else if(IsDateDayChecked())
            {
                this.DayContainer.Children.Clear();
                this.DayContainer.Children.Add(this.DateDayPickerContainer);
            }
        }
        private bool IsWeekDayChecked()
        {
            return ((this.WeekDayRB.IsChecked == true) && (this.DateDayRB.IsChecked == false));
        }

        private bool IsDateDayChecked()
        {
            return ((this.DateDayRB.IsChecked == true) && (this.WeekDayRB.IsChecked == false));
        }
    }
}
