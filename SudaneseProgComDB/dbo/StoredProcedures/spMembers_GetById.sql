CREATE PROCEDURE [dbo].[spMembers_GetById]
@MemberId int
AS
BEGIN

Select * from Members Where Id = @MemberId
END