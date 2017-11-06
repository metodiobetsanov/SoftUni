CREATE PROC usp_AssignEmployeeToReport(@employeeId AS INT, @reportId AS INT)
AS
BEGIN
	declare @EmpDepartment  as int
	declare @RepDepartment  as int

	set @EmpDepartment = (select e.DepartmentId from Employees as e 
							where e.Id = @employeeId)

	set @RepDepartment = (select c.DepartmentId from Reports as r 
							join Categories as c on c.Id = r.CategoryId
							where r.Id = @reportId)

	IF (@EmpDepartment <> @RepDepartment)
	begin
		raiserror('Employee doesn''t belong to the appropriate department!', 16,1)
		return
	end

	update Reports
	set EmployeeId = @employeeId
	where Id = @reportId
END



