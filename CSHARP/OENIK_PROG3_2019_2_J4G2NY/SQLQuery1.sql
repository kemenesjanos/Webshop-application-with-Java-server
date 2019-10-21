IF OBJECT_ID('Users', 'U') IS NOT NULL DROP TABLE Users;
IF OBJECT_ID('Sales', 'U') IS NOT NULL DROP TABLE Sales;
IF OBJECT_ID('Loc', 'U') IS NOT NULL DROP TABLE Loc;

CREATE TABLE Loc( ID NUMERIC(10),
Country VARCHAR(20),
Street VARCHAR(40),
House_Number NUMERIC(4),
Zip_Code NUMERIC(4),
CONSTRAINT location_pk PRIMARY KEY(ID)
);

CREATE TABLE Users( FullName VARCHAR NOT NULL,
Location_ID NUMERIC(10),
Email VARCHAR(30) NOT NULL,
Phone_Number NUMERIC(15),
Birth_Date DATE,
Registration_Date DATE,
CONSTRAINT users_pk PRIMARY KEY(Email),
CONSTRAINT location_fk FOREIGN KEY(Location_ID) REFERENCES
Loc(ID),
CONSTRAINT chk_phone CHECK( LEN(Phone_Number) >= 10)
);

CREATE TABLE Sales( ID NUMERIC(10),
Seller_Email VARCHAR(30),
Buyer_Email VARCHAR(30),
Transaction_Date DATE,
Product_Name VARCHAR(30),
Price NUMERIC(10),
Category VARCHAR(15),
Shipping_Cost NUMERIC(10),
CONSTRAINT sales_pk PRIMARY KEY(ID),
CONSTRAINT seller_fk FOREIGN KEY(Seller_Email) REFERENCES
Users(Email),
CONSTRAINT buyer_fk FOREIGN KEY(Buyer_Email) REFERENCES
Users(Email),
CONSTRAINT chk_price CHECK(Price  > 0),
CONSTRAINT chk_scost CHECK(Shipping_Cost  > 0),
CONSTRAINT chk_category CHECK( Category IN('ruházat', 'elektronika', 'háztartási', 'élelmiszer', 'mezőgazdasági', 'papír-írószer', 'játék', 'gépjármű', 'egyéb')));




INSERT INTO Loc VALUES (1,'Oroszország','Jagyiszlaw',23,1211);
INSERT INTO Loc VALUES (2,'Bajorország','Hanska',44,1245);
INSERT INTO Loc VALUES (3,'Magyarország','Kodály Zoltán',78,3254);
INSERT INTO Loc VALUES (4,'USA','Carrot',1,5555);
INSERT INTO Loc VALUES (5, 'Magyarország','Zajos',2,1362);
INSERT INTO Loc VALUES (6,'USA','Johnny',31,7844);
INSERT INTO Loc VALUES (7, 'Magyarország','Karalábé',5,1320);
INSERT INTO Loc VALUES (8, 'Magyarország','NyamNyam',21,7786);
INSERT INTO Loc VALUES (9,'Magyarország','Zeller',2,7564);
INSERT INTO Loc VALUES (10,'Egyiptom','Hippopotamus',41,2221);
INSERT INTO Loc VALUES (11,'Franciaország','Jean-Pierre',4,4516);

INSERT INTO Users VALUES ('Andrea',0,'andreaemail',15428546324,'1988-02-02','2000-02-02');
INSERT INTO Users VALUES ('Balázs',1,'balazsfreemail',24518542652, '1999-05-12', '2009-11-01');
INSERT INTO Users VALUES ('Mónika',2,'monikaemail',52416525789, '1965-11-11', '2001-09-11');
INSERT INTO Users VALUES ('Hegyessy Levente',3,'hegyeshaemail',512415241356, '1955-11-11', '2019-10-19');
INSERT INTO Users VALUES ('Tudor',4,'dudorkafreemail',451245846541, '1999-05-02', '2001-03-12');
INSERT INTO Users VALUES ('Karcsika',5,'aranyosunokagmail',25124222222, '2005-12-24', '2011-08-15');
INSERT INTO Users VALUES ('Piroska',6,'kekzoldcitromail',54215462151, '1989-09-11', '2008-10-26');
INSERT INTO Users VALUES ('Tala Béla',7,'tlabalgmail',11111211458, '1975-06-14', '2000-06-06');
INSERT INTO Users VALUES ('Alexandrai Vlagyislaw',8,' vlagygmail',42154446555 , '2005-01-01', '2018-07-11');
INSERT INTO Users VALUES ('Gyakorlavics Kristóf',9,'gykgmail',55546289563, '2007-05-10', '2019-09-11');
INSERT INTO Users VALUES ('Karalábé Károly',10,'zellergmail',55542122263, '1966-06-06', '2006-06-06');

INSERT INTO Sales VALUES(1032,'gykgmail', 'tlabalgmail','2016-06-06','Karalábé',14,'élelmiszer',0);
INSERT INTO Sales VALUES(3213,'hegyeshaemail', 'zellergmail','2017-11-22','Távirányítós autó',4000,'játék',500);
INSERT INTO Sales VALUES(10, 'andreaemail', 'dudorkafreemail','2009-01-06','szoknya',6000,'ruházat',0);
INSERT INTO Sales VALUES(311, 'monikaemail', 'aranyosunokagmail','2014-03-27','robotgép',5200,'háztartási',1200);
INSERT INTO Sales VALUES(201, 'vlagygmail', 'tlabalgmail','2010-11-02','olló',2400, 'papír-írószer',0);
INSERT INTO Sales VALUES(146, 'zellergmail', 'aranyosunokagmail','2008-05-03','nyaklánc',10000,'egyéb',2000);
INSERT INTO Sales VALUES(854,'balazsfreemail', 'kekzoldcitromail', '2016-10-03','gereblye', 6400, 'mezőgazdasági',2100);
INSERT INTO Sales VALUES(432, 'aranyosunokagmail', 'tlabalgmail', '2006-12-21','focimez',8000,'egyéb',1000);
INSERT INTO Sales VALUES(887, 'gykgmail', 'tlabalgmail', '2019-09-01','Gucci kávé',20000, 'élelmiszer',13000);
INSERT INTO Sales VALUES(324, 'hegyeshaemail', 'dudorkafreemail', '2016-03-03','csirke',2000,'élelmiszer',0);
INSERT INTO Sales VALUES(56, 'kekzoldcitromail', 'vlagygmail', '2006-02-27','szenzor készlet', 9600, 'elektronika',1500);
INSERT INTO Sales VALUES(852, 'gykgmail', 'zellergmail', '2015-04-17','Oscar-díj',4006,'egyéb',2000);

