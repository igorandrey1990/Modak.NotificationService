using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modak.NotificationServiceTest.Models
{
    public class User
    {
        public User(int p_Id, string p_Name) { 
            Id = p_Id; 
            Name = p_Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
