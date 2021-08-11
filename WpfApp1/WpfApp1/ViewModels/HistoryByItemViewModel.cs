using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Other;

namespace WpfApp1.ViewModels
{

    public class HistoryByItemViewModel : BaseViewModel
    {
        public HistoryByItemViewModel()
        {
            NumberOfMounths = "5";
            HistoryByItemM = new HistoryByItemModel();
            ItemList = new ObservableCollection<string>(HistoryByItemM.GetItems().OrderBy(x => x));
            NumOfMonthsList = new ObservableCollection<string>(new ListOfMonths().GetNumOfMonthsList());
            SeriesCollection = new SeriesCollection();
            YFormatter = value => value.ToString("F1");
        }
        #region collections
        public ObservableCollection<string> ItemList { get; set; }
        public ObservableCollection<string> NumOfMonthsList { get; set; }
        #endregion
        #region properties

        public HistoryByItemModel HistoryByItemM { get; set; }
        private string numberOfMounths { get; set; }
        public string NumberOfMounths
        {
            get { return numberOfMounths; }
            set
            {
                numberOfMounths = value.Split(' ')[0];
                Labels = new GetMonthLabel().GetLabels(int.Parse(NumberOfMounths));
                normelizeGraph();
                OnPropertyRaised("NumberOfMounths");
            }
        }
        #endregion
        #region commands
        public ICommand UpdateGraphCommand
        {
            get
            {
                return new UpdateGraphItemCommand(this);
            }
        }
        #endregion
        #region chart properties
        private SeriesCollection seriesCollection { get; set; }
        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set
            {
                seriesCollection = value;
                OnPropertyRaised("SeriesCollection");
            }
        }

        private string[] labels { get; set; }
        public string[] Labels
        {
            get { return labels; }
            set
            {
                labels = value;
                OnPropertyRaised("Labels");
            }
        }

        public Func<double, string> YFormatter { get; set; }

        public void updateGraph(string itemName)
        {
            foreach (var line in seriesCollection)
            {
                if (line.Title == itemName)
                {
                    seriesCollection.Remove(line);
                    return;
                }
            }

            SeriesCollection.Add
                (new LineSeries
                {
                    Title = itemName,
                    Values = new ChartValues<double>(HistoryByItemM.GetHistoryByItem(itemName, Labels)),
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 15
                });
        }
        #endregion
        #region other
        public void normelizeGraph()
        {
            if (SeriesCollection == null)
                return;
            List<string> SeriesCollectionLineTitles = SeriesCollection.Select(line => line.Title).ToList<string>();
            SeriesCollection.Clear();
            foreach (var LineTitle in SeriesCollectionLineTitles)
            {
                updateGraph(LineTitle);
            }
        }
        #endregion
    }
}
