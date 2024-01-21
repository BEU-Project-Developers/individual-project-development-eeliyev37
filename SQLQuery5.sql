create table BillTbl(BCode int primary key identity, BDate date, Customer int foreign key references CustomerTbl(CustCode), Amount int, PaymentMode varchar(50));
