use ceglakoniecna
Select Dzien, Sum(Suma) as [Suma z dnia]  from Sprzedaz group by Dzien

Select p.Imie, p.Nazwisko, COALESCE(sum(s.Suma), 0) as [Suma pracownika]
from Pracownicy as p
left join Sprzedaz as s on p.Id = s.PracownikId
Group by p.Imie, p.Nazwisko


Select top 1 p.Imie, p.Nazwisko
from Pracownicy as p
left join Sprzedaz as s on p.Id = s.PracownikId
Group by p.Imie, p.Nazwisko
Order by COALESCE(sum(s.Suma), 0)
