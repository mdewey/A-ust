using A_ust.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace A_ust.Models
{
    [Table("Projects")]
    public class Projects
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public Status.GenericStates status { get; set; }
        private ICollection<Features> _features;
        public virtual ICollection<Features> Features
        {
            get { return _features ?? (_features = new List<Features>()); }
            set { _features = value; }
        }


        public int Progress()
        {
            return 0;
        }

        public Projects()
        {
            status = Status.GenericStates.NonStarted;
            TargetDate = null;
        }
    }

    [Table("Features")]
    public class Features
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public Status.GenericStates status { get; set; }
        public Priority.GenericPriority priority { get; set; }
        private ICollection<Assumptions> _assumptions;
        public virtual ICollection<Assumptions> Assumptions
        {
            get { return _assumptions ?? (_assumptions = new List<Assumptions>()); }
            set { _assumptions = value; }
        }
        public int Progress()
        {
            return 0;
        }
        public Features()
        {
            status = Status.GenericStates.NonStarted;
            priority = Priority.GenericPriority.Low;
            TargetDate = null;
        }
    }

    [Table("Assumptions")]
    public class Assumptions
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String Assumption { get; set; }
        public DateTime? TargetDate { get; set; }
        public Status.GenericStates status { get; set; }
        public Priority.GenericPriority priority { get; set; }
        private ICollection<UserStories> _userStories;
        public virtual ICollection<UserStories> RequireLearningObjects
        {
            get { return _userStories ?? (_userStories = new List<UserStories>()); }
            set { _userStories = value; }
        }
        public int Progress()
        {
            return 0;
        }
        public Assumptions()
        {
            status = Status.GenericStates.NonStarted;
            priority = Priority.GenericPriority.Low;
            TargetDate = null;
        }
    }

    [Table("UserStories")]
    public class UserStories
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public Priority.GenericPriority priority { get; set; }
        public Status.GenericStates status { get; set; }
        [Required]
        public String Actor { get; set; }
        [Required]
        public String Act { get; set; }
        [Required]
        public String Outcome { get; set; }
        private ICollection<Tasks> _tasks;
        public virtual ICollection<Tasks> Tasks
        {
            get { return _tasks ?? (_tasks = new List<Tasks>()); }
            set { _tasks = value; }
        }
        public int Progress()
        {
            return 0;
        }
        public UserStories()
        {
            status = Status.GenericStates.NonStarted;
            priority = Priority.GenericPriority.Low;
            TargetDate = null;
        }
    }

    [Table("Tasks")]
    public class Tasks
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public Priority.GenericPriority priority { get; set; }
        public Status.GenericStates status { get; set; }
        public int Progress()
        {
            return 0;
        }
        public Tasks()
        {
            status = Status.GenericStates.NonStarted;
            priority = Priority.GenericPriority.Low;
            TargetDate = null;
        }
    }
}
