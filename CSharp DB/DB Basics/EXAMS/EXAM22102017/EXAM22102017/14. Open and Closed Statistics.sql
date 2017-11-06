select e.FirstName + ' ' + e.LastName as [Name],
	   CONCAT(count(r.CloseDate), '/', (
	   select COUNT(rep.OpenDate) from Reports as rep
	   where format(rep.OpenDate, 'yyyy') = 2016 and rep.EmployeeId = e.Id
	   )) as Datete
from Employees as e
join Reports as r on r.EmployeeId = e.Id
where format(r.OpenDate, 'yyyy') = 2016 or format(r.CloseDate, 'yyyy') = 2016
group by e.FirstName + ' ' + e.LastName, e.Id
order by [Name], e.Id