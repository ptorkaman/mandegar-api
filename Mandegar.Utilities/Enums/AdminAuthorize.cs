
namespace Mandegar.Utilities.Enums
{
    public enum AdminAuthorize : int
    {
        Registered = -1,
        SuperAdmin = 1,
        Admin = 2,
        PanelAdmin = 3,

        #region Users

        UserManagement = 4,
        UserAdd = 5,
        UserEdit = 6,
        UserDelete = 7,

        #endregion

        #region Roles
        RolesManagement = 8,
        RolesAdd = 9,
        RolesEdit = 10,
        RolesDelete = 11,
        #endregion

        #region Task

        TaskManagement = 12,
        TaskAdd = 13,
        TaskEdit = 14,
        TaskDelete = 15,

        #endregion

        #region TaskGroup

        TaskGroupManagement = 16,
        TaskGroupAdd = 17,
        TaskGroupEdit = 18,
        TaskGroupDelete = 19,

        #endregion

        #region Position

        PositionManagement = 20,
        PositionAdd = 21,
        PositionEdit = 22,
        PositionDelete = 23,

        #endregion

        #region AssignTask

        AssignTaskManagement = 24,
        AssignTaskAdd = 25,
        AssignTaskEdit = 26,
        AssignTaskDelete = 27,

        #endregion

        #region DepartmentActivity

        DepartmentActivityManagement = 28,
        DepartmentActivityAdd = 29,
        DepartmentActivityEdit = 30,
        DepartmentActivityDelete = 31,

        #endregion

        #region DepartmentActivityType

        DepartmentActivityTypeManagement = 28,
        DepartmentActivityTypeAdd = 29,
        DepartmentActivityTypeEdit = 30,
        DepartmentActivityTypeDelete = 31,

        #endregion

        #region Department

        DepartmentManagement = 32,
        DepartmentAdd = 33,
        DepartmentEdit = 34,
        DepartmentDelete = 35,

        #endregion

        #region Personnel
        StaffManagement = 36,
        StaffAdd = 37,
        StaffEdit = 38,
        StaffDelete = 39,

        #endregion

        #region CooperationType

        CooperationTypeManagement = 40,
        CooperationTypeAdd = 41,
        CooperationTypeEdit = 42,
        CooperationTypeDelete = 43,

        #endregion

        #region ActivityCase

        ActivityCaseManagement = 44,
        ActivityCaseAdd = 45,
        ActivityCaseEdit = 46,
        ActivityCaseDelete = 47,

        #endregion

        #region DepartmentLesson

        DepartmentLessonManagement = 48,
        DepartmentLessonAdd = 49,
        DepartmentLessonEdit = 50,
        DepartmentLessonDelete = 51,

        #endregion

        #region Lesson

        LessonManagement = 52,
        LessonAdd = 53,
        LessonEdit = 54,
        LessonDelete = 55,

        #endregion

        #region StudyGrade

        StudyGradeManagement = 56,
        StudyGradeAdd = 57,
        StudyGradeEdit = 58,
        StudyGradeDelete = 59,

        #endregion

        #region StudyDegree

        StudyDegreeManagement = 60,
        StudyDegreeAdd = 61,
        StudyDegreeEdit = 62,
        StudyDegreeDelete = 63,

        #endregion

        #region StudyField

        StudyFieldManagement = 64,
        StudyFieldAdd = 65,
        StudyFieldEdit = 66,
        StudyFieldDelete = 67,

        #endregion

        #region LessonType

        LessonTypeManagement = 68,
        LessonTypeAdd = 69,
        LessonTypeEdit = 70,
        LessonTypeDelete = 71,

        #endregion

        #region AcademicYear

        AcademicYearManagement = 72,
        AcademicYearAdd = 73,
        AcademicYearEdit = 74,
        AcademicYearDelete = 75,

        #endregion

        #region  Topic

        TopicManagement = 76,
        TopicAdd = 77,
        TopicEdit = 78,
        TopicDelete = 79,

        #endregion

        #region  DepartmentMember

        DepartmentMemberManagement = 80,
        DepartmentMemberAdd = 81,
        DepartmentMemberEdit = 82,
        DepartmentMemberDelete = 83,

        #endregion


        #region  ExecutiveCalendar

        ExecutiveCalendarManagement = 84,
        ExecutiveCalendarAdd = 85,
        ExecutiveCalendarEdit = 86,
        ExecutiveCalendarDelete = 87,

        #endregion


        #region  DepartmentSchedule

        DepartmentScheduleManagement = 88,
        DepartmentScheduleAdd = 89,
        DepartmentScheduleEdit = 90,
        DepartmentScheduleDelete = 91,

        #endregion



        #region  AssignPosition

        AssignPositionManagement = 92,
        AssignPositionAdd = 93,
        AssignPositionEdit = 94,
        AssignPositionDelete = 95,
        StaffUpdatePreparation = 96,

        #endregion
    }
}
