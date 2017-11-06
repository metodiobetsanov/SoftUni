select d.Name as [Department Name],
	   c.Name as [Category Name],
	   count(r.id)as [Percentage],
	   (select count(r2.id) from Departments as d2
	   join Categories as c2 on c2.DepartmentId = d2.Id
	   join Reports as r2 on d2.Id = r2.CategoryId 
	   where d2.Name = d.Name)
  from Departments as d
join Categories as c on c.DepartmentId = d.Id
join Reports as r on r.CategoryId = c.Id
group by d.Name, c.Name
order by d.Name, c.Name