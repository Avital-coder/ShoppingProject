using BE;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp.ViewModels
{

    public class PriceComparisonViewModel : BaseViewModel
    {
        public priceComparisonModel PriceComparisonModel { get; set; }
        public PriceComparisonViewModel()
        {
            SeriesCollection = new SeriesCollection();
            YFormatter = value => value.ToString("C");
            PriceComparisonModel = new priceComparisonModel();
            ItemList = new ObservableCollection<string>(PriceComparisonModel.GetItems().OrderBy(x => x));
            PriceComparisonList = new ObservableCollection<PriceComparisonItem>();
            Labels = PriceComparisonModel.GetBranches().ToArray();
        }

        #region inner class
        public class PriceComparisonItem
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImagePath { get; set; }
            public IEnumerable<string> PriceComparison { get; set; }
        }
        #endregion
        #region collections
        public ObservableCollection<PriceComparisonItem> PriceComparisonList { get; set; }
        public ObservableCollection<string> ItemList { get; set; }
        #endregion
        #region other
        public void UpdatericeComparisonList(string itemName)
        {
            foreach (var tempItem in PriceComparisonList)
            {
                if (tempItem.Name == itemName)
                {
                    PriceComparisonList.Remove(tempItem);
                    UpdateGraph();
                    return;
                }
            }

            PriceComparisonItem priceComparisonItem = new PriceComparisonItem();
            Item item = PriceComparisonModel.GetItemsByName(itemName).FirstOrDefault();
            priceComparisonItem.Name = itemName;
            priceComparisonItem.Description = item.Description;
            priceComparisonItem.ImagePath = item.ImagePath;
            priceComparisonItem.PriceComparison = PriceComparisonModel.GetPriceComparison(itemName).OrderBy(ShopName => ShopName.Split('\n')[1]);
            PriceComparisonList.Add(priceComparisonItem);
            UpdateGraph();
        }

        private void UpdateGraph()
        {
            List<string> BranchesList = PriceComparisonModel.GetBranches().ToList<string>();
            List<string> TempBranchesList = new List<string>(BranchesList);
            foreach (var item in PriceComparisonList)
            {
                foreach (var Branche in BranchesList)
                {
                    if (!item.PriceComparison.Any(x => x.Split('\n')[0] == Branche))
                        TempBranchesList.Remove(Branche);
                }
            }

            Labels = TempBranchesList.ToArray();
            SeriesCollection = new SeriesCollection
            {
            new ColumnSeries
            {
                Title = "הסל שלך",
                Values = new ChartValues<double> (priceComparisonModel.GetPriceOptions(Labels, PriceComparisonList.Select(x => x.Name)))
            }
            };
        }
        #endregion
        #region command
        public ICommand UpdatePriceComparisonList
        {
            get
            {
                return new UpdatePriceComparisonListCommand(this);
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

    }
}
