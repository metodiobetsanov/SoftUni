select d.Name as [Department Name],
	   case 
	   when AVG(CASt(DATEDIFF(DAY, r.OpenDate, r.CloseDate) AS int))is null then 'no info'
	   else Cast(AVG(casT(DATEDIFF(DAY, r.OpenDate, r.CloseDate) AS INT)) as NVARCHAR)
	   end
	   as [Average Duration]
  from Departments as d
  join Categories as c on c.DepartmentId = d.Id
  join Reports as r on r.CategoryId = c.DepartmentId
group by d.Name
order by d.Name