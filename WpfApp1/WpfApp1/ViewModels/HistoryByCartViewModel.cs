using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class HistoryBySCartViewModel : BaseViewModel
    {
        public HistoryBySCartViewModel()
        {
            NumberOfMounths = "5";
            SeriesCollection = new SeriesCollection();
            HistoryBySCartM = new HistoryBySCartModel();
            YFormatter = value => value.ToString("C");
            NumOfMonthsList = new ObservableCollection<string>(new Others.ListOfMonths().GetNumOfMonthsList());
            updateGraph();
        }
        #region properties
        public HistoryBySCartModel HistoryBySCartM { get; set; }
        public ObservableCollection<string> NumOfMonthsList { get; set; }
        private string numberOfMounths { get; set; }
        public string NumberOfMounths
        {
            get { return numberOfMounths; }
            set
            {
                numberOfMounths = value.Split(' ')[0];
                Labels = new Others.GetMonthLabel().GetLabels(int.Parse(NumberOfMounths));
                updateGraph();
                OnPropertyRaised("NumberOfMounths");
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
        #endregion
        #region other

        public void updateGraph()
        {
            if (SeriesCollection == null)
                return;
            SeriesCollection.Clear();
            SeriesCollection.Add(new LineSeries
            {
                Title = "סל הקניות שלך",
                Values = new ChartValues<double>(HistoryBySCartM.GetHistoryBySCart(Labels)),
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 15
            });
        }
        #endregion
    }
}
