use Tutorstore;
alter table Tutors add IsSelected int;
go
update Tutors set IsSelected = 0;