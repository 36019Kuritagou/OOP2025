using System.Windows.Media;

namespace ColorChecker {
    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
        public bool IsKnownColor { get; set; }

        public override string ToString() {
            return Name ?? string.Format("R : {0,3} G : {1,3} B : {2,3}", Color.R, Color.G, Color.B);
        }
    }
}