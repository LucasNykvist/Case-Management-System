using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DBModels
{
        public class Client
        {
            public int ClientID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }

            public virtual ICollection<Case> Cases { get; set; }
            public virtual ICollection<Task> Task { get; set; }
        }

        public class Task
        {
            public int TaskID { get; set; }
            public string TaskName { get; set; }
            public string TaskDescription { get; set; }
            public DateTime DateOpened { get; set; }
            public string Status { get; set; }

            public int ClientID { get; set; }
            public virtual Client Client { get; set; }
            public virtual ICollection<Case> Case { get; set; }
        }

        public class Case
        {
            public int CaseID { get; set; }

            public int ClientID { get; set; }
            public virtual Client Client { get; set; }

            public int TaskID { get; set; }
            public virtual Task Task { get; set; }
        }
    }

