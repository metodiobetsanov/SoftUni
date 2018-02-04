select c.Name as CategoryName,
	   COUNT(*) as ReportsNumber
  from Categories as c
join Reports as r on r.CategoryId = c.Id
GROUP BY c.Name
Order BY ReportsNumber desc, c.Name