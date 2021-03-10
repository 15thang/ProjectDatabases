--DEELNEMER
CREATE TABLE [dbo].[Deelnemer]
(
[StudentID] INT NOT NULL FOREIGN KEY REFERENCES [Student](StudentID), 
[ActiviteitID] INT NOT NULL FOREIGN KEY REFERENCES [Activiteit](ActiviteitID), 
PRIMARY KEY([StudentID], [ActiviteitID]),
)


