CREATE PROCEDURE [dbo].[spMembers_Delete]
@Id int
AS
BEGIN
Delete from Members Where Id = @Id
END
