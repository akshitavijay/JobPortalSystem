using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortalSystem.Entities;
using JobPortalSystem.Exceptions;
using JobPortalSystem.DataAccessLayer;
using System.Text.RegularExpressions;

namespace JobPortalSystem.BusinessLayer
{
    public class JobBL
    {
        //<detail>Validate user method to check whether all the input fields are in a correct format</detail>
        private static bool ValidateUser(UserInfo user)
        {
            StringBuilder sb = new StringBuilder();
            bool validUser = true;
            if (user.UserId <= 0)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "Invalid User ID");

            }
            if (user.Age <= 0)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "Invalid Age");

            }
            if (user.PhoneNo <=0)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "Required Phone Number");

            }
            if (user.PhoneNo.ToString().Length != 10)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "10 Digit Phone Number is Required");

            }
            if (user.FirstName == string.Empty)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "First Name Required");

            }
            if (user.Password == string.Empty)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "Password Required");

            }
            if (user.LastName == string.Empty)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "Last Name Required");

            }
            if (user.Gender == string.Empty)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "Gender is Required");

            }
            if (user.Address == string.Empty)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "Address is Required");

            }
            if (validUser == false)
                throw new JobPortalSystemException(sb.ToString());

            return validUser;
        }

        //<detail>Validate job method to check whether all the input fields are in a correct format</detail>
        private static bool ValidateJob(Job job)
        {
            StringBuilder sb = new StringBuilder();
            bool validJob = true;

            if (job.ContactNumber <= 0)
            {
                validJob = false;
                sb.Append(Environment.NewLine + "Invalid Phone Number");

            }
            if (job.ContactNumber.ToString().Length != 10)
            {
                validJob = false;
                sb.Append(Environment.NewLine + "10 Digit Phone Number is Required");

            }
            if (job.Salary <= 0)
            {
                validJob = false;
                sb.Append(Environment.NewLine + "Invalid Salary");

            }
            if (job.NoOfVacancies <= 0)
            {
                validJob = false;
                sb.Append(Environment.NewLine + "Invalid Number");

            }
            if (job.Employer == string.Empty)
            {
                validJob = false;
                sb.Append(Environment.NewLine + "Job Name Required");

            }
            if (job.Address == string.Empty)
            {
                validJob = false;
                sb.Append(Environment.NewLine + "Address is Required");

            }
            if (job.EmailId == string.Empty)
            {
                validJob = false;
                sb.Append(Environment.NewLine + "Email Id is Required");

            }
            if (!Regex.IsMatch(job.EmailId, "([a-zA-Z0-9]+@[a-zA-Z].[a-zA-Z])"))
            {
                validJob = false;
                sb.Append(Environment.NewLine + "Email Id is not in proper format");
            }
            if (job.SkillsRequired == string.Empty)
            {
                validJob = false;
                sb.Append(Environment.NewLine + "Skill is Required");

            }
            if (job.Qualification == string.Empty)
            {
                validJob = false;
                sb.Append(Environment.NewLine + "Qualification is Required");

            }
            if (job.Location == string.Empty)
            {
                validJob = false;
                sb.Append(Environment.NewLine + "Location is Required");

            }
            if (validJob == false)
                throw new JobPortalSystemException(sb.ToString());

            return validJob;
        }

        //<summary>Register method to regsiter any new user</summary>
        public static bool RegisterUserBL(UserInfo newUser)
        {
            bool userAdded = false;
            try
            {
                if (ValidateUser(newUser))
                {
                    JobDAL jobDAL = new JobDAL();
                    userAdded = jobDAL.RegisterUserDAL(newUser);
                }
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userAdded;
        }

        //<summary>User Login method to give access any user to the user manual</summary>
        public static bool LoginUserBL(int userId, string password)
        {
            bool loginUser = false;
            try
            {
                JobDAL jobDAL = new JobDAL();
                loginUser = jobDAL.LoginUserDAL(userId, password);
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return loginUser;

        }

        //<summary>Admin method to give access admin to the admin manual</summary>
        public static bool LoginAdminBL(int adminId, string password)
        {
            bool loginAdmin = false;
            try
            {
                JobDAL jobDAL = new JobDAL();
                loginAdmin = jobDAL.LoginAdminDAL(adminId, password);
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return loginAdmin;

        }

        //<summary>Add Job method to add a new job in the job list</summary>
        public static bool AddJobBL(Job newJob)
        {
            bool jobAdded = false;
            try
            {
                if (ValidateJob(newJob))
                {
                    JobDAL jobDAL = new JobDAL();
                    jobAdded = jobDAL.AddJobDAL(newJob);
                }
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return jobAdded;
        }

        //<summary>Edit Job method to edit a already existed job in the job list</summary>
        public static bool EditJobBL(Job editJob)
        {
            bool jobEdited = false;
            try
            {
                if (ValidateJob(editJob))
                {
                    JobDAL jobDAL = new JobDAL();
                    jobEdited = jobDAL.EditJobDAL(editJob);
                }
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return jobEdited;
        }

        //<summary>Delete Job method to delete a already existed job from the job list</summary>
        public static bool DeleteJobBL(string deleteJobName)
        {
            bool jobDeleted = false;
            try
            {
                if (deleteJobName !=null)
                {
                    JobDAL jobDAL = new JobDAL();
                    jobDeleted = jobDAL.DeleteJobDAL(deleteJobName);
                }
                
            }
            catch (JobPortalSystemException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return jobDeleted;
        }

        //<summary>Search Job method to search a job based on name from the job list</summary>
        public static Job SearchJobBL(string searchJobName)
        {
            Job searchJob = null;
            try
            {
                JobDAL jobDAL = new JobDAL();
                searchJob = jobDAL.SearchJobDAL(searchJobName);
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchJob;

        }

        //<summary>List Jobs method to list all the jobs in the job list</summary>
        public static List<Job> ListJobsBl()
        {
            List<Job> jobList = new List<Job>();
            try
            {
                JobDAL objJob = new JobDAL();
                jobList = objJob.ListJobsDAL();
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return jobList;
        }
    }
}
