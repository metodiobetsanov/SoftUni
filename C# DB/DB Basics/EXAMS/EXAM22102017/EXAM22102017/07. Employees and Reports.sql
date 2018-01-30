select e.FirstName,
	   e.LastName,
	   r.Description,
	   FORMAT(r.OpenDate, 'yyyy-MM-dd') as OpenDate
  from Employees as e
join Reports as r on r.EmployeeId = e.Id
ORDER BY e.ID, r.OpenDate, r.Id