namespace Test01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;


        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);

        }

        //メソッドの概要： studentクラスを読み込み、studentクラスのオブジェクトを返す
        private static IEnumerable<Student> ReadScore(string filePath) {
            var score = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                string[] items = line.Split(',');
                Student student = new Student() {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                score.Add(student);
            }
            return score;
        }

        //メソッドの概要： 教科別点数を求める
        public IDictionary<string, int> GetPerStudentScore() {

            var dict = new SortedDictionary<string, int>();
            foreach (var sc in _score) {
                if (dict.ContainsKey(sc.Subject)) {
                    dict[sc.Subject] += sc.Score;
                } else {
                    dict[sc.Subject] = sc.Score;
                }
            }
            return dict;



        }



    }
}
