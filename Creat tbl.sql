CREATE TABLE tbl_rooms
(
	Id INT NOT NULL,
	Name NCHAR( 255 ) NOT NULL,
	Is_reserve INT NOT NULL,
	CONSTRAINT PK_tbl_rooms_Id PRIMARY KEY ( Id )
);

CREATE PROCEDURE reserve
	@I INT
AS
	UPDATE tbl_rooms
	SET Is_reserve=1
	WHERE Id=1;