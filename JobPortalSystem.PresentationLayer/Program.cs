using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortalSystem.Entities;
using JobPortalSystem.Exceptions;
using JobPortalSystem.BusinessLayer;

namespace JobPortalSystem.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int option;
                char choice;
                do
                {

                    Console.WriteLine("Enter your user type:");
                    Console.WriteLine("1: Admin Login \n2: Existing User? Login \n3: New User? Registration");
                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            AdminLogin();
                            break;
                        case 2:
                            UserLogin();
                            break;
                        case 3:
                            RegisterUser();
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice");
                            break;
                    }
                    Console.WriteLine("Do you want to continue, type 'y' for yes");
                    choice = Convert.ToChar(Console.ReadLine());
                } while (choice == 'y');
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //<summary>Admin method to give access admin to the admin manual</summary>
        private static void AdminLogin()
        {
            try
            {
                int adminId;
                string password;

                Console.WriteLine("Enter admin id");
                adminId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter admin password");
                password = Console.ReadLine();

                bool loginAdmin = JobBL.LoginAdminBL(adminId, password);
                if (loginAdmin)
                {
                    Console.WriteLine("Login Successful.");
                    AdminMenu();
                }

                else
                {
                    Console.WriteLine("Invalid admin id or password.");
                }
            }
            catch (JobPortalSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //<summary>User Login method to give access any user the user manual</summary>
        private static void UserLogin()
        {
            try
            {
                int userId;
                string password;

                Console.WriteLine("Enter user id");
                userId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter user password");
                password = Console.ReadLine();

                bool loginUser = JobBL.LoginUserBL(userId, password);
                if (loginUser)
                {
                    Console.WriteLine("Login Successful.");
                    UserMenu();
                }

                else
                {
                    Console.WriteLine("Invalid user id or password.");
                }
            }
            catch (JobPortalSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //<summary>Register method to regsiter any new user</summary>
        private static void RegisterUser()
        {
            try
            {
                UserInfo objUser = new UserInfo();


                Console.WriteLine("Enter your first name");
                objUser.FirstName = (Console.ReadLine());
                while (objUser.FirstName.Length == 0)
                {
                    Console.WriteLine("First Name should not be empty");
                    objUser.FirstName = Console.ReadLine();
                    if (objUser.FirstName.Length != 0)
                        break;
                }

                Console.WriteLine("Enter your last name");
                objUser.LastName = (Console.ReadLine());
                while (objUser.LastName.Length == 0)
                {
                    Console.WriteLine("Last Name should not be empty");
                    objUser.LastName = Console.ReadLine();
                    if (objUser.LastName.Length != 0)
                        break;
                }

                Console.WriteLine("Enter your password");
                objUser.Password = (Console.ReadLine());
                while (objUser.Password.Length == 0)
                {
                    Console.WriteLine("Password should not be empty");
                    objUser.Password = Console.ReadLine();
                    if (objUser.Password.Length != 0)
                        break;
                }

                Console.WriteLine("Enter your age");
                string age = Console.ReadLine();
                int resAge;
                while(!int.TryParse(age, out resAge))
                {
                    Console.WriteLine("Please enter a valid age. It should be a number.");
                    age = Console.ReadLine();
                    if (!int.TryParse(age, out resAge))
                        break;
                }
                objUser.Age = Convert.ToInt32(age);

                int choice;
                Console.WriteLine("Select your gender:\n1:Male\n2:Female");
                do
                {
                    
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            objUser.Gender = "Male";
                            break;
                        case 2:
                            objUser.Gender = "Female";
                            break;
                        default:
                            Console.WriteLine("please enter a valid choice");
                            break;
                    }
                    
                } while (choice != 1 && choice !=2);
                

                Console.WriteLine("Enter your address");
                objUser.Address = (Console.ReadLine());
                while (objUser.Address.Length == 0)
                {
                    Console.WriteLine("Address should not be empty");
                    objUser.Address = Console.ReadLine();
                    if (objUser.Address.Length != 0)
                        break;
                }

                Console.WriteLine("Enter your phone number");
                string phoneNo = Console.ReadLine();
                double resPhoneNo;
                while (!double.TryParse(phoneNo, out resPhoneNo))
                {
                    Console.WriteLine("Please enter a valid phone no. It should be a number.");
                    phoneNo = Console.ReadLine();
                    if (!double.TryParse(phoneNo, out resPhoneNo))
                        break;
                }
                objUser.PhoneNo = Convert.ToDouble(phoneNo);

                

                Random objRandom = new Random();
                List<int> randomLst = new List<int>();
                objUser.UserId = objRandom.Next(1000, 9999);
                while (true)
                {
                    if (randomLst.Contains(objUser.UserId))
                        objUser.UserId = objRandom.Next(100, 9999);
                    else
                        randomLst.Add(objUser.UserId);
                    break;
                }

                bool userAdded = JobBL.RegisterUserBL(objUser);
                if (userAdded)
                {
                    Console.WriteLine("User Registered Successfully.");
                    Console.WriteLine("Your User Id is: {0} and Password is: {1}", objUser.UserId,objUser.Password);
                    
                }
                else
                {
                    Console.WriteLine("User cannot be regstered.");
                }
            }
            catch (JobPortalSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //<summary>Admin menu method to show admin the functionality options he can choose from</summary>
        private static void AdminMenu()
        {

            try
            {
                int choice;
                char option;
                do
                {
                    Console.WriteLine("***********Administration Menu***********");
                    Console.WriteLine("1. Add Job");
                    Console.WriteLine("2. Edit Job");
                    Console.WriteLine("3. Search Job By Job Name");
                    Console.WriteLine("4. Delete Job");
                    Console.WriteLine("5. List All Jobs");
                    Console.WriteLine("******************************************\n");

                    Console.WriteLine("Enter your choice");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddJob();
                            break;
                        case 2:
                            EditJob();
                            break;
                        case 3:
                            SearchJob();
                            break;
                        case 4:
                            DeleteJob();
                            break;
                        case 5:
                            ListJobs();
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice");
                            break;
                    }
                    Console.WriteLine("Do you want to logout, type 'n' for no");
                    option = Convert.ToChar(Console.ReadLine());
                } while (option == 'n');
            }
            catch (JobPortalSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //<summary>Add Job method to add a new job in the job list</summary>
        private static void AddJob()
        {
            try
            {
                Job objJob = new Job();

                Console.WriteLine("Enter job name");
                objJob.Employer = (Console.ReadLine());
                while (objJob.Employer.Length == 0)
                {
                    Console.WriteLine("Job Name should not be empty");
                    objJob.Employer = Console.ReadLine();
                    if (objJob.Employer.Length != 0)
                        break;
                }

                Console.WriteLine("Enter address");
                objJob.Address = (Console.ReadLine());
                while (objJob.Address.Length == 0)
                {
                    Console.WriteLine("Address should not be empty");
                    objJob.Address = Console.ReadLine();
                    if (objJob.Address.Length != 0)
                        break;
                }

                Console.WriteLine("Enter contact number");
                string contactNo = Console.ReadLine();
                double resContactNo;
                while (!double.TryParse(contactNo, out resContactNo))
                {
                    Console.WriteLine("Please enter a valid phone no. It should be a number.");
                    contactNo = Console.ReadLine();
                    if (!double.TryParse(contactNo, out resContactNo))
                        break;
                }
                objJob.ContactNumber = Convert.ToDouble(contactNo);

                Console.WriteLine("Enter contact email id");
                objJob.EmailId = (Console.ReadLine());
                while (objJob.EmailId.Length == 0)
                {
                    Console.WriteLine("EmailId should not be empty");
                    objJob.EmailId = Console.ReadLine();
                    if (objJob.EmailId.Length != 0)
                        break;
                }

                Console.WriteLine("Enter skill required");
                objJob.SkillsRequired = (Console.ReadLine());
                while (objJob.SkillsRequired.Length == 0)
                {
                    Console.WriteLine("Skill should not be empty");
                    objJob.SkillsRequired = Console.ReadLine();
                    if (objJob.SkillsRequired.Length != 0)
                        break;
                }

                Console.WriteLine("Enter qualification");
                objJob.Qualification = (Console.ReadLine());
                while (objJob.Qualification.Length == 0)
                {
                    Console.WriteLine("Qualification should not be empty");
                    objJob.Qualification = Console.ReadLine();
                    if (objJob.Qualification.Length != 0)
                        break;
                }

                Console.WriteLine("Enter location");
                objJob.Location = (Console.ReadLine());
                while (objJob.Location.Length == 0)
                {
                    Console.WriteLine("Location should not be empty");
                    objJob.Location = Console.ReadLine();
                    if (objJob.Location.Length != 0)
                        break;
                }

                Console.WriteLine("Enter salary");
                string salary = Console.ReadLine();
                double reSalary;
                while (!double.TryParse(salary, out reSalary))
                {
                    Console.WriteLine("Please enter a valid salary. It should be a number.");
                    salary = Console.ReadLine();
                    if (!double.TryParse(salary, out reSalary))
                        break;
                }
                objJob.Salary = Convert.ToDouble(salary);

                Console.WriteLine("Enter no of vacancies");
                string noOfVacancies = Console.ReadLine();
                int resNoOfVacancies;
                while (!int.TryParse(noOfVacancies, out resNoOfVacancies))
                {
                    Console.WriteLine("Please enter a valid no of vacancies. It should be a number.");
                    noOfVacancies = Console.ReadLine();
                    if (!int.TryParse(noOfVacancies, out resNoOfVacancies))
                        break;
                }
                objJob.NoOfVacancies = Convert.ToInt32(noOfVacancies);

                Random objRandom = new Random();
                List<int> randomList = new List<int>();
                objJob.JobId = objRandom.Next(1000, 9999);
                while (true)
                {
                    if (randomList.Contains(objJob.JobId))
                        objJob.JobId = objRandom.Next(100, 9999);
                    else
                        randomList.Add(objJob.JobId);
                    break;
                }

                bool jobAdded = JobBL.AddJobBL(objJob);
                if (jobAdded)
                {
                    Console.WriteLine("Job Details Added Successfully.");
                }
                else
                {
                    Console.WriteLine("Job details cannot be added");
                }
            }
            catch (JobPortalSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //<summary>Edit Job method to edit a already existed job in the job list</summary>
        private static void EditJob()
        {
            try
            {
                Job objJob = new Job();
                string employer;
                Console.WriteLine("Enter job name whose job details you want to edit");
                employer = (Console.ReadLine());

                objJob = JobBL.SearchJobBL(employer);
                if(objJob != null)
                {
                    Console.WriteLine("Enter new address");
                    objJob.Address = (Console.ReadLine());

                    Console.WriteLine("Enter new contact number");
                    objJob.ContactNumber = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter new contact email id");
                    objJob.EmailId = (Console.ReadLine());

                    Console.WriteLine("Enter new skill required");
                    objJob.SkillsRequired = (Console.ReadLine());

                    Console.WriteLine("Enter new qualification");
                    objJob.Qualification = (Console.ReadLine());

                    Console.WriteLine("Enter new location");
                    objJob.Location = (Console.ReadLine());

                    Console.WriteLine("Enter new salary");
                    objJob.Salary = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter no of vacancies");
                    objJob.NoOfVacancies = Convert.ToInt32(Console.ReadLine());

                    bool jobEdited = JobBL.EditJobBL(objJob);
                    if (jobEdited)
                    {
                        Console.WriteLine("Job Details Edited Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Job details cannot be edited");
                    }
                }
            
            }
            catch (JobPortalSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //<summary>Search Job method to search a job based on name from the job list</summary>
        private static void SearchJob()
        {
            try
            {
                string employer;
                Console.WriteLine("Enter the job name whose details you want to search");
                employer = Console.ReadLine();
                Job objJob = new Job();
                objJob = JobBL.SearchJobBL(employer);
                if (objJob != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("Searched Job Details: ");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("Job Name: {0}\n Address: {1}\n" +
                        "Contact Number: {2}\nEmail Id: {3} \nSkills Required {4}\n" +
                        "Qualification: {5} \nLocation: {6}\nSalary: {7}\nNo Of Vacancies: {8}", objJob.Employer, objJob.Address, objJob.ContactNumber, objJob.EmailId
                        , objJob.SkillsRequired, objJob.Qualification, objJob.Location, objJob.Salary, objJob.NoOfVacancies);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No such job listed");
                }
            }

            catch (JobPortalSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //<summary>Delete Job method to delete a already existed job from the job list</summary>
        private static void DeleteJob()
        {

            try
            {
                string employer;
                Console.WriteLine("Enter the name of job whose details you want to delete");
                employer = Console.ReadLine();

                bool jobDeleted = JobBL.DeleteJobBL(employer);
                if (jobDeleted)
                {
                    Console.WriteLine("Job details deleted successfully");
                }
                else
                {
                    Console.WriteLine("Job details cannot be deleted");
                }
            }
            catch (JobPortalSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //<summary>List Jobs method to list all the jobs in the job list</summary>
        private static void ListJobs()
        {
            try
            {
                List<Job> jobList = JobBL.ListJobsBl();
                if (jobList != null)
                {
                    Console.WriteLine("Job Details:");
                    foreach (Job job in jobList)
                    {
                        Console.WriteLine("Job Name: {0}\nAddress: {1}\n" +
                            "Contact Number: {2}\nEmail Id: {3} \nSkills Required {4}\n" +
                            "Qualification: {5} \nLocation: {6}\nSalary: {7}\nNo Of Vacancies: {8}", job.Employer, job.Address, job.ContactNumber, job.EmailId
                            , job.SkillsRequired, job.Qualification, job.Location, job.Salary, job.NoOfVacancies);
                        Console.WriteLine("----------------------------------------------------------------");
                    }
                }
            }
            catch (JobPortalSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //<summary>User menu method to show users the functionality options they can choose from</summary>
        private static void UserMenu()
        {
            try
            {
                int choice;
                char option;
                do
                {
                    Console.WriteLine("***********Administration Menu***********");
                    Console.WriteLine("1. List All Jobs");
                    Console.WriteLine("2. Search Job By Job Name");
                    Console.WriteLine("******************************************\n");

                    Console.WriteLine("Enter your choice");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            ListJobs();
                            break;
                        case 2:
                            SearchJob();
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice");
                            break;
                    }
                    Console.WriteLine("Do you want to logout Type n for no");
                    option = Convert.ToChar(Console.ReadLine());
                } while (option == 'n');
            }
            catch (JobPortalSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    
}
