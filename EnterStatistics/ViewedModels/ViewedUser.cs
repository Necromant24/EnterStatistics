using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EnterStatistics.Models;

namespace EnterStatistics.ViewedModels
{
    public class ViewedUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Created { get; set; }
        
        [NotNull]public List<Action> Actions { get; set; }

        public ViewedUser(User user, List<Action> actions)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Created = user.Created;
            Actions = actions;
        }
        
        
    }
}