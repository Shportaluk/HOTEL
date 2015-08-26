CREATE TABLE tbl_rooms
(
	Id INT NOT NULL,
	Name NCHAR( 255 ) NOT NULL,
	Is_reserve INT NOT NULL,
	CONSTRAINT PK_tbl_rooms_Id PRIMARY KEY ( Id )
);
GO
CREATE PROCEDURE reserve
	@I INT
AS
	IF( (SELECT Is_reserve FROM tbl_rooms WHERE Id = @I) = 0 )
	BEGIN
		UPDATE tbl_rooms
		SET Is_reserve=1
		WHERE Id=@I;
	END
	ELSE
	BEGIN
		RAISERROR ( 'Цей номер вже заброньований !!! Виберіть інший номер', 16, 1 )
	END
	