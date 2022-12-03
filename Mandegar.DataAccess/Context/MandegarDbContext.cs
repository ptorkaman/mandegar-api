using Mandegar.DataAccess.Configuration;
using Mandegar.DataAccess.QueryFilter;
using Mandegar.DataAccess.Seed;
using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Departments;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess
{
    public class MandegarDbContext : DbContext
    {
        public MandegarDbContext(DbContextOptions<MandegarDbContext> options) : base(options)
        {

        }

        #region User | Role | Permission

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }


        #endregion

        #region Personeli

        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<AssignTask> AssignTasks { get; set; }
        public DbSet<AssignPosition> AssignPositions { get; set; }
        public DbSet<CooperationType> CooperationTypes { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<ActivityCase> ActivityCases { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<MilitaryServiceStatus> MilitaryServiceStatuses { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<WorkExperienceType> WorkExperienceTypes { get; set; }
        public DbSet<ActivityField> ActivityFields { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffFinancial> StaffFinancials { get; set; }
        public DbSet<StaffAddress> StaffAddresses { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<StaffComplementary> StaffComplementaries { get; set; }
        public DbSet<EducationalQualification> EducationalQualifications { get; set; }
        public DbSet<Cooperation> Cooperations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<StaffDocument> StaffDocuments { get; set; }
        public DbSet<Sacrifice> Sacrifices { get; set; }
        public DbSet<StaffFamilyInformation> StaffFamilyInformation { get; set; }
        public DbSet<DepartmentEvaluationGroup> DepartmentEvaluationGroup { get; set; }

        #endregion

        #region Department

        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentActivityType> DepartmentActivityTypes { get; set; }
        public DbSet<DepartmentActivity> DepartmentActivities { get; set; }
        public DbSet<EvaluationCourse> EvaluationCourses { get; set; }
        public DbSet<DepartmentSchedule> DepartmentSchedules { get; set; }
        public DbSet<DepartmentMember> DepartmentMembers { get; set; }
        public DbSet<DepartmentMeeting> DepartmentMeetings { get; set; }
        public DbSet<DepartmentActivityMember> DepartmentActivityMembers { get; set; }
        public DbSet<DepartmentLesson> DepartmentLessons { get; set; }
        public DbSet<DepartmentMeetingMember> DepartmentMeetingMembers { get; set; }
        public DbSet<MeetingMember> MeetingMembers { get; set; }
        public DbSet<DepartmentMeetingAttendees> DepartmentMeetingAttendees { get; set; }
        public DbSet<EvaluationIndicator> EvaluationIndicators { get; set; }
        public DbSet<SecretaryScore> SecretaryScores { get; set; }
        public DbSet<ProceedingsDepartment> ProceedingsDepartments { get; set; }
        public DbSet<SessionApprovals> SessionApprovals { get; set; }
        public DbSet<SessionApprovalMembers> SessionApprovalMembers { get; set; }

        #endregion

        #region BaseInfo

        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<StudyDegree> StudyDegrees { get; set; }
        public DbSet<StudyField> StudyFields { get; set; }
        public DbSet<StudyGrade> StudyGrades { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<YearClass> YearClasses { get; set; }
        public DbSet<ExecutiveCalendar> ExecutiveCalendars { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Topic> Topics { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configuration

            modelBuilder.ApplyConfigs();

            #endregion

            #region Seed

            modelBuilder.UsersSeed();

            modelBuilder.RolesSeed();

            modelBuilder.PermissionsSeed();

            #endregion

            #region Query Filter

            modelBuilder.UsersQueryFilter();
            modelBuilder.RolesQueryFilter();
            modelBuilder.StaffsQueryFilter();
            modelBuilder.StaffFinancialQueryFilter();
            modelBuilder.ResumeeQueryFilter();
            modelBuilder.ActivityQueryFilter();
            modelBuilder.StaffFamilyInformationQueryFilter();

            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
