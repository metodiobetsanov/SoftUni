select distinct c.Name as [Category Name]
 from Categories as c
join Reports as r on r.CategoryId = c.DepartmentId
join Users as u on u.Id = r.UserId
where (DAY(r.OpenDate) = DAY(u.BirthDate) AND MONTH(r.OpenDate) = MONTH(u.BirthDate))
order by c.Name

