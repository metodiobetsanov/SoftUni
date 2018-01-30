select c.Name as CategoryName,
		count(*) as [Employees Number]
 from Categories as c
join Departments as d on d.Id = c.DepartmentId
join Employees as e on e.DepartmentId = c.Id
GROUP BY c.Name
Order by c.Name