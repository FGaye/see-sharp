using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class User
    {
        int Id;
        string Name;
        string Email;
        string Password;
        List<Task> Tasks;
    }
}