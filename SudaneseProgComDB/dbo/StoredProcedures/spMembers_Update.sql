CREATE PROCEDURE [dbo].[spMembers_Update]
@FullName nvarchar(250),
@Job nvarchar(250),
@Id int 
AS
BEGIN
Update Members Set FullName = @FullName ,Job = @Job  Where Id = @Id
END
