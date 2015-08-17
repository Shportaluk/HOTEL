CREATE TABLE tbl_rooms
(
	Id INT NOT NULL,
	Name NCHAR( 255 ) NOT NULL,
	Is_reserve INT NOT NULL,
	CONSTRAINT PK_tbl_rooms_Id PRIMARY KEY ( Id )
);

INSERT INTO tbl_rooms VALUES ( 0,	'���������',						0 );
INSERT INTO tbl_rooms VALUES ( 1,	'��������',						1 );
INSERT INTO tbl_rooms VALUES ( 2,	'��������',						0 );
INSERT INTO tbl_rooms VALUES ( 3,	'����',								1 );
INSERT INTO tbl_rooms VALUES ( 4,	'���� �����������',					0 );
INSERT INTO tbl_rooms VALUES ( 5,	'����������� � ����������� ����',	1 );

SELECT * FROM tbl_rooms;
SELECT Id FROM tbl_rooms WHERE Is_reserve = 1;
SELECT Is_reserve FROM tbl_rooms WHERE Id = 0;

UPDATE tbl_rooms
SET Is_reserve=1
WHERE Id=1;

DROP TABLE tbl_rooms;