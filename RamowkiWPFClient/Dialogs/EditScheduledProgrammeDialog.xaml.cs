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
using WPFSample.DTO;
using WPFSample.Services.Programme;

namespace WPFSample.Controllers
{
    public partial class EditScheduledProgrammeDialog : Window
    {
        private IProgrammeService programmeService;
        private string scheduledProgrammeID;
        public bool IsProgrammeSwitched
        {
            get
            {
                return this.chooseProgrammeContainer != null;
            }
        }
        public string NewProgrammeID { get; private set; }
        private ChooseProgrammeContainer chooseProgrammeContainer;
        private EditScheduledProgrammeInfoContainer editProgrammeContainer;
        public ScheduledProgrammeJson UpdatedScheduledProgramme { get; set; }

        public EditScheduledProgrammeDialog(IProgrammeService programmeService, string scheduledProgrammeID)
        {
            InitializeComponent();
            this.programmeService = programmeService;
            this.scheduledProgrammeID = scheduledProgrammeID;
        }

        private void EditModeChanged(object sender, RoutedEventArgs e)
        {
            if( IsRb1Checked() )
            {
                this.chooseProgrammeContainer = new ChooseProgrammeContainer(this.programmeService, this.scheduledProgrammeID);
                this.editProgrammeContainer = null;
                this.ContentContainer.Children.Clear();
                this.ContentContainer.Children.Add(this.chooseProgrammeContainer);
            }
            else if( IsRb2Checked() )
            {
                this.chooseProgrammeContainer = null;
                this.editProgrammeContainer = new EditScheduledProgrammeInfoContainer();
                this.ContentContainer.Children.Clear();
                this.ContentContainer.Children.Add(this.editProgrammeContainer);
            }
        }

        private bool IsRb1Checked()
        {
            return ((Rb1.IsChecked == true) && (Rb2.IsChecked == false));
        }

        private bool IsRb2Checked()
        {
            return ((Rb1.IsChecked == false) && (Rb2.IsChecked == true));
        }

        private void Save()
        {
            if( this.IsProgrammeSwitched )
            {
                this.NewProgrammeID = ((ExistingProgrammeJson)(this.chooseProgrammeContainer.ChooseProgrammeCB.SelectedItem)).Id;
            }
            else
            {
                this.UpdatedScheduledProgramme = new ScheduledProgrammeJson();
                if (IsWeekDayChecked())
                {
                    this.UpdatedScheduledProgramme.Day = new DayWrapper() { WeekDay = this.editProgrammeContainer.WeekDayPickerContainer.WeekDayCB.SelectedIndex + 1 };
                }
                else if (IsDateDayChecked())
                {
                    this.UpdatedScheduledProgramme.Day = new DayWrapper() { Date = ((DateTime)(this.editProgrammeContainer.DateDayPickerContainer.Date.SelectedDate)).ToString("dd-MM-yyyy") };
                }
                else throw new InvalidOperationException();
                this.UpdatedScheduledProgramme.BeginTime = new Time()
                {
                    Hours = ((DateTime)this.editProgrammeContainer.TimeContainer.Value).Hour,
                    Minutes = ((DateTime)this.editProgrammeContainer.TimeContainer.Value).Minute
                };
            }
        }

        private void SaveBtnClick(object sender, RoutedEventArgs e)
        {
            Save();
            this.DialogResult = true;
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private bool IsWeekDayChecked()
        {
            return ((this.editProgrammeContainer.WeekDayRB.IsChecked == true) && (this.editProgrammeContainer.DateDayRB.IsChecked == false));
        }

        private bool IsDateDayChecked()
        {
            return ((this.editProgrammeContainer.WeekDayRB.IsChecked == false) && (this.editProgrammeContainer.DateDayRB.IsChecked == true));
        }
    }
}
