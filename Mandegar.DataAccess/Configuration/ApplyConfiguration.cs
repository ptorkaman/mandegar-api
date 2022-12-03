using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.Configuration
{
    public static class ApplyConfiguration
    {
        public static void ApplyConfigs(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new User_Config());
            modelBuilder.ApplyConfiguration(new RolePermission_Config());
            modelBuilder.ApplyConfiguration(new Role_Config());
            modelBuilder.ApplyConfiguration(new UserRole_Config());

            modelBuilder.ApplyConfiguration(new TaskGroup_Config());
            modelBuilder.ApplyConfiguration(new Task_Config());
            modelBuilder.ApplyConfiguration(new Position_Config());
            modelBuilder.ApplyConfiguration(new AssignTask_Config());
            modelBuilder.ApplyConfiguration(new AssignPosition_Config());
            modelBuilder.ApplyConfiguration(new CooperationType_Config());
            modelBuilder.ApplyConfiguration(new ActivityType_Config());
            modelBuilder.ApplyConfiguration(new ActivityCase_Config());
            modelBuilder.ApplyConfiguration(new MaritalStatus_Config());
            modelBuilder.ApplyConfiguration(new MilitaryServiceStatus_Config());
            modelBuilder.ApplyConfiguration(new BloodType_Config());
            modelBuilder.ApplyConfiguration(new InsuranceType_Config());
            modelBuilder.ApplyConfiguration(new WorkExperienceType_Config());
            modelBuilder.ApplyConfiguration(new ActivityField_Config());
            modelBuilder.ApplyConfiguration(new Relation_Config());
            modelBuilder.ApplyConfiguration(new Education_Config());
            modelBuilder.ApplyConfiguration(new Bank_Config());
            modelBuilder.ApplyConfiguration(new Country_Config());
            modelBuilder.ApplyConfiguration(new Province_Config());
            modelBuilder.ApplyConfiguration(new City_Config());
            modelBuilder.ApplyConfiguration(new Religion_Config());
            modelBuilder.ApplyConfiguration(new AddressType_Config());
            modelBuilder.ApplyConfiguration(new Staff_Config());
            modelBuilder.ApplyConfiguration(new StaffFinancial_Config());
            modelBuilder.ApplyConfiguration(new StaffAddress_Config());
            modelBuilder.ApplyConfiguration(new Nationality_Config());
            modelBuilder.ApplyConfiguration(new StaffComplementary_Config());
            modelBuilder.ApplyConfiguration(new EducationalQualification_Config());
            modelBuilder.ApplyConfiguration(new Cooperation_Config());
            modelBuilder.ApplyConfiguration(new Activity_Config());
            modelBuilder.ApplyConfiguration(new Resume_Config());
            modelBuilder.ApplyConfiguration(new StaffDocument_Config());
            modelBuilder.ApplyConfiguration(new Sacrifice_Config());
            modelBuilder.ApplyConfiguration(new StaffFamilyInformation_Config());

            modelBuilder.ApplyConfiguration(new Department_Config());
            modelBuilder.ApplyConfiguration(new DepartmentEvaluationGroup_Config());
            modelBuilder.ApplyConfiguration(new DepartmentActivityType_Config());
            modelBuilder.ApplyConfiguration(new DepartmentActivity_Config());
            modelBuilder.ApplyConfiguration(new EvaluationCourse_Config());
            modelBuilder.ApplyConfiguration(new ExecutiveCalendar_Config());
            modelBuilder.ApplyConfiguration(new DepartmentSchedule_Config());
            modelBuilder.ApplyConfiguration(new DepartmentMember_Config());

            modelBuilder.ApplyConfiguration(new AcademicYear_Config());
            modelBuilder.ApplyConfiguration(new StudyDegree_Config());
            modelBuilder.ApplyConfiguration(new StudyField_Config());
            modelBuilder.ApplyConfiguration(new StudyGrade_Config());
            modelBuilder.ApplyConfiguration(new Class_Config());
            modelBuilder.ApplyConfiguration(new YearClass_Config());
            modelBuilder.ApplyConfiguration(new EventType_Config());
            modelBuilder.ApplyConfiguration(new Document_Config());
            modelBuilder.ApplyConfiguration(new LessonType_Config());
            modelBuilder.ApplyConfiguration(new Event_Config());
            modelBuilder.ApplyConfiguration(new Lesson_Config());
            modelBuilder.ApplyConfiguration(new Topic_Config());
            modelBuilder.ApplyConfiguration(new DepartmentMeeting_Config());
            modelBuilder.ApplyConfiguration(new DepartmentActivityMember_Config());
            modelBuilder.ApplyConfiguration(new DepartmentLesson_Config());
            modelBuilder.ApplyConfiguration(new DepartmentMeetingMember_Config());
            modelBuilder.ApplyConfiguration(new DepartmentMeetingAttendees_Config());
            modelBuilder.ApplyConfiguration(new EvaluationIndicators_Config());
            modelBuilder.ApplyConfiguration(new SecretaryEvaluation_Config());
            modelBuilder.ApplyConfiguration(new SecretaryScore_Config());
            modelBuilder.ApplyConfiguration(new ProceedingsDepartment_Config());
            modelBuilder.ApplyConfiguration(new SessionApprovals_Config());
            modelBuilder.ApplyConfiguration(new MeetingMember_Config());
            modelBuilder.ApplyConfiguration(new SessionApprovalMembers_Config());


        }
    }
}
