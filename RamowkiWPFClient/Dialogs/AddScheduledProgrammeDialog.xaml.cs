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

using WPFSample.Services.Programme;
using WPFSample.Services.Schedule;
using WPFSample.Controls;
using WPFSample.DTO;

namespace WPFSample.Controllers
{
    public partial class AddScheduledProgrammeDialog : Window
    {
        private IScheduleService scheduleService;

        private DateDayPickerContainer dateDayPickerContainer;
        private WeekDayPickerContainer weekDayPickerContainer;

        private ChooseProgrammeContainer chooseProgrammeContainer;
        private AddProgrammeContainer addProgrammeContainer;

        public AddScheduledProgrammeDialog(IProgrammeService programmeService, IScheduleService scheduleService)
        {
            InitializeComponent();
            this.scheduleService = scheduleService;
            this.dateDayPickerContainer = new DateDayPickerContainer();
            this.weekDayPickerContainer = new WeekDayPickerContainer();
            this.chooseProgrammeContainer = new ChooseProgrammeContainer(programmeService);
            this.addProgrammeContainer = new AddProgrammeContainer();
            CreateProgrammeChanged();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ScheduledProgrammeJson scheduledProgramme = new ScheduledProgrammeJson();
                if (IsWeekDayChecked())
                {
                    scheduledProgramme.Day = new DayWrapper() { WeekDay = this.weekDayPickerContainer.WeekDayCB.SelectedIndex + 1 };
                }
                else if (IsDateDayChecked())
                {
                    scheduledProgramme.Day = new DayWrapper() { Date = ((DateTime)(this.dateDayPickerContainer.Date.SelectedDate)).ToString("dd-MM-yyyy") };
                }
                else throw new InvalidOperationException();
                scheduledProgramme.BeginTime = new Time()
                {
                    Hours = ((DateTime)this.TimeContainer.Value).Hour,
                    Minutes = ((DateTime)this.TimeContainer.Value).Minute
                };
                if (this.CreateNewProgrammeContainer.IsChecked == true)
                {
                    ProgrammeJson newProgramme = new ProgrammeJson()
                    {
                        Title = this.addProgrammeContainer.newProgrammeTitleTB.Text,
                        Description = this.addProgrammeContainer.newProgrammeDescriptionTB.Text
                    };
                    try
                    {
                        this.scheduleService.CreateScheduleAndProgramme(scheduledProgramme, newProgramme);
                        MessageBox.Show("Zapis zrealizowany pomyślnie!");
                        DialogResult = true;
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show("Błąd: " + ex.Message);
                    }
                }
                else if (this.CreateNewProgrammeContainer.IsChecked == false)
                {
                    var selectedProgramme = (ExistingProgrammeJson) this.chooseProgrammeContainer.ChooseProgrammeCB.SelectedItem;
                    var programmeID = selectedProgramme.Id;
                    try
                    {
                        this.scheduleService.CreateSchedule(scheduledProgramme, programmeID);
                        MessageBox.Show("Zapis zrealizowany pomyślnie!");
                        DialogResult = true;
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show("Błąd: " + ex.Message);
                    }
                }
                else throw new InvalidOperationException();
            }
            catch( Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void DayTypeChanged(object sender, RoutedEventArgs e)
        {
            if (IsWeekDayChecked())
            {
                this.DayContainer.Children.Clear();
                this.DayContainer.Children.Add(this.weekDayPickerContainer);
            }
            else if (IsDateDayChecked())
            {
                this.DayContainer.Children.Clear();
                this.DayContainer.Children.Add(this.dateDayPickerContainer);
            }
        }

        private void CreateProgrammeChanged(object sender, RoutedEventArgs e)
        {
            CreateProgrammeChanged();
        }

        private void CreateProgrammeChanged()
        {
            if( CreateNewProgrammeContainer.IsChecked == true )
            {
                this.NewProgrammeContainer.Children.Clear();
                this.NewProgrammeContainer.Children.Add(this.addProgrammeContainer);
            }
            else
            {
                this.NewProgrammeContainer.Children.Clear();
                this.NewProgrammeContainer.Children.Add(this.chooseProgrammeContainer);
            }
        }

        private bool IsWeekDayChecked()
        {
            return ((WeekDayRB.IsChecked == true) && (DateDayRB.IsChecked == false));
        }

        private bool IsDateDayChecked()
        {
            return((DateDayRB.IsChecked == true) && (WeekDayRB.IsChecked == false));
        }
    }
}
