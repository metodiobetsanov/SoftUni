select c.Name,
		count(*) as [Reports Number]
 from Categories as c,
 (case
 when count(*) = 1 then s.label
 end ) as [Main Status]
join Reports as r on r.CategoryId = c.Id
join Status as s on s.Id = r.StatusId
where StatusId in(1,2)
group by c.Name