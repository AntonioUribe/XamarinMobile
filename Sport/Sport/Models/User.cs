using System;
using System.Collections.Generic;
using SQLite;

namespace Sport.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Creation_Date { get; set; }

    }
}
