select u.Username

 from Users as u
 join Reports as r on r.UserId = u.Id
 where (TRY_CAST(Left(u.Username, 1) as int) is not null
 or TRY_CAST(Right(u.Username, 1) as int) is not null)
 and (r.CategoryId like TRY_CAST(Left(u.Username, 1) as int) 
 or r.CategoryId like TRY_CAST(Right(u.Username, 1) as int))
 order by u.Username