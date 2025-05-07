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

            static void PrintYardToMeterList(int start) {                
                    double meter = YardToMeter(start);
                    Console.WriteLine($"{meter:0.0000}m");
                
            }

            static void PrintMeterToYardList(int start) {               
                    double yard = MeterToYard(start);
                    Console.WriteLine($"{meter}m = {yard:0.0000}yard");
                
            }
        }

             public static double YardToMeter(int meter) {
            return meter / 0.9144;
        }

        
        public static double MeterToYard(int yard) {
            return yard * 0.9144;
        }
    }
}
    





