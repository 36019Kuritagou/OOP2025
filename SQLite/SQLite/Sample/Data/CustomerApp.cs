using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Data
{
    internal class CustomerApp
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        
        
        public byte[] Picture { get; set; }
        

        private void LoadImage(string filePath) {
            Picture = File.ReadAllBytes(filePath);
        }
    }
}
