namespace Exercize02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("*** 変換アプリ ***");
            Console.WriteLine("1: ヤードからメートル");
            Console.WriteLine("2: メートルからヤード");
            int a = int.Parse(Console.ReadLine());


            if (a == 1) {
                Console.Write("変換前(ヤード):");
                int start = int.Parse(Console.ReadLine());
                Console.Write("変換後(メートル):" + YardToMeter);
                

            } else if (a == 2) {
                Console.Write("変換前(メートル)");
                int start = int.Parse(Console.ReadLine());
                Console.Write("変換後(ヤード)");
                
            } else {
                Console.WriteLine("エラー");
            }

            //static void PrintYardToMeterList(int start, int end) {
            //    for (int yard = start; yard <= end; yard++) {
            //        double meter = YardToMeter(yard);
            //        Console.WriteLine($"{yard}yard = {meter:0.0000}m");
            //    }
            //}

            //static void PrintMeterToYardList(int start, int end) {
            //    for (int meter = start; meter <= end; meter++) {
            //        double yard = MeterToYard(meter);
            //        Console.WriteLine($"{meter}m = {yard:0.0000}yard");
            //    }
            //}
        }

             public static double YardToMeter(double meter) {
            return meter / 0.9144;
        }

        //フィートからメートルを求める
        public static double MeterToYard(double yard) {
            return yard * 0.9144;
        }
    }
}
    





