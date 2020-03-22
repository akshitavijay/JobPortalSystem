using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortalSystem.Entities;
using JobPortalSystem.Exceptions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace JobPortalSystem.DataAccessLayer
{
    public class JobDAL
    {
        //<text>List collections to store user data and job details</text>
        public static List<Job> jobList = new List<Job>();
        public static List<UserInfo> userList = new List<UserInfo>();

        //<details>Static constructor use to call deserialization so as to collect previously stored data</detail>
        static JobDAL()
        {
            DeSerialization();
        }

        //<summary>Register method to regsiter any new user</summary>
        public bool RegisterUserDAL(UserInfo newUser)
        {
            bool userAdded = false;
            try
            {
                userList.Add(newUser);
                userAdded = true;
                
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return userAdded;

        }

        //<summary>User Login method to give access any user to the user manual</summary>
        public bool LoginUserDAL(int userId, string password)
        {
            bool userLogin = false;
            try
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    if(userList[i].UserId == userId && userList[i].Password == password)
                    {
                        userLogin = true;
                    }
                }
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return userLogin;
        }

        //<summary>Admin method to give access admin to the admin manual</summary>
        public bool LoginAdminDAL(int adminId, string password)
        {
            bool adminLogin = false;
            try
            {
                if (adminId == 160499 && password == "admin123")
                {
                    adminLogin = true;
                }
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return adminLogin;
        }

        //<summary>Add Job method to add a new job in the job list</summary>
        public bool AddJobDAL(Job newJob)
        {
            bool jobAdded = false;
            try
            {
                jobList.Add(newJob);
                jobAdded = true;
                
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return jobAdded;

        }

        //<summary>Edit Job method to edit a already existed job in the job list</summary>
        public bool EditJobDAL(Job editJob)
        {
            bool jobEdited = false;
            try
            {
                for (int i = 0; i < jobList.Count; i++)
                {
                    if (jobList[i].Employer == editJob.Employer)
                    {
                        editJob.Employer = jobList[i].Employer;
                        editJob.Address = jobList[i].Address;
                        editJob.ContactNumber = jobList[i].ContactNumber;
                        editJob.EmailId = jobList[i].EmailId;
                        editJob.SkillsRequired = jobList[i].SkillsRequired;
                        editJob.Qualification = jobList[i].Qualification;
                        editJob.Location = jobList[i].Location;
                        editJob.Salary = jobList[i].Salary;
                        editJob.NoOfVacancies = jobList[i].NoOfVacancies;
                        jobEdited = true;
                    }
                }
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return jobEdited;

        }

        //<summary>Delete Job method to delete a already existed job from the job list</summary>
        public bool DeleteJobDAL(string deleteJobName)
        {
            bool jobDeleted = false;
            try
            {
                Job deleteJob = jobList.Find(job => job.Employer == deleteJobName);

                if (deleteJob != null)
                {
                    jobList.Remove(deleteJob);
                    jobDeleted = true;
                }
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return jobDeleted;

        }

        //<summary>Search Job method to search a job based on name from the job list</summary>
        public Job SearchJobDAL(string searchJobName)
        {
            Job searchJob = null;
            try
            {
                searchJob = jobList.Find(job => job.Employer == searchJobName);
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return searchJob;
        }

        //<summary>List Jobs method to list all the jobs in the job list</summary>
        public List<Job> ListJobsDAL()
        {
            try
            {
                return jobList;
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
        }

        //<detail>Serialization method to store the user information and job details in files in binary format</detail>
        public void Serialization()
        {
            try
            {
                FileStream fsUser = new FileStream(@"UserInfo.txt", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter objUser = new BinaryFormatter();
                objUser.Serialize(fsUser, userList);
                fsUser.Close();

                FileStream fsJob = new FileStream(@"JobDetails.txt", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter objJob = new BinaryFormatter();
                objJob.Serialize(fsJob, jobList);
                fsJob.Close();
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
        }

        //<detail>Deserialization method to retrieve the user information and job details from files in original format</detail>
        public static void DeSerialization()
        {
            try
            {
                
               FileStream fsUser = new FileStream(@"UserInfo.txt", FileMode.Open);
               BinaryFormatter objUser = new BinaryFormatter();
               userList = (List<UserInfo>)objUser.Deserialize(fsUser);
               fsUser.Close();
               

                FileStream fsJob = new FileStream(@"JobDetails.txt", FileMode.Open);
                BinaryFormatter objJob = new BinaryFormatter();
                jobList = (List<Job>)objJob.Deserialize(fsJob);
                fsJob.Close();
                
            }
            catch (JobPortalSystemException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
        }

        //<text>Destructor to serialize all the changes done</text>
        ~JobDAL()
        {
            Serialization();
        }
    }
}
