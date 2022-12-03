using Mandegar.Models.Base;
using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Departments;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Utilities.BusinessHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mandegar.Models.Entities.User
{
    public class User : BaseEntity<int>
    {
        public User()
        {

        }

        [Display(Name = "نام کاربری")]
        [DisplayName("نام کاربری")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(100)]
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        public string Username { get; set; } = "";

        [Display(Name = "رمز عبور")]
        [DisplayName("رمز عبور")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [ScaffoldColumn(false)]
        [Display(Name = "کد فعال سازی")]
        [DisplayName("کد فعال سازی")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(200)]
        public string RequestCode { get; set; } = Security.Encrypt(Guid.NewGuid().ToString("N"));

        public DateTime? ModifiedOn { get; set; }

        #region Relations

        public virtual Profile Profile { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<Role> RoleCreatedBy { get; set; }
        public virtual ICollection<Role> RoleModifiedBy { get; set; }

        public virtual ICollection<TaskGroup> TaskGroupCreatedBy { get; set; }
        public virtual ICollection<TaskGroup> TaskGroupModifiedBy { get; set; }

        public virtual ICollection<Tasks> TaskCreatedBy { get; set; }
        public virtual ICollection<Tasks> TaskModifiedBy { get; set; }

        public virtual ICollection<Resume> ResumeCreatedBy { get; set; }
        public virtual ICollection<Resume> ResumeModifiedBy { get; set; }

        public virtual ICollection<StaffDocument> StaffDocumentCreatedBy { get; set; }
        public virtual ICollection<StaffDocument> StaffDocumentModifiedBy { get; set; }

        public virtual ICollection<Sacrifice> SacrificeCreatedBy { get; set; }
        public virtual ICollection<Sacrifice> SacrificeModifiedBy { get; set; }

        public virtual ICollection<StaffFamilyInformation> StaffFamilyInformationCreatedBy { get; set; }
        public virtual ICollection<StaffFamilyInformation> StaffFamilyInformationModifiedBy { get; set; }

        public virtual ICollection<Activity> ActivityCreatedBy { get; set; }
        public virtual ICollection<Activity> ActivityModifiedBy { get; set; }

        public virtual ICollection<ActivityCase> ActivityCaseCreatedBy { get; set; }
        public virtual ICollection<ActivityCase> ActivityCaseModifiedBy { get; set; }

        public virtual ICollection<ActivityField> ActivityFieldCreatedBy { get; set; }
        public virtual ICollection<ActivityField> ActivityFieldModifiedBy { get; set; }

        public virtual ICollection<ActivityType> ActivityTypeCreatedBy { get; set; }
        public virtual ICollection<ActivityType> ActivityTypeModifiedBy { get; set; }

        public virtual ICollection<AddressType> AddressTypeCreatedBy { get; set; }
        public virtual ICollection<AddressType> AddressTypeModifiedBy { get; set; }

        public virtual ICollection<Bank> BankCreatedBy { get; set; }
        public virtual ICollection<Bank> BankModifiedBy { get; set; }

        public virtual ICollection<BloodType> BloodTypeCreatedBy { get; set; }
        public virtual ICollection<BloodType> BloodTypeModifiedBy { get; set; }

        public virtual ICollection<City> CityCreatedBy { get; set; }
        public virtual ICollection<City> CityModifiedBy { get; set; }

        public virtual ICollection<Cooperation> CooperationCreatedBy { get; set; }
        public virtual ICollection<Cooperation> CooperationModifiedBy { get; set; }

        public virtual ICollection<CooperationType> CooperationTypeCreatedBy { get; set; }
        public virtual ICollection<CooperationType> CooperationTypeModifiedBy { get; set; }

        public virtual ICollection<Country> CountryCreatedBy { get; set; }
        public virtual ICollection<Country> CountryModifiedBy { get; set; }

        public virtual ICollection<Department> DepartmentCreatedBy { get; set; }
        public virtual ICollection<Department> DepartmentModifiedBy { get; set; }

        public virtual ICollection<Education> EducationCreatedBy { get; set; }
        public virtual ICollection<Education> EducationModifiedBy { get; set; }

        public virtual ICollection<EducationalQualification> EducationalQualificationCreatedBy { get; set; }
        public virtual ICollection<EducationalQualification> EducationalQualificationModifiedBy { get; set; }

        public virtual ICollection<InsuranceType> InsuranceTypeCreatedBy { get; set; }
        public virtual ICollection<InsuranceType> InsuranceTypeModifiedBy { get; set; }

        public virtual ICollection<MaritalStatus> MaritalStatusCreatedBy { get; set; }
        public virtual ICollection<MaritalStatus> MaritalStatusModifiedBy { get; set; }

        public virtual ICollection<MilitaryServiceStatus> MilitaryServiceStatusCreatedBy { get; set; }
        public virtual ICollection<MilitaryServiceStatus> MilitaryServiceStatusModifiedBy { get; set; }

        public virtual ICollection<Nationality> NationalityCreatedBy { get; set; }
        public virtual ICollection<Nationality> NationalityModifiedBy { get; set; }

        public virtual ICollection<Position> PositionCreatedBy { get; set; }
        public virtual ICollection<Position> PositionModifiedBy { get; set; }

        public virtual ICollection<Province> ProvinceCreatedBy { get; set; }
        public virtual ICollection<Province> ProvinceModifiedBy { get; set; }

        public virtual ICollection<Relation> RelationCreatedBy { get; set; }
        public virtual ICollection<Relation> RelationModifiedBy { get; set; }

        public virtual ICollection<Religion> ReligionCreatedBy { get; set; }
        public virtual ICollection<Religion> ReligionModifiedBy { get; set; }

        public virtual ICollection<Staff> StaffCreatedBy { get; set; }
        public virtual ICollection<Staff> StaffModifiedBy { get; set; }

        public virtual ICollection<StaffAddress> StaffAddressCreatedBy { get; set; }
        public virtual ICollection<StaffAddress> StaffAddressModifiedBy { get; set; }

        public virtual ICollection<StaffComplementary> StaffComplementaryCreatedBy { get; set; }
        public virtual ICollection<StaffComplementary> StaffComplementaryModifiedBy { get; set; }

        public virtual ICollection<StaffFinancial> StaffFinancialCreatedBy { get; set; }
        public virtual ICollection<StaffFinancial> StaffFinancialModifiedBy { get; set; }

        public virtual ICollection<WorkExperienceType> WorkExperienceTypeCreatedBy { get; set; }
        public virtual ICollection<WorkExperienceType> WorkExperienceTypeModifiedBy { get; set; }

        public virtual ICollection<DepartmentEvaluationGroup> DepartmentEvaluationGroupCreatedBy { get; set; }
        public virtual ICollection<DepartmentEvaluationGroup> DepartmentEvaluationGroupModifiedBy { get; set; }

        public virtual ICollection<DepartmentActivityType> DepartmentActivityTypeCreatedBy { get; set; }
        public virtual ICollection<DepartmentActivityType> DepartmentActivityTypeModifiedBy { get; set; }

        public virtual ICollection<DepartmentActivity> DepartmentActivityCreatedBy { get; set; }
        public virtual ICollection<DepartmentActivity> DepartmentActivityModifiedBy { get; set; }

        public virtual ICollection<EvaluationCourse> EvaluationCourseCreatedBy { get; set; }
        public virtual ICollection<EvaluationCourse> EvaluationCourseModifiedBy { get; set; }

        public virtual ICollection<AcademicYear> AcademicYearCreatedBy { get; set; }
        public virtual ICollection<AcademicYear> AcademicYearModifiedBy { get; set; }

        public virtual ICollection<ExecutiveCalendar> ExecutiveCalendarCreatedBy { get; set; }
        public virtual ICollection<ExecutiveCalendar> ExecutiveCalendarModifiedBy { get; set; }

        public virtual ICollection<DepartmentSchedule> DepartmentScheduleCreatedBy { get; set; }
        public virtual ICollection<DepartmentSchedule> DepartmentScheduleModifiedBy { get; set; }

        public virtual ICollection<DepartmentMember> DepartmentMemberCreatedBy { get; set; }
        public virtual ICollection<DepartmentMember> DepartmentMemberModifiedBy { get; set; }

        public virtual ICollection<StudyDegree> StudyDegreeCreatedBy { get; set; }
        public virtual ICollection<StudyDegree> StudyDegreeModifiedBy { get; set; }

        public virtual ICollection<StudyField> StudyFieldCreatedBy { get; set; }
        public virtual ICollection<StudyField> StudyFieldModifiedBy { get; set; }

        public virtual ICollection<StudyGrade> StudyGradeCreatedBy { get; set; }
        public virtual ICollection<StudyGrade> StudyGradeModifiedBy { get; set; }

        public virtual ICollection<Class> ClassCreatedBy { get; set; }
        public virtual ICollection<Class> ClassModifiedBy { get; set; }

        public virtual ICollection<YearClass> YearClassCreatedBy { get; set; }
        public virtual ICollection<YearClass> YearClassModifiedBy { get; set; }

        public virtual ICollection<EventType> EventTypeCreatedBy { get; set; }
        public virtual ICollection<EventType> EventTypeModifiedBy { get; set; }

        public virtual ICollection<Document> DocumentCreatedBy { get; set; }
        public virtual ICollection<Document> DocumentModifiedBy { get; set; }

        public virtual ICollection<LessonType> LessonTypeCreatedBy { get; set; }
        public virtual ICollection<LessonType> LessonTypeModifiedBy { get; set; }

        public virtual ICollection<Event> EventCreatedBy { get; set; }
        public virtual ICollection<Event> EventModifiedBy { get; set; }

        public virtual ICollection<Lesson> LessonCreatedBy { get; set; }
        public virtual ICollection<Lesson> LessonModifiedBy { get; set; }

        public virtual ICollection<Topic> TopicCreatedBy { get; set; }
        public virtual ICollection<Topic> TopicModifiedBy { get; set; }

        public virtual ICollection<DepartmentMeeting> DepartmentMeetingCreatedBy { get; set; }
        public virtual ICollection<DepartmentMeeting> DepartmentMeetingModifiedBy { get; set; }

        public virtual ICollection<MeetingMember> MeetingMemberCreatedBy { get; set; }
        public virtual ICollection<MeetingMember> MeetingMemberModifiedBy { get; set; }

        public virtual ICollection<EvaluationIndicator> EvaluationIndicatorsCreatedBy { get; set; }
        public virtual ICollection<EvaluationIndicator> EvaluationIndicatorsModifiedBy { get; set; }

        public virtual ICollection<SecretaryScore> SecretaryScoreCreatedBy { get; set; }
        public virtual ICollection<SecretaryScore> SecretaryScoreModifiedBy { get; set; }

        public virtual ICollection<ProceedingsDepartment> ProceedingsDepartmentCreatedBy { get; set; }
        public virtual ICollection<ProceedingsDepartment> ProceedingsDepartmentModifiedBy { get; set; }

        public virtual ICollection<SessionApprovals> SessionApprovalsCreatedBy { get; set; }
        public virtual ICollection<SessionApprovals> SessionApprovalsModifiedBy { get; set; }

        public virtual ICollection<DepartmentMeetingMember> DepartmentMeetingMemberCreatedBy { get; set; }
        public virtual ICollection<DepartmentMeetingMember> DepartmentMeetingMemberModifiedBy { get; set; }

        public virtual ICollection<DepartmentMeetingAttendees> DepartmentMeetingAttendeesCreatedBy { get; set; }
        public virtual ICollection<DepartmentMeetingAttendees> DepartmentMeetingAttendeesModifiedBy { get; set; }

        public virtual ICollection<SessionApprovalMembers> SessionApprovalMembersCreatedBy { get; set; }
        public virtual ICollection<SessionApprovalMembers> SessionApprovalMembersModifiedBy { get; set; }


        public int? ModifiedById { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual User ModifiedBy { get; set; }


        #endregion
    }
}
