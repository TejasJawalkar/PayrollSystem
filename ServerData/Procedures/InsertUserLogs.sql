CREATE PROC [InsertUserLogs]
(
	@UserId  NVARCHAR(150),
	@BrowswerUsed NVARCHAR(150),
	@IdAddress  NVARCHAR(500),
	@Comment  NVARCHAR(500),
	@CreatedDateTime DateTime
)
AS
BEGIN
	DECLARE @result SMALLINT
	
	INSERT INTO TsyUserLogs(UserId, BrowswerUsed, IdAddress, Comment,CreatedDateTime) VALUES (@UserId, @BrowswerUsed, @IdAddress, @Comment, @CreatedDateTime)
END;


