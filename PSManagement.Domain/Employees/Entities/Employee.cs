﻿using PSManagement.Domain.Employees.DomainEvents;
using PSManagement.Domain.Identity.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.SharedKernel.Aggregate;
using PSManagement.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Employees.Entities
{
    /// <summary>
    ///  Employee Class 
    /// 
    /// </summary>
    /// this class represent an employee that work and manage and lead a project
    /// in this class we abstract the employee data and take 
    /// the only needed data in our problem 
    public class Employee : BaseEntity
    {
        public int HIASTId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public WorkInfo WorkInfo { get; set; }

        // the availablity value object
        // we only care about the working hours 
        // any other inof can be hide in it 
        public Availability Availability { get; set; }


        #region Asscociation 
        public ICollection<Project> Projects { get; set; }
        
        public ICollection<EmployeeTrack> EmployeeTracks { get; set; }
        
        public ICollection<EmployeeParticipate> EmployeeParticipates { get; set; }
        #endregion Asscociation 

        #region  Constructors

        public Employee()
        {

        }
        public Employee(Availability availability, PersonalInfo personalInfo, int hiastId)
        {
            Availability = availability;
            PersonalInfo = personalInfo;
            HIASTId = hiastId;
        }

        #endregion  Constructors

        #region business logic encapsulation 

        public void IncreaseWorkHours(int workHours)
        {
            UpdateWorkHours(Availability.CurrentWorkingHours + workHours);
        }

        public void DecreaseWorkHours(int workHours)
        {
            UpdateWorkHours(Availability.CurrentWorkingHours - workHours);
        }

        public void UpdateWorkHours(int workingHour)
        {

            int currentWorkHours = Availability.CurrentWorkingHours;

            // change the employee working hours 
            Availability = new(workingHour, Availability.IsAvailable);

            // publish the events of changing the working hours  
            AddDomainEvent(new EmployeeWorkHoursChangedEvent(Id,currentWorkHours,workingHour));

            
        }
        #endregion business logic encapsulation 
    }
    }
