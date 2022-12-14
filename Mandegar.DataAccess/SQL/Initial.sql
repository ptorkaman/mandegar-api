GO
IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'GetSpParametersName'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[GetSpParametersName]
GO

CREATE PROC [dbo].[GetSpParametersName](
@SpName nvarchar(max)
)
AS
BEGIN
	select REPLACE(PARAMETER_NAME,'@','') as PARAMETER_NAME from information_schema.parameters
	where specific_name=@SpName
END

GO

IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'GetUserLogin'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[GetUserLogin]
GO
CREATE PROC [dbo].[GetUserLogin](
@Username varchar(100),
@Password nvarchar(max)
)
AS
BEGIN
	SELECT DISTINCT U.Id AS UserId,
		   PR.[Name],
		   PR.Family,
		   PR.Email,
		   U.Username,
		   PR.Avatar,
		   P.Id PermissionId,
		   P.Name AS PermissionName,
		   R.Name AS RoleName,
		   R.Id AS RoleId,
		   P.IsActive IsActivePermission
	FROM [dbo].Users U
		INNER JOIN [dbo].Profiles PR ON U.Id = PR.UserId
		INNER JOIN [dbo].UserRoles UR ON U.Id=UR.UserId
		INNER JOIN [dbo].Roles R ON UR.RoleId = R.Id
		INNER JOIN [dbo].RolePermissions RP ON RP.RoleId = R.Id
		INNER JOIN [dbo].[Permissions] P ON RP.PermissionId = P.Id
	WHERE Username = @Username
		AND Password = @Password
		AND U.IsActive = 1
		AND U.IsDeleted = 0

	UPDATE [dbo].Profiles
	SET LastLogin = GETDATE()
	FROM dbo.Users U
		INNER JOIN dbo.Profiles P ON U.Id = P.UserId
	WHERE U.Username = @Username
		AND U.Password = @Password
END


GO
IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'InsertExceptionLog'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[InsertExceptionLog]
GO
CREATE PROC [dbo].[InsertExceptionLog](
@Request NVARCHAR(MAX),
@Message NVARCHAR(MAX),
@Exception NVARCHAR(MAX),
@Source NVARCHAR(MAX),
@StackTrace NVARCHAR(MAX),
@Url NVARCHAR(MAX)
)
AS
BEGIN
	INSERT INTO [ExceptionLogs]
                                                               ([Request]
                                                               ,[Message]
                                                               ,[Exception]
                                                               ,[Source]
                                                               ,[StackTrace]
                                                               ,[Url]
                                                               ,[CreatedOn]
                                                               ,[IsActive])
                                                         VALUES
                                                               (@Request
                                                               ,@Message
                                                               ,@Exception
                                                               ,@Source
                                                               ,@StackTrace
                                                               ,@Url
                                                               ,getdate()
                                                               ,1)
END

GO
DROP FUNCTION IF EXISTS dbo.fn_GetReportPaging;
GO
CREATE FUNCTION dbo.fn_GetReportPaging
(
	@PageIndex INT,
	@PageCount INT,
	@OrderBy TINYINT,
	@OrderAsc BIT
)
RETURNS VARCHAR(256)
AS BEGIN

	RETURN CONCAT(
		' ORDER BY ', @OrderBy,
		CASE WHEN @OrderAsc = 0 THEN ' DESC ' END,
		' OFFSET ', @PageIndex * @PageCount, ' ROWS ',
		' FETCH NEXT ', @PageCount, ' ROWS ONLY '
	)

END
GO

IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'Staff_GetAll'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[Staff_GetAll]
GO
CREATE PROC [dbo].[Staff_GetAll](
@Name NVARCHAR(100) = NULL,
@Family NVARCHAR(100) = NULL,
@NationalCode NVARCHAR(10) = NULL,
@Gender BIT = NULL,
@PersonneliCode NVARCHAR(32) = NULL,
@PositionId INT = NULL,
@DepartmentId INT = NULL,
@CooperationId INT = NULL,
@PageIndex INT = NULL,
@PageCount INT = NULL,
@OrderBy TINYINT = NULL,
@OrderAsc BIT = NULL,
@IsCount BIT
)
AS
BEGIN
	DECLARE @Query NVARCHAR(MAX)
	DECLARE @Where NVARCHAR(MAX) = 'WHERE S.IsDeleted = 0 '
	
	IF @Name IS NOT NULL SET @Where = @Where + ' AND S.Name LIKE CONCAT(''%'', @Name, ''%'')'
	IF @Family IS NOT NULL SET @Where = @Where + ' AND S.Family LIKE CONCAT(''%'', @Family, ''%'')'
	IF @NationalCode IS NOT NULL SET @Where = @Where + ' AND S.NationalCode LIKE CONCAT(''%'', @NationalCode, ''%'')'
	IF @Gender IS NOT NULL SET @Where = @Where + ' AND SC.Gender = @Gender'
	IF @PersonneliCode IS NOT NULL SET @Where = @Where + ' AND S.PersonneliCode LIKE CONCAT(''%'', @PersonneliCode, ''%'')'
	IF @PositionId IS NOT NULL SET @Where = @Where + ' AND P.Id = @PositionId'
	IF @DepartmentId IS NOT NULL SET @Where = @Where + ' AND D.Id = @DepartmentId'
	IF @CooperationId IS NOT NULL SET @Where = @Where + ' AND C.Id = @CooperationId'


	IF @IsCount = 1
	SET @Query = '
		SELECT COUNT(DISTINCT S.ID)
		FROM Staffs S 
			LEFT JOIN dbo.StaffComplementaries SC ON SC.StaffId = S.Id	
			LEFT JOIN dbo.Cooperations c ON c.StaffId = s.Id
			LEFT JOIN dbo.CooperationTypes CT ON CT.Id = C.CooperationTypeId
			LEFT JOIN dbo.AssignPositions AP ON AP.StaffId = S.Id
			LEFT JOIN dbo.Positions P ON AP.PositionId = P.Id
			LEFT JOIN dbo.DepartmentMembers DM ON DM.StaffId = s.Id
			LEFT JOIN dbo.Departments D ON D.Id = DM.DepartmentId
	' + @Where
	ELSE
	SET @Query = '
		SELECT DISTINCT Id = S.ID,
				Image = S.Image,
				Name = S.Name,
				Family = S.Family,
				NationalCode = S.NationalCode,
				PersonneliCode = S.PersonneliCode,
				PositionName = STRING_AGG(P.Name, '' - ''),
				CooperationTypeName = CT.Name,
				CooperationEndDate = C.CooperationEndDate,
				Status = S.IsActive
		FROM Staffs S 
			LEFT JOIN dbo.StaffComplementaries SC ON SC.StaffId = S.Id	
			LEFT JOIN dbo.Cooperations c ON c.StaffId = s.Id
			LEFT JOIN dbo.CooperationTypes CT ON CT.Id = C.CooperationTypeId
			LEFT JOIN dbo.AssignPositions AP ON AP.StaffId = S.Id
			LEFT JOIN dbo.Positions P ON AP.PositionId = P.Id
			LEFT JOIN dbo.DepartmentMembers DM ON DM.StaffId = s.Id
			LEFT JOIN dbo.Departments D ON D.Id = DM.DepartmentId
	' + @Where + ' 
			GROUP BY 
			S.ID,
			S.Image,
			S.Name,
			S.Family,
			S.NationalCode,
			S.PersonneliCode,
			CT.Name,
			C.CooperationEndDate,
			S.IsActive
	'

	IF @IsCount = 0 SET @Query = @Query + dbo.fn_GetReportPaging(@PageIndex, @PageCount, @OrderBy, @OrderAsc)
		EXECUTE sp_executesql
		@Query,
		  N'@Name NVARCHAR(100),
			@Family NVARCHAR(100),
			@NationalCode NVARCHAR(10),
			@Gender BIT,
			@PersonneliCode NVARCHAR(32),
			@PositionId INT,
			@DepartmentId INT,
			@CooperationId INT
			',
			@Name,
			@Family,
			@NationalCode,
			@Gender,
			@PersonneliCode,
			@PositionId,
			@DepartmentId,
			@CooperationId
END
GO
IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'GetAllDepartmentMeetingAttendees'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[GetAllDepartmentMeetingAttendees]
GO
Create PROCEDURE [dbo].[GetAllDepartmentMeetingAttendees] 
	@DepartmentMeetingId INT = NULL,
	@PageIndex INT = NULL,
	@PageCount INT = NULL,
	@OrderBy TINYINT = NULL,
	@OrderAsc BIT = NULL,
	@IsCount BIT,
	@MemberIds [dbo].[MemberIds] READONLY
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @Query NVARCHAR(MAX)
	DECLARE @Where NVARCHAR(MAX) = 'WHERE dbo.DepartmentMeetingAttendees.IsDeleted = 0 '
	IF @DepartmentMeetingId IS NOT NULL SET @Where = @Where + ' AND dbo.DepartmentMeetingAttendees.DepartmentMeetingId = @DepartmentMeetingId'
	IF EXISTS (SELECT * FROM @MemberIds) SET @Where = @Where + ' AND EXISTS(SELECT * FROM @MemberIds AS M WHERE M.DepartmentMemberId = dbo.DepartmentMeetingAttendees.DepartmentMemberId)'
	IF @IsCount = 1
	SET @Query = '
		SELECT COUNT(DISTINCT dbo.DepartmentMeetingAttendees.Id)
		FROM dbo.DepartmentMeetings INNER JOIN dbo.DepartmentMeetingAttendees ON dbo.DepartmentMeetings.Id = dbo.DepartmentMeetingAttendees.DepartmentMeetingId INNER JOIN
             dbo.Staffs ON dbo.DepartmentMeetingAttendees.DepartmentMemberId = dbo.Staffs.Id
	' + @Where
	ELSE
	SET @Query = '
		SELECT (dbo.Staffs.Name + '' '' + dbo.Staffs.Family) as FullName, dbo.DepartmentMeetings.Name AS MeetingName, dbo.DepartmentMeetingAttendees.DepartmentMeetingId, dbo.DepartmentMeetingAttendees.DepartmentMemberId, 
        dbo.DepartmentMeetingAttendees.IsDeleted, dbo.DepartmentMeetingAttendees.Id
		FROM dbo.DepartmentMeetings INNER JOIN dbo.DepartmentMeetingAttendees ON dbo.DepartmentMeetings.Id = dbo.DepartmentMeetingAttendees.DepartmentMeetingId INNER JOIN
             dbo.Staffs ON dbo.DepartmentMeetingAttendees.DepartmentMemberId = dbo.Staffs.Id
	' + @Where
	IF @IsCount = 0 SET @Query = @Query + dbo.fn_GetReportPaging(@PageIndex, @PageCount, @OrderBy, @OrderAsc)
	EXECUTE sp_executesql
		@Query,
		  N'@DepartmentMeetingId INT,
			@MemberIds dbo.MemberIds READONLY
			',
			@DepartmentMeetingId,
			@MemberIds
END
GO

IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'GetAllMembersInMeeting'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[GetAllMembersInMeeting]
GO
CREATE PROCEDURE [dbo].[GetAllMembersInMeeting]

	@Id int = null
AS
BEGIN
	SELECT dbo.MeetingMembers.IsDeleted AS MeetingMemberDeleted, dbo.MeetingMembers.DepartmentMemberId, (dbo.Staffs.Name +' '+ dbo.Staffs.Family) AS FullName, dbo.Staffs.IsDeleted AS StaffDeleted, 
           dbo.MeetingMembers.DepartmentMeetingMemberId, dbo.DepartmentMeetingMembers.IsDeleted AS DepartmentMeetingMemberDeleted, dbo.DepartmentMeetingMembers.DepartmentId
	FROM dbo.MeetingMembers INNER JOIN dbo.Staffs ON dbo.MeetingMembers.DepartmentMemberId = dbo.Staffs.Id INNER JOIN dbo.DepartmentMeetingMembers ON dbo.MeetingMembers.DepartmentMeetingMemberId = dbo.DepartmentMeetingMembers.Id
	WHERE (dbo.MeetingMembers.IsDeleted = 0) AND (dbo.Staffs.IsDeleted = 0) AND (dbo.DepartmentMeetingMembers.IsDeleted = 0) AND (dbo.MeetingMembers.DepartmentMeetingMemberId = @Id)
END

CREATE TYPE [dbo].[MemberIds] AS TABLE(
	[DepartmentMemberId] [int] NULL
)
GO

IF type_id('[dbo].[MemberIds]') IS NOT NULL
DROP TYPE [dbo].[MemberIds];
		go
CREATE TYPE [dbo].[MemberIds] AS TABLE(
	[DepartmentMemberId] [int] NULL
)
GO

