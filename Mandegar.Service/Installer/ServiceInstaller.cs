using Mandegar.Models.Cache;
using Mandegar.Services.Attachments;
using Mandegar.Services.Cache;
using Mandegar.Services.Impeliments;
using Mandegar.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mandegar.Services.Installer
{
    public static class ServiceInstaller
    {
        public static void Install(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IEvaluationIndicatorService, EvaluationIndicatorService>();
            services.AddScoped<IEvaluationGroupService, EvaluationGroupService>();
            services.AddScoped<ISessionApprovalsService, SessionApprovalsService>();
            services.AddScoped<IDepartmentMeetingAttendeesService, DepartmentMeetingAttendeesService>();
            services.AddScoped<IAssignPositionService, AssignPositionService>();
            services.AddScoped<IDepartmentMeetingAttendeesService, DepartmentMeetingAttendeesService>();
            services.AddScoped<IExecutiveCalendarService, ExecutiveCalendarService>();
            services.AddScoped<IProceedingsDepartmentService, ProceedingsDepartmentService>();
            services.AddScoped<IDepartmentMemberService, DepartmentMemberService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IAcademicYearService, AcademicYearService>();
            services.AddScoped<IDepartmentScheduleService, DepartmentScheduleService>();
            services.AddScoped<ILessonTypeService, LessonTypeService>();
            services.AddScoped<IStudyDegreeService, StudyDegreeService>();
            services.AddScoped<IStudyFieldService, StudyFieldService>();
            services.AddScoped<IStudyGradeService, StudyGradeService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IDepartmentLessonService, DepartmentLessonService>();
            services.AddScoped<IActivityCaseService, ActivityCaseService>();
            services.AddScoped<ICooperationTypeService, CooperationTypeService>();
            services.AddScoped<IDepartmentMeetingMember, DepartmentMeetingMemberService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentActivityTypeService, DepartmentActivityTypeService>();
            services.AddScoped<IAssignTaskService, AssignTaskService>();
            services.AddScoped<IDepartmentActivityService, DepartmentActivityService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IDepartmentMeetingService, DepartmentMeetingService>();
            services.AddScoped<ITaskGroupService, TaskGroupService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogExceptionService, LogExceptionService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IStaffAddressService, StaffAddressService>();
            services.AddScoped<IStaffComplementaryService, StaffComplementaryService>();
            services.AddScoped<IStaffFinancialService, StaffFinancialService>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IStaffFamilyInformationService, StaffFamilyInformationService>();
            services.AddScoped<ICooperationService, CooperationService>();
            services.AddScoped<ISacrificeService, SacrificeService>();
            services.AddScoped<IEducationalQualificationService, EducationalQualificationService>();

            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ICaptchaService, CaptchaService>();

            services.AddScoped<IFileStorage, FileStorage>();
            services.AddScoped<IComperssor, Comperssor>();

            CacheConfig cacheConfig = configuration.GetSection(nameof(CacheConfig)).Get<CacheConfig>();
            services.AddSingleton(cacheConfig);

            MemoryCacheService cache = new MemoryCacheService(cacheConfig);
            services.AddSingleton<IMemoryCacheService>(cache);
            services.AddSingleton<MemoryCacheService>(cache);
        }
    }
}
