ALTER TABLE Minions
ADD TownId INT FOREIGN KEY(TownId) references Towns(ID)