using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalSystem.Entities
{
    [Serializable]
    //<summary>Job class to store all the details about jobs</summary>
    public class Job
    {
        private int jobId,  noOfVacancies;
        private string employer, address, emailId, skillsRequired, qualification, location;
        private double contactNumber, salary;

        public int JobId
        {
            get { return jobId; }
            set { jobId = value; }
        }

        public double ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public int NoOfVacancies
        {
            get { return noOfVacancies; }
            set { noOfVacancies = value; }
        }

        public string Employer
        {
            get { return employer; }
            set { employer = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string EmailId
        {
            get { return emailId; }
            set { emailId = value; }
        }

        public string SkillsRequired
        {
            get { return skillsRequired; }
            set { skillsRequired = value; }
        }

        public string Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }


    }
}
