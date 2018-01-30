select r.OpenDate,
	   r.Description,
	   u.Email as [Reporter Email]
 from Reports as r
join Categories as c on c.Id = r.CategoryId
join Users as u on u.Id = r.UserId
where r.CloseDate is null 
  and LEN(r.Description) > 20
  and r.Description like '%str%'
  and c.DepartmentId in (1, 4, 5)
order by r.OpenDate, u.Email, r.Id