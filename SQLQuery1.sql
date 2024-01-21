create table ItemTbl(ItCode int primary key identity, ItName varchar(80), ItCategory int foreign key references CategoryTbl(CatCode), Price varchar(10), Stock varchar(15), Manufacturer varchar(50));
