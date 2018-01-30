CREATE OR ALTER TRIGGER TR_RepStatusUpdate ON Reports FOR UPDATE
AS
BEGIN
DECLARE @MyCursor CURSOR;
	declare @OldCloseDate AS DateTime
	declare @NewCloseDate AS DateTime
	declare @RepID as INT

	SET @MyCursor = CURSOR FOR
    select * from inserted    

    OPEN @MyCursor 
    FETCH NEXT FROM @MyCursor 

    WHILE @@FETCH_STATUS = 0
    BEGIN
    
	set @OldCloseDate = (select d.CloseDate from deleted as d where @@ROWCOUNT = @MyCursir)
	set @NewCloseDate = (select i.CloseDate from inserted as i where @@ROWCOUNT = @MyCursir)
	set @RepID = (select d.Id from deleted as d where @@ROWCOUNT = @MyCursir)

	IF(@OldCloseDate <> @NewCloseDate)
	begin
		Update Reports
		set StatusId = 3
		where Id = @RepID
	end

      FETCH NEXT FROM @MyCursor 
    END; 

    CLOSE @MyCursor ;
    DEALLOCATE @MyCursor;

END

UPDATE Reports
SET CloseDate = GETDATE()
WHERE EmployeeId = 24;

