select e.FirstName + ' ' + e.LastName as Name,
	   COUNT(r.UserId) as [User Number]
  from Employees as e
left join Reports as r on r.EmployeeId = e.Id
group by e.FirstName + ' ' + e.LastName
order by [User Number] desc, [Name]