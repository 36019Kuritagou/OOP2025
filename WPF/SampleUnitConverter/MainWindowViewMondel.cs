using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter
{
    internal class MainWindowViewMondel : ViewModel {
        private double metricValue;
        private double imperialValue;

        public ICommand ImperialUnitToMetric { get; private set; }

        public ICommand MetricToImperialunit { get; private set; }

        public MetricUnit CurrentMetricUnit { get; set; }

        public ImperialUnit CurrentImperialUnit { get; set; }

        public double MetricValue {
            get => metricValue;
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }
        }

        public double ImperialValue {
            get => imperialValue;
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();
            }
        }

        public MainWindowViewMondel() {

            ImperialUnitToMetric = new DelegateCommand(
                ()=> MetricValue = CurrentMetricUnit.FromImperialUnit(CurrentImperialUnit, ImperialValue));

            MetricToImperialunit = new DelegateCommand(
                () => ImperialValue = CurrentImperialUnit.FromMetricUnit(CurrentMetricUnit, MetricValue));
        }
    }
}
