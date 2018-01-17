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

using WPFSample.Services.Schedule;
using WPFSample.Services.Programme;
using WPFSample.Controllers;
using WPFSample.DTO;

namespace WPFSample.Controls
{
    public partial class SingleScheduledProgrammeContainer : UserControl
    {
        private MainWindow mainWindow;

        public ExistingScheduledProgrammeJson ScheduledProgramme { get; set; }

        private IScheduleService scheduleService;
        private IProgrammeService programmeService;

        private SingleScheduledProgrammeDescriptionContainer descriptionContainer;

        public SingleScheduledProgrammeContainer(MainWindow mainWindow, IScheduleService scheduleService, IProgrammeService programmeService, ExistingScheduledProgrammeJson scheduledProgramme)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.scheduleService = scheduleService;
            this.programmeService = programmeService;
            this.ScheduledProgramme = scheduledProgramme;
            this.DataContext = this.ScheduledProgramme;
            this.descriptionContainer = new SingleScheduledProgrammeDescriptionContainer(this.ScheduledProgramme.Programme.Description);
            this.ShowOrHideDescBtn.Content = "Rozwiń...";
        }

        private void ShowOrHideDescription(object sender, RoutedEventArgs e)
        {
            if( this.MainContainer.Children.Contains(this.descriptionContainer) )
            {
                this.MainContainer.RowDefinitions.Remove(this.MainContainer.RowDefinitions.OfType<RowDefinition>().LastOrDefault());
                this.MainContainer.Children.Remove(this.descriptionContainer);
                this.ShowOrHideDescBtn.Content = "Rozwiń...";
            }
            else
            {
                this.MainContainer.RowDefinitions.Add(new RowDefinition());
                this.MainContainer.Children.Add(this.descriptionContainer);
                Grid.SetRow(this.descriptionContainer, 1);
                Grid.SetColumn(this.descriptionContainer, 0);
                this.ShowOrHideDescBtn.Content = "Zwiń";
            }
        }

        private void EditBtnClick(object sender, RoutedEventArgs e)
        {
            var scheduleID = ((Button)sender).DataContext.ToString();
            var dialog = new EditScheduledProgrammeDialog(this.programmeService, scheduleID);
            if (dialog.ShowDialog() == true)
            {
                if (dialog.IsProgrammeSwitched)
                {
                    this.scheduleService.UpdateSchedule(scheduleID, dialog.NewProgrammeID);
                }
                else
                {
                    this.scheduleService.UpdateSchedule(dialog.UpdatedScheduledProgramme, scheduleID);
                }
                ReloadElements();
            }
        }

        private void RemoveBtnClick(object sender, RoutedEventArgs e)
        {
            string message = "Czy na pewno usunąć zaznaczony rekord?";
            var confirmationResult = MessageBox.Show(message, message, MessageBoxButton.YesNo);
            if (confirmationResult == MessageBoxResult.Yes)
            {
                this.scheduleService.RemoveSchedule(((Button)sender).DataContext.ToString());
                ReloadElements();
            }
        }

        private void ReloadElements()
        {
            this.mainWindow.ReloadResults();
        }
    }
}
