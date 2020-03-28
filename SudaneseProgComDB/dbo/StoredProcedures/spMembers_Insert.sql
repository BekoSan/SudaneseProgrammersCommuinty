CREATE PROCEDURE [dbo].[spMembers_Insert]
@FullName nvarchar(250),
@Job nvarchar(250)
AS
BEGIN
Insert into Members(FullName,Job) Values(@FullName,@Job)
END