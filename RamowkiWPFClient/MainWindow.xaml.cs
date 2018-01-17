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

using WPFSample.Services.Programme;
using WPFSample.Services.Schedule;
using WPFSample.Controls;
using WPFSample.Utils;
using WPFSample.DTO;

namespace WPFSample.Controllers
{
    public partial class MainWindow : Window
    {

        private IProgrammeService programmeService;
        private IScheduleService scheduleService;

        private Dictionary<string, Object> scheduledProgrammeListParams;

        public MainWindow(IProgrammeService programmeService, IScheduleService scheduleService)
        {
            InitializeComponent();
            this.programmeService = programmeService;
            this.scheduleService = scheduleService;
            this.scheduledProgrammeListParams = new Dictionary<string, object>();
        }

        private void ShowProgrammeList(object sender, RoutedEventArgs e)
        {
            this.ContentContainer.Children.Clear();
            var programmeList = this.programmeService.ReadProgrammeList();
            foreach (var programme in programmeList)
            {
                this.ContentContainer.Children.Add(new ProgrammeListElementContainer(this.programmeService, programme));
            }
            this.ContentContainer.Children.Add(new AddProgrammeButton(this.programmeService));
        }

        private void AddNewProgrammeDialog(object sender, RoutedEventArgs e)
        {
            // Zintegrować do jakiegoś serwisu wraz z identyczną metodą w klasie AddProgrammeButton
            var dialog = new AddProgrammeDialog();
            if( dialog.ShowDialog() == true )
            {
                ProgrammeJson programme = dialog.Programme;
                try
                {
                    this.programmeService.AddNewProgramme(programme);
                    MessageBox.Show("Zapis zrealizowany pomyślnie!");
                }
                catch(InvalidOperationException ex)
                {
                    MessageBox.Show("Błąd: " + ex.Message);
                }
            }
        }

        private void ShowScheduledProgrammeListByWeekDay(object sender, RoutedEventArgs e)
        {
            var dialog = new ShowScheduledProgrammeListByWeekDayDialog();
            if( dialog.ShowDialog() == true )
            {
                var weekDayNumber = dialog.WeekDayPicker.WeekDayCB.SelectedIndex + 1;
                this.scheduledProgrammeListParams.Clear();
                this.scheduledProgrammeListParams.Add("type", "WeekDay");
                this.scheduledProgrammeListParams.Add("value", weekDayNumber);
                try
                {
                    var results = this.scheduleService.GetScheduledProgrammeListByWeekDay(weekDayNumber);
                    ShowScheduledProgrammeListResults(results);
                }
                catch ( InvalidOperationException ex )
                {
                    MessageBox.Show("Błąd: " + ex.Message);
                }
            }
        }

        private void ShowScheduledProgrammeListByDate(object sender, RoutedEventArgs e)
        {
            var dialog = new ShowScheduledProgrammeListByDateDialog();
            if (dialog.ShowDialog() == true)
            {
                var date = ((DateTime)dialog.dp.SelectedDate).ToString("dd-MM-yyyy");
                this.scheduledProgrammeListParams.Clear();
                this.scheduledProgrammeListParams.Add("type", "DateDay");
                this.scheduledProgrammeListParams.Add("value", date);
                try
                {
                    var results = this.scheduleService.GetScheduledProgrammeListByDate(date);
                    ShowScheduledProgrammeListResults(results);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Błąd: " + ex.Message);
                }
            }
        }

        private void ShowScheduledProgrammeListResults(IEnumerable<ExistingScheduledProgrammeJson> results)
        {
            this.ContentContainer.Children.Clear();
            foreach (var result in results)
            {
                this.ContentContainer.Children.Add(new SingleScheduledProgrammeContainer(this, this.scheduleService, this.programmeService, result));
            }
        }

        public void ReloadResults()
        {
            if ((this.scheduledProgrammeListParams["type"] != null) && (this.scheduledProgrammeListParams["value"] != null))
            {
                if (this.scheduledProgrammeListParams["type"].ToString() == "DateDay")
                {
                    string date = this.scheduledProgrammeListParams["value"].ToString();
                    ShowScheduledProgrammeListResults(this.scheduleService.GetScheduledProgrammeListByDate(date));
                }
                else if (this.scheduledProgrammeListParams["type"].ToString() == "WeekDay")
                {
                    int dayNumber = (int)this.scheduledProgrammeListParams["value"];
                    ShowScheduledProgrammeListResults(this.scheduleService.GetScheduledProgrammeListByWeekDay(dayNumber));
                }
                else throw new InvalidOperationException();
            }
            else throw new InvalidOperationException();
        }

        private void AddNewScheduledProgrammeDialog(object sender, RoutedEventArgs e)
        {
            var dialog = new AddScheduledProgrammeDialog(this.programmeService, this.scheduleService);
            dialog.ShowDialog();
        }

        private void ClearContent(object sender, RoutedEventArgs e)
        {
            this.ContentContainer.Children.Clear();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
