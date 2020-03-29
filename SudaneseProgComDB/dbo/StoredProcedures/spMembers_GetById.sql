CREATE PROCEDURE [dbo].[spMembers_GetById]
@Id int
AS
BEGIN

Select * from Members Where Id = @Id
END
