using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter
{
    internal class MainWindowViewMondel : BindableBase {
        private double metricValue;
        private double imperialValue;

        public DelegateCommand ImperialUnitToMetric { get; private set; }

        public DelegateCommand MetricToImperialUnit { get; private set; }

        public MetricUnit CurrentMetricUnit { get; set; }

        public ImperialUnit CurrentImperialUnit { get; set; }

        public double MetricValue {
            get => metricValue;
            set => SetProperty(ref metricValue, value);
        }

        public double ImperialValue {
            get => imperialValue;
            set => SetProperty(ref imperialValue, value);
        }

        //プロパティ


        public MainWindowViewMondel() {
            CurrentMetricUnit = MetricUnit.Units.First();
            CurrentImperialUnit = ImperialUnit.Units.First();

            ImperialUnitToMetric = new DelegateCommand(
                ()=> MetricValue = CurrentMetricUnit.FromImperialUnit(CurrentImperialUnit, ImperialValue));

            MetricToImperialUnit = new DelegateCommand(
                () => ImperialValue = CurrentImperialUnit.FromMetricUnit(CurrentMetricUnit, MetricValue));
        }
    }
}
