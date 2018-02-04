CREATE OR ALTER FUNCTION udf_GetReportsCount(@employeeId as int, @statusId as int)
returns int
as
begin
	declare @result as int

	set @result = (select Count(*) from Reports
					where EmployeeId = @employeeId and StatusId = @statusId)

	return @result
end

SELECT Id, FirstName, Lastname, dbo.udf_GetReportsCount(Id, 2) AS ReportsCount
FROM Employees
ORDER BY Id
