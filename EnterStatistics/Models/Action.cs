using System.ComponentModel.DataAnnotations;

namespace EnterStatistics.Models
{
    public class Action
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
    }
}